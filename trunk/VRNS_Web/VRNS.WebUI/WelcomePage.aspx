<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="WelcomePage.aspx.vb" Inherits="VRNS.WebUI.WelcomePage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="UserControl/LeftMenu.ascx" TagName="LeftMenu" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LeftMenuTechnical.ascx" TagName="LeftMenuTechnical"
    TagPrefix="uc2" %>
<%@ Register Src="UserControl/LeftMenuEngineer.ascx" TagName="LeftMenuEngineer" TagPrefix="uc3" %>
<%@ Register Src="UserControl/LeftMenuDocument.ascx" TagName="LeftMenuDocument" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="main-content">
                <div id="info-accordion">
                    <span><span>System Overviews </span></span>
                    <div>
                        <table width="100%">
                            <tr>
                                <td width="20%" align="left" style="background-color: #eee;">
                                    <div style="padding-top: 5px; margin-left: -40px;">
                                        <div id="dvTech" runat="server">
                                            <uc2:LeftMenuTechnical ID="LeftMenuTechnical1" runat="server" />
                                        </div>
                                        <div id="dvEng" runat="server">
                                            <uc3:LeftMenuEngineer ID="LeftMenuEngineer1" runat="server" />
                                        </div>
                                        <div id="dvDoc" runat="server">
                                            <uc4:LeftMenuDocument ID="LeftMenuDocument1" runat="server" />
                                        </div>
                                    </div>
                                </td>
                                <td width="80%">
                                    <div style="padding-top: 5px;" align="center">
                                        <div style="border: 2px dotted #C0C0C0; padding-left: 10px;  padding-top: 10px;" align="left">
                                            <asp:ImageButton ID="North" runat="server" ImageUrl="~/Images/tools/left-pane-hide.png" />
                                            &nbsp;<asp:LinkButton ID="LinkButtonNorth" runat="server">Group North</asp:LinkButton>
                                            &nbsp; 
                                            <div id="dvNorth" runat="server" style="padding-top: 5px;" align="center">
                                                <div style="padding-left: 10px;" align="left">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="300px" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    &nbsp;ค้นหาจากรหัสสาขา :
                                                    <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                                                    &nbsp;<asp:Button ID="btn_search" runat="server" CssClass="button primary" Text="ค้นหา"
                                                        Width="100px" />
                                                    <br />
                                                    <br />
                                                    <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="gridtable" EmptyDataText="ไม่มีข้อมูล" ForeColor="#333333" GridLines="None"
                                                        ShowHeaderWhenEmpty="True" Width="100%">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="OpenJob" HeaderStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="lnkNew" Visible='<%# Eval("Offline") %>' runat="server" CommandArgument='<%# Eval("ID") %>'
                                                                        CommandName="OpenJob" ImageUrl="~/images/tools/new.png" Text="แก้ไข" />
                                                                    <asp:HiddenField ID="GVhdfID" runat="server" Value='<%#Eval("ID")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="50" HeaderText="Status">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNo" Visible="false" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                                                    <asp:Image ImageUrl="~/Images/device/offine.jpg" ID="Image1" runat="server" Height="49px"
                                                                        Width="84px" Visible='<%# Eval("Offline") %>' />
                                                                    <asp:Image ImageUrl="~/Images/device/online.png" ID="Image2" runat="server" Height="53px"
                                                                        Width="62px" Visible='<%# Eval("Online") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="80" HeaderText="Branch">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="VRNS_Branch" runat="server" Text='<%#Eval("BRANCH_CODE")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="" HeaderText="Branch Name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="VRNS_BranchNM" runat="server" Text='<%#Eval("BranchName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="100" HeaderText="Telephone">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBranchTel" runat="server" Text='<%#Eval("BranchTel")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="150" HeaderText="LAN IPAddress">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLAN_IP" runat="server" Text='<%#Eval("LAN_IP")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="100" HeaderText="Provider">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProvider" runat="server" Text='<%#Eval("ISP")%>'></asp:Label>
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
                                        </div>
                                    </div>
                                    <div style="padding-top: 5px;" align="center">
                                        <div style="border: 2px dotted #C0C0C0; padding-left: 10px;  padding-top: 10px;" align="left">
                                            <asp:ImageButton ID="imgEast" runat="server" ImageUrl="~/Images/tools/left-pane-hide.png" />
                                            &nbsp;<asp:LinkButton ID="LinkButtonEast" runat="server">Group East</asp:LinkButton>
                                            &nbsp; 
                                            <div id="dvEast" runat="server" style="padding-top: 5px;" align="center">
                                                <div style="padding-left: 10px;" align="left">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div style="padding-top: 5px;" align="center">
                                        <div style="border: 2px dotted #C0C0C0; padding-left: 10px;  padding-top: 10px;" align="left">
                                            <asp:ImageButton ID="ImageSouth" runat="server" ImageUrl="~/Images/tools/left-pane-hide.png" />
                                            &nbsp;<asp:LinkButton ID="LinkButtonSouth" runat="server">Group South</asp:LinkButton>
                                            &nbsp; 
                                            <div id="dvSouth" runat="server" style="padding-top: 5px;" align="center">
                                                <div style="padding-left: 10px;" align="left">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-top: 5px;" align="center">
                                        <div style="border: 2px dotted #C0C0C0; padding-left: 10px; padding-top: 10px;" 
                                            align="left">
                                            <asp:ImageButton ID="ImageWest" runat="server" ImageUrl="~/Images/tools/left-pane-hide.png" />
                                            &nbsp;<asp:LinkButton ID="LinkButtonWest" runat="server">Group West</asp:LinkButton>
                                            &nbsp; 
                                            <div id="dvWest" runat="server" style="padding-top: 5px;" align="center">
                                                <div style="padding-left: 10px;" align="left">
                                                </div>
                                            </div>
                                        </div>
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
                <asp:Panel ID="pnlEdit" runat="server" CssClass="modalPopup" Style="display:none ;" Width="850px"
                    BackColor="White">
                    <div class="section-title">
                        <asp:Label ID="lblPopupTitle" runat="server" Text="Open Maintainance Job"></asp:Label>
                    </div>
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td align="right" style="width: 180px;">
                                <div align="right">
                                    หัวข้อของปัญหา</div>
                                &nbsp;&nbsp;
                            </td>
                            <td width="600">
                                <asp:DropDownList ID="ddl_topic_problem" runat="server" Width="80%">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <span runat="server" id="sp1" class="requiredField"></span>
                            </td>
                            <td style="width: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                ปัญหา
                            </td>
                            <td>
                                <asp:TextBox ID="txtRootcuase" runat="server" TextMode="MultiLine" Width="95%" Rows="4"></asp:TextBox>
                                <span class="requiredField"></span>
                                <asp:RequiredFieldValidator ID="rf1" runat="server" ControlToValidate="txtRootcuase"
                                    ErrorMessage="กรุณากรอกรายละเอียดปัญหา" SetFocusOnError="True" ValidationGroup="val"
                                    Visible="False"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                ข้อควรแก้ไข &nbsp; : &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtINSTRUCTION" runat="server" TextMode="MultiLine" Width="95%"
                                    Rows="8"></asp:TextBox>
                                <br />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Job Type :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlJobType" runat="server" Width="300px">
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
