namespace SilentMike.XsltPoC.Cient.Application.Takeoffs.Models
{
    using System;
    using BytesPack.Sterling.Shared.Interfaces;

    public sealed class TakeoffDataMessage : ITakeoffDataMessage
    {
        public Guid PortfolioId { get; set; } = default;
        public ITakeoffData TakeoffData { get; set; } = new TakeoffData();
    }
}
