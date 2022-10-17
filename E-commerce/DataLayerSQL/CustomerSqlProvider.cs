using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model;
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
                SqlCommand command = new SqlCommand("Insert into Customer values(@CustomerName,@CustomerEmail,@CustomerImage,@CustomerUserName)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CustomerName", customer.FullName);
                command.Parameters.AddWithValue("@CustomerEmail", customer.Email);
                command.Parameters.AddWithValue("@CustomerImage", customer.CustomerImage);
                command.Parameters.AddWithValue("@CustomerUserName", customer.Membership.UserName);
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
        public List<CustomerInformation> GetAllCustomerDetails()
        {
            using (SqlConnection conncetion = new SqlConnection(ConnectionStringProvider.Connection))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Customer ", conncetion);
                command.CommandType = CommandType.Text;
                try
                {
                    conncetion.Open();
                    SqlDataReader list = command.ExecuteReader();
                    List<CustomerInformation> CustomerList = new List<CustomerInformation>();
                    foreach (var item in list)
                    {
                        CustomerInformation customer = new CustomerInformation();
                        customer.CustomerId = (int)list["CustomerId"];
                        customer.CustomerImage = (string)list["CustomerImage"];
                        customer.FullName = (string)list["CustomerName"];
                        customer.Email = (string)list["CustomerEmail"];
                        //customer.Membership.UserName = (string)list["CustomerUserName"];
                        CustomerList.Add(customer);
                    }
                    return CustomerList;
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
