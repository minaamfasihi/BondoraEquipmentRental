using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Rental
{
    public class OneTime : Rental
    {
        public OneTime()
        {
            this.fees = 100;
        }
        public override float getFees(int days)
        {
            return this.fees;
        }
        public override float getFees()
        {
            return this.fees;
        }
    }
}
