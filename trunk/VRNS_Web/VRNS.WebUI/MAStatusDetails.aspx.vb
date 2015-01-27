Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic
Imports VRNS.BusinessLogic.Command

Public Class MAStatusDetails
    Inherits BaseWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("login") IsNot Nothing Then
                Dim id = Request.QueryString("id").ToString()
                initialDataLoad(id)
            Else
                Response.Redirect("AccessDeniedPage.aspx")

            End If

        End If
    End Sub

    Property DataSource As List(Of VRNS_Maintainance_Detail)
        Get

            Dim d As List(Of VRNS_Maintainance_Detail) = ViewState(gridData.ClientID & "_DataSource")
            If d Is Nothing Then
                d = New List(Of VRNS_Maintainance_Detail)
                ViewState(gridData.ClientID & "_DataSource") = d

            End If
            Return d

        End Get
        Set(ByVal value As List(Of VRNS_Maintainance_Detail))

            ViewState(gridData.ClientID & "_DataSource") = value

        End Set
    End Property

    Private Sub initialDataLoad(ByVal id As Integer)

        Dim cmd As New GetMaintainanceRecordDetailsCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim list = cmd.Result.Where(Function(x) x.Maintainance_Record_ID = id).OrderByDescending(Function(o) o.ID).ToList()

        Dim int As Integer = 0
        For Each i In list
            int = int + 1
            i.No = int
        Next

        Me.DataSource = list

        refreshGrid()


        Dim cmdRecord As New GetMaintainanceRecordCommand()
        cmdRecord.Initialize()
        cmdRecord.Execute()

        Dim result = cmdRecord.Result.ToList().Where(Function(x) x.ID = id).FirstOrDefault()

        If result IsNot Nothing AndAlso result.SOLUTION IsNot Nothing AndAlso result.Status IsNot Nothing Then
            txt_solution.Text = result.SOLUTION
            chkStatus.Checked = result.Status
        End If
        
    End Sub
     
    Private Sub refreshGrid()
        gridData.DataSource = Me.DataSource
        gridData.DataBind()
    End Sub

    Protected Sub btnEditCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditCancel.Click
        Response.Redirect("ListOfflineBranch.aspx")
    End Sub

    Protected Sub btnEditConfirm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditConfirm.Click

        If txt_solution.Text <> Nothing Then
            UpdateMARecord()
            UpdateStatusToDevRegis()
            Me.ShowSaveSuccess()
        Else
            Me.ShowAlert("กรุณากรอกวิธีการแก้ปัญหา")
        End If

      
    End Sub

    Private Sub UpdateMARecord()
        Dim cmd As New GetMaintainanceRecordCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim id = Request.QueryString("id").ToString()
        Dim result = cmd.Result.ToList().Where(Function(x) x.ID = id).ToList()
        For Each i In result
            i.Action = ActionEnum.Update
            i.SOLUTION = txt_solution.Text
            i.Status = chkStatus.Checked
        Next
        Dim cmdUpd As New UpdateMA_RecordCommand(result)
        cmdUpd.Initialize()
        cmdUpd.Execute()


    End Sub
    Private Sub UpdateStatusToDevRegis()

        Dim DevRegisID = GetDevRegisByMARecord()
        Dim cmdget As New GetDeviceRegisteredCommand()
        cmdget.Initialize()
        cmdget.Execute()
        Dim objList = cmdget.Result.Where(Function(x) x.ID = DevRegisID).ToList()

        For Each i In objList
            i.Action = ActionEnum.Update
            i.Cur_Status_CODE = "99000"
            i.Cur_Status_UPD = Date.Now

        Next
        Dim cmd As New UpdateStatusDevRegisCommand(objList)
        cmd.Initialize()
        cmd.Execute()

    End Sub

    Private Function GetDevRegisByMARecord() As Integer
        Dim cmd As New GetMaintainanceRecordCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim id = Request.QueryString("id").ToString()
        Dim result = cmd.Result.ToList().Where(Function(x) x.ID = id).FirstOrDefault()

        If result IsNot Nothing Then
            Return result.Dev_Regis_ID
        End If
        Return ""
    End Function

End Class