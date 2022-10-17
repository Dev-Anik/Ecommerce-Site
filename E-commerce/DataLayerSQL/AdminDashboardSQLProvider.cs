using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Utility;

namespace DataLayerSQL
{
    public class AdminDashboardSQLProvider
    {
        public int CountTotalProduct()
        {
            int TotalProduct = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                long id = 0;
                SqlCommand command = new SqlCommand("SELECT COUNT(ProductId) FROM product; ", connection);
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open();
                    TotalProduct = (Int32)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return TotalProduct;
            }
        }
        //public int CountTotalOrder()
        //{
        //    int TotalProduct = 0;
        //    using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
        //    {
        //        long id = 0;
        //        SqlCommand command = new SqlCommand("SELECT COUNT(ProductId) FROM product; ", connection);
        //        command.CommandType = CommandType.Text;
        //        try
        //        {
        //            connection.Open();
        //            TotalProduct = command.ExecuteNonQuery();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Exception Adding Data. " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }

        //        return TotalProduct;
        //    }
        //}

        public int CountTotalCustomer()
        {
            int TotalCustomer = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                long id = 0;
                SqlCommand command = new SqlCommand("SELECT COUNT(CustomerId) FROM Customer; ", connection);
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open();
                    TotalCustomer = (Int32)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return TotalCustomer;
            }
        }
    }
}
