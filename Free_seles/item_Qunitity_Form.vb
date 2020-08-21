Public Class item_Qunitity_Form
    Public Property DataGridView2 As Object

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsNumeric(TextBox1.Text) Then

            'DataGridView2.CurrentRow.Cells("total").Value = DataGridView2.CurrentRow.Cells("item_Qunitity").Value * DataGridView2.CurrentRow.Cells("item_Price").Value
            'sale_total = DataGridView2.CurrentRow.Cells("total").Value
            Update_Salesbysaleno(TextBox1.Text,  sale_no)
            Sale_Form.Load_Sale2()

            Close()

        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class