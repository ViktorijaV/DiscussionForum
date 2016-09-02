<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="DiscussionForum.Site.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-3"></div>
        <div class="col-xs-6 profile-card">
            <div class="row full-height">
                <div class="col-xs-4 full-height">
                    <asp:Image ID="profilePicture" Cssclass="fit-in-div profile-card-photo" runat="server"></asp:Image>
                </div>
                <div class="col-xs-8 full-height">
                    <div class="profile-card-row">
                        <span class="profile-card-label">Username</span>
                        <asp:Label ID="username" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>
                    <div class="profile-card-row">
                        <span class="profile-card-label">FullName</span>
                        <asp:Label ID="fullname" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>
                    <div class="profile-card-row">
                        <span class="profile-card-label">Gender</span>
                        <asp:Label ID="gender" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>
                    <div class="profile-card-row">
                        <span class="profile-card-label">Age</span>
                        <asp:Label ID="age" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>
                    <div class="profile-card-row">
                        <span class="profile-card-label">Bio</span>
                        <asp:Label ID="bio" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-3"></div>
    </div>
</asp:Content>
