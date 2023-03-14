using GpgDecryptionApp.Services.Abstractions;
using System;
using System.Diagnostics;
using System.IO;

namespace GpgDecryptionApp.Services
{
    public class GpgDecryptionService : IDecryptionService
    {
        public string DecryptGpg(string encryptedMessage, string passphrase)
        {
            if (string.IsNullOrEmpty(encryptedMessage))
            {
                throw new ArgumentNullException(nameof(encryptedMessage));
            }

            if (string.IsNullOrEmpty(passphrase))
            {
                throw new ArgumentNullException(nameof(passphrase));
            }

            var psi = new ProcessStartInfo();
            psi.FileName = "gpg";
            psi.Arguments = $"--batch --yes --passphrase {passphrase} --decrypt";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;

            var process = new Process();
            process.StartInfo = psi;
            process.Start();

            using StreamWriter stdin = process.StandardInput;
            stdin.WriteLine(encryptedMessage);
            stdin.Close();

            process.WaitForExit();

            string decryptedMessage = process.StandardOutput.ReadToEnd();

            if (string.IsNullOrWhiteSpace(decryptedMessage))
            {
                string errorMessage = process.StandardError.ReadToEnd();
                throw new Exception($"GPG decryption failed: {errorMessage}");
            }

            return decryptedMessage;
        }
    }
}
