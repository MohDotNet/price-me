using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace price_me.models
{
    public class CalculateRequest
    {
        public int Markup { get; set; }
        public double CostPrice { get; set; }
        public bool IncVat { get; set; } = false;
    }
}
