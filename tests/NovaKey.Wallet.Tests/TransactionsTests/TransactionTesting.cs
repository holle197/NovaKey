using NBitcoin;
using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using NovaKey.Wallet.Models;
using NovaKey.Wallet.Tests.TransactionsTests.InternalCalssesAddaptions;
using NovaKey.Wallet.Tests.TransactionsTests.Mock;
using NovaKey.Wallet.Transactions;

namespace NovaKey.Wallet.Tests.TransactionsTests
{
    public class TransactionTesting 
    {
        private static readonly List<IUnspentTransactionOutput> fakeUtxos = [
                                                                     new MockUTxO("hahs1", 2, 1),
                                                                     new MockUTxO("hahs2", 2, 10000),
                                                                     new MockUTxO("hahs3", 2, 10000),
                                                                   ];
        [Fact]
        public void BestUTxOsPickingTesting_Expected_IEnumerable_Of_UTxOs_With_Length_Of_2()
        {
            var mockBasicRawTransactionModel = new BasicRawTransactionModel(Bitcoin.Instance.Mainnet,new Key(),BitcoinAddress.Create("3KZ526NxCVXbKwwP66RgM3pte6zW4gY1tD", Network.Main),fakeUtxos,BitcoinAddress.Create("35hK24tcLEWcgNA4JxpvbkNkoAcDGqQPsP", Network.Main),0.0001m);
            var utxos = new InternalRawTransaction().MockPickBestUTxOs(mockBasicRawTransactionModel);

            var expectedCountOfUtxos = 2;
            var actuallCount = utxos.Count();

            Assert.Equal(expectedCountOfUtxos,actuallCount);
        }
    }
}
