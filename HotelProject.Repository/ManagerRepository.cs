using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelProject.Repository
{
    public class ManagerRepository
    {
        public List<Manager> GetManagers()
        {
            List<Manager> result = new List<Manager>();
            const string sqlExpression = "GetAllManagers";

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
                                Manager data = new Manager
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    SecondName = !reader.IsDBNull(2) ? reader.GetString(2) : null
                                };
                                result.Add(data);
                            }
                        }
                    }
                }                                    
            }
            return result;
        }

        public void AddManager(Manager manager)
        {
            const string sqlExpression = "AddManager";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstName", manager.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@secondName", manager.SecondName ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateManager(Manager manager)
        {
            const string sqlExpression = "UpdateManager";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@firstName", manager.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@secondName", manager.SecondName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", manager.Id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No manager found with the specified ID.");
                    }                    
                }
            }
        }
        public void DeleteManager(int id)
        {
            const string sqlExpression = "DeleteManager";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No manager found with the specified ID.");
                    }
                }
            }
        }

    }
}
