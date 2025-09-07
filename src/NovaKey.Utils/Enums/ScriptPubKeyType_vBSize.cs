namespace NovaKey.Utils.Enums
{
    public enum ScriptPubKeyType_vBSize
    {
        Legacy = 34,                // P2PKH
        SegwitP2SH = 32,            // P2SH
        Segwit = 31,                // P2WPKH  Segiwt and SegwitMultisig are the same BIP - BIP141 (+BIP143 for signature hash)
        Taproot = 43,               //P2TR
    }
}
