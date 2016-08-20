<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DiscussionForum.Site.Home" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartSet-Home</title>

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
         <form id="form1" runat="server">
            
             <div class="row">
                 <div class="col-xs-offset-1 col-xs-10">
                        <div id="welcome" >All important welcome message</div>
                 </div>
             </div>

             <div class="row">
                 <div class="col-xs-offset-2 col-xs-10 title">
                        <div class="title">Categories</div>
                 </div>
             </div>

             <div class="row separate">
                     <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"><a class="categories">Programming</a></div>
                         </div>
                      
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"><a class="categories">Discrete Mathematics</a></div>
                         </div>
                         
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"><a class="categories">Calculus</a></div>
                         </div>
                         
                    </div>
                </div>

              <div class="row separate">
                     <div class="col-xs-offset-1 col-xs-2">
                           <div class="panel panel-default">
                             <div class="panel-body"> <a class="categories">Web Design</a></div>
                         </div>
                        
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"> <a class="categories">Web Development</a></div>
                         </div>
                        
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"> <a class="categories">Computer Networking</a></div>
                         </div>
                        
                    </div>
                </div>

              <div class="row separate">
                     <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"> <a class="categories">Probability and Statistics</a></div>
                         </div>
                         
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"> <a class="categories">Algorithms and Data Structures</a></div>
                         </div>
                        
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                         <div class="panel panel-default">
                             <div class="panel-body">  <a class="categories">Operating Systems</a></div>
                         </div>
                       
                    </div>
                </div>

              <div class="row separate">
                     <div class="col-xs-offset-1 col-xs-2">
                           <div class="panel panel-default">
                             <div class="panel-body">  <a class="categories">Artificial Intelligence</a></div>
                         </div>
                       
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"><a class="categories">Software Engineering</a></div>
                         </div>
                         
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body"><a class="categories">DataBases</a></div>
                         </div>
                         
                    </div>
                </div>

              <div class="row separate">
                     <div class="col-xs-offset-1 col-xs-2">
                          <div class="panel panel-default">
                             <div class="panel-body">  <a class="categories">Shell</a></div>
                         </div> 
                       
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                         
                         
                    </div>

                    <div class="col-xs-offset-1 col-xs-2">
                         
                        
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