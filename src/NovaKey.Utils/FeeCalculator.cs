using NovaKey.Utils.Enums;
using System.ComponentModel;

namespace NovaKey.Utils
{
    public static class FeeCalculator
    {
        //extra for safety
        private const long extra = 10L;
        //for now usi this as safe refference to add utxo as input as fee
        //later add API call to fetch RAW tx to decide precisely amount of fee per utxo
        private const long utxoMax_vB = 148L;
       
        public static long Calculate(int numOfInputs, IEnumerable<ScryptPubKeyType_vBSize> outputs,SatoshiPerByte satoshiPerByte)
        {
            return (utxoMax_vB * numOfInputs + Calculate_vB_PerOutput(outputs) + extra) * (long)satoshiPerByte;
        }

        public static bool IsDust(long utxobalanceInsatoshi,SatoshiPerByte satoshiPerByte)
        {
            return utxobalanceInsatoshi <= 3 * utxoMax_vB * (long)satoshiPerByte;
        }

        //calculating vB per output (for every address that we sending funds)
        private static long Calculate_vB_PerOutput(IEnumerable<ScryptPubKeyType_vBSize> destinationAddresses)
        {
            long total = 0L;
            foreach (var destinationAddresstype in destinationAddresses)
            {
                total += (long)destinationAddresstype;
            }
            return total;
        }

       


    }
}
