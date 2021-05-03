using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Parser
    {
        public List<Equipment> parseEquipments(string[] data)
        {
            var equipments = new List<Equipment>();
            for (int item = 1; item <= data.Length; item++)
            {
                string tmp = data[item - 1].Replace("\t", " ");
                string[] equipmentDetail = tmp.Split(' ');
                if (equipmentDetail.Length > 1 &&
                    Enum.TryParse(equipmentDetail[equipmentDetail.Length - 1], out EquipmentType equipmentType)
                    )
                {
                    string eqName = equipmentDetail[0].Trim();
                    for (int i = 1; i < (equipmentDetail.Length - 1); i++)
                    {
                        eqName += " " + equipmentDetail[i].Trim();
                    }
                    Equipment equipment = new Equipment(eqName.Trim(), equipmentType, item);
                    equipments.Add(equipment);
                }
                else
                {
                    continue;
                }
            }
            return equipments;
        }
    }
}
