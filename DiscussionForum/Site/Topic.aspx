<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="DiscussionForum.Site.Topic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12">
            <a href="/topic/create" class="btn btn-default pull-right">Create new topic</a>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-9">
            <div class="row">
                <div class="col-xs-12 topic-info">
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:Image ID="creatorImg" runat="server" cssclass="img-rounded topic-info-img" />
                        </div>
                        <div class="col-xs-10">
                            <asp:Label ID="topicTitle" runat="server" cssclass="topic-info-title"></asp:Label>
                        </div>
                    </div>
                    <div class="row row-separated">
                        <div class="col-xs-12">
                            <div id="topicDescription" class="topic-info-description" runat="server">
                            </div>
                            <div class="topic-info-details">
                                <span class="fa fa-thumbs-o-up">Like</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-3">
            <div class="row row-separated">
                <div class="col-xs-12">
                    <asp:LinkButton ID="btnFollow" runat="server" CssClass="btn btn-default pull-right" OnClick="btnFollow_Click"><span class="fa fa-plus"></span>&nbsp;Follow topic</asp:LinkButton>
                    <asp:LinkButton ID="btnUnfollow" runat="server" CssClass="btn btn-default pull-right" OnClick="btnUnfollow_Click"><span class="fa fa-minus"></span>&nbsp;Unfollow topic</asp:LinkButton>
                </div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-heading">STATS</li>
                        <li class="list-group-item">Category&nbsp;
                            <asp:HyperLink ID="categoryLink" runat="server" cssclass="list-group-item-span"></asp:HyperLink>
                        </li>
                        <li class="list-group-item">Created&nbsp;- &nbsp;
                            <asp:Label id="createdTime" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">Last active&nbsp;-&nbsp;
                            <asp:Label id="activeTime" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">Followers&nbsp;<span id="Followers" class="badge" runat="server"></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
