using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelProject.Repository
{
    public class HotelRepository
    {
        public List<Hotel> GetHotels()
        {
            List<Hotel> result = new List<Hotel>();
            const string sqlExpression = "GetAllHotels";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Hotel data = new Hotel
                                {
                                    Id = reader.GetInt32(0),
                                    HotelName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                    Country = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                                    City = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                                    PhysicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : null,
                                    ManagerId = !reader.IsDBNull(6) ? reader.GetInt32(6) : null,
                                };
                                result.Add(data);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public void AddHotel(Hotel hotel)
        {
            const string sqlExpression = "AddHotel";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@HotelName", hotel.HotelName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rating", hotel.Rating ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", hotel.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", hotel.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhysicalAddress", hotel.PhysicalAddress ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ManagerId", hotel.ManagerId ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateHotel(Hotel hotel)
        {
            const string sqlExpression = "UpdateHotel";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@HotelName", hotel.HotelName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rating", hotel.Rating ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", hotel.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", hotel.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhysicalAddress", hotel.PhysicalAddress ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("ManagerId", hotel.ManagerId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", hotel.Id);


                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No hotel found with the specified ID.");
                    }
                }
            }
        }
        public void DeleteHotel(int id)
        {
            const string sqlExpression = "DeleteManager";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No hotel found with the specified ID.");
                    }
                }
            }
        }
    }
}
