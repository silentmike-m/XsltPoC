namespace SilentMike.XsltPoC.Cient.Application.Takeoffs.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using BytesPack.Sterling.Shared.Interfaces;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Cient.Application.Takeoffs.Commands;
    using SilentMike.XsltPoC.Cient.Application.Takeoffs.Models;

    public sealed class SendTakeoffItemsHandler : IRequestHandler<SendTakeoffItems>
    {
        private readonly ILogger<SendTakeoffItemsHandler> logger;
        private readonly IPublishEndpoint publishEndpoint;

        public SendTakeoffItemsHandler(ILogger<SendTakeoffItemsHandler> logger, IPublishEndpoint publishEndpoint)
            => (this.logger, this.publishEndpoint) = (logger, publishEndpoint);

        public async Task<Unit> Handle(SendTakeoffItems request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Sending takeoff items to server");

            var takeoffItem = new TakeoffData
            {
                AggregatedMeasurements = new List<IMeasurement>
                {
                    new Measurement
                    {
                        Name = "Volume",
                        Unit = "m3",
                        Value = 123.5678m,
                    },
                },
                Children = new List<ITakeoffData>
                {
                    new TakeoffData
                    {
                        AggregatedMeasurements = new List<IMeasurement>
                        {
                            new Measurement
                            {
                                Name = "Quantity",
                                Unit = "szt",
                                Value = 145,
                            },
                        },
                        GroupName = "child_group_name",
                        GroupedBy = "child_group_by",
                        Id = Guid.NewGuid(),
                    },
                },
                GroupName = "takeoff_group_name",
                GroupedBy = "takeoff_group_by",
                Id = Guid.NewGuid(),
            };

            var message = new TakeoffDataMessage
            {
                PortfolioId = Guid.Parse("0dcaf360-a2da-4480-86b8-3e8a9f686040"),
                TakeoffData = takeoffItem,
            };

            await this.publishEndpoint.Publish<ITakeoffDataMessage>(message, context => context.TimeToLive = TimeSpan.FromSeconds(10), cancellationToken);
            return await Task.FromResult(Unit.Value);
        }
    }
}
