Imports System.Globalization

Public Class ServerTime
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lb_Time.Text = Date.Now.ToString("HH:mm")
    End Sub

End Class