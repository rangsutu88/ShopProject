using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using ShopProject.Classes.Paths;
using ShopProject.Classes.RepeatedWords;

namespace ShopProject.Classes.Bills
{
    class Bill
    {
        private static readonly double electricitybill = 1500, phonebill = 200, internetbill = 400, shopbill = 8000;

        public static void CreateFileTextForTheBillsUsingTextwriters()
        {
            try
            {
                string file = AllPaths.GetBillFilePath(), filepath = AllPaths.GetEmployeeFilepath();
                List<string> lines = File.ReadAllLines(filepath).ToList();
                string[] informations;
                int SumOfSalaries = 0;

                foreach (string line in lines)
                {
                    informations = line.Split(' ');
                    if (informations.Length > ImportantWords.GetMinimumLength()) SumOfSalaries = SumOfSalaries + Convert.ToInt32(informations[7]);
                }
                using (TextWriter tw = new StreamWriter(file))
                {
                    tw.Write("Electricity bill is: ");  tw.Write(electricitybill);    tw.WriteLine();
                    tw.Write("Phone bill is: ");        tw.Write(phonebill);          tw.WriteLine();
                    tw.Write("Internet bill is: ");     tw.Write(internetbill);       tw.WriteLine();
                    tw.Write("Shop bill is: ");         tw.Write(shopbill);           tw.WriteLine();
                    tw.Write("Salary bill is: ");       tw.Write(SumOfSalaries);      tw.WriteLine();
                }
            }
            catch(DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}