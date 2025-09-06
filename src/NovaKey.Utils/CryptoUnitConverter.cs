using System.Security.Cryptography;

namespace NovaKey.Utils
{
    public static class CryptoUnitConverter
    {

        private const long satoshiPerBTC = 100000000;
        public static long ToSatoshi(decimal btc)
        {
            if (btc < 0.00000001m) throw new CryptographicException("Amount Must Be Greather Than Or Equal to 0.00000001");
            return (long)(btc * satoshiPerBTC);
        }

        public static decimal ToBTC(long satoshi)
        {
            if(satoshi<=0) throw new CryptographicException("Amount Must Be Greather Than 0");
            return Math.Round(satoshi / (decimal)satoshiPerBTC, 8);
        }
    }

}
