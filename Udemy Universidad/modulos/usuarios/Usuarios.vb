Imports System.Data.SqlClient
Public Class Usuarios
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        mostrar()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Panel4.Visible = True
        GuardarCambiosToolStripMenuItem.Visible = False
        GuardarToolStripMenuItem.Visible = True
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@nombres", TextBox2.Text)
            cmd.Parameters.AddWithValue("@usuario", TextBox3.Text)
            cmd.Parameters.AddWithValue("@contraseña", TextBox4.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            mostrar()
            Panel4.Visible = False
        Catch ex As Exception : MsgBox(ex.Message)

        End Try

    End Sub
    Sub mostrar()
        Dim dt As New DataTable
        Dim data As SqlDataAdapter
        Try
            abrir()
            data = New SqlDataAdapter("mostrar_usuario", conexion)
            data.Fill(dt)
            DataGridView1.DataSource = dt
            cerrar()
            multilinea(DataGridView1)
            DataGridView1.Columns(1).Visible = False
        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Try
            Panel4.Visible = True
            GuardarCambiosToolStripMenuItem.Visible = True
            GuardarToolStripMenuItem.Visible = False
            TextBox2.Text = DataGridView1.SelectedCells.Item(2).Value
            TextBox3.Text = DataGridView1.SelectedCells.Item(3).Value
            TextBox4.Text = DataGridView1.SelectedCells.Item(4).Value
            Label5.Text = DataGridView1.SelectedCells.Item(1).Value
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@id", Label5.Text)
            cmd.Parameters.AddWithValue("@nombres", TextBox2.Text)
            cmd.Parameters.AddWithValue("@usuario", TextBox3.Text)
            cmd.Parameters.AddWithValue("@contraseña", TextBox4.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            mostrar()
            Panel4.Visible = False
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = Me.DataGridView1.Columns.Item("eli").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Desea Eliminar Este Usuario?", "Eliminar Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If result = DialogResult.OK Then
                Try
                    Dim cmd As New SqlCommand
                    abrir()
                    cmd = New SqlCommand("eliminar_usuario", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@id", DataGridView1.SelectedCells.Item(1).Value)
                    cmd.ExecuteNonQuery()
                    cerrar()
                    mostrar()
                Catch ex As Exception : MsgBox(ex.Message)

                End Try
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        buscar()
    End Sub

    Sub buscar()
        Dim dt As New DataTable
        Dim data As SqlDataAdapter
        Try
            abrir()
            data = New SqlDataAdapter("buscar_usuario", conexion)
            data.SelectCommand.CommandType = 4
            data.SelectCommand.Parameters.AddWithValue("@letra", TextBox1.Text)
            data.Fill(dt)
            DataGridView1.DataSource = dt
            cerrar()
        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel4.Visible = False
    End Sub
End Class