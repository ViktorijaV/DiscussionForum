<%@ Page Title="" Language="C#" MasterPageFile="~/Site/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TermsAndConditions.aspx.cs" Inherits="DiscussionForum.Site.TermsAndConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12" id="terms">
        <h3>Terms & Conditions </h3>
        <br />
        <br />
        <div class="paragraf">
            SmartSet is a forum designed for computer science students.
            <p>
                The following terms and conditions were put together to help users better understand how their use of this website will be governed. 
            </p>
            <p class="tekst">If you are not registered you can only view created topics and their comments.</p>
        </div>
        <br />
        <ul class="terms">
            <li>
                <h4>1.	User profile </h4>
                <p class="tekst">The registration on SmartSet is free.  By registering on SmartSet the user can: </p>
                <ul>
                    <li>Create a topic, ask questions </li>
                    <li>Comment on their own or someone else’s topic </li>
                    <li>Like a topic or a comment </li>
                    <li>Report a topic or a comment</li>
                    <li>Follow a topic or a category</li>
                    <li>Suggest creating new category </li>
                    <li>View other’s profiles.</li>
                </ul>
            </li>

            <li>
                <br />
                <h4>2.	User’s privacy</h4>
                <ul>
                    <li>SmartSet undertakes to respect the user’s privacy and anonymity of their users and guarantees than will not share user’s information to unregistered users. </li>
                    <li>In order to protect the user’s privacy, SmartSet will not display the user’s email. </li>
                </ul>
            </li>


            <li>
                <br />
                <h4>3.	Blocking users</h4>
                <p class="tekst">SmartSet’s admins can block users.  </p>
                <p class="tekst">sers will be blocked for one or more of the following reasons: </p>
                <ul>
                    <li>Publishing inappropriate content. (Offensive, no copyright, false, libelous, hateful, etc.)    </li>
                    <li>Offending other users    </li>
                    <li>Sharing the personal information of other users    </li>
                    <li>Publishing spam content.     </li>
                </ul>
                The blocked user will no longer be able to login with current email, or create a new account with the existing email.
            </li>


            <li>
                <br />
                <h4>4.	Creating a topic</h4>
                <p class="tekst">Creating a topic is allowed only for registered users on SmartSet. </p>
                <p class="tekst">Unregistered users can only view already created topics. </p>
                <p class="tekst">When a user creates a topic, it is preferable that:</p>
                <ul>
                    <li>-      The same or similar topic is not already existing</li>
                    <li>-       The topic belongs to the corresponding category</li>
                    <li>-	The topic name is descriptively written</li>
                    <li>-	The description covers in detail the problem. </li>
                </ul>
                <p class="tekst">
                    If the content of the topic is non-compliance with the above recommendations the topic will be removed by the admins.
                </p>
            </li>


            <li>
                <br />
                <h4>5.	Commenting on a topic</h4>
                <p class="tekst">Commenting on a topic is allowed only for registered users on SmartSet.</p>
                <p class="tekst">Unregistered users can only view already existing comments.</p>
                <p class="tekst">When a user leaves a comment, it is preferable that:</p>
                <ul>
                    <li>-	The comment is related in content to the topic </li>
                    <li>-	It doesn’t insult other users</li>
                    <li>-	Does not share someone else's information</li>
                    <li>-	Does not share copy-right information </li>
                    <li>-	Does not publish spam content</li>
                </ul>
                <p class="tekst">If the content of the topic is non-compliance with the above recommendations the topic will be removed by the admins. </p>
            </li>

        </ul>

    </div>
</asp:Content>
