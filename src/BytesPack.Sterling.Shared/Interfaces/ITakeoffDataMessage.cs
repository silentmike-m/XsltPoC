namespace BytesPack.Sterling.Shared.Interfaces
{
    using System;

    public interface ITakeoffDataMessage
    {
        public Guid PortfolioId { get; set; }
        public ITakeoffData TakeoffData { get; set; }
    }
}
