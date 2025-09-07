using NovaKey.Utils.Enums;

namespace NovaKey.Utils.Tests
{
    public class FeeCalculatorTesting
    {
        [Fact]
        public void BtcFeeCalculatorTesting_With_2_Inputs_And_2_Outputs_One_Segwit_Another_Legacy_Expecter_Result_2230()
        {
            var toAddresses = new List<ScriptPubKeyType_vBSize>() { ScriptPubKeyType_vBSize.Legacy,ScriptPubKeyType_vBSize.Segwit};
            var btcFee = FeeCalculator.Calculate(1,toAddresses,SatoshiPerByte.BTC);
            //1 utxo = 148vB segwit 31vB legacy 34vB extra 10 = 223vB * 10 satoshi = 2230
            var expectedFee = 2230;
            Assert.Equal(btcFee, expectedFee);
        }
    }
}
