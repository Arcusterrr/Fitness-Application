using System.Threading.Tasks;
using Domain.UseCases.User.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/v1/user")]
    public class UserController: Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserAsync([FromQuery] CreateUserInput request)
        {
            var result = await _mediator.Send(request);

            return Ok(new
            {
                id = result
            });
        }
    }
}