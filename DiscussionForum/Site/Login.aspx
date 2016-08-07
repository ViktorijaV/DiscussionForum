<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DiscussionForum.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <!-- Bootstrap Core CSS -->
    <link href="~/Site/Content/bootstrap.min.css" rel="stylesheet" />
    
    <!-- Custom Fonts -->
    <link href="~/Site/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href="~/Site/Content/style.css" rel="stylesheet" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/validation.js"></script>

</head>
<body>
    <div class="container">
        <form id="form2" runat="server">
            <div class="row">
                <div class="col-xs-offset-3 col-xs-6">
                    <a href="Home.aspx">
                        <img class="fit-in-div" src="../Storage/logoWithLetters.png" />
                    </a>
                </div>
            </div>
            <div class="row row-centered">
                <div class="col-xs-offset-4 col-xs-4">
                    <div id="error" runat="server" class="alert alert-danger"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
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
                    <a href="Register.aspx">Register Here</a>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <footer class="footer">
        <div class="container">
            <p class="m-b-0 text-muted">&copy; <%: DateTime.Now.Year %> - SmartSet</p>
        </div>
    </footer>
</body>
</html>
