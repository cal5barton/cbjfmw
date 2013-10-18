using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public class Address
{
    public string TempAccountType { get; set; }
    public string Name { get; set; }
    public string Attn { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Default { get; set; }
    public string Residential { get; set; }
    public string Type { get; set; }

    public class State
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CountryID { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class AddressInformation
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public string Default { get; set; }
        public string Type { get; set; }
    }
}

public class CustomField
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
}

public class Customer
{
    public int CustomerID { get; set; }
    public int AccountID { get; set; }
    public string Status { get; set; }
    public string DefPaymentTerms { get; set; }
    public string DefShipTerms { get; set; }
    public string TaxRate { get; set; }
    public string Name { get; set; }
    public string CreditLimit { get; set; }
    public string TaxExempt { get; set; }
    public string TaxExemptNumber { get; set; }
    public string Note { get; set; }
    public string ActiveFlag { get; set; }
    public string DefSalesman { get; set; }
    public string DefCarrier { get; set; }
    public string JobDepth { get; set; }
}

public class Vendor
{

}

