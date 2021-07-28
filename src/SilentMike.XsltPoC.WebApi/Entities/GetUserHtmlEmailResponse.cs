namespace SilentMike.XsltPoC.WebApi.Entities
{
    using SilentMike.XsltPoC.Shared.Interfaces;

    internal sealed class GetUserHtmlEmailResponse : IGetUserHtmlEmailResponse
    {
        public string Email { get; set; } = string.Empty;
        public string Html { get; set; } = string.Empty;
    }
}
