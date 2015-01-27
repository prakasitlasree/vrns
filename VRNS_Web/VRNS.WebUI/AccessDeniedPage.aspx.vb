Public Class AccessDeniedPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Me.ErrorMessage IsNot Nothing Or Me.ErrorMessage <> String.Empty Then
                lbError.Text = Me.ErrorMessage
            End If

        End If

    End Sub

    Public Property ErrorMessage As String
        Get

            Dim d As String = ViewState(lbError.ClientID & "error")
            If d Is Nothing Then

                ViewState(lbError.ClientID & "error") = d

            End If
            Return d

        End Get
        Set(value As String)

            ViewState(lbError.ClientID & "error") = value

        End Set
    End Property
End Class