using System.ComponentModel.DataAnnotations;

namespace BatchRecord.Aplication.DTOs.AutenticacionDto
{
    public class AuthRequestEmpresaBaseDatosDto
    {
        [Required(AllowEmptyStrings = false)]
        public string IdEmpresa { get; set; }
    }
}
