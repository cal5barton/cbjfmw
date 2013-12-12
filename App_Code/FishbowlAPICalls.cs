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
    public String Login(string username, string password)
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
        
        allCustomers = doc.Root.Descendants("Name")
                .Select(element => element.Value).ToList();

        allCustomers.Sort();
        return allCustomers;
    }

    //Gets Specific Customer
    public Customer getCustomer(string customer)
    {
        Customer customerObj = new Customer();

        string request = CustomerGet(customer);
        string response = "";

        response = SendRequest(request);

        //Read xml response
                XmlReader reader = XmlReader.Create(new StringReader(response));

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "CustomerID")
                        {
                            customerObj.CustomerID = reader.ReadElementContentAsInt();
                        }
                        else if (reader.Name == "AccountID")
                        {
                            customerObj.AccountID = reader.ReadElementContentAsInt();
                        }
                        else if (reader.Name == "Status")
                        {
                            customerObj.Status = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "DefPaymentTerms")
                        {
                            customerObj.DefPaymentTerms = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "DefShipTerms")
                        {
                            customerObj.DefShipTerms = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "TaxRate")
                        {
                            customerObj.TaxRate = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "Name")
                        {
                            customerObj.Name = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "Number")
                        {
                            customerObj.Number = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "DateCreated")
                        {
                            customerObj.DateCreated = reader.ReadElementContentAsDateTime();
                        }
                        else if (reader.Name == "DateLastModified")
                        {
                            customerObj.DateLastModified = reader.ReadElementContentAsDateTime();
                        }
                        else if (reader.Name == "LastChangedUser")
                        {
                            customerObj.LastChangedUser = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "CreditLimit")
                        {
                            customerObj.CreditLimit = reader.ReadElementContentAsDouble();
                        }
                        else if (reader.Name == "TaxExempt")
                        {
                            customerObj.TaxExempt = reader.ReadElementContentAsBoolean();
                        }
                        else if (reader.Name == "TaxExemptNumber")
                        {
                            customerObj.TaxExemptNumber = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "Note")
                        {
                            customerObj.Note = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "ActiveFlag")
                        {
                            customerObj.ActiveFlag = reader.ReadElementContentAsBoolean();
                        }
                        else if (reader.Name == "AccountingID")
                        {
                            customerObj.AccountingID = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "CurrencyName")
                        {
                            customerObj.CurrencyName = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "CurrencyRate")
                        {
                            customerObj.CurrencyRate = reader.ReadElementContentAsDouble();
                        }
                        else if (reader.Name == "DefaultSalesman")
                        {
                            customerObj.DefSalesman = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "DefaultCarrier")
                        {
                            customerObj.DefCarrier = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "DefaultShipService")
                        {
                            customerObj.DefShipService = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "JobDepth")
                        {
                            customerObj.JobDepth = reader.ReadElementContentAsInt();
                        }
                        else if (reader.Name == "ParentID")
                        {
                            customerObj.ParentID = reader.ReadElementContentAsInt();
                        }
                        else if (reader.Name == "PipelineAccount")
                        {
                            customerObj.PipelineAccount = reader.ReadElementContentAsInt();
                        }
                        else if (reader.Name == "URL")
                        {
                            customerObj.URL = reader.ReadElementContentAsString();
                        }
                        else if (reader.Name == "Addresses")
                        {

                        }
                        else if (reader.Name == "CustomFields")
                        {

                        }
                    }
                }

                return customerObj;

        //XDocument doc = XDocument.Parse(response);

        ////Store elements in Customer Object
        ////if (doc.Root.Descendants("Name").Single().Value.ToString() != null && doc.Root.Descendants("Name").Single().Value.ToString() != "")
        ////{
        //string value = doc.Root.Descendants("TaxExempt").Single().Value;
        //    customerObj.CustomerID = Convert.ToInt32(doc.Root.Descendants("CustomerID").Single().Value);
        //    customerObj.AccountID = Convert.ToInt32(doc.Root.Descendants("AccountID").Single().Value);
        //    customerObj.Status = doc.Root.Descendants("Status").Single().Value;
        //    customerObj.DefPaymentTerms = doc.Root.Descendants("DefPaymentTerms").Single().Value;
        //    customerObj.DefShipTerms = doc.Root.Descendants("DefShipTerms").Single().Value;
        //    customerObj.TaxRate = doc.Root.Descendants("TaxRate").Single().Value;
        //    customerObj.Name = doc.Root.Descendants("Name").First().Value;
        //    customerObj.Number = doc.Root.Descendants("Number").Single().Value;
        //    customerObj.DateLastModified = Convert.ToDateTime(doc.Root.Descendants("DateLastModified").Single().Value);
        //    customerObj.LastChangedUser = doc.Root.Descendants("LastChangedUser").Single().Value;
        //    customerObj.CreditLimit = Convert.ToDouble(doc.Root.Descendants("CreditLimit").Single().Value);
        //    customerObj.TaxExempt = Convert.ToBoolean(doc.Root.Descendants("TaxExempt").Single().Value);
        //    customerObj.TaxExemptNumber = doc.Root.Descendants("TaxExemptNumber").Single().Value;
        //    customerObj.Note = doc.Root.Descendants("Note").Single().Value;
        //    customerObj.ActiveFlag = Convert.ToBoolean(doc.Root.Descendants("ActiveFlag").Single().Value);
        //    customerObj.AccountingID = doc.Root.Descendants("AccountingID").Single().Value;
        //    customerObj.CurrencyName = doc.Root.Descendants("CurrencyName").Single().Value;
        //    customerObj.CurrencyRate = Convert.ToDouble(doc.Root.Descendants("CurrencyRate").Single().Value);
        //    customerObj.DefSalesman = doc.Root.Descendants("DefaultSalesman").Single().Value;
        //    customerObj.DefCarrier = doc.Root.Descendants("DefaultCarrier").Single().Value;
        //    customerObj.DefShipService = doc.Root.Descendants("DefaultShipService").Single().Value;
        //    customerObj.JobDepth = Convert.ToInt32(doc.Root.Descendants("JobDepth").Single().Value);
        //    customerObj.ParentID = Convert.ToInt32(doc.Root.Descendants("ParentID").Single().Value);
        //    customerObj.PipelineAccount = Convert.ToInt32(doc.Root.Descendants("PipelineAccount").Single().Value);
        //    customerObj.URL = doc.Root.Descendants("URL").Single().Value;
        ////}


        //return customerObj;
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
    public  string VendorNameList()
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><VendorNameListRq></VendorNameListRq></FbiMsgsRq></FbiXml>";
    }

    //Gets List of Vendor Name strings
    public List<String> getVendorList()
    {
        List<String> allVendors = new List<string>();
        string request = VendorNameList();
        string response = "";

        response = SendRequest(request);

        XDocument doc = XDocument.Parse(response);

        allVendors = doc.Root.Descendants("Name")
                .Select(element => element.Value).ToList();

        allVendors.Sort();
        return allVendors;
    }

    //Vendor Get -- gets specific vendor
    public  string VendorGet(string key, string vendorName)
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><VendorGetRq>" + vendorName + "</VendorGetRq></FbiMsgsRq></FbiXml>";
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

    //Sales Rep List
    public string GetSalesRepList()
    {
        return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><ExecuteQueryRq><Query></Query></ExecuteQueryRq></FbiMsgsRq></FbiXml>";
    }
}