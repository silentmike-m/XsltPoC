namespace SilentMike.XsltPoC.Cient.Entities
{
    using System.Collections.Generic;
    using BytesPack.Sterling.Shared.Interfaces;

    internal sealed class UserEmail : ISendResetPasswordEmailRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<UserThing> List { get; init; } = new();
        public string UserName { get; set; } = string.Empty;
    }
}
