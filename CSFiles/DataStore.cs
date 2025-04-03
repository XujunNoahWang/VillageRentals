using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles;

public static class DataStore
{
    public static List<EquipmentCategory> EquipmentCategories { get; set; } = new List<EquipmentCategory>();
    public static List<Equipment> Equipments { get; set; } = new List<Equipment>();
    public static List<Customer> Customers { get; set; } = new List<Customer>();
    public static List<Order> Orders { get; set; } = new List<Order>();

    public static void LoadData(JsonService jsonService)
    {
        EquipmentCategories = jsonService.ReadCategories();
        Equipments = jsonService.ReadEquipments();
        Customers = jsonService.ReadCustomers();
        Orders = jsonService.ReadOrders();
    }
}