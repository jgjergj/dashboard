using Dashboard.Application.Companies.Commands;
using Dashboard.Application.Companies.Queries;
using Dashboard.Application.Companies.ViewModels;
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
    public class CompaniesController : ApiController
    {
        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IList<CompanyVM>> Get()
        {
            return await Mediator.Send(new GetCompaniesQuery());
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<CompanyVM> Get(int id)
        {
            return await Mediator.Send(new GetCompanyQuery(id));
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCompanyCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<CompaniesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateCompanyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<CompaniesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteCompanyCommand { Id = id });
        }
    }
}
