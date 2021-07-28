namespace SilentMike.XsltPoC.Cient.Entities
{
    using System.Collections.Generic;
    using SilentMike.XsltPoC.Shared.Interfaces;

    internal sealed class GetUserHtmlEmailRequest : IGetUserHtmlEmailRequest
    {
        public string Email { get; set; } = string.Empty;
        public IReadOnlyCollection<string> Things { get; set; } = new List<string>().AsReadOnly();
        public string UserName { get; set; } = string.Empty;
    }
}
