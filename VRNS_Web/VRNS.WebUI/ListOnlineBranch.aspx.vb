Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic
Imports VRNS.BusinessLogic.Command

Public Class OnlineBranch
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
        Dim list = cmd.Result.Where(Function(x) x.Online = True).ToList()

        Me.DataSource = list

        refreshGrid()

    End Sub

    Private Sub refreshGrid()
        gridData.DataSource = Me.DataSource
        gridData.DataBind()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click

        If txt_branchCode.Text <> String.Empty Then

            Dim list = Me.DataSource.Where(Function(x) x.BRANCH_CODE.Contains(txt_branchCode.Text.Trim())).ToList()
            gridData.DataSource = list.ToList()
            gridData.DataBind()

        ElseIf txt_branchLAN.Text <> String.Empty Then

            Dim list = Me.DataSource.Where(Function(x) x.LAN_IP.Contains(txt_branchLAN.Text.Trim())).ToList()
            gridData.DataSource = list.ToList()
            gridData.DataBind()

        ElseIf txt_branchName.Text <> String.Empty Then

            Dim list = Me.DataSource.Where(Function(x) x.BranchName.Contains(txt_branchName.Text.Trim())).ToList()
            gridData.DataSource = list.ToList()
            gridData.DataBind()

        End If

    End Sub
End Class