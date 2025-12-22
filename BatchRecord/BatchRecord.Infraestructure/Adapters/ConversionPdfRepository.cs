using BatchRecord.Domain.DTOs.ConversionPdf;
using BatchRecord.Domain.Ports;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
// Reemplaza la línea:
// var form = XForm.FromPdfPage(pdfTemp.Pages[0]);
// por la siguiente:


using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace BatchRecord.Infraestructure.Adapters
{
    public class ConversionPdfRepository : IConversionPdfRepository
    {
        public Task<byte[]> GetPdfAsync(List<PaginaSeisDto> html)
        {
            var pdf = new PdfDocument();

            for (int i = 0; i < html.Count; i++)
            {
                try
                {

                    var pagina = html[i];

                    var tablaHtml = $@"
                    <table>
                        <tr>
                            <td> <b>DESPEJE Incial</b></td>  <td>{pagina.DespejeInicial}</td>
                        </tr>
                        <tr><td>Número de Orden de producción anterior</td><td>{pagina.Fila2}</td></tr>
                        <tr><td>Dotación, EPP´S de personal, utensilios completos y correctos</td><td>{pagina.Fila3}</td></tr>
                        <tr><td>Se enceuntran el área y quipos/utensilios limpios</td><td>{pagina.Fila4}</td></tr>
                        <tr><td>Existen materiales o documentación de productos anteriores</td><td>{pagina.Fila5}</td></tr>
                        <tr><td>Se encuentra el área identificada de acuerdo al producto a realizar</td><td>{pagina.Fila6}</td></tr>
                        <tr><td>El material y documentos del producto a realizar se encutnran en el área</td><td>{pagina.Fila7}</td></tr>
                        <tr><td>Realizado por</td><td>{pagina.Fila8}</td></tr>
                        <tr><td>Verificado por </td><td>{pagina.Fila9}</td></tr>
                        <tr><td>Fecha: </td><td>{pagina.Fila10}</td></tr>
                        <tr>
                            <td> <b>DESPEJE Final</b></td>  <td>{pagina.DespejeFinal}</td>
                        </tr>
                        <tr><td>Se encuentran el área y los equipos/utensilios limpios</td><td>{pagina.Fila11}</td></tr>
                        <tr><td>Existen materiales o documentación</td><td>{pagina.Fila12}</td></tr>
                        <tr><td>El material y los productos se dejan adecuadamente identificados</td><td>{pagina.Fila13}</td></tr>
                        <tr><td>Realizado Por</td><td>{pagina.Fila14}</td></tr>
                        <tr><td>Verificado Por</td><td>{pagina.Fila15}</td></tr>
                        <tr><td>Fecha</td><td>{pagina.Fila16}</td></tr>
                        <tr>
                            <td>D= dispensacion - F=Fabricación - E=Envase - A=Acondicionamiento
                            <br/> Inspeccion Visual de Producto Terminado(Espacio exclusivo contol de calida)
                            </td>
                        </tr>
                        <tr>
                            <td> <b>Military STANDARD</b></td> <td>{pagina.MilitaryStandard}</td>
                        </tr>
                        <tr><td>STOCK PRODUCTO</td><td>{pagina.StockProducto}</td></tr>
                        <tr><td>a) total unidades acondicionadas</td><td>{pagina.Fila17}</td></tr>
                        <tr><td>b) Tamaño muestra</td><td>{pagina.Fila18}</td></tr>
                        <tr><td>c) Total cajas corrugadas</td><td>{pagina.Fila19}</td></tr>
                        <tr><td>d) Corrugados a revisar</td><td>{pagina.Fila20}</td></tr>
                        <tr><td>e) Cantiad producto a revisar</td><td>{pagina.Fila21}</td></tr>
                        <tr><td>Unidades no conformes </td><td>{pagina.Fila22}</td></tr>
                        <tr><td>Defecto encontrado </td><td>{pagina.Fila23}</td></tr>
                        <tr><td>Concepto </td><td>{pagina.Fila24}</td></tr>
                        <tr><td>Realizado por </td><td>{pagina.Fila25}</td></tr>
                        <tr><td>Observaciones </td><td>{pagina.Fila26}</td></tr>

                    </table>
                ";

                    var htmlPagina = ConstruirHtmlPagina(tablaHtml);
                    PdfGenerator.AddPdfPages(pdf, htmlPagina, PdfSharp.PageSize.A4);
                }
                catch (Exception e)
                {
                    var a = 0;
                }
            }

            //PdfGenerator.AddPdfPages(pdf, html, PdfSharp.PageSize.A4);

            using var ms = new MemoryStream();
            pdf.Save(ms, false);
            return Task.FromResult(ms.ToArray());

        }

        private string ConstruirHtmlPagina(string tablaHtml)
        {
            return $@"
                <html>
                <head>
                    <style>
                         body {{ font-family: Arial; font-size: 9px; margin: 15px; }}
                        h1 {{ text-align: center; }}
                        table {{ width: 100%; border-collapse: collapse; }}
                        td {{ border: 1px solid black; padding: 6px; }}
                    </style>
                </head>
                <body>
                   
                    {tablaHtml}
                </body>
                </html>
            ";
        }


    }
}
