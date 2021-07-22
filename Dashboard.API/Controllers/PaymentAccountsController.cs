using Dashboard.Application.PaymentAccounts.Commands;
using Dashboard.Application.PaymentAccounts.Queries;
using Dashboard.Application.PaymentAccounts.ViewModels;
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
    public class PaymentAccountsController : ApiController
    {
        // GET: api/<PaymentAccountsController>
        [HttpGet]
        public async Task<IList<PaymentAccountVM>> Get()
        {
            return await Mediator.Send(new GetPaymentAccountsQuery());
        }

        // GET api/<PaymentAccountsController>/5
        [HttpGet("{id}")]
        public async Task<PaymentAccountVM> Get(int id)
        {
            return await Mediator.Send(new GetPaymentAccountQuery(id));
        }

        // POST api/<PaymentAccountsController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePaymentAccountCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<PaymentAccountsController>
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(int id, UpdatePaymentAccountCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        // DELETE api/<PaymentAccountsController>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new DeletePaymentAccountCommand { Id = id });
        }
    }
}
