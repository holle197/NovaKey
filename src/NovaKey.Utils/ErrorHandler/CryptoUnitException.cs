using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Utils.ErrorHandler
{
    internal class CryptoUnitException(string msg) : Exception(msg)
    {
    }
}
