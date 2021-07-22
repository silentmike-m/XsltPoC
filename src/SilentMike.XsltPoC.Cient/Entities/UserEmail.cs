namespace SilentMike.XsltPoC.Cient.Entities
{
    using System.Collections.Generic;

    internal sealed class UserEmail
    {
        public string Email { get; set; } = string.Empty;
        public List<UserThing> List { get; init; } = new();
        public string UserName { get; set; } = string.Empty;
    }
}
