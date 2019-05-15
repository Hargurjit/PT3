using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;

namespace PT3
{
    public class Database
    {
        private string connectionString;
        private string filename;

        public Database(string _filename)
        {
            filename = _filename;
            connectionString = "URI=file:" + filename;
        }

        public void CreateDatabase()
        {
            connectionString = "URI=file:" + filename;
            SqliteConnection.CreateFile(filename);
            using (SqliteConnection connection =
                   new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"CREATE TABLE user(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               Name           TEXT      NOT NULL,
                               Password            TEXT       NOT NULL,
                               IsOnline         BOOL
                            );";
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void ConnectDatabase(String filename, String user, String password)
        {
            connectionString = "URI=file:" + filename;
            connectionString = "URI=file:" + filename;
            using (SqliteConnection connection =
            new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO user(Name, Password) " +
                    "VALUES(@Name, @Password); ";
                cmd.Parameters.AddWithValue(
                    "@Name", user);
                cmd.Parameters.AddWithValue(
                "@Password", password);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void Register(String user, String password){
            using (SqliteConnection connection =
            new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO user(Name, Password) " +
                    "VALUES(@Name, @Password); ";
                cmd.Parameters.AddWithValue(
                    "@Name", user);
                cmd.Parameters.AddWithValue(
                "@Password", password);
                cmd.ExecuteNonQuery();
                connection.Close();
            }    
        }

        public Boolean CheckPassword(string Name, string Password)
        {
            using (SqliteConnection connection =
            new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT password " + "FROM user " + "WHERE name = @name";
                cmd.Parameters.AddWithValue
                ("@name", Name);
                using
                (
                SqliteDataReader
                reader
                =
                cmd.ExecuteReader
                ())
                {
                    while
                    (
                    reader.Read
                    ())
                    {
                        if
                        (
                        reader.GetString
                        (0) == Password)
                        {
                            return true
                            ;
                        }

                    }
                }
            }
            return false;
        }

        public Boolean CheckUsername(string Name)
        { //return true als hij WEL bestaat
            using (SqliteConnection connection =
            new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Name " + "FROM user " + "WHERE name = @name";
                cmd.Parameters.AddWithValue
                ("@name", Name);
                using
                (
                SqliteDataReader
                reader
                =
                cmd.ExecuteReader
                ())
                {
                    while
                    (
                    reader.Read
                    ())
                    {
                        if
                        (
                        reader.GetString
                        (0) == Name)
                        {
                            return true
                            ;
                        }

                    }
                }
            }
            return false;
        }

        public List<string> ReturnOnlineUsernames()
        {
            List<string> usernames = new List<string>();
            using (SqliteConnection connection =
            new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Name " + "FROM user WHERE IsOnline = TRUE ";
                using
                (
                SqliteDataReader
                reader
                =
                cmd.ExecuteReader
                ())
                {
                    while
                    (
                    reader.Read
                    ())
                    {
                        usernames.Add(reader.GetString(0));
                        Console.WriteLine(reader.GetString(0) + "    asdfasdf");
                    }
                }
            }
            return usernames;

        }

        public void switchOnlinestatus(string Name, bool Online)
        {
            {//zet IsOnline true als online, en false als offline;
                using (SqliteConnection connection =
                new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update user set IsOnline = @online where Name = @name";
                    cmd.Parameters.AddWithValue
                    ("@name", Name);
                    cmd.Parameters.AddWithValue
                    ("@online", Online);

                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }
    }
}