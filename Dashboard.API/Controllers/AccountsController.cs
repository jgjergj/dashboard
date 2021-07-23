using Dashboard.Application.Accounts.Commands;
using Dashboard.Application.Accounts.Queries;
using Dashboard.Application.Accounts.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccountsController : ApiController
    {
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<IList<AccountVM>> Get()
        {
            return await Mediator.Send(new GetAccountsQuery());
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<AccountVM> Get(int id)
        {
            return await Mediator.Send(new GetAccountQuery(id));
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAccountCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<AccountsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateAccountCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<AccountsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteAccountCommand { Id = id });
        }
    }
}
