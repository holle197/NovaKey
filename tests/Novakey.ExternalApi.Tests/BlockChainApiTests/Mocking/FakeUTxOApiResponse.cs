using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novakey.ExternalApi.Tests.BlockChainApiTests.Mocking
{
    internal class FakeUTxOApiResponse
    {
        internal static string GetBlockCypherFakeUTxOsApiResponse()
        {
           return   @"
{
  ""address"": ""1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa"",
  ""total_received"": 10430923478,
  ""total_sent"": 0,
  ""balance"": 10430923478,
  ""unconfirmed_balance"": 0,
  ""final_balance"": 10430923478,
  ""n_tx"": 50734,
  ""unconfirmed_n_tx"": 0,
  ""final_n_tx"": 50734,
  ""txrefs"": [
    {
      ""tx_hash"": ""9382899c2f19d2977aa06c27a9cd2e9510ea121536c9a8610b0edfa5899ac8ec"",
      ""block_height"": 911478,
      ""tx_input_n"": -1,
      ""tx_output_n"": 1,
      ""value"": 546,
      ""ref_balance"": 10430923478,
      ""spent"": false,
      ""confirmations"": 11,
      ""confirmed"": ""2025-08-24T11:41:42Z"",
      ""double_spend"": false
    },
    {
      ""tx_hash"": ""59eb46849452f8af1a471c6accdf29c0f2f36160e2376f8e5813f6ddcd6740d5"",
      ""block_height"": 911330,
      ""tx_input_n"": -1,
      ""tx_output_n"": 0,
      ""value"": 546,
      ""ref_balance"": 10430922932,
      ""spent"": false,
      ""confirmations"": 159,
      ""confirmed"": ""2025-08-23T13:35:30Z"",
      ""double_spend"": false
    }
  ]
}";
        }
    }
}
