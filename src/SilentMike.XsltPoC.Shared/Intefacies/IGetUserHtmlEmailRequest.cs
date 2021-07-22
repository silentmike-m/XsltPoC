namespace SilentMike.XsltPoC.Shared.Intefacies
{
    using System.Collections.Generic;

    public interface IGetUserHtmlEmailRequest
    {
        string Email { get; set; }
        IReadOnlyCollection<string> Things { get; set; }
        public string UserName { get; set; }
    }
}
