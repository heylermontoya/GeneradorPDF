using BatchRecord.Domain.DTOs.Venta;
using BatchRecord.Domain.Services.ventas;
using MediatR;

namespace BatchRecord.Aplication.Feature.ventas.Queries
{
    public class GetVentasByYearQueryHandler(
                VentaService service
        ) : IRequestHandler<GetVentasByYearQueryAndCostCenter, List<VentasDto>>
    {
        public async Task<List<VentasDto>> Handle(GetVentasByYearQueryAndCostCenter request, CancellationToken cancellationToken)
        {

            List<VentasDto> venta = await service.GetVentaByYear(
                request.Year,
                request.costCenter
            );

            return venta;
        }
    }
}
