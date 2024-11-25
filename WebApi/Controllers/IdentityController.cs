using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Identities.Commands.SignIn;
using Application.Identities.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CreateSignInCommand signInCommand)
        {
            return Ok(await _mediator.Send(signInCommand));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateSignUpCommand signUpCommand)
        {
            return Ok(await _mediator.Send(signUpCommand));
        }
    }


}