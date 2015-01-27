 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

'Imports VRNS.DataModel.EntityModel
Namespace Command

    Public Class GetMATopicCommand
        Inherits FrameworkCommand(Of List(Of VRNS_MA_Topic))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_MA_Topic.ToList()

            For Each i In list
                 
            Next

            Result = list.ToList()
        End Sub

    End Class

End Namespace

