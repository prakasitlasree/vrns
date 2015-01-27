<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="VRNS.WebUI._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div >
<br /><br /><br />
    <table style="width:100%;">
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="13%">
                &nbsp;</td>
            <td width="30%">
                &nbsp;</td>
            <td width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                UserName :
            </td>
            <td>
&nbsp;
                <asp:TextBox ID="txt_user" runat="server" Width="200px">admin</asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                PassWord :</td>
            <td>
&nbsp;
                <asp:TextBox ID="txt_password" TextMode="Password"  runat="server" Width="200px">1234</asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right" colspan="2">
               <div class="metro" style="display: table; width: 100%; text-align: center; margin-top: 20px;
                        padding-bottom: 20px;">
                        <asp:Button ID="Btn_Save" runat="server" CssClass="button primary" 
                            Text="Login" ValidationGroup="profile"
                            Width="100" />&nbsp;
                        <asp:Button ID="Btn_Back" runat="server" Text="ย้อนกลับ" Width="100" 
                            Visible="False" />
                    </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
              
              
              
              </td>
        </tr>
    </table>

</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
