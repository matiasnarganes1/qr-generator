using System;
using QRCoder;

namespace QrGenerator.Services
{
    public class QRService
    {
        public byte[] GenerateQrCode(string data, string qrType)
        {
            string qrData = data;

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            return  qrCode.GetGraphic(20);
        }
    }
}
