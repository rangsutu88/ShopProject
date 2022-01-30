using System;
using System.IO;

namespace ShopProject.Classes.Paths
{
    class AllPaths
    {
         string Employeefilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\Employees.txt",
            AddEmployeefilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\AddedAndRemovedEmployees.txt",
            newfilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\Employeessss.txt",
            OpenedAccountTimefilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\OpenedAccountTime.txt",
            Billfilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\Bills.txt",
            Passwordpath = Directory.GetCurrentDirectory() + "\\AllFiles\\Passwords.txt",
            newdesignfilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\NewDesign.xml",
            AdminInformationspath = Directory.GetCurrentDirectory() + "\\AllFiles\\AdminInformations.txt",
            AdminCodepath = Directory.GetCurrentDirectory() + "\\AllFiles\\AdminCode.txt",
            AskForPromotionpath = Directory.GetCurrentDirectory() + "\\AllFiles\\AskForPromotion.txt",
            BinaryInformationpath = Directory.GetCurrentDirectory() + "\\AllFiles\\BinaryAdminInformations.bin",
            xmlfilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\data.xml",
            jsonfilepath = Directory.GetCurrentDirectory() + "\\AllFiles\\JSONEmployeesFile.json";

        public static string GetEmployeeFilepath()
        {
            AllPaths p = new AllPaths();
            return p.Employeefilepath;
        }

        public static string GetAddedAndRemovedEmployeeFilepath()
        {
            AllPaths p = new AllPaths();
            return p.AddEmployeefilepath;
        }

        public static string GetnewfilePath()
        {
            AllPaths p = new AllPaths();
            return p.newfilepath;
        }

        public static string GetOpenedAccountFilepath()
        {
            AllPaths p = new AllPaths();
            return p.OpenedAccountTimefilepath;
        }

        public static string GetBillFilePath()
        {
            AllPaths p = new AllPaths();
            return p.Billfilepath;
        }

        public static string GetPasswordFilePath()
        {
            AllPaths p = new AllPaths();

            return p.Passwordpath;
        }

        public static string GetXMLFilePath()
        {
            AllPaths p = new AllPaths();
            return p.xmlfilepath;
        }

        public static string GetJSONFilePath()
        {
            AllPaths p = new AllPaths();
            return p.jsonfilepath;
        }

        public static string GetNewDesignFilePath()
        {
            AllPaths p = new AllPaths();
            return p.newdesignfilepath;
        }

        public static string GetAdminCodeFilePath()
        {
            AllPaths p = new AllPaths();
            return p.AdminCodepath;
        }

        public static string GetAdminInformationsFilePath()
        {
            AllPaths p = new AllPaths();
            return p.AdminInformationspath;
        }

        public static string GetAskForPromotionFilePath()
        {
            AllPaths p = new AllPaths();
            return p.AskForPromotionpath;
        }

        public static string GetBinaryInformationFilePath()
        {
            AllPaths p = new AllPaths();
            return p.BinaryInformationpath;
        }
    }
}