namespace SilentMike.XsltPoC.Cient.Application.Takeoffs.Models
{
    using BytesPack.Sterling.Shared.Interfaces;

    public sealed class Measurement : IMeasurement
    {
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; } = default;
        public string Unit { get; set; } = string.Empty;
    }
}
