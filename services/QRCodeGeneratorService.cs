using QRCoder;

namespace main_menu.Services
{
	public class QRCodeGeneratorService
	{
		public byte[] GenerateQRCode(string url)
		{
			var qrGenerator = new QRCodeGenerator();
			var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

			var qrCode = new BitmapByteQRCode(qrCodeData);
			var qrCodeImage = qrCode.GetGraphic(20);

			return qrCodeImage;
		}
	}
}