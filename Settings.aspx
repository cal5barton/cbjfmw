<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    
    <div id="detailsTab">
        <div data-role="fieldcontain">
            <label for="username">Username</label>
            <input type="text" name="username" id="username" placeholder="Username" />
        </div>
        <div data-role="fieldcontain">
            <label for="password">Password</label>
            <input type="text" name="password" id="password" placeholder="Password" />
        </div>
        <div data-role="fieldcontain">
            <label for="serverIP">Server IP</label>
            <input type="text" name="serverIP" id="serverIP" placeholder="Server IP" />
        </div>
        <div data-role="fieldcontain">
            <label for="serverPort">Server Port</label>
            <input type="text" name="serverPort" id="serverPort" value="28192" />
        </div>
        
            
            
        
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomNavContent" Runat="Server">
    <div data-role="navbar" data-position="fixed">
        <ul>
            <li><a data-role="tab">Login</a></li>
        </ul>
    </div>
</asp:Content>

