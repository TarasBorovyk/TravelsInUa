using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Microsoft.AspNetCore.Mvc;

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
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok();
            return BadRequest(result.Errors);
        }
    }
}