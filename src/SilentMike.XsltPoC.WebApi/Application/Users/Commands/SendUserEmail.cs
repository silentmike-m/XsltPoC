﻿namespace SilentMike.XsltPoC.WebApi.Application.Users.Commands
{
    using System.Collections.Generic;
    using MediatR;

    public sealed record SendUserEmail : IRequest
    {
        public string UserName { get; init; } = string.Empty;
        public string UserEmail { get; init; } = string.Empty;
        public IReadOnlyCollection<string> List { get; init; } = new List<string>().AsReadOnly();
    }
}
