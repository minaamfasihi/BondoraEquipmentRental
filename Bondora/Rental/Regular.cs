using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Rental
{
    public class Regular : Rental
    {
        public Regular()
        {
            this.fees = 40;
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
