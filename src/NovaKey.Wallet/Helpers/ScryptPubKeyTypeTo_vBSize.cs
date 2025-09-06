using NovaKey.Utils.Enums;
using NovaKey.Wallet.Enums;
using NovaKey.Wallet.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Wallet.Helpers
{
    internal static class ScryptPubKeyTypeTo_vBSize
    {
        internal static ScryptPubKeyType_vBSize Get_vBSize(this ScryptPubKeyType type)
        {
            return type switch
            {
                ScryptPubKeyType.Legacy => ScryptPubKeyType_vBSize.Legacy,
                ScryptPubKeyType.SegwitP2SH => ScryptPubKeyType_vBSize.SegwitP2SH,
                ScryptPubKeyType.Segwit => ScryptPubKeyType_vBSize.Segwit,
                ScryptPubKeyType.SegwitMultisig => ScryptPubKeyType_vBSize.SegwitMultisig,
                ScryptPubKeyType.Taproot => ScryptPubKeyType_vBSize.Taproot,
                _ => throw new WalletException("Unknow ScriptPubKey Type"),
            };
        }
    }
}
