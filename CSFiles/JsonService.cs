using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace VillageRentals.CSFiles;

public class JsonService
{
    private readonly string _basePath;
    private readonly string _equipmentCategoriesFilePath;
    private readonly string _equipmentsFilePath;
    private readonly string _customersFilePath;
    private readonly string _ordersFilePath;

    public JsonService()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        _basePath = Path.Combine(desktopPath, "VillageRentals");
        _equipmentCategoriesFilePath = Path.Combine(_basePath, "EquipmentCategories.json");
        _equipmentsFilePath = Path.Combine(_basePath, "Equipments.json");
        _customersFilePath = Path.Combine(_basePath, "Customers.json");
        _ordersFilePath = Path.Combine(_basePath, "Orders.json");
    }

    public void InitializeJsonFile()
    {
        // Create the directory if it doesn't exist
        Directory.CreateDirectory(_basePath);

        // Check if the EquipmentCategories.json file exists
        if (!File.Exists(_equipmentCategoriesFilePath))
        {
            // Add initial data for categories
            var initialCategories = new List<EquipmentCategory>
            {
                new EquipmentCategory(10, "Power tools"),
                new EquipmentCategory(20, "Yard equipment"),
                new EquipmentCategory(30, "Compressors"),
                new EquipmentCategory(40, "Generators"),
                new EquipmentCategory(50, "Air Tools")
            };

            // Write initial data to JSON
            string jsonString = JsonSerializer.Serialize(initialCategories, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_equipmentCategoriesFilePath, jsonString);
        }

        // Load categories into DataStore
        DataStore.EquipmentCategories = ReadCategories();

        // Check if the Equipments.json file exists
        if (!File.Exists(_equipmentsFilePath))
        {
            // Create initial data for equipments
            var initialEquipments = new List<Equipment>
            {
                new Equipment(101, 10, "Hammer drill", "Powerful drill for concrete and masonry", 25.99, "Good", true, true, "all"),
                new Equipment(201, 20, "Chainsaw", "Gas-powered chainsaw for cutting wood", 49.99, "Good", true, true, "all"),
                new Equipment(202, 20, "Lawn mower", "Self-propelled lawn mower with mulching function", 19.99, "Good", true, true, "all"),
                new Equipment(301, 30, "Small Compressor", "5 Gallon Compressor-Portable", 14.99, "Good", true, true, "all"),
                new Equipment(501, 50, "Brad Nailer", "Brad Nailer. Requires 3/4 to 1 1/2 Brad Nails", 10.99, "Good", true, true, "all")
            };

            // Set EquipmentCategoryName for initial data
            foreach (var equipment in initialEquipments)
            {
                var category = DataStore.EquipmentCategories.FirstOrDefault(c => c.EquipmentCategoryID == equipment.EquipmentCategoryID);
                if (category != null)
                {
                    equipment.EquipmentCategoryName = category.EquipmentCategoryName;
                }
            }

            // Write initial data to JSON
            string jsonString = JsonSerializer.Serialize(initialEquipments, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_equipmentsFilePath, jsonString);
        }

        // Check if the Customers.json file exists
        if (!File.Exists(_customersFilePath))
        {
            var initialCustomers = new List<Customer>
            {
                new Customer(1001, "Doe", "John", "(555) 555-1212", "jd@sample.net", false, "N/A", 5, "123456"),
                new Customer(1002, "Smith", "Jane", "(555) 555-3434", "js@live.com", false, "N/A", 0, "123456"),
                new Customer(1003, "Lee", "Michael", "(555) 555-5656", "ml@sample.net", false, "N/A", 0, "123456")
            };
            string jsonString = JsonSerializer.Serialize(initialCustomers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_customersFilePath, jsonString);
        }

        // Check if the Orders.json file exists
        if (!File.Exists(_ordersFilePath))
        {
            var initialOrders = new List<Order>();
            string jsonString = JsonSerializer.Serialize(initialOrders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_ordersFilePath, jsonString);
        }

        // Load data into DataStore
        DataStore.Initialize(this);
    }

    public List<EquipmentCategory> ReadCategories()
    {
        if (File.Exists(_equipmentCategoriesFilePath))
        {
            string jsonString = File.ReadAllText(_equipmentCategoriesFilePath);
            return JsonSerializer.Deserialize<List<EquipmentCategory>>(jsonString) ?? new List<EquipmentCategory>();
        }

        return new List<EquipmentCategory>();
    }

    public void AddCategory(EquipmentCategory category)
    {
        // Read existing categories
        var categories = ReadCategories();

        // Check if the category already exists (based on ID)
        var existingCategory = categories.FirstOrDefault(c => c.EquipmentCategoryID == category.EquipmentCategoryID);
        if (existingCategory != null)
        {
            // Update the existing category
            existingCategory.EquipmentCategoryName = category.EquipmentCategoryName;
        }
        else
        {
            // Add the new category
            categories.Add(category);
        }

        // Write back to JSON
        string jsonString = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_equipmentCategoriesFilePath, jsonString);

        // Update DataStore
        DataStore.EquipmentCategories = categories;
    }

    public int GetNextCategoryID()
    {
        var categories = ReadCategories();
        if (categories.Count == 0)
        {
            return 10; // Start from 10 if no categories exist
        }

        // Find the maximum ID and increment by 10
        return categories.Max(c => c.EquipmentCategoryID) + 10;
    }

    public List<Equipment> ReadEquipments()
    {
        if (File.Exists(_equipmentsFilePath))
        {
            string jsonString = File.ReadAllText(_equipmentsFilePath);
            return JsonSerializer.Deserialize<List<Equipment>>(jsonString) ?? new List<Equipment>();
        }

        return new List<Equipment>();
    }

    public void AddEquipment(Equipment equipment)
    {
        // Read existing equipments
        var equipments = ReadEquipments();

        // Set EquipmentCategoryName
        var category = DataStore.EquipmentCategories.FirstOrDefault(c => c.EquipmentCategoryID == equipment.EquipmentCategoryID);
        if (category != null)
        {
            equipment.EquipmentCategoryName = category.EquipmentCategoryName;
        }

        // Check if the equipment already exists (based on ID)
        var existingEquipment = equipments.FirstOrDefault(e => e.EquipmentID == equipment.EquipmentID);
        if (existingEquipment != null)
        {
            // Update the existing equipment
            existingEquipment.EquipmentCategoryID = equipment.EquipmentCategoryID;
            existingEquipment.EquipmentCategoryName = equipment.EquipmentCategoryName;
            existingEquipment.EquipmentName = equipment.EquipmentName;
            existingEquipment.EquipmentDescription = equipment.EquipmentDescription;
            existingEquipment.EquipmentDailyRate = equipment.EquipmentDailyRate;
            existingEquipment.EquipmentCondition = equipment.EquipmentCondition;
            existingEquipment.EquipmentIsInInventory = equipment.EquipmentIsInInventory;
            existingEquipment.EquipmentIsAvailable = equipment.EquipmentIsAvailable;
            existingEquipment.EquipmentWorkingParts = equipment.EquipmentWorkingParts;
        }
        else
        {
            // Add the new equipment
            equipments.Add(equipment);
        }

        // Write back to JSON
        string jsonString = JsonSerializer.Serialize(equipments, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_equipmentsFilePath, jsonString);

        // Update DataStore
        DataStore.Equipments = equipments;
    }

    public void RemoveEquipment(int equipmentID)
    {
        // Read existing equipments
        var equipments = ReadEquipments();

        // Remove the equipment with the specified ID
        var equipmentToRemove = equipments.FirstOrDefault(e => e.EquipmentID == equipmentID);
        if (equipmentToRemove != null)
        {
            equipments.Remove(equipmentToRemove);

            // Write back to JSON
            string jsonString = JsonSerializer.Serialize(equipments, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_equipmentsFilePath, jsonString);

            // Update DataStore
            DataStore.Equipments = equipments;
        }
    }

    public int GetNextEquipmentID(int categoryID)
    {
        var equipments = ReadEquipments();
        var categoryEquipments = equipments.Where(e => e.EquipmentCategoryID == categoryID).ToList();

        if (categoryEquipments.Count == 0)
        {
            // If no equipments exist for this category, start with CategoryID + 1
            return int.Parse($"{categoryID}1");
        }

        // Find the maximum EquipmentID for this category
        int maxId = categoryEquipments.Max(e => e.EquipmentID);
        // Extract the sequential number (e.g., for 101, sequential number is 1)
        string categoryIdStr = categoryID.ToString();
        string sequentialPart = maxId.ToString().Substring(categoryIdStr.Length);
        int sequentialNumber = int.Parse(sequentialPart);

        // Increment the sequential number
        sequentialNumber++;

        // If the sequential number reaches 9, the next ID should be CategoryID + 10 (e.g., 109 -> 1010)
        if (sequentialNumber <= 9)
        {
            return int.Parse($"{categoryID}{sequentialNumber}");
        }
        else
        {
            // Increase the length of the sequential part (e.g., 109 -> 1010)
            return int.Parse($"{categoryID}{sequentialNumber}");
        }
    }

    public List<Customer> ReadCustomers()
    {
        if (File.Exists(_customersFilePath))
        {
            string jsonString = File.ReadAllText(_customersFilePath);
            return JsonSerializer.Deserialize<List<Customer>>(jsonString) ?? new List<Customer>();
        }

        return new List<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        // Read existing customers
        var customers = ReadCustomers();

        // Check if the customer already exists (based on ID)
        var existingCustomer = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
        if (existingCustomer != null)
        {
            // Update the existing customer
            existingCustomer.CustomerLastName = customer.CustomerLastName;
            existingCustomer.CustomerFirstName = customer.CustomerFirstName;
            existingCustomer.CustomerContactPhone = customer.CustomerContactPhone;
            existingCustomer.CustomerEmail = customer.CustomerEmail;
            existingCustomer.CustomerIsBanned = customer.CustomerIsBanned;
            existingCustomer.CustomerBannedDescription = customer.CustomerBannedDescription;
            existingCustomer.CustomerDiscount = customer.CustomerDiscount;
            existingCustomer.CustomerPassword = customer.CustomerPassword;
        }
        else
        {
            // Add the new customer
            customers.Add(customer);
        }

        // Write back to JSON
        string jsonString = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_customersFilePath, jsonString);

        // Update DataStore
        DataStore.Customers = customers;
    }

    public void RemoveCustomer(int customerID)
    {
        // Read existing customers
        var customers = ReadCustomers();

        // Remove the customer with the specified ID
        var customerToRemove = customers.FirstOrDefault(c => c.CustomerID == customerID);
        if (customerToRemove != null)
        {
            customers.Remove(customerToRemove);

            // Write back to JSON
            string jsonString = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_customersFilePath, jsonString);

            // Update DataStore
            DataStore.Customers = customers;
        }
    }

    public int GetNextCustomerID()
    {
        var customers = ReadCustomers();
        if (customers.Count == 0)
        {
            return 1001; // Start from 1001 if no customers exist
        }

        // Find the maximum ID and increment by 1
        return customers.Max(c => c.CustomerID) + 1;
    }

    public List<Order> ReadOrders()
    {
        if (File.Exists(_ordersFilePath))
        {
            string jsonString = File.ReadAllText(_ordersFilePath);
            return JsonSerializer.Deserialize<List<Order>>(jsonString) ?? new List<Order>();
        }

        return new List<Order>();
    }

    public void AddOrder(Order order)
    {
        // Read existing orders
        var orders = ReadOrders();

        // Check if the order already exists (based on ID)
        var existingOrder = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
        if (existingOrder != null)
        {
            // Update the existing order
            existingOrder.CustomerID = order.CustomerID;
            existingOrder.EquipmentID = order.EquipmentID;
            existingOrder.OrderPlaceDate = order.OrderPlaceDate;
            existingOrder.OrderRentalDate = order.OrderRentalDate;
            existingOrder.OrderReturnDate = order.OrderReturnDate;
            existingOrder.OrderReturnDateFinal = order.OrderReturnDateFinal;
            existingOrder.TotalFee = order.TotalFee;
            existingOrder.OrderIsClosed = order.OrderIsClosed; 
        }
        else
        {
            // Add the new order
            order.OrderPlaceDate = DateTime.Now; // Set OrderPlaceDate to current date
            orders.Add(order);

            // Update the equipment's availability
            var equipments = ReadEquipments();
            var equipment = equipments.FirstOrDefault(e => e.EquipmentID == order.EquipmentID);
            if (equipment != null)
            {
                equipment.EquipmentIsAvailable = false;
                AddEquipment(equipment);
            }
        }

        // Write back to JSON
        string jsonString = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_ordersFilePath, jsonString);

        // Update DataStore
        DataStore.Orders = orders;
    }

    public void RemoveOrder(int orderID)
    {
        // Read existing orders
        var orders = ReadOrders();

        // Find the order to remove
        var orderToRemove = orders.FirstOrDefault(o => o.OrderID == orderID);
        if (orderToRemove != null)
        {
            // Remove the order
            orders.Remove(orderToRemove);

            // Write back to JSON
            string jsonString = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_ordersFilePath, jsonString);

            // Update DataStore
            DataStore.Orders = orders;

            // Update the equipment's availability
            var equipments = ReadEquipments();
            var equipment = equipments.FirstOrDefault(e => e.EquipmentID == orderToRemove.EquipmentID);
            if (equipment != null)
            {
                equipment.EquipmentIsAvailable = true;
                AddEquipment(equipment);
            }
        }
    }

    public int GetNextOrderID()
    {
        var orders = ReadOrders();
        if (orders.Count == 0)
        {
            return 1001; // Start from 1001 if no orders exist
        }

        // Find the maximum ID and increment by 1
        return orders.Max(o => o.OrderID) + 1;
    }
}