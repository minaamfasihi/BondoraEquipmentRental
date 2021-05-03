using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Rental
{
    public abstract class Rental
    {
        public abstract float getFees(int days);
        public abstract float getFees();
        public float fees { get; set; }
    }
}
