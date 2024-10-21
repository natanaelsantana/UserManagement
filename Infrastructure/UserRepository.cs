using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain;

namespace UserManagement.Infrastructure
{
    public class UserRepository
    {
        private const string ConnectionString = "Data Source=users.db";

        public UserRepository()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Execute("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY, Name TEXT, Email TEXT)");
            }
        }

        public void Add(User user)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                var sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
                connection.Execute(sql, user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                return connection.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public User GetById(int id)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                return connection.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
            }
        }

        public void Update(User user)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                var sql = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
                connection.Execute(sql, user);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM Users WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
