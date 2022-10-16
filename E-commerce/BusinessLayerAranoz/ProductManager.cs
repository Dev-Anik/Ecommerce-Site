using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model;
using DataLayerSQL;
using System.IO;
using System.Web;

namespace BusinessLayerAranoz
{
    public class ProductManager
    {
        public static long AddNewProduct(ProductModel productitems)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var productid = provider.AddNewProduct(productitems);
            return productid;
        }
        public static List<ProductModel> CheckProductDetails()
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var productid = provider.CheckProductDetails();
            return productid;
        }
        public static bool UpdateProduct(ProductModel productitems)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var productid = provider.UpdateProduct(productitems);
            return productid;
        }
        public static bool DeleteProduct(int id)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var productid = provider.DeleteProduct(id);
            return productid;
        }
        public static ProductModel GetSingleProduct(int id)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var productid = provider.GetSingleProduct(id);
            return productid;
        }
        public static List<ProductModel> SeachByCategoryProduct(int id)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var productid = provider.SearchByCategoryDetails(id);
            return productid;
        }
    }
}
