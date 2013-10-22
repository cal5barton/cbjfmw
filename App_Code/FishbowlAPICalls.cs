﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;

/// <summary>
/// Contains the API calls to send and receive data to Fishbowl Server application.
/// </summary>

public class FishbowlServer
{
    private string key { get; set; }
    private string loginCommand { get; set; }
    public string serverMessage { get; set; }


    public void Connect()
    {
        key = "";

        //XML Login String
        loginCommand = createLoginXML("admin", "admin");
        ConnectionObject connectionObject = new ConnectionObject();

        //Send Login Command once to get Fishbowl Server Application to recoginize connection attempt
        //or pull the key off the line if connection is already established
        try
        {
            key = pullKey(connectionObject.sendCommand(loginCommand));

            if (key == "null")
            {
                throw new System.ArgumentException("Please accept the connection under integrated applications on the Fishbowl Server application");
            }
        }
        catch (Exception ex)
        {
            serverMessage = ex.Message;
        }

    }
    


    //Login XML with encryption
    private String createLoginXML(string username, string password)
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
            while (reader.Read())
            {
                //if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("Key"))
                if (reader.Name.Equals("Key") && reader.Read())
                {
                    return reader.Value.ToString();
                }
            }
        }
        return key;
    }

}