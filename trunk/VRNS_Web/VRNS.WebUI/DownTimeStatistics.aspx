<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DownTimeStatistics.aspx.vb" Inherits="VRNS.WebUI.DownTimeStatistics" %>
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
                    <span><span> DownT ime Statistics </span></span>


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
                       
                            <br />
                            <div style="padding-top: 5px; color: #0000FF; font-weight: bold; font-size: large;" 
                            align="left">Top 10 Branch Down-Time</div>
                            <br />
                            <br />
                            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" CssClass="gridtable" EmptyDataText="ไม่มีข้อมูล" ForeColor="#333333"
                                GridLines="None" ShowHeaderWhenEmpty="True" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="80" HeaderText="No.">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="VRNS_NO"  runat="server" Text='<%#Eval("No")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="" HeaderText="Branch Code">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="VRNS_BranchNM" runat="server" Text='<%#Eval("BRANCH_CODE")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="" HeaderText="Branch Name">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="VRNS_BranchNM" runat="server" Text='<%#Eval("BranchName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderStyle-Width="" HeaderText="Branch Tel">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="VRNS_BranchNM" runat="server" Text='<%#Eval("BranchTel")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="100" HeaderText="DownTime Count">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployee" runat="server" Text='<%#Eval("row")%>'></asp:Label>
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
