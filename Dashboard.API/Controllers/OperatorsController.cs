using Dashboard.Application.Operators.Commands;
using Dashboard.Application.Operators.Queries;
using Dashboard.Application.Operators.ViewModels;
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
    public class OperatorsController : ApiController
    {
        // GET: api/<OperatorsController>
        [HttpGet]
        public async Task<IList<OperatorVM>> Get()
        {
            return await Mediator.Send(new GetOperatorsQuery());
        }

        // GET api/<OperatorsController>/5
        [HttpGet("{id}")]
        public async Task<OperatorVM> Get(int id)
        {
            return await Mediator.Send(new GetOperatorQuery(id));
        }

        // POST api/<OperatorsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateOperatorCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<OperatorsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateOperatorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<OperatorsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteOperatorCommand { Id = id });
        }
    }
}
