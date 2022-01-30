using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Interfaces
{
    interface IEmployee
    {
        int removeemployee();
        int addemployee();
        string ToString();
        int ViewEmployees();
    }
}