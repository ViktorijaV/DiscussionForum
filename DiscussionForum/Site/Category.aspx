<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="DiscussionForum.Site.CategoryTopic" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12">
            <asp:Label ID="categoryName" runat="server" Text="Label" CssClass="category-name"></asp:Label>
            <ul class="nav nav-pills">
                <li id="latest" class="active">Latest</li>
                <li id="top">Top</li>
                <li id="most-popular">Most Popular</li>
            </ul>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12">
            <asp:Table ID="tableTopics" runat="server" class="display" CellSpacing="0" Width="100%">
            </asp:Table>
        </div>
    </div>
</asp:Content>
