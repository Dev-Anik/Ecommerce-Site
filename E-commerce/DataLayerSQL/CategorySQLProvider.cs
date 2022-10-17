using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model;
using  Aranoz.Model.Model;
using System.Data.SqlClient;
using Aranoz.Utility;

namespace DataLayerSQL
{
    public class CategorySQLProvider
    {
        public  long AddNewCategory(CategoryModel category)
        {
            using (SqlConnection connection= new SqlConnection(ConnectionStringProvider.Connection))
            {
                long id = 0;
                SqlCommand command = new SqlCommand("Insert into Category values(@CategoryName)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CategoryName", category.CategorName);
                try
                {
                    connection.Open();
                    id = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return id;
            }
        }

        public List<CategoryModel> ViewAllCategory()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = new SqlCommand("Select * from Category", connection);
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open();
                    SqlDataReader list = command.ExecuteReader();
                    List<CategoryModel> categoryList = new List<CategoryModel>();
                    foreach (var item in list)
                    {
                        CategoryModel category = new CategoryModel();
                        category.CategoryId = (int)list["CategoryId"];
                        category.CategorName = (string)list["CategoryName"];
                        categoryList.Add(category);
                    }

                    return categoryList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public bool UpdateCategory(CategoryModel category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand("update Category set CategoryName=@CategoryName where CategoryId=@CategoryId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                command.Parameters.AddWithValue("@CategoryName", category.CategorName);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    updated = false;
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return updated;
            }
        }
        public CategoryModel GetSingleCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = new SqlCommand("Select * from Category where CategoryId=@CategoryId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CategoryId", id);
                try
                {
                    connection.Open();
                    SqlDataReader list=command.ExecuteReader();
                    CategoryModel category = new CategoryModel();
                    foreach (var item in list)
                    {
                        category.CategoryId = (int)list["CategoryId"];
                        category.CategorName = (string)list["CategoryName"];
                    }
                    return category;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        public bool DeleteCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                bool deleted = true;
                SqlCommand command = new SqlCommand("Delete Category where CategoryId=@CategoryId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CategoryId", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    deleted = false;
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return deleted;
            }
        }
    }
}
