using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles;

// Customer.cs
public class Customer
{
    public int CustomerID { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerContactPhone { get; set; }
    public string CustomerEmail { get; set; }
    public bool CustomerIsBanned { get; set; }
    public string CustomerBannedDescription { get; set; }
    public int CustomerDiscount { get; set; }
    public string CustomerPassword { get; set; }

    public Customer() { }

    public Customer(int customerID, string lastName, string firstName, string phone, string email, bool isBanned, string bannedDescription, int discount, string password)
    {
        CustomerID = customerID;
        CustomerLastName = lastName;
        CustomerFirstName = firstName;
        CustomerContactPhone = phone;
        CustomerEmail = email;
        CustomerIsBanned = isBanned;
        CustomerBannedDescription = bannedDescription;
        CustomerDiscount = discount;
        CustomerPassword = password;
    }
}