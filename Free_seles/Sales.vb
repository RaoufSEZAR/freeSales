Public Class Sales
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Customer_Form.Show()

    End Sub

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Sale_View3(DateTimePicker1.Value, DateTimePicker2.Value)
        DataGridView1.DataSource = dt_Sale_View3
        Total_sales()

        Load_Customers()
        ComboBox1.DataSource = dt_Customer
        ComboBox1.DisplayMember = "Customer_Name"
        ComboBox1.ValueMember = "customer_id"

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Load_Sale_View3(DateTimePicker1.Value, DateTimePicker2.Value)
        Total_sales()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Load_Sale_View3(DateTimePicker1.Value, DateTimePicker2.Value)
        Total_sales()
    End Sub

    Public Sub Total_sales()

        Dim sum As Double
        Dim Qunitity As Double

        For s As Integer = 0 To DataGridView1.RowCount - 1

            sum = sum + DataGridView1.Item("total", s).Value
            Qunitity = Qunitity + DataGridView1.Item("item_Qunitity", s).Value
        Next

        Label2.Text = sum
        Label3.Text = Qunitity
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Load_Sale_View_by_item_name(DateTimePicker1.Value, DateTimePicker2.Value, TextBox1.Text)
        Total_sales()

    End Sub

    Sub get_customer_name()
        Load_Sale_View_by_customer_id(DateTimePicker1.Value, DateTimePicker2.Value, Customer_id)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Load_Sale_View_by_customer_id(DateTimePicker1.Value, DateTimePicker2.Value, ComboBox1.SelectedValue)
        Catch
        End Try

    End Sub
End Class