using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ShopProject.PeopleForms;
using ShopProject.Classes.Paths;
using ShopProject.Classes.Bills;
using ShopProject.Classes.People;
using ShopProject.Classes.RepeatedWords;

namespace ShopProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDirectory();
            CreateEmployeeText();
            CreateBillText();
            CreateAdminInformation();
            CreateAskForPromotion();
            CreateAddedAndRemovedEmployees();
            CreateOpenedAccountTime();
            CreatePasswords();
            CreateAdminCode();
            Createdataxml();
            CreateBinaryAdminInformations();
            string employeepath = AllPaths.GetEmployeeFilepath();
            File.WriteAllLines(employeepath, File.ReadAllLines(employeepath).Where(l => !string.IsNullOrWhiteSpace(l)));
        }

        public void CreateDirectory()
        {
            string filepath = Directory.GetCurrentDirectory();
            if(Directory.Exists(filepath+"\\AllFiles") == false)
            {
                Directory.CreateDirectory(filepath + "\\AllFiles");
            }
        }

        public void CreateBillText()
        {
            Bill.CreateFileTextForTheBillsUsingTextwriters();
        }

        public void CreateEmployeeText()
        {
            Employee.CreateEmployeeText();
        }

        public void CreateAdminInformation()
        {
            Admin.CreateAdminInformation();
        }

        public void CreateAskForPromotion()
        {
            string filepath = AllPaths.GetAskForPromotionFilePath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }
        
        public void CreateAddedAndRemovedEmployees()
        {
            string filepath = AllPaths.GetAddedAndRemovedEmployeeFilepath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }

        public void CreateOpenedAccountTime()
        {
            string filepath = AllPaths.GetOpenedAccountFilepath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }

        public void CreatePasswords()
        {
            string filepath = AllPaths.GetPasswordFilePath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }

        public void CreateAdminCode()
        {
            string filepath = AllPaths.GetAdminCodeFilePath(), file = AllPaths.GetEmployeeFilepath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }

        public void Createdataxml()
        {
            string filepath = AllPaths.GetXMLFilePath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }

        public void CreateBinaryAdminInformations()
        {
            string filepath = AllPaths.GetBinaryInformationFilePath();
            if (File.Exists(filepath) == false) File.Create(filepath);
        }

        private void LogInAsAUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form formlogin = new create_LogIn_Forget.LogInForm();
                DialogResult logform = formlogin.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "SQL error occured");
            }
        }

        private void CreateAnAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form CreateAccount = new create_LogIn_Forget.CreateAccountForm();
                DialogResult CreateForm = CreateAccount.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "SQL error occured");
            }
        }

        private void ForgetThePasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form ForgetPassword = new create_LogIn_Forget.ForgetThePasswordForm();
                DialogResult Passwordforgotten = ForgetPassword.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "SQL error occured");
            }
        }

        private void LogInAsAnAdminButton_Click(object sender, EventArgs e)
        {
            LogInAsAnEmployeeButton.Visible = false;
            LogInAsAUserButton.Visible = false;
            ForgetThePasswordButton.Visible = false;
            CreateAnAccountButton.Visible = false;
            BrickBreakerGameButton.Visible = false;
            NameLabel.Visible = true;
            PasswordLabel.Visible = true;
            ExitButton.Visible = true;
            NameTextbox.Visible = true;
            PasswordTextBox.Visible = true;
            LogInButton.Visible = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            LogInAsAnEmployeeButton.Visible = true;
            LogInAsAUserButton.Visible = true;
            ForgetThePasswordButton.Visible = true;
            CreateAnAccountButton.Visible = true;
            BrickBreakerGameButton.Visible = true;
            NameLabel.Visible = false;
            PasswordLabel.Visible = false;
            ExitButton.Visible = false;
            NameTextbox.Visible = false;
            PasswordTextBox.Visible = false;
            LogInButton.Visible = false;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            try
            {
                Admin a = new Admin(NameTextbox.Text);
                a.LogEvent += new LogInEvent(HelloEvent);
                a.LoginToTheAccount(NameTextbox.Text, PasswordTextBox.Text);   
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void HelloEvent(string name, bool b)
        {
            if (b == true) 
            { 
                MessageBox.Show("Hello " + name);
                NameTextbox.Text = "";
                PasswordTextBox.Text = "";
            }
            else MessageBox.Show("Wrong Informations");
        }

        private void ExitEmployeeLogInButton_Click(object sender, EventArgs e)
        {
            LogInAsAnAdminButton.Visible = true;
            LogInAsAUserButton.Visible = true;
            ForgetThePasswordButton.Visible = true;
            CreateAnAccountButton.Visible = true;
            BrickBreakerGameButton.Visible = true;
            IDLabel.Visible = false;
            EmployeePasswordLabel.Visible = false;
            IDTextBox.Visible = false;
            EmployeePasswordTextBox.Visible = false;
            ExitEmployeeLogInButton.Visible = false;
            EmployeeLogInButton.Visible = false;
        }

        private void LogInAsAnEmployeeButton_Click(object sender, EventArgs e)
        {
            LogInAsAnAdminButton.Visible = false;
            LogInAsAUserButton.Visible = false;
            ForgetThePasswordButton.Visible = false;
            CreateAnAccountButton.Visible = false;
            BrickBreakerGameButton.Visible = false;
            IDLabel.Visible = true;
            EmployeePasswordLabel.Visible = true;
            IDTextBox.Visible = true;
            EmployeePasswordTextBox.Visible = true;
            ExitEmployeeLogInButton.Visible = true;
            EmployeeLogInButton.Visible = true;
        }

        private void EmployeeLogInButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDTextBox.Text != "")
                {
                    if (EmployeePasswordTextBox.Text != "")
                    {
                        bool accountopened = false;
                        List<string> lines = new List<string>();
                        string filepath = AllPaths.GetEmployeeFilepath();
                        string[] informations;
                        lines = File.ReadAllLines(filepath).ToList();
                        foreach (string line in lines)
                        {
                            informations = line.Split(' ');
                            if (informations.Length > ImportantWords.GetMinimumLength())
                            {
                                if ((informations[5] == IDTextBox.Text) && (informations[6] == EmployeePasswordTextBox.Text))
                                {
                                    Form employe = new EmployeeForm(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3], Convert.ToInt32(informations[4]), 
                                        Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), Convert.ToDouble(informations[7]), informations[8], informations[9]);
                                    employe.Show();
                                    accountopened = true;
                                }
                            }
                        }
                        if(accountopened==false) MessageBox.Show("Incorrect informations");
                    }
                    else MessageBox.Show("Give me a password");
                }
                else MessageBox.Show("Give me an ID");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally 
            {
                IDTextBox.Text = "";
                EmployeePasswordTextBox.Text = "";
            }
        }

        private void BrickBreakerGameButton_Click(object sender, EventArgs e)
        {
            Form game = new Game.BrickBreaker();
            game.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}