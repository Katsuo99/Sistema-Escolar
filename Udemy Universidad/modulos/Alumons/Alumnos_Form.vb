Imports System.Data.SqlClient
Public Class Alumnos_Form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel3.Visible = False
    End Sub

    Private Sub Alumnos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Panel3.Visible = False
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_alumnos", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@apellido_paterno", Textpa.Text)
            cmd.Parameters.AddWithValue("@apellido_materno", Textma.Text)
            cmd.Parameters.AddWithValue("@nombre", Textnombres.Text)
            cmd.Parameters.AddWithValue("@numero_documento", Textno_doc.Text)
            cmd.Parameters.AddWithValue("@estado", "ACTIVO")
            cmd.ExecuteNonQuery()
            cerrar()
            mostrar()
            Panel3.Visible = False
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Sub mostrar()
        Dim dt As New DataTable
        Dim data As SqlDataAdapter
        Try
            abrir()
            data = New SqlDataAdapter("mostrar_alumnos", conexion)
            data.Fill(dt)
            DataGridView1.DataSource = dt
            cerrar()
            multilinea(DataGridView1)
            DataGridView1.Columns(1).Visible = False
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("estado").Value = "ELIMINADO" Then
                    row.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Strikeout Or FontStyle.Bold)
                    row.DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try


    End Sub

    Private Sub AgregarAlumnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarAlumnoToolStripMenuItem.Click
        Panel3.Visible = True
        Textpa.Clear()
        Textma.Clear()
        Textnombres.Clear()
        Textno_doc.Clear()
        GuardarCambiosToolStripMenuItem.Visible = False
        GuardarToolStripMenuItem.Visible = True
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim estado As String
            estado = DataGridView1.SelectedCells.Item(6).Value
            If estado = "ELIMINADO" Then
                rest_alumno()
            Else
                Panel3.Visible = True
                GuardarCambiosToolStripMenuItem.Visible = True
                GuardarToolStripMenuItem.Visible = False
                Textnombres.Text = DataGridView1.SelectedCells.Item(2).Value
                Textpa.Text = DataGridView1.SelectedCells.Item(3).Value
                Textma.Text = DataGridView1.SelectedCells.Item(4).Value
                Textno_doc.Text = DataGridView1.SelectedCells.Item(5).Value
                Label4.Text = DataGridView1.SelectedCells.Item(1).Value
            End If
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub
    Sub rest_alumno()
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Restaurar Este Usuario?", "Restaurar Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If result = DialogResult.OK Then
            Try
                Dim cmd As New SqlCommand
                abrir()
                cmd = New SqlCommand("restaurar_alumno", conexion)
                cmd.CommandType = 4
                cmd.Parameters.AddWithValue("@id", DataGridView1.SelectedCells.Item(1).Value)
                cmd.ExecuteNonQuery()
                cerrar()
                mostrar()
            Catch ex As Exception : MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_alumno", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@apellido_paterno", Textpa.Text)
            cmd.Parameters.AddWithValue("@apellido_materno", Textma.Text)
            cmd.Parameters.AddWithValue("@nombre", Textnombres.Text)
            cmd.Parameters.AddWithValue("@numero_documento", Textno_doc.Text)
            cmd.Parameters.AddWithValue("@id", Label4.Text)
            cmd.ExecuteNonQuery()
            cerrar()
            mostrar()
            Panel3.Visible = False
        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = Me.DataGridView1.Columns.Item("eli").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Desea Eliminar Este Usuario?", "Eliminar Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If result = DialogResult.OK Then
                Try
                    For Each row As DataGridViewRow In DataGridView1.SelectedRows
                        Try
                            Dim cmd As New SqlCommand
                            abrir()
                            cmd = New SqlCommand("eliminar_alumno", conexion)
                            cmd.CommandType = 4
                            cmd.Parameters.AddWithValue("@id", DataGridView1.SelectedCells.Item(1).Value)
                            cmd.ExecuteNonQuery()
                            cerrar()
                            mostrar()
                        Catch ex As Exception : MsgBox(ex.Message)

                        End Try
                    Next
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub RestaurarAlumnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarAlumnoToolStripMenuItem.Click
        rest_alumno()
    End Sub
End Class