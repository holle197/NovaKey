using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovaKey.ExternalApi.BlockChainApi.Models.BlockCypherModels.UnspentTransactionOutputModels
{
    internal class UnspentTransactionOutput : IUnspentTransactionOutput
    {
        [JsonPropertyName("tx_hash")]
        public string TransactionHash { get; set; } = string.Empty;
        [JsonPropertyName("tx_output_n")]
        //convert to uint later for IUnspentTransactionOutput
        public int TransactionOutputNumber { get; set; }
        [JsonPropertyName("value")]
        public long Amount { get; set; }
        [JsonPropertyName("spent")]
        public bool IsSpent { get; set; }
        [JsonPropertyName("confirmations")]
        public uint Confirmations { get; set; }

        public decimal GetAmount()
        {
            return Amount;
        }

        public string GetTransactionId()
        {
            return TransactionHash;
        }

        public uint GetTransactionOutputNumber()
        {
            try
            {
                return Convert.ToUInt32(TransactionOutputNumber);
            }
            catch (Exception)
            {

                throw new ArgumentException("Transaction Output Number Cannot Be Negative");
            }

        }
    }
}
