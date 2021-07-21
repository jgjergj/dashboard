using Dashboard.Application.Teams.Commands;
using Dashboard.Application.Teams.Queries;
using Dashboard.Application.Teams.ViewModels;
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
    public class TeamsController : ApiController
    {
        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IList<TeamVM>> Get()
        {
            return await Mediator.Send(new GetTeamsQuery());
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<TeamVM> Get(int id)
        {
            return await Mediator.Send(new GetTeamQuery(id));
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTeamCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<TeamsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateTeamCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<TeamsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteTeamCommand { Id = id });
        }
    }
}
