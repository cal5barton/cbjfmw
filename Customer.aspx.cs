using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FishbowlServer"] != null)
        {
            var fbServer = Session["FishbowlServer"] as FishbowlServer;
            
            List<string> customerNames = fbServer.getCustomerList();
            string html = "";

            foreach (string name in customerNames)
            {
                html = html + String.Format("<input type='submit' value='{0}' onclick='setHidden(this)'>", name);
            }

            nameList.InnerHtml = html;
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

    }

}