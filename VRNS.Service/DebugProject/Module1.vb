
Imports System.IO
Imports System.Configuration
Imports System.Timers
Imports System.Net.NetworkInformation
Imports System.Net
Imports VRNS.DAL
Imports VRNS.DAL.EntityModel
Imports System.Collections.Generic
Imports System.Data

Module Module1

    Sub Main()
        Dim listIPAddress = GetListIPAddress().ToList()
        For Each i In listIPAddress
            UpdateDeviceStatus(i)
        Next
    End Sub

    Public Function GetListIPAddress(categoryID As Integer) As IEnumerable(Of VRNS_Device_Registered)

        Using ctx As New VRNSEntities
            Dim obj = ctx.VRNS_Device_Registered.ToList()
            Return obj
        End Using

    End Function

    Public Function GetListIPAddress() As List(Of VRNS_Device_Registered)

        Using ctx As New VRNSEntities
            If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
            Dim obj = ctx.VRNS_Device_Registered.ToList()
            Return obj
        End Using

    End Function

   Private Sub UpdateDeviceStatus(ByVal item As VRNS_Device_Registered)

        Using ctx As New VRNS.DAL.VRNSEntities

            If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
            Dim txn = ctx.Connection.BeginTransaction

            Try

                Dim device_reg = ctx.VRNS_Device_Registered.Where(Function(x) x.ID = item.ID).FirstOrDefault()

                If device_reg IsNot Nothing Then
                    device_reg.Cur_Status_CODE = getStatusCode("OFFLINE")
                    device_reg.Cur_Status_UPD = Date.Now
                    device_reg.Prev_Status_CODE = device_reg.Cur_Status_CODE
                    device_reg.Prev_Status_UPD = device_reg.Cur_Status_UPD
                End If

                ctx.SaveChanges()
                txn.Commit()

            Catch ex As Exception
                txn.Rollback()

            End Try

        End Using
    End Sub


    Private Sub Open_Maintainance_Record(ByVal item As VRNS_Device_Registered)

        Dim obj As New VRNS_Maintainance_Record
        obj.Dev_Regis_ID = item.ID
        obj.ROOT_CAUSE = "N/A"
        obj.SOLUTION = "N/A"
        obj.ASSIGNEE = getAssigneeByBranchCode(item.BRANCH_CODE)
        obj.JOB_ID = 1

        Using ctx As New VRNSEntities

            If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
            Dim txn = ctx.Connection.BeginTransaction

            Try

                ctx.VRNS_Maintainance_Record.AddObject(obj)
                ctx.SaveChanges()
                txn.Commit()

            Catch ex As Exception
                txn.Rollback()

            End Try

        End Using

    End Sub

    Private Function getAssigneeByBranchCode(ByVal branch_code As String)

        Dim result As String = String.Empty
        Using ctx As New VRNSEntities

            Dim brancObj = ctx.VRNS_Employee.Where(Function(x) x.BRANCH_CODE = branch_code).FirstOrDefault()
            If brancObj IsNot Nothing Then
                result = brancObj.FNAME_TH & " " & brancObj.LNAME_TH
            End If

        End Using
        Return result

    End Function

    Private Function getStatusCode(ByVal status As String) As Integer

        Using ctx As New VRNSEntities

            Dim obj = ctx.VRNS_Status.Where(Function(x) x.DESCRIPTION = status).FirstOrDefault()

            If obj IsNot Nothing Then
                Return obj.CODE
            Else
                Return 0
            End If

        End Using

    End Function

End Module
