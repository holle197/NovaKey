using NBitcoin;
using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("NovaKey.Wallet.Tests")]
namespace NovaKey.Wallet.Models
{
    internal class BasicRawTransactionModel(Network network, Key key, BitcoinAddress address,
                                    IEnumerable<IUnspentTransactionOutput> utxos,
                                     BitcoinAddress destinationAddress, decimal amount)
    {
        public Network Network { get; set; } = network;
        public Key Key { get; set; } = key;
        public BitcoinAddress Address { get; set; } = address;
        public IEnumerable<IUnspentTransactionOutput> UnspentTransactionsOutputs { get; set; } = utxos;
        public BitcoinAddress DestinationAddr { get; set; } = destinationAddress;
        public decimal Amount { get; set; } = amount;
       
        
    }
}
