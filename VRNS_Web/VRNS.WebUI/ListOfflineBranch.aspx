<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListOfflineBranch.aspx.vb" Inherits="VRNS.WebUI.ListOfflineBranch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="UserControl/LeftMenu.ascx" tagname="LeftMenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
            <div class="main-content">
                <div id="info-accordion">
                    <span><span> List Offline Branch </span></span>


                    <table width="100%">
                    <tr>
                    <td width="20%" align="left" style="background-color:#eee;"  >
                       <div style="padding-top: 5px;  margin-left:-40px;">
                        <uc1:LeftMenu ID="LeftMenu1" runat="server" />
                        </div>
                        </td>
                    <td width="80%">
                    
                    <div style="padding-top: 5px;" align="center">
                        
                        <div style="padding-left: 10px;" align="left">
                            <table width="100%">
                            <tr>
                            <td width="20%">ค้นหาจากรหัสสาขา</td>
                            <td width="40%"> 
                            <asp:TextBox ID="txt_branchCode" runat="server" Width="200px"></asp:TextBox>
                                 
                                </td>
                            <td rowspan="3" >
                                <asp:Button ID="btn_search" runat="server" CssClass="button primary" 
                                    Text="ค้นหา" Width="100px" />
                                </td>
                            </tr>
                                <tr>
                                    <td width="20%">
                                        ค้นาจากชื่อสาขา</td>
                                    <td width="40%">
                                        <asp:TextBox ID="txt_branchName" runat="server" Width="200px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        ค้นหาจาก LAN IP</td>
                                    <td width="40%">
                                        <asp:TextBox ID="txt_branchLAN" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td width="40%">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                       
                            <br />
                            <br />
                            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" CssClass="gridtable" EmptyDataText="ไม่มีข้อมูล" ForeColor="#333333"
                                GridLines="None" ShowHeaderWhenEmpty="True" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="50" HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" Visible ="false"  runat="server" Text='<%#Eval("ID")%>'></asp:Label>

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
                                    <asp:TemplateField HeaderStyle-Width="150" HeaderText="LAN IPAddress">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblLAN_IP" runat="server" Text='<%#Eval("LAN_IP")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="150" HeaderText="Provider">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblProvider" runat="server" Text='<%#Eval("ISP")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Assign MA Team" HeaderStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkassign"  runat="server" CommandArgument='<%# Eval("ID") %>'
                                            CommandName="Assign" ImageUrl="~/images/tools/assign.png" Text="Assign" />
                                            <asp:HiddenField ID="GVhdfID" runat="server" Value='<%#Eval("ID")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status Details" HeaderStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkdetails"  runat="server" CommandArgument='<%# Eval("ID") %>'
                                            CommandName="Details" ImageUrl="~/images/tools/editList.png" Text="Assign" />
                                             
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
                     
                        <br />
                    </div>

                     <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
            <asp:Panel ID="pnlEdit" runat="server" CssClass="modalPopup" Style="display: ;" Width="850px"
                BackColor="White">
                <div class="section-title">
                    <asp:Label ID="lblPopupTitle" runat="server" Text="Open Maintainance Job"></asp:Label>
                </div>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 180px;">
                            
                                Branch&nbsp; :
                        </td>
                        <td width="600">
                            &nbsp;
                            <asp:Label ID="lbBranch" runat="server" Text=""></asp:Label>
                           
                            <asp:HiddenField ID="Dev_Regis_ID" runat="server" />
                             <asp:HiddenField ID="Maintainance_Record_ID" runat="server" />
                               
                        </td>
                        <td style="width: 10px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            MA Team&nbsp; :&nbsp;&nbsp; </td>
                        <td>
                         <asp:DropDownList ID="ddl_ma_team" runat="server" Width="80%">
                            </asp:DropDownList>
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
                            Employee Contact &nbsp; : &nbsp;
                        </td>
                        <td>
                             <asp:DropDownList ID="ddl_empcontact" runat="server" Width="80%">
                            </asp:DropDownList> &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <div class="metro" style="display: table; width: 100%; text-align: center; margin-top: 20px;
                    padding-bottom: 20px;">
                    <asp:Button ID="btnEditConfirm" runat="server" CssClass="button primary" Text="ตกลง"
                        Width="100" ValidationGroup="val" />
                    <asp:Button ID="btnEditCancel" runat="server" CssClass="button" Text="ปิด" Width="100" />
                </div>
                <br /> <br />
            </asp:Panel>
            <ajax:ModalPopupExtender ID="popup" runat="server" DropShadow="false" PopupControlID="pnlEdit"
                TargetControlID="lnkFake" BackgroundCssClass="modalBackground" CancelControlID="btnEditCancel">
            </ajax:ModalPopupExtender>

                    </td>
                    <td width=""></td>
                    </tr>
                    <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    </table>
                    
                </div>
            </div>
             
      
    </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
<script type="text/javascript">
    function BindJQuery() {

        $("#info-accordion").accordion({
            collapsible: false,
            heightStyle: "content",
            icons: null
        });



        $(".saInfo").click(function () {
            var opt = {
                modal: true,
                autoOpen: false,
                width: 600,
                height: 500
            }

            $(".dlgContent", '#saInfoPopup').html($(this).html());
            $('#saInfoPopup').dialog(opt).dialog('option', 'title', $('.dialogHead', this).val() + ':' + $('.topic', this).val()).dialog("open"); ;
            return false;
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
