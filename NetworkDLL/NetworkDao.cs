﻿using Entities;
using INetwork.DLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDLL
{
    public class NetworkDao : INetworkDao
    {
        private string connectionString = "Data Source=DESKTOP-60HJP9E;Initial Catalog=Network;Integrated Security=True";

       

        public void AddFriend(int? IdUser, int? IdFriend)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddFriend", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDUser", IdUser);
                cmd.Parameters.AddWithValue("@IDFriend", IdFriend);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Surname", user.Surname);
                cmd.Parameters.AddWithValue("@Patronymic", user.Patronymic);
                cmd.Parameters.AddWithValue("@YearOfBirth", user.YearOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Town", user.Town);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Login", user.Login);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Friend> GetAllFriends(int? id)
        {
            var result = new List<Friend>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllFriends", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDUser", id);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var f = new Friend
                    {
                        IDUser = (int?)reader["IDFriend"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Patronymic = (string)reader["Patronymic"],
                        Town = (string)reader["Town"],
                        Gender = (bool)reader["Gender"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        TermOfFriend = (DateTime)reader["Term_Friends"],
                    };

                    result.Add(f);
                }
            }
            return result;
        }

        public UserSearch GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessagesByFriend(Friend friend)
        {
            throw new NotImplementedException();
        }

        public string[] GetRoles(string username)
        {
            var result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUsetRoles", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.Add((string)reader["Role"]);
                }
            }
            return result.ToArray();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            foreach (string r in GetRoles(username))
            {
                if (r.Equals(roleName))
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteFriend(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddFriend", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<UserSearch> SearchByName(string Name, int? idUser)
        {
            var result = new List<UserSearch>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllByName", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Id", idUser);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var f = new Friend
                    {
                        IDUser = (int?)reader["IDUser"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Patronymic = (string)reader["Patronymic"],
                        Town = (string)reader["Town"],
                        Gender = (bool)reader["Gender"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        TermOfFriend = (DateTime)reader["Term_Friends"],
                    };
                    result.Add(f);
                }
            }
            return result;
        }

        public IEnumerable<UserSearch> SearchBySurname(string Surname, int? idUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSearch> SearchByTown(string Town, int? idUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSearch> SearchByYearOfBirth(int YearOfBirth, int? idUser)
        {
            throw new NotImplementedException();
        }

        public int SingUp(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Surname", user.Surname);
                cmd.Parameters.AddWithValue("@Patronymic", user.Patronymic);
                cmd.Parameters.AddWithValue("@YearOfBirth", user.YearOfBirth);
                cmd.Parameters.AddWithValue("@Phone", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Town", user.Town);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Login", user.Login);
                var id = new SqlParameter
                {
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@Id",
                    DbType = System.Data.DbType.Int32
                };
                cmd.Parameters.Add(id);

                connection.Open();

                cmd.ExecuteNonQuery();

                return (int)id.Value;
            }
        }

        public Message SendMessage(int userId, int friendId, string message)
        {
            DateTime now = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SendMessage", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDUser", userId);
                cmd.Parameters.AddWithValue("@IDFriend", friendId);
                cmd.Parameters.AddWithValue("@Message", message);
                cmd.Parameters.AddWithValue("@DateOfMessage", now);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
            return new Message(userId, friendId, message, now);
        }

        public User LogIn(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LogIn", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                User u = null;
                if (reader.Read())
                {
                    u = new User
                    {
                        IDUser = (int?)reader["IDUser"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Patronymic = (string)reader["Patronymic"],
                        Town = (string)reader["Town"],
                        Gender = (bool)reader["Gender"],
                        YearOfBirth = (int)reader["YearOfBirth"],
                        PhoneNumber = (string)reader["Phone"]
                    };
                }
                    return u;
            }
        }

    }
}

