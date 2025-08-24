using Microsoft.Extensions.Configuration;
using NovaKey.ExternalApi.BlockChainApi.Enums;
using NovaKey.ExternalApi.BlockChainApi.Interfaces;

namespace NovaKey.ExternalApi.BlockChainApi
{
    internal abstract class BlockChainApi<AddressData>(IConfiguration configuration,HttpClient httpClient,Coins coin,Networks network)
    {
        protected readonly IConfiguration configuration = configuration;
        protected readonly HttpClient httpClient = httpClient;
        protected readonly Coins coin = coin;
        protected readonly Networks network = network;

        protected abstract IEnumerable<IUnspentTransactionOutput>? FilterUnspentTransactionsOutputs(AddressData addressData);

    }
}
