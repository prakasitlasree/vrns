
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

'Imports VRNS.DataModel.EntityModel
Namespace Command

    Public Class UpdateStatusDevRegisCommand
        Inherits FrameworkCommand(Of Boolean)
        Dim _list As New List(Of VRNS_Device_Registered)
        Sub New(ByVal list As List(Of VRNS_Device_Registered))
            _list = list
        End Sub
        Protected Overrides Sub ExecuteCommand()

            Using ctx As New VRNSEntities

                If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
                Dim txn = ctx.Connection.BeginTransaction

                Try
                    For Each o In _list.Where(Function(x) x.Action = ActionEnum.Update).ToList()
                        Dim id = o.ID
                        Dim objupd = ctx.VRNS_Device_Registered.Where(Function(x) x.ID = id).FirstOrDefault()

                        If objupd IsNot Nothing Then
                            objupd.Cur_Status_CODE = o.Cur_Status_CODE
                            objupd.Cur_Status_UPD = o.Cur_Status_UPD
                            objupd.LAST_UPD = Date.Now

                        End If

                    Next
                    ctx.SaveChanges()
                    txn.Commit()

                Catch ex As Exception
                    txn.Rollback()
                    Result = False
                End Try

            End Using

            Result = True
        End Sub

    End Class

End Namespace

