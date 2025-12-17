using BatchRecord.Domain.DTOs.Autenticacion;
using BatchRecord.Domain.Services.Autenticacion;
using MediatR;

namespace BatchRecord.Aplication.Feature.Autenticacion.Queries
{
    public class GetPermisosQueryHandler(
        AutenticacionService autenticacionService
    ) : IRequestHandler<GetPermisosQuery, PermisosSalidaDto>
    {
        public async Task<PermisosSalidaDto> Handle(GetPermisosQuery request, CancellationToken cancellationToken)
        {
            return await autenticacionService.ObtenerPermisosAsync(request.idObjeto, request.idUsuario);
        }
    }
}
