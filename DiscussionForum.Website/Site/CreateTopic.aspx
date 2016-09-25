<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CreateTopic.aspx.cs" Inherits="DiscussionForum.Site.CreateTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12 col-sm-12 col-md-12">
            <h3><span class="fa fa-plus-circle">&nbsp;</span><span>Create new topic</span></h3>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-sm-12 col-md-10">
            <div class="row">
                <div class="col-xs-12">
                    <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
                </div>
            </div>
            <div class="row separated">
                <div class="col-xs-12 col-sm-8 col-md-6">
                    <h4>Title</h4>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 col-md-6"></div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <h4>Category</h4>
                    <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-8"></div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12">
                    <h4>Description</h4>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-2">
            <div class="row row-separated">
                <div class="col-xs-12">
                    <h4>Properties</h4>
                    <hr />
                </div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-8 col-sm-6 col-sm-12">
                    <h5>Created by:</h5>
                    <asp:Image ID="currentUser" runat="server" CssClass="half-size" />
                </div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12">
                    <h5>Status:</h5>
                    <span>Open</span>
                </div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12">
                    <button class="btn btn-default btn-fit">Suggest creating new category</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12">
            <button id="btnCreate" class="btn btn-default" onclick="validateCreateTopic(); return false;">Post</button>
            <asp:Button ID="btnSubmit" Style="display: none;" runat="server" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
