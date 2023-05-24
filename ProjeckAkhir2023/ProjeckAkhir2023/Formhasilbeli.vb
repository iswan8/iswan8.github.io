Public Class Formhasilbeli
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormUtama.Show()
        Me.Hide()
    End Sub

    Private Sub Formhasilbeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hitunggg()
    End Sub
    Private Function hitunggg() As Integer
        Dim jumlah As Integer
        Dim banyak As Integer
        Dim hasil As Integer

        If Integer.TryParse(FormUser.TextBox2.Text, jumlah) AndAlso Integer.TryParse(FormUser.TextBox5.Text, banyak) Then
            PictureBox1.Image = FormUser.PictureBox1.Image
            Label10.Text = FormUser.TextBox3.Text
            Label9.Text = FormUser.TextBox5.Text
            Label8.Text = (jumlah * banyak).ToString()
            hasil = jumlah * banyak
        Else
            MessageBox.Show("Input tidak valid!")
            hasil = 0 ' Nilai default jika konversi gagal
        End If

        Return hasil
    End Function
End Class