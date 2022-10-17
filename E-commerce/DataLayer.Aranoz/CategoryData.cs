using Aranoz.Model;
using Aranoz.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Aranoz
{
    public class CategoryData
    {
        
      //get all category
      public List<CategoryModel> GetCategory()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "spCategoryList";
                SqlDataAdapter sqldata = new SqlDataAdapter(command);
                DataTable dbCategories = new DataTable();

                connection.Open();
                sqldata.Fill(dbCategories);
                connection.Close();

                foreach (DataRow dr in dbCategories.Rows)
                {
                    categories.Add(new CategoryModel
                    {
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        CategorName = dr["CategoryName"].ToString(),

                    });
                }

            }

            return categories;
        }
    }
}
