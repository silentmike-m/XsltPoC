namespace SilentMike.XsltPoC.WebApi.Application.Users.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.WebApi.Application.Users.Commands;

    internal sealed class SendUserEmailHandler : IRequestHandler<SendUserEmail>
    {

        private readonly ILogger<SendUserEmailHandler> logger;

        public SendUserEmailHandler(ILogger<SendUserEmailHandler> logger)
            => (this.logger) = (logger);

        public async Task<Unit> Handle(SendUserEmail request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation($"Send email to user {request.UserName}, {request.UserEmail}");
            return await Task.FromResult(Unit.Value);
        }
    }
}
