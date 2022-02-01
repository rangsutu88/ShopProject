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
    public sealed class Sales: Employee
    {
        private double moneyearnedperyear;

        public Sales(int yearsofworking, int salary)
        {
            this.Yearsofworking = yearsofworking;
            this.Salary = salary;
        }

        public Sales(string fn, string ln, int age, string gender, int yearsofworking, int employeeID, int employeepassword, double salary,
            string position, double money) : base(fn, ln, age, gender, yearsofworking, employeeID, employeepassword, position, salary)
        {
            this.Moneyearnedperyear = money;
        }
        public double Moneyearnedperyear
        {
            get { return moneyearnedperyear; }
            set { moneyearnedperyear = value; }
        }
        public sealed override int removeemployee()
        {
            int i = base.removeemployee();
            if (i == 1)
            {
                MessageBox.Show("You are a senior sales so you can only remove junior sales");
                return 1;
            }
            else
            {
                MessageBox.Show("You are a junior sales so you can't remove employees");
                return -1;
            }
        }
        public sealed override int addemployee()
        {
            int i = base.addemployee();
            if (i == 1)
            {
                MessageBox.Show("You are a senior sales so you can only add sales");
                return Employee.GetLastIDGiven();
            }
            else
            {
                MessageBox.Show("You are a junior sales so you can't add employees");
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
                this.Employeepassword + " " + this.Salary + " " + this.Position + " " + this.Moneyearnedperyear);
        }
    }
}