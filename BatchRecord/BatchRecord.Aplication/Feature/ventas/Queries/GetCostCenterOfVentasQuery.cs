using BatchRecord.Domain.DTOs.Venta;
using MediatR;

namespace BatchRecord.Aplication.Feature.ventas.Queries
{
    public record  GetCostCenterOfVentasQuery
    () : IRequest<List<CostCenterOfVentasDto>>;
}
