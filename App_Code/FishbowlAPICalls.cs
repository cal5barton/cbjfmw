using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Xml.Linq;

/// <summary>
/// Contains the API calls to send and receive data to Fishbowl Server application.
/// </summary>

public class FishbowlServer
{
    public string key { get; set; }
    public string serverMessage { get; set; }
    public string loginCommand { get; set; }
    private string serverIP { get; set; }
    private int serverPort { get; set; }
    private string username { get; set; }
    private string password { get; set; }    
    ConnectionObject connectionObj = new ConnectionObject("localhost", 28192);

    //Login Method
    public String Login(string serverIP, int serverPort, string username, string password)
    {
        //XML Login String
        loginCommand = createLoginXML(username, password);

        //Send Login Command once to get Fishbowl Server Application to recoginize connection attempt
        //or pull the key off the line if connection is already established
        try
        {
            key = pullKey(connectionObj.sendCommand(loginCommand));

            if (key == "null")
            {
                throw new System.ArgumentException("Please accept the connection under integrated applications on the Fishbowl Server application");
            }

        }
        catch (Exception ex)
        {
            serverMessage = ex.Message;

            key = pullKey(connectionObj.sendCommand(loginCommand));

        }

        return key;
    }
    
    //Send Request
    public String SendRequest(string request)
    {
        string response = "<root></root>";
        response = connectionObj.sendCommand(request);
        return response;
    }

