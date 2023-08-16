namespace SilentMike.XsltPoC.Cient.Application.Takeoffs.Models
{
    using System;
    using System.Collections.Generic;
    using BytesPack.Sterling.Shared.Interfaces;

    public sealed class TakeoffData : ITakeoffData
    {
        public Guid Id { get; set; } = default;
        public IEnumerable<IMeasurement> AggregatedMeasurements { get; set; } = new List<IMeasurement>();
        public IEnumerable<ITakeoffData> Children { get; set; } = new List<ITakeoffData>();
        public string GroupedBy { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
    }
}
