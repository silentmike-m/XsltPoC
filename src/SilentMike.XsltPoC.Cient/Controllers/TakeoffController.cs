namespace SilentMike.XsltPoC.Cient.Controllers
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SilentMike.XsltPoC.Cient.Application.Takeoffs.Commands;

    [ApiController]
    [Route("[controller]/[action]")]
    public sealed class TakeoffController : ControllerBase
    {
        private readonly IMediator mediator;

        public TakeoffController(IMediator mediator) => this.mediator = mediator;

        [HttpPost(Name = "SendTakeoffItems")]
        public async Task SendTakeoffItems(SendTakeoffItems request) => await this.mediator.Send(request);
    }
}
