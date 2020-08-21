Imports System.Data.SqlClient

Module Roles_Module
    Public dt_Roles As New DataTable

    Public Sub Load_Roles()

        dt_Roles.Clear()
        Dim cmd As New SqlCommand("select Roles_Id,Roles_Name,Roles_Main,Roles_Reports,Roles_Controls from Roles", connSQLServer)
        connSQLServer.Open()
        dt_Roles.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub


    Public Function Max_Roles_id_From_Roles()
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("select Max(Roles_Id) from Roles", connSQLServer)
            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()

        End Try
        Return Number
    End Function


    Public Sub Insert_Roles(ByVal Roles_Name As String, ByVal Roles_Main As Boolean, ByVal Roles_Reports As Boolean, ByVal Roles_Controls As Boolean)
        Dim cmd As New SqlCommand("Insert into Roles(Roles_Id,Roles_Name,Roles_Main,Roles_Reports,Roles_Controls)values(@Roles_Id,@Roles_Name,@Roles_Main,@Roles_Reports,@Roles_Controls)", connSQLServer)
        cmd.Parameters.Add("Roles_Id", SqlDbType.Int).Value = Max_Roles_id_From_Roles() + 1
        cmd.Parameters.Add("Roles_Name", SqlDbType.NVarChar).Value = Roles_Name
        cmd.Parameters.Add("Roles_Main", SqlDbType.Bit).Value = Roles_Main
        cmd.Parameters.Add("Roles_Reports", SqlDbType.Bit).Value = Roles_Reports
        cmd.Parameters.Add("Roles_Controls", SqlDbType.Bit).Value = Roles_Controls

        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing
    End Sub

    Public Sub Update_Roles(ByVal Roles_Name As String, ByVal Roles_Main As Boolean, ByVal Roles_Reports As Boolean, ByVal Roles_Controls As Boolean, ByVal Roles_Id2 As Integer)
        Dim cmd As New SqlCommand("Update Roles set Roles_Name=@Roles_Name,Roles_Main=@Roles_Main,Roles_Reports=@Roles_Reports,Roles_Controls=@Roles_Controls Where Roles_Id=@Roles_Id2", connSQLServer)

        cmd.Parameters.Add("Roles_Name", SqlDbType.NVarChar).Value = Roles_Name
        cmd.Parameters.Add("Roles_Main", SqlDbType.Bit).Value = Roles_Main
        cmd.Parameters.Add("Roles_Reports", SqlDbType.Bit).Value = Roles_Reports
        cmd.Parameters.Add("Roles_Controls", SqlDbType.Bit).Value = Roles_Controls
        cmd.Parameters.Add("Roles_Id2", SqlDbType.Int).Value = Roles_Id2
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub










End Module
