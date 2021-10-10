using Dashboard.Application.ArbitrageBets.Commands;
using Dashboard.Application.ArbitrageBets.Queries;
using Dashboard.Application.ArbitrageBets.ViewModels;
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
    public class ArbitrageBetsController : ApiController
    {
        // GET: api/<ArbitrageBetsController>
        [HttpGet]
        public async Task<IList<ArbitrageBetVM>> Get()
        {
            return await Mediator.Send(new GetArbitrageBetsQuery());
        }

        // GET api/<ArbitrageBetsController>/5
        [HttpGet("{id}")]
        public async Task<ArbitrageBetVM> Get(int id)
        {
            return await Mediator.Send(new GetArbitrageBetQuery(id));
        }

        // POST api/<ArbitrageBetsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateArbitrageBetCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<ArbitrageBetsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateArbitrageBetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // PUT api/<ArbitrageBetsController>
        [HttpPut("UpdateStatus")]
        public async Task<ActionResult<Unit>> UpdateStatus(int id, UpdateArbitrageBetStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<ArbitrageBetsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteArbitrageBetCommand { Id = id });
        }
    }
}
