Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

Namespace Command

    Public Class GetMaintainanceRecordCommand
        Inherits FrameworkCommand(Of List(Of VRNS_Maintainance_Record))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_Maintainance_Record.ToList()

            For Each i In list

            Next

            Result = list.ToList()
        End Sub

    End Class

End Namespace

