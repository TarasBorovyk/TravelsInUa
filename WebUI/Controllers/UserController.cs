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
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok();
            return BadRequest(result.Errors);
        }
    }
}