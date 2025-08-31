using NovaKey.Utils.Enums;
using System.ComponentModel;

namespace NovaKey.Utils
{
    public static class FeeCalculator
    {
        private const long satoshiPerByte = 10L;
        //extra for safety
        private const long extra = 10L;
        //for now usi this as safe refference to add utxo as input as fee
        //later add API call to fetch RAW tx to decide precisely amount of fee per utxo
        private const long utxoMax_vB = 148L;
       
        public static long BtcFee(int numOfInputs, IEnumerable<ScryptPubKeyType_vBSize> outputs)
        {
            return (utxoMax_vB * numOfInputs + Calculate_vB_PerOutput(outputs) + extra) * satoshiPerByte;
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
