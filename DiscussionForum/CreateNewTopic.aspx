<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CreateNewTopic.aspx.cs" Inherits="DiscussionForum.CreateNewTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        
        body{
             background-color: #e6e6e6;
              color: #003366;
        }

        .mainPanel{

              border: 2px solid #003366;
              font-size: 25px;
              width: 800px;
              height: 600px;
              position: absolute;
              left: 270px;
              background-color: white;
              padding-top: 10px;
             
        }

        .title{
            font-size:35px;
            position: absolute;
            top: -27px;
            left: 285px;
            background-color: #e6e6e6;

        }

        .panelElements{

             margin-left: 200px;
            /*margin-top: 150px;*/ 
           
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server"  CssClass="mainPanel">
      
        <asp:Label ID="Label1" runat="server" Text="|  New Topic  |" CssClass="title" Font-Size="28pt"></asp:Label> <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name" CssClass="panelElements"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="panelElements"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Description" CssClass="panelElements"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="panelElements" Height="119px" TextMode="MultiLine" Width="440px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Category" CssClass="panelElements"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="panelElements">
            <asp:ListItem>Programming</asp:ListItem>
            <asp:ListItem>Discrete Mathematics</asp:ListItem>
            <asp:ListItem>Calculus</asp:ListItem>
            <asp:ListItem>Web Design</asp:ListItem>
            <asp:ListItem>Web Development</asp:ListItem>
            <asp:ListItem>Computer Networking</asp:ListItem>
            <asp:ListItem>Probability and Statistics</asp:ListItem>
            <asp:ListItem>Algorithms and Data Structures</asp:ListItem>
            <asp:ListItem>Operating Systems</asp:ListItem>
            <asp:ListItem>Artificial Intelligence</asp:ListItem>
            <asp:ListItem>Software Engineering</asp:ListItem>
            <asp:ListItem>DataBases</asp:ListItem>
            <asp:ListItem>Shell</asp:ListItem>
        </asp:DropDownList>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br /><br />
    <br />
    <br />
    <br />
    <br /><br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
