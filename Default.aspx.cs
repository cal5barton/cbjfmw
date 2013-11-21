using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : System.Web.UI.Page
{
    FishbowlServer fbServer = new FishbowlServer();

    protected void Page_Load(object sender, EventArgs e)
    {

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
                    }
                }
            }
        }
    }
}