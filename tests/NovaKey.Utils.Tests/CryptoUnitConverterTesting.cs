namespace NovaKey.Utils.Tests
{
    public class CryptoUnitConverterTesting
    {
        [Fact]
        public void CryptoUnitConverter_Testing_Decimal_Input_To_Satoshi()
        {
            var btcAmount = 0.01m;
            var toSatoshi = CryptoUnitConverter.ToSatoshi(btcAmount);

            var expecterResult = 1000000L;

            Assert.Equal(toSatoshi, expecterResult);
        }

        [Fact]
        public void CryptoUnitConverter_Testng_Long_As_Satoshi_To_Decimal_BTC()
        {
            var satoshi = 1000000L;
            var toBtcDecimal = CryptoUnitConverter.ToBTC(satoshi);

            var expectedResult = 0.01m;

            Assert.Equal(toBtcDecimal, expectedResult);
        }
    }
}
