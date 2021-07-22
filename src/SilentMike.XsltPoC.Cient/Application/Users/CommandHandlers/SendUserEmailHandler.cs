namespace SilentMike.XsltPoC.Cient.Application.Users.CommandHandlers
{
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
        private readonly ILogger<SendUserEmailHandler> logger;
        private readonly IPublishEndpoint emailPublishEndpoint;

        public SendUserEmailHandler(ILogger<SendUserEmailHandler> logger, IPublishEndpoint emailPublishEndpoint)
            => (this.logger, this.emailPublishEndpoint) = (logger, emailPublishEndpoint);

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

            await this.emailPublishEndpoint.Publish(userEmail, cancellationToken);

            return await Task.FromResult(Unit.Value);
        }
    }
}
