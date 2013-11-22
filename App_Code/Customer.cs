//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Xml;

///// <summary>
///// Summary description for Customer
///// </summary>
//public class CustomerModule
//{
    
//    //FishbowlServer FBserver = new FishbowlServer();

//    ////Get specific Customer Object
//    //public Customer getCustomer(string key, string customerName)
//    //{
//    //    Customer customerObj = new Customer();
//    //    string response = FBserver.CustomerGet(key, customerName);

//    //    //Read xml response
//    //    XmlReader reader = XmlReader.Create(response);

//    //    while (reader.Read())
//    //    {
//    //        if (reader.NodeType == XmlNodeType.Element)
//    //        {
//    //            if (reader.Name == "CustomerID")
//    //            {
//    //                customerObj.CustomerID = reader.ReadElementContentAsInt();
//    //            }
//    //            else if (reader.Name == "AccountID")
//    //            {
//    //                customerObj.AccountID = reader.ReadElementContentAsInt();
//    //            }
//    //            else if (reader.Name == "Status")
//    //            {
//    //                customerObj.Status = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "DefPaymentTerms")
//    //            {
//    //                customerObj.DefPaymentTerms = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "DefShipTerms")
//    //            {
//    //                customerObj.DefShipTerms = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "TaxRate")
//    //            {
//    //                customerObj.TaxRate = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "Name")
//    //            {
//    //                customerObj.Name = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "Number")
//    //            {
//    //                customerObj.Number = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "DateCreated")
//    //            {
//    //                customerObj.DateCreated = reader.ReadElementContentAsDateTime();
//    //            }
//    //            else if (reader.Name == "DateLastModified")
//    //            {
//    //                customerObj.DateLastModified = reader.ReadElementContentAsDateTime();
//    //            }
//    //            else if (reader.Name == "LastChangedUser")
//    //            {
//    //                customerObj.LastChangedUser = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "CreditLimit")
//    //            {
//    //                customerObj.CreditLimit = reader.ReadElementContentAsDouble();
//    //            }
//    //            else if (reader.Name == "TaxExempt")
//    //            {
//    //                customerObj.TaxExempt = reader.ReadElementContentAsBoolean();
//    //            }
//    //            else if (reader.Name == "TaxExemptNumber")
//    //            {
//    //                customerObj.TaxExemptNumber = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "Note")
//    //            {
//    //                customerObj.Note = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "ActiveFlag")
//    //            {
//    //                customerObj.ActiveFlag = reader.ReadElementContentAsBoolean();
//    //            }
//    //            else if (reader.Name == "AccountingID")
//    //            {
//    //                customerObj.AccountingID = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "CurrencyName")
//    //            {
//    //                customerObj.CurrencyName = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "CurrencyRate")
//    //            {
//    //                customerObj.CurrencyRate = reader.ReadElementContentAsDouble();
//    //            }
//    //            else if (reader.Name == "DefaultSalesman")
//    //            {
//    //                customerObj.DefSalesman = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "DefaultCarrier")
//    //            {
//    //                customerObj.DefCarrier = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "DefaultShipService")
//    //            {
//    //                customerObj.DefShipService = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "JobDepth")
//    //            {
//    //                customerObj.JobDepth = reader.ReadElementContentAsInt();
//    //            }
//    //            else if (reader.Name == "ParentID")
//    //            {
//    //                customerObj.ParentID = reader.ReadElementContentAsInt();
//    //            }
//    //            else if (reader.Name == "PipelineAccount")
//    //            {
//    //                customerObj.PipelineAccount = reader.ReadElementContentAsInt();
//    //            }
//    //            else if (reader.Name == "URL")
//    //            {
//    //                customerObj.URL = reader.ReadElementContentAsString();
//    //            }
//    //            else if (reader.Name == "Addresses")
//    //            {

//    //            }
//    //            else if (reader.Name == "CustomFields")
//    //            {

//    //            }
//    //        }
//    //    }

//    //    return customerObj;
//    //}

//    //Gets List of Customer Name strings
//    public List<String> getCustomerList(string serverIP, int serverPort, string key)
//    {
//        List<String> allCustomers = new List<string>();
//        string request = FBserver.CustomerNameList(key);
//        string response = "";
//        try
//        {
//            response = FBserver.SendRequest(serverIP, serverPort, request);
//        }
//        catch (Exception ex)
//        {

//        }
//        //Read xml response
//        XmlReader reader = XmlReader.Create(new StringReader(response));

//        while (reader.Read())
//        {
//            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name"))
//            {
//                allCustomers.Add(reader.Value.ToString());
//            }
//        }

//        return allCustomers;
//    }

//    //Save or Create Customer
//    public void saveCustomer(string key, Customer customerObj)
//    {
//        FBserver.CustomerSave(key, customerObj);
//    }
//}