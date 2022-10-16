using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model.Model;
using Aranoz.Utility;

namespace DataLayerSQL
{
   public class CustomerSqlProvider
    {
        public int AddNewCustomer(CustomerInformation customer)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.Connection))
            {
                int id = 0;
                SqlCommand command = new SqlCommand("Insert into Customer values(@CustomerName,@CustomerEmail,@CustomerImage,@MembershipUserid)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CustomerName", customer.FullName);
                command.Parameters.AddWithValue("@CustomerEmail", customer.Email);
                command.Parameters.AddWithValue("@CustomerImage", customer.CustomerImage);
                command.Parameters.AddWithValue("@MembershipUserid", customer.MembershipUserId);
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
    }
}
