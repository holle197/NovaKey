using NovaKey.Utils.Enums;
using NovaKey.Wallet.Enums;
using NovaKey.Wallet.ErrorHandling;

namespace NovaKey.Wallet.Helpers
{
    internal static class ScriptPubKeyTypeTo_vBSize
    {
        internal static ScriptPubKeyType_vBSize Get_vBSize(this ScriptPubKeyTypes type)
        {
            return type switch
            {
                ScriptPubKeyTypes.Legacy => ScriptPubKeyType_vBSize.Legacy,
                ScriptPubKeyTypes.SegwitP2SH => ScriptPubKeyType_vBSize.SegwitP2SH,
                ScriptPubKeyTypes.Segwit => ScriptPubKeyType_vBSize.Segwit,
                ScriptPubKeyTypes.Taproot => ScriptPubKeyType_vBSize.Taproot,
                _ => throw new WalletException("Unknow ScriptPubKey Type"),
            };
        }
    }
}
