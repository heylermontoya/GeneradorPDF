using BatchRecord.Domain.DTOs.Autenticacion;

namespace BatchRecord.Domain.DTOs.Autenticacion
{
    public class PermisosSalidaDto
    {
        public string IdObjeto { get; set; }
        public string IdUsuari { get; set; }
        public NivelAccesoDto NivelA { get; set; }
        public List<NivelAccesoCtrlDto> NivelAccesoCtrl { get; set; }
    }
}
