<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MAStatusDetails.aspx.vb" Inherits="VRNS.WebUI.MAStatusDetails" %>
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
                    <span><span> Maintainance Details </span></span>


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
                                    <asp:TemplateField HeaderStyle-Width="" HeaderText="Branch Name">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="VRNS_BranchNM" runat="server" Text='<%#Eval("BranchName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="150" HeaderText="MA Team">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblMA" runat="server" Text='<%#Eval("MA_Team_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="150" HeaderText="Employee Contact">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployee" runat="server" Text='<%#Eval("EMP_Contact_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="150" HeaderText="Assign Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblUpdate" runat="server" Text='<%#Eval("LAST_UPD")%>'></asp:Label>
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
                     <table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 180px;">
                            
                                Solution :&nbsp;
                        </td>
                        <td width="600">
                            &nbsp;<asp:TextBox ID="txt_solution" runat="server" Rows="10" 
                                TextMode="MultiLine" Width="500px"></asp:TextBox> <span class="requiredField"></span>
&nbsp;<asp:HiddenField ID="Dev_Regis_ID" runat="server" />
                               
                        </td>
                        <td style="width: 10px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            Status :&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chkStatus" runat="server" Text="แกไขแล้ว" />
                        </td>
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
                    
                    <br /><br />
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
