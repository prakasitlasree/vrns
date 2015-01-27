 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

Namespace Command

    Public Class GetMaintainanceRecordDetailsCommand
        Inherits FrameworkCommand(Of List(Of VRNS_Maintainance_Detail))
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Dim ctx As New VRNSEntities

            Dim list = ctx.VRNS_Maintainance_Detail.ToList()
            Dim int As Integer = 0
            For Each i In list
                int = int + 1
                i.No = int
                i.EMP_Contact_Name = getFnamebyEMPID(i.EMP_Contact_ID)
                i.BranchName = getBracnchbyDevID(i.Dev_Regis_ID)
                i.MA_Team_Name = getMATeambyID(i.EMP_MA)
            Next

            Result = list.ToList()
        End Sub

        Private Function getFnamebyEMPID(ByVal emp_id As Integer) As String
            Dim ctx As New VRNSEntities
            Dim List = ctx.VRNS_Employee.Where(Function(x) x.ID = emp_id).FirstOrDefault()

            If List IsNot Nothing Then
                Return List.FNAME_TH & " " & List.LNAME_TH
            Else
                Return ""
            End If

        End Function

        Private Function getBracnchbyDevID(ByVal id As Integer) As String
            Dim ctx As New VRNSEntities
            Dim bid = ctx.VRNS_Device_Registered.Where(Function(x) x.ID = id).FirstOrDefault()

            If bid IsNot Nothing Then
                Dim list = ctx.VRNS_Branch.Where(Function(x) x.CODE = bid.BRANCH_CODE).FirstOrDefault()

                If list IsNot Nothing Then
                    If list IsNot Nothing Then
                        Return list.NAME
                    Else
                        Return "N/A"
                    End If
                End If

            End If
            Return "N/A"
        End Function

        Private Function getMATeambyID(ByVal id As Integer) As String
            Dim ctx As New VRNSEntities
            Dim bid = ctx.VRNS_MA_Team.Where(Function(x) x.ID = id).FirstOrDefault()

            If bid IsNot Nothing Then
                Dim list = ctx.VRNS_Employee.Where(Function(x) x.ID = bid.EMP_ID).FirstOrDefault()

                If list IsNot Nothing Then
                    If list IsNot Nothing Then
                        Return list.FNAME_TH & " " & list.LNAME_TH
                    Else
                        Return "N/A"
                    End If
                End If

            End If
            Return "N/A"
        End Function

    End Class

End Namespace

