namespace SilentMike.XsltPoC.WebApi.Users.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.WebApi.Users.Commands;

    internal sealed class SendUserEmailHandler : IRequestHandler<SendUserEmail>
    {
        private readonly ILogger<SendUserEmailHandler> logger;

        public Task<Unit> Handle(SendUserEmail request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}