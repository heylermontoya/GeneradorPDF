using BatchRecord.Domain.DTOs.Autenticacion;
using BatchRecord.Domain.Services.Autenticacion;
using MediatR;

namespace BatchRecord.Aplication.Feature.Autenticacion.Queries
{
    public class GetUsuarioQueryHandler(
        AutenticacionService autenticacionService
    ) : IRequestHandler<GetUsuarioQuery, AuthResponseDto>
    {

        public async Task<AuthResponseDto> Handle(
            GetUsuarioQuery request,
            CancellationToken cancellationToken
        )
        {
            return await autenticacionService.GetUser(request.AuthRequest.Usuario, request.AuthRequest.Password);
        }
    }
}
