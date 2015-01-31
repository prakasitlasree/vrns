Imports VRNS.DataModel.EntityModel

Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim projectTitle As String = ConfigurationManager.AppSettings.Get("ProjectTitle")
            Dim projectEnv As String = ConfigurationManager.AppSettings.Get("ProjectEnvironment")
            lblProjectTitle.Text = projectTitle
            If projectEnv <> "" Then
                lblProjectTitle.Text &= " " & projectEnv
            End If

            If Session("login") IsNot Nothing Then

                Dim user As VRNS_Member = Session("login")
                lblUserDisplay.Text = user.DISPLAY_NAME

            End If


        End If
    End Sub

End Class