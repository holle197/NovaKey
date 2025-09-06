namespace NovaKey.Utils.Enums
{
    public enum ScryptPubKeyType_vBSize
    {
        Legacy = 34,                // P2PKH
        SegwitP2SH = 32,            // P2SH
        Segwit = 31,                // P2WPKH  Segiwt and SegwitMultisig are the same BIP - BIP141 (+BIP143 for signature hash)
        SegwitMultisig = 43,        // P2WSH 
        Taproot = SegwitMultisig,   // P2TR taproot have the same vBite as SegwithMultisig
    }
}
