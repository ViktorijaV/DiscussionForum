<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DiscussionForum.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        body{
             background-color: #e6e6e6;
              color: #003366;
        }


        .one{

            position: absolute;
            top: 582px;
            left: 580px;
            font-size: 35px;
            background-color: #e6e6e6;
          
        }

        .two{
            position: absolute;
            top: 1472px;
            left: 485px;
            font-size: 35px;
            color: #003366;
            background-color: #e6e6e6;
        }

        .three{
            position: absolute;
            top: 2247px;
             left: 485px;
            font-size: 35px;
            color: #003366;
            background-color: #e6e6e6;
        }

        .listItem{

            font-size: 25px;
            margin: 10px;
            border: 2px solid #003366;
            width: 900px;
            left: 320px;
            margin-left: 8%;
           
            height: 635px;
            background-color: white;
            align-content: center;
           
        }

        .welcome{
          position: absolute;
          left: 320px;
          font-size:50px;
          top: 260px;
        }
        
        .item{
             
              background-color: #e6e6e6;
              color: #003366;
              text-align: center;
              padding-top: 10%;
              padding-bottom: 10%;
              border: 2px solid #003366;
              margin: 3%;
              margin-left: 20%;
              width: 150px;
              height: 100px;
              font-size: 14pt;

        }

        tr{

            border-color: white;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  
      <br />
      <br />
      <br />
      <br />
      <asp:Label ID="Label2" runat="server" Text="All important welcome message" CssClass="welcome"></asp:Label>
      <br />
      <br />
      <br />
      <br />
  
      <asp:Label ID="Label1" runat="server" Text="| Categories |" CssClass="one"></asp:Label>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    <asp:Panel ID="Panel3" runat="server" Height="750px" CssClass="listItem">
     
         <br />
        <br />

      <table align="center" class="table">
          <tr>
              <td> 
                  <asp:Panel ID="Panel5" runat="server" CssClass="item" >
                      <asp:Label ID="Label3" runat="server" Text="Calculus"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel8" runat="server" CssClass="item" >
                      <asp:Label ID="Label6" runat="server" Text="Programming"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel11" runat="server" CssClass="item" >
                      <asp:Label ID="Label8" runat="server" Text="Discrete  Mathematics"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td> 
                  <asp:Panel ID="Panel6" runat="server" CssClass="item" >
                      <asp:Label ID="Label7" runat="server" Text="Web Design"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel9" runat="server" CssClass="item" >
                      <asp:Label ID="Label9" runat="server" Text="Web Development"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel10" runat="server" CssClass="item" >
                      <asp:Label ID="Label11" runat="server" Text="Computer Networking"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td> 
                  <asp:Panel ID="Panel4" runat="server" CssClass="item">
                      <asp:Label ID="Label13" runat="server" Text="Probability and Statistics"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel12" runat="server" CssClass="item">
                      <asp:Label ID="Label12" runat="server" Text="Algorithms and Data Structures"></asp:Label>
                  </asp:Panel>
              </td>
              <td>

                  <asp:Panel ID="Panel13" runat="server" CssClass="item">
                      <asp:Label ID="Label14" runat="server" Text="Operating Systems"></asp:Label>
                  </asp:Panel>

              </td>
          </tr>
          <tr>
              <td>
                  <asp:Panel ID="Panel7" runat="server" CssClass="item" > Shell</asp:Panel>
                     
              </td>
              <td>
                  <asp:Panel ID="Panel14" runat="server" CssClass="item">
                      <asp:Label ID="Label15" runat="server" Text="Software Engineering"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel15" runat="server" CssClass="item">
                      <asp:Label ID="Label16" runat="server" Text="Artificial Intelligence"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Panel ID="Panel16" runat="server" CssClass="item"> DataBases </asp:Panel>
              </td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
          </tr>
      </table>
        
       </asp:Panel>
      
     
     <asp:Label ID="Label4" runat="server" Text="| Most popular categories |" CssClass="two">


     </asp:Label>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    <asp:Panel ID="Panel2" runat="server" CssClass="listItem">

        <br />
      <br />

        <table align="center" class="table">
          <tr>
              <td> 
                  <asp:Panel ID="Panel17" runat="server" CssClass="item" >
                      <asp:Label ID="Label10" runat="server" Text="Calculus"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel18" runat="server" CssClass="item" >
                      <asp:Label ID="Label17" runat="server" Text="Programming"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel19" runat="server" CssClass="item" >
                      <asp:Label ID="Label18" runat="server" Text="Discrete  Mathematics"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td> 
                  <asp:Panel ID="Panel20" runat="server" CssClass="item" >
                      <asp:Label ID="Label19" runat="server" Text="Web Design"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel21" runat="server" CssClass="item" >
                      <asp:Label ID="Label20" runat="server" Text="Web Development"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel22" runat="server" CssClass="item" >
                      <asp:Label ID="Label21" runat="server" Text="Computer Networking"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td> 
                  <asp:Panel ID="Panel23" runat="server" CssClass="item">
                      <asp:Label ID="Label22" runat="server" Text="Probability and Statistics"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel24" runat="server" CssClass="item">
                      <asp:Label ID="Label23" runat="server" Text="Algorithms and Data Structures"></asp:Label>
                  </asp:Panel>
              </td>
              <td>

                  <asp:Panel ID="Panel25" runat="server" CssClass="item">
                      <asp:Label ID="Label24" runat="server" Text="Operating Systems"></asp:Label>
                  </asp:Panel>

              </td>
          </tr>
          <tr>
              <td>
                  <asp:Panel ID="Panel26" runat="server" CssClass="item" > Shell</asp:Panel>
                     
              </td>
              <td>
                  <asp:Panel ID="Panel27" runat="server" CssClass="item">
                      <asp:Label ID="Label25" runat="server" Text="Software Engineering"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel28" runat="server" CssClass="item">
                      <asp:Label ID="Label26" runat="server" Text="Artificial Intelligence"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
         
      </table>


    </asp:Panel>
     <asp:Label ID="Label5" runat="server" Text="| Most recent categories |" CssClass="three"></asp:Label>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <asp:Panel ID="Panel1" runat="server" CssClass="listItem">

          
        <br />
      <br />

        <table align="center" class="table">
          <tr>
              <td> 
                  <asp:Panel ID="Panel29" runat="server" CssClass="item" >
                      <asp:Label ID="Label27" runat="server" Text="Calculus"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel30" runat="server" CssClass="item" >
                      <asp:Label ID="Label28" runat="server" Text="Programming"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel31" runat="server" CssClass="item" >
                      <asp:Label ID="Label29" runat="server" Text="Discrete  Mathematics"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td> 
                  <asp:Panel ID="Panel32" runat="server" CssClass="item" >
                      <asp:Label ID="Label30" runat="server" Text="Web Design"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel33" runat="server" CssClass="item" >
                      <asp:Label ID="Label31" runat="server" Text="Web Development"></asp:Label>
                  </asp:Panel>
              </td>
              <td> 
                  <asp:Panel ID="Panel34" runat="server" CssClass="item" >
                      <asp:Label ID="Label32" runat="server" Text="Computer Networking"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
          <tr>
              <td> 
                  <asp:Panel ID="Panel35" runat="server" CssClass="item">
                      <asp:Label ID="Label33" runat="server" Text="Probability and Statistics"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel36" runat="server" CssClass="item">
                      <asp:Label ID="Label34" runat="server" Text="Algorithms and Data Structures"></asp:Label>
                  </asp:Panel>
              </td>
              <td>

                  <asp:Panel ID="Panel37" runat="server" CssClass="item">
                      <asp:Label ID="Label35" runat="server" Text="Operating Systems"></asp:Label>
                  </asp:Panel>

              </td>
          </tr>
          <tr>
              <td>
                  <asp:Panel ID="Panel38" runat="server" CssClass="item" > Shell</asp:Panel>
                     
              </td>
              <td>
                  <asp:Panel ID="Panel39" runat="server" CssClass="item">
                      <asp:Label ID="Label36" runat="server" Text="Software Engineering"></asp:Label>
                  </asp:Panel>
              </td>
              <td>
                  <asp:Panel ID="Panel40" runat="server" CssClass="item">
                      <asp:Label ID="Label37" runat="server" Text="Artificial Intelligence"></asp:Label>
                  </asp:Panel>
              </td>
          </tr>
         
      </table>

      </asp:Panel>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    ---------------------------------------------Testing part---------------------------------------------<br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    Registered users (format: Fullname - Username):<br />
    <asp:ListBox ID="lstUsers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
    <br />
    Show password of the selected user:
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
    <br />
    Username:
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    &nbsp;Fullname:&nbsp;
            <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert User" />

    <br />
    <br />
    ---------------------------------------------------------------------------------------------------------------
        

</asp:Content>
