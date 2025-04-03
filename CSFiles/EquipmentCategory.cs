using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentals.CSFiles
{
    public class EquipmentCategory
    {
        public int EquipmentCategoryID { get; set; }
        public string EquipmentCategoryName { get; set; }

        public EquipmentCategory() { }

        public EquipmentCategory(int id, string name)
        {
            EquipmentCategoryID = id;
            EquipmentCategoryName = name;
        }
    }
}
