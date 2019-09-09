namespace HomeWizard.Net
{
    public class Reading
    {
        public string Type { get; set; }
        public int Tariff { get; set; }
        public double Consumed { get; set; }
        public double Produced { get; set; }
        public int? Timestamp { get; set; }
    }
}
