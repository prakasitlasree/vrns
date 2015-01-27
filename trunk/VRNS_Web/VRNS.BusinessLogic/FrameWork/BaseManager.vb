Namespace Framework

    Public Class BaseManager

        Private _connection As SqlClient.SqlConnection
        Private _transaction As SqlClient.SqlTransaction

        Sub New()

        End Sub

        Sub New(ByRef connection As SqlClient.SqlConnection, ByRef transaction As SqlClient.SqlTransaction)
            _connection = connection
            _transaction = transaction
        End Sub

        Protected Function Connection() As SqlClient.SqlConnection
            If _connection IsNot Nothing AndAlso _connection.State <> ConnectionState.Open Then
                Return _connection
            Else
                _connection = New SqlClient.SqlConnection(GetConnectionString)
                _connection.Open()
            End If
            Return _connection
        End Function

        Protected Function Transaction() As SqlClient.SqlTransaction
            Return _transaction
        End Function

        Public Function BeginTransaction() As SqlClient.SqlTransaction
            Return Me.Connection.BeginTransaction
        End Function

        Private Function GetConnectionString() As String
            Dim configKey As String = "EWP.ADO.ConnectionString"
            Dim conString As String = "" 'System.Configuration.ConfigurationManager.AppSettings.Get(configKey)
            Return conString
        End Function

    End Class

End Namespace
