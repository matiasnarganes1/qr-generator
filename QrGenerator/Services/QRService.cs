using System;
using QRCoder;  // Necesitarás agregar el paquete QR Code Generator (QRCoder)

namespace QrGenerator.Services
{
    public class QRService
    {
        public byte[] GenerateQrCode(string url)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            return  qrCode.GetGraphic(20);  // Genera el QR como un gráfico
        }
    }
}
