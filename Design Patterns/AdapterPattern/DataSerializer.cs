using ShopProject.Classes.Paths;
using ShopProject.Classes.People;
using ShopProject.Design_Patterns.AdapterPattern.Target;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShopProject.Design_Patterns.AdapterPattern
{
    public class DataSerializer
    {
        private readonly ISerializerAdapter _serializer;
        internal string xmlfilepath = AllPaths.GetXMLFilePath(), jsonfilepath = AllPaths.GetJSONFilePath();
        public DataSerializer(ISerializerAdapter serializer)
        {
            _serializer = serializer;
        }

        public void CreateJSONFileOfEmployees()
        {
            string s = _serializer.Serialize<Engineers>(Admin.GetAllEmployees()) + "\n";
            File.WriteAllText(jsonfilepath, s);
        }

        public void CreateXMLFileOfEmployees()
        {
            int i = 1;
            using (XmlWriter writer = XmlWriter.Create(xmlfilepath))
            {
                writer.WriteStartElement("Employees");
                foreach (var x in Admin.GetAllEmployees())
                {
                    writer.WriteElementString("Employee" + i, _serializer.Serialize<Engineers>(x));
                    i++;
                }
                writer.WriteEndElement();
                writer.Flush();
            }
        }
    }
}
