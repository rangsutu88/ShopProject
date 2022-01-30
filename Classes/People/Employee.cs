using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ShopProject.Classes.RepeatedWords;
using ShopProject.Classes.Paths;

namespace ShopProject.Classes.People
{
     public abstract class Employee : Person
    {
        protected int yearsofworking, employeeID, employeepassword;
        protected double salary;
        protected string position;

        public string senior = ImportantWords.GetSeniorString(), junior = ImportantWords.GetJuniorString();

        static string employeefilepath = AllPaths.GetEmployeeFilepath();
        public Employee() { }
        public Employee(string fn, string ln, int age, string gender, int yearsofworking, 
            int employeeID, int employeepassword, string position):base(fn,ln, age, gender)
        {
            this.Yearsofworking = yearsofworking;
            this.EmployeeID = employeeID;
            this.Employeepassword = employeepassword;
            this.Position = position;
            this.Salary = -1;
        }

        public Employee(string fn, string ln, int age, string gender, int yearsofworking,
            int employeeID, int employeepassword, string position, double salary) : base(fn, ln , age, gender)
        {
            this.Yearsofworking = yearsofworking;
            this.EmployeeID = employeeID;
            this.Employeepassword = employeepassword;
            this.Position = position;
            this.Salary = salary;
        }

        public int Yearsofworking
        {
            get { return yearsofworking; }
            set { if (value >= 0) yearsofworking = value;
                else throw new Exception("Years of working must be positive");
            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value == -1)
                {
                    if (this.position.ToLower() == senior) salary = 5000;
                    else if (this.position.ToLower() == junior) salary = 1500;
                }
                else if (value > 0) salary = value;
                else throw new Exception("Salary must be positive");
            }
        }
        public int EmployeeID
        {
            get { return employeeID; }
            set { if (value > 0) employeeID = value;
                else throw new Exception("EmployeeID must be positive"); }
        }
        public int Employeepassword
        {
            get { return employeepassword; }
            set { if (value.ToString().Length > 2) employeepassword = value;
                else throw new Exception("employeepassword must be of 3 integers at least"); }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (value.ToLower() == senior) position = senior;
                else if (value.ToLower() == junior) position = junior;
                else throw new Exception("Position must be " + junior + " or " + senior);
            }
        }

        public virtual int removeemployee()
        {
            if (this.position.ToLower() == senior) { return 1; }
            else return 0;
        }
        public virtual int addemployee()
        {
            if (this.position.ToLower() == senior) { return 1; }
            else return 0;
        }

        public virtual int ViewEmployees()
        {
            if (this.position.ToLower() == senior) { return 1; }
            else return 0;
        }

        public static int GetLastIDGiven()
        {
            List<string> lines = new List<string>();
            string[] informations;
            int lastid = 1;
            lines = File.ReadAllLines(employeefilepath).ToList();
            foreach (string line in lines)
            {
                informations = line.Split(' ');
                if (informations.Length > ImportantWords.GetMinimumLength())
                {
                    if (Convert.ToInt32(informations[5]) > lastid) lastid = Convert.ToInt32(informations[5]);
                }
            }
            return (lastid + 1);
        }
        public static string GenerateEmployeePassword()
        {
            try
            {
                Random rnd = new Random();
                int code = rnd.Next(100, 1000000), counter = 0, numberoflines;
                bool Regeneratecode = true;
                List<string> lines = new List<string>();
                string[] informations;
                while (Regeneratecode == true)
                {
                    lines = File.ReadAllLines(employeefilepath).ToList();
                    numberoflines = lines.Count;
                    foreach (string line in lines)
                    {
                        informations = line.Split(' ');
                        if (informations.Length > ImportantWords.GetMinimumLength())
                        {
                            counter++;
                            if (code == Convert.ToInt32(informations[6]))
                            {
                                Regeneratecode = true;
                                code = rnd.Next(100, 1000000);
                                counter = 0;
                                break;
                            }
                            if (counter == numberoflines) Regeneratecode = false;
                        }
                    }
                }
                return code.ToString();
            }
            catch (DirectoryNotFoundException ex) { return ex.Message; }
            catch (FileNotFoundException ex) { return ex.Message; }
            catch (IOException ex) { return ex.Message; }
            catch { return "Logging failed"; }
        }

        public static void CreateEmployeeText()
        {
            char fn = 'a', ln = 'b';
            Random rnd = new Random();

            string[] gender = { "Man", "Woman" }, position = { "Junior", "Senior" }, degree = { "Electrical", "Mechanical", rnd.Next(100000).ToString() }, salary = { "1500", "5000" };

            if (File.Exists(employeefilepath) == false)
            {
                using (TextWriter tw = new StreamWriter(employeefilepath))
                {

                    for (int i = 0; i < 10; i++)
                    {
                        tw.Write((char)((int)(fn) + i));            tw.Write(" ");
                        tw.Write((char)((int)(ln) + i));            tw.Write(" ");
                        tw.Write(rnd.Next(18, 64));                 tw.Write(" ");
                        tw.Write(gender[rnd.Next(2)]);              tw.Write(" ");
                        tw.Write(rnd.Next(0, 30));                  tw.Write(" ");
                        tw.Write(i + 1);                            tw.Write(" ");
                        tw.Write(rnd.Next(100, 5000));              tw.Write(" ");
                        tw.Write(salary[rnd.Next(0,2)]);            tw.Write(" ");
                        tw.Write(position[rnd.Next(2)]);            tw.Write(" ");
                        tw.Write(degree[rnd.Next(3)]);              tw.WriteLine();
                        degree[2] = rnd.Next(100000).ToString();
                    }
                }
            }
        }
    }
}