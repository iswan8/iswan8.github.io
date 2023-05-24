Public Class FormUtama


    Private Sub FormUtama_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Dim p As New System.Drawing.Drawing2D.GraphicsPath()
        p.AddEllipse(0, 0, PictureBox2.Width - 1, PictureBox2.Height - 1)
        PictureBox2.Region = New Region(p)
    End Sub

    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelName.BackColor = Color.Transparent
        PictureBox1.BackColor = Color.Transparent
    End Sub

    Private Sub TampikanDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TampikanDataToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub BiodataSayaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiodataSayaToolStripMenuItem.Click
        FormBiodata.Show()
        Me.Hide()

    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem1.Click



        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo)


        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        End If
    End Sub
End Class