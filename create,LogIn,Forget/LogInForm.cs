using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ShopProject.Classes.Paths;
using ShopProject.Classes.LoggerClass;
using ShopProject.DatabaseConnections;

namespace ShopProject.create_LogIn_Forget
{
    public partial class LogInForm : Form
    {
        SqlConnection connection = OpenDatabaseConnection.GetConnection();
        SqlCommand Thecommand;
        string TheCommandString;
        static int t = 0, counter = 0;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (OpenDatabaseConnection.OpenConnectionWithDatabase(connection))
            {
                try
                {
                    if ((FirstNameTextBox.Text != null) && (LastNameTextBox.Text != null) && (PasswordTextBox.Text != null))
                    {
                        if (int.TryParse(PasswordTextBox.Text, out int a))
                        {
                            TheCommandString = "Select ID from [dbo].[User] where FirstName=@FN and LastName=@LN";
                            Thecommand = new SqlCommand(TheCommandString, connection);
                            Thecommand.Parameters.AddWithValue("@FN", FirstNameTextBox.Text);
                            Thecommand.Parameters.AddWithValue("@LN", LastNameTextBox.Text);
                            int id = Convert.ToInt32(Thecommand.ExecuteScalar());

                            TheCommandString = "Select Passcode from [dbo].[User] where ID=@id";
                            Thecommand = new SqlCommand(TheCommandString, connection);
                            Thecommand.Parameters.AddWithValue("@id", id);
                            int password = Convert.ToInt32(Thecommand.ExecuteScalar());

                            if (password == Convert.ToInt32(PasswordTextBox.Text))
                            {
                                MessageBox.Show("Welcome " + FirstNameTextBox.Text + " " + LastNameTextBox.Text);
                                Form account = new PeopleForms.UserForm(id);
                                account.Show();
                                Logger.LogWrite(AllPaths.GetOpenedAccountFilepath(),
                                    FirstNameTextBox.Text, LastNameTextBox.Text, id);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Wrong password");
                                if (t == 2)
                                {
                                    MessageBox.Show("Thief!");
                                    t = 0;
                                    this.Close();
                                }
                                t++;
                            }
                        }
                        else MessageBox.Show("Password must be a number");
                    }
                    else if (FirstNameTextBox.Text.Length == 0) { MessageBox.Show("Please enter your firstname"); }
                    else if (LastNameTextBox.Text.Length == 0) { MessageBox.Show("Please enter your lastname"); }
                    else { MessageBox.Show("Please enter your password"); }
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
                finally { connection.Close(); }
            }
        }
        
        private void ShowLogInPasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (counter == 0)
                {
                    PasswordTextBox.UseSystemPasswordChar = false;
                    counter = 1;
                }
                else if (counter == 1)
                {
                    PasswordTextBox.UseSystemPasswordChar = true;
                    counter = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ReturnBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LogInForgetThePasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form Forget = new ForgetThePasswordForm();
                DialogResult Passwordforgotten = Forget.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}