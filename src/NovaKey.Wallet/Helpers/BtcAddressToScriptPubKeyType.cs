using NBitcoin;
using NovaKey.Wallet.Enums;
using NovaKey.Wallet.ErrorHandling;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("NovaKey.Wallet.Tests")]
namespace NovaKey.Wallet.Helpers
{
    internal static class BtcAddressToScriptPubKeyType
    {
        internal static ScriptPubKeyTypes GetScriptPubKeyType(this BitcoinAddress address)
        {
            var script = address.ScriptPubKey;

            if (PayToPubkeyHashTemplate.Instance.CheckScriptPubKey(script))
                return ScriptPubKeyTypes.Legacy;

            if (PayToScriptHashTemplate.Instance.CheckScriptPubKey(script))
                return ScriptPubKeyTypes.SegwitP2SH;

            if (PayToWitPubKeyHashTemplate.Instance.CheckScriptPubKey(script))
                return ScriptPubKeyTypes.Segwit;

            if (PayToTaprootTemplate.Instance.CheckScriptPubKey(script))
                return ScriptPubKeyTypes.Taproot;

            throw new WalletException("Unknown ScriptPubKey type");
        }
    }
}
