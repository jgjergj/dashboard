using Dashboard.Application.Departments.Commands;
using Dashboard.Application.Departments.Queries;
using Dashboard.Application.Departments.ViewModels;
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
    public class DepartmentsController : ApiController
    {
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IList<DepartmentVM>> Get()
        {
            return await Mediator.Send(new GetDepartmentsQuery());
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<DepartmentVM> Get(int id)
        {
            return await Mediator.Send(new GetDepartmentQuery(id));
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateDepartmentCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<DepartmentsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateDepartmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<DepartmentsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteDepartmentCommand { Id = id });
        }
    }
}
