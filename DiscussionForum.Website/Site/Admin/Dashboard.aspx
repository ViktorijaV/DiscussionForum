<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DiscussionForum.Site.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-12 col-md-offset-3 col-md-6 editProfile">
                    <h3><span class="fa fa-tachometer ">&nbsp;</span><span>Admin dashboard</span></h3>
                </div>
                <div class="col-xs-12 col-md-offset-3 col-md-6 input-group">
                    <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
                </div>
                <div id="rootwizard" class="col-xs-12 col-md-offset-3 col-md-6">
                    <ul class="nav nav-pills ">
                        <li class="active"><a href="#tab1" data-toggle="tab" class="adminFunctions">Reported topics</a></li>
                        <li><a href="#tab2" data-toggle="tab" class="adminFunctions">Reported comments</a></li>
                        <li><a href="#tab3" data-toggle="tab" class="adminFunctions">Block user</a></li>
                        <li><a href="#tab4" data-toggle="tab" class="adminFunctions">Close topic</a></li>
                    </ul>
                </div>

            </div>
            <div class="tab-content row">
                <div class="tab-pane col-xs-12 col-md-offset-3 col-md-6 active" id="tab1">
                    <div id="ReportedTopics" runat="server">
                    </div>
                </div>
                <div class="tab-pane col-xs-12 col-md-offset-3 col-md-6" id="tab2">
                    <div id="ReportedComments" runat="server">
                    </div>
                </div>
                <div class="tab-pane col-xs-12 col-md-offset-3 col-md-6" id="tab3">
                    <div class="col-md-4  input-group delEm">
                        <span class="input-group-addon">Please enter the username of the user you would like to block below.</span>
                    </div>
                    <div class="col-md-8 input-group delEm">
                        <span class="input-group-addon"><i class="fa fa-unlock-alt "></i></span>
                        <asp:TextBox ID="txtUsername" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="Username"></asp:TextBox>
                    </div>
                    <div class="col-md-8">
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-default pull-right" OnClick="btnSave_Click"><i class="fa fa-paper-plane "></i>&nbsp;&nbsp;BLock user</asp:LinkButton>
                    </div>
                </div>

                <div class="tab-pane col-xs-12 col-md-offset-3 col-md-6" id="tab4">
                     <div class="col-md-4  input-group delEm">
                        <span class="input-group-addon">Please enter the id of the topic you would like to close below.</span>
                    </div>
                    <div class="col-md-8 input-group delEm">
                        <span class="input-group-addon"><i class="fa fa-unlock-alt "></i></span>

                        <asp:TextBox ID="txtTopicCode" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="ID"></asp:TextBox>
                    </div>
                    <div class="col-md-8">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default pull-right" OnClick="LinkButton1_Click"><i class="fa fa-paper-plane "></i>&nbsp;&nbsp;Close topic</asp:LinkButton>
                    </div>
                </div>
            </div>

            <!-- Modal for deleting topic report-->
            <div class="modal fade" id="deleteTopicReportModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel">Delete report</h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="topicReportId" runat="server" />
                            <h4>Are you sure you want to delete this report ?</h4>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-danger" onclick="deleteTopicReport()">Delete</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal for deleting comment report-->
            <div class="modal fade" id="deleteCommentReportModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel3" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel3">Delete report</h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="commentReportId" runat="server" />
                            <h4>Are you sure you want to delete this report ?</h4>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-danger" onclick="deleteCommentReport()">Delete</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal for deleting topic-->
            <div class="modal fade" id="deleteTopicModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel2">Delete topic</h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="topicID" runat="server" />
                            <h4>Are you sure you want to delte this topic ?</h4>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-danger" onclick="deleteTopic()">Delete</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal for deleting comment-->
            <div class="modal fade" id="deleteCommentModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel4">Delete comment</h4>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="commentID" runat="server" />
                            <h4>Are you sure you want to delte this comment ?</h4>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-danger" onclick="deleteComment()">Delete</button>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnDeleteTopicReport" Style="display: none;" runat="server" OnClick="btnDeleteTopicReport_Click" />
            <asp:Button ID="btnDeleteCommentReport" Style="display: none;" runat="server" OnClick="btnDeleteCommentReport_Click" />
            <asp:Button ID="btnDeleteTopic" Style="display: none;" runat="server" OnClick="btnDeleteTopic_Click" />
            <asp:Button ID="btnDeleteComment" Style="display: none;" runat="server" OnClick="btnDeleteComment_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
