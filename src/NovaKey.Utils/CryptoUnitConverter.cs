namespace NovaKey.Utils
{
    public static class CryptoUnitConverter
    {

        private const long satoshiPerBTC = 100000000;
        public static long ToSatoshi(decimal btc)
        {
            return (long)(btc * satoshiPerBTC);
        }

        public static decimal ToBTC(long satoshi)
        {
            return Math.Round(satoshi / (decimal)satoshiPerBTC, 8);
        }
    }

}
