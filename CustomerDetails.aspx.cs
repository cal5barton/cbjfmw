using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetailsPage : System.Web.UI.Page
{

    protected Customer customer { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FishbowlServer"] != null)
        {
            var fbServer = Session["FishbowlServer"] as FishbowlServer;
            customer = new Customer();
            if (Request.Form["HiddenSelection"] != null)
            {
                string customerName = Request.Form["HiddenSelection"];

                Page.Title = String.Format("{0} Details", customerName);
                customer = fbServer.getCustomer(customerName);

            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private Customer getCustomer(string customerName)
    {
        Customer customer = new Customer();
        Address address = new Address();
        address.addressState = new Address.State();

        

        customer.CreditLimit = 1000;
        customer.Status = "Normal";
        customer.DefPaymentTerms = "CIA";
        customer.DefCarrier = "This Carrier";
        customer.DefShipService = "A Service";
        customer.DefShipTerms = "Ship Terms";
        customer.DefSalesman = "Callen 'Da Man' Barton";
        customer.Number = "23095woti422";
        customer.TaxRate = "3.5%";
        customer.Note = "This might be a HUGE problem!";

        address.Name = "Address 1";
        address.Street = "123 Road";
        address.City = "Orem";
        address.Zip = "84058";
        address.addressState.Code = "UT";
        address.Attn = "ATTN: Cody";

        customer.customerAddresses.Clear();

        customer.customerAddresses.Add(address);


        return customer;

    }
}