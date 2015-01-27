Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic
Imports VRNS.BusinessLogic.Command

Public Class WelcomePage
    Inherits BaseWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Session("login") IsNot Nothing Then
                initialDataLoad()
            Else
                Response.Redirect("AccessDeniedPage.aspx")
            End If

        End If

    End Sub

    Property DataSource As List(Of VRNS_Device_Registered)
        Get

            Dim d As List(Of VRNS_Device_Registered) = ViewState(gridData.ClientID & "_DataSource")
            If d Is Nothing Then
                d = New List(Of VRNS_Device_Registered)
                ViewState(gridData.ClientID & "_DataSource") = d

            End If
            Return d

        End Get
        Set(value As List(Of VRNS_Device_Registered))

            ViewState(gridData.ClientID & "_DataSource") = value

        End Set
    End Property

    Private Sub initialDataLoad()

        Dim cmd As New GetDeviceRegisteredCommand()
        cmd.Initialize()
        cmd.Execute()

        Me.DataSource = cmd.Result

        Dim cmdStatus As New GetStatusCommand()
        cmdStatus.Initialize()
        cmdStatus.Execute()
        Dim list = cmdStatus.Result
        ddlStatus.Items.Clear()

        ddlStatus.Items.Add(New ListItem("All Status", "0"))
        For Each i In list
            ddlStatus.Items.Add(New ListItem(i.DESCRIPTION, i.CODE))
        Next
        refreshGrid()
    End Sub

    Private Sub refreshGrid()
        gridData.DataSource = Me.DataSource
        gridData.DataBind()
    End Sub

    Private Sub getDDLTopic()
        Dim cmd As New GetMATopicCommand()
        cmd.Initialize()
        cmd.Execute()
        ddl_topic_problem.Items.Clear()
        Dim list = cmd.Result

        For Each i In list
            ddl_topic_problem.Items.Add(New ListItem(i.NAME, i.CODE))
        Next
    End Sub

    Private Sub getDDLJobType()
        Dim cmd As New GetJobTypeCommand()
        cmd.Initialize()
        cmd.Execute()
        ddlJobType.Items.Clear()
        Dim list = cmd.Result

        For Each i In list
            ddlJobType.Items.Add(New ListItem(i.CODE, i.ID))
        Next
    End Sub

    Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
        If ddlStatus.SelectedIndex = 0 Then
            Dim ds = Me.DataSource '.Where(Function(x) x.Cur_Status_CODE = ddlStatus.SelectedValue).ToList()
            gridData.DataSource = ds
            gridData.DataBind()
        Else
            Dim ds = Me.DataSource.Where(Function(x) x.Cur_Status_CODE = ddlStatus.SelectedValue).ToList()
            gridData.DataSource = ds
            gridData.DataBind()
        End If

       

    End Sub

    'Protected Sub cmdNew_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdNew.Click
    '    popup.Show()
    'End Sub
  
    Protected Sub gridData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridData.PageIndexChanging
        Dim ds = Me.DataSource.Where(Function(x) x.Cur_Status_CODE = ddlStatus.SelectedValue).ToList()
        If ddlStatus.SelectedIndex = 0 Then
            ds = Me.DataSource
        End If

        gridData.DataSource = ds
        gridData.PageIndex = e.NewPageIndex
        gridData.DataBind()
    End Sub

   
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click

        If txt_search.Text <> String.Empty Then
            Dim list = Me.DataSource.Where(Function(x) x.BRANCH_CODE.Contains(txt_search.Text)).ToList()

            gridData.DataSource = list
            gridData.DataBind()

        End If

    End Sub

    Protected Sub gridData_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridData.RowCommand
        If e.CommandName = "OpenJob" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim lbRowindex As Label = row.FindControl("lblNo")
            hdfID.Value = lbRowindex.Text
            If ddl_topic_problem.Items.Count = 0 Then
                getDDLTopic()
            End If
            If ddlJobType.Items.Count = 0 Then
                getDDLJobType()
            End If


            popup.Show()
        End If
    End Sub

    Protected Sub btnEditConfirm_Click(sender As Object, e As EventArgs) Handles btnEditConfirm.Click

        popup.Hide()

        Dim obj As New VRNS_Maintainance_Record
        If hdfID.Value IsNot Nothing Then
            obj.Dev_Regis_ID = hdfID.Value
            obj.JOB_ID = ddlJobType.SelectedValue
            obj.ROOT_CAUSE = txtRootcuase.Text
            obj.MA_TOPIC_CODE = ddl_topic_problem.SelectedValue
            obj.LAST_UPD = Date.Now
            obj.LAST_UPD_LOGIN = Session("login")
            Dim list As New List(Of VRNS_Maintainance_Record)
            list.Add(obj)
            Dim cmd As New MaintainMaintainance_RecordCommand(list)
            cmd.Initialize()
            cmd.Execute()

        End If
         
        Me.ShowSaveSuccessRedirect()
        
    End Sub


End Class