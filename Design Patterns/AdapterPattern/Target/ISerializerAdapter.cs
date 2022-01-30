using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Design_Patterns.AdapterPattern.Target
{
    public interface ISerializerAdapter
    {
        string Serialize<T>(object objectToSerialize);
    }
}
