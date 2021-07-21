namespace SilentMike.XsltPoC.WebApi.Users.Commands
{
    using MediatR;

    public sealed record SendUserEmail : IRequest
    {
        public string UserName { get; init; } = string.Empty;
        public string UserEmail { get; init; } = string.Empty;

    }
}