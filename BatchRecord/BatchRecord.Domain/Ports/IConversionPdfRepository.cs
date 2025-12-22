
using BatchRecord.Domain.DTOs.ConversionPdf;

namespace BatchRecord.Domain.Ports
{
    public interface IConversionPdfRepository
    {
        Task<byte[]> GetPdfAsync(List<PaginaSeisDto> html);

    }
}
