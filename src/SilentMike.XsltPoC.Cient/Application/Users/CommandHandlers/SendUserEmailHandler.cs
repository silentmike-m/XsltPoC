namespace SilentMike.XsltPoC.Cient.Application.Users.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BytesPack.Sterling.Shared.Interfaces;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Cient.Application.Users.Commands;
    using SilentMike.XsltPoC.Cient.Entities;

    internal sealed class SendUserEmailHandler : IRequestHandler<SendUserEmail>
    {
        private readonly ILogger<SendUserEmailHandler> logger;
        private readonly IPublishEndpoint publishEndpoint;

        public SendUserEmailHandler(IBus bus, ILogger<SendUserEmailHandler> logger, IPublishEndpoint publishEndpoint)
            => (this.logger, this.publishEndpoint) = (logger, publishEndpoint);

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
                Token = request.Token,
                Url = "www.wp.pl",
                UserName = request.UserName,
            };

            await this.publishEndpoint.Publish<ISendResetPasswordEmailRequest>(userEmail, context => context.TimeToLive = TimeSpan.FromSeconds(10), cancellationToken);
            //await this.publishEndpoint.Publish<ISendResetPasswordEmailRequest>(userEmail, cancellationToken);

            return await Task.FromResult(Unit.Value);
        }
    }
}
