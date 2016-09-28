<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DiscussionForum.Site.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="row">
        <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
            <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
        </div>
    </div>
    <div class="row">
        <div class="row">
        <div class="col-xs-12 col-md-offset-3 col-md-6 editProfile">
            <h3><span class="fa fa-tachometer ">&nbsp;</span><span>Admin dashboard</span></h3>
        </div>
    </div>
        <div id="rootwizard" class="col-xs-12 col-md-offset-3 col-md-6">
            <ul class="nav nav-pills ">
	  	<li><a href="#tab1" data-toggle="tab" class="adminFunctions">Reported topics</a></li>
		<li><a href="#tab2" data-toggle="tab" class="adminFunctions">Delete user</a></li>
		<li><a href="#tab4" data-toggle="tab" class="adminFunctions">Delete comment</a></li>
      
            </ul>
        </div>

    </div>
    <div class="tab-content">
	    <div class="tab-pane col-xs-12 col-md-offset-3 col-md-6" id="tab1">
	       <div class="col-xs-12">
           <div id="Reported" runat="server">

            </div>
        </div>
	    </div>
	    <div class="tab-pane col-xs-12 col-md-offset-3 col-md-6" id="tab2">
	      <div class=" col-md-4  input-group">
                <span class="input-group-addon">Please enter the email of the user you would like to delete below.</span>
            </div>
             <div class="col-md-4  input-group">
                <span class="input-group-addon"><i class="fa fa-unlock-alt "></i></span>
                <asp:TextBox ID="txtPass" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="Email"></asp:TextBox>
            </div>
	    </div>
		<div class="tab-pane col-xs-12 col-md-offset-3 col-md-6" id="tab4">
			4
	    </div>
    </div>
</asp:Content>
