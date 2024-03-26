using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;

namespace HotelProject.Repository
{
    public class ManagerRepository
    {
        public List<Manager> GetManagers()
        {
            List<Manager> result = new List<Manager>();
            const string sqlExpression = "SELECT * FROM Managers";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection))
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Manager data = new Manager
                            {
                                Id = reader.GetInt32(0),
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : null
                            };

                            result.Add(data);
                        }
                    }
                }
            }
            return result;
        }

        public void AddManager(Manager manager)
        {
            const string sqlExpression = "INSERT INTO DOITHotel_BCTFO.dbo.Managers(FirstName, LastName) Values (@FirstName, @LastName)";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", manager.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", manager.LastName ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateManager(Manager manager)
        {
            const string sqlExpression = "UPDATE DOITHotel_BCTFO.dbo.Managers SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", manager.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", manager.LastName ?? (object)DBNull.Value);
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
            const string sqlExpression = "DELETE FROM DOITHotel_BCTFO.dbo.Managers WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(ApplicationDBContext.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
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
