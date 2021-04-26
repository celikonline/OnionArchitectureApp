using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Efactura.Application.Features.Commands.CreateUser;
using Efactura.Application.Features.Queries.GetAllUsers;
using Efactura.Application.Features.Queries.GetUserById;
using Efactura.Application.Interfaces.Repositories;
using Efactura.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Efactura.Application.Dtos;

namespace Efactura.WebApi.Controllers
{
    /// <summary>
    /// User Management API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> OnCreate([FromBody] CreateUserCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await mediator.Send(command);

            return !result.IsSuccess
                ? GetErrorResult(result.Message)
                : Ok(result);
        }

        /// <summary>
        /// Update user by id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> OnUpdate([FromBody] CreateUserCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await mediator.Send(command);

            return !result.IsSuccess
                ? GetErrorResult(result.Message)
                : Ok(result);
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> OnRead(Guid id)
        {
            var query = new GetUserByIdQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OnReadAll(Guid id)
        {
            var query = new GetAllUsersQuery();
            return Ok(await mediator.Send(query));
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> OnDelete(Guid id)
        {
            var query = new GetUserByIdQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }


    }
}
