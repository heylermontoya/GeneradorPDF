
namespace BatchRecord.Domain.DTOs.Autenticacion
{
    public class AuthResponseDto(string? token, UsuarioDto? usuario)
    {
        public string Token { get; set; } = token;
        public UsuarioDto Usuario { get; set; } = usuario;
    }
}
