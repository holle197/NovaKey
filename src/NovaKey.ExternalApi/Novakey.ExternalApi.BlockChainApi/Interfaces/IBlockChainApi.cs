using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.ExternalApi.BlockChainApi.Interfaces
{
    internal interface IBlockChainApi
    {
        /// <summary>
        /// Get all unspnt transactions outputs of given address 
        /// </summary>
        /// <param name="address">given address</param>
        /// <returns>utxos or null</returns>
        Task<IEnumerable<IUnspentTransactionOutput>?> FetchUnspentTransactionsOutputsAsync(string address);
        /// <summary>
        /// broadcasting transaction to the network
        /// </summary>
        /// <param name="rawTransaction">signed transaction</param>
        /// <returns>txid</returns>
        Task<string> BroadcastTransactionAsync(string rawTransaction);
    }
}
