using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles;
public class CustomerManagementUI
{
    public int CustomerID { get; set; }
    public string CustomerLastName { get; set; } = string.Empty;
    public string CustomerFirstName { get; set; } = string.Empty;
    public string CustomerContactPhone { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public bool CustomerIsBanned { get; set; } = false;
    public string CustomerBannedDescription { get; set; } = "N/A";
    public int CustomerDiscount { get; set; } = 0;
    public string CustomerPassword { get; set; } = "123456";

    public CustomerManagementUI() { }

    public CustomerManagementUI(int customerID, string lastName, string firstName, string phone, string email, bool isBanned, string bannedDescription, int discount, string password)
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