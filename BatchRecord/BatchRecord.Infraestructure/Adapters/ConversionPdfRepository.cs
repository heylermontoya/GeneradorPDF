using BatchRecord.Domain.DTOs.ConversionPdf;
using BatchRecord.Domain.Ports;
using PuppeteerReportCsharp;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.Text;

namespace BatchRecord.Infraestructure.Adapters
{
    public class ConversionPdfRepository : IConversionPdfRepository
    {
        public async Task<byte[]> GetPdfAsync(List<PaginaSeisDto> paginas)
        {
            string templateHtml = CargarTemplate("BatchRecord.Infraestructure.Templates.RegistroBatch.html");
            string content = GenerarTablaRegistro(paginas);
            templateHtml = templateHtml.Replace("{{CONTENT}}", content.ToString());

            await new BrowserFetcher().DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions());
            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(templateHtml);

            var pupeteer = new PuppeteerReport();
            byte[] pdfBytes = await pupeteer.PDFPage(page, new PuppeteerSharp.PdfOptions
            {
                Format = PaperFormat.A4,
                PreferCSSPageSize = true,
                MarginOptions = new MarginOptions
                {
                    Top = "10mm",
                    Bottom = "10mm",
                    Left = "10mm",
                    Right = "10mm"
                }
            });

            return pdfBytes;
        }

        private string CargarTemplate(string nombreRecurso)
        {
            var assembly = typeof(ConversionPdfRepository).Assembly;

            var recursos = assembly.GetManifestResourceNames();

            var stream = assembly.GetManifestResourceStream(nombreRecurso);

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private string GenerarTablaRegistro(List<PaginaSeisDto> paginas)
        {
            string tableHtml = CargarTemplate("BatchRecord.Infraestructure.Templates.TablaRegistro.html");

            var tableBuilder = new StringBuilder();
            for (int i = 0; i < paginas.Count(); i++)
            {
                tableBuilder.Append(tableHtml);
                if (i < paginas.Count() - 1)
                {
                    tableBuilder.Append("<div class=\"page-break\"></div>");
                }
            }
            return tableBuilder.ToString();
        }
    }
}
