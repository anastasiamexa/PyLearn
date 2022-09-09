using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Npgsql;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace EkpaideutikoLogismiko
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

        // Username is pk
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
                return "Υπήρξε κάποιο πρόβλημα.";
            }
           
            foreach (string usernameDB in usernamesDB) //check for duplicates (username)
                if (usernameDB.Equals(username))
                    return "Ο χρήστης υπάρχει ήδη.";
            return null;
        }

        // Check user's input
        public static string CheckRegex(string firstname, string lastname, string username, string password)
        {
            if (!Regex.IsMatch(firstname, @"^[a-zA-Z]+$") || !Regex.IsMatch(lastname, @"^[a-zA-Z]+$"))
            {
                return "Το όνομα πρέπει να περιέχει μόνο γράμματα.";
            }
            if (password.Trim().Length < 6)
            {
                return "Ο κωδικός πρέπει να είναι μεγαλύτερος ή ίσος με 6 χαρακτήρες.";
            }
            if (Regex.IsMatch(username, @"^[0-9]+$"))
            {
                return "Το όνομα χρήστη δεν μπορεί να περιέχει μόνο αριθμούς.";
            }
            return null;
        }

        //----Log In----
        //================================================================================================================================ 

        //Validate user's input.
        public static string IsValidUserInputLogIn(string username, string password)
        {
            if (username.Trim().Length == 0)
                return "Παρακαλώ συμπληρώστε όλα τα πεδία.";
            if (password.Trim().Length < 6)
                return "Ο κωδικός πρέπει να είναι μεγαλύτερος ή ίσος με 6 χαρακτήρες.";
            return null;
        }
        //================================================================================================================================ 
    }
}