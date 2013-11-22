using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : System.Web.UI.Page
{
    

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

                            Session["FishbowlServer"] = fbServer;
                            Response.Redirect("~/Customer.aspx");
                        }
                    }
                }
            }
        }
    }
}