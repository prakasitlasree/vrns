

Public Class BaseUserControl
    Inherits System.Web.UI.UserControl
    Private _fiCode As String
 
    ReadOnly Property FICode As String
        Get
            Return _fiCode
        End Get
    End Property

    Private _asofYear As String
    ReadOnly Property AsOfYear As String
        Get
            Return _asofYear
        End Get
    End Property


    Private _asofYearThai As String
    ReadOnly Property AsOfYearThai As String
        Get
            If IsNumeric(_asofYear) Then
                Return Val(_asofYear) + 543
            Else
                Return ""
            End If
        End Get
    End Property

    Private _project As String
    ReadOnly Property Project As String

        Get
            Return "FI_PROFILE"
        End Get

    End Property
     
    Protected Sub ShowAlert(ByVal msg As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('" & msg & "');}, 500)", True)
    End Sub

    'use this in page without Upate Panel
    Protected Sub ShowSaveSuccessRedirect()
        'random number to add to url to make change for page (fixing caching old page problem)
        Randomize()
        Dim rndNum As Integer = Math.Ceiling(Rnd() * 10)
        'redirect to avoid user press F5 to resubmit
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('บันทึกข้อมูลเรียบร้อย'); window.location = ((document.URL.indexOf('?') != -1) ? document.URL + '&rndn=" & rndNum & "' : document.URL + '?rndn=" & rndNum & "');}, 500);", True)
    End Sub

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
         
    End Sub
 
 
End Class
