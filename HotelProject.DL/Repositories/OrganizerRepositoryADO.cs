using HotelProject.BL.Exceptions;
using HotelProject.BL.Interfaces;
using HotelProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DL.Repositories
{
    public class OrganizerRepositoryADO : IOrganizerRepository
    {
        private string _connectionString;
        public OrganizerRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Organizer> GetOrganizers()
        {
            try
            {
                string query = "SELECT * FROM Organizer";
                List<Organizer> organizers = new List<Organizer>();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Organizer organizer = new Organizer
                        (
                            (int)reader["Id"],
                            (string)reader["Name"],
                            new ContactInfo
                            (
                                (string)reader["Email"],
                                (string)reader["Phone"],
                                new Address((string)reader["Address"])
                            )
                        );
                        organizers.Add(organizer);

                    }
                }
                return organizers;
            }
            catch (Exception ex)
            {

                throw new OrganizerException("GetOrganizers failed", ex);   
            }
        }
    }
}
