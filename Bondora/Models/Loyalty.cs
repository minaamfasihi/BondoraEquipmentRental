using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondora.Models
{
    public class Loyalty
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("bondora.models.loyalty");
        public int points { get; set; }
        public int getPoints(EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.Heavy:
                    points = 2;
                    break;
                case EquipmentType.Regular:
                case EquipmentType.Specialized:
                    points = 1;
                    break;
            }
            log.Debug("getPoints: Points: " + points);
            return points;
        }
    }
}
