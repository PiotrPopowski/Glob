using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.UI.Infrastructure
{
    public interface IFormManager
    {
        BaseForm ActiveForm { get; }
    }
}
