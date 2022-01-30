using ShopProject.Design_Patterns.AdapterPattern.Target;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopProject.Design_Patterns.AdapterPattern.Adapter
{
    public class XMLSerializerAdapter: ISerializerAdapter
    {
        public string Serialize<T>(object objToSerialize)
        {
            using(var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objToSerialize);
                return writer.ToString();
            }    
        }
    }
}
