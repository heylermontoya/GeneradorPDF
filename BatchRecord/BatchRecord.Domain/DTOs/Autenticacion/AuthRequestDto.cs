using System.ComponentModel.DataAnnotations;

namespace BatchRecord.Domain.DTOs.Autenticacion
{
    public class AuthRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Usuario { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
