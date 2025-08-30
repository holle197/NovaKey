using NovaKey.ExternalApi.BlockChainApi.Providers.BlockCypher;
using RichardSzalay.MockHttp;

namespace Novakey.ExternalApi.Tests.BlockChainApiTests.Mocking
{
    internal static class FakeBlockChainProviders
    {
        internal static BlockCypherProvider GetFakeBlockCypherProvider()
        {

            var mockHttp = new MockHttpMessageHandler();
            var address = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa";


            var expectedUrl = $"https://api.blockcypher.com/v1/btc/main/addrs/{address}?token=28debc61c85843a6baf702c79f3f959a";

            mockHttp.When(expectedUrl)
                    .Respond("application/json", FakeUTxOApiResponse.GetBlockCypherFakeUTxOsApiResponse());

            var httpClient = new HttpClient(mockHttp);

            var config = ConfigLoader.LoadFromSolutionRoot();
            var provider = new BlockCypherProvider(config, httpClient, NovaKey.ExternalApi.BlockChainApi.Enums.Coins.BTC, NovaKey.ExternalApi.BlockChainApi.Enums.Networks.Main);

            return provider;
        }
    }
}
