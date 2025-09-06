using NBitcoin;
using NBitcoin.Altcoins;
using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using NovaKey.Utils;
using NovaKey.Utils.Enums;
using NovaKey.Wallet.Enums;
using NovaKey.Wallet.ErrorHandling;
using NovaKey.Wallet.Helpers;
using NovaKey.Wallet.Models;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("NovaKey.Wallet.Tests")]

namespace NovaKey.Wallet.Transactions
{

    internal abstract class RawTransaction
    {
        /// <summary>
        /// while creating transaction -utxos will be picked up by min to max order by value (how much coins they have)
        /// so first utxos with smallest amount will be spent to clean number of small utxos
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="TransactionException"></exception>
        protected static List<IUnspentTransactionOutput> PickBestUtxos(BasicRawTransactionModel model)
        {
            if (!model.UnspentTransactionsOutputs.Any()) throw new TransactionException("Can't Create Raw Transaction.There Are No UTxOs");

            var satoshiPerByte = GetSatoshiPerByteFromNetwork(model.Network);
            var amount = CryptoUnitConverter.ToSatoshi(model.Amount);

            //sort by value in utxo min - max
            var sortedUtxos = model.UnspentTransactionsOutputs.OrderBy(x => x.GetAmount());


            long totalUtxosBalanceOfPickedBestUtxos = 0L;
            long fee = 0L;
            //best utxos
            var bestUTxOs = new List<IUnspentTransactionOutput>();

            foreach (var utxo in sortedUtxos)
            {
                if (totalUtxosBalanceOfPickedBestUtxos >= amount + fee) break;

                //if current utxo is dust,just ingore them and contionue to the next one
                if (FeeCalculator.IsDust(utxo.GetAmount(), satoshiPerByte)) continue;

                bestUTxOs.Add(utxo);
                totalUtxosBalanceOfPickedBestUtxos += utxo.GetAmount();
                fee = FeeCalculator.Calculate(bestUTxOs.Count, [model.DestinationAddr.GetScriptPubKeyType().Get_vBSize()],
                                              satoshiPerByte);

            }

            return totalUtxosBalanceOfPickedBestUtxos >= (amount + fee) ? bestUTxOs : throw new TransactionException("Insufficent Funds.");
        }

        private static SatoshiPerByte GetSatoshiPerByteFromNetwork(Network network)
        {
            if (network == Bitcoin.Instance.Mainnet || network == Bitcoin.Instance.Testnet) return SatoshiPerByte.BTC;
            if (network == Litecoin.Instance.Mainnet || network == Litecoin.Instance.Testnet) return SatoshiPerByte.LTC;
            if (network == Dogecoin.Instance.Mainnet || network == Dogecoin.Instance.Testnet) return SatoshiPerByte.DOGE;

            throw new NetworkException("Network Not Supported");
        }

        private static List<ScryptPubKeyType> GetScryptPubKeyTypes(IEnumerable<BitcoinAddress> addresses)
        {
            var types = new List<ScryptPubKeyType>();
            foreach (var address in addresses)
            {
                types.Add(address.GetScriptPubKeyType());
            }
            return types;
        }

        private static List<ScryptPubKeyType_vBSize> ConvertScryptPubKeyTypeTo_vBSize(List<ScryptPubKeyType> types)
        {
            var vBSizes = new List<ScryptPubKeyType_vBSize>();
            foreach (var scryptType in types)
            {
                vBSizes.Add(scryptType.Get_vBSize());
            }
            return vBSizes;
        }


    }
}
