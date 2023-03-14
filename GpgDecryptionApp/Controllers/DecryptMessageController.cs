using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GpgDecryptionApp.Models;
using GpgDecryptionApp.Services.Abstractions;

namespace GpgDecryptionApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecryptMessageController : ControllerBase
    {
        private readonly ILogger<DecryptMessageController> _logger;
        private readonly IDecryptionService _decryptionService;

        public DecryptMessageController(ILogger<DecryptMessageController> logger, IDecryptionService decryptionService)
        {
            _logger = logger;
            _decryptionService = decryptionService;
        }

        [HttpPost]
        public ActionResult Post(DecryptMessageRequest request)
        {
            var decypted = _decryptionService.DecryptGpg(request.Message, request.Passphrase);

            return Ok(new DecryptMessageResponse
            {
                DecryptedMessage = decypted
            });
        }
    }
}
