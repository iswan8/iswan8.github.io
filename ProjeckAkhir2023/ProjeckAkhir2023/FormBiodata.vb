Public Class FormBiodata
    Private Sub FormBiodata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        FormUtama.Show()
        Me.Hide()
    End Sub

    Private Sub TampilkanDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TampilkanDataToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click

        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo)


        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        End If
    End Sub
End Class