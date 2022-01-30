using ShopProject.Design_Patterns.AdapterPattern.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Text.Json;

namespace ShopProject.Design_Patterns.AdapterPattern.Adapter
{
    public class JsonSerializerAdapter: ISerializerAdapter
    {
        public string Serialize<T>(object objToSerialize)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(objToSerialize, options);
        }
    }
}
