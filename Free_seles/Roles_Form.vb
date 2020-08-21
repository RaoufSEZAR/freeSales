Public Class Roles_Form
    Dim Roles_id As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" Then
            Insert_Roles(TextBox1.Text, CheckBox1.Checked, CheckBox2.Checked, CheckBox3.Checked)
            TextBox1.Text = ""
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        Else
            MsgBox("Yanlis Bilgiller Girdininz")

        End If
        Load_Roles()

    End Sub

    Private Sub Roles_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Roles()

        DataGridView1.DataSource = dt_Roles
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text <> "" Then
            Update_Roles(TextBox1.Text, CheckBox1.Checked, CheckBox2.Checked, CheckBox3.Checked, Roles_id)
            TextBox1.Text = ""
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        Else
            MsgBox("Yanlis Bilgiller Girdininz")

        End If
        Load_Roles()


    End Sub

    Private Sub Button1_DoubleClick(sender As Object, e As EventArgs) Handles Button1.DoubleClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        CheckBox1.Checked = DataGridView1.CurrentRow.Cells(2).Value
        CheckBox2.Checked = DataGridView1.CurrentRow.Cells(3).Value
        CheckBox3.Checked = DataGridView1.CurrentRow.Cells(4).Value
        Roles_id = DataGridView1.CurrentRow.Cells(0).Value
    End Sub
End Class