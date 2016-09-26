<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="DiscussionForum.Site.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12 col-md-offset-3 col-md-6 editProfile">
            <h3><span class="fa fa-paper-plane">&nbsp;</span><span>Forgot password</span></h3>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
            <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
        </div>
    </div>
    <div class="col-xs-12 col-md-offset-3 col-md-4 form-group">
            <div class="input-group message">
                <span >Please enter your email address below and we will send you instructions for setting a new password.</span>
            </div>
        </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-3 col-md-4 form-group">
            <label for="txtEmail">Email:</label>
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                <asp:TextBox ID="txtEmail" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="Email"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row row-separated">
        <div class="col-xs-12 col-md-offset-1 col-md-6">
            <button id="btn" class="btn btn-default pull-right" onclick="validateChangeUserProperties()"><i class="fa fa-paper-plane "></i>&nbsp;&nbsp;Send email</button>
            <asp:Button ID="btnSave" runat="server" Style="display: none;" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
