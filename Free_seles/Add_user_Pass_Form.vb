Public Class Add_user_Pass_Form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Add_user_Pass_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Roles()
        ComboBox1.DataSource = dt_Roles
        ComboBox1.DisplayMember = "Roles_Name"
        ComboBox1.ValueMember = "Roles_Id"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.TextLength > 4 Then
            Insert_User_Pass(Label2.Text, TextBox1.Text, TextBox2.Text, ComboBox1.SelectedValue)
            dt_user_pass = Load_dt_user()
            User_Form.DataGridView2.DataSource = dt_user_pass

            Close()
        Else
            MsgBox("en az 4 harf")
        End If


    End Sub
End Class