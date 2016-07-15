<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DiscussionForum.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlHeader" runat="server">
        logo, sign up i sign in
    </asp:Panel>
    <asp:Panel ID="pnlContent" runat="server">
        most popular, recent i all
    </asp:Panel>
    <asp:Panel ID="pnlFooter" runat="server">
        copyright
    </asp:Panel>

    <br />
    ---------------------------------------------Testing part---------------------------------------------<br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    Registered users (format: Fullname - Username):<br />
    <asp:ListBox ID="lstUsers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
    <br />
    Show password of the selected user:
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
    <br />
    Username:
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    &nbsp;Fullname:&nbsp;
            <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert User" />

    <br />
    <br />
    ---------------------------------------------------------------------------------------------------------------
        

</asp:Content>
