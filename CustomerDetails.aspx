<%@ Page Title="New Customer" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="Customer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
        function select_address() {
            document.getElementById('detailsTab').hidden = true;
            document.getElementById('addressesTab').hidden = false;
        }
        function select_details() {
            document.getElementById('addressesTab').hidden = true;
            document.getElementById('detailsTab').hidden = false;
        }
    </script>
    
    <div id="detailsTab">
        <div data-role="fieldcontain">
            <label for="creditLimit">Credit Limit</label>
            <input type="text" name="creditLimit" id="creditLimit" placeholder="Credit Limit" />
        </div>
        <div data-role="fieldcontain">
            <label for="status">Status</label>
            <select name="status" id="status" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="terms">Terms</label>
            <select name="terms" id="terms" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="carrier">Carrier</label>
            <select name="carrier" id="carrier" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="shippingService">Shipping Service</label>
            <select name="shippingService" id="shippingService" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="shipTerms">Ship Terms</label>
            <select name="shipTerms" id="shipTerms" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="salesperson">Salesperson</label>
            <select name="salesperson" id="salesperson" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="accountNumber">Account Number</label>
            <input type="text" name="accountNumber" id="accountNumber" value="" placeholder="Account Number" />
        </div>
        <div data-role="fieldcontain">
            <label for="taxRate">Tax Rate</label>
            <select name="taxRate" id="taxRate" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="alertNotes">Alert Notes</label>
            <textarea name="alertNotes" id="alertNotes">
            </textarea>
        </div>
    </div>



    <div id="addressesTab" hidden="hidden">
        <div data-role="fieldcontain">
            <label for="name">Name</label>
            <input type="text" name="name" id="name" value="" />
        </div>
        <div data-role="fieldcontain">
            <label for="addressName">Address Name</label>
            <select name="addressName" id="addressName" >
            </select>
        </div>
        <div data-role="fieldcontain">
            <label for="attn">Attn</label>
            <input type="text" name="attn" id="attn" value="" />
        </div>
        <div id="cityStateZip" data-role="fieldcontain">
            <label for="city">City/State/Zip</label>
            <input type="text" name="city" id="city" style="position:relative; display:inline-block; float:left;" value="" />
            <select name="state" id="state" style="display:inline-block; float:left;" ></select>
            <input type="text" name="zip" id="zip" style="display:inline-block; float:left; width:100px;" size="5" maxlength="5" value="" />
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BottomNavContent" Runat="Server">
    <div data-role="navbar" data-position="fixed">
        <ul>
            <li><a data-role="tab" class="ui-btn-active" onclick="select_details()" >Details</a></li>
            <li><a data-role="tab" onclick="select_address()" >Addresses</a></li>
        </ul>
    </div>
</asp:Content>