    // The following generates different querries 
    private static string listCustomerName(string key)
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><CustomerNameListRq></CustomerNameListRq></FbiMsgsRq></FbiXml>";
    }

    //Login XML with encryption
    private static String createLoginXML(string username, string password)
    {
        System.Text.StringBuilder buffer = new System.Text.StringBuilder("<FbiXml><Ticket/><FbiMsgsRq><LoginRq><IAID>");
        buffer.Append("10271731");
        buffer.Append("</IAID><IAName>");
        buffer.Append("Fish Brains Mobile");
        buffer.Append("</IAName><IADescription>");
        buffer.Append("Mobile Application For Fishbowl Inventory");
        buffer.Append("</IADescription><UserName>");
        buffer.Append(username);
        buffer.Append("</UserName><UserPassword>");

        MD5 md5 = MD5CryptoServiceProvider.Create();
        byte[] encoded = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
        string encrypted = Convert.ToBase64String(encoded, 0, 16);
        buffer.Append(encrypted);
        buffer.Append("</UserPassword></LoginRq></FbiMsgsRq></FbiXml>");

        return buffer.ToString();
    }

    //Pull the session Key out of the server response string
    private static String pullKey(String connection)
    {
        String key = "";
        using (XmlReader reader = XmlReader.Create(new StringReader(connection)))
        {
            if (connection != null)
            {
                while (reader.Read())
                {
                    //if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("Key"))
                    if (reader.Name.Equals("Key") && reader.Read())
                    {
                        return reader.Value.ToString();
                    }
                }
            }
        }
        return key;
    }

    //Gets List of Customer Name strings
    public List<String> getCustomerList()
    {
        List<String> allCustomers = new List<string>();
        string request = CustomerNameList();
        string response = "";
       
        response = SendRequest(request);

        XDocument doc = XDocument.Parse(response);
        var ns = doc.Root.GetDefaultNamespace();
        var objects = doc.Descendants(ns + "Name");
        allCustomers = doc.Root.Descendants("Name")
                .Select(element => element.Value).ToList();


        //Read xml response
        //using (XmlReader reader = XmlReader.Create(new StringReader(response)))
        //{

        //    if (response != null)
        //    {
        //        while (reader.Read())
        //        {
        //            if (reader.Name.Equals("Name") && reader.Read())
        //            {
                        
        //                allCustomers.Add(reader.Value.ToString());
                        
        //            }
        //        }
        //    }
        //}
        allCustomers.Sort();
        return allCustomers;
    }

    //Gets Specific Customer
    public string getCustomer(string customer)
    {
        string request = CustomerGet(customer);
        string response = "";

        response = SendRequest(request);

        return response;
    }
    
    //Customer Name List Call -- Displays a list of all customers
    public string CustomerNameList()
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><CustomerNameListRq></CustomerNameListRq></FbiMsgsRq></FbiXml>";
    }

    //Customer Get -- gets specific customer
    public string CustomerGet(string customerName)
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><CustomerGetRq><Name>" + customerName + "</Name></CustomerGetRq></FbiMsgsRq></FbiXml>";
    }

    //Customer Save -- saves or adds a customer
    public string CustomerSave(string key, Customer customerObj)
    {
        StringBuilder xml = new StringBuilder();
        xml.Append("<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq>");
        xml.Append("<CustomerSaveRq><Customer><Status>" + customerObj.Status + "</Status>");
        xml.Append("<DefPaymentTerms>" + customerObj.DefPaymentTerms + "</DefPaymentTerms>");
        xml.Append("<DefShipTerms>" + customerObj.DefShipTerms + "</DefShipTerms>");
        xml.Append("<TaxRate>" + customerObj.TaxRate + "</TaxRate>");
        xml.Append("<Name>" + customerObj.Name + "</Name>");
        xml.Append("<CreditLimit>" + customerObj.CreditLimit + "</CreditLimit>");
        xml.Append("<TaxExempt>" + customerObj.TaxExempt + "</TaxExempt>");
        xml.Append("<TaxExemptNumber>" + customerObj.TaxExemptNumber + "</TaxExemptNumber>");
        xml.Append("<Note>" + customerObj.Note + "</Note>");
        xml.Append("<ActiveFlag>" + customerObj.ActiveFlag + "</ActiveFlag>");
        xml.Append("<DefaultSalesman>" + customerObj.DefSalesman + "</DefaultSalesman>");
        xml.Append("<DefaultCarrier>" + customerObj.DefCarrier + "</DefaultCarrier>");
        xml.Append("<JobDepth>" + customerObj.JobDepth + "</JobDepth>");
        //Add all addresses
        xml.Append("<Addresses>");

        foreach (var address in customerObj.customerAddresses)
        {
            xml.Append("<Address><Name>" + address.Name + "</Name>"
            + "<Attn>" + address.Attn + "</Attn>"
            + "<Street>" + address.Street + "</Street>"
            + "<City>" + address.City + "</City>"
            + "<Zip>" + address.Zip + "</Zip>"
            + "<Default>" + address.Default + "</Default>"
            + "<Residential>" + address.Residential + "</Residential>"
            + "<Type>" + address.Type + "</Type>"
            + "<State><Name>" + address.addressState.Name + "</Name><Code>" + address.addressState.Code + "</Code><CountryID>" + address.addressState.CountryID + "</CountryID></State><Country><Name>" + address.addressCountry.Name + "</Name><Code>" + address.addressCountry.Code + "</Code></Country>"
            + "<AddressInformationList><AddressInformation><Name>" + address.addressInformation.Name + "</Name><Data>" + address.addressInformation.Data + "</Data><Default>" + address.addressInformation.Default + "</Default><Type>" + address.addressInformation.Type + "</Type></AddressInformation></AddressInformationList></Address>");
        }

        xml.Append("</Addresses>");

        //Add custom fields
        xml.Append("<CustomField><Type>" + customerObj.customerCF.Type + "</Type><Name>" + customerObj.customerCF.Name + "</Name><Info>" + customerObj.customerCF.Info + "</Info></CustomField>");
        xml.Append("</Customer></CustomerSaveRq></FbiMsgsRq></FbiXml>");

        return xml.ToString();
    }
    
    //Vendor Name List Call
    public  string VendorNameList(string key)
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><VendorNameListRq></VendorNameListRq></FbiMsgsRq></FbiXml>";
    }

    //Vendor Get -- gets specific vendor
    public  string VendorGet(string key, string vendorName)
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><CustomerGetRq>" + vendorName + "</CustomerGetRq></FbiMsgsRq></FbiXml>";
    }


    //Vendor Save -- saves or creates vendor
    public  string VendorSave(string key, Vendor vendorObj)
    {
        StringBuilder xml = new StringBuilder();
        xml.Append("<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq>");
        xml.Append("<CustomerSaveRq><Customer><Status>" + vendorObj.Status + "</Status>");
        xml.Append("<DefPaymentTerms>" + vendorObj.DefPaymentTerms + "</DefPaymentTerms>");
        xml.Append("<DefShipTerms>" + vendorObj.DefShipTerms + "</DefShipTerms>");
        xml.Append("<TaxRate>" + vendorObj.TaxRate + "</TaxRate>");
        xml.Append("<Name>" + vendorObj.Name + "</Name>");
        xml.Append("<CreditLimit>" + vendorObj.CreditLimit + "</CreditLimit>");
        xml.Append("<Note>" + vendorObj.Note + "</Note>");
        xml.Append("<ActiveFlag>" + vendorObj.ActiveFlag + "</ActiveFlag>");
        //Add all addresses
        xml.Append("<Addresses>");

        foreach (var address in vendorObj.vendorAddresses)
        {
            xml.Append("<Address><Name>" + address.Name + "</Name>"
            + "<Attn>" + address.Attn + "</Attn>"
            + "<Street>" + address.Street + "</Street>"
            + "<City>" + address.City + "</City>"
            + "<Zip>" + address.Zip + "</Zip>"
            + "<Default>" + address.Default + "</Default>"
            + "<Residential>" + address.Residential + "</Residential>"
            + "<Type>" + address.Type + "</Type>"
            + "<State><Name>" + address.addressState.Name + "</Name><Code>" + address.addressState.Code + "</Code><CountryID>" + address.addressState.CountryID + "</CountryID></State><Country><Name>" + address.addressCountry.Name + "</Name><Code>" + address.addressCountry.Code + "</Code></Country>"
            + "<AddressInformationList><AddressInformation><Name>" + address.addressInformation.Name + "</Name><Data>" + address.addressInformation.Data + "</Data><Default>" + address.addressInformation.Default + "</Default><Type>" + address.addressInformation.Type + "</Type></AddressInformation></AddressInformationList></Address>");
        }

        xml.Append("</Addresses>");

        //Add custom fields
        xml.Append("<CustomField><Type>" + vendorObj.vendorCF.Type + "</Type><Name>" + vendorObj.vendorCF.Name + "</Name><Info>" + vendorObj.vendorCF.Info + "</Info></CustomField>");
        xml.Append("</Customer></CustomerSaveRq></FbiMsgsRq></FbiXml>");

        return xml.ToString();
    }



}