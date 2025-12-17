using BatchRecord.Aplication.Feature.Autenticacion.Queries;
using BatchRecord.Domain.DTOs.Autenticacion;
using BatchRecord.Infrastructure.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BatchRecord.Aplication.DTOs.AutenticacionDto;

namespace BatchRecord.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutenticacionController(AppDbContextDapper appDbContextDapper, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Auth")]
        public async Task<ActionResult> Autenticar(AuthRequestDto authRequest)
        {
            var variable = await _mediator.Send(new GetUsuarioQuery(authRequest));
            if (variable == null)
                return Unauthorized();

            return Ok(variable);

        }

        [HttpPost("AuthEmpresa")]
        public async Task<ActionResult> AutenticarEmpresaBaseDatos(AuthRequestEmpresaBaseDatosDto authRequest)
        {
            HttpContext.Items["DB"] = authRequest.IdEmpresa;

            if (authRequest == null)
                return Unauthorized();
            return Ok(new { mensaje = "Base seleccionada correctamente", db = authRequest.IdEmpresa });

        }


    }
}
