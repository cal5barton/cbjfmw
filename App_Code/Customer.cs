using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Customer
/// </summary>
public class CustomerModule
{
    FishbowlServer FBserver = new FishbowlServer();

    public Customer getCustomer(string key, string customerName)
    {
        Customer customerObj = new Customer();
        string response = FBserver.CustomerGet(key, customerName);

        //Read xml response
        XmlReader reader = XmlReader.Create(response);

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                reader.ReadToFollowing("CustomerID");
                customerObj.CustomerID = reader.ReadElementContentAsInt();
            }
        }

        return customerObj;
    }

    public List<String> getCustomerList(string key)
    {
        List<String> allCustomers = new List<string>();
        string response = FBserver.CustomerNameList(key);

        //Read xml response
        XmlReader reader = XmlReader.Create(response);

        while (reader.Read())
        {
            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name"))
            {
                allCustomers.Add(reader.Value.ToString());
            }
        }

        return allCustomers;
    }
}