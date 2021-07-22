namespace SilentMike.XsltPoC.WebApi.Application.Users.QueryHandlers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.WebApi.Application.Users.Queries;
    using SilentMike.XsltPoC.WebApi.Entities;
    using SilentMike.XsltPoC.WebApi.Extensions;
    using SilentMike.XsltPoC.WebApi.Services;

    internal sealed class GetUserHtmlEmailHandler : IRequestHandler<GetUserHtmlEmail, string>
    {
        private readonly string xsltFileName = "XsltStyles\\UserEmail.xslt";

        private readonly ILogger<GetUserHtmlEmailHandler> logger;
        private readonly XmlService xmlService;

        public GetUserHtmlEmailHandler(ILogger<GetUserHtmlEmailHandler> logger, XmlService xmlService)
            => (this.logger, this.xmlService) = (logger, xmlService);

        public async Task<string> Handle(GetUserHtmlEmail request, CancellationToken cancellationToken)
        {
            var requestXmlString = GetRequestXmlString(request);
            var html = this.xmlService.GetHtml(requestXmlString, xsltFileName);

            return await Task.FromResult(html);
        }

        private static string GetRequestXmlString(GetUserHtmlEmail request)
        {
            var things = request.List.Select(i => new UserThing
            {
                Name = i,
            });

            var userEmail = new UserEmail
            {
                Email = request.UserEmail,
                List = things.ToList(),
                UserName = request.UserName,
            };

            var serializer = new XmlSerializer(typeof(UserEmail));
            return serializer.Serialize(userEmail);
        }
    }
}
