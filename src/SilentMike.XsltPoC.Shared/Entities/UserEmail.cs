namespace SilentMike.XsltPoC.Shared.Entities
{
    using System.Collections.Generic;

    public sealed class UserEmail
    {
        public string Email { get; set; } = string.Empty;
        public List<UserThing> List { get; init; } = new();
        public string UserName { get; set; } = string.Empty;
    }
}
