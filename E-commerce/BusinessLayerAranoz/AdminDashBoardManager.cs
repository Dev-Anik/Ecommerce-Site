using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model;
using DataLayerSQL;

namespace BusinessLayerAranoz
{
    public class AdminDashBoardManager
    {
        public static int TotalProduct()
        {
            AdminDashboardSQLProvider provider = new AdminDashboardSQLProvider();
            var TotalProduct = provider.CountTotalProduct();
            return TotalProduct;
        }
        public static int TotalCustomer()
        {
            AdminDashboardSQLProvider provider = new AdminDashboardSQLProvider();
            var TotalCustomer = provider.CountTotalCustomer();
            return TotalCustomer;
        }
    }
}
