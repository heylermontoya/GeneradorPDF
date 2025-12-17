using BatchRecord.Domain.DTOs.Venta;
using MediatR;

namespace BatchRecord.Aplication.Feature.ventas.Queries
{
    public record GetYearsOfVentasQuery
    () : IRequest<List<YearsOfVentasDto>>;
}
