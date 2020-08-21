Public Class Items_Form
    'Dim Add_Edit As Boolean = True
    Dim item_id As Integer

    Private Sub Items_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Items()
        DataGridView1.DataSource = dt_Items
        DataGridView1.Columns(0).HeaderText = "Ürünün Numarası"
        DataGridView1.Columns(1).HeaderText = "Ürünün ADINI"
        DataGridView1.Columns(2).HeaderText = "Ürünün FIYATI"
        DataGridView1.Columns(3).HeaderText = "BARCODE"

        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 200
        Clear_All_Text()
    End Sub

    Public Sub Clear_All_Text()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        TextBox1.Select()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Clear_All_Text()
        '  Add_Edit = True
        item_id = 0
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If item_id = 0 Then

            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                Insert_Items(TextBox1.Text, TextBox2.Text, TextBox3.Text)
            Else
                MsgBox("BILGILER DOGRU GIRDIR")
            End If
        Else

            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                Update_Items(TextBox1.Text, TextBox2.Text, TextBox3.Text, item_id)


            Else
                MsgBox("BILGILER DOGRU GIRDIR")
            End If

        End If

        Load_Items()
        Clear_All_Text()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Add_Edit = False
        item_id = DataGridView1.CurrentRow.Cells(0).Value
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        item_id = DataGridView1.CurrentRow.Cells(0).Value
        Delete_Items(item_id)
        Load_Items()
    End Sub
End Class