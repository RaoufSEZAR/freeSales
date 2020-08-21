Imports System.Data.SqlClient

Module User_Pass_Module1

    Public dt_user_pass As New DataTable
    Public user_id As Integer

    Public Function Load_dt_user()
        Dim dt As New DataTable
        Dim cmd As New SqlCommand("select A.UP_id,A.User_name,A.Pass,B.Roles_Name,c.emp_name from User_Pass as A,Roles as B,Employees as C where A.Roles_Id=B.Roles_Id and A.Emp_id=C.emp_id", connSQLServer)

        connSQLServer.Open()
        dt.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing
        Return dt

    End Function


    Public Function Max_UP_id_Form_User_Pass()
        Dim Number As Integer
        Try
            Dim cmd As New SqlCommand("Select Max(UP_id)from User_Pass", connSQLServer)
            connSQLServer.Open()
            Number = cmd.ExecuteScalar
            connSQLServer.Close()

        Catch
            Number = 0
            connSQLServer.Close()
        End Try
        Return Number

    End Function


    Public Sub Insert_User_Pass(ByVal Emp_id As Integer, ByVal User_Name As String, ByVal Pass As String, ByVal Roles_id As Integer)
        Dim cmd As New SqlCommand("Insert into User_Pass(UP_id,Emp_id,User_Name,Pass,Roles_id)values(@UP_id,@Emp_id,@User_Name,@Pass,@Roles_id)", connSQLServer)

        cmd.Parameters.Add("UP_id", SqlDbType.Int).Value = Max_UP_id_Form_User_Pass() + 1
        cmd.Parameters.Add("Emp_id", SqlDbType.Int).Value = Emp_id
        cmd.Parameters.Add("User_Name", SqlDbType.NVarChar).Value = User_Name
        cmd.Parameters.Add("Pass", SqlDbType.NVarChar).Value = Pass
        cmd.Parameters.Add("Roles_id", SqlDbType.Int).Value = Roles_id
        connSQLServer.Open()
        cmd.ExecuteNonQuery()
        connSQLServer.Close()
        cmd = Nothing

    End Sub

    Public dt_Login As New DataTable

    Public Sub Load_dt_Loginn(ByVal user As String, ByVal pass As String)
        dt_Login.Clear()

        Dim cmd As New SqlCommand("select [Emp_id],[Roles_Main],[Roles_Reports],[Roles_Controls] from [User_Pass],[dbo].[Roles] where User_name=@user and pass=@pass and [User_Pass].[Roles_Id]=[Roles].[Roles_Id]", connSQLServer)

        cmd.Parameters.Add("user", SqlDbType.NVarChar).Value = user
        cmd.Parameters.Add("Pass", SqlDbType.NVarChar).Value = pass

        connSQLServer.Open()
        dt_Login.Load(cmd.ExecuteReader)
        connSQLServer.Close()
        cmd = Nothing

    End Sub

End Module
