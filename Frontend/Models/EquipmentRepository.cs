using Frontend.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private List<Equipment> equipmentList;
        public EquipmentRepository()
        {
            Parser parser = new Parser();
            equipmentList = parser.parseEquipments(new Reader().ReadFile("inventory.txt"));
        }
        public List<Equipment> GetEquipments()
        {
            return equipmentList;
        }
    }
}
