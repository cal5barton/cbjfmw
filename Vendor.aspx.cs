using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vendor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> customerNames = getVendorList();
        string html = "";

        foreach (string name in customerNames)
        {
            html = html + String.Format("<input type=\"submit\" value=\"{0}\" onclick=\"setHidden(this)\">", name);
        }

        nameList.InnerHtml = html;
    }

    private List<string> getVendorList()
    {
        List<string> names = new List<string>();

        names.Add("Vendor 1");
        names.Add("Vendor 2");
        names.Add("Vendor 3");
        names.Add("Vendor 4");
        names.Add("Vendor 5");
        names.Add("Vendor 6");
        names.Add("Vendor 7");
        names.Add("Vendor 8");
        names.Add("Vendor 9");
        names.Add("Vendor 10");

        return names;
    }
}