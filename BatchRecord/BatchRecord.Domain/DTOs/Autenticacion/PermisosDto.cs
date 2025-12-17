namespace BatchRecord.Domain.DTOs.Autenticacion
{
    public class PermisosDto
    {
        public string IdObjeto { get; set; }
        public string IdUsuari { get; set; }
        public string? IdCtrl { get; set; }
        public string? VisCtrl { get; set; }
        public string? HabCtrl { get; set; }
        public int NivelA { get; set; }
    }
}
