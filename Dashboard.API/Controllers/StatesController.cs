using Dashboard.Application.States.Commands;
using Dashboard.Application.States.Queries;
using Dashboard.Application.States.ViewModels;
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
    public class StatesController : ApiController
    {
        // GET: api/<StatesController>
        [HttpGet]
        public async Task<IList<StateVM>> Get()
        {
            return await Mediator.Send(new GetStatesQuery());
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public async Task<StateVM> Get(int id)
        {
            return await Mediator.Send(new GetStateQuery(id));
        }

        // POST api/<StatesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStateCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<StatesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateStateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<StatesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteStateCommand { Id = id });
        }
    }
}
