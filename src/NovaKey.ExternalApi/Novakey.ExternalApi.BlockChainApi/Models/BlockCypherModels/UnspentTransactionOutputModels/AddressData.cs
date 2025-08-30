using System.Text.Json.Serialization;

namespace NovaKey.ExternalApi.BlockChainApi.Models.BlockCypherModels.UnspentTransactionOutputModels
{
    internal class AddressData
    {
        [JsonPropertyName("txrefs")]
        public List<UnspentTransactionOutput> UnspentTransactionsOutputsRefferences { get; set; } = [];
    }
}
