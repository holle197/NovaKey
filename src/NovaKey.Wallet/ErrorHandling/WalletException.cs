using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Wallet.ErrorHandling
{
    internal class WalletException(string msg):Exception(msg)
    {
    }
}
