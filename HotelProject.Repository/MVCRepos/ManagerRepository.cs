using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelProject.Repository.MVCRepos
{
    public class ManagerRepository : IManagerRepository
    {
        public async Task<List<Manager>> GetManagers()
        {
            List<Manager> result = new List<Manager>();
            const string sqlExpression = "GetAllManagers";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Manager data = new Manager
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    SecondName = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                                    HotelId = !reader.IsDBNull(3) ? reader.GetInt32(3) : null
                                };
                                result.Add(data);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public async Task AddManager(Manager manager)
        {
            const string sqlExpression = "AddManager";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstName", manager.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@secondName", manager.SecondName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@hotelId", manager.HotelId ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task UpdateManager(Manager manager)
        {
            const string sqlExpression = "UpdateManager";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@firstName", manager.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@secondName", manager.SecondName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HotelId", manager.HotelId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", manager.Id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No manager found with the specified ID.");
                    }
                }
            }
        }
        public async Task DeleteManager(int id)
        {
            const string sqlExpression = "DeleteManager";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No manager found with the specified ID.");
                    }
                }
            }
        }
        public async Task<Manager> GetManagerById(int id)
        {
            Manager result = new Manager();
            const string sqlExpression = "GetManagerByID";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"@id", id);
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Manager data = new Manager
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    SecondName = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                                    HotelId = !reader.IsDBNull(3) ? reader.GetInt32(3) : null
                                };
                                result = data;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}