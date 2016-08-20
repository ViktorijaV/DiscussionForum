<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="CreateTopic.aspx.cs" Inherits="DiscussionForum.Site.CreateTopic" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-CreateTopic</title>

    <!-- Bootstrap Core CSS -->
    <link href="~/Site/Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="~/Site/Fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <link href="~/Site/Content/style.css" rel="stylesheet" />
    <link href="~/Site/Content/Custom.css" rel="stylesheet" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/validation.js"></script>
    <script src="Scripts/JavaScript.js"></script>
   

</head>
<body>
    <div class="container">
         <form id="form1" runat="server">


             <div class="row">
                <div class="col-xs-offset-3 col-xs-6">
                    <a href="Home.aspx">
                        <img class="fit-in-div" src="../Storage/logoWithLetters.png" />
                    </a>
                </div>
            </div>
            
        <div class="row">
            <div class="col-xs-12">
                <div id="error" runat="server" class="alert alert-danger"></div>
            </div>
        </div>

     
        <div class="row">
             <div class="col-xs-offset-4 col-xs-4 input-group">
                 <span class="input-group-addon"><i class="fa fa-user"></i></span>
                 <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name"></asp:TextBox>
                </div>
        </div>

      

        <div class="row">
             <div class="col-xs-offset-4 col-xs-4 input-group">
                  <span class="input-group-addon"><i class="fa fa-paragraph"></i></span>
                 <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine" placeholder="Description..." Rows="7"></asp:TextBox>
                </div>
        </div>

        
        <div class="row">
             <div class="col-xs-offset-4 col-xs-4 input-group">
                 <label for="usr">Category</label>
                 <div class="input-group">

                    <span class="input-group-addon"><i class="fa fa-th-list"></i></span>
                    <asp:DropDownList ID="ddlCategories" CssClass="form-control" runat="server" placeholder="Description..."></asp:DropDownList>
                 </div>
              </div>
        </div>


             <div class="row">
             <div class="col-xs-offset-4 col-xs-4 input-group">
             
             <asp:Button ID="btnSubmit" Style="display: none;" runat="server" OnClick="btnSumbit_Click" />
             <button id="btnCreate" class="btn btn-default" onclick="validateCreateTopic(); return false;"><i class="fa fa-plus-square"></i>&nbsp;Create</button>
       

                </div>
        </div>
        
      
              </form>
    </div>

     <footer class="footer">
        <div class="container">
            <p class="m-b-0 text-muted">&copy; <%: DateTime.Now.Year %> - SmartSet</p>
        </div>
    </footer>
    
</body>
