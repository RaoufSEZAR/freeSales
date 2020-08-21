Public Class item_sales
    Private Sub İtem_sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_allSale(DateTimePicker1.Value, DateTimePicker2.Value)
        DataGridView1.DataSource = dt_allSales


    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Load_allSale(DateTimePicker1.Value, DateTimePicker2.Value)
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Load_allSale(DateTimePicker1.Value, DateTimePicker2.Value)
    End Sub
End Class