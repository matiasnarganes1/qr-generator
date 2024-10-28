using System;
using QRCoder;

namespace QrGenerator.Services
{
    public class QRService
    {
        public byte[] GenerateQrCode(string data, string qrType)
        {
            string qrData = data;

            switch (qrType)
            {
                case "link":
                    qrData = data;
                    break;
                case "email":
                    qrData = $"mailto:{data}";
                    break;
                case "text":
                    qrData = data;
                    break;
                case "call":
                    qrData = $"tel:{data}";
                    break;
                case "sms":
                    qrData = $"sms:{data}";
                    break;
                case "vcard":
                    qrData = $"BEGIN:VCARD\nFN:{data}\nEND:VCARD";
                    break;
                case "whatsapp":
                    qrData = $"https://wa.me/{data}";
                    break;
                case "wifi":
                    qrData = $"WIFI:T:WPA;S:{data};";
                    break;
                case "paypal":
                    qrData = $"https://www.paypal.me/{data}";
                    break;
            }

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            return  qrCode.GetGraphic(20);
        }
    }
}
