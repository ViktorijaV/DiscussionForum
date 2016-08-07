<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CreateTopic.aspx.cs" Inherits="DiscussionForum.Site.CreateTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body {
            background-color: #e6e6e6;
            color: #003366;
        }

        .mainPanel {
            border: 2px solid #003366;
            font-size: 25px;
            width: 800px;
            height: 780px;
            position: absolute;
            left: 270px;
            background-color: white;
            padding-top: 10px;
        }

        .title {
            font-size: 35px;
            position: absolute;
            top: -27px;
            left: 285px;
            background-color: #e6e6e6;
        }

        .panelElements {
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
    <asp:Panel ID="Panel1" runat="server" CssClass="mainPanel">

        <asp:Label ID="Label1" runat="server" Text="|  New Topic  |" CssClass="title" Font-Size="28pt"></asp:Label>
        <br />
        <br />
        <br />

        <div class="row">
            <div class="col-xs-12">
                <div id="error" runat="server" class="alert alert-danger"></div>
            </div>
        </div>

        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name" CssClass="panelElements"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server" CssClass="panelElements"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Description" CssClass="panelElements"></asp:Label>
        <br />
        <asp:TextBox ID="txtDescription" runat="server" CssClass="panelElements" Height="119px" TextMode="MultiLine" Width="440px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Category" CssClass="panelElements"></asp:Label>
        <br />
        <br />

        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control">
        </asp:DropDownList>
        <br />
        <br />

        <asp:Button ID="btnSubmit" Style="display: none;" runat="server" OnClick="btnSumbit_Click" />
        <button id="btnCreate" class="btn btn-default" onclick="validateCreateTopic(); return false;">Create</button>
        <br />
        <br />

    </asp:Panel>
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>
