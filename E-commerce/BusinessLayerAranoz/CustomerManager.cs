using DataLayerSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model.Model;

namespace BusinessLayerAranoz
{
   public static class CustomerManager
    {
        public static long AddNewCustomer(CustomerInformation productitems)
        {
            CustomerSqlProvider provider = new CustomerSqlProvider();
            var productid = provider.AddNewCustomer(productitems);
            return productid;
        }
    }
}
