namespace VillageRentals.CSFiles;

public static class DataStore
{
    public static List<Customer> Customers { get; set; } = new List<Customer>();
    public static List<EquipmentCategory> EquipmentCategories { get; set; } = new List<EquipmentCategory>();
    public static List<Equipment> Equipments { get; set; } = new List<Equipment>();
    public static List<Order> Orders { get; set; } = new List<Order>();

    public static void Clear()
    {
        Customers.Clear();
        EquipmentCategories.Clear();
        Equipments.Clear();
        Orders.Clear();
    }

    public static void Initialize(JsonService jsonService)
    {
        Customers = jsonService.ReadCustomers();
        EquipmentCategories = jsonService.ReadCategories();
        Equipments = jsonService.ReadEquipments();
        Orders = jsonService.ReadOrders();
    }
}