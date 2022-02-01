using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopProject.PeopleForms;

namespace ShopProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new EmployeeForm("b","c", 30, "Man" ,28, 2, 2623, 1413, "Senior", "Electrical"));
            //Application.Run(new EmployeeForm("a","b", 31, "Woman",21, 3, 462, 1500, "Junior", "Mechanical"));
            //Application.Run(new EmployeeForm("a","b",61,"Man",27,1,1390,4090,"Junior","91309"));
            //Application.Run(new EmployeeForm("e", "f", 49, "Woman", 3, 5, 3309, 1375, "Senior", "20437"));    
            
            //Application.Run(new AdminForm("abc",""));
            Application.Run(new Form1());
        }
    }
}
