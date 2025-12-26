
using BatchRecord.Domain.DTOs.ConversionPdf;
using BatchRecord.Domain.Ports;
using System.Text;

namespace BatchRecord.Domain.Services.ConversionPdf
{
    [DomainService]
    public class ConversionPdfService(
        IConversionPdfRepository conversionPdfRepository
     )
    {

        public async Task<byte[]> GetPdfAsync()
        {
            var paginas = new List<PaginaSeisDto>
            {
                new()
                {
                    DespejeInicial = "D",
                    Fila2 = "73949",
                    Fila3 = "Si",
                    Fila4 = "Si",
                    Fila5 = "No",
                    Fila6 = "Si",
                    Fila7 = "Si",
                    Fila8 = "B.Castro",
                    Fila9 = "E.Muñoz",
                    Fila10 = "04/02/25",
                    DespejeFinal = "D",
                    Fila11 = "Si",
                    Fila12 = "No",
                    Fila13 = "Si",
                    Fila14 = "B.Castro",
                    Fila15 = "E.Muñoz",
                    Fila16 = "04/02/25",
                    MilitaryStandard = "Entrega 1",
                    StockProducto = "producto",
                    Fila17 = "5184",
                    Fila18 = "203",
                    Fila19 = "36",
                    Fila20 = "7",
                    Fila21 = "24",
                    Fila22 = "0",
                    Fila23 = "N/A",
                    Fila24 = "Cumple",
                    Fila25 = "G.Vega",
                    Fila26 = "N/A",
                    Fila27 = "✔",
                    Fila28 = "✔",
                    Fila29 = "✔",
                    Fila30 = "✔",
                    Fila31 = "✔",
                    Fila32 = "✔",
                    Fila33 = "-",
                    Fila34 = "-",
                    Fila35 = "-",
                    Fila36 = "-",
                    Fila37 = "-",
                    Fila38 = "✔",
                    Fila39 = "✔",
                    Fila40 = "✔",
                    Fila41 = "✔",
                    Fila42 = "✔",
                    Fila43 = "-",
                    Fila44 = "-"
                },
                new()
                {
                    DespejeInicial = "D",
                    Fila2 = "73949",
                    Fila3 = "Si",
                    Fila4 = "Si",
                    Fila5 = "No",
                    Fila6 = "Si",
                    Fila7 = "Si",
                    Fila8 = "B.Castro",
                    Fila9 = "E.Muñoz",
                    Fila10 = "04/02/25",
                    DespejeFinal = "D",
                    Fila11 = "Si",
                    Fila12 = "No",
                    Fila13 = "Si",
                    Fila14 = "B.Castro",
                    Fila15 = "E.Muñoz",
                    Fila16 = "04/02/25",
                    MilitaryStandard = "Entrega 1",
                    StockProducto = "producto",
                    Fila17 = "5184",
                    Fila18 = "203",
                    Fila19 = "36",
                    Fila20 = "7",
                    Fila21 = "24",
                    Fila22 = "0",
                    Fila23 = "N/A",
                    Fila24 = "Cumple",
                    Fila25 = "G.Vega",
                    Fila26 = "N/A",
                    Fila27 = "✔",
                    Fila28 = "✔",
                    Fila29 = "✔",
                    Fila30 = "✔",
                    Fila31 = "✔",
                    Fila32 = "✔",
                    Fila33 = "-",
                    Fila34 = "-",
                    Fila35 = "-",
                    Fila36 = "-",
                    Fila37 = "-",
                    Fila38 = "✔",
                    Fila39 = "✔",
                    Fila40 = "✔",
                    Fila41 = "✔",
                    Fila42 = "✔",
                    Fila43 = "-",
                    Fila44 = "-"
                }
            };

            var pdf = await conversionPdfRepository.GetPdfAsync(paginas);
            return pdf;
        }
    }
}
