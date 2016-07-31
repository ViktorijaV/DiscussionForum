<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DiscussionForum.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container form-group">
        <asp:Label ID="lblEmail" runat="server" Text="Label">Email:</asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Label">Password:</asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblRepeatPassword" runat="server" Text="Label">RepeatPassword:</asp:Label>
        <br />
        <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblFullName" runat="server" Text="Label">FullName:</asp:Label>
        <br />
        <asp:TextBox ID="txtFullName" runat="server" TextMode="SingleLine"></asp:TextBox>
        <br />
        <asp:Label ID="lblGender" runat="server" Text="Label">Select Gender:</asp:Label>
        <br />
        <br />
        <asp:Label ID="lblBirthday" runat="server" Text="Label">Select Birthday:</asp:Label>
        <br />
        <asp:TextBox ID="txtBirthday" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" />
    </div>
</asp:Content>
