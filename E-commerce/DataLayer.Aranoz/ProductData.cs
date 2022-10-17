using Aranoz.Model;
using Aranoz.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Aranoz
{
   public class ProductData
    {
        public List<ProductModel> GetAllProduct()
        {
            List<ProductModel> allProducts = new List<ProductModel>();

            using (SqlConnection connection=new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "spGetProducts";
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dbProducts = new DataTable();

                connection.Open();
                sqlData.Fill(dbProducts);
                connection.Close();


                foreach(DataRow dr in dbProducts.Rows)
                {
                    allProducts.Add(new ProductModel
                    {
                        ProdutID=Convert.ToInt32(dr["ProductID"]),
                        ProductName=dr["ProductName"].ToString(),
                        ProductDetails = dr["ProductDetails"].ToString(),
                        ProductPrice=Convert.ToInt32(dr["ProductPrice"]),
                        ProductImage= dr["ProductImage"].ToString(),

                    });
                }

                return allProducts;

            }
        }
    }
}
