using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Models
{
    public enum EquipmentType
    {
        Regular,
        Heavy,
        Specialized
    }
    public class Equipment
    {
        public Equipment(string name, EquipmentType type, int id)
        {
            this.name = name;
            this.type = type;
            this.id = id;
        }
        public string name { get; set; }
        public EquipmentType type { get; set; }
        public int id { get; set; }
    }
}
