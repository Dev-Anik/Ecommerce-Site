using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model;
using Aranoz.Model.Model;
using System.Data.SqlClient;
using Aranoz.Utility;

namespace DataLayerSQL
{
    public class ProductSQLProvider
    {
        public int AddNewProduct(ProductModel products)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                int id = 0;
                SqlCommand command = new SqlCommand("Insert into Product values(@ProductName,@ProductPrice,@ProductImage,@ProductDetails,@CategoryId,@TotalProduct)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ProductName", products.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", products.ProductPrice);
                command.Parameters.AddWithValue("@ProductImage", products.ProductImage);
                command.Parameters.AddWithValue("@ProductDetails", products.ProductDetails);
                command.Parameters.AddWithValue("@CategoryId", products.CategoryId);
                command.Parameters.AddWithValue("@TotalProduct", products.TotalProduct);
                try
                {
                    connection.Open();
                    id = command.ExecuteNonQuery();
                    return id;
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
        public List<ProductModel> CheckProductDetails()
        {
            using (SqlConnection conncetion = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = new SqlCommand("SELECT  Category.CategoryName,Product.ProductId, Product.ProductName,Product.ProductPrice, Product.ProductImage,Product.ProductDetails,Product.TotalProduct FROM Product INNER JOIN Category ON Product.CategoryId = Category.CategoryId; ", conncetion);
                command.CommandType = CommandType.Text;
                try
                {
                    conncetion.Open();
                    SqlDataReader list = command.ExecuteReader();
                    List<ProductModel> Products = new List<ProductModel>();
                    foreach (var item in list)
                    {
                        ProductModel product = new ProductModel();
                        product.ProdutID = (int)list["ProductId"];
                        product.ProductName = (string)list["ProductName"];
                        product.ProductImage = (string)list["ProductImage"];
                        product.ProductDetails = (string)list["ProductDetails"];
                        product.ProductPrice = (int)list["ProductPrice"];
                        product.CategoryName = (string)list["CategoryName"];
                        product.TotalProduct = (int)list["TotalProduct"];
                        Products.Add(product);
                    }
                    return Products;
                }
                catch (Exception e)
                {
                    throw new Exception("Message" + e);
                }
                finally
                {
                    conncetion.Close();
                }
            }
        }
        public bool UpdateProduct(ProductModel products)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand("Update set ProductName=@ProductName,ProductPrice=@ProductPrice,ProductImage=@ProductImage,ProductDetails=@ProductDetails,CategoryId=@CategoryId,ProductQuantity=@ProductQuantity,TotalProduct=@TotalProduct where ProductId=@ProductId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ProductName", products.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", products.ProductPrice);
                command.Parameters.AddWithValue("@ProductImage", products.ProductImage);
                command.Parameters.AddWithValue("@ProductDetails", products.ProductDetails);
                command.Parameters.AddWithValue("@CategoryId", products.CategoryId);
                command.Parameters.AddWithValue("@ProductId", products.ProdutID);
                command.Parameters.AddWithValue("@TotalProduct", products.TotalProduct);
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

        public bool DeleteProduct(int id)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                bool deleted = true;
                SqlCommand command = new SqlCommand("delete from product where ProductId=@ProductId", Connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ProductId", id);
                try
                {
                    Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    deleted = false;
                    throw new Exception("Message" + ex);
                 
                }
                finally
                {
                    Connection.Close();
                }
                return deleted;
            }
        }

        public ProductModel GetSingleProduct(int id)
        {
            using (SqlConnection conncetion = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = new SqlCommand("select * from product where ProductId=@ProductId", conncetion);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ProductId", id);
                try
                {
                    conncetion.Open();
                    SqlDataReader list = command.ExecuteReader();
                    ProductModel product = new ProductModel();
                    foreach (var item in list)
                    {
                        product.ProdutID = (int)list["ProductId"];
                        product.ProductName = (string)list["ProductName"];
                        product.ProductImage = (string)list["ProductImage"];
                        product.ProductDetails = (string)list["ProductDetails"];
                        product.ProductPrice = (int)list["ProductPrice"];
                        product.CategoryId = (int)list["CategoryId"];
                        product.TotalProduct = (int)list["TotalProduct"];
                    }

                    return product;
                }
                catch (Exception e)
                {
                    throw new Exception("Message" + e);
                }
                finally
                {
                    conncetion.Close();
                }
            }
        }
        public List<ProductModel> SearchByCategoryDetails(int id)
        {
            using (SqlConnection conncetion = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = new SqlCommand("SELECT  Category.CategoryName,Product.ProductId, Product.ProductName,Product.ProductPrice, Product.ProductImage,Product.ProductDetails FROM Product INNER JOIN Category ON Product.CategoryId = @Category; ", conncetion);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CategoryId", id);
                try
                {
                    conncetion.Open();
                    SqlDataReader list = command.ExecuteReader();
                    List<ProductModel> Products = new List<ProductModel>();
                    foreach (var item in list)
                    {
                        ProductModel product = new ProductModel();
                        product.ProdutID = (int)list["ProductId"];
                        product.ProductName = (string)list["ProductName"];
                        product.ProductImage = (string)list["ProductImage"];
                        product.ProductDetails = (string)list["ProductDetails"];
                        product.ProductPrice = (int)list["ProductPrice"];
                        product.CategoryName = (string)list["CategoryName"];
                        product.TotalProduct = (int)list["TotalProduct"];
                        Products.Add(product);
                    }
                    return Products;
                }
                catch (Exception e)
                {
                    throw new Exception("Message" + e);
                }
                finally
                {
                    conncetion.Close();
                }
            }
        }

    }
}
