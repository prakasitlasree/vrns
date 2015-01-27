Imports System.Globalization 

Public Class BaseWebPage
    Inherits System.Web.UI.Page
    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        SetCulture()
        
    End Sub

    Private Sub SetCulture()
        Dim culture As New CultureInfo("th-TH")
        System.Threading.Thread.CurrentThread.CurrentCulture = culture
        System.Threading.Thread.CurrentThread.CurrentUICulture = culture
    End Sub
    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If SiteMap.CurrentNode IsNot Nothing Then
            Me.Page.Title = SiteMap.CurrentNode.Title
        End If

    End Sub

       
    Private _fiCode As String
    Protected ReadOnly Property FICode As String
        Get
            Return _fiCode
        End Get
    End Property

    Private _asofYear As String
    Protected ReadOnly Property AsofYear As String
        Get
            Return _asofYear
        End Get
    End Property

    Private _asofYearThai As String
    ReadOnly Property AsOfYearThai As String
        Get
            Return Val(_asofYear) + 543
        End Get
    End Property

     

    Private _customErrorMessage As String
    Property ErrorMessage As String

        Get
            Return _customErrorMessage
        End Get
        Set(ByVal value As String)
            _customErrorMessage = value
        End Set

    End Property
     
    Protected Sub ShowSaveSuccessRedirect()

        Randomize()
        Dim rndNum As Integer = Math.Ceiling(Rnd() * 10)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('บันทึกข้อมูลเรียบร้อย'); window.location = ((document.URL.indexOf('?') != -1) ? document.URL + '&rndn=" & rndNum & "' : document.URL + '?rndn=" & rndNum & "');}, 500);", True)
    End Sub
     
    Protected Sub ShowSaveSuccess()

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('บันทึกข้อมูลเรียบร้อย');}, 500);", True)

    End Sub
   
    Protected Sub ShowSaveSuccess(ByVal redirectURL As String)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('บันทึกข้อมูลเรียบร้อย'); window.location = ('" & redirectURL & "');}, 500);", True)

    End Sub

    Protected Sub ShowSaveNotChange()

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('ไม่มีการเปลี่ยนแปลงข้อมูล');}, 500);", True)
         
    End Sub

    Protected Sub ShowAlert(ByVal msg As String)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {alert('" & msg & "');}, 500);", True)

    End Sub

    Protected Sub EnableRemindSave(ByVal act As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "setTimeout(function () {  $(window)." & act & "('beforeunload', confirmExit);  }, 500);", True)
    End Sub
    

    Protected Sub OpenNewWindow(ByVal querystring As String, ByVal width As Int32, ByVal height As Int32)

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), Guid.NewGuid.ToString(), "window.open('" & querystring & "');", True)

    End Sub

     

End Class

