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
    public class MemberRepositoryADO : IMemberRepository
    {
        private string _connectionString;
        public MemberRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddMember(Member member, int customerid)
        {
            string query = "INSERT INTO Member(Name, BirthDay, CustomerId,status) VALUES (@Name, @BirthDay, @CustomerId,@status)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@BirthDay", new DateTime(member.BirthDay.Year,member.BirthDay.Month,member.BirthDay.Day));
                command.Parameters.AddWithValue("@CustomerId", customerid);
                command.Parameters.AddWithValue("@status", 1);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteMember(Member member, int customerid)
        {
            string query = "DELETE FROM Member WHERE CustomerId = @CustomerId AND Name=@Name";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@CustomerId", customerid);
                command.ExecuteNonQuery();
            }
            
        }

        public void UpdateMember(Member member, int customerid, string name)
        {
            string query = "UPDATE Member SET Name = @Name, BirthDay = @BirthDay WHERE CustomerId = @CustomerId AND Name=@oldname";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@oldname", name);
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@BirthDay", new DateTime(member.BirthDay.Year, member.BirthDay.Month, member.BirthDay.Day));
                command.Parameters.AddWithValue("@CustomerId", customerid);
                command.ExecuteNonQuery();
            }
        }
    }
}
