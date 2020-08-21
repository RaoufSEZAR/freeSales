Public Class Customer_Form
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click



        For s As Integer = 0 To DataGridView1.RowCount - 2
            With DataGridView1.Rows(s)


                If count_customer_id_From_Customers(.Cells(0).Value) = 1 Then
                    Update_Customers(.Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(0).Value)
                Else
                    Insert_Customers(.cells(0).value, .cells(1).value, .cells(2).value, .cells(3).value)


                End If
            End With

        Next

        Load_Customers()



    End Sub





    Private Sub Customer_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Customers()
        DataGridView1.DataSource = dt_Customer
        DataGridView1.Columns(0).HeaderText = "MUSTERI NUMARASI"
        DataGridView1.Columns(1).HeaderText = "MUSTERI ISMI"
        DataGridView1.Columns(2).HeaderText = "MUSTERI TELEFONU"
        DataGridView1.Columns(3).HeaderText = "MUSTERI ADRESI"

        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 150
        DataGridView1.Columns(3).Width = 250

    End Sub


    Public Function GetMax()
        Dim MaxNumber As Integer = 0
        For s As Integer = 0 To DataGridView1.RowCount - 2
            If MaxNumber < DataGridView1.Rows(s).Cells(0).Value Then
                MaxNumber = DataGridView1.Rows(s).Cells(0).Value
            End If


        Next


        Return MaxNumber

    End Function


    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter

        If IsDBNull(DataGridView1.CurrentRow.Cells(0).Value) Then

            DataGridView1.CurrentRow.Cells(0).Value = GetMax() + 1

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Customer_id = DataGridView1.CurrentRow.Cells(0).Value
        customer_name = DataGridView1.CurrentRow.Cells(1).Value

        Sale_Form.Label2.Text = Customer_id
        Sale_Form.Label4.Text = customer_name


        Close()

        Sales.get_customer_name()

    End Sub
End Class