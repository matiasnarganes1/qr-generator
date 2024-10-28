using Microsoft.AspNetCore.Mvc;
using QrGenerator.Services;

namespace QrGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrController : ControllerBase
    {
        private readonly QRService _qrService;

        public QrController(QRService qrService)
        {
            _qrService = qrService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateQrCode([FromQuery] string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL cannot be empty.");

            var qrCodeImage = _qrService.GenerateQrCode(url);
            return File(qrCodeImage, "image/png");
        }
    }
}
