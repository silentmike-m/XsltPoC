namespace SilentMike.XsltPoC.Cient.Application.Users.QueryHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.Cient.Application.Users.Queries;
    using SilentMike.XsltPoC.Cient.Entities;
    using SilentMike.XsltPoC.Shared.Interfaces;

    internal sealed class GetUserHtmlEmailHandler : IRequestHandler<GetUserHtmlEmail, string>
    {
        private readonly ILogger<GetUserHtmlEmailHandler> logger;
        private readonly IRequestClient<IGetUserHtmlEmailRequest> requestClient;

        public GetUserHtmlEmailHandler(ILogger<GetUserHtmlEmailHandler> logger, IRequestClient<IGetUserHtmlEmailRequest> requestClient)
            => (this.logger, this.requestClient) = (logger, requestClient);

        public async Task<string> Handle(GetUserHtmlEmail request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Sending get html email message to server");

            var getHtmlRequest = new GetUserHtmlEmailRequest
            {
                Email = request.UserEmail,
                Things = request.List,
                UserName = request.UserName,

            };

            //var test = await this.requestClient.Create(getHtmlRequest, cancellationToken).GetResponse<IGetUserHtmlEmailResponse>();
            var response = await this.requestClient.GetResponse<IGetUserHtmlEmailResponse>(getHtmlRequest, cancellationToken);

            return await Task.FromResult(response.Message.Html);
        }


    }
}
