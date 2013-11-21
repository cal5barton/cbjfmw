<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <a href="CustomerDetails.aspx" style="float:right;" data-transition="fade" data-role="button" data-icon="plus" data-iconpos="notext" ></a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
        function setHidden(passedName) {
            selName = document.getElementById("HiddenSelection");
            selName.value = passedName.value;
        }
    </script>
    <form action="CustomerDetails.aspx" method="post" data-transition="pop">
        <div data-roll="fieldcontain" runat="server">
            No Customers to view...
        </div>
        <input type="submit" value="Person One" onclick="setHidden(this)">
        <input type="hidden" id="HiddenSelection" name="HiddenSelection" value="" />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomNavContent" Runat="Server">
</asp:Content>

