<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DiscussionForum.Site.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-Login</title>
    <link href="~/Site/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Site/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="~/Site/Content/style.css" />
    <link rel="shortcut icon" href="/Storage/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="/Storage/favicon.ico" type="image/x-icon" />
</head>
<body class="body-without-nav">
    <div class="container">
        <form id="form2" runat="server">
            <div class="row">
                <div class="col-xs-offset-3 col-xs-6">
                    <a href="/home">
                        <img class="fit-in-div" src="/Storage/logoWithLetters.png" />
                    </a>
                </div>
            </div>
            <div class="row row-centered">
                <div class="col-xs-offset-4 col-xs-4">
                    <div id="error" runat="server" class="alert alert-danger display-none"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                    <asp:TextBox ID="txtEmail" CssClass="form-control form-control-input" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="txtPassword" CssClass="form-control form-control-input" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cbRememberMe" runat="server" />
                            Remember me
                        </label>

                    </div>
                </div>
            </div>
            <asp:Button ID="btnLoginServer" Style="display: none;" runat="server" OnClick="btnLogin_Click" />
        </form>
        <div class="row">
            <div class="col-xs-offset-4 col-xs-4">
                <button id="btn" class="btn btn-default pull-right" onclick="validateLogin()"><i class="fa fa-sign-in"></i>&nbsp;Login</button>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-offset-4 col-xs-4">
                <div style="padding-top: 30px; font-size: 90%">
                    Don't have an account? 
                    <a href="register">Register Here</a>
                </div>
            </div>
        </div>
    </div>

    <script src="/Site/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Site/Scripts/validation.js" type="text/javascript"></script>
    <script src="/Site/Scripts/script.js" type="text/javascript"></script>
</body>
</html>
