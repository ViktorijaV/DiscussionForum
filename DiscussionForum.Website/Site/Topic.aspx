<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="DiscussionForum.Site.Topic" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-separated">
        <div class="col-xs-12">
            <a href="/topic/create" class="btn btn-default pull-right">Create new topic</a>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-9">
            <div class="row">
                <div class="col-xs-12 topic-info">
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:Image ID="creatorImg" runat="server" CssClass="img-rounded topic-info-img" />
                        </div>
                        <div class="col-xs-10">
                            <asp:Label ID="topicTitle" runat="server" CssClass="topic-info-title"></asp:Label>
                            <div class="btn-group pull-right">
                                <a class="btn btn-icon dropdown-toggle faa-parent animated-hover tool expand" data-title="Edit or report this topic" data-toggle="dropdown" href="#">
                                    <i class="fa fa-cogs faa-spin" aria-hidden="true"></i>
                                </a>
                                <ul class="dropdown-menu">
                                    <li><a href="#" data-toggle="modal" data-target="#editTopicModal"><i class="fa fa-pencil fa-fw faa-spin"></i>Edit</a></li>
                                    <li><a href="#" data-toggle="modal" data-target="#reportTopicModal"><i class="fa fa-exclamation-circle fa-fw"></i>Report</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>


                    <div class="row row-separated">
                        <div class="col-xs-12">
                            <div id="topicDescription" class="topic-info-description" runat="server">
                            </div>
                            <asp:LinkButton ID="btnLike" runat="server" OnClick="btnLike_Click" CssClass="btn btn-icon faa-parent animated-hover" ToolTip="Like"><i class="fa fa-star-o faa-tada"></i></asp:LinkButton>
                            <asp:LinkButton ID="btnUnlike" runat="server" OnClick="btnUnlike_Click" CssClass="btn btn-icon faa-parent animated-hover" ToolTip="UnLike"><i class="fa fa-star faa-tada"></i></asp:LinkButton>
                            <asp:Label ID="btnlikeNum" runat="server" Text="" CssClass="span-number"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 topic-comments">
                    <div class="topic-comments-heading">
                        <i class="fa fa-comment"></i>
                        <span id="numComments" runat="server"></span>
                        &nbsp;Comments
                   
                    </div>
                    <div class="topic-comments-container">
                        <ul id="CommentList" class="media-list" runat="server">
                        </ul>
                    </div>
                    <div class="topic-comments-textarea">
                        <div class="topic-comments-textarea-heading">Add your comment</div>
                        <div id="error" runat="server" class="alert alert-danger display-none"></div>
                        <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <button id="btnCreate" class="btn btn-default" onclick="validateCreateComment(); return false;">Add comment</button>
                        <asp:Button ID="btnCreateComment" Style="display: none;" runat="server" OnClick="btnCreateComment_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-3">
            <div class="row row-separated">
                <div class="col-xs-12">
                    <asp:LinkButton ID="btnFollow" runat="server" CssClass="btn btn-default pull-right" OnClick="btnFollow_Click"><span class="fa fa-plus"></span>&nbsp;Follow topic</asp:LinkButton>
                    <asp:LinkButton ID="btnUnfollow" runat="server" CssClass="btn btn-default pull-right" OnClick="btnUnfollow_Click"><span class="fa fa-minus"></span>&nbsp;Unfollow topic</asp:LinkButton>
                </div>
            </div>
            <div class="row row-separated">
                <div class="col-xs-12">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-heading">STATS</li>
                        <li class="list-group-item">Category&nbsp;
                            <asp:HyperLink ID="categoryLink" runat="server" CssClass="list-group-item-span"></asp:HyperLink>
                        </li>
                        <li class="list-group-item">Created&nbsp;- &nbsp;
                            <asp:Label ID="createdTime" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">Last active&nbsp;-&nbsp;
                            <asp:Label ID="activeTime" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">Followers&nbsp;<span id="Followers" class="badge" runat="server"></span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for edit comment-->
    <div class="modal fade" id="editCommentModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel">Edit comment</h4>
                </div>
                <div class="modal-body">
                    <div id="editError" runat="server" class="alert alert-danger display-none"></div>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" onclick="closeEditCommentModal()">Close</button>
                    <button type="button" class="btn btn-primary" onclick="validateEditComment()">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal for edit topic-->
<div class="modal fade" id="editTopicModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabell" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
        <h4 class="modal-title" id="myModalLabell">Edit your topic</h4>
      </div>
      <div class="modal-body">
       <b> Edit title: </b> <br />
      <asp:TextBox ID="tb" runat="server" ></asp:TextBox>
         <br />
          <br />

       <b>Edit description </b>

          <br />
      <asp:TextBox ID="topicDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>

        <!-- Modal for edit topic-->
<div class="modal fade" id="reportTopicModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabell" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
        <h4 class="modal-title" id="myModalLabelll">Report this topic</h4>
      </div>
      <div class="modal-body">
    



          <div class="row" >
     
        <div class="[ form-group ]">
            <input type="checkbox" name="fancy-checkbox-primary" id="fancy-checkbox-primary"  />
            <div class="[ btn-group ]">
                <label for="fancy-checkbox-primary" class="[ btn btn-primary ]">
                    <span class="[ glyphicon glyphicon-ok ]"></span>
                    <span> </span>
                </label>
                <label for="fancy-checkbox-primary" class="[ btn btn-default active ]">
                    Already exists same or similar topic
                </label>
            </div>
        </div>
        <div class="[ form-group ]">
            <input type="checkbox" name="fancy-checkbox-success" id="fancy-checkbox-success"  />
            <div class="[ btn-group ]">
                <label for="fancy-checkbox-success" class="[ btn btn-success ]">
                    <span class="[ glyphicon glyphicon-ok ]"></span>
                    <span> </span>
                </label>
                <label for="fancy-checkbox-success" class="[ btn btn-default active ]">
                    It contains offensive content
                </label>
            </div>
        </div>
        <div class="[ form-group ]">
            <input type="checkbox" name="fancy-checkbox-info" id="fancy-checkbox-info"  />
            <div class="[ btn-group ]">
                <label for="fancy-checkbox-info" class="[ btn btn-info ]">
                    <span class="[ glyphicon glyphicon-ok ]"></span>
                    <span> </span>
                </label>
                <label for="fancy-checkbox-info" class="[ btn btn-default active ]">
                  This shoudn't be on SmartSet
                </label>
            </div>
        </div>
       
             <div id="other">
                  <label> Other: </label> 
                  <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                 </div>
  
    </div>



      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Report topic</button>
      </div>
    </div>
  </div>
</div>
    



    <asp:HiddenField ID="commentID" runat="server" />
    <asp:Button ID="btnLikeComment" runat="server" Style="display: none;" OnClick="btnLikeComment_Click" />
    <asp:Button ID="btnUnlikeComment" runat="server" Style="display: none;" OnClick="btnUnlikeComment_Click" />
    <asp:Button ID="btnEditComment" runat="server" Style="display: none;" OnClick="btnEditComment_Click" />
</asp:Content>
