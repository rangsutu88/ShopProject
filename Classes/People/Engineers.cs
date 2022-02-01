using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ShopProject.Interfaces;
using ShopProject.Classes.RepeatedWords;
using ShopProject.Classes.Paths;

namespace ShopProject.Classes.People
{
    public sealed class Engineers : Employee
    {
        private string degree;

        public string mechanical = ImportantWords.GetMechanicalString(), electrical = ImportantWords.GetElectricalString();

        public Engineers() { }

        public Engineers(string fn, int ID)
        {
            this.Firstname = fn;
            this.EmployeeID = ID;
        }
        public Engineers(string fn, string ln, int age, string gender, int yearsofworking, int employeeID, int employeepassword,
            string position, string degree):base(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, position)
        {
            this.Degree = degree;
        }

        public Engineers(string fn, string ln, int age, string gender, int yearsofworking, int employeeID, int employeepassword, string position, 
            double salary, string degree) : base(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, position,salary)
        {
            this.Degree = degree;
        }
        public string Degree
        {
            get { return degree; }
            set {
                if (value.ToLower() == mechanical) degree = mechanical;
                else if (value.ToLower() == electrical) degree = electrical;
                else if (int.TryParse(value, out int k) == true) degree = value;
                else MessageBox.Show("Degree must be Mechanical or Electrical");
            }
        }

        public sealed override int removeemployee()
        {
            int i = base.removeemployee();
            if (i == 1)
            {
                MessageBox.Show("You are a senior engineer so you can only remove junior engineers");
                return 1;
            }
            else
            {
                MessageBox.Show("You are a junior engineer so you can't remove employees");
                return -1;
            }
        }

        public sealed override int addemployee()
        {
            int i= base.addemployee();
            if (i == 1)
            {
                MessageBox.Show("You are a senior engineer so you can only add engineers");
                return Employee.GetLastIDGiven();
            }
            else
            {
                MessageBox.Show("You are a junior engineer so you can't add employees");
                return -1;
            }
        }

        public sealed override int ViewEmployees()
        {
            string path = AllPaths.GetEmployeeFilepath();
            string[] informations;
            List<string> lines = File.ReadAllLines(path).ToList();
            string s = "";
            bool isSenior = false;
            if (base.ViewEmployees() == 1) isSenior = true;

            foreach (string line in lines)
            {
                informations = line.Split(' ');
                if ((isSenior || informations[8].ToLower() == junior) && informations.Length > ImportantWords.GetMinimumLength())
                {
                    s = s + new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]),
                    informations[3], Convert.ToInt32(informations[4]), Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]),
                    informations[8], Convert.ToDouble(informations[7]), informations[9]).ToString() + "\n";
                }
            }
            MessageBox.Show(s);
            if (isSenior) return 1;
            return 0;
        }
        public override string ToString()
        {
            return (this.Firstname + " " + this.Lastname + " " + this.Age + " " + this.Gender + " " + this.Yearsofworking + " " + this.EmployeeID + " " +
                this.Employeepassword + " " + this.Salary + " " + this.Position + " " + this.Degree);
        }

        public string GetDetails()
        {
            return "Name: " + this.Firstname + " LastName: " + this.Lastname + " Age: " + this.Age + " Gender: " + this.Gender + " Years of working: " + this.Yearsofworking +
                      " EmployeeID: " + this.EmployeeID + " Employee password: " + this.Employeepassword + " Salary: " + this.Salary + " Position: " + this.Position;
        }
    }
}