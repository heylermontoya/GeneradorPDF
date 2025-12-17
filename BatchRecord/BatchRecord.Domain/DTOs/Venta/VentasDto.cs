using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRecord.Domain.DTOs.Venta
{
    public class VentasDto
    {
        public int year { get; set; }
        public int mes { get; set; }
        public int IdCenCos { get; set; }
        public string CentroCosto { get; set; }
        public decimal TotalCantidadPorMes { get; set; }   // valorneto = cantidad*VrUnitKardex - VrDesc
        public decimal valornetoPorMes { get; set; }

    }
}
