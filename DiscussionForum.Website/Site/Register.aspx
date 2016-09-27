<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DiscussionForum.Site.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-Register</title>
    <link href="~/Site/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Site/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="~/Site/Content/style.css" />
    <link rel="shortcut icon" href="/Storage/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="/Storage/favicon.ico" type="image/x-icon" />
</head>
<body class="body-without-nav">
    <div id="loading">
        <div id="loading-center">
            <div id="loading-center-absolute">
                <div class="object" id="object_one"></div>
                <div class="object" id="object_two" style="left: 20px;"></div>
                <div class="object" id="object_three" style="left: 40px;"></div>
                <div class="object" id="object_four" style="left: 60px;"></div>
                <div class="object" id="object_five" style="left: 80px;"></div>
            </div>
        </div>
    </div>
    <div class="container">
        <form id="form1" runat="server" method="post">
            <div class="row">
                <div class="col-xs-12 col-md-offset-3 col-md-6">
                    <a href="/home">
                        <img class="fit-in-div" src="/Storage/logoWithLetters.png" />
                    </a>
                </div>
            </div>
            <div class="row row-centered row-separated">
                <div class="col-xs-12 col-md-offset-4 col-md-4">
                    <div id="error" runat="server" class="alert alert-danger alert-dismissible display-none"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                    <asp:TextBox ID="txtEmail" CssClass="form-control form-control-input" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="txtPassword" CssClass="form-control form-control-input" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="txtRepeatPassword" CssClass="form-control form-control-input" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                    <asp:TextBox ID="txtFullName" CssClass="form-control form-control-input" runat="server" TextMode="SingleLine" placeholder="Full Name"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <label for="usr">Gender</label>
                    <div>
                        <label class="radio-inline">
                            <asp:RadioButton ID="male" runat="server" Checked="True" Text="Male" GroupName="Gender"></asp:RadioButton></label>
                        <label class="radio-inline">
                            <asp:RadioButton ID="female" runat="server" Text="Female" GroupName="Gender"></asp:RadioButton>
                        </label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <label for="usr">Birthdate</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                        <asp:TextBox ID="txtBirthday" CssClass="form-control form-control-input" runat="server" TextMode="Date" placeholder="Birthday"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-offset-4 col-md-4 input-group">
                    <div class="g-recaptcha" data-sitekey="6LdAgwcUAAAAAHtvdcydApZJmRIwrjvxhZbpUElJ"></div>
                </div>
            </div>
            <asp:Button ID="btnRegister" Style="display: none;" runat="server" OnClick="btnRegister_Click" />
            <br />
        </form>
        <div class="row">
            <div class="col-xs-12 col-md-offset-4 col-md-4">
                <button id="btn" class="btn btn-default pull-right" onclick="validateRegister()"><i class="fa fa-sign-in"></i>&nbsp;Register</button>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-offset-4 col-md-4">
                <div style="padding-top: 30px;">
                    Already have an account? 
                    <a href="login">Login Here</a>
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

    <script src="/Site/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Site/Scripts/validation.js" type="text/javascript"></script>
    <script src="/Site/Scripts/script.js" type="text/javascript"></script>
    <script src='https://www.google.com/recaptcha/api.js'></script>
</body>
</html>
