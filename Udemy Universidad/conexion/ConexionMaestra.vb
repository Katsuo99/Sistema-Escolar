Imports System.Data.SqlClient
Module ConexionMaestra
    Public conexion As New SqlConnection("Data Source=DESKTOP-FFHL56F\WINCCPLUSMIG2014;Initial Catalog=Colegio;Integrated Security=True")
    Sub abrir()
        If conexion.State = 0 Then
            conexion.Open()
        End If
    End Sub
    Sub cerrar()
        If conexion.State = 1 Then
            conexion.Close()
        End If
    End Sub
End Module
