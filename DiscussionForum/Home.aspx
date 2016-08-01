<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DiscussionForum.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        body{
             background-color: #e6e6e6;
        }


        .one{

            position: absolute;
            top: 585px;
             left: 600px;
            font-size: 35px;
            background-color: #e6e6e6;
        }

        .two{
            position: absolute;
            top: 1005px;
            left: 485px;
            font-size: 35px;
            color: #003366;
            background-color: #e6e6e6;
        }

        .three{
            position: absolute;
            top: 1427px;
             left: 485px;
            font-size: 35px;
            color: #003366;
            background-color: #e6e6e6;
        }

        .listItem{

            font-size: 25px;
            margin: 10px;
            border: 2px solid #003366;
            width: 1100px;
            left: 220px;
            
           
        }

        .welcome{
          position: absolute;
          left: 315px;
          font-size:50px;
          top: 260px;
        }
        .auto-style1 {
            font-size: 25px;
            margin: 10px;
            border: 2px solid #003366;
            left: 220px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      <br />
      <br />
      <br />
      <br />
      <asp:Label ID="Label2" runat="server" Text="All important welcome message" CssClass="welcome"></asp:Label>
      <br />
      <br />
      <br />
      <br />
  
      <asp:Label ID="Label1" runat="server" Text="Categories" CssClass="one"></asp:Label>
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
      <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style1" Height="300px" Width="1100px"></asp:ListBox>
     <asp:Label ID="Label4" runat="server" Text="Most popular categories" CssClass="two"></asp:Label>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <asp:ListBox ID="ListBox2" runat="server" CssClass="listItem" Height="300px" ></asp:ListBox>
     <asp:Label ID="Label5" runat="server" Text="Most recent categories" CssClass="three"></asp:Label>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <asp:ListBox ID="ListBox3" runat="server" CssClass="listItem" Height="300px"></asp:ListBox>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
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
