using Epam.ListUsers.DAL.Abstract;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Epam.ListUsers.DAL.SQLServer
{
    public class UsersDao : IUsersDao
    {
        private string connectionString;
        public UsersDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["UsersAndAwards"].ConnectionString;
        }

        public bool Add(User user)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.Users ([Id], [Name], [DateOfBirth]) VALUES (@Id, @Name, @DateOfBirth)", connect);
                command.Parameters.Add(new SqlParameter("@Id", user.Id.ToString()));
                command.Parameters.Add(new SqlParameter("@Name", user.Name));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", user.DateOfBirth.Date));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public User GetById(Guid id)
        {
            User user = null;
            using(var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [DateOfBirth] FROM dbo.Users WHERE [Id]=@Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", id.ToString()));

                connect.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User(
                        (string)reader["Name"],
                        (DateTime)reader["DateOfBirth"])
                        {
                            Id = Guid.Parse((string)reader["Id"])
                        };
                }
            }
            if (user != null)
            {
                user.Awards = AwardsOfUser(id);
                return user;
            }
            throw new ArgumentException("User with such Id is not exist");
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using(var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [DateOfBirth] FROM dbo.Users", connect);

                connect.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User(
                        (string)reader["Name"],
                        (DateTime)reader["DateOfBirth"])
                        {
                            Id = Guid.Parse((string)reader["Id"])
                        });
                }
            }
            return users;
        }

        public bool Edit(User newUser)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.Users SET Name = @Name, DateOfBirth = @DateOfBirth WHERE Id = @Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", newUser.Id.ToString()));
                command.Parameters.Add(new SqlParameter("@Name", newUser.Name));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", newUser.DateOfBirth.Date));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool Remove(User user)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.Users WHERE Id = @Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", user.Id.ToString()));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool ToAward(User user, Award award)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.Relations ([IdUser], [IdAward]) VALUES (@IdUser, @IdAward)", connect);
                command.Parameters.Add(new SqlParameter("@IdUser", user.Id.ToString()));
                command.Parameters.Add(new SqlParameter("@IdAward", award.Id.ToString()));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool ReAward(User user, Award award)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.Relations WHERE IdUser = @IdUser, IdAward = @IdAward", connect);
                command.Parameters.Add(new SqlParameter("@IdUser", user.Id.ToString()));
                command.Parameters.Add(new SqlParameter("@IdAward", award.Id.ToString()));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public void SetImage(Guid id, HttpPostedFileBase file)
        {
            byte[] image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, image.Length);

            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.ImagesOfUsers ([IdUser], [ImageOfUser]) VALUES (@IdUser, @ImageOfUser)", connect);
                command.Parameters.Add(new SqlParameter("@IdUser", id.ToString()));
                command.Parameters.Add(new SqlParameter("@ImageOfUser", image));

                connect.Open();
                command.ExecuteNonQuery();
            }
        }

        public byte[] GetImage(Guid id)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                string PuthToDefaultImageForUsers = ConfigurationManager.AppSettings["PathForDefaultImageOfUsers"];
                var command = new SqlCommand("SELECT [ImageOfUser] FROM dbo.ImagesOfUsers WHERE IdUser = @Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", id.ToString()));

                connect.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return (byte[])reader["ImageOfUser"];
                }
                else
                {
                    return File.ReadAllBytes(PuthToDefaultImageForUsers);
                }
            }
        }

        private List<Award> AwardsOfUser(Guid id)
        {
            var awards = new List<Award>();
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Title] FROM dbo.Awards as a JOIN dbo.Relations as r ON a.Id = r.IdAward WHERE r.IdUser = @IdUser", connect);
                command.Parameters.Add(new SqlParameter("@IdUser", id.ToString()));

                connect.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award((string)reader["Title"])
                        {
                            Id = Guid.Parse((string)reader["Id"])
                        });
                }
            }
            return awards;
        }


        public bool EditImage(Guid id, HttpPostedFileBase file)
        {
            byte[] image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, image.Length);

            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.ImagesOfUsers SET ImageOfUser = @ImageOfUser WHERE IdUser = @IdUser", connect);
                command.Parameters.Add(new SqlParameter("@IdUser", id.ToString()));
                command.Parameters.Add(new SqlParameter("@ImageOfUser", image));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}
