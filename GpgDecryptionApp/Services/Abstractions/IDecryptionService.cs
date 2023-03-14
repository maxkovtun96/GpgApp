namespace GpgDecryptionApp.Services.Abstractions
{
    public interface IDecryptionService
    {
        string DecryptGpg(string encryptedMessage, string passphrase);
    }
}
