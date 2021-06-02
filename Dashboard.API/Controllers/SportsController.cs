using Dashboard.Application.Sports.Commands;
using Dashboard.Application.Sports.Queries;
using Dashboard.Application.Sports.ViewModels;
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
    public class SportsController : ApiController
    {
        // GET: api/<SportsController>
        [HttpGet]
        public async Task<IList<SportVM>> Get()
        {
            return await Mediator.Send(new GetSportsQuery());
        }

        // GET api/<SportsController>/5
        [HttpGet("{id}")]
        public async Task<SportVM> Get(int id)
        {
            return await Mediator.Send(new GetSportQuery(id));
        }

        // POST api/<SportsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSportCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<SportsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateSportCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<SportsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteSportCommand { Id = id });
        }
    }
}
