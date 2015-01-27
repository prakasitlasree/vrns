Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic
Imports VRNS.BusinessLogic.Command
Public Class DownTimeStatistics
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

    Property DataSource As List(Of GET_TOP10_DOWN_Result)
        Get

            Dim d As List(Of GET_TOP10_DOWN_Result) = ViewState(gridData.ClientID & "_DataSource")
            If d Is Nothing Then
                d = New List(Of GET_TOP10_DOWN_Result)
                ViewState(gridData.ClientID & "_DataSource") = d

            End If
            Return d

        End Get
        Set(ByVal value As List(Of GET_TOP10_DOWN_Result))

            ViewState(gridData.ClientID & "_DataSource") = value

        End Set
    End Property

    Private Sub initialDataLoad()

        Dim cmd As New GETTOP10Command()
        cmd.Initialize()
        cmd.Execute()
        Dim list = cmd.Result.ToList()

        Me.DataSource = list

        refreshGrid()

    End Sub

    Private Sub refreshGrid()
        gridData.DataSource = Me.DataSource
        gridData.DataBind()
    End Sub

End Class