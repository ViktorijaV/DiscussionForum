<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="DiscussionForum.Site.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-7 profile-card">

            <div class="row full-height">
               
                <div class="row">

                <div class="col-xs-offset-1 col-xs-3 full-height pcphoto">
                    <asp:Image ID="profilePicture" Cssclass="fit-in-div profile-card-photo" runat="server"></asp:Image>
                </div>

                 <div class="col-xs-6 full-height usp">

                    <div class="profile-card-row">
                       <span class="profile-card-label username">Username</span>
                       <asp:Label ID="username" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>
                    <div class="profile-card-row">
                        <span class="profile-card-label fullName">FullName</span>
                        <asp:Label ID="fullname" runat="server" CssClass="profile-card-info"></asp:Label>
                    </div>

                </div>
               
                 <div class="col-xs-1 full-height editProfile">
                     <div class="profile-card-row">
                        <asp:LinkButton ID="btnLike" runat="server" CssClass="btn btn-icon faa-parent animated-hover editProfileChangeSize" ToolTip="Like"><i class="fa fa-pencil faa-tada"></i></asp:LinkButton>
                     </div>
                </div>
                
                </div>

                <div class="col-xs-offset-1 col-xs-9 full-height bio">
                
                    <div class="profile-card-row">
                       <!-- <span class="profile-card-label">Bio</span> -->
                        <asp:Label ID="bio" runat="server" CssClass="profile-card-info bio">Sed sed leo sit amet elit sagittis fermentum. Nulla posuere commodo erat. Nam ac nunc ipsum, id espara tincidunt orci. Quisque adipiscing molestie dolor, ut congue sem porta et. Sed sapien urna, auctor et accumsan ut, accumsan sit amet dui. Nunc tristique interdum magna, dictum volutpat sem. Nam ac nunc ipsum, id espara tincidunt orci. Sed sapien urna, auctor et accumsan ut</asp:Label>
                    </div>
                

                </div>

               <div class="col-xs-offset-1 col-xs-10 full-height">
                    <div class="profile-card-row">
                    
                        <div class="info">
                            <div class=" infoEl">
                                <span class="profile-card-label">Gender</span>
                            </div> 
                            <div class="infoMain">
                                <asp:Label ID="gender" runat="server" CssClass="profile-card-info"></asp:Label>
                            </div>
                             
                           
                        </div>
                        
                        <div class="info">
                            <div  class=" infoEl">
                                 <span class="profile-card-label">Age</span>
                            </div>
                            <div class="infoMain">
                                <asp:Label ID="age" runat="server" CssClass="profile-card-info"></asp:Label>
                            </div>
                            
                            
                        </div>

                        <div class="info">
                            <div class=" infoEl">
                                <span class="profile-card-label">Followers</span>
                            </div>
                            
                           <div class="infoMain">
                                 <asp:Label ID="Label1" runat="server" CssClass="profile-card-info"></asp:Label>
                            </div>
                            
                           
                        </div>

                        <div class="info">
                            <div class="infoEl">
                                <span class="profile-card-label">Following</span>
                            </div>
                            
                          <div class="infoMain">
                                <asp:Label ID="Label2" runat="server" CssClass="profile-card-info"></asp:Label>
                            </div>

                        </div>

                    </div>  
                
                </div>
                
                
                </div>



                
        </div>
        <div class="col-xs-3"></div>
    </div>
</asp:Content>
