using Microsoft.Extensions.Configuration;
using NovaKey.ExternalApi.BlockChainApi.Enums;

namespace NovaKey.ExternalApi.BlockChainApi
{
    internal class BlockChainApiService(IConfiguration configuration)
    {
        private readonly IConfiguration _config = configuration;



        public string GetUnspentTransactionsOutputsUrl(ApiProviders provider, Coins coin, Networks network, string address)
        {
            if (provider == ApiProviders.BlockCypher)
            {
                return GetBlockCypherUnspentTransactionsOutputsUrl(network, coin, address);
            }
            throw new ArgumentException($"No configururation for provider: {provider} while trying to get utxos url");
        }

        public string GetBroadcastUrl(ApiProviders provider, Coins coin, Networks network)
        {
            if (provider == ApiProviders.BlockCypher)
            {
                return GetBlockCypherBroadcastUrl(coin, network);
            }

            throw new ArgumentException($"No configuration for provider: {provider} while trying to get broadcast url");
        }


        private string GetBlockCypherApiKey()
        {
            return _config[$"BlockChainApiProviders:{ApiProviders.BlockCypher}:ApiKey"] ?? throw new Exception("No ApiKey configured for BlockCypher");

        }

        private string GetBlockCypherUnspentTransactionsOutputsUrl(Networks network, Coins coin, string address)
        {
            //BlockCypher provide only btc testnet
            if ((coin == Coins.LTC || coin == Coins.DOGE) && network != Networks.Main) throw new ArgumentException($"BlockCypher does not support {coin} on {network} network.");
            string? template = _config[$"BlockChainApiProviders:{ApiProviders.BlockCypher}:{coin}:{network}:UnspentTransactionsOutputs"];
            if (string.IsNullOrEmpty(template))
                throw new ArgumentException($"No Address URL configured for {ApiProviders.BlockCypher} {coin} {network}");
            return $"{template.Replace("{address}", address)}?token={GetBlockCypherToken(ApiProviders.BlockCypher)}";
        }

        private string GetBlockCypherBroadcastUrl(Coins coin, Networks network)
        {

            //BlockCypher provides only btc for testnet
            if ((coin == Coins.LTC || coin == Coins.DOGE) && network != Networks.Main)
                throw new ArgumentException($"BlockCypher does not support {coin} on {network} network.");

            return _config[$"BlockChainApiProviders:{ApiProviders.BlockCypher}:{coin}:{network}:BroadcastTransaction"] + GetBlockCypherToken(ApiProviders.BlockCypher) ?? throw new ArgumentException($"No Broadcast URL configured for {ApiProviders.BlockCypher} {coin} {network}");

        }

        private string GetBlockCypherToken(ApiProviders provider)
        {
            if (provider == ApiProviders.BlockCypher) return GetBlockCypherApiKey();

            throw new ArgumentException($"No token configured for provider: {provider}");
        }


    }
}
