using BatchRecord.Domain.DTOs.Autenticacion;
using MediatR;

namespace BatchRecord.Aplication.Feature.Autenticacion.Queries
{
    public record GetPermisosQuery(string idObjeto, string idUsuario) : IRequest<PermisosSalidaDto>;
    
}
