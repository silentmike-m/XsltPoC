namespace SilentMike.XsltPoC.WebApi
{
    using System;

    internal sealed class RabbitMqOptions
    {
        public static readonly string SectionName = "RabbitMQ";
        public Uri HostAddress { get; set; } = new Uri("about:blank");
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
