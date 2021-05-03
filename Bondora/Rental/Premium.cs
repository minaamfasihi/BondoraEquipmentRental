using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Rental
{
    public class Premium : Rental
    {
        public Premium()
        {
            this.fees = 60;
        }
        public override float getFees(int days)
        {
            return fees * days;
        }
        public override float getFees()
        {
            return fees;
        }
    }
}
