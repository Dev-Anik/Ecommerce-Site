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
        public static long AddNewCustomer(CustomerInformation customer)
        {
            CustomerSqlProvider provider = new CustomerSqlProvider();
            var productid = provider.AddNewCustomer(customer);
            return productid;
        }
        public static List<CustomerInformation> GetAllCustomerList()
        {
            CustomerSqlProvider provider = new CustomerSqlProvider();
            var TotalCustomer = provider.GetAllCustomerDetails();
            return TotalCustomer;
        }
    }
}
