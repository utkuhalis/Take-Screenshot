Public Class Form1
    Dim Say As Integer = 0
    Dim save As New SaveFileDialog
    Dim ScreenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
    Dim BMP As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
    Dim g As System.Drawing.Graphics

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Visible = False 'Çekilen resimde bizim görünmememiz için şart.
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Say += 1

        If Say = 1 Then
            g = System.Drawing.Graphics.FromImage(BMP)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), ScreenSize)
            PictureBox1.BackgroundImage = BMP
            save.Title = "Save Screen Picture Image"
            save.Filter = "Png File(*.png)|*.png"

            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Kayıt Edecek
                BMP.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png)
                Label1.Text = "Kayıt: " & save.FileName
                Timer1.Stop()
                Me.Visible = True
                Say = 0
            Else
                'Kayıt Etmicek
                Timer1.Stop()
                Me.Visible = True
                Say = 0
            End If
        End If
    End Sub
End Class
