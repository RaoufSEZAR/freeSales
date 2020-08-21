Imports System.Data.SqlClient


Module Items_Module
    Public dt_Items As New DataTable

    Public Sub Load_Items()
        dt_Items.Clear()
        Dim cmd As New SqlCommand("select * from Items", connSQLServer)
        connSQLServer.Open()
        dt_Items.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub


    'البحث عن منتج بدلالة ال id
    Public Sub Load_Items(ByVal item_id As String)
        Try
            dt_Items.Clear()
            Dim cmd As New SqlCommand("select * from Items where item_id=@item_id", connSQLServer)
            cmd.Parameters.Add("item_id", SqlDbType.NVarChar).Value = item_id
            connSQLServer.Open()
            dt_Items.Load(cmd.ExecuteReader)
            connSQLServer.Close()
            cmd = Nothing
        Catch
            connSQLServer.Close()
        End Try


    End Sub




    Public Function Max_item_id_Form_Items()
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(item_id)from Items", connSQLServer)
            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()
        End Try
        Return Number

    End Function


    Public Sub Insert_Items(ByVal item_name As String, ByVal item_price As Decimal, ByVal item_barcode As String)
        Dim cmd As New SqlCommand("Insert into Items(item_id,item_name,item_price,item_barcode)values(@item_id,@item_name,@item_price,@item_barcode)", connSQLServer)
        cmd.Parameters.Add("item_id", SqlDbType.Int).Value = Max_item_id_Form_Items() + 1
        cmd.Parameters.Add("item_name", SqlDbType.NVarChar).Value = item_name
        cmd.Parameters.Add("item_price", SqlDbType.Decimal).Value = item_price
        cmd.Parameters.Add("item_barcode", SqlDbType.NVarChar).Value = item_barcode
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public Sub Update_Items(ByVal item_name As String, ByVal item_price As Decimal, ByVal item_barcode As String, ByVal item_id2 As Integer)
        Dim cmd As New SqlCommand("Update Items set item_name=@item_name,item_price=@item_price,item_barcode=@item_barcode Where item_id=@item_id2", connSQLServer)

        cmd.Parameters.Add("item_name", SqlDbType.NVarChar).Value = item_name
        cmd.Parameters.Add("item_price", SqlDbType.Decimal).Value = item_price
        cmd.Parameters.Add("item_barcode", SqlDbType.NVarChar).Value = item_barcode
        cmd.Parameters.Add("item_id2", SqlDbType.Int).Value = item_id2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public Sub Delete_Items(ByVal item_id As Integer)
        Dim cmd As New SqlCommand("Delete from Items where item_id=@item_id", connSQLServer)
        cmd.Parameters.Add("item_id", SqlDbType.Int).Value = item_id
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing
    End Sub

    Public dt_items_id As New DataTable

    Public Sub Load_Items_byId(ByVal item_id As Integer)
        dt_items_id.Clear()
        Dim cmd As New SqlCommand("select item_price,item_barcode from Items where item_id=@item_id", connSQLServer)
        cmd.Parameters.Add("item_id", SqlDbType.Int).Value = item_id
        connSQLServer.Open()
        dt_items_id.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub








End Module
