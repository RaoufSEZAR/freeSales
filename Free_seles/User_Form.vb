Public Class User_Form
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub User_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Employees()
        DataGridView1.DataSource = dt_Employees
        dt_user_pass = Load_dt_user()
        DataGridView2.DataSource = dt_user_pass
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Add_user_Pass_Form.Show()
        Add_user_Pass_Form.Label2.Text = DataGridView1.CurrentRow.Cells(0).Value
        Add_user_Pass_Form.Label4.Text = DataGridView1.CurrentRow.Cells(1).Value
    End Sub
End Class