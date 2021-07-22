namespace SilentMike.XsltPoC.WebApi.Application.Users.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Shared.Entities;

    internal sealed class SendUserEmailConsumer : IConsumer<UserEmail>
    {
        private readonly ILogger<SendUserEmailConsumer> logger;

        public SendUserEmailConsumer(ILogger<SendUserEmailConsumer> logger)
            => (this.logger) = (logger);

        public async Task Consume(ConsumeContext<UserEmail> context)
        {
            this.logger.LogInformation($"Recieve send email message: {context.Message}");
        }
    }
}