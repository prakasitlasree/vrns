 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

'Imports VRNS.DataModel.EntityModel
Namespace Command

    Public Class GetMATeamCommand
        Inherits FrameworkCommand(Of List(Of VRNS_MA_Team))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_MA_Team.ToList()

            

            Result = list.ToList()
        End Sub

    End Class

End Namespace

