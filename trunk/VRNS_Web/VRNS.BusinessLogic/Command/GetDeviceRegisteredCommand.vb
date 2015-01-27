Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel
Imports System.Linq
'Imports VRNS.DataModel.EntityModel
Namespace Command

    Public Class GetDeviceRegisteredCommand
        Inherits FrameworkCommand(Of List(Of VRNS_Device_Registered))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_Device_Registered.Include("VRNS_Status").ToList()

            For Each i In list
                If i.Cur_Status_CODE = "99000" Then
                    i.Online = True
                    i.Offline = False
                Else
                    i.Online = False
                    i.Offline = True
                End If
                Dim Branch = ctx.VRNS_Branch.Where(Function(x) x.CODE = i.BRANCH_CODE).FirstOrDefault()
                If Branch IsNot Nothing Then

                    i.BranchName = Branch.NAME

                    If Branch.TELEPHONE IsNot Nothing Then
                        i.BranchTel = Branch.TELEPHONE
                    Else

                        If Branch.MOBILE IsNot Nothing Then
                            i.BranchTel = Branch.MOBILE
                        Else
                            i.BranchTel = "N/A"
                        End If


                    End If

                Else
                    i.BranchTel = "N/A"
                    i.BranchName = "N/A"
                End If

            Next

            Result = list.OrderBy(Function(x) x.Online).ToList()
        End Sub

    End Class

End Namespace

