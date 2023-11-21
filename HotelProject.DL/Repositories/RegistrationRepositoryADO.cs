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

        public List<Registration> GetAllRegistrations()
        {
            try
            {
                List<Registration> registrations = new List<Registration>();
                string query = "SELECT r.id AS registrationId, c.id AS customerId, c.name AS customerName, c.email AS customerEmail, c.phone AS customerPhone, c.address AS customerAddress, " +
                               "a.id AS activityId, a.name AS activityName, a.description AS activityDescription, a.startdate AS activityStartDate, a.duration AS activityDuration, " +
                               "a.availableplaces AS activityAvailablePlaces, a.costadult AS activityCostAdult, a.costchild AS activityCostChild, a.discount AS activityDiscount, a.location AS activityLocation, " +
                               "r.numadults, r.numchildren " +
                               "FROM Registration r " +
                               "JOIN Customer c ON r.customerid = c.id " +
                               "JOIN Activity a ON r.activityid = a.id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int registrationId = (int)reader["registrationId"];
                        int customerId = (int)reader["customerId"];
                        string customerName = (string)reader["customerName"];
                        string customerEmail = (string)reader["customerEmail"];
                        string customerPhone = (string)reader["customerPhone"];
                        string customerAddress = (string)reader["customerAddress"];
                        int numAdults = (int)reader["numadults"];
                        int numChildren = (int)reader["numchildren"];

                        int activityId = (int)reader["activityId"];
                        string activityName = (string)reader["activityName"];
                        string activityDescription = (string)reader["activityDescription"];
                        DateTime activityStartDate = (DateTime)reader["activityStartDate"];
                        int activityDuration = (int)reader["activityDuration"];
                        int activityAvailablePlaces = (int)reader["activityAvailablePlaces"];
                        decimal activityCostAdult = (decimal)reader["activityCostAdult"];
                        decimal activityCostChild = (decimal)reader["activityCostChild"];
                        decimal activityDiscount = (reader["activityDiscount"] != DBNull.Value) ? (decimal)reader["activityDiscount"] : 0;
                        string activityLocation = (string)reader["activityLocation"];

                        // Create Registration using constructor with customer and member details
                        Registration registration = new Registration(
                            registrationId,
                            new Customer(customerName,customerId, new ContactInfo(customerEmail, customerPhone, new Address(customerAddress))),
                            new Activity(
                                activityId,
                                activityName,
                                activityDescription,
                                activityStartDate,
                                activityDuration,
                                activityAvailablePlaces,
                                activityCostAdult,
                                activityCostChild,
                                activityDiscount,
                                activityLocation
                            ), numAdults,
                            numChildren
                        );

                        registrations.Add(registration);
                    }
                }

                return registrations;
            }
            catch (Exception ex)
            {
                throw new RegistrationRepositoryException("GetAllRegistrations failed", ex);
            }
        }




    }
}
