using NBitcoin;
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
    internal static class BtcAddressToScryptPubKeyType
    {
        internal static ScryptPubKeyType GetScriptPubKeyType(this BitcoinAddress address)
        {
            var script = address.ScriptPubKey;

            if (PayToPubkeyHashTemplate.Instance.CheckScriptPubKey(script))
                return ScryptPubKeyType.Legacy;

            if (PayToScriptHashTemplate.Instance.CheckScriptPubKey(script))
                return ScryptPubKeyType.SegwitP2SH;

            if (PayToWitPubKeyHashTemplate.Instance.CheckScriptPubKey(script))
                return ScryptPubKeyType.Segwit;

            if (PayToWitScriptHashTemplate.Instance.CheckScriptPubKey(script))
                return ScryptPubKeyType.SegwitMultisig;

            if (PayToTaprootTemplate.Instance.CheckScriptPubKey(script))
                return ScryptPubKeyType.Taproot;

            throw new WalletException("Unknown ScriptPubKey type");
        }
    }
}
