using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanApp.Application.Ivoices.ViewModels
{
    public class InvoiceItemVM
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount
        {
            get
            {
                return Quantity * Rate;
            }
        }
    }
}
