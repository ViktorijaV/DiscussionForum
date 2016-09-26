<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="DiscussionForum.Site.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12 col-md-offset-3 col-md-6 editProfile">
            <h3><span class="fa fa-pencil">&nbsp;</span><span>Reset password</span></h3>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
            <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
        </div>
    </div>
    <div class="col-xs-12 col-md-offset-3 col-md-4 form-group">
            <div class="input-group message">
                <span >Please enter your new password and the code we sent you below.</span>
            </div>
        </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-3 col-md-4 form-group">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-unlock-alt "></i></span>
                <asp:TextBox ID="txtPass" CssClass="form-control form-control-input" runat="server" TextMode="Password" placeholder="New password"></asp:TextBox>
            </div>
        </div>
        <div class="col-xs-12 col-md-offset-3 col-md-4 form-group">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-unlock-alt "></i></span>
                <asp:TextBox ID="txtCofirm" CssClass="form-control form-control-input" runat="server" TextMode="Password" placeholder="Confirm new password"></asp:TextBox>
            </div>
        </div>
        <div class="col-xs-12 col-md-offset-3 col-md-4 form-group">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-codepen"></i></span>
                <asp:TextBox ID="txtCode" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="Code"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-1 col-md-6">
            <button id="btn" class="btn btn-default pull-right" onclick="validateChangeUserProperties()"><i class="fa fa-floppy-o"></i>&nbsp;&nbsp;Save new password</button>
            <asp:Button ID="btnSave" runat="server" Style="display: none;" />
        </div>
    </div>
</asp:Content>
