using BatchRecord.Domain.DTOs.Venta;
using BatchRecord.Domain.Enums;
using BatchRecord.Domain.Helpers;
using BatchRecord.Domain.Ports;
using BatchRecord.Domain.QueryFilters;

namespace BatchRecord.Domain.Services.ventas
{
    [DomainService]
    public class VentaService(IQueryWrapper queryWrapper )
    {

        public async Task<List<VentasDto>> GetVentaByYear(int year, List<int> costCenter)
        {
            List<FieldFilter> listFilters = [];

            var ventas = await queryWrapper
                .QueryAsync<VentasDto>
                (
                ItemsMessageConstants.GetVentas.GetDescription(),
                new { year = year, costCenter = costCenter },

                FieldFilterHelper.BuildQueryArgs(listFilters)
                );



            return ventas.ToList();
        }
    }
}
