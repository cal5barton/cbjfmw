using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : System.Web.UI.Page
{
<<<<<<< HEAD
    
=======
    FishbowlServer fbServer = new FishbowlServer();
>>>>>>> a21185eb23cfc9647a0f76c1db83a1a47b6bd148

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FishbowlServer"] != null)
        {
            Session.Abandon();
        }
        else
        {
            FishbowlServer fbServer = new FishbowlServer();

            if (Request.Form["username"] != null)
            {
                fbServer.username = Request.Form["username"];

                if (Request.Form["password"] != null)
                {
                    fbServer.password = Request.Form["password"];

                    if (Request.Form["serverIP"] != null)
                    {
                        fbServer.serverIP = Request.Form["serverIP"];

                        if (Request.Form["serverPort"] != null)
                        {
                            fbServer.serverPort = Convert.ToInt32(Request.Form["serverPort"]);
                            fbServer.SendRequest("login");

<<<<<<< HEAD
                            Session["FishbowlServer"] = fbServer;
                            Response.Redirect("~/Customer.aspx");
                        }
=======
        if (Request.Form["username"] != null)
        {
            string username = Request.Form["username"];

            if (Request.Form["password"] != null)
            {
                string password = Request.Form["password"];

                if (Request.Form["serverIP"] != null)
                {
                    string serverIP = Request.Form["serverIP"];

                    if (Request.Form["serverPort"] != null)
                    {
                        int serverPort = Convert.ToInt32(Request.Form["serverPort"]);

                        fbServer.Connect(serverIP, serverPort, username, password);
                        Session["key"] = fbServer.key;
                        Response.Redirect("~/Customer.aspx");
>>>>>>> a21185eb23cfc9647a0f76c1db83a1a47b6bd148
                    }
                }
            }
        }
    }
}