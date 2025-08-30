namespace NovaKey.Utils
{
    public static class FeeCalculator
    {
        /// <summary>
        /// 180 (input) +  34 (output) + 10 (extra) = 224 bytes
        /// each input must have at least 180 bytes and each output 34 bytes
        /// and add extra 10 bytes for safety
        /// multiple this result by 10 satoshi per byte (1 satoshi = 0.00000001 BTC)
        /// </summary>
        /// <param name="numOfInputs"></param>
        /// <param name="numOfOutputs"></param>
        /// <returns></returns>
        public static long BtcFee(int numOfInputs, int numOfOutputs)
        {
            int extra = 10;
            int satoshiPerByte = 10;
            return (numOfInputs * 180 + numOfOutputs * 34 + extra) * satoshiPerByte;
        }
    }
}
