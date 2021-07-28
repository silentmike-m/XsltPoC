namespace SilentMike.XsltPoC.Shared.Interfaces
{
    using System.Collections.Generic;

    public interface ISendUserEmailRequest
    {
        string Email { get; set; }
        IReadOnlyCollection<string> Things { get; set; }
        string UserName { get; set; }
    }
}
