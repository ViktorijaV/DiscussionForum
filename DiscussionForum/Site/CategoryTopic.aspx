<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CategoryTopics.aspx.cs" Inherits="DiscussionForum.Site.CategoryTopic" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-Category</title>

    <!-- Bootstrap Core CSS -->
    <link href="~/Site/Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="~/Site/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href="~/Site/Content/style.css" rel="stylesheet" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/validation.js"></script>
    <script src="Scripts/JavaScript.js"></script>

</head>

    <body>
        <div class="container">
            

           <form runat="server">

               <div class="row">
                   <div class="col-xs-offset-3 col-xs-7 input-group">
                     <h1> <asp:Label ID="Label1" runat="server" Text="Category name"></asp:Label> </h1>
                   </div>
               </div>

               <div class="row">
                     <div class="col-xs-offset-3 col-xs-7 input-group">
                         <asp:ListBox ID="ListBox1" runat="server" CssClass="form-control" ></asp:ListBox>
                    </div>
                </div>

            </form>


        </div>


    </body>