using BatchRecord.Aplication.Feature.ConversionPdf.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BatchRecord.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionPdfController(
        IMediator mediator
    ) : ControllerBase
    {
        [HttpGet("generar-pdf")]
        public async Task<IActionResult> GenerarPdf()
        {
            var pdfBytes = await mediator.Send(new GetConversionPdfQuery());
            return File(pdfBytes, "application/pdf", "reporte.pdf");

        }
    }
}
