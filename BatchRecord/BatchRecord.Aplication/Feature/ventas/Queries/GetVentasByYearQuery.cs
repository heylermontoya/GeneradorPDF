using BatchRecord.Domain.DTOs.Venta;
using MediatR;

namespace BatchRecord.Aplication.Feature.ventas.Queries
{
    public record GetVentasByYearQueryAndCostCenter
   (
       int Year,
       List<int> costCenter
   ) : IRequest<List<VentasDto>>;
}
