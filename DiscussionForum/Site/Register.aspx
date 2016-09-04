<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DiscussionForum.Site.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-Register</title>
    <link href="~/Site/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Site/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="~/Site/Content/style.css" />
</head>
<body class="body-without-nav">
    <div class="container">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-xs-offset-3 col-xs-6">
                    <a href="home">
                        <img class="fit-in-div" src="../Storage/logoWithLetters.png" />
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
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="txtRepeatPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                    <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server" TextMode="SingleLine" placeholder="Full Name"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-offset-4 col-xs-4 input-group">
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
                <div class="col-xs-offset-4 col-xs-4 input-group">
                    <label for="usr">Birthdate</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                        <asp:TextBox ID="txtBirthday" CssClass="form-control" runat="server" TextMode="Date" placeholder="Birthday"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnRegister" Style="display: none;" runat="server" OnClick="btnRegister_Click" />
        </form>
        <div class="row">
            <div class="col-xs-offset-4 col-xs-4">
                <button id="btn" class="btn btn-default pull-right" onclick="validateRegister()"><i class="fa fa-sign-in"></i>&nbsp;Register</button>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-offset-4 col-xs-4">
                <div style="padding-top: 30px; font-size: 90%">
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
    <script src="Site/Scripts/JavaScript.js" type="text/javascript"></script>

    <!-- This will be moved to PROFILE & EDIT PROFILE -->
    <asp:Label ID="lblLocation" runat="server" Text="Label">Location:</asp:Label>
    <pre id="location"></pre>
    <br />
    <!-- Location can be edited and Country cannot. -->
    <asp:Label ID="lblCountry" runat="server" Text="Label">Country:</asp:Label>
    <pre id="country"></pre>
    <!-- -------------------------------------------- -->
</body>
</html>
