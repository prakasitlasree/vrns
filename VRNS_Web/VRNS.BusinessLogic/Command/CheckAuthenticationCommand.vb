
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

'Imports VRNS.DataModel.EntityModel
Namespace Command

    Public Class CheckAuthenticationCommand
        Inherits FrameworkCommand(Of VRNS_Member)
        Private _user As String
        Private _pass As String

        Sub New(ByVal user As String, ByVal password As String)
            _user = user
            _pass = password
        End Sub

        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim obj = ctx.VRNS_Member.Where(Function(x) x.USER_LOGIN = _user And x.USER_PASSWORD = _pass).FirstOrDefault()

            Result = obj

        End Sub

    End Class
End Namespace

