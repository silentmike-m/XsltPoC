namespace BytesPack.Sterling.Shared.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ITakeoffData
    {
        public Guid Id { get; set; }
        public IEnumerable<IMeasurement> AggregatedMeasurements { get; set; }
        public IEnumerable<ITakeoffData> Children { get; set; }
        public string GroupedBy { get; set; }
        public string GroupName { get; set; }
    }
}
