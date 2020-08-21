Public Class Sale_Form


    Private Sub Sale_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Items()
        DataGridView1.DataSource = dt_Items

        DataGridView1.Columns(0).HeaderText = "Ürünün Numarası"
        DataGridView1.Columns(1).HeaderText = "Ürünün ADINI"
        DataGridView1.Columns(2).HeaderText = "Ürünün FIYATI"
        DataGridView1.Columns(3).HeaderText = "BARCODE"


        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 60
        DataGridView1.Columns(3).Width = 85


        Label9.Text = Max_sale_Bill_No_Sales(DateTimePicker3.Value) + 1
        Load_Sales_by_date_bill(DateTimePicker3.Value, Label9.Text)
        With DataGridView2
            .DataSource = dt_Sales_by_date_bill
            .Columns("sale_No").HeaderText = "Satis NO"
            .Columns("sale_No").Width = 50
            .Columns("sale_date").HeaderText = "Satis Tarihi"
            .Columns("sale_date").Width = 70
            .Columns("sale_Bill_No").HeaderText = "Fatura NO"
            .Columns("sale_Bill_No").Width = 80
            .Columns("item_name").HeaderText = "Urun Ismi"
            .Columns("item_name").Width = 80
            .Columns("item_Qunitity").HeaderText = "Miktar"
            .Columns("item_Qunitity").Width = 80
            .Columns("item_Price").HeaderText = "Fiyat"
            .Columns("item_Price").Width = 80
            .Columns("total").HeaderText = "Total"
            .Columns("total").Width = 80
            .Columns("customer_id").HeaderText = "Musteri No"
            .Columns("customer_id").Width = 60

        End With



    End Sub
    Public Sub Load_Sale2()
        Load_Sales_by_date_bill(DateTimePicker3.Value, Label9.Text)
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Load_Items()
        Else


            Load_Items(TextBox1.Text)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Customer_Form.MdiParent = Main_Form1
        Customer_Form.Show()
        Customer_Form.Button1.Show()

    End Sub


    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        ' Insert_Sales(ByVal sale_date As Date, ByVal sale_Bill_No As Integer,
        '              ByVal item_id As Integer, ByVal item_Qunitity As Decimal,
        '              ByVal item_Price As Decimal, ByVal total As Decimal,
        'ByVal customer_id As Integer)
        Insert_Sales(DateTimePicker3.Value, Label9.Text, DataGridView1.CurrentRow.Cells(0).Value, 1, DataGridView1.CurrentRow.Cells(2).Value, 1 * DataGridView1.CurrentRow.Cells(2).Value, Label2.Text)
        Load_Sales_by_date_bill(DateTimePicker3.Value, Label9.Text)
        Count_All()

    End Sub

    Private Sub Sale_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.A Then
            TextBox1.Focus()
        End If
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Focused = True Then
                Load_Items_byId(TextBox1.Text)
                If dt_items_id.Rows.Count > 0 Then
                    Insert_Sales(DateTimePicker3.Value, Label9.Text, dt_items_id.Rows(0).Item(0), 1, dt_items_id.Rows(0).Item(1), 1 * dt_items_id.Rows(0).Item(1), Label2.Text)
                    Load_Sales_by_date_bill(DateTimePicker3.Value, Label9.Text)
                    TextBox1.Text = ""
                    TextBox1.Focus()
                Else
                End If
            Else
                ' MsgBox("istedigin urun yoktur")
                MsgBox(DataGridView2.CurrentRow.Cells(0).Value)
            End If
        End If
        If e.KeyCode = Keys.Q Then
            item_Qunitity_Form.Show()




            ' DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("item_Qunitity").Selected = True
            If DataGridView2.RowCount > 0 Then

                sale_no = DataGridView2.CurrentRow.Cells(0).Value

            End If

        End If


        If e.KeyCode = Keys.R Then
            DataGridView2.Focus()
            DataGridView2.CurrentCell = DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("item_Qunitity")
        End If


    End Sub


    '(Q)انا وقفتا لان كمان بتعمل تعديل على المقدار بس من الشاشة مباشرة فمافي داعي مزال عم استخدم حرف
    Public Sub DataGridView2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellEndEdit
        DataGridView2.CurrentRow.Cells("total").Value = DataGridView2.CurrentRow.Cells("item_Qunitity").Value * DataGridView2.CurrentRow.Cells("item_Price").Value
        Update_Sales_by_saleno(DataGridView2.CurrentRow.Cells("item_Qunitity").Value, DataGridView2.CurrentRow.Cells("total").Value, DataGridView2.CurrentRow.Cells("sale_No").Value)
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Delete_Sales(DataGridView2.CurrentRow.Cells(0).Value)
        Load_Sales_by_date_bill(DateTimePicker3.Value, Label9.Text)
        Count_All()
    End Sub

    Private Sub Count_All()

        Label7.Text = DataGridView2.RowCount
        'DataGridView2.CurrentRow.Cells("total").Value = DataGridView2.CurrentRow.Cells("item_Qunitity").Value * DataGridView2.CurrentRow.Cells("item_Price").Value

        Dim sum As Double
        For s As Integer = 0 To DataGridView2.RowCount - 1
            '   DataGridView2.CurrentRow.Cells("total").Value = DataGridView2.CurrentRow.Cells("item_Qunitity").Value * DataGridView2.CurrentRow.Cells("item_Price").Value


            sum = sum + DataGridView2.Rows(s).Cells("total").Value
        Next
        Label5.Text = sum

        '  DataGridView2.CurrentRow.Cells("total").Value = DataGridView2.CurrentRow.Cells("item_Qunitity").Value * DataGridView2.CurrentRow.Cells("item_Price").Value

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Load_Sale_View(DateTimePicker3.Value, Label9.Text)
        Dim report As New CrystalReport1
        report.SetDataSource(dt_Sale_View)
        Report_View.CrystalReportViewer1.ReportSource = report
        Report_View.CrystalReportViewer1.Zoom(100%)
        Report_View.Show()



        'Report_View.CrystalReportViewer1.PrintReport()    حتى يطبع على المكنة


        '        report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "E:\Report.PDF")
        'كل شي بينطبع من فواتير بتنعمل ماف ب د ف دون ماينتبه العامل 




        Label9.Text = Label9.Text + 1
        Load_Sales_by_date_bill(DateTimePicker3.Value, Label9.Text)

    End Sub

End Class