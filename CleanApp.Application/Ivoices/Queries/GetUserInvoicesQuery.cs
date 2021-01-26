using CleanApp.Application.Ivoices.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CleanApp.Application.Ivoices.Queries
{
    public class GetUserInvoicesQuery: IRequest<IList<InvoiceVM>>
    {
        public string User { get; set; }
    }
}
