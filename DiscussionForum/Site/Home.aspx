<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DiscussionForum.Site.Home" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-xs-4">
            <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-xs-4">
        </div>
        <div class="col-xs-8">
            <ul class="nav nav-pills">
                <li class="active"><a href="#">Latest</a></li>
                <li><a href="#">Top</a></li>
                <li><a href="#">Menu 2</a></li>
            </ul>
        </div>
    </div>

    <div class="row">
        <asp:Table ID="example" runat="server" class="display" cellspacing="0" width="100%">
            
        </asp:Table>
 
    </div>

    <script src="http://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            var table = document.getElementById("ContentPlaceHolder1_example");
            var header = table.createTHead();
            var row = header.insertRow(0);
            var cell = row.insertCell(0);
            cell.innerHTML = "<b>Name</b>";
            var cell = row.insertCell(0);
            cell.innerHTML = "<b>Category</b>";


            $("#ContentPlaceHolder1_example").DataTable();
        });
    </script>
</asp:Content>
