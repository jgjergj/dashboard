using Dashboard.Application.Ivoices.ViewModels;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Ivoices.Validators
{
    public class MustHaveInvoiceItemPropertyValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public override string Name => "MustHaveInvoiceItemPropertyValidator";

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            return value is IList<InvoiceItemVM> list && list.Any();
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return errorCode + ": Property {PropertyName} should not be an empty list.";
        }
    }
}
