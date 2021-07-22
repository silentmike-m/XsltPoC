namespace SilentMike.XsltPoC.Shared.Intefacies
{
    using System.Collections.Generic;

    public interface ISendUserEmailRequest
    {
        string Email { get; set; }
        IReadOnlyCollection<string> Things { get; set; }
        public string UserName { get; set; }
    }
}
