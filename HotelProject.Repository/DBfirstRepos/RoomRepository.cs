using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace HotelProject.Repository.MVCRepos
{
    public class RoomRepository : IRoomRepository
    {
        /*
        public async Task<List<Room>> GetRooms()
        {
            List<Room> result = new List<Room>();
            const string sqlExpression = "GetAllRooms";

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
                                Room data = new Room
                                {
                                    Id = reader.GetInt32(0),
                                    RoomName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    IsBooked = !reader.IsDBNull(2) ? reader.GetBoolean(2) : null,
                                    HotelId = !reader.IsDBNull(3) ? reader.GetInt32(3) : null,
                                    PriceGel = !reader.IsDBNull(4) ? reader.GetDouble(4) : null,
                                };
                                result.Add(data);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task AddRoom(Room room)
        {
            const string sqlExpression = "AddRoom";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@roomName", room.RoomName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@isBooked", room.IsBooked ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@hotelId", room.HotelId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@priceGel", room.PriceGel ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task UpdateRoom(Room room)
        {
            const string sqlExpression = "UpdateRoom";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@roomName", room.RoomName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@isBooked", room.IsBooked ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@hotelId", room.HotelId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@priceGel", room.PriceGel ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", room.Id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No room found with the specified ID.");
                    }
                }
            }
        }
        public async Task DeleteRoom(int id)
        {
            const string sqlExpression = "DeleteRoom";

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
                        throw new InvalidOperationException("No room found with the specified ID.");
                    }
                }
            }
        }
        */
        public Task AddAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetAllAsync(Expression<Func<Room, bool>> filter, string? includePropeties = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetAllAsync(string? includePropeties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Room?> GetAsync(Expression<Func<Room, bool>> filter, string? includePropeties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<Room> Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
