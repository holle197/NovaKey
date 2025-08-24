using Novakey.ExternalApi.Tests.BlockChainApiTests.Mocking;
using NovaKey.ExternalApi.BlockChainApi.Providers.BlockCypher;

namespace Novakey.ExternalApi.Tests.BlockChainApiTests
{
    public class BlockCypherProviderTests
    {

        internal BlockCypherProvider Provider = FakeBlockChainProviders.GetFakeBlockCypherProvider();
        internal string Address = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa";

        //running this test cost api call
        //its runs real api call
        //befor running this test change addr inside test body and check on blockchain to be sure
        //there are actually some utxos (some balance)
        //utxo must have at least 3 confirmations for pass this test 
        /*[Fact]
        public async Task BlockCypher_Test_UTxOs_Fetcher_Expected_Some_Utxos()
        {

            var provider = new BlockCypherProvider(ConfigLoader.LoadFromSolutionRoot(), new HttpClient(), NovaKey.ExternalApi.BlockChainApi.Enums.Coins.BTC, NovaKey.ExternalApi.BlockChainApi.Enums.Networks.Main);
            var addr = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa";
            var res = await provider.FetchUnspentTransactionsOutputsAsync(addr);
            Assert.True(res?.Count() > 0);
        }*/

        [Fact]
        public async Task BlockCypher_Test_Get_Utxos_Expected_Not_Null_With_Lenght_Of_2()
        {
            var utxos = await Provider.FetchUnspentTransactionsOutputsAsync(Address);
            Assert.Equal(utxos?.Count(), 2);
        }

        [Fact]
        public async Task BlockCypher_Test_UTxOs_Must_Have_TxId_Expected_True()
        {
            var utxos = await Provider.FetchUnspentTransactionsOutputsAsync(Address);
            var utxosAsList = utxos?.ToList();

            var expectedTransactionsIds = new string[2] { "9382899c2f19d2977aa06c27a9cd2e9510ea121536c9a8610b0edfa5899ac8ec", "59eb46849452f8af1a471c6accdf29c0f2f36160e2376f8e5813f6ddcd6740d5" };

            Assert.Equal(utxosAsList?[0].GetTransactionId(), expectedTransactionsIds[0]);
            Assert.Equal(utxosAsList?[1].GetTransactionId(), expectedTransactionsIds[1]);

        }

        [Fact]
        public async Task BlockCypher_Test_UTxOs_Must_Have_Amout_Great_Than_Zero_Expected_True()
        {
            var utxos = await Provider.FetchUnspentTransactionsOutputsAsync(Address);
            var utxosAsList = utxos?.ToList();

            Assert.True(utxosAsList?[0].GetAmount() > 0);
            Assert.True(utxosAsList?[1].GetAmount() > 0);

        }

        [Fact]
        public async Task BlockCypher_Test_UTxOs_Must_Have_Transaction_Output_Number_Not_Negative_Expected_True()
        {
            var utxos = await Provider.FetchUnspentTransactionsOutputsAsync(Address);
            var utxosAsList = utxos?.ToList();

            Assert.True(utxosAsList?[0].GetTransactionOutputNumber() > -1);
            Assert.True(utxosAsList?[1].GetTransactionOutputNumber() > -1);

        }




    }
}
