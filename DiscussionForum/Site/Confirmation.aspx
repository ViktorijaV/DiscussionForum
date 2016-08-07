<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="DiscussionForum.Site.Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblText" runat="server" Text="Label">
        <h1>An email has been send to you. Please confirm your account.</h1>
    </asp:Label>
</asp:Content>
