namespace SilentMike.XsltPoC.WebApi.Users.CommandHandlers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SilentMike.XsltPoC.WebApi.Entities;
    using SilentMike.XsltPoC.WebApi.Extensions;
    using SilentMike.XsltPoC.WebApi.Services;
    using SilentMike.XsltPoC.WebApi.Users.Commands;

    internal sealed class SendUserEmailHandler : IRequestHandler<SendUserEmail, string>
    {
        private readonly string xsltFileName = "XsltStyles\\UserEmail.xslt";

        private readonly ILogger<SendUserEmailHandler> logger;
        private readonly XmlService xmlService;

        public SendUserEmailHandler(ILogger<SendUserEmailHandler> logger, XmlService xmlService)
            => (this.logger, this.xmlService) = (logger, xmlService);

        public async Task<string> Handle(SendUserEmail request, CancellationToken cancellationToken)
        {
            var requestXmlString = GetRequestXmlString(request);
            var html = this.xmlService.GetHtml(requestXmlString, xsltFileName);

            return await Task.FromResult(html);
        }

        private static string GetRequestXmlString(SendUserEmail request)
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
            return userEmail.ToXmlString();

            var serializer = new XmlSerializer(typeof(UserEmail));
            return serializer.Serialize(userEmail);
        }
    }
}