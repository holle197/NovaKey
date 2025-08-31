using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using NovaKey.Wallet.ErrorHandling;
using NovaKey.Wallet.Models;

namespace NovaKey.Wallet.Transactions
{
    internal class RawTransaction
    {
        /// <summary>
        /// while creating transaction -utxos will be picked up by min to max order by value (how much coins they have)
        /// so first utxos with smallest amount will be spent to clean number of small utxos
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="amount"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        /// <exception cref="TransactionException"></exception>
        protected static List<IUnspentTransactionOutput> PickBestUtxos(BasicRawTransactionModel model, decimal amount, decimal fee)
        {
            if (model.UnspentTransactionsOutputs.Count() == 0) throw new TransactionException("Can't Create Raw Transaction.There Are No UTxOs");

            //sort by value in utxo min - max
            model.UnspentTransactionsOutputs.OrderBy(x => x.GetAmount());

            //total to be sent ( amount + fee for miners )
            var total = amount+fee;
            var current = 0m;
            //best utxos
            var bestUTxOts = new List<IUnspentTransactionOutput>();

            foreach (var utxo in model.UnspentTransactionsOutputs)
            {
                if (current>=total) break;

                current += utxo.GetAmount();
                bestUTxOts.Add(utxo);
            }
            return current >= total ? bestUTxOts : throw new TransactionException("Insufficent funds.");
        }
    }
}
