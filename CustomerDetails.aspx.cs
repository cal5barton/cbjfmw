using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["HiddenSelection"] != null)
        {
            Page.Title = String.Format("{0} Details", Request.Form["HiddenSelection"]); ;
        }

        //Customer customer = getCustomerDetails(stuff Callen needs);
        // parse customer
    }
}