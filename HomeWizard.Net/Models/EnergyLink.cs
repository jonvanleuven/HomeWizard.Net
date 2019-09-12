using Newtonsoft.Json;

namespace HomeWizard.Net
{
    public class EnergyLink : Device
    { 
        public string Tariff { get; set;  }
        public string C1 { get; set;  }
        public string C2 { get; set;  }
        public string T1 { get; set;  }
        public string T2 { get; set;  }
        public string S1 { get; set;  }
        public string S2 { get; set;  }
        public Electric Aggregate { get; set; }
        public Electric Used { get; set; }
        public Gas Gas { get; set; }
        public double Kwhindex { get; set; }
    }

    public class Electric
    {
        public int Po { get; set; }
        public double DayTotal { get; set; }
        [JsonProperty("po+")]
        public int PoPlus { get; set; }
        [JsonProperty("po+t")]
        public string PoPlusT { get; set; }
        [JsonProperty("po-")]
        public int PoMin { get; set; }
        [JsonProperty("po-t")]
        public string PoMinT { get; set; }
    }

    public class Gas
    {
        public double LastHour { get; set; }
        public double DayTotal { get; set; }
    }
}
