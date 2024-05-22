using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineForm.DbActions.SQLCommands;
using System.Data.SqlClient;
using System.Data;
using OnlineForm.DbActions.Entity;

namespace OnlineForm.DbActions.Repo
{
    public class UserRepository
    {
        private readonly Commands _sqlCommands;
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
            _sqlCommands = new Commands();
        }
        public int CreateUser(string firstName, string lastName, string email, string password)
        {
            string firstNamePlaceholder = $"@{nameof(firstName)}";
            string lastNamePlaceholder = $"@{nameof(lastName)}";
            string emailPlaceholder = $"@{nameof(email)}";
            string passwordPlaceholder = $"@{nameof(password)}";

            string commandText = _sqlCommands.CreateUser(firstNamePlaceholder, lastNamePlaceholder, emailPlaceholder, passwordPlaceholder);

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.Add(firstNamePlaceholder, SqlDbType.VarChar);
                command.Parameters[firstNamePlaceholder].Value = firstName;

                command.Parameters.Add(lastNamePlaceholder, SqlDbType.VarChar);
                command.Parameters[lastNamePlaceholder].Value = lastName;

                command.Parameters.Add(emailPlaceholder, SqlDbType.VarChar);
                command.Parameters[emailPlaceholder].Value = email;

                command.Parameters.Add(passwordPlaceholder, SqlDbType.VarChar);
                command.Parameters[passwordPlaceholder].Value = password;

                try
                {
                    sqlConnection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        public User GetUserById(int id)
        {
            string idPlaceholder = $"@{nameof(id)}";

            string commandText = _sqlCommands.GetUserById(idPlaceholder);

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.Add(idPlaceholder, SqlDbType.Int);
                command.Parameters[idPlaceholder].Value = id;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    return new User()
                    {
                        Id = (int)reader[0],
                        FirstName = (string)reader[1],
                        LastName = (string)reader[2],
                        Email = (string)reader[3],
                        Password = (string)reader[4]
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public User GetUserByNameAndPasswordAndEmail(int id)
        {
            string idPlaceholder = $"@{nameof(id)}";

            string commandText = _sqlCommands.GetUserById(idPlaceholder);

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.Add(idPlaceholder, SqlDbType.Int);
                command.Parameters[idPlaceholder].Value = id;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    return new User()
                    {
                        Id = (int)reader[0],
                        FirstName = (string)reader[1],
                        LastName = (string)reader[2],
                        Email = (string)reader[3],
                        Password = (string)reader[4]
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public int UpdateUser(string firstName, string lastName, string password)
        {
            string firstNamePlaceholder = $"@{nameof(firstName)}";
            string lastNamePlaceholder = $"@{nameof(lastName)}";
            string passwordPlaceholder = $"@{nameof(password)}";

            string commandText = _sqlCommands.UpdateUser(firstNamePlaceholder, lastNamePlaceholder, passwordPlaceholder);

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);
                command.Parameters.Add(firstNamePlaceholder, SqlDbType.VarChar);
                command.Parameters[firstNamePlaceholder].Value = firstName;

                command.Parameters.Add(lastNamePlaceholder, SqlDbType.VarChar);
                command.Parameters[lastNamePlaceholder].Value = lastName;

                command.Parameters.Add(passwordPlaceholder, SqlDbType.VarChar);
                command.Parameters[passwordPlaceholder].Value = password;

                try
                {
                    sqlConnection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
