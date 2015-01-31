
Imports VRNS.BusinessLogic.Framework
Imports VRNS.DataAccess
Imports VRNS.DataModel.EntityModel


Namespace Command

    Public Class MaintainMemberCommand
        Inherits FrameworkCommand(Of Boolean)
        Dim _list As New List(Of VRNS_MEMBER)
        Dim _obj As New VRNS_MEMBER
        Sub New(ByVal list As List(Of VRNS_MEMBER))
            _list = list
        End Sub
        Sub New(ByVal obj As VRNS_MEMBER)
            _obj = obj
        End Sub
        Sub New()

        End Sub
        Protected Overrides Sub ExecuteCommand()

            Using ctx As New VRNSEntities

                If ctx.Connection.State <> ConnectionState.Open Then ctx.Connection.Open()
                Dim txn = ctx.Connection.BeginTransaction

                Try
                    If _obj IsNot Nothing Then

                        If _obj.Action = DataModel.EntityModel.ActionEnum.Create Then
                            Dim mem = ctx.VRNS_Member.Where(Function(x) x.USER_LOGIN = _obj.USER_LOGIN).FirstOrDefault()
                            If mem Is Nothing Then
                                ctx.VRNS_Member.AddObject(_obj)
                            End If
                             
                        ElseIf _obj.Action = DataModel.EntityModel.ActionEnum.Update Then
                            Dim mem = ctx.VRNS_Member.Where(Function(x) x.USER_LOGIN = _obj.USER_LOGIN).FirstOrDefault()
                            If mem IsNot Nothing Then
                                mem.DISPLAY_NAME = _obj.DISPLAY_NAME
                                mem.MOBILE_TEL = _obj.MOBILE_TEL
                                mem.ROLE_ID = _obj.ROLE_ID
                                mem.PHOTO = _obj.PHOTO
                                mem.PHOTO_TYPE = _obj.PHOTO_TYPE
                                mem.HOME_TEL = _obj.HOME_TEL
                                mem.LAST_UPD = Date.Now
                            End If

                        End If


                    Else
                        For Each o In _list
                            If o.Action = ActionEnum.Create Then

                                ctx.VRNS_Member.AddObject(o)
                            Else
                                Dim mem = ctx.VRNS_Member.Where(Function(x) x.USER_LOGIN = _obj.USER_LOGIN).FirstOrDefault()
                                If mem IsNot Nothing Then
                                    mem.DISPLAY_NAME = o.DISPLAY_NAME
                                    mem.MOBILE_TEL = o.MOBILE_TEL
                                    mem.ROLE_ID = o.ROLE_ID
                                    mem.PHOTO = o.PHOTO
                                    mem.PHOTO_TYPE = o.PHOTO_TYPE
                                    mem.HOME_TEL = o.HOME_TEL
                                    mem.LAST_UPD = Date.Now
                                End If
                            End If

                        Next
                        
                    End If


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

