<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="Profiles.aspx.vb" Inherits="VRNS.WebUI.Profiles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content">
                <div id="info-accordion">
                    <span><span>My Profiles </span></span>
                    <div>
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td width="30%" align="right">
                                &nbsp; PHOTO :
                            </td>
                            <td width="70%">
                            <div style="border:1px solid #ccc; width:100px; float:left;">
                                <asp:Image ID="Image2" runat="server" 
                                    ImageUrl="~/Images/common/defaultperson.png" Width="100px" />
                                    </div>
                                &nbsp;
                                <div style=" padding-left: 10px; width:100px; float:left;"><asp:ImageButton ID="cmdNew" runat="server" ImageUrl="../images/tools/new.png" AlternateText="Upload"
                                    ToolTip="Upload" />
                                    &nbsp;Upload
                                    </div>
                                <br /> <br />
                                <br />
                                <br /><br /> <br />
                                <br />
                                 
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                USER_LOGIN : 
                            </td>
                            <td align="left">
                                
                                <asp:TextBox ID="txtUSER_LOGIN" runat="server" Width="300px"></asp:TextBox>
                                <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                PASSWORD :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUSER_PASSWORD" runat="server" TextMode="Password" 
                                    Width="300px"></asp:TextBox>
                                <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                DISPLAY_NAME :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDISPLAY_NAME" runat="server" Width="300px"></asp:TextBox>
                                <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                ROLE : </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlROLE" runat="server" Width="300px">
                                </asp:DropDownList>
                                <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                EMAIL :</td>
                            <td align="left">
                                <asp:TextBox ID="txtEMAIL" runat="server" Width="300px"></asp:TextBox>
                               <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                MOBILE :</td>
                            <td align="left">
                                <asp:TextBox ID="txtMOBILE_TEL" runat="server" Width="300px"></asp:TextBox>
                               <br />
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                HOME :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtHOME_TEL" runat="server" Width="300px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                      <div class="metro" style="display: table; width: 100%; text-align: center; margin-top: 20px;
                    padding-bottom: 20px;">
                    <asp:Button ID="Save" runat="server" CssClass="button primary" Text="Save"
                        Width="100" ValidationGroup="val" />
                    <asp:Button ID="Cancle" runat="server" CssClass="button" Text="Back" Width="100" />
                    <br /><br />
                </div>
                     <ajax:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlEdit"
                TargetControlID="lnkFake" BackgroundCssClass="modalBackground">
            </ajax:ModalPopupExtender>
                    <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                    <asp:Panel ID="pnlEdit" runat="server" CssClass="modalPopup" Style="display: ;">
                        <div id="popupcontent" runat="server">
                            <asp:HiddenField ID="hdfRowIndex" runat="server" />
                            <div style="width: 480px; height: 180px; background-color: #fff; border: 3px solid #ccc;">
                                <div class="section-title">
                                    <asp:Label ID="lblPopupTitle" runat="server" Text="Upload Picture Profile"></asp:Label>
                                </div>
                                <table width="100%" class="popupform">
                                    <tr>
                                        <td align="right" style="width: 70px;">
                                        </td>
                                        <td>
                                            <tr>
                                                <td align="right">
                                                    ไฟล์:
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="FileUploadDoc" runat="server" /><span class="requiredField"></span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FileUploadDoc"
                                                        runat="server" ErrorMessage="กรุณาระบุชื่อไฟล์" ValidationGroup="DocInfo" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="valFileUpload" ControlToValidate="FileUploadDoc"
                                                        ValidationGroup="DocInfo" ErrorMessage="ต้องเป็นภาพประเภท  ไฟล์รูปภาพ เท่านั้น"
                                                        Display="None" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.GIF|.gif|.zip|.rar|.JPG|.jpg|.PNG|.png)$" />
                                                </td>
                                            </tr>
                                </table>
                                <div class="metro" style="display: table; width: 100%; text-align: center; margin-top: 20px;
                                    padding-bottom: 20px;">
                                    <asp:Button ID="btnEditConfirm" runat="server" CssClass="button primary" Text="ตกลง"
                                        ValidationGroup="DocInfo" Width="100" />
                                    <asp:Button ID="btnEditCancel" runat="server" CssClass="button" Text="ปิด" Width="100" />
                                    <asp:ValidationSummary ID="vldsDocInfo" runat="server" ValidationGroup="DocInfo"
                                        ShowMessageBox="true" ShowSummary="false" />
                                </div>
                                <br /> <br />
                            </div>
                        </div>
                    </asp:Panel>
                
           </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnEditConfirm" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script type="text/javascript">
        function BindJQuery() {

            $("#info-accordion").accordion({
                collapsible: false,
                heightStyle: "content",
                icons: null
            });
        }

        $(document).ready(function () {

            BindJQuery();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            BindJQuery();
        });
     
    </script>
</asp:Content>
