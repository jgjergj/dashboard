using CleanApp.Application.Common.Interfaces;
using CleanApp.Application.Ivoices.Commands;
using CleanApp.Application.Ivoices.Queries;
using CleanApp.Application.Ivoices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanApp.API.Controllers
{
    //[Authorize]
    public class InvoicesController : ApiController
    {
        private ICurrentUserService _currentUser;

        public InvoicesController(ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IList<InvoiceVM>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery { User = _currentUser.UserId });
        }
    }
}
