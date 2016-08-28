<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DiscussionForum.Site.Home" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-8">
            <ul class="nav nav-pills">
                <li id="latest" class="active">Latest</li>
                <li id="top">Top</li>
                <li id="most-popular">Most Popular</li>
            </ul>
        </div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <asp:Table ID="tableTopics" runat="server" class="display" CellSpacing="0" Width="100%">
        </asp:Table>

    </div>

    <script src="http://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="Scripts/script.js"></script>
</asp:Content>
