<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditTopic.aspx.cs" Inherits="DiscussionForum.Site.EditTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12 col-sm-12 col-md-12">
            <h3><span class="fa fa-plus-circle">&nbsp;</span><span>Edit topic</span></h3>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-sm-10 col-md-8">
            <div class="row">
                <div class="col-xs-12">
                    <div id="editTopicError" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
                </div>
            </div>
            <div class="row separated">
                <div class="col-xs-12 col-sm-8 col-md-6">
                    <h4>Title</h4>
                    <asp:TextBox ID="txtEditTitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 col-md-6"></div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12">
                    <h4>Description</h4>
                    <textarea id="txtEditDesc" runat="server" class="form-control"></textarea>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-2 col-md-4">
            <div class="row row-separated">
                <div class="col-xs-12">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-heading">STATS</li>
                        <li class="list-group-item">Category&nbsp;
                            <asp:HyperLink ID="categoryLink" runat="server" CssClass="list-group-item-span"></asp:HyperLink>
                        </li>
                        <li class="list-group-item">Created&nbsp;- &nbsp;
                            <asp:Label ID="createdTime" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">Last active&nbsp;-&nbsp;
                            <asp:Label ID="activeTime" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">Followers&nbsp;<span id="Followers" class="badge" runat="server"></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12">
            <button id="btnEdit" class="btn btn-default" onclick="validateEditTopic(); return false;">Edit</button>
            <asp:Button ID="btnEditTopic" Style="display: none;" runat="server" OnClick="btnEditTopic_Click" />
        </div>
    </div>
</asp:Content>
