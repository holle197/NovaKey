using Microsoft.Extensions.Configuration;
using NovaKey.ExternalApi.BlockChainApi.Enums;
using NovaKey.ExternalApi.BlockChainApi.Exceptions;
using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using NovaKey.ExternalApi.BlockChainApi.Models.BlockCypherModels.UnspentTransactionOutputModels;
using System.Text;
using System.Text.Json;

namespace NovaKey.ExternalApi.BlockChainApi.Providers.BlockCypher
{
    internal class BlockCypherProvider : BlockChainApi<AddressData>, IBlockChainApi
    {
        private readonly BlockChainApiService _configuration;

        public BlockCypherProvider(IConfiguration configuration, HttpClient httpClient, Coins coin, Networks networks) : base(configuration, httpClient, coin, networks)
        {
            this._configuration = new BlockChainApiService(base.configuration);
        }

        public async Task<IEnumerable<IUnspentTransactionOutput>?> FetchUnspentTransactionsOutputsAsync(string address)
        {
            var url = _configuration.GetUnspentTransactionsOutputsUrl(ApiProviders.BlockCypher, base.coin, base.network, address);
            var response = await base.httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new BlockChainApiProviderException($"Failed to fetch address data: {response.StatusCode}");

            var responseAsString = await response.Content.ReadAsStringAsync();
            var data = System.Text.Json.JsonSerializer.Deserialize<AddressData>(responseAsString);

            return FilterUnspentTransactionsOutputs(data);
        }



        public async Task<string> BroadcastTransactionAsync(string rawTransaction)
        {
            var url = _configuration.GetBroadcastUrl(ApiProviders.BlockCypher, base.coin, base.network);

            var content = new StringContent(
                JsonSerializer.Serialize(new { tx = rawTransaction }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await base.httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new BlockChainApiProviderException($"Failed to broadcast transaction: {response.StatusCode}");

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// check all utxos if exists and filter only confirmed utxos by network
        /// 3 confirmations are minimum standard for safety
        /// </summary>
        /// <param name="addressData"></param>
        /// <returns></returns>
        protected override IEnumerable<IUnspentTransactionOutput>? FilterUnspentTransactionsOutputs(AddressData? addressData)
        {
            //there are no any utxo for given address
            if (addressData?.UnspentTransactionsOutputsRefferences == null || addressData.UnspentTransactionsOutputsRefferences.Count == 0) return null;

            var res = new List<IUnspentTransactionOutput>();

            foreach (var utxo in addressData.UnspentTransactionsOutputsRefferences)
            {
                if (!utxo.IsSpent && utxo.Confirmations > 2)
                {
                    res.Add(utxo);
                }
            }
            return res.Count>0 ? res:null;
        }

    }
}
