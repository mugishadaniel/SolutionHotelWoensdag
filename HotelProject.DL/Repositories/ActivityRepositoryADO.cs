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
    public class ActivityRepositoryADO : IActivityRepository
    {
        private string connectionString;

        public ActivityRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddActivity(Activity activity)
        {
            try
            {
                string query = "INSERT INTO Activity (Name, Description, Location, Startdate, Duration, AvailablePlaces, CostAdult, CostChild,Discount)\r\nVALUES (@Name, @Description, @Location, @Date, @Duration, @AvailablePlaces, @PriceAdult, @PriceChild,@Discount);";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        cmd.CommandText = query;
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@Name", activity.Name);
                        cmd.Parameters.AddWithValue("@Description", activity.Description);
                        cmd.Parameters.AddWithValue("@Location", activity.Location);
                        cmd.Parameters.AddWithValue("@Date", activity.Date);
                        cmd.Parameters.AddWithValue("@Duration", activity.Duration);
                        cmd.Parameters.AddWithValue("@AvailablePlaces", activity.AvailablePlaces);
                        cmd.Parameters.AddWithValue("@PriceAdult", activity.PriceAdult);
                        cmd.Parameters.AddWithValue("@PriceChild", activity.PriceChild);
                        if(activity.Discount == null)
                        {
                            cmd.Parameters.AddWithValue("@Discount", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Discount", activity.Discount);
                        }
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ActivityRepositoryException(ex.Message);
            }

        }

        public List<Activity> GetActivities(string filter)
        {
            try
            {
                Dictionary<int, Activity> activities = new Dictionary<int, Activity>();
                string sql;
                if (string.IsNullOrEmpty(filter))
                {
                    sql = "select * from Activity";
                }
                else
                {
                    sql = "select * from Activity where Name like @filter";
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@filter", $"%{filter}%");
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            if (!activities.ContainsKey(id)) //member toevoegen
                            {
                                //first see if it contains a discount
                                if (reader["Discount"] == DBNull.Value)
                                {
                                    activities.Add(id, new Activity(id, reader["Name"].ToString(), reader["Description"].ToString(), Convert.ToDateTime(reader["Startdate"]), Convert.ToInt32(reader["Duration"]), Convert.ToInt32(reader["AvailablePlaces"]), Convert.ToDecimal(reader["CostAdult"]), Convert.ToDecimal(reader["CostChild"]),0, reader["Location"].ToString()));
                                }
                                else
                                {
                                    activities.Add(id, new Activity(id, reader["Name"].ToString(), reader["Description"].ToString(), Convert.ToDateTime(reader["Startdate"]), Convert.ToInt32(reader["Duration"]), Convert.ToInt32(reader["AvailablePlaces"]), Convert.ToDecimal(reader["CostAdult"]), Convert.ToDecimal(reader["CostChild"]), Convert.ToDecimal(reader["Discount"]), reader["Location"].ToString()));
                                }
                            }
                        }
                    conn.Close();
                    return activities.Values.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ActivityRepositoryException(ex.Message);
            }
        }

        public void UpdateActivityAvailableSeats(Activity activity,int seatstaken)
        {
            try
            {

                string query = "UPDATE Activity SET AvailablePlaces = @AvailablePlaces WHERE ID = @ID";               
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        cmd.CommandText = query;
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@AvailablePlaces", activity.AvailablePlaces - seatstaken);
                        cmd.Parameters.AddWithValue("@ID", activity.Id);
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ActivityRepositoryException(ex.Message);
            }
        }
    }
}
