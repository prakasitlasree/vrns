Imports System.ServiceProcess
Imports System.IO
Imports System.Configuration
Imports System.Timers
Imports System.Net.NetworkInformation
Imports System.Net
Imports VRNS.DAL
Imports VRNS.DAL.EntityModel
Imports System.Collections.Generic
Imports System.Data

Namespace VRNS_Service
    Public Class VRNS_Service
        Inherits ServiceBase

        Dim timer As New Timer()
        Dim DT_Jobtodo As New DataTable()
        Dim Logpath As String = ""
        Dim ServiceRunFrequency As Double = 0

        Protected Overrides Sub OnStart(ByVal args() As String)

            Logpath = ConfigurationSettings.AppSettings("LogMonitor").ToString()
            ServiceRunFrequency = Convert.ToDouble(ConfigurationSettings.AppSettings("ServiceRunFrequency").ToString())

            timer = New Timer(ServiceRunFrequency)
            AddHandler timer.Elapsed, AddressOf OnElapsedTime
            timer.Enabled = True

            WritLogFile("Starting Service : " & DateTime.Now.ToString())

        End Sub


        Private Sub OnElapsedTime(source As Object, e As ElapsedEventArgs)

            timer.Stop()
            Try

                Dim listIPAddress = GetListIPAddress().ToList()

                WritLogFile("Start Checking Device IP Address Count -> : " & listIPAddress.Count.ToString() & " Branch " & DateTime.Now.ToString())
                Dim loopcount As Integer = 0
                For Each o In listIPAddress
                    loopcount = loopcount + 1
                    Dim p As New Ping()
                    Dim reply As PingReply
                    Dim ip As String = o.LAN_IP

                    Dim pingResult As Boolean = False

                    For i As Integer = 0 To 3

                        reply = p.Send(ip)
                        If reply.Status = IPStatus.Success Then
                            pingResult = True
                        Else
                            pingResult = False
                        End If

                        System.Threading.Thread.Sleep(1000)

                    Next

                    Dim result_msg As String
                    If pingResult Then
                        result_msg = "ONLINE"
                    Else
                        result_msg = "OFFINE"
                    End If

                    WritLogFile("Send Ping to IP Adress --> : " & ip & " Status --> : " & result_msg)

                    If Not pingResult Then

                        UpdateDeviceStatus(o)
                        Open_Maintainance_Record(o)

                    End If
                    If loopcount = 10 Then
                        Exit For
                    End If

                Next

                WritLogFile("End Checking Device IP Address Count -> : " & listIPAddress.Count.ToString() & " " & DateTime.Now.ToString())

            Catch ex As Exception

                WritLogFile((("Error : ==> " + ex.Message & vbLf) + ex.StackTrace & vbLf))

            Finally

                timer.Start()
                WritLogFile("Timer Start : Service Stand by to Next Round! : " & DateTime.Now.ToString() & vbCr & vbLf)

            End Try

        End Sub

        Protected Overrides Sub OnStop()

            timer.Enabled = False
            WritLogFile("Stopping Service : " & DateTime.Now.ToString())

        End Sub

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
                        device_reg.Cur_Status_CODE = 99001
                        device_reg.Cur_Status_UPD = Date.Now
                        device_reg.Prev_Status_CODE = device_reg.Cur_Status_CODE
                        device_reg.Prev_Status_UPD = device_reg.Cur_Status_UPD
                    End If

                    ctx.SaveChanges()
                    txn.Commit()

                Catch ex As Exception
                    txn.Rollback()
                    WritLogFile(ex.Message)
                End Try

            End Using

        End Sub

        Private Sub Open_Maintainance_Record(ByVal item As VRNS_Device_Registered)

            Dim obj As New VRNS_Maintainance_Record
            obj.Dev_Regis_ID = item.ID
            obj.MA_TOPIC_CODE = "0001"
            obj.ROOT_CAUSE = "Ping not reply from VRNS.Service Please Contact Branch"
            obj.SOLUTION = "N/A"
            'obj.ASSIGNEE = getAssigneeByBranchCode(item.BRANCH_CODE)
            obj.JOB_ID = 1
            obj.LAST_UPD = Date.Now
            obj.LAST_UPD_LOGIN = "VRNS.Service"

            Using ctx As New VRNSEntities

                If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
                Dim txn = ctx.Connection.BeginTransaction

                Try

                    ctx.VRNS_Maintainance_Record.AddObject(obj)
                    ctx.SaveChanges()
                    txn.Commit()

                Catch ex As Exception
                    txn.Rollback()
                    WritLogFile(ex.Message)
                End Try

            End Using

        End Sub

        Private Function getAssigneeByBranchCode(ByVal branch_code As String)

            Dim result As String = String.Empty
            Using ctx As New VRNSEntities
                If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
                Dim brancObj = ctx.VRNS_Employee.Where(Function(x) x.BRANCH_CODE = branch_code).FirstOrDefault()
                If brancObj IsNot Nothing Then
                    result = brancObj.FNAME_TH & " " & brancObj.LNAME_TH
                End If

            End Using
            Return result

        End Function

        Private Function getStatusCode(ByVal des As String) As Integer

            Using ctx As New VRNSEntities
                If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
                Dim obj = ctx.VRNS_Status.Where(Function(x) x.DESCRIPTION = des).FirstOrDefault()

                If obj IsNot Nothing Then
                    Return obj.CODE
                Else
                    Return 99002
                End If

            End Using

        End Function

        Public Sub WritLogFile(contents As String)

            Dim fName As String = Logpath & "\LogWindowService_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            Dim logDir As New DirectoryInfo(Logpath)
            If Not logDir.Exists Then
                logDir.Create()
            End If
            Dim fs As New FileStream(fName, FileMode.OpenOrCreate, FileAccess.Write)
            Dim sw As New StreamWriter(fs)
            sw.BaseStream.Seek(0, SeekOrigin.[End])
            sw.WriteLine(contents)
            sw.Flush()
            sw.Close()

        End Sub

    End Class

End Namespace
