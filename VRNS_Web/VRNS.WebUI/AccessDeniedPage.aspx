<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AccessDeniedPage.aspx.vb" Inherits="VRNS.WebUI.AccessDeniedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<br />
<br />
<br />
<center>
<h3 align="center">
Access Denied Please contact Product Manager
</h3>
    <asp:Label ID="lbError" runat="server" Text=""></asp:Label>

<br />
<a href="../Default.aspx">Return to Homepage</a>
</center>
<br />
<br />
<br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
