namespace BatchRecord.Domain.Entities
{
    public class Venta
    {

        public DateTime FecContab { get; set; }
        public int IdCenCos { get; set; }
        public string CentroCosto { get; set; }
        public decimal Cantidad { get; set; }   
        public decimal VrUnitKardex { get; set; }
        public decimal VrDesc { get; set; }
        public decimal valorneto { get; set; }


    }
}
