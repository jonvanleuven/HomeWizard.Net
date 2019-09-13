using System;

namespace HomeWizard.Net
{
    public class EnergyLinkGraphData
    {
        public DateTime T { get; set; }
        public decimal U { get; set; }
        public decimal A { get; set; }
        public decimal S1 { get; set; }
        public decimal S2 { get; set; }
        public decimal G { get; set; }
    }
}