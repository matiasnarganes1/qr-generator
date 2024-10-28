using Microsoft.AspNetCore.Mvc;
using QrGenerator.Services;

namespace QrGenerator.Controllers
{
    [ApiController]
    [Route("qr-api/QrController")]
    public class QrController : ControllerBase
    {
        private readonly QRService _qrService;

        public QrController(QRService qrService)
        {
            _qrService = qrService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateQrCode([FromQuery] string url, string qrType)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL cannot be empty.");

            var qrCodeImage = _qrService.GenerateQrCode(url, qrType);
            return File(qrCodeImage, "image/png");
        }
    }
}
