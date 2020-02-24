using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Queries.User;
using Infrastructure.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return NoContent();
            return BadRequest(result.Errors);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromBody]LogoutUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Get/{UserName}")]
        public async Task<IActionResult> GetUserByName(string UserName)
        {
            var result = await Mediator.Send(new GetUserByNameQuery() { UserName = UserName });

            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }
    }
}