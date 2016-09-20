<%@ Page Title="Edit profile" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="DiscussionForum.Site.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row">
       <div class="row">
                <div class="col-xs-offset-3 col-xs-6 editProfile">
                   <span id="editProfile">Edit profile</span>
                </div>
            </div>
       <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                    <asp:TextBox ID="txtEmail" CssClass="form-control form-control-input" runat="server" TextMode="Email" placeholder="New email"></asp:TextBox>
                </div>
       <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-book"></i></span>
                    <asp:TextBox ID="txtBio" CssClass="form-control form-control-input" runat="server" TextMode="MultiLine" placeholder="New bio"></asp:TextBox>
                </div>
       <div class="row">
            <div class="col-xs-offset-4 col-xs-4">
                <button id="btnUpload" class="btn btn-default pull-right"><i class="fa fa-floppy-o"></i>&nbsp;&nbsp;Upload photo</button>
            </div>
        </div>
       <div class="row">
            <div class="col-xs-offset-4 col-xs-4">
                <button id="btn" class="btn btn-default pull-right"><i class="fa fa-upload"></i>&nbsp;&nbsp;Save changes</button>
            </div>
        </div>
       
   </div>
</asp:Content>
