Imports System.Data.SqlClient

Module Emp_Module
    Public Add_Edit As String
    Public emp_id As Integer

    Public dt_Employees As New DataTable
    Public Sub Load_Employees()
        dt_Employees.Clear()
        Dim cmd As New SqlCommand("select emp_id,emp_name,emp_phone,emp_state from Employees where emp_state=1", connSQLServer)
        connSQLServer.Open()
        dt_Employees.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub




    Public Function Max_emp_id_From_Employees()
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("select Max(emp_id) from Employees", connSQLServer)
            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()

        End Try
        Return Number
    End Function


    Public Sub Insert_Employees(ByVal emp_name As String, ByVal emp_phone As String, ByVal emp_state As Boolean)
        Dim cmd As New SqlCommand("Insert into Employees(emp_id,emp_name,emp_phone,emp_state)values(@emp_id,@emp_name,@emp_phone,@emp_state)", connSQLServer)
        cmd.Parameters.Add("emp_id", SqlDbType.Int).Value = Max_emp_id_From_Employees() + 1
        cmd.Parameters.Add("emp_name", SqlDbType.NVarChar).Value = emp_name
        cmd.Parameters.Add("emp_phone", SqlDbType.NVarChar).Value = emp_phone
        cmd.Parameters.Add("emp_state", SqlDbType.Bit).Value = emp_state
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing
    End Sub


    Public Sub Update_Employees(ByVal emp_name As String, ByVal emp_phone As String, ByVal emp_state As Boolean, ByVal emp_id2 As Integer)
        Dim cmd As New SqlCommand("Update Employees set emp_name=@emp_name,emp_phone=@emp_phone,emp_state=@emp_state Where emp_id=@emp_id2", connSQLServer)

        cmd.Parameters.Add("emp_name", SqlDbType.NVarChar).Value = emp_name
        cmd.Parameters.Add("emp_phone", SqlDbType.NVarChar).Value = emp_phone
        cmd.Parameters.Add("emp_state", SqlDbType.Bit).Value = emp_state
        cmd.Parameters.Add("emp_id2", SqlDbType.Int).Value = emp_id2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub


    Public Sub Update_Employees_del(ByVal emp_id2 As Integer)
        Dim cmd As New SqlCommand("Update Employees set emp_state=@emp_state Where emp_id=@emp_id2", connSQLServer)
        cmd.Parameters.Add("emp_state", SqlDbType.Bit).Value = False
        cmd.Parameters.Add("emp_id2", SqlDbType.Int).Value = emp_id2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub


End Module
