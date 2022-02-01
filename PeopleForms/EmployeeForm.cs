using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShopProject.Classes.People;
using ShopProject.Classes.RepeatedWords;
using ShopProject.Classes.Paths;
using ShopProject.Classes.LoggerClass;

namespace ShopProject.PeopleForms
{
    public partial class EmployeeForm : Form
    {
        Engineers engineer;
        Sales sales;

        public bool IsEngineer = false, IsSales = false, AddingAnEngineer = false, AddingASales = false, RemoveEngineer = false, RemoveSales = false;

        string filepath = AllPaths.GetEmployeeFilepath(), AskForPromotionString = AllPaths.GetAskForPromotionFilePath();

        public string senior = ImportantWords.GetSeniorString(), junior = ImportantWords.GetJuniorString();
        public string[] informations;
        public EmployeeForm(string fn, string ln, int age, string gender, int yearsofworking, int employeeID, int employeepassword, double salary, string position, string degree)
        {
            InitializeComponent();

            if (position.ToLower() == senior)
            {
                if (int.TryParse(degree, out int k))
                {
                    AddJuniorEngineerButton.Visible = false;
                    AddJuniorSalesButton.Visible = true;
                    RemoveJuniorEngineerButton.Visible = false;
                    RemoveJuniorSalesButton.Visible = true;
                    sales = new Sales(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, salary, position, k);
                    IsSales = true;
                    IsEngineer = false;
                }
                else
                {
                    AddJuniorEngineerButton.Visible = true;
                    AddJuniorSalesButton.Visible = false;
                    RemoveJuniorEngineerButton.Visible = true;
                    RemoveJuniorSalesButton.Visible = false;
                    engineer = new Engineers(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, position, salary, degree);
                    IsEngineer = true;
                    IsSales = false;
                }
                IDToRemoveNumericUpDown.Visible = false;
                AskForAPromotionButton.Visible = false;
            }
            else if (position.ToLower() == junior)
            {
                if (int.TryParse(degree, out int k))
                {
                    IsSales = true;
                    IsEngineer = false;
                    sales = new Sales(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, salary, position, k);
                }
                else
                {
                    IsEngineer = true;
                    IsSales = false;
                    engineer = new Engineers(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, position, salary, degree);
                }
                AddJuniorEngineerButton.Visible = false;
                AddJuniorSalesButton.Visible = false;
                RemoveJuniorEngineerButton.Visible = false;
                RemoveJuniorSalesButton.Visible = false;
                AskForAPromotionButton.Visible = true;
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
        }
        private void AddJuniorEngineerButton_Click(object sender, EventArgs e)
        {
            AddingAnEngineer = true;
            AddingASales = false;
            RemoveEngineer = false;
            RemoveSales = false;

            FirstNameLabel.Visible = true;
            FirstNameTextBox.Visible = true;
            LastNameLabel.Visible = true;
            LastNameTextBox.Visible = true;
            AgeLabel.Visible = true;
            AgeNumericUpDown.Visible = true;
            GenderLabel.Visible = true;
            GenderCombobox.Visible = true;
            DegreeLabel.Visible = true;
            DegreeComboBox.Visible = true;
            AddTheEmployeeButton.Visible = true;
            IDToRemoveNumericUpDown.Visible = false;
            IDToRemoveLabel.Visible = false;
            RemoveEmployeeButton.Visible = false;
        }
        private void AddJuniorSalesButton_Click(object sender, EventArgs e)
        {
            AddingAnEngineer = false;
            AddingASales = true;
            RemoveEngineer = false;
            RemoveSales = false;

            FirstNameLabel.Visible = true;
            FirstNameTextBox.Visible = true;
            LastNameLabel.Visible = true;
            LastNameTextBox.Visible = true;
            AgeLabel.Visible = true;
            AgeNumericUpDown.Visible = true;
            GenderLabel.Visible = true;
            GenderCombobox.Visible = true;
            DegreeLabel.Visible = false;
            DegreeComboBox.Visible = false;
            AddTheEmployeeButton.Visible = true;
            IDToRemoveNumericUpDown.Visible = false;
            IDToRemoveLabel.Visible = false;
            RemoveEmployeeButton.Visible = false;
        }
        private void RemoveJuniorEngineerButton_Click(object sender, EventArgs e)
        {
            AddingAnEngineer = false;
            AddingASales = false;
            RemoveEngineer = true;
            RemoveSales = false;

            FirstNameLabel.Visible = false;
            FirstNameTextBox.Visible = false;
            LastNameLabel.Visible = false;
            LastNameTextBox.Visible = false;
            AgeLabel.Visible = false;
            AgeNumericUpDown.Visible = false;
            GenderLabel.Visible = false;
            GenderCombobox.Visible = false;
            DegreeLabel.Visible = false;
            DegreeComboBox.Visible = false;
            AddTheEmployeeButton.Visible = false;
            IDToRemoveNumericUpDown.Visible = true;
            IDToRemoveLabel.Visible = true;
            RemoveEmployeeButton.Visible = true;
        }
        private void RemoveJuniorSalesButton_Click(object sender, EventArgs e)
        {
            AddingAnEngineer = false;
            AddingASales = false;
            RemoveEngineer = false;
            RemoveSales = true;

            FirstNameLabel.Visible = false;
            FirstNameTextBox.Visible = false;
            LastNameLabel.Visible = false;
            LastNameTextBox.Visible = false;
            AgeLabel.Visible = false;
            AgeNumericUpDown.Visible = false;
            GenderLabel.Visible = false;
            GenderCombobox.Visible = false;
            DegreeLabel.Visible = false;
            DegreeComboBox.Visible = false;
            AddTheEmployeeButton.Visible = false;
            IDToRemoveNumericUpDown.Visible = true;
            IDToRemoveLabel.Visible = true;
            RemoveEmployeeButton.Visible = true;

        }

        private void IDToRemoveNumericUpDown_ValueChanged(object sender, EventArgs e)
        { }

        private void AddTheEmployeeButton_Click(object sender, EventArgs e)
        {
            if (AllInformationsFilled())
            {
                try
                {
                    int id = 0;
                    if (IsEngineer) id = engineer.addemployee();
                    else if (IsSales)  id = sales.addemployee();
                    
                    if (id != -1)
                    {
                        string s = "";
                        string AddEmployeefilepath = AllPaths.GetAddedAndRemovedEmployeeFilepath(), password = Employee.GenerateEmployeePassword();
                        StringBuilder sb = new StringBuilder();

                        if ((AddingAnEngineer) && (IsEngineer))
                        {
                            s = FirstNameTextBox.Text + " " + LastNameTextBox.Text + " " + AgeNumericUpDown.Value + " " + GenderCombobox.SelectedItem + " " + 0 + " " + id + " " + password + " " +  
                                "1500" + " " + junior + " " + DegreeComboBox.SelectedItem.ToString();

                            Logger.WriteIntoFile(filepath, s);

                            s = engineer.Firstname + " " + engineer.Lastname + " added " + FirstNameTextBox.Text + " " + LastNameTextBox.Text + " of ID " + id + " at: " + DateTime.Now;
                        }
                        else if ((AddingASales) && (IsSales))
                        {
                            s = FirstNameTextBox.Text + " " + LastNameTextBox.Text + " " + AgeNumericUpDown.Value + " " + GenderCombobox.SelectedItem + " " + 0 + " " + id + " " + password + " 1500" + 
                                " " + junior + " " + "0";
                            Logger.WriteIntoFile(filepath, s);

                            s = sales.Firstname + " " + sales.Lastname + " added " + FirstNameTextBox.Text + " " + LastNameTextBox.Text + " of ID " + id + " at: " + DateTime.Now;
                        }
                        else if (IsEngineer == false) MessageBox.Show("Engineeers can only add engineers and sales can only add sales");

                        if(s != "")
                        {
                            using (TextWriter tw = new StringWriter(sb))
                            {
                                tw.Write(s);
                                MessageBox.Show(FirstNameTextBox.Text + " " + LastNameTextBox.Text + " was added");
                            }
                            using (StreamWriter write = new StreamWriter(AddEmployeefilepath, true))
                            {
                                write.WriteLine(sb.ToString());
                            }
                        }
                    }
                }
                catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
                catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
                catch (IOException ex) { MessageBox.Show(ex.Message); }
                catch { MessageBox.Show("Logging Failed"); }
                finally
                {
                    string employeepath = AllPaths.GetEmployeeFilepath();
                    File.WriteAllLines(employeepath, File.ReadAllLines(employeepath).Where(l => !string.IsNullOrWhiteSpace(l)));
                }
            }
        }
        private void AskForAPromotionButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool RequestAlreadySent = false;
                List<string> lines = new List<string>();
                if (File.Exists(AskForPromotionString))
                {
                    lines = File.ReadAllLines(AskForPromotionString).ToList();
                    foreach (string line in lines)
                    {
                        if ((IsEngineer) && (line == engineer.ToString())) RequestAlreadySent = true;
                        else if ((IsSales) && (line == sales.ToString())) RequestAlreadySent = true;
                    }
                }

                if (RequestAlreadySent == false)
                {
                    string s = "";
                    if (IsEngineer) s = engineer.ToString();
                    else if (IsSales) s = sales.ToString();
                    Logger.WriteIntoFile(AskForPromotionString, s);
                }
                else MessageBox.Show("Request already sent");
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ViewSamePositionsEmployeesButton_Click(object sender, EventArgs e)
        {
            if (IsEngineer == true) engineer.ViewEmployees();
            else if (IsSales == true) sales.ViewEmployees();
        }

        private void ViewEmployeeInformationsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsEngineer) MessageBox.Show(engineer.ToString());
                if (IsSales) MessageBox.Show(sales.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            try { this.Close(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RemoveEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string newfilepath = AllPaths.GetnewfilePath(), RemovedEmployeefilepath = AllPaths.GetAddedAndRemovedEmployeeFilepath();
                if (File.Exists(newfilepath)) File.Delete(newfilepath);
                if (Convert.ToInt32(IDToRemoveNumericUpDown.Value) > 0)
                {
                    File.Move(filepath, newfilepath);
                    string line;
                    bool isRemoved = false;
                    List<string> list = new List<string>();
                    using (var r = new StreamReader(newfilepath))
                    {
                        using (var w = new StreamWriter(filepath))
                        {
                            while ((line = r.ReadLine()) != null)
                            {
                                informations = line.Split(' ');
                                if (informations.Length > ImportantWords.GetMinimumLength())
                                {
                                    if (Convert.ToInt32(informations[5]) != Convert.ToInt32(IDToRemoveNumericUpDown.Value))
                                    {
                                        w.WriteLine(line);
                                    }
                                    else
                                    {
                                        int i = 0;
                                        if (IsEngineer) i = engineer.removeemployee();
                                        else if (IsSales) i = sales.removeemployee();
                                        
                                        if (i == 1)
                                        {
                                            if (informations[8].ToLower() == junior)
                                            {
                                                StringBuilder sb = new StringBuilder();
                                                if (IsEngineer)
                                                {
                                                    if (Convert.ToInt32(informations[5]) != engineer.EmployeeID)
                                                    {
                                                        if ((RemoveEngineer) && (int.TryParse(informations[9], out int k) == false))
                                                        {
                                                            using (TextWriter tw = new StringWriter(sb))
                                                            {
                                                                tw.Write(engineer.Firstname + " " + engineer.Lastname + " removed " + informations[0] + " " +
                                                                    informations[1] + " of ID " + informations[5] + " at: " + DateTime.Now);
                                                                MessageBox.Show(informations[0] + " " + informations[1] + " was removed");
                                                                isRemoved = true;
                                                            }
                                                        }
                                                        else if (int.TryParse(informations[9], out int p) == true)
                                                        {
                                                            MessageBox.Show("Engineers can only remove engineers");
                                                            w.WriteLine(line);
                                                            isRemoved = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You cannot remove yourself");
                                                        w.WriteLine(line);
                                                        isRemoved = true;
                                                    }
                                                }

                                                else if (IsSales)
                                                {
                                                    if (Convert.ToInt32(informations[5]) != sales.EmployeeID)
                                                    {
                                                        if ((RemoveSales) && (int.TryParse(informations[9], out int u) == true))
                                                        {
                                                            using (TextWriter tw = new StringWriter(sb))
                                                            {
                                                                tw.Write(sales.Firstname + " " + sales.Lastname + " removed " + informations[0] + " " +
                                                                    informations[1] + " of ID " + informations[5] + " at: " + DateTime.Now);
                                                                MessageBox.Show(informations[0] + " " + informations[1] + " was removed");
                                                                isRemoved = true;
                                                            }
                                                        }
                                                        else if (int.TryParse(informations[9], out int o) == false)
                                                        {
                                                            MessageBox.Show("Sales can only remove sales");
                                                            w.WriteLine(line);
                                                            isRemoved = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("You cannot remove yourself");
                                                        w.WriteLine(line);
                                                        isRemoved = true;
                                                    }
                                                }
                                                using (StreamWriter write = new StreamWriter(RemovedEmployeefilepath, true))
                                                {
                                                    write.WriteLine(sb.ToString());
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("You can only remove juniors");
                                                w.WriteLine(line);
                                                isRemoved = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (isRemoved == false) MessageBox.Show("The ID " + IDToRemoveNumericUpDown.Value + " does not exist");
                        }
                    }
                    File.Delete(newfilepath);
                }
                else MessageBox.Show("Give an ID that is positive and not equal to 0");
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File {0} not found: ", ex.FileName);
                throw;
            }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception)
            {
                Console.WriteLine("Other file copy exception");
                throw;
            }
            finally
            {
                string employeepath = AllPaths.GetEmployeeFilepath();
                File.WriteAllLines(employeepath, File.ReadAllLines(employeepath).Where(l => !string.IsNullOrWhiteSpace(l)));
            }
        }

        public bool AllInformationsFilled()
        {
            if ((FirstNameTextBox.Text != "") && (LastNameTextBox.Text != ""))
            {
                if (AgeNumericUpDown.Value > 18)
                {
                    if (GenderCombobox.SelectedItem != null)
                    {
                        if (AddingAnEngineer == true)
                        {
                            if (DegreeComboBox.SelectedItem != null) return true;
                            else
                            {
                                MessageBox.Show("Please select a degree");
                                return false;
                            }
                        }
                        else return true;
                    }
                    else MessageBox.Show("Please select a gender");
                }
                else MessageBox.Show("Employee must be at least 18 years old");
            }
            else MessageBox.Show("Fill The FirstName and LastName");
            return false;
        }
    }
}