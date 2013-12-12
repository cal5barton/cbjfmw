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
            //List<string> customerNames = getCustomerList();
            string html = "";

            foreach (string name in customerNames)
            {
                html = html + String.Format("<input type='submit' value=\"{0}\" onclick='setHidden(this)'>", name);
            }

            nameList.InnerHtml = html;
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

    }

    private List<string> getCustomerList()
    {
        List<string> names = new List<string>();

        names.Add("Customer 1");
        names.Add("Customer 2");
        names.Add("Customer 3");
        names.Add("Customer 4");
        names.Add("Customer 5");
        names.Add("Customer 6");
        names.Add("Customer 7");
        names.Add("Customer 8");
        names.Add("Customer 9");
        names.Add("Customer 10");

        return names;
    }

}