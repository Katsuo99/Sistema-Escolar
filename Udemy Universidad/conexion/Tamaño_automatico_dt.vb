Module Tamaño_automatico_dt
    Public Sub multilinea(ByRef list As DataGridView)
        list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        list.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        list.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        list.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        list.EnableHeadersVisualStyles = False

        Dim stycabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        stycabeceras.BackColor = Color.White
        stycabeceras.ForeColor = Color.Black
        stycabeceras.Font = New Font("Sogoe UI", 15, FontStyle.Regular Or FontStyle.Bold)
        list.ColumnHeadersDefaultCellStyle = stycabeceras
    End Sub
End Module
