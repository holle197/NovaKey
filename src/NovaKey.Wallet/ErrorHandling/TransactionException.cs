using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Wallet.ErrorHandling
{
    internal class TransactionException(string msg) : Exception(msg)
    {
    }
}
