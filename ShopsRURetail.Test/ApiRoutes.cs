using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRURetail.Test
{
    public static class ApiRoutes
    {
        public static class Invoice
        {
            private static readonly string invoiceControllerUrl = "api/invoices";
            public static readonly string CreateInvoice = invoiceControllerUrl;
        }
    }
}
