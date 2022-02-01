using System;
using ShopProject.Classes.RepeatedWords;
using static ShopProject.Classes.RepeatedWords.ImportantWords;

namespace ShopProject.Classes.People
{
    abstract public class Person
    {
        private int age;
        private string firstname, lastname, gender;

        public string man = ImportantWords.GetManString(), woman = ImportantWords.GetWomanString();

        public Person() { }
        public Person(string fn, string ln, int Age)
        {
            this.Firstname = fn;
            this.Lastname = ln;
            this.Age = Age;
        }
        public Person(string fn, string ln, int Age, string gender)
        {
            this.Firstname = fn;
            this.Lastname = ln;
            this.Age = Age;
            this.Gender = gender;
        }
        public string Firstname
        {
            get { return firstname; }
            set { if (value.Length > 0) firstname = value;
                else throw new Exception("FirstName should be at least 1 characters");
            }
        }
        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (value.Length > 0) lastname = value;
                else throw new Exception("LastName should be at least 1 characters");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0) age = value;
                else throw new Exception("Age must be a positive value");
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (value.ToLower() == man) gender = man;
                else if (value.ToLower() == woman) gender = woman;
                else throw new Exception("Gender should be Man or Woman");
            }
        }
    }
}