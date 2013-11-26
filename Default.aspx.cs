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
                string username = Request.Form["username"].ToString();

                if (Request.Form["password"] != null)
                {
                    string password = Request.Form["password"].ToString();

                    if (Request.Form["serverIP"] != null)
                    {
                        string serverIP = Request.Form["serverIP"].ToString();

                        if (Request.Form["serverPort"] != null)
                        {
                            int port = Convert.ToInt32(Request.Form["serverPort"]);

                            fbServer.Login(serverIP, port, username, password);

                            Session["FishbowlServer"] = fbServer;
                            Response.Redirect("~/Customer.aspx");
                        }
                    }
                }
            }
        
    }
}