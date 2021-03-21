using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class SignedData
    {
        public string Data { get; protected set; }
        public byte[] Signature { get; protected set; }
        public SignedData(string data, byte[] signature)
        {
            Data = data;
            Signature = signature;
        }
    }
}
