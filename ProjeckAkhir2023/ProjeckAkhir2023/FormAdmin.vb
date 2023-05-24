Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.IO

Public Class FormAdmin
    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Dim fileName As String
    'Dim input As String = TextBox1.Text.Trim()
    'Dim parsedValue As Integer

    'If Integer.TryParse(input, parsedValue) Then
    'If parsedValue > 0 Then
    'If Not IsNumberAlreadyExists(parsedValue) Then

    'Else
    '               MsgBox("Maaf, Kode Barang sudah ada.")

    'End If
    'Else
    '           MsgBox("Maaf, Kode Barang harus lebih dari 0.")
    '          TextBox1.Text = ""
    'End If
    'ElseIf
    '       MsgBox("Maaf, Kode Barang harus berupa angka.")
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or PictureBox1.Image Is Nothing Then
            MsgBox("Maaf Data Belum Lengkap..!")



        Else
            Call koneksi()

            Dim openFileDialog3 As New OpenFileDialog()

            Dim folderPath As String = Path.Combine(Application.StartupPath, "gambar")
            'Dim fileName As String = Path.GetFileName(openFileDialog3.FileName)
            'Dim filePath As String = Path.Combine(folderPath, fileName)

            'PictureBox1.Image.Save(filePath)
            Dim imageData As Byte() = File.ReadAllBytes(fileName)
            'MsgBox(fileName)
            Dim query As String = "INSERT INTO tbjualjam (id, nama, harga, gambari) VALUES (?, ?, ?, ?)"

            Dim ms As New System.IO.MemoryStream()
            Dim arrImage() As Byte = ms.GetBuffer()
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            ms.Close()

            Dim p As New SqlParameter("@gambari", SqlDbType.Image)
            p.Value = arrImage


            Using conn As New OdbcConnection(MyDB)
                conn.Open()
                Using cmd As New OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@nama", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@harga", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@gambari", imageData)
                    cmd.ExecuteNonQuery()
                End Using

            End Using
            Call KondisiAwal()
        End If

    End Sub

    Sub koneksi()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=dbjualjam;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "JPG files |*.jpg|BMP Files|*.bmp|JPEG Files|*.jpeg|PNG Files|*.png|All File(*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True


        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
            fileName = openFileDialog1.FileName
        End If
    End Sub


    Private Sub TampilkanDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TampilkanDataToolStripMenuItem.Click
        FormDataBarang.Show()
        Me.Hide()

    End Sub

    Private Sub FormAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()

    End Sub
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        PictureBox1.Image = Nothing


        btnTambah.Text = "Create"
        Button3.Text = "Update"
        btnDelete.Text = "Delete"


        Call koneksi()
        Da = New OdbcDataAdapter("Select * From tbjualjam", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbjualjam")
        DataGridView2.DataSource = Ds.Tables("tbjualjam")
        FormDataBarang.DataGridView3.DataSource = Ds.Tables("tbjualjam")
        FormUser.DataGridView1.DataSource = Ds.Tables("tbjualjam")
    End Sub
    Sub tampilData()
        Call koneksi()
        Da = New OdbcDataAdapter("select * from tbjualjam", Conn)
        Ds = New DataSet
        Da.Fill(Ds)
        DataGridView2.DataSource = Ds.Tables(0)
        DataGridView2.ReadOnly = True
        FormDataBarang.DataGridView3.ReadOnly = True
        FormUser.DataGridView1.ReadOnly = True
        FormDataBarang.DataGridView3.DataSource = Ds.Tables("tbjualjam")
        FormUser.DataGridView1.DataSource = Ds.Tables("tbjualjam")
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand(" Select * From tbjualjam Where nama like '%" & TextBox3.Text & "%'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Rd.HasRows Then
            Call koneksi()
            Rd.Close()
            Da = New OdbcDataAdapter("Select * From tbjualjam Where nama like '%" & TextBox3.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "Dapat")
            DataGridView2.DataSource = Ds.Tables("Dapat")
            DataGridView2.ReadOnly = True


        Else
            Rd.Close()
            MsgBox("Maaf Data Tidak Ditemukan")
        End If
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If TextBox1.Text = "" Then
            MsgBox("Tidak Ada Data Yang Di Hapus")

        Else
            Call koneksi()
            Cmd = New OdbcCommand("delete from tbjualjam where id='" & TextBox1.Text & "'", Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("hapus Data Sukses")
            KondisiAwal()
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call bersih()
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Maaf Data Belum Lengkap..!")
        Else
            Try
                Call koneksi()
                Dim query As String = "UPDATE tbjualjam SET id = ?, nama = ?, harga = ? WHERE id = ?"
                Cmd = New OdbcCommand(query, Conn)
                Cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                Cmd.Parameters.AddWithValue("@nama", TextBox2.Text)
                Cmd.Parameters.AddWithValue("@harga", TextBox4.Text)
                Cmd.Parameters.AddWithValue("@idlama", TextBox1.Text)

                Cmd.ExecuteNonQuery()
                MsgBox("Update Data Berhasil")
                tampilData()
            Catch ex As Exception
                MsgBox("Terjadi kesalahan saat melakukan update data: " & ex.Message)
            End Try
        End If
        tampilData()
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        FormUtama.Show()
        Me.Hide()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub



    Private Sub BiodataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiodataToolStripMenuItem.Click
        FormBiodata.Show()
        Me.Hide()
    End Sub

    Private Sub LogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogToolStripMenuItem.Click

        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo)


        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Function IsNumberAlreadyExists(number As Integer) As Boolean
        ' Menggunakan koneksi database dengan ODBC
        Dim connectionString As String = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=dbjualjam;Server=localhost;uid=root"
        Dim connection As New OdbcConnection(connectionString)
        Dim query As String = "SELECT COUNT(*) FROM tbjualjam WHERE id = ?"

        Dim command As New OdbcCommand(query, connection)
        command.Parameters.AddWithValue("@id", number)

        connection.Open()
        Dim count As Integer = CInt(command.ExecuteScalar())
        connection.Close()

        Return count > 0
    End Function


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
            MsgBox("maaf id hanya bisa diisi angka!!")
        End If
        If e.KeyChar < "0" Then
            e.Handled = True
            MsgBox("maaf id barang tidak bisa diisi 0!!")
        End If
    End Sub
End Class