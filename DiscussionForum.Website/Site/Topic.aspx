﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="DiscussionForum.Site.Topic" MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row row-separated">
                <div class="col-md-12">
                    <a href="/topic/create" class="btn btn-default pull-right">Create new topic</a>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-md-push-9">
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
                <div class="col-md-9 col-md-pull-3">
                    <div class="row">
                        <div class="col-md-12 topic-info">
                            <div class="row">
                                <div class="col-xs-6 col-md-2">
                                    <asp:Image ID="creatorImg" runat="server" CssClass="img-rounded topic-info-img" />
                                </div>
                                <div class="clo-xs-6 col-md-10">
                                    <asp:Label ID="topicTitle" runat="server" CssClass="topic-info-title"></asp:Label>
                                    <div class="btn-group pull-right">
                                        <a class="btn btn-icon dropdown-toggle faa-parent animated-hover tool expand" data-title="Edit or report this topic" data-toggle="dropdown" href="#">
                                            <i class="fa fa-cogs faa-spin" aria-hidden="true"></i>
                                        </a>
                                        <ul id="settingsDropdown" runat="server" class="dropdown-menu">
                                            <li><a data-toggle="modal" data-target="#reportTopicModal"><i class="fa fa-exclamation-circle fa-fw"></i>Report</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="row row-separated">
                                <div class="col-xs-12">
                                    <div>Created <span id="timeCreated" runat="server"></span>by <span id="creatorUsername" runat="server"></span></div>
                                    <div id="timeEdited" runat="server"></div>
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
                        <div class="col-md-12 topic-comments">
                            <div class="topic-comments-heading">
                                <i class="fa fa-comment"></i>
                                <span id="numComments" runat="server"></span>
                                &nbsp;Comments
                   
                            </div>
                            <div class="topic-comments-container">
                                <ul id="CommentList" class="media-list" runat="server">
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="commentID" runat="server" />
            <asp:Button ID="btnLikeComment" runat="server" Style="display: none;" OnClick="btnLikeComment_Click" />
            <asp:Button ID="btnUnlikeComment" runat="server" Style="display: none;" OnClick="btnUnlikeComment_Click" />
            <asp:Button ID="btnEditComment" runat="server" Style="display: none;" OnClick="btnEditComment_Click" />
            <asp:Button ID="btnReportTopic" runat="server" Style="display: none;" OnClick="btnReportTopic_Click" />
            <asp:Button ID="btnReportComment" runat="server" Style="display: none;" OnClick="btnReportComment_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="row">
        <div class="col-md-3 col-md-push-9"></div>
        <div class="col-md-9 col-md-pull-3">
            <div class="row">
                <div id="addcomment" class="col-xs-12  topic-comments" runat="server">
                    <div class="topic-comments-textarea">
                        <div class="topic-comments-textarea-heading">Add your comment</div>
                        <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
                        <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <button id="btnCreate" class="btn btn-default" onclick="validateCreateComment(); return false;">Add comment</button>
                        <asp:Button ID="btnCreateComment" Style="display: none;" runat="server" OnClick="btnCreateComment_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Modal for displaying message-->
    <div class="modal fade" id="messageModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content alert alert-success">
                <div class="modal-body">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 id="messageInModal"></h4>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for edit comment-->
    <div class="modal fade" id="editCommentModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Edit comment</h4>
                </div>
                <div class="modal-body">
                    <div id="editError" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" onclick="closeEditCommentModal()">Close</button>
                    <button type="button" class="btn btn-primary" onclick="validateEditComment()">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for report topic-->
    <div class="modal fade" id="reportTopicModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabell" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabelll">Report this topic</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-12">
                            <div id="errorReportTopic" runat="server" class="alert alert-danger display-none"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <asp:RadioButtonList ID="listReportTopic" runat="server" CssClass="radiobuttonlist">
                                    <asp:ListItem Text="Already exists same or similar topic" Value="Already exists same or similar topic"></asp:ListItem>
                                    <asp:ListItem Text="It contains offensive content" Value="It contains offensive content"></asp:ListItem>
                                    <asp:ListItem Text="This shoudn't be on SmartSet" Value="This shoudn't be on SmartSet"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="other">
                                <label>Other: </label>
                                <asp:TextBox ID="txtOther" runat="server" CssClass="form-control form-control-input"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="validateReportTopic()">Report topic</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal for report comment-->
    <div class="modal fade" id="reportCommentModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabellll" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabellll">Report this comment</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-12">
                            <div id="errorReportComment" runat="server" class="alert alert-danger display-none"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <asp:RadioButtonList ID="listReportComment" runat="server" CssClass="radiobuttonlist">
                                    <asp:ListItem Text="This comment contains offence content" Value="This comment contains offence content"></asp:ListItem>
                                    <asp:ListItem Text="This shoudn't be on SmartSet" Value="This shoudn't be on SmartSet"></asp:ListItem>
                                    <asp:ListItem Text="This is spam" Value="This is spam"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="otherC">
                                <label>Other: </label>
                                <asp:TextBox ID="txtOtherReason" runat="server" CssClass="form-control form-control-input"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="validateReportComment()">Report comment</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
