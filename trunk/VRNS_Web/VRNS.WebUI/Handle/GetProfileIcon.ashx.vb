Imports System.Web
Imports System.Web.Services
Imports VRNS.DataModel.EntityModel
Imports VRNS.BusinessLogic.Command
Public Class GetProfileIcon
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim login_id As String = context.Request.QueryString("id")
        Dim cmd = New GetMemberCommand()
        cmd.Initialize()
        cmd.Execute()
        Dim obj = cmd.Result().Where(Function(x) x.USER_LOGIN = login_id).FirstOrDefault()

        If obj IsNot Nothing AndAlso obj.PHOTO IsNot Nothing Then
            context.Response.ContentType = obj.PHOTO_TYPE
            Dim bytes() As Byte = obj.PHOTO
            context.Response.Buffer = True
            context.Response.Charset = ""
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            context.Response.ContentType = obj.PHOTO_TYPE
            context.Response.AddHeader("content-disposition", _
                "attachment;filename=photo")
            context.Response.BinaryWrite(bytes)

            context.Response.End()
        Else

        End If

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class