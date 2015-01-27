
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

Namespace Command

    Public Class GETTOP10Command
        Inherits FrameworkCommand(Of List(Of GET_TOP10_DOWN_Result))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.GETTOP10_DOWNTIME().ToList()
            Dim int As Integer = 0

            For Each i In list

                Dim bname = ctx.VRNS_Branch.Where(Function(x) x.CODE = i.BRANCH_CODE).FirstOrDefault()
                int = int + 1
                i.No = int

                If bname IsNot Nothing Then
                    i.BranchName = bname.NAME

                    If bname.TELEPHONE IsNot Nothing Then
                        i.BranchTel = bname.TELEPHONE
                    Else

                        If bname.MOBILE IsNot Nothing Then
                            i.BranchTel = bname.MOBILE
                        Else
                            i.BranchTel = "N/A"
                        End If

                    End If

                Else
                    i.BranchName = "N/A"
                    i.BranchTel = "N/A"
                End If

            Next

            Result = list

        End Sub

    End Class

End Namespace

