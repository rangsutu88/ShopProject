using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShopProject.Design_Patterns.AdapterPattern;
using ShopProject.Design_Patterns.AdapterPattern.Adapter;
using ShopProject.Classes.People;
using ShopProject.Classes.Paths;
using ShopProject.Classes.RepeatedWords;
using ShopProject.Classes.LoggerClass;
using ShopProject.Classes.Bills;

namespace ShopProject.PeopleForms
{
    public partial class AdminForm : Form
    {
        public delegate int[] ReturnEmployeesSalariesInOrder(int a, int b);
        private delegate string AsyncReadLog(string filePath);
        private AsyncReadLog LogReader = new AsyncReadLog(Logger.LogRead);
        List<string> lines = new List<string>();
        Admin admin;
        delegate int SumofAges(List<int> l);

        public string AdminInformationsString = AllPaths.GetAdminInformationsFilePath(), AskForPromotionString = AllPaths.GetAskForPromotionFilePath(),
                      EmployeeString = AllPaths.GetEmployeeFilepath(), BillsString = AllPaths.GetBillFilePath(), 
                      xmlfilepath = AllPaths.GetXMLFilePath(), filepath = AllPaths.GetEmployeeFilepath();

        public string senior = ImportantWords.GetSeniorString(), junior = ImportantWords.GetJuniorString(),
            man = ImportantWords.GetManString(), woman = ImportantWords.GetWomanString(),
            mechanical = ImportantWords.GetMechanicalString(), electrical = ImportantWords.GetElectricalString();
        string[] informations;

        static int id = 0;

        public AdminForm(string name, string password)
        {
            InitializeComponent();
            string fn, ln, g, code;
            int i, balance;
            using (TextReader twst = new StreamReader(AllPaths.GetAdminInformationsFilePath()))
            {
                fn = twst.ReadLine();
                ln = twst.ReadLine();
                i = Int32.Parse(twst.ReadLine());
                g = twst.ReadLine();
                code = twst.ReadLine();
                balance = Int32.Parse(twst.ReadLine());
            }
            admin = new Admin(fn,ln,i,g, Admin.DecodeThecode(code).Trim('\0'),balance);

            StringBuilder sb = new StringBuilder();
            if (File.Exists(AskForPromotionString))
            {
                lines = File.ReadAllLines(AskForPromotionString).ToList();
                if(lines.Count == 0) MessageBox.Show("No promotion requests");
                else
                {
                    using (TextWriter tw = new StringWriter(sb))
                    {
                        foreach (string line in lines)
                        {
                            DialogResult dialogresult = MessageBox.Show(line, "Do you want to promote him?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogresult == DialogResult.Yes)
                            {
                                informations = line.Split(' ');
                                if (informations.Length > ImportantWords.GetMinimumLength())
                                {
                                    for(int k = 0; k < 10; k++)
                                    {
                                        if (k == 7)
                                        {
                                            tw.Write("5000");  tw.Write(" ");
                                        }
                                        else if (k == 8)
                                        {
                                            tw.Write(senior); tw.Write(" ");
                                        }
                                        else
                                        {
                                            tw.Write(informations[k]);
                                            if(k != 9) tw.Write(" ");
                                        }
                                    }
                                    tw.WriteLine();
                                    admin.removeemployee(Convert.ToInt32(informations[5]));
                                    MessageBox.Show("Employee promoted");
                                }
                            }
                        }
                    }
                    FileStream oFileStream = new FileStream(EmployeeString, FileMode.Open, FileAccess.Write);
                    StreamWriter oStreamWriter = new StreamWriter(oFileStream);
                    oFileStream.Seek(0, SeekOrigin.End);
                    oStreamWriter.WriteLine(sb.ToString());
                    oStreamWriter.Close();
                    File.WriteAllText(AskForPromotionString,string.Empty);
                }
            }
            else MessageBox.Show("No promotion requests");

            string filename = EmployeeString;
            FileInfo fi = new FileInfo(filename);
            DirectoryInfo di = fi.Directory;
            FileInfo[] files = di.GetFiles();
            foreach(FileInfo f in files)
            {
                if(f.Extension==".txt") AllFilesCombobox.Items.Add(f);
            }
        }

        private void SeeWhoLoggedInButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(Logger.LogRead(AllPaths.GetOpenedAccountFilepath()));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
        }

