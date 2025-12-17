using BatchRecord.Domain.DTOs.Autenticacion;
using MediatR;

namespace BatchRecord.Aplication.Feature.Autenticacion.Queries
{
    public record GetUsuarioQuery(AuthRequestDto AuthRequest) : IRequest<AuthResponseDto>;
    
}
