namespace BatchRecord.Domain.DTOs.Autenticacion
{
    public class NivelAccesoDto
    {
        public bool Listar { get; set; }
        public bool Propiedades { get; set; }
        public bool Crear { get; set; }
        public bool Modificar { get; set; }
        public bool Anular { get; set; }
        public bool Eliminar { get; set; }
    }
}
