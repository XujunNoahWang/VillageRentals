using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles;

public class Equipment : EquipmentCategory
{
    public int EquipmentID { get; set; }
    public string EquipmentName { get; set; }
    public string EquipmentDescription { get; set; }
    public double EquipmentDailyRate { get; set; }
    public string EquipmentCondition { get; set; }
    public bool EquipmentIsInInventory { get; set; }
    public bool EquipmentIsAvailable { get; set; }
    public string EquipmentWorkingParts { get; set; }

    public Equipment() { }

    public Equipment(int equipmentID, int categoryID, string equipmentName, string equipmentDescription, double equipmentDailyRate, string equipmentCondition, bool isInInventory, bool isAvailable, string workingParts)
    {
        EquipmentID = equipmentID;
        EquipmentCategoryID = categoryID; 
        EquipmentName = equipmentName;
        EquipmentDescription = equipmentDescription;
        EquipmentDailyRate = equipmentDailyRate;
        EquipmentCondition = equipmentCondition;
        EquipmentIsInInventory = isInInventory;
        EquipmentIsAvailable = isAvailable;
        EquipmentWorkingParts = workingParts;
    }
}
