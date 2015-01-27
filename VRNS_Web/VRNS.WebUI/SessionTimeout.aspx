<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SessionTimeout.aspx.vb" Inherits="VRNS.WebUI.SessionTimeout" %>
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
ขออภัย ท่านไม่ได้ดำเนินการภายในเวลาที่กำหนด
</h3>
<p>ข้อผิดพลาดที่เกิดขึ้นเกิดจากท่านไม่ได้ดำเนินการภายในเวลาที่กำหนด หรืออาจเกิดจากมีการปรับปรุงระบบใหม่</p>
<asp:HyperLink Text="กรุณาคลิกที่นี่เพื่อกลับไปยังหน้าที่แล้ว" ID="lnkBack" runat="server"></asp:HyperLink>
<br />
<br />
<a href="../Default.aspx">กรุณาคลิกที่นี่เพื่อกลับไปยังหน้าหลัก</a>
</center>
<br />
<br />
<br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
