
namespace NovaKey.Utils.Tests
{
    public class SHA256Testing
    {
        [Fact]
        public void Test_Sha256_Input_123_Expected_Output_a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3()
        {
            var test = "123";
            var hashAsBytes = SHA256Helper.GenerateHash(test);
            var hashAsHexaString = Convert.ToHexString(hashAsBytes).ToLower();

            //https://sha256hash.org/ used to get actually value of "123"
            var actualHashAsHexaString = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3";

            Assert.Equal(hashAsHexaString , actualHashAsHexaString);
        }
    }
}
