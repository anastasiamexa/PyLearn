using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PyLearn
{
    public class Auxiliary
    {
        public static readonly string CONNECTION_STRING = "Host=127.0.0.1;Port=5432;User ID=postgres;Password=maxrouso2;Database=elearning;";

        //----Hash Password----
        //================================================================================================================================

        //Generate a salt to hash the user's password.
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[32]; //salt length is 32(can be changed)
            using (var random = new RNGCryptoServiceProvider()) //"RNGCryptoServiceProvider" object is disposed, there are no resourse leaks
            {
                random.GetNonZeroBytes(salt); //salt
            }
            return salt;
        }

        //Hashes the user's password along with the salt.
        public static string HashPassword(string rawPassword, byte[] salt)
        {
            byte[] password = Encoding.UTF8.GetBytes(rawPassword);//convert to bytes
            byte[] passwordWithSalt = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++) //copy password bytes
            {
                passwordWithSalt[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++) //copy salt bytes
            {
                passwordWithSalt[i + password.Length] = salt[i];
            }
            using (SHA512 shaM = new SHA512Managed()) //"SHA512Managed" object is disposed, there are no resourse leaks
            {
                return Convert.ToBase64String(shaM.ComputeHash(passwordWithSalt)); //hashed password (with salt)
            }
        }



        //================================================================================================================================

        //----Sign Up----
        //================================================================================================================================

        //Email is pk, username is unique
        public static string CheckForDublicates(string username)
        {
            string query = "select username from users";
            List<string> usernamesDB = new List<string>(); //store usernames
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    usernamesDB.Add(dataReader[0].ToString());
                }
                connection.Close();
            }
            catch
            {
                return "An exeption was caught. Please report it.";
            }

            foreach (string usernameDB in usernamesDB) //check for duplicates (username)
                if (usernameDB.Equals(username))
                    return "Username already exists";
            return null;
        }

        //----Log In----
        //================================================================================================================================ 

        //Validate user's input.
        public static string IsValidUserInputLogIn(string username, string password)
        {
            if (username.Trim().Length == 0)
                return "Please fill all input fields";
            if (password.Trim().Length < 6)
                return "Password must be at least 6 characters long";
            return null;
        }
        //================================================================================================================================ 

        //----Get Progress----
        //================================================================================================================================ 

        public static List<string> GetOneProgressFromDB()
        {
            string query = "select * from exercisehistory where username='" + (string)HttpContext.Current.Session["Username"] + "';";
            List<string> progressList = new List<string>(); //store plate_numberIDs 
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    progressList.Add(dataReader[0].ToString());
                    progressList.Add(dataReader[1].ToString());
                    if (dataReader[2].ToString().Equals("0"))
                    {
                        progressList.Add("Εύκολο");
                    }
                    else
                    {
                        progressList.Add("Δύσκολο");
                    }
                    progressList.Add(dataReader[3].ToString());
                    progressList.Add(dataReader[4].ToString());
                    progressList.Add(dataReader[5].ToString());
                    progressList.Add(dataReader[6].ToString());
                    progressList.Add(dataReader[7].ToString());
                    progressList.Add(dataReader[8].ToString());
                    progressList.Add(dataReader[9].ToString());
                    progressList.Add(dataReader[10].ToString());
                    progressList.Add(dataReader[11].ToString());
                    progressList.Add(dataReader[12].ToString());
                }
                connection.Close();
                return progressList;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetUsersProgressFromDB()
        {
            string query = "select * from exercisehistory;";
            List<string> progressList = new List<string>(); //store plate_numberIDs 
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    progressList.Add(dataReader[0].ToString());
                    progressList.Add(dataReader[1].ToString());
                    if (dataReader[2].ToString().Equals("0"))
                    {
                        progressList.Add("Εύκολο");
                    }
                    else
                    {
                        progressList.Add("Δύσκολο");
                    }
                    progressList.Add(dataReader[3].ToString());
                    progressList.Add(dataReader[4].ToString());
                    progressList.Add(dataReader[5].ToString());
                    progressList.Add(dataReader[6].ToString());
                    progressList.Add(dataReader[7].ToString());
                    progressList.Add(dataReader[8].ToString());
                    progressList.Add(dataReader[9].ToString());
                    progressList.Add(dataReader[10].ToString());
                    progressList.Add(dataReader[11].ToString());
                    progressList.Add(dataReader[12].ToString());
                }
                connection.Close();
                return progressList;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetStudentsFromDB(string username)
        {
            string query = "select first_name, last_name, username from users where teacher=false;";
            List<string> progressList = new List<string>(); //store plate_numberIDs 
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    // Don't return as a classmate the same user
                    if (!username.Equals(dataReader[2].ToString()))
                    {
                        progressList.Add(dataReader[0].ToString());
                        progressList.Add(dataReader[1].ToString());
                    }
                }
                connection.Close();
                return progressList;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetOnesFinalTestProgressFromDB()
        {
            string query = "select username, date_time, answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer12 from testhistory where username='" 
                + (string)HttpContext.Current.Session["Username"] + "';";
            List<string> progressList = new List<string>(); //store plate_numberIDs 
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    progressList.Add(dataReader[0].ToString());
                    progressList.Add(dataReader[1].ToString());
                    progressList.Add(dataReader[2].ToString());
                    progressList.Add(dataReader[3].ToString());
                    progressList.Add(dataReader[4].ToString());
                    progressList.Add(dataReader[5].ToString());
                    progressList.Add(dataReader[6].ToString());
                    progressList.Add(dataReader[7].ToString());
                    progressList.Add(dataReader[8].ToString());
                    progressList.Add(dataReader[9].ToString());
                    progressList.Add(dataReader[10].ToString());
                    progressList.Add(dataReader[11].ToString());
                    progressList.Add(dataReader[12].ToString());
                    progressList.Add(dataReader[13].ToString());
                }
                connection.Close();
                return progressList;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetFinalTestProgressFromDB()
        {
            string query = "select username, date_time, answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer12 from testhistory;";
            List<string> progressList = new List<string>(); //store plate_numberIDs 
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    progressList.Add(dataReader[0].ToString());
                    progressList.Add(dataReader[1].ToString());
                    progressList.Add(dataReader[2].ToString());
                    progressList.Add(dataReader[3].ToString());
                    progressList.Add(dataReader[4].ToString());
                    progressList.Add(dataReader[5].ToString());
                    progressList.Add(dataReader[6].ToString());
                    progressList.Add(dataReader[7].ToString());
                    progressList.Add(dataReader[8].ToString());
                    progressList.Add(dataReader[9].ToString());
                    progressList.Add(dataReader[10].ToString());
                    progressList.Add(dataReader[11].ToString());
                    progressList.Add(dataReader[12].ToString());
                    progressList.Add(dataReader[13].ToString());
                }
                connection.Close();
                return progressList;
            }
            catch
            {
                return null;
            }
        }


        public static List<string> GetErrors()
        {
            string query = "select id, errortype from questions;";
            List<string> idsList = new List<string>(); //store ids 
            List<string> errorTypeList = new List<string>(); //store error types 
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {
                    idsList.Add(dataReader[0].ToString());
                    errorTypeList.Add(dataReader[1].ToString());
                }
                connection.Close();
            }
            catch
            {
                return null;
            }

            string query2 = "select id1, id2, id3, id4, id5, answer1, answer2, answer3, answer4, answer5, chapter from exercisehistory where username='" 
                + (string)HttpContext.Current.Session["Username"] + "';";
            int syntaxErrors = 0;
            int logicalErrors = 0;
            int combErrors = 0;
            int chapter1Errors = 0;
            int chapter2Errors = 0;
            int chapter3Errors = 0;
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Auxiliary.CONNECTION_STRING);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query2, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader(); //run query
                while (dataReader.Read())
                {

                    System.Diagnostics.Debug.WriteLine("WHILE");
                    for (int i=0; i < 5; i++)
                    {

                        System.Diagnostics.Debug.WriteLine("FOR");
                        if (dataReader[i + 5].ToString().Equals("False"))
                        {
                            //int position = idsList.FindIndex(a => a == dataReader[i].ToString());
                            int position = idsList.IndexOf(dataReader[i].ToString());
                            System.Diagnostics.Debug.WriteLine(position.ToString());
                            if (errorTypeList.ElementAt(position).Equals("0"))
                            {
                                syntaxErrors++;
                            }
                            else if (errorTypeList.ElementAt(position).Equals("1"))
                            {
                                logicalErrors++;
                            }
                            else
                            {
                                combErrors++;
                            }

                            if (dataReader[10].ToString().Equals("1"))
                            {
                                chapter1Errors++;
                            }
                            else if (dataReader[10].ToString().Equals("2"))
                            {
                                chapter2Errors++;
                            }
                            else
                            {
                                chapter3Errors++;
                            }
                        }
                    }
                }
                connection.Close();

                System.Diagnostics.Debug.WriteLine(syntaxErrors.ToString());
                System.Diagnostics.Debug.WriteLine(logicalErrors.ToString());
                System.Diagnostics.Debug.WriteLine(combErrors.ToString());
                System.Diagnostics.Debug.WriteLine("CHAPTER ERRORS BELOW");
                System.Diagnostics.Debug.WriteLine(chapter1Errors.ToString());
                System.Diagnostics.Debug.WriteLine(chapter2Errors.ToString());
                System.Diagnostics.Debug.WriteLine(chapter3Errors.ToString());
            }
            catch
            {
                return null;
            }

            List<string> results = new List<string>();
            results.Add(syntaxErrors.ToString());
            results.Add(logicalErrors.ToString());
            results.Add(combErrors.ToString());
            results.Add(chapter1Errors.ToString());
            results.Add(chapter2Errors.ToString());
            results.Add(chapter3Errors.ToString());
            return results;
        }
    }
}