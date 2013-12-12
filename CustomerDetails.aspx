<%@ Page Title="New Customer" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetailsPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script>
        function select_address() {
            document.getElementById('detailsTab').hidden = true;
            document.getElementById('addressesTab').hidden = false;
        }
        function select_details() {
            document.getElementById('addressesTab').hidden = true;
            document.getElementById('detailsTab').hidden = false;
        }
        function init_function() {
            $('preferred').replaceWith(
                "<option selected='selected' id='preferred'>Preferred</option>"
                );
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    
    <!-- Details Tab -->
    <div id="detailsTab" onload="init_function()">
        <div data-role="fieldcontain">
            <label for="creditLimit">Credit Limit</label>
            <input type="text" name="creditLimit" id="creditLimit" placeholder="Credit Limit" value="<%= customer.CreditLimit %>" />
        </div>
        <div data-role="fieldcontain">
            <label for="status">Status</label>
            <input type="text" name="status" id="status" placeholder="Status" value="<%= customer.Status %>" />
            <%--<select name="status" id="status" >
                <option></option>
                <option value="Normal">Normal</option>
                <option>Hold Sales</option>
                <option>Hold Shipment</option>
                <option>Hold All</option>
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="terms">Terms</label>
            <input type="text" name="terms" id="terms" placeholder="Terms" value="<%= customer.DefPaymentTerms %>" />
            <%--<select name="terms" id="terms" >
                <option></option>
                <option>CCD</option>
                <option>CIA</option>
                <option>COD</option>
                <option>NET 30</option>
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="carrier">Carrier</label>
            <input type="text" name="carrier" id="carrier" placeholder="Carrier" value="<%= customer.DefCarrier %>" />
            <%--<select name="carrier" id="carrier" >
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="shipService">Shipping Service</label>
            <input type="text" name="shipService" id="shipService" placeholder="Shipping Service" value="<%= customer.DefShipService %>" />
            <%--<select name="shippingService" id="shippingService" >
                <option>Next Day Air</option>
                <option>2nd Day Air</option>
                <option>Ground</option>
                <option>3 Day Select</option>
                <option>Next Day Air Saver</option>
                <option>Next Day Air Early A.M.</option>
                <option>2nd Day Air A.M.</option>
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="shipTerms">Ship Terms</label>
            <input type="text" name="shipTerms" id="shipTerms" placeholder="Ship Terms" value="<%= customer.DefShipTerms %>" />
            <%--<select name="shipTerms" id="shipTerms" >
                <option>Prepaid & Billed</option>
                <option>Prepaid</option>
                <option>Freight Collect</option>
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="salesperson">Salesperson</label>
            <input type="text" name="salesperson" id="salesperson" placeholder="Salseperson" value="<%= customer.DefSalesman %>" />
            <%--<select name="salesperson" id="salesperson" >
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="accountNumber">Account Number</label>
            <input type="text" name="accountNumber" id="accountNumber"" value="<%= customer.Number %>" placeholder="Account Number" />
        </div>
        <div data-role="fieldcontain">
            <label for="taxRate">Tax Rate</label>
            <input type="text" name="taxRate" id="taxRate" placeholder="Tax Rate" value="<%= customer.TaxRate %>" />
            <%--<select name="taxRate" id="taxRate" >
                <option></option>
                <option>None</option>
                <option>Utah</option>
            </select>--%>
        </div>
        <div data-role="fieldcontain">
            <label for="alertNotes">Alert Notes</label>
            <textarea name="alertNotes" id="alertNotes" aria-valuetext="<%= customer.Note %>" >
            </textarea>
        </div>
    </div>


    <!-- Address Tab -->
    <div id="addressesTab" hidden="hidden">
        <%--<div data-role="fieldcontain">
            <label for="addressName">Address Name</label>
            <select name="addressName" id="addressName" >
            </select>
        </div>--%>
        <div data-role="fieldcontain">
            <label for="attn">Attn</label>
            <input type="text" name="attn" id="attn"" value="<%= customer.customerAddresses.First().Attn %>" />
        </div>
        <div data-role="fieldcontain">
            <label for="street">Street</label>
            <input type="text" name="street" id="street" value="<%= customer.customerAddresses.First().Street %>" />
        </div>
        <div id="cityStateZip" data-role="fieldcontain">
            <label for="city">City/State/Zip</label>
            <input type="text" name="city" id="city" style="position:relative; display:inline-block; float:left;"" value="<%= customer.customerAddresses.First().City %>" />
            <input type="text" name="state" id="state" style="display:inline-block; float:left;" value="<%= customer.customerAddresses.First().addressState.Code %>" />
            <%--<select name="state" id="state" style="display:inline-block; float:left;" ></select>--%>
            <input type="text" name="zip" id="zip" style="display:inline-block; float:left; width:100px;" size="5" maxlength="5"" value="<%= customer.customerAddresses.First().Zip %>" />
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