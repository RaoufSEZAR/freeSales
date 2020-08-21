Public Class Add_emp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Add_Edit = "Add" Then
            Insert_Employees(TextBox1.Text, TextBox2.Text, CheckBox1.Checked)
        Else

            Update_Employees(TextBox1.Text, TextBox2.Text, CheckBox1.Checked, emp_id)

        End If

        Load_Employees()
        Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class