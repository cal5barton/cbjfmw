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
        FishbowlServer fbServer = new FishbowlServer();
        //fbServer.Connect("161.28.118.41", 28192, "admin", "admin", "customerList");

        //if (fbServer.serverMessage != "" && fbServer.serverMessage != null)
        {
            //Needs Javascript alert
        }
    }
}