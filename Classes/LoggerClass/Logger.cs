using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ShopProject.Classes.LoggerClass
{
    class Logger
    {
        public static void WriteIntoFile(string logPath, string towrite)
        {
            try
            {
                FileStream oFileStream = new FileStream(logPath, FileMode.Open, FileAccess.Write);
                StreamWriter oStreamWriter = new StreamWriter(oFileStream);
                oFileStream.Seek(0, SeekOrigin.End);
                oStreamWriter.WriteLine(towrite);
                oStreamWriter.Close();
            }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch { MessageBox.Show("Logging Failed"); }
        }

        public static void LogWrite(string logPath, string fn, string ln, int id)
        {
            try
            {
                FileStream oFileStream = new FileStream(logPath, FileMode.Open, FileAccess.Write);
                StreamWriter oStreamWriter = new StreamWriter(oFileStream);
                oFileStream.Seek(0, SeekOrigin.End);
                oStreamWriter.WriteLine(fn + " " + ln + " " + " whose ID is: " + id + " logged in at: " + DateTime.Now);
                oStreamWriter.Close();
            }
            catch (FileNotFoundException ex) { MessageBox.Show(ex.Message); }
            catch (IOException ex) { MessageBox.Show(ex.Message); }
            catch {MessageBox.Show("Logging Failed"); }
        }

        public static string LogRead(string filepath)
        {
            StreamReader ostreamReader = null;
            string filetext;
            try
            {
                ostreamReader = File.OpenText(filepath);
                filetext = ostreamReader.ReadToEnd();
                Thread.Sleep(2000);
                return filetext;
            }
            catch (DirectoryNotFoundException ex) { return ex.Message; }
            catch (FileNotFoundException ex) { return ex.Message; }
            catch (IOException ex) { return ex.Message; }
            catch { return "Logging failed"; }
            finally
            {
                ostreamReader.Close();
                ostreamReader.Dispose();
            }
        }
    }
}