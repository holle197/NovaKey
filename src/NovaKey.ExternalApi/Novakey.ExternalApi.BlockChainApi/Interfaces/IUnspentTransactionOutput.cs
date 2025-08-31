namespace NovaKey.ExternalApi.BlockChainApi.Interfaces
{
    public interface IUnspentTransactionOutput
    {
        //UTxO is OUTPUT of transaction
        //when we creating new transaction and want to spend this UTxO
        //this UTxO becoum INPUT in this new transaction

        //transaction hash
        string GetTransactionId();
        //represent previouse utxo that indexed address how much coins he sending to this address
        //btc tx can have multiple inputs and outputs
        //so in outputs we need to finde our address to know how much btc previouse tx sending to this address
        uint GetTransactionOutputNumber();
        //represent amount in SATOSHI 1 satosi = 0.00000001 or 1 BTC = 100_000_000 satoshi
        long GetAmount();
    }
}
