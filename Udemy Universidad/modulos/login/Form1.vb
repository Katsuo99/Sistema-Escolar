Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub


    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub
    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_usuarios()
        If DataGridView1.RowCount > 0 Then
            Me.Hide()
            mp_matriculas.Show()

        Else
            MessageBox.Show("Error en usuario y contraseña", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub cargar_usuarios()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("validar_usuario", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@usuario", TextBox1.Text)
            da.SelectCommand.Parameters.AddWithValue("@contraseña", TextBox2.Text)
            da.Fill(dt)
            DataGridView1.DataSource = dt
            cerrar()
            multilinea(DataGridView1)
        Catch ex As Exception : MsgBox(ex.Message)

        End Try

    End Sub
End Class
