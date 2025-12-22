


using BatchRecord.Domain.Services.ConversionPdf;
using MediatR;

namespace BatchRecord.Aplication.Feature.ConversionPdf.Queries
{
    public class GetConversionPdfQueryHandler(
        ConversionPdfService conversionPdf
    ) : IRequestHandler<GetConversionPdfQuery, byte[]>
    {
        public async Task<byte[]> Handle(
            GetConversionPdfQuery request,
            CancellationToken cancellationToken
        )
        {
            return await conversionPdf.GetPdfAsync();
        }
    }
}