        private void ViewTheBillsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = BillsString, DirectoriesNames = "", FileInfoNames = "";
                FileInfo fi = new FileInfo(fileName);
                fi.Refresh();
                bool exists = fi.Exists ? true : false;

                if (exists)
                {
                    DirectoryInfo di = fi.Directory;
                    FileInfo[] files = di.Parent.GetFiles();
                    DirectoryInfo[] dirs = di.Parent.GetDirectories();

                    MessageBox.Show("The file exists, and here is some properties: \n\n" + "DirectoryName: " + fi.DirectoryName + "   FullName: " + fi.FullName + "   Extension: " + 
                        fi.Extension + "  Name: " + fi.Name + "   Length: " + fi.Length + "  CreationTime: " + fi.CreationTime +  "   and it is in the" + " directory: " + di + 
                        "  that have " + di.Parent.Name + " as a parent");
                    
                    foreach (DirectoryInfo d in dirs) { DirectoriesNames = DirectoriesNames + " " + d.Name; }
                    MessageBox.Show("The directories names are: " + DirectoriesNames);
                    foreach (FileInfo f in files) { FileInfoNames = FileInfoNames + " " + f.Name; }
                    if (FileInfoNames != "")  MessageBox.Show("The FileInfo names are: " + FileInfoNames);
                }
                else MessageBox.Show("The file doesn't exists, it'll be created");

                Bill.CreateFileTextForTheBillsUsingTextwriters();
                MessageBox.Show(Logger.LogRead(AllPaths.GetBillFilePath()));
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int[] AscendingOrder(int a, int b)
        {
            int[] arr = new int[2];
            if (a > b) { arr[0] = b; arr[1] = a; return arr; }
            else if (a == b) { arr[0] = -1; arr[1] = -1; return arr; }
            else { arr[0] = a; arr[1] = b; return arr; }
        }

