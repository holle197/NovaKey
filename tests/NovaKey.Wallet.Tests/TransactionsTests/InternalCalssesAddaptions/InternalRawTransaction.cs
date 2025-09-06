using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using NovaKey.Wallet.Models;
using NovaKey.Wallet.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Wallet.Tests.TransactionsTests.InternalCalssesAddaptions
{
    internal class InternalRawTransaction : RawTransaction
    {
        public IEnumerable<IUnspentTransactionOutput> MockPickBestUTxOs(BasicRawTransactionModel model)
        {
            return RawTransaction.PickBestUtxos(model);
        }
    }
}
