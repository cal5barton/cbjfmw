using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

/// <summary>
/// Responsible for sending and receiving XML to Fishbowl Server
/// </summary>
public class FishbowlServer1
{
    public string serverMessage { get; set; }
    public string userToken { get; set; }
    public string serverIP { get; set; }
    public int serverPort { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public bool encrypted { get; set; }
    

    //public ConnectionObject Initilize(string serverIP, int serverPort)
    //{
    //    ConnectionObject connectionObj = new ConnectionObject(serverIP, serverPort);
    //    return connectionObj;
    //}

    public void SendRequest(string request)
    {
        string key = "";
        string loginCommand = "";

        //XML Login String with encryption
        if (encrypted == true)
        {
            loginCommand = createLoginXML(username, password);
        }
        else
        {
            userToken = PasswordEncryption(password);
            loginCommand = createLoginXML(username, userToken);
        }

        ConnectionObject connectionObject = new ConnectionObject(serverIP, serverPort);

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

            key = pullKey(connectionObject.sendCommand(loginCommand));

        }

    }

    //Login XML with encryption
    private static String createLoginXML(string username, string encryptedPassword)
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
        //Encrypted Password
        buffer.Append(encryptedPassword);
        buffer.Append("</UserPassword></LoginRq></FbiMsgsRq></FbiXml>");

        return buffer.ToString();
    }

    //Encrypt Password
    public String PasswordEncryption(string password)
    {
        string result = EncryptPassword(password);
        return result;
    }

    //Encryption Method
    private String EncryptPassword(string password)
    {
        MD5 md5 = MD5CryptoServiceProvider.Create();
        byte[] encoded = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
        string encrypted = Convert.ToBase64String(encoded, 0, 16);

        return encrypted;
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
}