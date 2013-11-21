using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetailsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["HiddenSelection"] != null)
        {
            string customerName = Request.Form["HiddenSelection"];

            Page.Title = String.Format("{0} Details", customerName);

        }

        //Customer customer = getCustomerDetails(stuff Callen needs);
        // parse customer
    }

    private Customer getCustomer(string customerName)
    {
        Customer customer = new Customer();
        Address address = new Address();

        

        customer.CreditLimit = 1000;
        customer.Status = "Super Duper";
        customer.DefPaymentTerms = "Deez Terms";
        customer.DefCarrier = "This Carrier";
        customer.DefShipService = "A Service";
        customer.DefShipTerms = "Ship Terms";
        customer.DefSalesman = "Callen 'Da Man' Barton";
        customer.Number = "23095woti422";
        customer.TaxRate = "3.5%";
        customer.Note = "This might be a HUGE problem!";

        return customer;

    }
}