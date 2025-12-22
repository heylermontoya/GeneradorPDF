
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
                    Fila2 = "11111",
                    Fila3 = "Si",
                    Fila4 = "Si",
                    Fila5 = "Si",
                    Fila6 = "Si",
                    Fila7 = "Si",
                    Fila8 = "B.Castro",
                    Fila9 = "E.Muñoz",
                    Fila10 = "01/01/01",
                    DespejeFinal = "D",
                    Fila11 = "Si",
                    Fila12 = "Si",
                    Fila13 = "Si",
                    Fila14 = "B.Castro",
                    Fila15 = "E.Muñoz",
                    Fila16 = "01/01/01",
                    MilitaryStandard = "Entrega 1",
                    StockProducto = "producto",
                    Fila17 = "11111",
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
                    Fila2 = "22222",
                    Fila3 = "No",
                    Fila4 = "No",
                    Fila5 = "No",
                    Fila6 = "No",
                    Fila7 = "No",
                    Fila8 = "B.Castro",
                    Fila9 = "E.Muñoz",
                    Fila10 = "02/02/02",
                    DespejeFinal = "D",
                    Fila11 = "No",
                    Fila12 = "No",
                    Fila13 = "No",
                    Fila14 = "B.Castro",
                    Fila15 = "E.Muñoz",
                    Fila16 = "02/02/02",
                    MilitaryStandard = "Entrega 1",
                    StockProducto = "producto",
                    Fila17 = "2222",
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
            };

            string fila1 = "0108-1";
            string fila2 = "Si";
            string fila3 = "No";
            string fila4 = "Si";
            string fila5 = "0094";
            string fila6 = "1205";
            string fila7 = "29/09/25";

            var tablaHtml = $@"
                <table>
                    <tr><td><b>DESPEJE FINAL</b></td><td>{fila1}</td></tr>
                    <tr><td>El material y los productos se dejan adecuadamente identificados</td><td>{fila2}</td></tr>
                    <tr><td>Existen materiales o documentación</td><td>{fila3}</td></tr>
                    <tr><td>Se encuentran el área y los equipos/utensilios limpios</td><td>{fila4}</td></tr>
                    <tr><td>Realizado Por</td><td>{fila5}</td></tr>
                    <tr><td>Verificado Por</td><td>{fila6}</td></tr>
                    <tr><td>Fecha Registro</td><td>{fila7}</td></tr>
                </table>
            "; 

            //var html = @"
            //    <html>
            //    <body>
            //        <h1>Reporte de prueba</h1>
            //        <p>Este PDF fue generado con HtmlRenderer.PdfSharp</p>
            //    </body>
            //    </html>
            //";

            var pdf = await conversionPdfRepository.GetPdfAsync(paginas);
            return pdf;


        }

        private string GenerarTabla(
            string fila1,
            string fila2,
            string fila3,
            string fila4,
            string fila5,
            string fila6,
            string fila7
        )
        {
            return $@"
                <table style='width:100%; border-collapse: collapse;' border='1'>
                    <tr>
                        <td><b>DESPEJE FINAL</b></td>
                        <td>{fila1}</td>
                    </tr>
                    <tr>
                        <td>El material y los productos se dejan adecuadamente identificados</td>
                        <td>{fila2}</td>
                    </tr>
                    <tr>
                        <td>Existen materiales o documentación</td>
                        <td>{fila3}</td>
                    </tr>
                    <tr>
                        <td>Se encuentran el área y los equipos/utensilios limpios</td>
                        <td>{fila4}</td>
                    </tr>
                    <tr>
                        <td>Realizado Por</td>
                        <td>{fila5}</td>
                    </tr>
                    <tr>
                        <td>Verificado Por</td>
                        <td>{fila6}</td>
                    </tr>
                    <tr>
                        <td>Fecha Registro</td>
                        <td>{fila7}</td>
                    </tr>
                </table>
            ";
        }
    }
}
