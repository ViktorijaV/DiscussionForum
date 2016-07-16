<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DiscussionForum.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <!-- Bootstrap Core CSS -->
    <link href="~/Content/Css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="~/Content/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="~/Content/Css/Style.css" />
</head>
<body>
    <form id="form1" runat="server">
            <div class="container">

                <div id="loginbox" class="mainbox col-md-6 col-md-offset-3 col-sm-6 col-sm-offset-3">

                    <div class="row">
                            <img class="fit-in-div" src="https://eclipse.org/artwork/images/v2/logo-800x188.png" />
                       
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="panel-title text-center">SmartSet</div>
                        </div>

                        <div class="panel-body">

                            <form name="form" id="form" class="form-horizontal" enctype="multipart/form-data">

                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    <input id="user" type="text" class="form-control" name="user" value="" placeholder="User" />
                                </div>

                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                    <input id="password" type="password" class="form-control" name="password" placeholder="Password">
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-12 controls">
                                        <button runat="server" id="btnLogin" onserverclick="btnLogin_Click" type="submit" class="btn btn-primary pull-right"><i class="fa fa-sign-in"></i>&nbsp;Log in</button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style=""border-top: 1px solid#888; padding-top: 15px; font-size: 85%">
                                            Don't have an account! 
                                        <a href="Register.aspx">Sign Up Here</a>
                                        </div>
                                    </div>
                                </div>
                            </form>

                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
