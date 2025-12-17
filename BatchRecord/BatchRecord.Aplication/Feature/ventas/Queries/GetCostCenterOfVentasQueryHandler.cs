using BatchRecord.Domain.DTOs.Venta;
using BatchRecord.Domain.Enums;
using BatchRecord.Domain.Helpers;
using BatchRecord.Domain.Ports;
using BatchRecord.Domain.QueryFilters;
using MediatR;

namespace BatchRecord.Aplication.Feature.ventas.Queries
{
    internal class GetCostCenterOfVentasQueryHandler(
        IQueryWrapper queryWrapper
        ) : IRequestHandler<GetCostCenterOfVentasQuery, List<CostCenterOfVentasDto>>
    {
        public async Task<List<CostCenterOfVentasDto>> Handle(GetCostCenterOfVentasQuery request, CancellationToken cancellationToken)
        {
            List<FieldFilter> listFilters = [];

            var costCenterOfVentas = await queryWrapper
                           .QueryAsync<CostCenterOfVentasDto>
                           (
                           ItemsMessageConstants.GetCostCenterOfVentas.GetDescription(),
                           new { },

                           FieldFilterHelper.BuildQueryArgs(listFilters)
                           );


            return costCenterOfVentas.ToList();
        }
    }
}
