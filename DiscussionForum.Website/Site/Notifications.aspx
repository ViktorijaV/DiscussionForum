<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="DiscussionForum.Site.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <h3><span class="fa fa-bell-o">&nbsp;</span><span>Notifications</span></h3>
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-8">
            <div id="Notifs" runat="server">

            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-4"></div>
    </div>
</asp:Content>
