<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListOnlineBranch.aspx.vb" Inherits="VRNS.WebUI.OnlineBranch" %>

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
                    <span><span> List Online Branch </span></span>


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
