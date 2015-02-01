Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic.Command

Public Class Profiles
    Inherits BaseWebPage
     
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Session("login") IsNot Nothing Then
                InitialLoad()
            Else
                Response.Redirect("AccessDeniedPage.aspx")
            End If

        End If
    End Sub

    Private Sub InitialLoad()
        bindRole()
        Dim action As String = Request.QueryString("action")
        If action = "self" Then

            Dim user As VRNS_Member = Session("login")
            Image2.ImageUrl = "~/Handle/GetProfileIcon.ashx?id=" & user.USER_LOGIN
            txtUSER_LOGIN.Text = user.USER_LOGIN
            txtUSER_LOGIN.Enabled = False
            txtDISPLAY_NAME.Text = user.DISPLAY_NAME
            txtUSER_PASSWORD.Text = user.USER_PASSWORD
            txtEMAIL.Text = user.EMAIL
            txtHOME_TEL.Text = user.HOME_TEL
            txtMOBILE_TEL.Text = user.MOBILE_TEL
            ddlROLE.SelectedValue = user.VRNS_ROLE.DESCRIPTION
        Else

            Dim cmd = New GetMemberCommand()
            cmd.Initialize()
            cmd.Execute()
            Dim User = cmd.Result().Where(Function(x) x.USER_LOGIN = action).FirstOrDefault()
            Image2.ImageUrl = "~/Handle/GetProfileIcon.ashx?id=" & User.USER_LOGIN
            txtUSER_LOGIN.Text = User.USER_LOGIN
            txtUSER_LOGIN.Enabled = False
            txtDISPLAY_NAME.Text = User.DISPLAY_NAME
            txtUSER_PASSWORD.Text = User.USER_PASSWORD
            txtEMAIL.Text = User.EMAIL
            txtHOME_TEL.Text = User.HOME_TEL
            txtMOBILE_TEL.Text = User.MOBILE_TEL
            ddlROLE.SelectedValue = User.VRNS_ROLE.DESCRIPTION
        End If



    End Sub

    Private Sub bindRole()
        Dim cmd = New GetROLECommand()
        cmd.Initialize()
        cmd.Execute()
        Dim list = cmd.Result
        For Each i In list
            ddlROLE.Items.Add(New ListItem(i.DESCRIPTION, i.ID))
        Next

    End Sub

    Private _phototype As String
    Public Property Phototype() As String
        Get
            Dim d As String = ViewState("phototype")
            Return d
        End Get
        Set(ByVal value As String)
            _phototype = value
            ViewState("phototype") = _phototype
        End Set
    End Property

    Private _photo As Byte()
    Public Property Photo() As Byte()
        Get
            Dim d As Byte() = ViewState("photo")
            Return d
        End Get
        Set(ByVal value As Byte())
            _photo = value
            ViewState("photo") = _photo
        End Set
    End Property


    Protected Sub btnEditConfirm_Click(sender As Object, e As EventArgs) Handles btnEditConfirm.Click
      
        If FileUploadDoc.HasFile Then
            Me.photo = FileUploadDoc.FileBytes
            Me.Phototype = FileUploadDoc.PostedFile.ContentType
        End If
    End Sub

    Protected Sub cmdNew_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles cmdNew.Click

        popup.Show()
    End Sub

    Protected Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim file As New VRNS_Member()
         
        Dim action As String = Request.QueryString("action")
         
            Dim cmd = New GetMemberCommand()
            cmd.Initialize()
            cmd.Execute()
            Dim obj = cmd.Result().Where(Function(x) x.USER_LOGIN = action).FirstOrDefault()
            If obj IsNot Nothing Then
                file.Action = ActionEnum.Update
                file = obj
                file.PHOTO = Me.Photo
                file.PHOTO_TYPE = Me.Phototype
                file.DISPLAY_NAME = txtDISPLAY_NAME.Text
                file.USER_PASSWORD = txtUSER_PASSWORD.Text
                file.EMAIL = txtEMAIL.Text
                file.HOME_TEL = txtHOME_TEL.Text
                file.MOBILE_TEL = txtMOBILE_TEL.Text
                file.ROLE_ID = ddlROLE.SelectedValue
                file.Action = ActionEnum.Update
            End If

            Dim cmdUpload As New MaintainMemberCommand(file)
            cmdUpload.Initialize()
            cmdUpload.Execute()
        
        Me.ShowSaveSuccessRedirect()


    End Sub

    Protected Sub Cancle_Click(sender As Object, e As EventArgs) Handles Cancle.Click
        Response.Redirect("WelcomePage.aspx")
    End Sub
End Class