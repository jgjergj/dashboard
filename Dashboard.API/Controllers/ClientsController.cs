using Dashboard.Application.Clients.Commands;
using Dashboard.Application.Clients.Queries;
using Dashboard.Application.Clients.ViewModels;
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
    public class ClientsController : ApiController
    {
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IList<ClientVM>> Get()
        {
            return await Mediator.Send(new GetClientsQuery());
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<ClientVM> Get(int id)
        {
            return await Mediator.Send(new GetClientQuery(id));
        }

        // GET api/<ClientsController>/5
        [Route("Unassigned")]
        public async Task<IList<ClientVM>> GetClientsWithNoOperator()
        {
            return await Mediator.Send(new GetClientsWithNoOperatorQuery());
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateClientCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<ClientsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateClientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<ClientsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteClientCommand { Id = id });
        }
    }
}