        private int[] DescendingOrder(int a, int b)
        {
            int[] arr = new int[2];
            if (a > b) { arr[0] = a; arr[1] = b; return arr; }
            else if (a == b) { arr[0] = -1; arr[1] = -1; return arr; }
            else { arr[0] = b; arr[1] = a; return arr; }
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (OrderComparisonComboBox.SelectedItem != null)
                {
                    if (Employee1IDNumericUpDown.Value != 0)
                    {
                        if (Employee2IDNumericUpDown.Value != 0)
                        {
                            if (Convert.ToInt32(Employee1IDNumericUpDown.Value) != Convert.ToInt32(Employee2IDNumericUpDown.Value))
                            {
                                string[] a = new string[2];
                                int[] s = new int[2];
                                int counter = 0;
                                lines = File.ReadAllLines(filepath).ToList();
                                foreach (string line in lines)
                                {
                                    informations = line.Split(' ');
                                    if (informations.Length > ImportantWords.GetMinimumLength())
                                    {
                                        if (Convert.ToInt32(informations[5]) == Convert.ToInt32(Employee1IDNumericUpDown.Value) ||
                                            (Convert.ToInt32(informations[5]) == Convert.ToInt32(Employee2IDNumericUpDown.Value)))
                                        {
                                            a[counter] = informations[0];
                                            s[counter] = Convert.ToInt32(informations[7]);
                                            counter++;
                                        }
                                    }
                                }

                                if ((a[0] != null) && (a[1] != null))
                                {
                                    ReturnEmployeesSalariesInOrder employeeorder;
                                    if (OrderComparisonComboBox.SelectedItem.ToString() == "Compare in ascending order")
                                    {
                                        employeeorder = new ReturnEmployeesSalariesInOrder(AscendingOrder);
                                        int[] arr = employeeorder(s[0], s[1]);
                                        if ((arr[0] == -1) && (arr[1] == -1))
                                        {
                                            string u = a[1].ToString() + "  and " + a[0].ToString();
                                            ResultTextBox.Text = u;
                                        }
                                        else if (arr[0] == s[1])
                                        {
                                            string u = a[1].ToString() + "  then " + a[0].ToString();
                                            ResultTextBox.Text = u;
                                        }
                                        else
                                        {
                                            string u = a[0].ToString() + "  then " + a[1].ToString();
                                            ResultTextBox.Text = u;
                                        }
                                    }
                                    if (OrderComparisonComboBox.SelectedItem.ToString() == "Compare in descending order")
                                    {
                                        employeeorder = new ReturnEmployeesSalariesInOrder(DescendingOrder);
                                        int[] arr = employeeorder(s[0], s[1]);
                                        if ((arr[0] == -1) && (arr[1] == -1))
                                        {
                                            string u = a[1].ToString() + "  and " + a[0].ToString();
                                            ResultTextBox.Text = u;
                                        }
                                        else if (arr[0] == s[0])
                                        {
                                            string u = a[0].ToString() + "  then " + a[1].ToString();
                                            ResultTextBox.Text = u;
                                        }
                                        else
                                        {
                                            string u = a[1].ToString() + "  then " + a[0].ToString();
                                            ResultTextBox.Text = u;
                                        }
                                    }
                                }
                                else if (a[0] == a[1]) MessageBox.Show("This is the same person or these ID doesn't exists");
                                else MessageBox.Show("One of these ID does not exists");
                            }
                            else MessageBox.Show("You chose the same ID, please choose different ID");
                        }
                        else MessageBox.Show("Employee ID should be bigger than 0");

                    }
                    else MessageBox.Show("Employee ID should be bigger than 0");
                }
                else MessageBox.Show("Please choose a comparision order");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void FormClose(object sender, EventArgs e)
        {
            try { this.Close(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BinarySearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Sales> l = new List<Sales>();
                lines = File.ReadAllLines(filepath).ToList();
                int numberoflines = 1;
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength())
                    {
                        l.Add(new Sales(Convert.ToInt32(informations[4]), Convert.ToInt32(informations[7])));
                        numberoflines++;
                    }
                }
                if (SalaryCombobox.SelectedItem != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    IComparer<Sales> salescompare = new SalesComparer();
                    
                    l.Insert(l.Count, new Sales(Convert.ToInt32(WorkingyearsnumericUpDown.Value), Convert.ToInt32(SalaireComboBox.SelectedItem)));
                    l.Sort(salescompare);

                    Sales searchPoint = new Sales(Convert.ToInt32(YearsOfWorkingNumericUpDown.Value), Convert.ToInt32(SalaryCombobox.SelectedItem));
                    int position = l.BinarySearch(searchPoint, salescompare);
                   
                    if (position < 0) MessageBox.Show("This point: " + searchPoint.Yearsofworking * searchPoint.Salary + " doesn't exist, but if it " +
                    "would exist it would be at position: " + (-position) + " out of " + numberoflines);
                    else MessageBox.Show("This point: " + searchPoint.Yearsofworking * searchPoint.Salary + " is at position: " + position + " out of " + numberoflines);
                    
                }
                else { MessageBox.Show("Please choose a salary"); }
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void GenerateThenewCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(AdminInformationsString))
                {
                    if (TheActualCodeTextBox.Text == admin.Secretcode)
                    {
                        admin.Secretcode = admin.generatesecretcode();
                        admin.SaveTheCodeInAFile(admin.EncodeThecode(admin.Secretcode) , filepath);
                    }
                    else MessageBox.Show("Wrong password");
                }
                else MessageBox.Show("File doesn't exist, youd have to create it manually");
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AsynchroneouslySeeWhoLoggedInButton_Click(object sender, EventArgs e)
        {
            AsyncCallback aCallBack = new AsyncCallback(LogReadCallBack);
            IAsyncResult aResult = LogReader.BeginInvoke(AllPaths.GetOpenedAccountFilepath(), aCallBack, null);
        }

        public void LogReadCallBack(IAsyncResult asyncResult)
        {
            MessageBox.Show(LogReader.EndInvoke(asyncResult));
        }
        
        private void GetTheEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                lines = File.ReadAllLines(filepath).ToList();
                List<Engineers> l = new List<Engineers>();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength())
                    {
                        Engineers p = new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3], Convert.ToInt32(informations[4]), 
                                    Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8], Convert.ToDouble(informations[7]), informations[9]);
                        l.Add(p);
                    }
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                id = Convert.ToInt32(GetTheNameNumericUpDown.Value);
                Engineers k = l.Find(new Predicate<Engineers>(FindID));
                if (k == null) { MessageBox.Show("There is no employee with this ID"); }
                else
                {
                    string s = "Name: " + k.Firstname + " LastName: " + k.Lastname + " Age: " + k.Age + " Gender: " + k.Gender + " Years of working: " + k.Yearsofworking + 
                                " EmployeeID: " + k.EmployeeID + " Employee password: " + k.Employeepassword + " Salary: " + k.Salary + " Position: " + k.Position;

                    if (k.Degree.All(char.IsDigit)) s += " Money earned per year: " + Convert.ToInt32(k.Degree);
                    else  s += " Degree: " + k.Degree;
                    MessageBox.Show(s);
                }
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private static bool FindID(Engineers e)
        {
            return e.EmployeeID == id;
        }
        private void GetEmployeesButton_Click(object sender, EventArgs e)
        {
            try
            {
                string NamesHavingLessLetters = "", NamesHavingMoreLetters = "";
                if (MaxFirstNameLettersNumericUpDown.Value < 0) MessageBox.Show("The value must be positive");
                else if (MaxFirstNameLettersNumericUpDown.Value != 0)
                {
                    List<string> lines = new List<string>(), l = new List<string>();
                    lines = File.ReadAllLines(filepath).ToList();
                    foreach (string line in lines)
                    {
                        informations = line.Split(' ');
                        if(informations.Length > ImportantWords.GetMinimumLength()) l.Add(informations[0]);
                    }
                    if (l.Count != 0)
                    {
                        var a = from word in l where word.Length <= (MaxFirstNameLettersNumericUpDown.Value) select word;
                        var b = l.Where(w => w.Length > MaxFirstNameLettersNumericUpDown.Value);
                        if (a != null)
                        {
                            foreach (var w in a) { NamesHavingLessLetters = NamesHavingLessLetters + w + " "; }
                            if (NamesHavingLessLetters == "") MessageBox.Show("No names have less than this number of characters");
                            else MessageBox.Show(NamesHavingLessLetters);
                            foreach (var w in b) { NamesHavingMoreLetters = NamesHavingMoreLetters + w + " "; }
                            if(NamesHavingMoreLetters!="") MessageBox.Show("The others are: " + NamesHavingMoreLetters);
                            else MessageBox.Show("No names have more than this number of characters");
                        }
                        else MessageBox.Show("List is empty");
                    }
                    else MessageBox.Show("List is empty");
                }
                else { MessageBox.Show("No employees with this maximum number of letters in their firstname"); }
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void RemoveEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(RemoveEmployeeIDNumericUpDown.Value) > 0)
                {
                    admin.removeemployee(Convert.ToInt32(RemoveEmployeeIDNumericUpDown.Value));
                }
                else MessageBox.Show("Give an ID that is positive and not equal to 0");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                string employeepath = AllPaths.GetEmployeeFilepath();
                File.WriteAllLines(employeepath, File.ReadAllLines(employeepath).Where(l => !string.IsNullOrWhiteSpace(l)));
            }
        }

        private void agesInDescendingOrderUsingDelegateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> AgeList = new List<int>();
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if(informations.Length > ImportantWords.GetMinimumLength()) AgeList.Add(Convert.ToInt32(informations[2]));
                }
                AgeList.Sort(delegate (int x, int y)
                {
                    if (x < y) return 1;
                    else if (x == y) return 0;
                    else return -1;
                });
                string s = "";
                foreach (int i in AgeList) { s = s + i.ToString() + " "; }
                MessageBox.Show(s);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void theEmployeesByTheirNameinDescendingOrderUsingComparerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> FirstNameList = new List<string>();
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength()) FirstNameList.Add(informations[0]);
                }
                FirstNameList.Sort(new StringComparer());

                string allnames = "";
                foreach (string s in FirstNameList) { allnames = allnames + s + "  "; }
                MessageBox.Show(allnames);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void theBillssalariesIncludedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string file = AllPaths.GetBillFilePath(), fn, ln, g, code;
                int i, balance;
                List<int> l = new List<int>();
                lines = File.ReadAllLines(file).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if(informations.Length > 2) l.Add(Convert.ToInt32(informations[3]));
                }
                using (TextReader twst = new StreamReader(AdminInformationsString))
                {
                    fn = twst.ReadLine();
                    ln = twst.ReadLine();
                    i = Int32.Parse(twst.ReadLine());
                    g = twst.ReadLine();
                    code = twst.ReadLine();
                    balance = Int32.Parse(twst.ReadLine());
                }
                using (TextWriter tw = new StreamWriter(AdminInformationsString))
                {
                    tw.WriteLine(fn); tw.WriteLine(ln); tw.WriteLine(i); tw.WriteLine(g); tw.WriteLine(code);
                    tw.Write((balance - (l.Sum())));
                    
                }
                MessageBox.Show("You have paid: " + l.Sum() + " and you still have: " + (balance - (l.Sum())));
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void employeeFileAlphabeticallyaToZForTheFirstNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Engineers> l = new List<Engineers>();
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength())
                    {
                        l.Add(new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3],
                                Convert.ToInt32(informations[4]), Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8],
                                Convert.ToDouble(informations[7]), informations[9]));
                    }
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                IComparer<Engineers> mycomparer = new FirstNameSort();
                l.Sort(mycomparer);
                string st = "";
                foreach (Engineers s in l)
                {
                    st = st + s.Firstname + " " + s.Lastname + " " + s.Age + " " + s.Gender + " " + s.Yearsofworking + " " + s.EmployeeID + " " + s.Employeepassword
                        + " " + s.Salary + " " + s.Position + " " + s.Degree + " " + "\n";
                }
                MessageBox.Show(st);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void allTheIDUsingStreamBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> ID = new List<int>();
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength()) ID.Add(Convert.ToInt32(informations[5]));
                }
                var list = from i in ID select i;
                StringBuilder sb = new StringBuilder();
                foreach (int j in list) sb.Append(j + " ");
                MessageBox.Show("The ID of the employees are: " + sb.ToString());
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void theNamesOfTheSeniorsusingFindAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lines = File.ReadAllLines(filepath).ToList();
                List<Engineers> l = new List<Engineers>();

                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength())
                    {
                        Engineers p = new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3],
                            Convert.ToInt32(informations[4]), Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8],
                            Convert.ToDouble(informations[7]), informations[9]);
                        l.Add(p);
                    }
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                id = Convert.ToInt32(GetTheNameNumericUpDown.Value);

                List<Engineers> emp = new List<Engineers>();
                emp = l.FindAll(delegate (Engineers en)
                {
                    return en.Position.ToLower() == senior;
                });
                if (emp.Count == 0) MessageBox.Show("There is no senior employees");
                else
                {
                    string allnames = "";
                    foreach (Engineers eng in emp) allnames = allnames + eng.Firstname + "\n";
                    MessageBox.Show("The senior employees are:\n" + allnames);
                }
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void allMoneyearnedFromDelegateAndLINQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> l = new List<string>();
                lines = File.ReadAllLines(filepath).ToList();

                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength()) l.Add(informations[9]);
                }
                if (l.TrueForAll(delegate (string s)
                {
                    return (int.TryParse(s, out int k));
                }))
                {
                    MessageBox.Show("All the Employees are sales employees");
                    int total = l.Sum(x => Convert.ToInt32(x));
                    MessageBox.Show("The sum of moneyearned is: " + total);
                }
                else
                {
                    MessageBox.Show("Not all the Employees are sales employees, we will remove the engineers from the list.");
                    l.RemoveAll(delegate (string s)
                    {
                        return (!int.TryParse(s, out int k));
                    });
                    string salesstring = "";
                    foreach (string s in l) salesstring = salesstring + s + " ";
                    MessageBox.Show("The money earned are: " + salesstring + "\n" + "Their sum is: " + l.Sum(x => Convert.ToInt32(x)));
                }
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void betweenEmployeeAndAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IDictionary<int, int> AgeNumber = new Dictionary<int, int>(new AgeComparer()) { };
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength())
                    {
                        if (AgeNumber.ContainsKey(Convert.ToInt32(informations[2])))
                        {
                            AgeNumber[Convert.ToInt32(informations[2])] = AgeNumber[Convert.ToInt32(informations[2])] + 1;
                        }
                        else AgeNumber.Add(Convert.ToInt32(informations[2]), 1);
                    }
                }
                string s = "";
                foreach (KeyValuePair<int, int> kvp in AgeNumber) s = s + kvp.Key + ": " + kvp.Value + "\n";

                MessageBox.Show(s);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void sumOfAgesLessThan25AndAverageOfAgesLessThan23lambdaExpressionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int agesum = 25, ageaverage = 23;
                List<int> list = new List<int>();
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength() && Convert.ToInt32(informations[2]) < agesum)
                    {
                        list.Add(Convert.ToInt32(informations[2]));
                    }
                }
                SumofAges sum = y => list.Sum();
                int x = sum(list);
                double average = list.Where(number => number < ageaverage).Average();
                MessageBox.Show("The sum is: " + x + "\nThe average is: " + average);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void agesLessThan21AndWhoseSalariesAreBiggerThan3000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                int age = 21, salariess = 3000;
                List<int> l = new List<int>();
                lines = File.ReadAllLines(filepath).ToList();

                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength() && Convert.ToInt32(informations[2]) < age)
                    {
                        l.Add(Convert.ToInt32(informations[7]));
                    }
                }

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                IComparer<int> intCompare = new SalaryComparer();

                int searchPoint = salariess;
                int position = l.BinarySearch(searchPoint, intCompare);
                if (position < 0) MessageBox.Show("This point: " + searchPoint + " doesn't exist, but if it would exist it would be at position: " + (-position));
                else MessageBox.Show("This point: " + searchPoint + " is at position: " + position + " out of " + l.Count);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fn = "", ln = "", age = "", str = FirstNameAndLastNameAndAgeTextBox.Text;
                char[] b = new char[str.Length];
                int counter = 0, i = 0;
                double salary = 1500;
                string gender = man, position = junior;
                using (StringReader sr = new StringReader(str))
                {
                    sr.Read(b, 0, str.Length);
                }
                while (i < str.Length)
                {
                    if (b[i] != ' ')
                    {
                        if (counter == 0) fn = fn + b[i];
                        else if (counter == 1) ln = ln + b[i];
                        else if (counter == 2) age = age + b[i];
                    }
                    else { counter++; }
                    i++;
                }
                if ((fn != "") && (int.TryParse(fn, out int w) == false) && (fn.Length>2))
                {
                    if ((ln != "") && (int.TryParse(ln, out int j) == false) && (ln.Length > 2))
                    {
                        if (int.TryParse(age, out int k))
                        {
                            if ((k >= 18) && (k<=64))
                            {
                                if ((CreateMenRadioButton.Checked == false) && (CreateWomenRadioButton.Checked == false))
                                {
                                    MessageBox.Show("Choose a gender");
                                }
                                else
                                {
                                    if (CreateMenRadioButton.Checked == true) gender = man;
                                    else if (CreateWomenRadioButton.Checked == true) gender = woman;
                                    if ((JuniorRadioButton.Checked == false) && (SeniorRadioButton.Checked == false))
                                    {
                                        MessageBox.Show("Choose a position");
                                    }
                                    else
                                    {
                                        if (JuniorRadioButton.Checked == true) { position = junior; salary = 1500; }
                                        else if (SeniorRadioButton.Checked == true) { position = senior; salary = 5000; }
                                        if (Convert.ToInt32(CreateYearsOfWorkingNumericUpDown.Value) >= 0)
                                        {
                                            if (EmployeeTree.SelectedNode != null)
                                            {
                                                if (EmployeeTree.Nodes[0].IsSelected)
                                                {
                                                    admin.addemployees(fn, ln, k, gender, Convert.ToInt32(CreateYearsOfWorkingNumericUpDown.Value),
                                                                    Employee.GetLastIDGiven(), Convert.ToInt32(Employee.GenerateEmployeePassword()),
                                                                    position, salary, "0");
                                                }
                                                else if (EmployeeTree.Nodes[1].Nodes[0].IsSelected)
                                                {
                                                    admin.addemployees(fn, ln, k, gender, Convert.ToInt32(CreateYearsOfWorkingNumericUpDown.Value),
                                                                    Employee.GetLastIDGiven(), Convert.ToInt32(Employee.GenerateEmployeePassword()),
                                                                    position, salary, mechanical);
                                                }
                                                else if (EmployeeTree.Nodes[1].Nodes[1].IsSelected)
                                                {
                                                    admin.addemployees(fn, ln, k, gender, Convert.ToInt32(CreateYearsOfWorkingNumericUpDown.Value),
                                                                    Employee.GetLastIDGiven(), Convert.ToInt32(Employee.GenerateEmployeePassword()),
                                                                    position, salary, electrical);
                                                }
                                                MessageBox.Show("Employee added succesfully");
                                            }
                                            else MessageBox.Show("Select a node");
                                        }
                                        else MessageBox.Show("Choose a years of working >=0");
                                    }
                                }
                            }
                            else MessageBox.Show("Enter an age between 18 and 64");
                        }
                        else MessageBox.Show("Enter an age between 18 and 64");
                    }
                    else MessageBox.Show("Enter a last name whose length is at least 3");
                }
                else MessageBox.Show("Enter a first name whose length is at least 3");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                string employeepath = AllPaths.GetEmployeeFilepath();
                File.WriteAllLines(employeepath, File.ReadAllLines(employeepath).Where(l => !string.IsNullOrWhiteSpace(l)));
            }
        }

        private void EmployeeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void theCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show(admin.Secretcode); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        { }

        private void AllFilesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void CopyFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllFilesCombobox.SelectedItem != null)
                {
                    admin.CopyFile(AllFilesCombobox.SelectedItem.ToString());
                }
                else MessageBox.Show("Choose a file");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MaxFirstNameLettersNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
        }

        private void adminInformationsInBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { admin.BinaryReaderAndWriter(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void seniorsAndJuniorsNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Engineers> AllNames = new List<Engineers>();
            lines = File.ReadAllLines(filepath).ToList();
            foreach(string line in lines)
            {
                informations = line.Split(' ');
                if (informations.Length > ImportantWords.GetMinimumLength())
                {
                    AllNames.Add(new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3], Convert.ToInt32(informations[4]), 
                            Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8], Convert.ToDouble(informations[7]), informations[9]));
                }
            }

            IEnumerable<IGrouping<double, string>> query = AllNames.GroupBy(x => x.Salary, x => x.Firstname);
            string seniors = "", juniors = "";
            double[] keys = new double[2];
            foreach(IGrouping<double,string> a in query)
            {
                if (a.Key == 1500)
                {
                    keys[0] = a.Key;
                    foreach (string name in a) { juniors = juniors + name + " "; }
                }
                else if (a.Key == 5000)
                {
                    keys[1] = a.Key;
                    foreach (string name in a) { seniors = seniors + name + " "; }
                }
            }
            MessageBox.Show("The juniors who are paid " + keys[0] + " are: " + juniors + "\nThe seniors who are paid " + keys[1] + " are: " + seniors);
        }


        private void orderTheIDByDescendingOrderAndTakeTheFirst3IDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] AllID = new int[File.ReadAllLines(filepath).Count()];
            int counter = 0;
            lines = File.ReadAllLines(filepath).ToList();
            foreach(string line in lines)
            {
                informations = line.Split(' ');
                if (informations.Length > ImportantWords.GetMinimumLength())
                {
                    AllID[counter] = Convert.ToInt32(informations[5]);
                    counter++;
                }
            }
            IEnumerable<int> TopThreeID = AllID.OrderByDescending(x => x).Take(3);
            string s = "The top three ID are: ";
            counter = 0;
            foreach (var a in TopThreeID)
            {
                if(counter != 2) s = s + a.ToString() + ", ";
                else s = s + a.ToString();
                counter++;
            }
            MessageBox.Show(s);
        }

        private void distinctAgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> ages = new List<int> { };
            lines = File.ReadAllLines(filepath).ToList();
            foreach (string line in lines)
            {
                informations = line.Split(' ');
                if (informations.Length > ImportantWords.GetMinimumLength()) ages.Add(Convert.ToInt32(informations[2]));
            }
            IEnumerable<int> DistinctAges = ages.Distinct();
            string s = "The distinct ages by ascending order are: \n";
            DistinctAges = DistinctAges.OrderBy(x => x);
            foreach (var a in DistinctAges) s = s + a + "\n";
            MessageBox.Show(s);
        }

        private void sortedFileOfYearsOfWorkingInAscendingOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Engineers> l = new List<Engineers>();
                lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength())
                    {
                        Engineers p = new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3], Convert.ToInt32(informations[4]), 
                                    Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8], Convert.ToDouble(informations[7]), informations[9]);
                        l.Add(p);
                    }
                }
                l.Sort(delegate (Engineers a, Engineers b)
                {
                    if (a.Yearsofworking < b.Yearsofworking) return -1;
                    else if (a.Yearsofworking == b.Yearsofworking) return 0;
                    else return 1;
                });
                File.WriteAllText(filepath, string.Empty);
                using (TextWriter tw = new StreamWriter(filepath))
                {
                    foreach (Engineers eng in l)
                    {
                        tw.Write(eng.Firstname + " " + eng.Lastname + " " + eng.Age + " " + eng.Gender + " " + eng.Yearsofworking + " " + eng.EmployeeID + " " +
                            eng.Employeepassword + " " + eng.Salary + " " + eng.Position + " " + eng.Degree);
                        tw.WriteLine();
                    }
                }
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void createJSONFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serializer = new DataSerializer(new JsonSerializerAdapter());
            serializer.CreateJSONFileOfEmployees();
        }

        private void createXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serializer = new DataSerializer(new XMLSerializerAdapter());
            serializer.CreateXMLFileOfEmployees();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }

    public class EmployeeTaskComparer : IEqualityComparer<Engineers>
    {
        public bool Equals(Engineers x, Engineers y)
        {
            return ((x.Firstname == y.Firstname) && (x.EmployeeID == y.EmployeeID));
        }
        public int GetHashCode(Engineers x)
        {
            return x.EmployeeID.GetHashCode();
        }
    }
    public class AgeComparer : IEqualityComparer<int>
    {
        public bool Equals(int x,int y)
        {
            return x == y;
        }
        public int GetHashCode(int x)
        {
            return x.GetHashCode();
        }
    }
    public class StringComparer:Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            if (x.CompareTo(y) < 0) return 1;
            else if (x.CompareTo(y)==0) return 0;
            else return -1;
        }
    }
    class SalesComparer : Comparer<Sales>
    {
        public override int Compare(Sales x, Sales y)
        {
            double a = x.Yearsofworking * x.Salary;
            double b = y.Yearsofworking * y.Salary;
            if (a < b) return -1;
            else if (a == b) return 0;
            else return 1;
        }
    }
    class FirstNameSort : Comparer<Engineers>
    {
        public override int Compare(Engineers x, Engineers y)
        {
            if (x.Firstname.CompareTo(y.Firstname) < 0) return -1;
            else if (x.Firstname.CompareTo(y.Firstname) == 0) return 0;
            else return 1;
        }
    }
    class SalaryComparer: Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (x < y) return -1;
            else if (x == y) return 0;
            else return 1;
        }
    } 
}