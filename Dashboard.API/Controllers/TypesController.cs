using Dashboard.Application.Types.Commands;
using Dashboard.Application.Types.Queries;
using Dashboard.Application.Types.ViewModels;
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
    public class TypesController : ApiController
    {
        // GET: api/<TypesController>
        [HttpGet]
        public async Task<IList<TypeVM>> Get()
        {
            return await Mediator.Send(new GetTypesQuery());
        }

        // GET api/<TypesController>/5
        [HttpGet("{id}")]
        public async Task<TypeVM> Get(int id)
        {
            return await Mediator.Send(new GetTypeQuery(id));
        }

        // POST api/<TypesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<TypesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<TypesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteTypeCommand { Id = id });
        }
    }
}
