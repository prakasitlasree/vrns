 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

Namespace Command

    Public Class GetROLECommand
        Inherits FrameworkCommand(Of List(Of VRNS_ROLE))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_ROLE.ToList()

            Result = list.ToList()
        End Sub

    End Class

End Namespace

