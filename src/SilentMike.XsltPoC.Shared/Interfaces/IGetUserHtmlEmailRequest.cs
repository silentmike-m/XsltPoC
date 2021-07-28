namespace SilentMike.XsltPoC.Shared.Interfaces
{
    using System.Collections.Generic;

    public interface IGetUserHtmlEmailRequest
    {
        string Email { get; set; }
        IReadOnlyCollection<string> Things { get; set; }
        public string UserName { get; set; }
    }
}
