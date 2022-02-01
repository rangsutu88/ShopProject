using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShopProject.Interfaces;
using ShopProject.PeopleForms;
using ShopProject.Classes.Paths;
using ShopProject.Classes.RepeatedWords;
using ShopProject.Classes.LoggerClass;

namespace ShopProject.Classes.People
{
    public delegate void LogInEvent(string name, Boolean status);

    sealed public class Admin : Person, IAdmin
    {
        private string secretcode;
        private static float shopbalance;

        public string AdminInformationString = AllPaths.GetAdminInformationsFilePath(), AdminCodeString = AllPaths.GetAdminCodeFilePath(), 
                      BinaryAdminInformationsString = AllPaths.GetBinaryInformationFilePath(), filepath = AllPaths.GetEmployeeFilepath();

        public event LogInEvent LogEvent;

        static string admininformationsfilepath = AllPaths.GetAdminInformationsFilePath(),  employeefilepath = AllPaths.GetEmployeeFilepath(),
                newfilepath = AllPaths.GetnewfilePath();

        public string Secretcode
        {
            get { return secretcode; }
            set
            {
                if (value.Length > -1) secretcode = value;
                else throw new Exception("SecretCode must be of 3 characters at least");
            }
        }
        public float Shopbalance
        {
            get { return shopbalance; }
            set
            {
                if (value > 0) shopbalance = value;
                else throw new Exception("ShopBalance must be positive or the shop will be closed");
            }
        }

        public Admin() { }

        public Admin(string fn) { this.Firstname = fn; }

        public Admin(string fn, string ln, int age, string gender, string secretcode, float shopbalance) : base(fn, ln, age, gender)
        {
            this.Secretcode = secretcode;
            this.Shopbalance = shopbalance;
        }

        public void LoginToTheAccount(string loginName, string password)
        {
            string fn, ln, g, code, decodedcode;
            int i, balance;
            using (TextReader twst = new StreamReader(AdminInformationString))
            {
                fn = twst.ReadLine();
                ln = twst.ReadLine();
                i = Int32.Parse(twst.ReadLine());
                g = twst.ReadLine();
                code = twst.ReadLine();
                balance = Int32.Parse(twst.ReadLine());
            }

            decodedcode = DecodeThecode(code).Trim('\0');

            if ((loginName == fn) && (password == decodedcode))
            {
                LogEvent(loginName, true);
                AdminForm f = new AdminForm(loginName,password);
                f.Show();
            }
            else LogEvent(loginName, false);
        }

