using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideutikoLogismiko
{
    public class User
    {
        //----Fields----
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
        //Stores user's info(firstname, lastname, email, username,hashedpassword,salt) in DB when he signs up.
        public string StoreUserInfoToDB()
        {
            string query = "insert into users values (@first_name, @last_name, @username, @hashed_password, @salt, @teacher)";
            int rowsAffected = -1; //false value
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                //define query's parameters
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("first_name", first_name);
                command.Parameters.AddWithValue("last_name", last_name);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("hashed_password", hashed_password);
                command.Parameters.AddWithValue("salt", salt);
                command.Parameters.AddWithValue("teacher", teacher);
                rowsAffected = command.ExecuteNonQuery(); //run query
                connection.Close();
            }
            catch
            {
                return "Υπήρξε κάποιο πρόβλημα.";
            }
            if (rowsAffected == -1)
                return "Υπήρξε κάποιο πρόβλημα με την βάση δεδομένων, ξαναπροσπαθήστε αργότερα.";
            else
                return "done";
        }

        //Stores user's info(firstname, lastname, email, username,hashedpassword,salt) in DB when he signs up.
        public string StoreTeacherInfoToDB()
        {
            string query = "insert into users(first_name, last_name, username, hashed_password, salt, teacher) values (@first_name, @last_name, @username, @hashed_password, @salt, @teacher)";
            int rowsAffected = -1; //false value
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                //define query's parameters
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("first_name", first_name);
                command.Parameters.AddWithValue("last_name", last_name);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("hashed_password", hashed_password);
                command.Parameters.AddWithValue("salt", salt);
                command.Parameters.AddWithValue("teacher", teacher);
                rowsAffected = command.ExecuteNonQuery(); //run query
                connection.Close();
            }
            catch
            {
                return "Υπήρξε κάποιο πρόβλημα.";
            }
            if (rowsAffected == -1)
                return "Υπήρξε κάποιο πρόβλημα με την βάση δεδομένων, ξαναπροσπαθήστε αργότερα.";
            else
                return "done";
        }

        //Used for logging in. Check if given username exists and if it does,then creates the hashed password anew and compares it with the one at the DB.
        //If username and password match, then he logs in.
        public string AuthenticateCredentials(string rawPassword)
        {
            string query = "select username, hashed_password, salt from users where teacher = false";
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
                        return "Λάθος κωδικός.";
            }
            return "Ο χρήστης δεν υπάρχει.";
        }

        //Used for logging in for teachers. Check if given username exists and if it does,then creates the hashed password anew and compares it with the one at the DB.
        //If username and password match, then he logs in.
        public string AuthenticateTeacherCredentials(string rawPassword)
        {
            string query = "select username, hashed_password, salt from users where teacher = true";
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
                        return "Λάθος κωδικός.";
            }
            return "Ο χρήστης δεν υπάρχει.";
        }
        //================================================================================================================================
    }
}
