using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles
{
    public class EquipmentCategoryUI
    {
        public int EquipmentCategoryID { get; set; }
        public string EquipmentCategoryName { get; set; } = string.Empty;

        public EquipmentCategoryUI() { }

        public EquipmentCategoryUI(int id, string name)
        {
            EquipmentCategoryID = id;
            EquipmentCategoryName = name;
        }
    }
}
