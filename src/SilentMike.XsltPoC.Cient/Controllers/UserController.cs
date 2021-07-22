﻿namespace SilentMike.XsltPoC.Cient.Controllers
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SilentMike.XsltPoC.Cient.Application.Users.Commands;

    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator) => this.mediator = mediator;

        [HttpPost(Name = "SendUserEmail")]
        public async Task SendUserEmail(SendUserEmail request) => await this.mediator.Send(request);
    }
}