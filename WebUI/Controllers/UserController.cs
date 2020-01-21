using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Queries.User;
using Application.Common.Models;
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

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromBody]LoginUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success)
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("Get/{UserName}")]
        public async Task<UserVm> GetUserByName(string UserName)
        {
            return await Mediator.Send(new GetUserByNameQuery() { UserName = UserName });
        }
    }
}