<%@ Page Title="Edit profile" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="DiscussionForum.Site.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-offset-3 col-xs-6 editProfile">
            <h3><span class="fa fa-pencil">&nbsp;</span><span>Edit profile</span></h3>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-offset-4 col-xs-4 input-group">
            <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
            <asp:TextBox ID="txtEmail" CssClass="form-control form-control-input" runat="server" TextMode="Email" placeholder="New email"></asp:TextBox>
        </div>
        <div class="col-xs-offset-4 col-xs-4 input-group">
            <label>FullName:</label>
        </div>
        <div class="col-xs-offset-4 col-xs-4 input-group">
            <span class="input-group-addon"><i class="fa fa-user"></i></span>
            <asp:TextBox ID="txtFullName" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="New fullname"></asp:TextBox>
        </div>
        <div class="col-xs-offset-4 col-xs-4 input-group">
            <label>New bio:</label>
        </div>
        <div class="col-xs-offset-4 col-xs-4 input-group">
            <span class="input-group-addon"><i class="fa fa-book"></i></span>
            <asp:TextBox ID="txtBio" CssClass="form-control form-control-input" runat="server" TextMode="MultiLine" placeholder="New bio"></asp:TextBox>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-offset-4 col-xs-4">
            <asp:FileUpload ID="imageUpload" runat="server" Text="Upload new profile picture"/>
            <asp:LinkButton ID="btnUpload" runat="server" CssClass="btn btn-default pull-right"><i class="fa fa-upload"></i>&nbsp;&nbsp;Upload photo</asp:LinkButton>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-offset-4 col-xs-4">
            <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-default pull-right"><i class="fa fa-floppy-o"></i>&nbsp;&nbsp;Save changes</asp:LinkButton>
        </div>
    </div>
</asp:Content>
