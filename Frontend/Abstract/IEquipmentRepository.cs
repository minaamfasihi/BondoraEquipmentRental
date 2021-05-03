using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Abstract
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetEquipments();
    }
}
