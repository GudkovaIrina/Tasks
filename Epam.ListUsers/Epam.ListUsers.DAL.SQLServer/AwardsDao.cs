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
    public class AwardsDao
    {
        private string connectionString;
        public AwardsDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["UsersAndAwards"].ConnectionString;
        }

        public bool Add(Award award)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.AddAward", connect) 
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@Id", award.Id.ToString()));
                command.Parameters.Add(new SqlParameter("@Title", award.Title));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public Award GetById(Guid id)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Title] FROM dbo.Awards WHERE [Id]=@Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", id.ToString()));

                connect.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Award(
                        (string)reader["Title"])
                    {
                        Id = Guid.Parse((string)reader["Id"])
                    };
                }
            }
            throw new ArgumentException("User with such Id is not exist");
        }

        public List<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Title] FROM dbo.Awards", connect);

                connect.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awards.Add(new Award(
                        (string)reader["Title"])
                    {
                        Id = Guid.Parse((string)reader["Id"])
                    });
                }
            }
            return awards;
        }

        public bool Edit(Award newAward)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.Awards SET Title = @Title WHERE Id = @Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", newAward.Id.ToString()));
                command.Parameters.Add(new SqlParameter("@Title", newAward.Title));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool Remove(Award award)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.RemoveAward", connect)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@Id", award.Id.ToString()));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public List<User> GetAllUsersWithAward(Award award)
        {
            var users = new List<User>();
            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT [Id], [Name], [DateOfBirth] FROM dbo.Users as u JOIN dbo.Relations as r ON u.Id = r.IdUser WHERE r.IdAward = @IdAward", connect);
                command.Parameters.Add(new SqlParameter("@IdAward", award.Id.ToString()));

                connect.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User((string)reader["Name"], (DateTime)reader["DateOfBirth"])
                    {
                        Id = Guid.Parse((string)reader["Id"])
                    });
                }
            }
            return users;
        }

        public void SetImage(Guid id, HttpPostedFileBase file)
        {
            byte[] image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, image.Length);

            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.ImagesOfAwards ([IdAward], [ImageOfAward]) VALUES (@IdAward, @ImageOfAward)", connect);
                command.Parameters.Add(new SqlParameter("@IdAward", id.ToString()));
                command.Parameters.Add(new SqlParameter("@ImageOfAward", image));

                connect.Open();
                command.ExecuteNonQuery();
            }
        }

        public byte[] GetImage(Guid id)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                string PuthToDefaultImageForAwards = ConfigurationManager.AppSettings["PathForDefaultImageOfAwards"];
                var command = new SqlCommand("SELECT [ImageOfAward] FROM dbo.ImagesOfAwards WHERE IdAward = @Id", connect);
                command.Parameters.Add(new SqlParameter("@Id", id.ToString()));

                connect.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return (byte[])reader["ImageOfAward"];
                }
                else
                {
                    return File.ReadAllBytes(PuthToDefaultImageForAwards);
                }
            }
        }

        public bool EditImage(Guid id, HttpPostedFileBase file)
        {
            byte[] image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, image.Length);

            using (var connect = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE dbo.ImagesOfAwards SET ImageOfAward = @ImageOfAward WHERE IdAward = @IdAward", connect);
                command.Parameters.Add(new SqlParameter("@IdAward", id.ToString()));
                command.Parameters.Add(new SqlParameter("@ImageOfAward", image));

                connect.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}
