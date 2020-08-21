Imports System.Data.SqlClient

Module Customer_Module

    Public dt_Customer As New DataTable
    Public Sub Load_Customers()
        dt_Customer.Clear()
        Dim cmd As New SqlCommand("select * from Customers", connSQLServer)
        connSQLServer.Open()
        dt_Customer.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing
    End Sub


    'لمعرفة الشخص اذا اسمه تكرر بالجدول مرة تانية

    Public Function count_customer_id_From_Customers(ByVal customer_id As Integer)
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select count(customer_id)From Customers Where customer_id=@customer_id", connSQLServer)
            cmd.Parameters.Add("customer_id", SqlDbType.Int).Value = customer_id
            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()
        End Try
        Return Number
    End Function

    Public Sub Insert_Customers(ByVal customer_id As Integer, ByVal customer_Name As String, ByVal customer_Mob As String, ByVal customer_Adress As String)
        Dim cmd As New SqlCommand("Insert into Customers(customer_id,customer_Name,customer_Mob,customer_Adress)values(@customer_id,@customer_Name,@customer_Mob,@customer_Adress)", connSQLServer)
        cmd.Parameters.Add("customer_id", SqlDbType.Int).Value = customer_id
        cmd.Parameters.Add("customer_Name", SqlDbType.NVarChar).Value = customer_Name
        cmd.Parameters.Add("customer_Mob", SqlDbType.NVarChar).Value = customer_Mob
        cmd.Parameters.Add("customer_Adress", SqlDbType.NVarChar).Value = customer_Adress
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing



    End Sub


    Public Sub Update_Customers(ByVal customer_name As String, ByVal customer_Mob As String, ByVal customer_Adress As String, ByVal customer_id2 As Integer)
        Dim cmd As New SqlCommand("Update Customers set customer_name=@customer_name,customer_Mob=@customer_Mob,customer_Adress=@customer_Adress Where customer_id=@customer_id2", connSQLServer)

        cmd.Parameters.Add("customer_name", SqlDbType.NVarChar).Value = customer_name
        cmd.Parameters.Add("customer_Mob", SqlDbType.NVarChar).Value = customer_Mob
        cmd.Parameters.Add("customer_Adress", SqlDbType.NVarChar).Value = customer_Adress
        cmd.Parameters.Add("customer_id2", SqlDbType.Int).Value = customer_id2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub







End Module
