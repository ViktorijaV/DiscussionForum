<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CategoryTopics.aspx.cs" Inherits="DiscussionForum.Site.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        body {
            background-color: #e6e6e6;
            color: #003366;
        }


        .listItem {
            font-size: 25px;
            margin: 10px;
            border: 2px solid #003366;
            width: 900px;
            left: 320px;
            margin-left: 8%;
            height: 635px;
            background-color: white;
            align-content: center;
        }

        .title {
            font-size: 35px;
            position: absolute;
            top: 90px;
            left: 285px;
            background-color: #e6e6e6;
        }
        
        .auto-style1 {
            font-size: 25px;
            border: 2px solid #003366;
            width: 900px;
            left: 320px;
            margin-left: 8%;
            height: 635px;
            background-color: white;
            align-content: center;
            margin-right: 10px;
            margin-top: 10px;
            margin-bottom: 264px;
        }
        .auto-style2 {
            font-size: 35px;
            position: absolute;
            top: 87px;
            left: 381px;
            background-color: #e6e6e6;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">


        <asp:Label ID="Label1" runat="server" Text="Category name" CssClass="auto-style2"></asp:Label>
        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style1" ></asp:ListBox>

    </asp:Panel>
</asp:Content>
