Imports System.Data.Odbc
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class FormUser
    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String
    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub
    Sub KondisiAwal()




        Call koneksi()
        Da = New OdbcDataAdapter("Select * From tbjualjam", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbjualjam")
        DataGridView1.DataSource = Ds.Tables("tbjualjam")
    End Sub
    Sub koneksi()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=dbjualjam;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Call read()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        On Error Resume Next
        TextBox1.Text = DataGridView1.Item(0, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(2, i).Value.ToString()

        Dim imageData As Byte() = DirectCast(DataGridView1.Item(3, i).Value, Byte())

        Using ms As New System.IO.MemoryStream(imageData)
            PictureBox1.Image = Image.FromStream(ms)
        End Using
    End Sub
    Sub read()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Call koneksi()
        Cmd = New OdbcCommand(" Select * From tbjualjam Where nama like '%" & TextBox4.Text & "%'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Rd.HasRows Then
            Call koneksi()
            Rd.Close()
            Da = New OdbcDataAdapter("Select * From tbjualjam Where nama like '%" & TextBox4.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "Dapat")
            DataGridView1.DataSource = Ds.Tables("Dapat")
            DataGridView1.ReadOnly = True


        Else
            Rd.Close()
            MsgBox("Maaf Data Tidak Ditemukan")
        End If


    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        FormUtama.Show()
        Me.Hide()
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub BiodataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiodataToolStripMenuItem.Click
        FormBiodata.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo)


        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub



    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
            MsgBox("maaf id hanya bisa diisi angka!!")
        End If
        If e.KeyChar = "0" Then
            e.Handled = True
            MsgBox("maaf id barang tidak bisa diisi 0!!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Formliathasil.Show()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Formhasilbeli.Show()
        Me.Hide()
        Call lenyap()
    End Sub
    Sub lenyap()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        PictureBox1.Image = Nothing
    End Sub
End Class