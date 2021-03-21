using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Core.Domain
{
    public class SignedData
    {
        public string Data { get; set; }
        public byte[] Signature { get; set; }
        public SignedData(string data, byte[] signature)
        {
            Data = data;
            Signature = signature;
        }
    }
}
