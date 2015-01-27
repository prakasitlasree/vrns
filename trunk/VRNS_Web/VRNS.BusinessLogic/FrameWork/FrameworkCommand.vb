
Imports System.Threading
Imports VRNS.DataModel.EntityModel

Namespace Framework

    Public MustInherit Class FrameworkCommand(Of TResult)
        Inherits BaseCommand


        Private _result As TResult
        Private _userName As String
        Private _userIPAddress As String
        Private _isIntialized As Boolean = False

        Private _performanceLogMessage As New System.Text.StringBuilder
        Dim _performanceLogLapName As String


        Private _executeSuccess As Boolean = False
        Private _processingTimeInSecond As Decimal

        Private _currentDate As DateTime = Now

        Public Sub New()

        End Sub

#Region "FrameworkInterface"
        Public Property Result() As TResult

            Get
                Return _result
            End Get
            Set(ByVal value As TResult)
                _result = value
            End Set
        End Property


        ''' <summary>
        ''' Command must be intialized before calling execute, add Command.Initialize before Command.Execute.
        ''' Parameter userName come from custom authentication then store username in Session value and pass to command
        ''' or userName come from user indentity in windows authentication application.
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <param name="userIPAddress"></param>
        ''' <remarks></remarks>
        Public Sub Initialize(ByVal userName As String, ByVal userIPAddress As String)

            Dim pos As Integer = userName.IndexOf("\") + 1
            _userName = userName.Substring(pos, userName.Length - pos)

            _userIPAddress = userIPAddress
            _isIntialized = True

        End Sub

        ''' <summary>
        ''' Command must be intialized before calling execute, add Command.Initialize before Command.Execute.
        ''' Caller can call this method for the command without authoriaztion required.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()

            _isIntialized = True

        End Sub

        Public Sub Initialize(ByVal userName As String)
            If InStr(userName, "\") > 0 Then
                Dim pos As Integer = userName.IndexOf("\") + 1
                _userName = userName.Substring(pos, userName.Length - pos)
            Else
                _userName = userName
            End If
          
            _isIntialized = True

        End Sub


        Public Overrides Sub Execute()
            Try
                If _isIntialized = False Then Throw New InvalidOperationException("Command must be intialized before calling execute, add Command.Initialize before Command.Execute.")


                CheckFunctionalAccessControl()

                ExecuteCommand()

                _executeSuccess = True

            Catch ex As Exception

                _executeSuccess = False
                WriteErrorLog(ex.ToString)
                Throw ex

            Finally

                'Call FinishPerformanceLog performance log before log activity because
                'the FinishPerformanceLog function will calculate processing time that use in activity detail
                'and CrateActivityLog function will use thread to log activity so it would not effect processing time

                CrateActivityLog()

            End Try

        End Sub

        Protected ReadOnly Property CurrentDate As Date
            Get
                Return _currentDate
            End Get
        End Property
         
#End Region

#Region "SupportingFunction"

        Protected Sub WriteTraceLog(ByVal message As String)

        End Sub

        Protected Sub WriteErrorLog(ByVal message As String)

        End Sub

        Protected Overridable Sub CrateActivityLog()

        End Sub

        ''' <summary>
        ''' CheckFunctionalAccessControl function will use current user name and child command authorization code in authorization data source.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CheckFunctionalAccessControl()

            'Me.WriteTraceLog("Check Access Control For: " & Me.GetType.ToString & " Code: " & Me.AuthorizationCode)

            If Me.FunctionCode <> "" Then
                'implement here

                'Check authorization from data source by using
                'Me.CurrentUser and Me.AuthorizationCode 
                'function must throw exception in case of user does not have permission to stop command from execute.
            End If


        End Sub
#End Region

#Region "ChildCommandImplementation"
        Protected MustOverride Overrides Sub ExecuteCommand()
 
        Protected Overridable ReadOnly Property FunctionCode() As String
            Get
                Return ""
            End Get
        End Property

#End Region

    End Class

End Namespace


