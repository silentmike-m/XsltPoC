namespace SilentMike.XsltPoC.WebApi.Application.Users.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Shared.Intefacies;
    using SilentMike.XsltPoC.WebApi.Application.Users.Commands;

    internal sealed class SendUserEmailConsumer : IConsumer<ISendUserEmailRequest>
    {
        private readonly ILogger<SendUserEmailConsumer> logger;
        private readonly IMediator mediator;

        public SendUserEmailConsumer(ILogger<SendUserEmailConsumer> logger, IMediator mediator)
            => (this.logger, this.mediator) = (logger, mediator);

        public async Task Consume(ConsumeContext<ISendUserEmailRequest> context)
        {
            this.logger.LogInformation("Receive send email message");

            var command = new SendUserEmail
            {
                List = context.Message.Things,
                UserEmail = context.Message.Email,
                UserName = context.Message.UserName,
            };

            await this.mediator.Send(command);
        }
    }
}
