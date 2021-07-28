namespace SilentMike.XsltPoC.WebApi.Application.Users.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Shared.Interfaces;
    using SilentMike.XsltPoC.WebApi.Application.Users.Queries;
    using SilentMike.XsltPoC.WebApi.Entities;

    internal sealed class GetUserHtmlEmailConsumer : IConsumer<IGetUserHtmlEmailRequest>
    {
        private readonly ILogger<GetUserHtmlEmailConsumer> logger;
        private readonly IMediator mediator;

        public GetUserHtmlEmailConsumer(ILogger<GetUserHtmlEmailConsumer> logger, IMediator mediator)
            => (this.logger, this.mediator) = (logger, mediator);

        public async Task Consume(ConsumeContext<IGetUserHtmlEmailRequest> context)
        {
            this.logger.LogInformation("Receive get user html email");

            var command = new GetUserHtmlEmail
            {
                List = context.Message.Things,
                UserEmail = context.Message.Email,
                UserName = context.Message.UserName,
            };

            var html = await this.mediator.Send(command);
            var response = new GetUserHtmlEmailResponse
            {
                Email = context.Message.Email,
                Html = html,
            };

            await context.RespondAsync<IGetUserHtmlEmailResponse>(response);
        }
    }
}
