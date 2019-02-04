using AppKit;
using Foundation;
using QRCoder;
using PdfSharp;

namespace qrwifiinfopage
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
            var assembly = typeof(AppDelegate).Assembly;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            PayloadGenerator.WiFi wifiPayload = new PayloadGenerator.WiFi(
                "rando SSID", 
                "password", 
                PayloadGenerator.WiFi.Authentication.WPA
                );
            QRCodeData qRCodeData = qrGenerator.CreateQrCode(wifiPayload);
            PngByteQRCode qrCodeImage = new PngByteQRCode(qRCodeData);
            byte[] qrCodeAsPngByteArr = qrCodeImage.GetGraphic(128);

            string filename = "rando.pdf";
            var document = new PdfSharp.Pdf.PdfDocument();
            document.Info.Title = "QR Code of Rando wifi";
            document.Info.Author = assembly.FullName;
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
