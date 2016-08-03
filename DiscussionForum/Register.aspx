<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DiscussionForum.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-Register</title>

    <!-- Bootstrap Core CSS -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="~/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <link href="~/Content/Style.css" rel="stylesheet" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/validateRegister.js"></script>
    <script src="Scripts/JavaScript.js"></script>

</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-xs-offset-3 col-xs-6">
                    <a href="Home.aspx">
                        <img class="fit-in-div" src="Storage/logoWithLetters.png" />
                    </a>
                </div>
            </div>
            <div class="row row-centered">
                <div class="col-xs-offset-4 col-xs-4">
                    <div id="error" class="alert alert-danger"></div>
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
                    <label for="usr">Select your gender:</label>
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
                    <label for="usr">Select your birthday date:</label>
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
                <button id="btn" class="btn btn-default pull-right" onclick="validate()">Register</button>
            </div>
        </div>

    </div>

    <asp:Label ID="lblLocation" runat="server" Text="Label">Location:</asp:Label>
    <pre id="location"></pre>
    <br />
    <asp:Label ID="lblCountry" runat="server" Text="Label">Country:</asp:Label>
    <pre id="country"></pre>
</body>
