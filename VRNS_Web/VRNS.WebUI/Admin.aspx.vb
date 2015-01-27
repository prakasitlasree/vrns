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
        txtUserName.Text = ""
        popup.Show()
    End Sub

    Protected Sub btnEditConfirm_Click(sender As Object, e As EventArgs) Handles btnEditConfirm.Click
        Dim list As New List(Of VRNS_Member)
        Dim obj As New VRNS_Member
        obj.USER_LOGIN = txtUserLogin.Text
        obj.USER_NAME = txtUserName.Text
        obj.USER_PASSWORD = txt_password.Text
        obj.ROLE = ddl_role.SelectedValue
        obj.LAST_UPD = Date.Now
        obj.LAST_UPD_LOGIN = Session("login")
        list.Add(obj)
        Dim cmd As New MaintainMemberCommand(list)
        cmd.Initialize()
        cmd.Execute()

        If cmd.Result Then
            Me.ShowSaveSuccessRedirect()
        Else
            Me.ShowAlert("Error Save not success!!!")
        End If

    End Sub

End Class