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
using ShopProject.DatabaseConnections;

namespace ShopProject.create_LogIn_Forget
{
    public partial class ForgetThePasswordForm : Form
    {
        SqlConnection connection = OpenDatabaseConnection.GetConnection();
        int id;
        static int x = 0, counter = 0, Verificationcounter = 0;

        public ForgetThePasswordForm()
        {
            InitializeComponent();
        }
        private void GoBackRecoveryButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void VerifyNameButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if ((ForgetFirstNameTextbox.Text.Length != 0) && (ForgetLastNameTextbox.Text.Length != 0))
                {
                    string SelectStatement = "Select ID from [dbo].[User] where FirstName=@firstname and LastName=@lastname";
                    SqlCommand SelectCommand = new SqlCommand(SelectStatement, connection);
                    SelectCommand.Parameters.AddWithValue("@firstname", ForgetFirstNameTextbox.Text);
                    SelectCommand.Parameters.AddWithValue("@lastname", ForgetLastNameTextbox.Text);

                    if (SelectCommand.ExecuteScalar() == null)
                    {
                        MessageBox.Show("This account does not exist");
                    }
                    else
                    {
                        id = Convert.ToInt32(SelectCommand.ExecuteScalar());
                        PasswordRecoveryLabel.Visible = true;
                        PasswordRecoveryTextBox.Visible = true;
                        VerifyRecoveryButton.Visible = true;
                    }
                }
                else if (ForgetFirstNameTextbox.Text.Length != 0) MessageBox.Show("Please enter your firstname");
                else MessageBox.Show("Please enter your lastname");
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally { connection.Close(); }
        }
        
        private void VerifyRecoveryButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (PasswordRecoveryTextBox.Text.Length != 0)
                {
                    int y = Convert.ToInt32(PasswordRecoveryTextBox.Text);
                    if (y == id)
                    {
                        ChangeThePasswordtextBox.Visible = true;
                        NewPasswordTextBox.Visible = true;
                        ShowPasswordButton.Visible = true;
                        ChangeThePasswordAgaintextBox.Visible = true;
                        NewPasswordVerificationTextBox.Visible = true;
                        ShowPasswordVerificationButton.Visible = true;
                        ContinueRecoveryButton.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong ID");
                        x++;
                        if (x == 2)
                        {
                            MessageBox.Show("Try again later");
                            x = 0;
                            this.Close();
                        }
                    }
                }
                else MessageBox.Show("Please enter an ID to continue");
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally { connection.Close(); }
        }
        
        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (counter == 0)
                {
                    NewPasswordTextBox.UseSystemPasswordChar = false;
                    counter = 1;
                }
                else if (counter == 1)
                {
                    NewPasswordTextBox.UseSystemPasswordChar = true;
                    counter = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ShowPasswordVerificationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verificationcounter == 0)
                {
                    NewPasswordVerificationTextBox.UseSystemPasswordChar = false;
                    Verificationcounter = 1;
                }
                else if (Verificationcounter == 1)
                {
                    NewPasswordVerificationTextBox.UseSystemPasswordChar = true;
                    Verificationcounter = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ContinueRecoveryButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if ((NewPasswordTextBox.Text.Length != 0) && (NewPasswordVerificationTextBox.Text.Length != 0))
                {
                    if (int.TryParse(NewPasswordTextBox.Text, out int a) && int.TryParse(NewPasswordVerificationTextBox.Text, out int b))
                    {
                        if (NewPasswordTextBox.Text == NewPasswordVerificationTextBox.Text)
                        {
                            int password = Convert.ToInt32(NewPasswordTextBox.Text);
                            string updatequery = "Update [dbo].[User]" + " set Passcode=@password where ID=@id";
                            SqlCommand updatecommand = new SqlCommand(updatequery, connection);
                            updatecommand.Parameters.AddWithValue("@password", password);
                            updatecommand.Parameters.AddWithValue("@id", Convert.ToInt32(PasswordRecoveryTextBox.Text));
                            updatecommand.ExecuteNonQuery();
                            MessageBox.Show("Password changed successfully");
                            this.Close();
                        }
                        else MessageBox.Show("Passwords are not the same");
                    }
                    else MessageBox.Show("Passwords must be numbers");
                }
                else if (NewPasswordTextBox.Text.Length == 0) MessageBox.Show("Please enter your new password");
                else  MessageBox.Show("Please enter the verification of your new password");
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "SQL error occured"); }
            finally { connection.Close(); }
        }

        private void ForgetThePasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}