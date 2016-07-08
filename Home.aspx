﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="style.css" rel="stylesheet" />
    <script src="jquery-3.0.0.js"></script>
    <script src="script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="pnlHeader" runat="server">
                logo, sign up i sign in
            </asp:Panel>
            <asp:Panel ID="pnlContent" runat="server">
                most popular, recent i all
            </asp:Panel>
            <asp:Panel ID="pnlFooter" runat="server">
                copyright
            </asp:Panel>

        </div>
    </form>
</body>
</html>
