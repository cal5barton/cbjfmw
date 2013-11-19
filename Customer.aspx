<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <a href="CustomerDetails.aspx" style="float:right;" data-transition="fade" data-role="button" data-icon="plus" data-iconpos="notext" ></a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
        function setHidden(selName) {
            alert("called method");
            SelectedName.value = selName.value;
            alert(selName.value);
        }
    </script>
    <form action="CustomerDetails.aspx" data-transition="pop">
        <a data-role="button" id="FirstName" onclick="setHidden(this)">First Name</a>
        <a data-role="button" id="SecondName" onclick="setHidden(this)">Second Name</a>
        <a data-role="button" id="ThirdName" onclick="setHidden(this)">Third Name</a>
        <a data-role="button" id="FourthName" onclick="setHidden(this)">Fourth Name</a>
    </form>
    <input type="hidden" name="SelectedName" value="" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomNavContent" Runat="Server">
</asp:Content>

