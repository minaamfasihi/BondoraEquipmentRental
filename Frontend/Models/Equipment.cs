using Frontend.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Frontend.Models
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