        public string generatesecretcode()
        {
            Random rnd = new Random();
            int k, j = rnd.Next(7, 20);
            char u;
            string code = string.Empty;
            for (int i = 0; i < j; i++)
            {
                k = rnd.Next(0, 2);
                if (k == 0)
                {
                    k = rnd.Next(65, 91);
                    u = (char)k;
                    code = code + u;
                }
                else
                {
                    k = rnd.Next(97, 123);
                    u = (char)k;
                    code = code + u;
                }
            }
            return code;
        }
        public byte[] EncodeThecode(string code)
        {
            Encoding ascii = Encoding.ASCII, utf8 = Encoding.UTF8;
            byte[] b = ascii.GetBytes(code);
            byte[] Utf8FromAscii = Encoding.Convert(ascii, utf8, b);
            return Utf8FromAscii;
        }
        public void SaveTheCodeInAFile(byte[] encodedcode, string file)
        {
            try
            {
                string s = "", fn, ln, age, gender, code, shopbalance;
                foreach (byte a in encodedcode)
                {
                    s = s + a + " ";
                }
                using (TextReader tr = new StreamReader(AdminInformationString))
                {
                    fn = tr.ReadLine();  ln = tr.ReadLine();  age = tr.ReadLine();   gender = tr.ReadLine();    code = tr.ReadLine();  shopbalance = tr.ReadLine();
                }
                using (TextWriter tw = new StreamWriter(AdminInformationString))
                {
                    tw.WriteLine(fn);  tw.WriteLine(ln);  tw.WriteLine(age);  tw.WriteLine(gender);   tw.WriteLine(s);  tw.WriteLine(shopbalance);
                }
                using (TextWriter tw = new StreamWriter(AdminCodeString))
                {
                    tw.WriteLine(DecodeThecode(s).Trim('\0'));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static string DecodeThecode(string s)
        {
            string g = "";
            int counter = 0;
            foreach (char c in s)
            {
                if (c == ' ') counter++;
            }
            Encoding utf8 = Encoding.UTF8;

            byte[] b = new byte[s.Length-counter];
            counter = 0;
            
            foreach (char a in s) 
            {
                if (a != ' ') g = g + a;
                else
                {
                    b[counter] = Convert.ToByte(g);
                    counter++;
                    g = "";
                }
            }
            char[] DecodeString = utf8.GetChars(b);
            string DecodedCode = new string(DecodeString);
            return DecodedCode;
        }

        public void CopyFile(string fromFile)
        {
            string toFile = Directory.GetCurrentDirectory() + "\\AllFiles" + "\\Copy" + fromFile;
            fromFile = Directory.GetCurrentDirectory() + "\\AllFiles\\" + fromFile;

            try
            {
                using (FileStream fromStream = new FileStream( fromFile, FileMode.Open))
                {
                    using (FileStream toStream = new FileStream(toFile, FileMode.Create))
                    {
                        int c;
                        do
                        {
                            c = fromStream.ReadByte();
                            if (c != -1) toStream.WriteByte((byte)c);
                        } while (c != -1);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File {0} not found: ", e.FileName);
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Other file copy exception");
                throw;
            }
        }
        public void BinaryReaderAndWriter()
        {
            int[] count = new int[7];
            char[] a, b, d, f;
            int i = 0, c, j;
            List<string> lines = File.ReadAllLines(AdminInformationString).ToList();
            foreach (string line in lines)
            {
                count[i] = line.Length;
                i++;
            }
            using (BinaryReader br = new BinaryReader(new FileStream(AdminInformationString, FileMode.Open)))
            {
                i = 0;
                a = br.ReadChars(count[i]);     i++;    char[] Remove = br.ReadChars(2);
                b = br.ReadChars(count[i]);     i++;    Remove = br.ReadChars(2);
                c = br.ReadInt32();             i++;
                d = br.ReadChars(count[i]);     i++;    Remove = br.ReadChars(2);
                f = br.ReadChars(count[i]);     i++;
                j = br.ReadInt32();
            }
            using (BinaryWriter bw = new BinaryWriter(new FileStream(BinaryAdminInformationsString, FileMode.Create)))
            {
                bw.Write(a); bw.Write(b); bw.Write(c); bw.Write(d); bw.Write(f); bw.Write(j);
            }
        }

        public void addemployees(string fn, string ln, int age, string gender, int yearsofworking, int employeeID, int employeepassword, string position,
            double salary, string degree)
        {
            try
            {
                string s = fn + " " + ln + " " + age + " " + gender + " " + yearsofworking + " " + employeeID + " " + employeepassword + " " + salary + " " + position + " " + degree;
                Logger.WriteIntoFile(filepath, s);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void removeemployee(int id)
        {
            try
            {
                string line;
                if (File.Exists(newfilepath)) File.Delete(newfilepath);

                File.Move(filepath, newfilepath);
                string[] informations;
                bool isRemoved = false;
                List<string> list = new List<string>();
                
                using (var r = new StreamReader(newfilepath))
                {
                    using (var w = new StreamWriter(filepath))
                    {
                        while ((line = r.ReadLine()) != null)
                        {
                            informations = line.Split(' ');
                            if (informations.Length > ImportantWords.GetMinimumLength())
                            {
                                if (Convert.ToInt32(informations[5]) != Convert.ToInt32(id))
                                {
                                    w.WriteLine(line);
                                }
                                else
                                {
                                    isRemoved = true;
                                    MessageBox.Show("Employee removed");
                                }
                            }
                        }
                        if (isRemoved == false) MessageBox.Show("The ID " + id + " does not exist");
                    }
                }
                File.Delete(newfilepath);
            }
            catch (DirectoryNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File {0} not found: ", ex.FileName);
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Other file copy exception");
                throw;
            }
        }

        public static Engineers[] GetAllEmployees()
        {
            int counter = 0;
            
            string[] informations;
            Engineers eng = new Engineers();
            Engineers[] engineers = new Engineers[File.ReadAllLines(employeefilepath).Length];
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(employeefilepath).ToList();
            foreach(string line in lines)
            {
                informations = line.Split(' ');
                if (informations.Length > ImportantWords.GetMinimumLength())
                {
                    eng = new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3], Convert.ToInt32(informations[4]), 
                        Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8], Convert.ToDouble(informations[7]), informations[9]);
                    engineers[counter] = eng;
                    counter++;
                }
            }
            return engineers;
        }

        public static List<Engineers> GetListOfAllEmployees()
        {
            string[] informations;
            List<string> lines = new List<string>();
            List<Engineers> l = new List<Engineers>();
            lines = File.ReadAllLines(employeefilepath).ToList();
            foreach (string line in lines)
            {
                informations = line.Split(' ');
                if (informations.Length > ImportantWords.GetMinimumLength())
                {
                    Engineers p = new Engineers(informations[0], informations[1], Convert.ToInt32(informations[2]), informations[3], Convert.ToInt32(informations[4]),
                                Convert.ToInt32(informations[5]), Convert.ToInt32(informations[6]), informations[8], Convert.ToDouble(informations[7]), informations[9]);
                    l.Add(p);
                }
            }
            return l;
        }

        public static void CreateAdminInformation()
        {
            Admin a = new Admin();
            Admin admin = new Admin("abc", "abc", 18, "Man", a.generatesecretcode(), 100000);

            if (File.Exists(admininformationsfilepath) == false)
            {
                using (TextWriter tw = new StreamWriter(admininformationsfilepath))
                {
                    tw.Write(admin.Firstname); tw.WriteLine();
                    tw.Write(admin.Lastname); tw.WriteLine();
                    tw.Write(admin.Age); tw.WriteLine();
                    tw.Write(admin.Gender); tw.WriteLine();
                    tw.Write(admin.Secretcode); tw.WriteLine();
                    tw.Write(admin.Shopbalance); tw.WriteLine();
                }
            }
        }

    }
}