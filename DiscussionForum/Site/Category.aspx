<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="DiscussionForum.Site.CategoryTopic" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12">
            <asp:Label ID="categoryName" runat="server" Text="Label" CssClass="category-name"></asp:Label>
            <asp:LinkButton ID="btnFollow" runat="server" CssClass="btn btn-default pull-right" OnClick="btnFollow_Click"><span class="fa fa-plus"></span>&nbsp;Follow category</asp:LinkButton>
            <asp:LinkButton ID="btnUnfollow" runat="server" CssClass="btn btn-default pull-right" OnClick="btnUnfollow_Click"><span class="fa fa-minus"></span>&nbsp;Unfollow category</asp:LinkButton>
            <ul class="nav nav-pills">
                <li id="latest" class="active">Latest</li>
                <li id="top">Top</li>
                <li id="most-popular">Most Popular</li>
            </ul>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-9">
            <asp:Table ID="tableTopics" runat="server" class="display" CellSpacing="0" Width="100%">
            </asp:Table>
        </div>
        <div class="col-xs-3">
            <h3>Followers</h3>
            <ul id="listFollowers" class="list-group" runat="server">
            </ul>
        </div>
    </div>
</asp:Content>
