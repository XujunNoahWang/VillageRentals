using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles;

public class EquipmentUI
{
    public int EquipmentID { get; set; }
    public int CategoryID { get; set; }
    public string EquipmentName { get; set; } = string.Empty;
    public string EquipmentDescription { get; set; } = string.Empty;
    public double EquipmentDailyRate { get; set; }
    public string EquipmentCondition { get; set; } = string.Empty;
    public bool EquipmentIsInInventory { get; set; }
    public bool EquipmentIsAvailable { get; set; }
    public string EquipmentWorkingParts { get; set; } = string.Empty;

    public EquipmentUI() { }

    public EquipmentUI(int equipmentID, int categoryID, string equipmentName, string equipmentDescription, double equipmentDailyRate, string equipmentCondition, bool isInInventory, bool isAvailable, string workingParts)
    {
        EquipmentID = equipmentID;
        CategoryID = categoryID;
        EquipmentName = equipmentName;
        EquipmentDescription = equipmentDescription;
        EquipmentDailyRate = equipmentDailyRate;
        EquipmentCondition = equipmentCondition;
        EquipmentIsInInventory = isInInventory;
        EquipmentIsAvailable = isAvailable;
        EquipmentWorkingParts = workingParts;
    }
}