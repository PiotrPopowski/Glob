using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Properties
{
    public interface IPropertyHandler
    {
        void Save(IProperties properties);
        IProperties Load();
    }
}
