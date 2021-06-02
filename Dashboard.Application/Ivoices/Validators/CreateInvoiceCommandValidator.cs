using Dashboard.Application.Ivoices.Commands;
using Dashboard.Application.Ivoices.ViewModels;
using FluentValidation;
using System.Collections.Generic;

namespace Dashboard.Application.Ivoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(v => v.AmountPaid).NotNull();
            RuleFor(v => v.Date).NotNull();
            RuleFor(v => v.From).NotEmpty().MinimumLength(3);
            RuleFor(v => v.To).NotEmpty().MinimumLength(3);
            RuleFor(v => v.InvoiceItems).NotNull().SetValidator(new MustHaveInvoiceItemPropertyValidator<CreateInvoiceCommand, IList<InvoiceItemVM>>());
        }
    }
}
