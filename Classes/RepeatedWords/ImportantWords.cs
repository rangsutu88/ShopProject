using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Classes.RepeatedWords
{
    public class ImportantWords
    {
        internal string senior = "senior", junior = "junior", mechanical = "mechanical", electrical = "electrical", man = "man", woman = "woman";
        internal int minimumlength = 7;
        public static string GetSeniorString()
        {
            ImportantWords p = new ImportantWords();
            return p.senior;
        }

        public static int GetMinimumLength()
        {
            ImportantWords p = new ImportantWords();
            return p.minimumlength;
        }

        public static string GetJuniorString()
        {
            ImportantWords p = new ImportantWords();
            return p.junior;
        }

        public static string GetMechanicalString()
        {
            ImportantWords p = new ImportantWords();
            return p.mechanical;
        }

        public static string GetElectricalString()
        {
            ImportantWords p = new ImportantWords();
            return p.electrical;
        }

        public static string GetManString()
        {
            ImportantWords p = new ImportantWords();
            return p.man;
        }

        public static string GetWomanString()
        {
            ImportantWords p = new ImportantWords();
            return p.woman;
        }
    }
}