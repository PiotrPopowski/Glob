using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Properties
{
    public class PropertyHandler : IPropertyHandler
    {
        private readonly string propertiesName = "properties";
        private static IProperties _properties;

        public IProperties Load()
        {
            if (_properties == null)
            {
                if (File.Exists(propertiesName) == false)
                    return null;
                using (FileStream fs = File.OpenRead(propertiesName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    _properties = (IProperties)bf.Deserialize(fs);
                }
            }
            return _properties;
        }

        public void Save(IProperties properties)
        {
            using (FileStream fs = File.Create(propertiesName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, properties);
            }
        }
    }
}
