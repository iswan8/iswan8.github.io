Imports System.Data.Odbc
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormDataBarang
    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Private Sub FormDataBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()

    End Sub
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        PictureBox1.Image = Nothing

        Call koneksi()
        Da = New OdbcDataAdapter("Select * From tbjualjam", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbjualjam")
        DataGridView3.DataSource = Ds.Tables("tbjualjam")
    End Sub
    Sub koneksi()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=dbjualjam;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        FormUtama.Show()
        Me.Hide()
    End Sub



    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Dim i As Integer
        i = DataGridView3.CurrentRow.Index

        On Error Resume Next
        TextBox1.Text = DataGridView3.Item(0, i).Value.ToString()
        TextBox2.Text = DataGridView3.Item(1, i).Value.ToString()
        TextBox3.Text = DataGridView3.Item(2, i).Value.ToString()

        Dim imageData As Byte() = DirectCast(DataGridView3.Item(3, i).Value, Byte())

        Using ms As New System.IO.MemoryStream(imageData)
            PictureBox1.Image = Image.FromStream(ms)
        End Using
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        FormAdmin.Show()
        Me.Hide()
    End Sub

    Private Sub BiodataToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BiodataToolStripMenuItem1.Click
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

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub
End Class