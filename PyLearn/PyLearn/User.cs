using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PyLearn
{
    public class User
    {
        public string first_name;
        public string last_name;
        public bool teacher;
        public string username;
        public string hashed_password;
        public string salt;

        //----Constructors----
        public User(string first_name, string last_name, string username, string hashed_password, string salt, bool teacher)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.teacher = teacher;
            this.username = username;
            this.hashed_password = hashed_password;
            this.salt = salt;
        }
        
        public User(string username)
        {
            this.username = username;
        }

        //----Methods----
        //================================================================================================================================
      
        //Used for logging in. Check if given username exists and if it does,then creates the hashed password anew and compares it with the one at the DB.
        //If username and password match, then he logs in.
        public string AuthenticateCredentials(string rawPassword)
        {
            string query = "select username, hashed_password, salt from users";
            List<string> userData = new List<string>(); //store user's username, hashed password and salt
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                    userData.Add(dataReader[0].ToString() + "|" + dataReader[1].ToString() + "|" + dataReader[2].ToString());
                connection.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            foreach (string dataRow in userData)
            {
                string[] dataCols = dataRow.Split('|');
                if (dataCols[0].Equals(username))
                    if (dataCols[1].Equals(Auxiliary.HashPassword(rawPassword, Convert.FromBase64String(dataCols[2]))))
                        return null;
                    else
                        return "Incorrect password.";
            }
            return "Username does not exist.";
        }

        //Check if user is admin.
        public string IsAdmin()
        {
            string isAdmin = null;
            string query = "select teacher from users where username = @username";
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("username", username);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                    isAdmin = dataReader[0].ToString(); //get result
                connection.Close();
                return isAdmin;
            }
            catch
            {
                return null;
            }
        }
    }
}