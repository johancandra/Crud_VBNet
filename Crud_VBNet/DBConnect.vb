Imports MySql.Data.MySqlClient

Public Class DBConnect
    Protected Conn As New MySqlConnection
    Protected Cmd As New MySqlCommand
    Protected Da As New MySqlDataAdapter
    Protected Ds As New DataSet
    Protected Dt As New DataTable

    Public Function OpenConn() As Boolean
        Conn = New MySqlConnection("server=localhost;user=root;password=;port=3306;database=dbcrudvbnet")
        Try
            Conn.Open()
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try

        If Conn.State <> ConnectionState.Open Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub CloseConn()
        If Not IsNothing(Conn) Then
            Conn.Close()
            Conn = Nothing
        End If
    End Sub

    Public Function ExecuteQuery(ByVal Query As String) As DataTable
        If Not OpenConn() Then
            MsgBox("Koneksi Gagal....!", MsgBoxStyle.Critical, " Access Failed")
            Return Nothing
            Exit Function
        End If

        Cmd = New MySqlCommand(Query, Conn)
        Da = New MySqlDataAdapter
        Da.SelectCommand = Cmd
        Ds = New Data.DataSet
        Da.Fill(Ds)
        Dt = Ds.Tables(0)
        Return Dt
        Dt = Nothing
        Ds = Nothing
        Da = Nothing
        Cmd = Nothing
        CloseConn()
    End Function

    Public Sub ExecuteNonQuery(ByVal Query As String)
        If Not OpenConn() Then
            MsgBox("Koneksi Gagal...!", MsgBoxStyle.Critical, "Access Failed")
            Exit Sub
        End If

        Cmd = New MySqlCommand

        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Query
        Cmd.ExecuteNonQuery()
        Cmd = Nothing
        CloseConn()
    End Sub
End Class