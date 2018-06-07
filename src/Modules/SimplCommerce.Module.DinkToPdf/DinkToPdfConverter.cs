using DinkToPdf;
using DinkToPdf.Contracts;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.DinkToPdf
{
    public class DinkToPdfConverter : IPdfConverter
    {
        private IConverter _converter;

        public DinkToPdfConverter(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] Convert(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);
            return pdf;
        }
    }
}
