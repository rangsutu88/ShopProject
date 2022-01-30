using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Configuration;
using ShopProject.Classes.People;
using ShopProject.DatabaseConnections;

namespace ShopProject.create_LogIn_Forget
{
    public partial class CreateAccountForm : Form
    {
        SqlConnection connection = OpenDatabaseConnection.GetConnection();
        SqlCommand TheCommand;
        Classes.People.User user = new Classes.People.User();
        string TheCommandString;
        static int counter = 0;
        int minimumAge = 18;

        string[] Countries = new string[] { "Lebanon", "Germany", "France", "Italy", "Norway" },
                Cities = new string[] { "Beyrouth", "Berlin", "Munich", "Paris", "Rome", "Venise", "Oslo" };

        public CreateAccountForm()
        {
            InitializeComponent();
        }
        
        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (counter == 0)
                {
                    CreatePasswordTextBox.UseSystemPasswordChar = false;
                    counter = 1;
                }
                else if (counter == 1)
                {
                    CreatePasswordTextBox.UseSystemPasswordChar = true;
                    counter = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ShowPasswordVerificationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (counter == 0)
                {
                    CreatePasswordVerificationTextBox.UseSystemPasswordChar = false;
                    counter = 1;
                }
                else if (counter == 1)
                {
                    CreatePasswordVerificationTextBox.UseSystemPasswordChar = true;
                    counter = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                if ((CreateFirstNameTextBox.Text.Length != 0) && (CreateLastNameTextBox.Text.Length != 0))
                {
                    if (CreateAgeNumericUpDown.Value >= minimumAge)
                    {
                        if ((CountryCombobox.SelectedItem != null) && (CityCombobox.SelectedItem != null))
                        {
                            if ((CreateBalanceNumericUpDown.Text.Length != 0) && (Convert.ToInt32(CreateBalanceNumericUpDown.Text) >= 0))
                            {
                                if ((CreatePasswordTextBox.Text.Length != 0) && (CreatePasswordVerificationTextBox.Text.Length != 0))
                                {
                                    if (int.TryParse(CreatePasswordTextBox.Text, out int a) && int.TryParse(CreatePasswordVerificationTextBox.Text, out int b))
                                    {
                                        if (Convert.ToInt32(CreatePasswordTextBox.Text) == Convert.ToInt32(CreatePasswordVerificationTextBox.Text))
                                        {
                                            TheCommandString = "Select Max(ID) from [dbo].[User]";
                                            TheCommand = new SqlCommand(TheCommandString, connection);
                                            int id = (Convert.ToInt32(TheCommand.ExecuteScalar())) + 1;
                                            Classes.People.User u = new Classes.People.User(Convert.ToInt32(CreateAgeNumericUpDown.Value), CreateFirstNameTextBox.Text,
                                                CreateLastNameTextBox.Text, CountryCombobox.SelectedItem.ToString(), CityCombobox.SelectedItem.ToString(), id,
                                                Convert.ToInt32(CreateBalanceNumericUpDown.Value), Convert.ToInt32(CreatePasswordTextBox.Text),
                                                user.Addressid);

                                            TheCommandString = "Insert Into [dbo].[User]" + "(FirstName, LastName, Age, Passcode, AddressID, BalanceInDollars)" +
                                                                "Values(@FirstName, @LastName, @Age, @Password, @AddressID, @Balance)";
                                            TheCommand = new SqlCommand(TheCommandString, connection);

                                            TheCommand.Parameters.AddWithValue("@FirstName", u.Firstname);
                                            TheCommand.Parameters.AddWithValue("@LastName", u.Lastname);
                                            TheCommand.Parameters.AddWithValue("@Age", u.Age);
                                            TheCommand.Parameters.AddWithValue("@Password", u.Password);
                                            TheCommand.Parameters.AddWithValue("@AddressID", u.Addressid);
                                            TheCommand.Parameters.AddWithValue("@Balance", u.Balance);
                                            TheCommand.ExecuteNonQuery();

                                            MessageBox.Show("Please remember this ID, so you can recover your account if you forget the password, ID= " + u.ID);
                                            user = u;

                                            Form account = new PeopleForms.UserForm(user.ID);
                                            account.Show();
                                            this.Close();
                                        }
                                        else  MessageBox.Show("Passwords are not the same");
                                    }
                                    else MessageBox.Show("Passwords must a number");
                                }
                                else if (CreatePasswordTextBox.Text.Length == 0) MessageBox.Show("Please enter your password");
                                else MessageBox.Show("Please enter the verification of your password");
                                
                            }
                            else if (CreateBalanceNumericUpDown.Text.Length == 0) MessageBox.Show("Enter the amount you want to put in your account");
                            else MessageBox.Show("Please enter a positive value for the balance");
                            
                        }
                        else if (CountryCombobox.SelectedItem == null) MessageBox.Show("Please enter your country");
                        else MessageBox.Show("Please enter your city");

                    }
                    else if (CreateAgeNumericUpDown.Value < minimumAge) MessageBox.Show("You should be at least 18 years old to create an account");
                    else MessageBox.Show("Your birthday cannot be correct");

                }
                else if (CreateFirstNameTextBox.Text.Length == 0) MessageBox.Show("Please enter your firstname");
                else MessageBox.Show("Please enter your lastname");
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "SQL error occured");
            }
            finally
            {
                connection.Close();
            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFirstNameTextBox.Text = "";  
                CreateLastNameTextBox.Text = "";                 
                CreateAgeNumericUpDown.Value = 0;
                CountryTextBox.Text = "";          
                CityTextBox.Text = "";                           
                CreateBalanceNumericUpDown.Value = 0;
                CreatePasswordTextBox.Text = "";   
                CreatePasswordVerificationTextBox.Text = "";
                CityCombobox.Items.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void CountryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                CountryTextBox.Text = Convert.ToString(CountryCombobox.SelectedItem);

                if (CountryTextBox.Text == Countries[0])
                {
                    CityCombobox.Items.Clear();
                    CityCombobox.Text = "";
                    CityTextBox.Text = "";

                    for (int i = 0; i < 1; i++)
                    {
                        CityCombobox.Items.Add(Cities[i]);
                    }
                }
                else if (CountryTextBox.Text == Countries[1])
                {
                    CityCombobox.Items.Clear();
                    CityCombobox.Text = "";
                    CityTextBox.Text = "";

                    for (int i = 1; i < 3; i++)
                    {
                        CityCombobox.Items.Add(Cities[i]);
                    }

                }
                else if (CountryTextBox.Text == Countries[2])
                {
                    CityCombobox.Items.Clear();
                    CityCombobox.Text = "";
                    CityTextBox.Text = "";

                    for (int i = 3; i < 4; i++)
                    {
                        CityCombobox.Items.Add(Cities[i]);
                    }

                }
                else if (CountryTextBox.Text == Countries[3])
                {
                    CityCombobox.Items.Clear();
                    CityCombobox.Text = "";
                    CityTextBox.Text = "";

                    for (int i = 4; i < 6; i++)
                    {
                        CityCombobox.Items.Add(Cities[i]);
                    }

                }
                else if (CountryTextBox.Text == Countries[4])
                {
                    CityCombobox.Items.Clear();
                    CityCombobox.Text = "";
                    CityTextBox.Text = "";

                    for (int i = 6; i < 7; i++)
                    {
                        CityCombobox.Items.Add(Cities[i]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void CityCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CityTextBox.Text = Convert.ToString(CityCombobox.SelectedItem);

                if ((CountryCombobox.Text == Countries[0]) && (CityTextBox.Text == Cities[0])) user.Addressid = 1;
                else if ((CountryCombobox.Text == Countries[1]) && (CityTextBox.Text == Cities[2])) user.Addressid = 2;
                else if ((CountryCombobox.Text == Countries[2]) && (CityTextBox.Text == Cities[3])) user.Addressid = 3;
                else if ((CountryCombobox.Text == Countries[3]) && (CityTextBox.Text == Cities[4])) user.Addressid = 4;
                else if ((CountryCombobox.Text == Countries[3]) && (CityTextBox.Text == Cities[5])) user.Addressid = 5;
                else if ((CountryCombobox.Text == Countries[1]) && (CityTextBox.Text == Cities[1])) user.Addressid = 6;
                else if ((CountryCombobox.Text == Countries[4]) && (CityTextBox.Text == Cities[6])) user.Addressid = 7;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}