Imports VRNS.BusinessLogic.Command
Public Class _Default
    Inherits BaseWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("login") IsNot Nothing Then
                Response.Redirect("WelcomePage.aspx")
            Else
                'Response.Redirect("AccessDeniedPage.aspx")
            End If

        End If
    End Sub

    Protected Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        If txt_user.Text <> String.Empty AndAlso txt_password.Text <> String.Empty Then
            Dim cmd As New CheckAuthenticationCommand(txt_user.Text, txt_password.Text)
            cmd.Initialize()
            cmd.Execute()
            Dim authenobj = cmd.Result
            If authenobj IsNot Nothing Then
                Session("login") = authenobj.USER_NAME
                Response.Redirect("WelcomePage.aspx")
            Else
                Response.Redirect("AccessDeniedPage.aspx")
            End If

        Else

        End If

    End Sub
End Class