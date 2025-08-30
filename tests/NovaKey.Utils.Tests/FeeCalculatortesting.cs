using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Utils.Tests
{
    public class FeeCalculatortesting
    {
        [Fact]
        public void BtcFeeCalculatorTesting_With_2_Inputs_And_2_Outputs_Expecter_Result_2580()
        {
            var btcFee = FeeCalculator.BtcFee(1, 2);

            var expectedFee = 2580L;
            Assert.Equal(btcFee, expectedFee);
        }
    }
}
