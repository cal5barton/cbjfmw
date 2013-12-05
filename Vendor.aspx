<%@ Page Title="Vendor" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" Inherits="Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <a href="VendorDetails.aspx" style="float:right;" data-transition="fade" data-role="button" data-icon="plus" data-iconpos="notext" ></a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
        function setHidden(passedName) {
            selName = document.getElementById("HiddenSelection");
            selName.value = passedName.value;
        }
    </script>
    <form action="VendorDetails.aspx" method="post" data-transition="pop">
        <div id="nameList" data-roll="controlgroup" runat="server">
            No Vendors to view...
        </div>
        <input type="hidden" id="HiddenSelection" name="HiddenSelection" value="" />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomNavContent" Runat="Server">
</asp:Content>

