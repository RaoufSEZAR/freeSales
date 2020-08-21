Imports System.Data.SqlClient
Module Sale_Module

    Public Customer_id As Integer
    Public customer_name As String
    Public sale_no As Integer
    Public sale_total As Decimal
    Public sale_noo As Integer



    'Public sale_total As Decimal

    Public dt_Sales As New DataTable

    Public Sub Load_Sales()
        dt_Sales.Clear()

        Dim cmd As New SqlCommand("select * from Sales", connSQLServer)
        connSQLServer.Open()
        dt_Sales.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public dt_Sales_by_date_bill As New DataTable

    Public Sub Load_Sales_by_date_bill(ByVal sale_date As Date, ByVal sale_Bill_No As Integer)
        Try
            dt_Sales_by_date_bill.Clear()
            Dim cmd As New SqlCommand("select sale_No,sale_date,sale_Bill_No,item_name,item_Qunitity,Sales.item_Price,total,customer_id from Sales,Items where sale_date=@sale_date and sale_Bill_No=@sale_Bill_No and Sales.item_id=Items.item_id", connSQLServer)
            cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
            cmd.Parameters.Add("sale_Bill_No", SqlDbType.Int).Value = sale_Bill_No

            connSQLServer.Open()

            dt_Sales_by_date_bill.Load(cmd.ExecuteReader)
            connSQLServer.Close()
            cmd = Nothing
        Catch
            connSQLServer.Close()
        End Try



    End Sub






    Public Function Max_sale_Bill_No_Sales(ByVal sale_date As Date)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("select Max(sale_Bill_No)from Sales where sale_date=@sale_date", connSQLServer)
            cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()

        End Try
        Return Number
    End Function


    Public Function Max_sale_No_Sales()
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("select Max(sale_No)from Sales", connSQLServer)

            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()

        End Try
        Return Number
    End Function


    Public Sub Insert_Sales(ByVal sale_date As Date, ByVal sale_Bill_No As Integer, ByVal item_id As Integer, ByVal item_Qunitity As Decimal, ByVal item_Price As Decimal, ByVal total As Decimal, ByVal customer_id As Integer)
        Dim cmd As New SqlCommand("Insert into Sales(sale_No,sale_date,sale_Bill_No,item_id,item_Qunitity,item_Price,total,customer_id)values(@sale_No,@sale_date,@sale_Bill_No,@item_id,@item_Qunitity,@item_Price,@total,@customer_id)", connSQLServer)
        cmd.Parameters.Add("sale_No", SqlDbType.Int).Value = Max_sale_No_Sales() + 1
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
        cmd.Parameters.Add("sale_Bill_No", SqlDbType.Int).Value = sale_Bill_No
        cmd.Parameters.Add("item_id", SqlDbType.Int).Value = item_id
        cmd.Parameters.Add("item_Qunitity", SqlDbType.Decimal).Value = item_Qunitity
        cmd.Parameters.Add("item_Price", SqlDbType.Decimal).Value = item_Price
        cmd.Parameters.Add("total", SqlDbType.Decimal).Value = total
        cmd.Parameters.Add("customer_id", SqlDbType.Int).Value = customer_id

        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public Sub Update_Salesbysaleno(ByVal item_Qunitity As Decimal, ByVal sale_No2 As Integer)
        Dim cmd As New SqlCommand("Update Sales set item_Qunitity=@item_Qunitity Where sale_No=@sale_No2", connSQLServer)

        cmd.Parameters.Add("item_Qunitity", SqlDbType.Decimal).Value = item_Qunitity

        cmd.Parameters.Add("sale_No2", SqlDbType.Int).Value = sale_No2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub


    Public Sub Update_Sales_by_saleno(ByVal item_Qunitity As Decimal, ByVal total As Decimal, ByVal sale_No2 As Integer)
        Dim cmd As New SqlCommand("Update Sales set item_Qunitity=@item_Qunitity,total=@total Where sale_No=@sale_No2", connSQLServer)

        cmd.Parameters.Add("item_Qunitity", SqlDbType.Decimal).Value = item_Qunitity
        cmd.Parameters.Add("total", SqlDbType.Decimal).Value = total
        cmd.Parameters.Add("sale_No2", SqlDbType.Int).Value = sale_No2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public Sub Delete_Sales(ByVal sale_No As Integer)

        Dim cmd As New SqlCommand("Delete From Sales where sale_No=@sale_No", connSQLServer)

        cmd.Parameters.Add("sale_No", SqlDbType.Int).Value = sale_No
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing
    End Sub


    Public dt_Sale_View As New DataTable

    Public Sub Load_Sale_View(ByVal sale_date As Date, ByVal sale_Bill_No As Integer)
        dt_Sale_View.Clear()
        Dim cmd As New SqlCommand("SELECT sale_date,sale_Bill_No,item_name,item_Qunitity,item_Price,total,Customer_Name,Customer_Mob,Customer_Adress from Sale_View where sale_date=@sale_date and sale_Bill_No=@sale_Bill_No", connSQLServer)
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
        cmd.Parameters.Add("sale_Bill_No", SqlDbType.Int).Value = sale_Bill_No
        connSQLServer.Open()
        dt_Sale_View.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    '    للبحث بتاريخ محدد
    Public dt_Sale_View2 As New DataTable

    Public Sub Load_Sale_View2(ByVal sale_date As Date)
        dt_Sale_View2.Clear()
        Dim cmd As New SqlCommand("select * from Sale_View2 where sale_date=@sale_date", connSQLServer)
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date

        connSQLServer.Open()
        dt_Sale_View2.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    'لبحث بين تاريخين
    Public dt_Sale_View3 As New DataTable

    Public Sub Load_Sale_View3(ByVal sale_date As Date, ByVal sale_date2 As Date)
        dt_Sale_View3.Clear()
        Dim cmd As New SqlCommand("select * from Sale_View2 where sale_date>=@sale_date and sale_date<=@sale_date2", connSQLServer)
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
        cmd.Parameters.Add("sale_date2", SqlDbType.Date).Value = sale_date2

        connSQLServer.Open()
        dt_Sale_View3.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    '   Public dt_Sale_View4 As New DataTable        للبحث بواسطة اسم منتج محدد      

    Public Sub Load_Sale_View_by_item_name(ByVal sale_date As Date, ByVal sale_date2 As Date, ByVal item_name As String)
        dt_Sale_View3.Clear()
        Dim cmd As New SqlCommand("select * from Sale_View2 where sale_date>=@sale_date and sale_date<=@sale_date2 and item_name like @item_name", connSQLServer)
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
        cmd.Parameters.Add("sale_date2", SqlDbType.Date).Value = sale_date2
        cmd.Parameters.Add("item_name", SqlDbType.NVarChar).Value = "%" & item_name & "%"

        connSQLServer.Open()
        dt_Sale_View3.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    'لعمل تقرير اجمالي من كل منتج دون ان يتكرر المنتج في الصف الواحد فقط يضع مقداره

    Public dt_allSales As New DataTable

    Public Sub Load_allSale(ByVal sale_date As Date, ByVal sale_date2 As Date)
        dt_allSales.Clear()
        Dim cmd As New SqlCommand("select sales.item_id,item_name,sum(item_Qunitity) as Qunitity_All,sum(total)as total_All from sales,Items where (sales.item_id=Items.item_id ) and sale_date>=@sale_date and sale_date<=@sale_date2 group by sales.item_id,item_name", connSQLServer)
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
        cmd.Parameters.Add("sale_date2", SqlDbType.Date).Value = sale_date2
        ' cmd.Parameters.Add("item_name", SqlDbType.NVarChar).Value = "%" & item_name & "%"

        connSQLServer.Open()
        dt_allSales.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public Sub Load_Sale_View_by_customer_id(ByVal sale_date As Date, ByVal sale_date2 As Date, ByVal customer_id As Integer)
        dt_Sale_View3.Clear()
        Dim cmd As New SqlCommand("select * from Sale_View2 where sale_date>=@sale_date and sale_date<=@sale_date2 and customer_id=@customer_id", connSQLServer)
        cmd.Parameters.Add("sale_date", SqlDbType.Date).Value = sale_date
        cmd.Parameters.Add("sale_date2", SqlDbType.Date).Value = sale_date2
        cmd.Parameters.Add("customer_id", SqlDbType.Int).Value = customer_id

        connSQLServer.Open()
        dt_Sale_View3.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub


End Module
