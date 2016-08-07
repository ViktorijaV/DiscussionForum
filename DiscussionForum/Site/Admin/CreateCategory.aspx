<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Admin/SiteAdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="DiscussionForum.Site.Admin.CreateCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="error" runat="server" class="alert alert-danger"></div>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSubmit" Style="display: none;" runat="server" Text="Button" OnClick="btnSumbit_Click" />
    <button id="btnCreate" onclick="validateCreateCategory()">Create</button>
</asp:Content>
