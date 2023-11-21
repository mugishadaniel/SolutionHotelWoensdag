using HotelProject.BL.Interfaces;
using HotelProject.BL.Model;
using HotelProject.DL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DL.Repositories
{
    public class RegistrationRepositoryADO : IRegistrationRepository
    {
        private string connectionString;
        public RegistrationRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddRegistration(Registration registration)
        {
            try
            {
                string query = "INSERT INTO Registration (activityid,customerid,numadults,numchildren,totalcost) VALUES (@ActivityId, @CustomerId, @NumAdults,@NumChildren,@TotalCost)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerId", registration.Customer.Id);
                    command.Parameters.AddWithValue("@ActivityId", registration.Activity.Id);
                    command.Parameters.AddWithValue("@NumAdults", registration.NumberOfAdults);
                    command.Parameters.AddWithValue("@NumChildren", registration.NumberOfChildren);
                    command.Parameters.AddWithValue("@TotalCost", registration.Price);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new RegistrationRepositoryException("AddRegistration failed", ex);
            }
        }
    }
}
