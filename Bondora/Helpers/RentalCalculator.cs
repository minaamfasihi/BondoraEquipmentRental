using Bondora.Models;
using Bondora.Rental;

namespace Bondora.Helpers
{
    public class RentalCalculator
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("bondora.helpers.rentalcalc");
        public float getRentalPrice(EquipmentType equipmentType, int days)
        {
            float total = 0;
            OneTime oneTime = new OneTime();
            Premium premium = new Premium();
            Regular regular = new Regular();
            log.Debug("getRentalPrice: Equipment Type: " + equipmentType + "|Days:" + days);
            switch (equipmentType)
            {
                case EquipmentType.Heavy:
                    total = oneTime.getFees() + premium.getFees(days);
                    break;
                case EquipmentType.Regular:
                    int daysOverTwo = days - 2;
                    total = oneTime.getFees();
                    if (daysOverTwo <= 0)
                    {
                        total += premium.getFees(days);
                    }
                    else
                    {
                        total += premium.getFees(2) + regular.getFees(daysOverTwo);
                    }
                    break;
                case EquipmentType.Specialized:
                    int daysOverThree = days - 3;
                    if (daysOverThree <= 0)
                    {
                        total = premium.getFees(days); 
                    }
                    else
                    {
                        total = premium.getFees(3) + regular.getFees(daysOverThree);
                    }
                    break;
                default:
                    break;
            }
            log.Info("getRentalPrice: Total:" + total);
            return total;
        }
    }
}
