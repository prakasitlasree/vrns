 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel
 
Namespace Command

    Public Class GetEmployeeCommand
        Inherits FrameworkCommand(Of List(Of VRNS_Employee))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_Employee.ToList()
             

            Result = list.ToList()
        End Sub

    End Class

End Namespace

