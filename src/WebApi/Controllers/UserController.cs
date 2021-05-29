using Application.Users.Commands.CreateUser;
using Application.Users.Commands.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;


        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<UserVm> Get([FromQuery] GetUserQuery query)
        {
            return await _sender.Send(query);
        }

        [HttpPost]
        public async Task<long> Create(CreateUserCommand command)
        {
            return await _sender.Send(command);
        }

        [HttpPut()]
        public async Task<int> Update(UpdateUserCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
