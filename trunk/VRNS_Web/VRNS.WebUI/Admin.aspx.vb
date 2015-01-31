Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic
Imports VRNS.BusinessLogic.Command

Public Class Admin
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

    Private Sub bindRole()
        ddl_role.Items.Clear()
        Dim cmd = New GetROLECommand()
        cmd.Initialize()
        cmd.Execute()
        Dim list = cmd.Result
        For Each i In list
            ddl_role.Items.Add(New ListItem(i.DESCRIPTION, i.ID))
        Next

    End Sub

    Property DataSource As List(Of VRNS_Member)
        Get

            Dim d As List(Of VRNS_Member) = ViewState(gridData.ClientID & "_DataSource")
            If d Is Nothing Then
                d = New List(Of VRNS_Member)
                ViewState(gridData.ClientID & "_DataSource") = d

            End If
            Return d

        End Get
        Set(value As List(Of VRNS_Member))

            ViewState(gridData.ClientID & "_DataSource") = value

        End Set
    End Property

    Private Sub initialDataLoad()

        Dim cmd As New GetMemberCommand()
        cmd.Initialize()
        cmd.Execute()

        Me.DataSource = cmd.Result
         
        refreshGrid()
    End Sub

    Private Sub refreshGrid()
        gridData.DataSource = Me.DataSource
        gridData.DataBind()
    End Sub

    Protected Sub cmdNew_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdNew.Click
        txt_password.Text = ""
        txtUserLogin.Text = ""
        displayname.Text = ""
        bindRole()
        popup.Show()
    End Sub

    Protected Sub btnEditConfirm_Click(sender As Object, e As EventArgs) Handles btnEditConfirm.Click

        Dim obj As New VRNS_Member
        obj.USER_LOGIN = txtUserLogin.Text

        obj.USER_PASSWORD = txt_password.Text
        obj.ROLE_ID = CInt(ddl_role.SelectedValue)
        obj.LAST_UPD = Date.Now
        obj.Action = ActionEnum.Create

        Dim cmd As New MaintainMemberCommand(obj)
        cmd.Initialize()
        cmd.Execute()

        If cmd.Result Then
            Me.ShowSaveSuccessRedirect()
        Else
            Me.ShowAlert("Error Save not success!!!")
        End If

    End Sub

    Protected Sub cmdseach_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdseach.Click
        Dim cmd As New GetEmployeeCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim emplist = cmd.Result()

        Dim empobj = emplist.Where(Function(x) x.ID = txt_Employee_id.Text).FirstOrDefault()
        If empobj IsNot Nothing Then
            txtUserLogin.Text = empobj.ID
            If empobj.FNAME_TH IsNot Nothing Then
                displayname.Text = "Name TH : " & empobj.FNAME_TH & " " & empobj.LNAME_TH & " Name EN : " & empobj.FNAME_EN & " " & empobj.LNAME_EN
            Else
                displayname.Text = ""
            End If
             
            txt_password.Text = ""
            bindRole()
            popup.Show()
        Else
            Me.ShowAlert("ไม่พบรหัสพนักงาน")
        End If

    End Sub

    Protected Sub gridData_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridData.RowCommand
        If e.CommandName = "Edit" Then
            Dim action = e.CommandArgument.ToString()
            Response.Redirect("Profiles.aspx?action=" & action)
        End If

    End Sub
End Class