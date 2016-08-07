<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Admin/SiteAdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="DiscussionForum.Site.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="error" runat="server" class="alert alert-danger"></div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <button id="btnCreate">Create</button>
</asp:Content>
