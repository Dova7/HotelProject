﻿using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelProject.Repository
{
    public class HotelRepository
    {
        public async Task<List<Hotel>> GetHotels()
        {
            List<Hotel> result = new List<Hotel>();
            const string sqlExpression = "GetAllHotels";

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
                                Hotel data = new Hotel
                                {
                                    Id = reader.GetInt32(0),
                                    HotelName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                    Country = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                                    City = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                                    PhysicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : null,
                                };
                                result.Add(data);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task AddHotel(Hotel hotel)
        {
            const string sqlExpression = "AddHotel";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@HotelName", hotel.HotelName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rating", hotel.Rating ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", hotel.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", hotel.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhysicalAddress", hotel.PhysicalAddress ?? (object)DBNull.Value);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task UpdateHotel(Hotel hotel)
        {
            const string sqlExpression = "UpdateHotel";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@HotelName", hotel.HotelName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rating", hotel.Rating ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", hotel.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", hotel.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhysicalAddress", hotel.PhysicalAddress ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", hotel.Id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No hotel found with the specified ID.");
                    }
                }
            }
        }
        public async Task DeleteHotel(int id)
        {
            const string sqlExpression = "DeleteHotel";

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
                        throw new InvalidOperationException("No hotel found with the specified ID.");
                    }
                }
            }
        }
        public async Task<List<Hotel>> GetHotelsWithoutManager()
        {
            List<Hotel> result = new List<Hotel>();
            const string sqlExpression = "GetHotelsWithoutManager";
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
                                Hotel data = new Hotel
                                {
                                    Id = reader.GetInt32(0),
                                    HotelName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                    Country = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                                    City = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                                    PhysicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : null,
                                };
                                result.Add(data);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task<Hotel> GetHotelById(int id)
        {
            Hotel result = new Hotel();
            const string sqlExpression = "GetHotelByID";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Hotel data = new Hotel
                                {
                                    Id = reader.GetInt32(0),
                                    HotelName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                    Country = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                                    City = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                                    PhysicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : null,
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
