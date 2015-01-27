 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel
 
Namespace Command

    Public Class GetStatusCommand
        Inherits FrameworkCommand(Of List(Of VRNS_Status))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Result = ctx.VRNS_Status.ToList()

        End Sub

    End Class

End Namespace

