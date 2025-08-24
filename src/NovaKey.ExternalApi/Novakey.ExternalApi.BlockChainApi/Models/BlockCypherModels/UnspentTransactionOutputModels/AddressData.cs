using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovaKey.ExternalApi.BlockChainApi.Models.BlockCypherModels.UnspentTransactionOutputModels
{
    internal class AddressData
    {
        [JsonPropertyName("txrefs")]
        public List<UnspentTransactionOutput> UnspentTransactionsOutputsRefferences { get; set; } = [];
    }
}
