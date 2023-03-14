using GpgDecryptionApp.Services;
using System;
using Xunit;

namespace GpgDecryptionApp.Tests
{
    public class GpgDecryptionServiceTests 
    {
        private readonly GpgDecryptionService _service;

        public GpgDecryptionServiceTests()
        {
            _service = new GpgDecryptionService();
        }

        [Fact]
        public void DecryptGpg_WithValidArguments_ReturnsDecryptedMessage()
        {
            // arrange
            var encryptedMessage = "-----BEGIN PGP MESSAGE-----\nVersion: GnuPG v2\njA0ECQMCVady3RUyJw3X0kcBF+zdkfZO" +
                                   "MhISoYBRwR3uk3vNv+TEg+rJnp4/yYISpEoI2S82cDiCNBIVAYWB8WKPtH2R2YSussKhpSJ4mFgqyOA01uw" +
                                   "roA==\n=KvJQ\n-----END PGP MESSAGE-----";
            var passphrase = "topsecret";

            // act
            var decryptedMessage = _service.DecryptGpg(encryptedMessage, passphrase);

            // assert
            Assert.Equal("Nice work!", decryptedMessage.Trim());
        }

        [Fact]
        public void DecryptGpg_WithEmptyEncryptedMessage_ThrowsArgumentNullException()
        {
            // arrange
            var encryptedMessage = "";
            var passphrase = "test";

            // act and assert
            Assert.Throws<ArgumentNullException>(() => _service.DecryptGpg(encryptedMessage, passphrase));
        }

        [Fact]
        public void DecryptGpg_WithEmptyPassphrase_ThrowsArgumentNullException()
        {
            // arrange
            var encryptedMessage = "U2FsdGVkX19KjrqPsO8V44uLX9zILJwwuCM31j8f7aQ=";
            var passphrase = "";

            // act and assert
            Assert.Throws<ArgumentNullException>(() => _service.DecryptGpg(encryptedMessage, passphrase));
        }

        [Fact]
        public void DecryptGpg_WithInvalidPassphrase_ThrowsException()
        {
            // arrange
            var encryptedMessage = "U2FsdGVkX19KjrqPsO8V44uLX9zILJwwuCM31j8f7aQ=";
            var passphrase = "wrongpassphrase";

            // act and assert
            Assert.Throws<Exception>(() => _service.DecryptGpg(encryptedMessage, passphrase));
        }

        [Fact]
        public void DecryptGpg_WithInvalidEncryptedMessage_ThrowsException()
        {
            // arrange
            var encryptedMessage = "invalid";
            var passphrase = "test";

            // act and assert
            Assert.Throws<Exception>(() => _service.DecryptGpg(encryptedMessage, passphrase));
        }
    }
}
