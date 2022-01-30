using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShopProject.Classes.People
{
    sealed class User : Person
    {
        private int id, balance, password, addressid;
        private string city;
        public string country;
        public User() { }
        public User(int age, string fn, string ln, string country, string city, int id, int balance, int password,
            int addressid) : base(fn, ln, age)
        {
            this.ID = id;
            this.Balance = balance;
            this.Password = password;
            this.Addressid = addressid;
            this.country = country;
            this.City = city;
        }
        public int ID
        {
            get { return id; }
            set { if(value>0) id = value;
                else throw new Exception("Id must be positive");
            }
        }
        public int Balance
        {
            get { return balance; }
            set { if(value>0) balance = value;
                else throw new Exception("Balance must be positive");
            }
        }
        public int Password
        {
            get { return password; }
            set
            {
                if (value.ToString().Length > 2) password = value;
                else throw new Exception("password must be of 3 integers at least");
            }
        }
        public int Addressid
        {
            get { return addressid; }
            set
            {
                if (value > 0) addressid = value;
                else throw new Exception("AddressID must be positive");
            }
        }
        public string Country
        {
            get { return country; }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (value.Length > 2) city = value;
                else throw new Exception("city should be at least 3 characters");
            }
        }
        public static User GetHigherbalance(SqlConnection connection)
        {
            try
            {
                connection.Open();
                string TheCommandString = "Select Max(BalanceInDollars) from [dbo].[User]";
                SqlCommand TheCommand = new SqlCommand(TheCommandString, connection);
                User u = new User();
                u.Balance = Convert.ToInt32(TheCommand.ExecuteScalar());

                TheCommandString = "Select Firstname, Lastname, Age from [dbo].[User] where BalanceInDollars=@d";
                TheCommand = new SqlCommand(TheCommandString, connection);
                TheCommand.Parameters.AddWithValue("@d", u.Balance);

                SqlDataReader ProductReader = TheCommand.ExecuteReader();
                while (ProductReader.Read())
                {
                    u.Firstname = ProductReader["FirstName"].ToString();
                    u.Lastname = ProductReader["LastName"].ToString();
                    u.Age = Convert.ToInt32(ProductReader["Age"]);
                }
                ProductReader.Close();
                return u;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}