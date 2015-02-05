<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="Admin.aspx.vb" Inherits="VRNS.WebUI.Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="UserControl/LeftMenu.ascx" TagName="LeftMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content">
                <div id="info-accordion">
                    <span><span>Administrator </span></span>
                    <div>
                        <table width="100%">
                            <tr>
                                <td width="20%" align="left" style="background-color: #eee;">
                                    <div style="padding-top: 5px; margin-left: -40px;">
                                        <uc1:LeftMenu ID="LeftMenu1" runat="server" />
                                    </div>
                                </td>
                                <td width="80%">
                                    <div style="padding-top: 5px;" align="center">
                                        <div style="padding-left: 10px;" align="left">
                                            <div style="padding-top: 5px; color: #0000FF; font-weight: bold; font-size: large;"
                                                align="left">
                                                Member Management System</div>
                                            <br />
                                            <div align="left">
                                                Add new Member
                                                <asp:ImageButton ID="cmdNew" runat="server" ImageUrl="~/Images/tools/new.png" />
                                            </div>
                                            <div align="left">
                                                Add from Employee
                                                <asp:TextBox ID="txt_Employee_id" runat="server"></asp:TextBox>
                                                &nbsp;<asp:ImageButton ID="cmdseach" runat="server" ImageUrl="~/Images/etc/audit.png" />
                                            </div>
                                            <br />
                                            <br />
                                            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="gridtable" EmptyDataText="ไม่มีข้อมูล" ForeColor="#333333" GridLines="None"
                                                ShowHeaderWhenEmpty="True" Width="100%">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-Width="150" HeaderText="User Login">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="Login" runat="server" Text='<%# Eval("USER_LOGIN") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="250" HeaderText="Role">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="role" runat="server" Text='<%# Eval("VRNS_ROLE.DESCRIPTION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                       <asp:TemplateField HeaderStyle-Width="60" HeaderText="Edit">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                             <a ></a>
                                                             <asp:ImageButton ID="ImageButton1" ImageUrl="~/Images/tools/edit.png" 
                                                                 runat="server" CommandArgument='<%# Eval("USER_LOGIN") %>' CommandName="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#c3d2e0" BorderColor="#ffffff" BorderStyle="Solid" BorderWidth="1"
                                                    ForeColor="Black" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="#c3d2e0" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                            </asp:GridView>
                                            <br />
                                        </div>
                                        <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
                                        <br />
                                        <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
                                        <br />
                                    </div>
                                </td>
                                <td width="">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                <asp:Panel ID="pnlEdit" runat="server" CssClass="modalPopup" Style="display: none;" Width="850px"
                    BackColor="White">
                    <div class="section-title">
                        <asp:Label ID="lblPopupTitle" runat="server" Text="Add New Member"></asp:Label>
                    </div>
                    <br />
                    <table style="width: 100%;">
                        <tr>
                         <td align="right" style="width: 200px;">
                        </td>
                         <td width="600">
                         <asp:Label ID="displayname" runat="server"  Text=""></asp:Label>
                         </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 200px;">
                                User Login
                            </td>
                            <td width="600">
                                <asp:TextBox ID="txtUserLogin" runat="server" Width="300px" ValidationGroup="val"></asp:TextBox>
                                <span class="requiredField"></span>
                                <asp:RequiredFieldValidator ID="rf1" runat="server" ControlToValidate="txtUserLogin"
                                    ErrorMessage="กรุณากรอก UserLogin" SetFocusOnError="True" ValidationGroup="val"
                                    Display="None"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                            </td>
                            <td style="width: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Password
                            </td>
                            <td>
                                <asp:TextBox ID="txt_password" runat="server" Width="300px" ValidationGroup="val"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rf3" runat="server" ControlToValidate="txt_password"
                                    ErrorMessage="กรุณากรอก password" SetFocusOnError="True" ValidationGroup="val"
                                    Display="None"></asp:RequiredFieldValidator>
                                <span class="requiredField">
                                    <br />
                                    <br />
                                </span>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Role
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_role" runat="server" Width="300px">
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="valSum" runat="server" ValidationGroup="val" ShowMessageBox="true"
                        ShowSummary="false" />
                    <div class="metro" style="display: table; width: 100%; text-align: center; margin-top: 20px;
                        padding-bottom: 20px;">
                        <asp:Button ID="btnEditConfirm" runat="server" CssClass="button primary" Text="ตกลง"
                            Width="100" ValidationGroup="val" />
                        <asp:Button ID="btnEditCancel" runat="server" CssClass="button" Text="ปิด" Width="100" />
                    </div>
                    <br />
                    <br />
                </asp:Panel>
                <ajax:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlEdit"
                    TargetControlID="lnkFake" BackgroundCssClass="modalBackground" CancelControlID="btnEditCancel">
                </ajax:ModalPopupExtender>
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
