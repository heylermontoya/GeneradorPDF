
using MediatR;

namespace BatchRecord.Aplication.Feature.ConversionPdf.Queries
{
    public record GetConversionPdfQuery() : IRequest<byte[]>;
}
