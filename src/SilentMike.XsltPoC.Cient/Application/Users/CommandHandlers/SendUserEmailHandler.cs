namespace SilentMike.XsltPoC.Cient.Application.Users.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Cient.Application.Users.Commands;
    using SilentMike.XsltPoC.Shared.Entities;

    internal sealed class SendUserEmailHandler : IRequestHandler<SendUserEmail>
    {
        private readonly IBus bus;
        private readonly ILogger<SendUserEmailHandler> logger;
        private readonly IPublishEndpoint emailPublishEndpoint;

        public SendUserEmailHandler(IBus bus, ILogger<SendUserEmailHandler> logger, IPublishEndpoint emailPublishEndpoint)
            => (this.bus, this.logger, this.emailPublishEndpoint) = (bus, logger, emailPublishEndpoint);

        public async Task<Unit> Handle(SendUserEmail request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Sending email message to server");
            var things = request.List.Select(i => new UserThing
            {
                Name = i,
            }).ToList();
            var userEmail = new UserEmail
            {
                Email = request.UserEmail,
                List = things,
                UserName = request.UserName,
            };

            var client = await this.bus.GetSendEndpoint(new Uri("queue:send-email"));
            await client.Send(userEmail, cancellationToken);

            await this.emailPublishEndpoint.Publish(userEmail, cancellationToken);

            return await Task.FromResult(Unit.Value);
        }
    }
}
