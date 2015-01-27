 
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel

'Imports VRNS.DataModel.EntityModel
Namespace Command

    Public Class MaintainMaintainance_RecordCommand
        Inherits FrameworkCommand(Of Boolean)
        Dim _list As New List(Of VRNS_Maintainance_Record)
        Sub New(ByVal list As List(Of VRNS_Maintainance_Record))
            _list = list
        End Sub
        Protected Overrides Sub ExecuteCommand()

            Using ctx As New VRNSEntities

                If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
                Dim txn = ctx.Connection.BeginTransaction

                Try
                    For Each o In _list
                        ctx.VRNS_Maintainance_Record.AddObject(o)
                    Next
                    ctx.SaveChanges()
                    txn.Commit()

                Catch ex As Exception
                    txn.Rollback()

                End Try

            End Using

            Result = True
        End Sub

    End Class

End Namespace

