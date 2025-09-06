using NovaKey.ExternalApi.BlockChainApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovaKey.Wallet.Tests.TransactionsTests.Mock
{
    internal class MockUTxO(string transactionHasa,uint transactionOutputNumber,long amount) : IUnspentTransactionOutput
    {
        public string TransactionHash { get; set; } = transactionHasa;

        public uint TransactionOutputNumber { get; set; } = transactionOutputNumber;
        public long Amount { get; set; } = amount;

        public long GetAmount()
        {
            return this.Amount;
        }

        public string GetTransactionId()
        {
            return this.TransactionHash;
        }

        public uint GetTransactionOutputNumber()
        {
            return this.TransactionOutputNumber;
        }
    }
}
