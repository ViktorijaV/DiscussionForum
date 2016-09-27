<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="DiscussionForum.Site.AccessDenied" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="alert alert-danger">You have no access for that action!</div>
    </div>
</asp:Content>
