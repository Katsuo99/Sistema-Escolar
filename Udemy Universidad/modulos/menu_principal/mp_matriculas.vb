Public Class mp_matriculas


    Private Sub mp_matriculas_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.Dispose()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub


End Class