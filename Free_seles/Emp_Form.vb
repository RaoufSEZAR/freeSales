Public Class Emp_Form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Add_emp.Show()
        Add_Edit = "Add"
    End Sub

    Private Sub Emp_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Employees()
        DataGridView1.DataSource = dt_Employees

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Add_emp.Show()
        Add_Edit = "Edit"
        emp_id = DataGridView1.CurrentRow.Cells(0).Value
        Add_emp.TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        Add_emp.TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value
        Add_emp.CheckBox1.Text = DataGridView1.CurrentRow.Cells(3).Value













    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        emp_id = DataGridView1.CurrentRow.Cells(0).Value
        Update_Employees_del(emp_id)
        Load_Employees()



    End Sub
End Class