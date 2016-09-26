<%@ Page Title="Edit profile" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="DiscussionForum.Site.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-3 col-md-6 editProfile">
            <h3><span class="fa fa-pencil">&nbsp;</span><span>Edit profile</span></h3>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
            <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-3 col-md-6 form-group">
            <label for="txtFullName">FullName:</label>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                <asp:TextBox ID="txtFullName" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="New fullname"></asp:TextBox>
            </div>
        </div>
        <div class="col-xs-12 col-md-offset-3 col-md-6 form-group">
            <label for="txtBio">New bio:</label>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-book"></i></span>
                <asp:TextBox ID="txtBio" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="New bio" ClientIDMode="Static"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-3 col-md-6">
            <label>Change profile picture:</label>
            <div class="alert alert-warning">Image should be less than 2MB large. For best experience the picture should be squared.</div>
        </div>
        <div class="col-xs-12 col-md-offset-3 col-md-6">
            <asp:FileUpload ID="imageUpload" runat="server" Text="Upload new profile picture" accept="image/*" />
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-3 col-md-6">
            <button id="btn" class="btn btn-default pull-right" onclick="validateChangeUserProperties()"><i class="fa fa-floppy-o"></i>&nbsp;&nbsp;Save changes</button>
            <asp:Button ID="btnSave" runat="server" Style="display: none;" OnClick="btnSubmit_Click" />
        </div>
    </div>

    <asp:HiddenField ID="ID" runat="server" />
    <asp:HiddenField ID="Username" runat="server" />
    <asp:HiddenField ID="Avatar" runat="server" />
</asp:Content>
