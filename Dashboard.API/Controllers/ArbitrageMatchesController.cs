using Dashboard.Application.ArbitrageMatches.Commands;
using Dashboard.Application.ArbitrageMatches.Queries;
using Dashboard.Application.ArbitrageMatches.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ArbitrageMatchesController : ApiController
    {
        // GET: api/<ArbitrageMatchesController>
        [HttpGet]
        public async Task<IList<ArbitrageMatchVM>> Get()
        {
            return await Mediator.Send(new GetArbitrageMatchesQuery());
        }

        // GET api/<ArbitrageMatchesController>/5
        [HttpGet("{id}")]
        public async Task<ArbitrageMatchVM> Get(Guid id)
        {
            return await Mediator.Send(new GetArbitrageMatchQuery(id));
        }

        // POST api/<ArbitrageMatchesController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateArbitrageMatchCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<ArbitrageMatchesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(Guid id, UpdateArbitrageMatchCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<ArbitrageMatchesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteArbitrageMatchCommand { Id = id });
        }
    }
}
