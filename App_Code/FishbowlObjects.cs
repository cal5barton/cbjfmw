﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public class Address
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Attn { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public int LocationGroupID { get; set; }
    public Boolean Default { get; set; }
    public Boolean Residential { get; set; }
    public string Type { get; set; }

    public State addressState { get; set; }
    public Country addressCountry { get; set; }
    public AddressInformation addressInformation { get; set; }

    public Address()
    {
        addressState = new State();
        addressCountry = new Country();
        addressInformation = new AddressInformation();
    }

    public class TempAccount
    {
        public int ID { get; set; }
        public int Type { get; set; }
    }

    public class State
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CountryID { get; set; }
    }

    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class AddressInformation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public Boolean Default { get; set; }
        public string Type { get; set; }
    }
}

public class CustomField
{
    public int ID { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SortOrder { get; set; }
    public string Info { get; set; }
    public Boolean RequiredFlag { get; set; }
    public Boolean ActiveFlag { get; set; }
}

public class CustomList
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class CustomListItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
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
    public string Number { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateLastModified { get; set; }
    public string LastChangedUser { get; set; }
    public double CreditLimit { get; set; }
    public Boolean TaxExempt { get; set; }
    public string TaxExemptNumber { get; set; }
    public string Note { get; set; }
    public Boolean ActiveFlag { get; set; }
    public string AccountingID { get; set; }
    public string CurrencyName { get; set; }
    public double CurrencyRate { get; set; }
    public string DefSalesman { get; set; }
    public string DefCarrier { get; set; }
    public string DefShipService { get; set; }
    public int JobDepth { get; set; }
    public int ParentID { get; set; }
    public int PipelineAccount { get; set; }
    public string URL { get; set; }

    public List<Address> customerAddresses { get; set; }
    public CustomField customerCF { get; set; }

    public Customer()
    {
        customerAddresses = new List<Address>();
        customerAddresses.Add(new Address());
    }
}

public class Vendor
{
    public int VendorID { get; set; }
    public int AccountID { get; set; }
    public string Status { get; set; }
    public string DefPaymentTerms { get; set; }
    public string DefShipTerms { get; set; }
    public string TaxRate { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateLastModified { get; set; }
    public string LastChangedUser { get; set; }
    public double CreditLimit { get; set; }
    public string Note { get; set; }
    public int AysUserID { get; set; }
    public Boolean ActiveFlag { get; set; }
    public string AccountingID { get; set; }
    public string AccountingHash { get; set; }
    public string CurrencyName { get; set; }
    public string CurrencyRate { get; set; }
    public int LeadTime { get; set; }

    public List<Address> vendorAddresses { get; set; }
    public CustomField vendorCF { get; set; }
}

