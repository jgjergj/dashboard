using CleanApp.Application.Ivoices.ViewModels;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanApp.Application.Ivoices.Validators
{
    public class MustHaveInvoiceItemPropertyValidator: PropertyValidator
    {
        protected override string GetDefaultMessageTemplate()
        {
            return "Property {PropertyName} should not be an empty list.";
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return context.PropertyValue is IList<InvoiceItemVM> list && list.Any();
        }
    }
}
