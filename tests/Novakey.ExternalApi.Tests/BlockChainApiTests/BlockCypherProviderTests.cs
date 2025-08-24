using NovaKey.ExternalApi.BlockChainApi.Providers.BlockCypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novakey.ExternalApi.Tests.BlockChainApiTests
{
    public class BlockCypherProviderTests
    {
        [Fact]
        public async Task  BlockCypher_Test_UTxOs_Fetcher_Expected_Some_Utxos()
        {

            var provider = new BlockCypherProvider(ConfigLoader.LoadFromSolutionRoot(),new HttpClient(),NovaKey.ExternalApi.BlockChainApi.Enums.Coins.BTC,NovaKey.ExternalApi.BlockChainApi.Enums.Networks.Main);
            var addr = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa";
            var res = await provider.FetchUnspentTransactionsOutputsAsync(addr);
            Assert.True(res?.Count()>0);
        }
    }
}
