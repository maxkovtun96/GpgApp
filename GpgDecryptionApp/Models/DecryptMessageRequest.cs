using System.ComponentModel.DataAnnotations;

namespace GpgDecryptionApp.Models
{
    public class DecryptMessageRequest
    {
        [Required]
        public string Passphrase { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
