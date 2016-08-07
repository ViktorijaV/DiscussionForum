<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="DiscussionForum.Topic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        
        body{
             background-color: #e6e6e6;
              color: #003366;
        }

        .topPanel{

              border: 2px solid #003366;
              font-size: 25px;
              width: 800px;
              height: 200px;
              position: absolute;
              left: 270px;
              background-color: white;
              padding: 15px;
              padding-top: 30px;
              top: 200px;
             
        }

        .bottomPanel{
            border: 2px solid #003366;
              font-size: 25px;
              width: 800px;
              
              position: absolute;
              top: 500px;
              left: 270px;
              background-color: white;
              padding-top: 30px;
              padding-left: 15px;
        }

        .title{
            font-size:35px;
            position: absolute;
            top: -27px;
            left: 50px;
            background-color: #e6e6e6;
            
        }

        .titleBottom{

            font-size:35px;
            position: absolute;
            top: 470px;
            left: 315px;
            background-color: #e6e6e6;
        }

        .panelElements{

             margin-left: 200px;
            /*margin-top: 150px;*/ 
           
         }

        .inPanel{

            margin: 15px;
            font-size: 20px;

        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server" CssClass="topPanel">
        <asp:Label ID="Label1" runat="server" Text="| Topic name |" CssClass="title"></asp:Label>
        <asp:Label ID="Label3" runat="server" cssClass="inPanel" Text="Topic description // Topic description // Topic description // Topic description // Topic description // Topic description // Topic description"></asp:Label>
    </asp:Panel>
     
    <asp:ListBox ID="ListBox1" runat="server" CssClass="bottomPanel" Height="800px">
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
         <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
        <asp:ListItem>Answer</asp:ListItem>
       </asp:ListBox>
    <asp:Label runat="server" Text="| List of topic answers |" CssClass="titleBottom"></asp:Label>
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
