using Dashboard.Application.Leagues.Commands;
using Dashboard.Application.Leagues.Queries;
using Dashboard.Application.Leagues.ViewModels;
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
    public class LeaguesController : ApiController
    {
        // GET: api/<LeaguesController>
        [HttpGet]
        public async Task<IList<LeagueVM>> Get(string? FilterBy = null, string? Value = null)
        {
            return await Mediator.Send(new GetLeaguesQuery(FilterBy, Value));
        }

        // GET api/<LeaguesController>/5
        [HttpGet("{id}")]
        public async Task<LeagueVM> Get(int id)
        {
            return await Mediator.Send(new GetLeagueQuery(id));
        }

        // POST api/<LeaguesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateLeagueCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<LeaguesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateLeagueCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<LeaguesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteLeagueCommand { Id = id });
        }
    }
}
