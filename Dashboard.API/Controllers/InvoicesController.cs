﻿using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Ivoices.Commands;
using Dashboard.Application.Ivoices.Queries;
using Dashboard.Application.Ivoices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.API.Controllers
{
    //[Authorize]
    //public class InvoicesController : ApiController
    //{
    //    private readonly ICurrentUserService _currentUser;

    //    public InvoicesController(ICurrentUserService currentUser)
    //    {
    //        _currentUser = currentUser;
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<int>> Create(CreateInvoiceCommand command)
    //    {
    //        return await Mediator.Send(command);
    //    }

    //    [HttpGet]
    //    public async Task<IList<InvoiceVM>> Get()
    //    {
    //        return await Mediator.Send(new GetUserInvoicesQuery { User = _currentUser.UserId });
    //    }
    //}
}
