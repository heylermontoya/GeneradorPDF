using BatchRecord.Domain.DTOs.Venta;
using BatchRecord.Domain.Enums;
using BatchRecord.Domain.Helpers;
using BatchRecord.Domain.Ports;
using BatchRecord.Domain.QueryFilters;
using MediatR;

namespace BatchRecord.Aplication.Feature.ventas.Queries
{
    public class GetYearsOfVentasQueryHandler(
        IQueryWrapper queryWrapper
        ) : IRequestHandler<GetYearsOfVentasQuery, List<YearsOfVentasDto>>
    {

        public async Task<List<YearsOfVentasDto>> Handle(GetYearsOfVentasQuery request, CancellationToken cancellationToken)
        {
            List<FieldFilter> listFilters = [];

         
            var yearsOfVentas = await queryWrapper
                .QueryAsync<YearsOfVentasDto>
                (
                ItemsMessageConstants.GetYearsOfVentas.GetDescription(),
                new { },

                FieldFilterHelper.BuildQueryArgs(listFilters)
                );        


            return yearsOfVentas.ToList();
        }






    }
}
