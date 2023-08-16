namespace BytesPack.Sterling.Shared.Interfaces
{
    public interface IMeasurement
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
    }
}
