using NBitcoin;
using NovaKey.Wallet.Enums;
using NovaKey.Wallet.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Wallet.Tests.AddressTypesTests
{
    public class AddressTypeTest
    {
        private readonly Key key = new();
    
        private readonly Network network = Network.Main;

        private readonly BitcoinAddress legacy;
        private readonly BitcoinAddress segwitP2SH;
        private readonly BitcoinAddress segwit;
        private readonly BitcoinAddress taproot;


        public AddressTypeTest()
        {
            this.legacy = key.GetAddress(ScriptPubKeyType.Legacy, network);
            this.segwitP2SH = key.GetAddress(ScriptPubKeyType.SegwitP2SH, network);
            this.segwit = key.GetAddress(ScriptPubKeyType.Segwit, network);
            this.taproot = key.GetAddress(ScriptPubKeyType.TaprootBIP86, network);
           
        }
      
        [Fact]
        public void AddressTypeTest_Expected_Legacy_Type()
        {
            var expectedScriptType = ScriptPubKeyTypes.Legacy;

            var actualType = this.legacy.GetScriptPubKeyType();

            Assert.Equal(expectedScriptType, actualType);
        }

        [Fact]
        public void AddressTypeTest_Expected_SegwitP2SH_Type()
        {
            var expectedScriptType = ScriptPubKeyTypes.SegwitP2SH;

            var actualType = this.segwitP2SH.GetScriptPubKeyType();

            Assert.Equal(expectedScriptType, actualType);
        }

        [Fact]
        public void AddressTypeTest_Expected_Segwit()
        {
            var expectedScriptType = ScriptPubKeyTypes.Segwit;

            var actualType = this.segwit.GetScriptPubKeyType();

            Assert.Equal(expectedScriptType, actualType);
        }
       
        [Fact]
        public void AddressTypeTest_Expected_Taproot()
        {
            var expectedScriptType = ScriptPubKeyTypes.Taproot;

            var actualType = this.taproot.GetScriptPubKeyType();

            Assert.Equal(expectedScriptType, actualType);
        }
    }
}
