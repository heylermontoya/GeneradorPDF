namespace BatchRecord.Domain.DTOs.Autenticacion
{
    public class EmpUsuariosDto
    {
        public string IdUsuari { get; set; }
        public string UsuPassword { get; set; }
        public string IdEmpresa { get; set; }
        public string UsuDirActivo { get; set; }
        public string Defecto { get; set; }
        public string IdEmpresaLogica { get; set; }
        public string NomEmpresaLogica { get; set; }
    }
}
