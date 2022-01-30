using ShopProject.Classes.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Interfaces
{
    interface IAdmin
    {
        void LoginToTheAccount(string loginName, string password);
        string generatesecretcode();
        byte[] EncodeThecode(string code);
        void SaveTheCodeInAFile(byte[] encodedcode, string file);

        void CopyFile(string fromFile);
        void BinaryReaderAndWriter();
        void removeemployee(int id);
        void addemployees(string fn, string ln, int age, string gender, int yearsofworking, int employeeID, int employeepassword, string position, double salary, string degree);
    }
}