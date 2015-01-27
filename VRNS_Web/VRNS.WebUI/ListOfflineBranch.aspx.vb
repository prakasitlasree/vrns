Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic
Imports VRNS.BusinessLogic.Command

Public Class ListOfflineBranch
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
        Dim list = cmd.Result.Where(Function(x) x.Online = False).ToList()

        Me.DataSource = list

        refreshGrid()

    End Sub

    Private Sub refreshGrid()
        gridData.DataSource = Me.DataSource
        gridData.DataBind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If txt_branchCode.Text <> String.Empty Then

            Dim list = Me.DataSource.Where(Function(x) x.BRANCH_CODE.Contains(txt_branchCode.Text)).ToList()
            gridData.DataSource = list.ToList()
            gridData.DataBind()

        ElseIf txt_branchLAN.Text <> String.Empty Then

            Dim list = Me.DataSource.Where(Function(x) x.LAN_IP.Contains(txt_branchLAN.Text)).ToList()
            gridData.DataSource = list.ToList()
            gridData.DataBind()

        ElseIf txt_branchName.Text <> String.Empty Then

            Dim list = Me.DataSource.Where(Function(x) x.BranchName.Contains(txt_branchName.Text)).ToList()
            gridData.DataSource = list.ToList()
            gridData.DataBind()

        End If
    End Sub

    Protected Sub gridData_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridData.RowCommand
        If e.CommandName = "Assign" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim lbno As Label = row.FindControl("lblNo")
            Dim lbbr As Label = row.FindControl("VRNS_BranchNM")
            Dev_Regis_ID.Value = lbno.Text


            If getMaintainance_Record_ID(Dev_Regis_ID.Value) IsNot Nothing Then

                Maintainance_Record_ID.Value = getMaintainance_Record_ID(Dev_Regis_ID.Value).ID
                lbBranch.Text = lbbr.Text

                If ddl_ma_team.Items.Count = 0 Then
                    bindDDLMAteam()
                End If

                If ddl_empcontact.Items.Count = 0 Then
                    bindEMP_Contact()
                End If

                popup.Show()

            Else
                Me.ShowAlert("กรุณาเปิด Maintainance Record ที่หน้า Dashboard ")
            End If

        ElseIf e.CommandName = "Details" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim lbno As Label = row.FindControl("lblNo")

            If getMaintainance_Record_ID(CInt(lbno.Text)) IsNot Nothing And getMaintainance_Detail(lbno.Text) IsNot Nothing Then
                Response.Redirect("MAStatusDetails.aspx?id=" & getMaintainance_Record_ID(CInt(lbno.Text)).ID)
            Else
                Me.ShowAlert("กรุณาเปิด Maintainance Record และ Assign MA Team ")
            End If


        End If
    End Sub

    Private Function getMaintainance_Record_ID(ByVal regis_id As Integer) As VRNS_Maintainance_Record
        Dim cmd As New GetMaintainanceRecordCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim result = cmd.Result.Where(Function(x) x.Dev_Regis_ID = regis_id).FirstOrDefault()
 
        Return result
    End Function

    Private Function getMaintainance_Detail(ByVal regis_id As Integer) As VRNS_Maintainance_Detail
        Dim cmd As New GetMaintainanceRecordDetailsCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim result = cmd.Result.Where(Function(x) x.Dev_Regis_ID = regis_id).FirstOrDefault()

        Return result
    End Function
    Private Sub bindDDLMAteam()
        Dim cmd As New GetMATeamCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim List = cmd.Result
        For Each i In List
            ddl_ma_team.Items.Add(New ListItem("ชื่อ-สกุล : " & getFnamebyEMPID(i.EMP_ID) & " ตำแหน่ง : " & i.SKILL, i.ID))
        Next
    End Sub

    Private Function getFnamebyEMPID(ByVal emp_id As Integer) As String
        Dim cmd As New GetEmployeeCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim List = cmd.Result.Where(Function(x) x.ID = emp_id).FirstOrDefault()

        If List IsNot Nothing Then
            Return List.FNAME_TH & " " & List.LNAME_TH
        Else
            Return ""
        End If

    End Function

    Private Sub bindEMP_Contact()
        Dim cmd As New GetEmployeeCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim List = cmd.Result
        For Each i In List
            ddl_empcontact.Items.Add(New ListItem("ชื่อ-สกุล : " & i.FNAME_TH & " " & i.LNAME_TH & " รหัสสาขา : " & i.BRANCH_CODE, i.ID))
        Next
    End Sub

    Protected Sub btnEditConfirm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditConfirm.Click

        popup.Hide()

        Dim obj As New VRNS_Maintainance_Detail

        obj.Dev_Regis_ID = Dev_Regis_ID.Value
        obj.Maintainance_Record_ID = Maintainance_Record_ID.Value
        obj.EMP_Contact_ID = ddl_empcontact.SelectedValue
        obj.EMP_MA = ddl_ma_team.SelectedValue
        obj.LAST_UPD = Date.Now
        obj.LAST_UPD_LOGIN = Session("login")
        Dim list As New List(Of VRNS_Maintainance_Detail)
        list.Add(obj)
        Dim cmd As New MaintainMADetailCommand(list)
        cmd.Initialize()
        cmd.Execute()

        Me.ShowSaveSuccessRedirect()

    End Sub

End Class