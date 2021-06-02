using Dashboard.Application.Currencies.Commands;
using Dashboard.Application.Currencies.Queries;
using Dashboard.Application.Currencies.ViewModels;
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
    public class CurrenciesController : ApiController
    {
        // GET: api/<CurrenciesController>
        [HttpGet]
        public async Task<IList<CurrencyVM>> Get()
        {
            return await Mediator.Send(new GetCurrenciesQuery());
        }

        // GET api/<CurrenciesController>/5
        [HttpGet("{id}")]
        public async Task<CurrencyVM> Get(int id)
        {
            return await Mediator.Send(new GetCurrencyQuery(id));
        }

        // POST api/<CurrenciesController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCurrencyCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<CurrenciesController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdateCurrencyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<CurrenciesController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeleteCurrencyCommand { Id = id });
        }
    }
}
