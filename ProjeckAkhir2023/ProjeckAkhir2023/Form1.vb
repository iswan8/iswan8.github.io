Public Class Form1


    Private Sub btnLogin_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLogin.MouseDown
        btnLogin.ForeColor = Color.Black
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatAppearance.MouseDownBackColor = Color.White

    End Sub

    Private Sub btnLogin_MouseUp(sender As Object, e As MouseEventArgs) Handles btnLogin.MouseUp
        btnLogin.ForeColor = Color.White
        btnLogin.FlatAppearance.BorderSize = 2


    End Sub

    Dim x, y As Integer
    Dim newpoint As New System.Drawing.Point



    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub


    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= (x)
            newpoint.Y -= (y)
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= (x)
            newpoint.Y -= (y)
            Me.Location = newpoint
        End If
    End Sub
    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Left = Me.Width
        Me.Height = 475
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Panel2.Left > 15 Then
            Panel2.Left = Int(Panel2.Left - 10)
        Else
            Panel2.Left = 15
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If (txtname.Text = "user" And txtpw.Text = "321") Then
            FormUser.Show()
            Me.Hide()
        ElseIf (txtname.Text = "admin" And txtpw.Text = "123") Then
            FormAdmin.Show()
            Me.Hide()
        Else
            TimerTurun.Enabled = True
            TimerNaik.Enabled = False

        End If
        bersih()

    End Sub


    Private Sub TimerTurun_Tick(sender As Object, e As EventArgs) Handles TimerTurun.Tick
        If Me.Height < 575 Then
            Me.Height = Int(Me.Height + 5)
        Else
            Me.Height = 575
            TimerDurasi.Enabled = True
        End If
    End Sub

    Private Sub TimerNaik_Tick(sender As Object, e As EventArgs) Handles TimerNaik.Tick
        If Me.Height > 475 Then
            Me.Height = Int(Me.Height - 5)
        Else
            Me.Height = 475
            TimerDurasi.Enabled = False
        End If
    End Sub

    Private Sub TimerDurasi_Tick(sender As Object, e As EventArgs) Handles TimerDurasi.Tick
        TimerTurun.Enabled = False
        TimerNaik.Enabled = True
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call hapus()
    End Sub
    Private Sub hapus()
        txtname.Text = ""
        txtpw.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo)


        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        End If
    End Sub


    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= (x)
            newpoint.Y -= (y)
            Me.Location = newpoint
        End If
    End Sub
    Sub bersih()
        txtname.Text = ""
        txtpw.Text = ""
    End Sub
End Class
