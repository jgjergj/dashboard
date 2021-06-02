using Dashboard.Application.Statuses.Commands;
using Dashboard.Application.Statuses.Queries;
using Dashboard.Application.Statuses.ViewModels;
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
    public class StatusesController : ApiController
    {
        // GET: api/<StatusesController>
        [HttpGet]
        public async Task<IList<StatusVM>> Get()
        {
            return await Mediator.Send(new GetStatusesQuery());
        }

        // GET api/<StatusesController>/5
        [HttpGet("{id}")]
        public async Task<StatusVM> Get(int id)
        {
            return await Mediator.Send(new GetStatusQuery(id));
        }

        // POST api/<StatusesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStatusCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<StatusesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<StatusesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteStatusCommand { Id = id });
        }
    }
}
