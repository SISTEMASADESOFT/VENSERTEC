//using CSharpAndExcel.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Data;
using CapaEntidad;
using CapaNegocios;

namespace SistemaInventario.Reportes
{
    public partial class ConstruirExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Request["CodMenu"]))
            {
                case 1:
                    P_RegistroVentas();
                    break;

                case 2:
                    P_RegistroCompras();
                    break;
                case 3:
                    P_Inventario_StockActual();
                    break;
                case 4:
                    P_Inventario_KardexSunat();
                    break;
                case 5:
                    P_Inventario_Pediodo();
                    break;
                case 6:
                    P_ReporteVentasPorPeriodoPorFamilia();
                    break;
                case 7:
                    P_ReporteVentasPorPeriodoCompleto();
                    break;
                case 8:
                    P_Reporte_Cobranzas();
                    break;
                case 12:
            P_Reporte_Cobranzas_Credito();
                    break;
                case 9:
                    P__ObligacionesTributariasCab_REPORTE();
                    break;
                case 10:
                    P_Reporte_Pagos();
                    break;
                case 11:
                    P_Inventario_Stock_Minimo();
                    break;
                case 600:
                    P_Contabilidad_RegistroVentas_Roman();
                    break;
                case 301:
                    P_Contabilidad_RegistroCompras();
                    break;
                case 303:
                    P_Contabilidad_RegistroCompras_detallado();
                    break;
                case 304:
                    P_Contabilidad_RegistroVentas();
                    break;
                case 305:
                    P_Contabilidad_RegistroVentas_detallado();
                    break;
                case 306:
                    P_Reporte_Vendedor_Ventas_Mes();
                    break;
                case 307:
                    P_Reporte_Ventas_Mes();
                    break;
                case 308:
                    P_Reporte_MedioPago_Mes();
                    break;
                case 309:
                    P_Reporte_Ventas_Mes_Unitario();
                    break;
                case 712:
                    P_Reporte_Caja_Chica();
                    break;
                case 713:
                    P_Reporte_Caja_Chica_Grupal();
                    break;
            }
        }
              
        public void P_RegistroCompras()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("RegistroCompras_Contabilidad.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);
         
            var ws = pck.Workbook.Worksheets["COMPRAS"];

            for (int i=8;i<10000;i++)
                ws.DeleteRow(i);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodEmpresa = 3;
            objEntidad.Periodo =Convert.ToInt32(Request["Periodo"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NotaIngresoSalidaCab_RegistroCompras(objEntidad);

            ws.Cells["A8"].LoadFromDataTable(dtTabla, true);

            ws.DeleteRow(8);
            ws.DeleteColumn(29);
            ws.DeleteColumn(30);
            ws.DeleteColumn(31);

            ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            ws.Cells["B3"].Value = dtTabla.Rows[0]["Nroruc"].ToString();
            ws.Cells["E4"].Value = dtTabla.Rows[0]["Empresa"].ToString();

            object BaseImponibleSuma;
            object IGVSuma;
            object IGVSINOGravadaSuma;
            object BaseSINOGravadaSuma;
            object IGVNOGravadaSuma;
            object NoAfectoSuma;
            object PercepcionSuma;
            object TotalSuma;
            
            BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
            IGVSuma = dtTabla.Compute("Sum(IGV)", "");
            IGVSINOGravadaSuma = dtTabla.Compute("Sum(IGVSINOGravada)", "");
            BaseSINOGravadaSuma = dtTabla.Compute("Sum(BaseSINOGravada)", "");
            IGVNOGravadaSuma = dtTabla.Compute("Sum(IGVNOGravada)", "");
            NoAfectoSuma = dtTabla.Compute("Sum(NoAfecto)", "");
            PercepcionSuma = dtTabla.Compute("Sum(Percepcion)", "");
            TotalSuma = dtTabla.Compute("Sum(Total)", "");

            ws.Cells["K" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = "TOTALES";

            ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseImponibleSuma.ToString();
            ws.Cells["M" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = IGVSuma.ToString();
            ws.Cells["O" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = IGVSINOGravadaSuma.ToString();
            ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseSINOGravadaSuma.ToString();
            ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = IGVNOGravadaSuma.ToString();
            ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = NoAfectoSuma.ToString();
            ws.Cells["S" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = PercepcionSuma.ToString();
            ws.Cells["T" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = TotalSuma.ToString();

            ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["M" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["O" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["S" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["T" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells["l:l"].Style.Numberformat.Format = null;
            ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["m:m"].Style.Numberformat.Format = null;
            ws.Cells["m:m"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["o:o"].Style.Numberformat.Format = null;
            ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["p:p"].Style.Numberformat.Format = null;
            ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["q:q"].Style.Numberformat.Format = null;
            ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["r:r"].Style.Numberformat.Format = null;
            ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["s:s"].Style.Numberformat.Format = null;
            ws.Cells["s:s"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["t:t"].Style.Numberformat.Format = null;
            ws.Cells["t:t"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["x:x"].Style.Numberformat.Format = null;
            ws.Cells["x:x"].Style.Numberformat.Format = "#,##0.000";

            String Cadena = "";
            Cadena = "A8:AB8," + "A" + Convert.ToString(dtTabla.Rows.Count + 8) + ":" + "AB" + Convert.ToString(dtTabla.Rows.Count + 8);

            using (ExcelRange rng = ws.Cells[Cadena])
            {
                rng.Style.Font.Bold = true;
                rng.Style.Font.SetFromFont(new Font("Arial", 10));
                rng.AutoFitColumns();
            }
            
            pck.Save();
          
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=RegistroCompras_Contabilidad.xlsx");
            Response.TransmitFile(Server.MapPath("RegistroCompras_Contabilidad.xlsx"));
            Response.End();
                    
        }

        public void P_RegistroVentas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("RegistroVentas_Contabilidad.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 8; i < 10000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodEmpresa = 3;
            objEntidad.Periodo = Convert.ToInt32(Request["Periodo"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_VentaIngresos(objEntidad);

            ws.Cells["A8"].LoadFromDataTable(dtTabla, true);

            //ws.DeleteRow(8);
            //ws.DeleteColumn(20);
            ws.DeleteColumn(21);
            ws.DeleteColumn(22);
            ws.DeleteColumn(23);
            ws.DeleteColumn(24);
            ws.DeleteColumn(25);
            ws.DeleteColumn(26);

            ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            ws.Cells["B3"].Value = dtTabla.Rows[0]["Nroruc"].ToString();
            ws.Cells["D4"].Value = dtTabla.Rows[0]["RazonSocial"].ToString();

            object BaseImponibleSuma;
            object IGVSuma;
            object TotalSuma;
            object OtrosTributos;

            BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
            IGVSuma = dtTabla.Compute("Sum(IGV)", "");
            TotalSuma = dtTabla.Compute("Sum(Total)", "");
            OtrosTributos = dtTabla.Compute("Sum(OtrosTributos)", "");

            ws.Cells["K" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = "TOTALES";
            ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = BaseImponibleSuma.ToString();
            ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = IGVSuma.ToString();
            ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = OtrosTributos.ToString();
            ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = TotalSuma.ToString();
            ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 9)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

         
            ws.Cells["o:o"].Style.Numberformat.Format = null;
            ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["p:p"].Style.Numberformat.Format = null;
            ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["q:q"].Style.Numberformat.Format = null;
            ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["r:r"].Style.Numberformat.Format = null;
            ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["s:s"].Style.Numberformat.Format = null;
            ws.Cells["s:s"].Style.Numberformat.Format = "#,##0.000";

            String Cadena = "";
            Cadena ="A8:S8," +  "A" + Convert.ToString(dtTabla.Rows.Count + 8) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 8);

            using (ExcelRange rng = ws.Cells[Cadena])
            {
                rng.Style.Font.Bold = true;
                rng.Style.Font.SetFromFont(new Font("Arial", 10));
                rng.AutoFitColumns();
            }

            pck.Save();
            MemoryStream msMemoria = null;
    
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=RegistroVentas_Contabilidad.xlsx");
            Response.TransmitFile(Server.MapPath("RegistroVentas_Contabilidad.xlsx"));
            Response.End();
        }

        public void P_CrearRegistroVentas()
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Ventas");

                ws.Cells["A1"].Value = "FORMATO 14.1: REGISTRO DE VENTAS E INGRESOS";

                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    using (ExcelRange rng = ws.Cells["A1:V1"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Merge = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        rng.Style.Font.SetFromFont(new Font("Arial", 14));

                    }
                }
                else
                {
                    using (ExcelRange rng = ws.Cells["A1:S1"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Merge = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        rng.Style.Font.SetFromFont(new Font("Arial", 14));

                    }
                }

                ws.Cells["A3"].Value = "PERIODO:";
                ws.Cells["A4"].Value = "RUC:";
                ws.Cells["A5"].Value = "APELLIDOS Y NOMBRES, DENOMINACIÓN O RAZÓN SOCIAL:";

                using (ExcelRange rng = ws.Cells["A3:A4"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                }

                using (ExcelRange rng = ws.Cells["A5:E5"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Merge = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.AutoFitColumns();
                }

                ws.Cells["A7"].Value = "NÚMERO";
                ws.Cells["A8"].Value = "CORRELATIVO";
                ws.Cells["A9"].Value = "DEL REGISTRO O";
                ws.Cells["A10"].Value = "CÓDIGO UNICO";
                ws.Cells["A11"].Value = "DE LA OPERACIÓN";

                ws.Cells["B7"].Value = " FECHA DE";
                ws.Cells["B8"].Value = "EMISIÓN DEL";
                ws.Cells["B9"].Value = "COMPROBANTE";
                ws.Cells["B10"].Value = "DE PAGO";
                ws.Cells["B11"].Value = "O DOCUMENTO";

                ws.Cells["C7"].Value = "FECHA";
                ws.Cells["C8"].Value = "DE";
                ws.Cells["C9"].Value = "VENCIMIENTO";
                ws.Cells["C10"].Value = "Y/O PAGO";
                ws.Cells["C11"].Value = "";

                ws.Cells["D7"].Value = "COMPROBANTE DE PAGO";
                ws.Cells["D8"].Value = "O DOCUMENTO";

                ws.Cells["D9 "].Value = "";
                ws.Cells["D10"].Value = "TIPO";
                ws.Cells["D11"].Value = "(TABLA 10)";

                ws.Cells["E9"].Value = "N° SERIE O";
                ws.Cells["E10"].Value = "N° DE SERIE DE LA";
                ws.Cells["E11"].Value = "MAQUINA REGISTRADORA";

                ws.Cells["F9"].Value = "";
                ws.Cells["F10"].Value = "NÚMERO";
                ws.Cells["F11"].Value = "";

                ws.Cells["G7"].Value = "INFORMACIÓN DEL CLIENTE";
                ws.Cells["G8"].Value = "";
                ws.Cells["G9"].Value = "DOCUMENTO DE IDENTIDAD";
                ws.Cells["G10"].Value = "TIPO";
                ws.Cells["G11"].Value = "(TABLA 2)";

                ws.Cells["H10"].Value = "NÚMERO";
                ws.Cells["H11"].Value = "";

                ws.Cells["I9"].Value = "APELLIDOS Y NOMBRES,";
                ws.Cells["I10"].Value = "DENOMINACIÓN";
                ws.Cells["I11"].Value = "O RAZÓN SOCIAL";

                ws.Cells["J7"].Value = "VALOR";
                ws.Cells["J8"].Value = "FACTURADO";
                ws.Cells["J9"].Value = "DE LA";
                ws.Cells["J10"].Value = "EXPORTACIÓN";
                ws.Cells["J11"].Value = "";

                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    ws.Cells["K7"].Value = "BASE";
                    ws.Cells["K8"].Value = "IMPONIBLE";
                    ws.Cells["K9"].Value = "DE LA";
                    ws.Cells["K10"].Value = "OPERACIÓN";
                    ws.Cells["K11"].Value = "GRAVADA";

                    ws.Cells["L7"].Value = "IMPORTE TOTAL DE LA OPERACIÓN";
                    ws.Cells["L8"].Value = "EXONERADA O INAFECTA";
                    ws.Cells["L9"].Value = "";
                    ws.Cells["L10"].Value = "EXONERADA";
                    ws.Cells["L11"].Value = "";

                    ws.Cells["M9"].Value = "";
                    ws.Cells["M10"].Value = "INAFECTA";
                    ws.Cells["M11"].Value = "";

                    ws.Cells["N9"].Value = "ISC";
                    ws.Cells["O9"].Value = "IGV Y/O IPM";

                    ws.Cells["P7"].Value = "OTROS TRIBUTOS";
                    ws.Cells["P8"].Value = "Y CARGOS QUE";
                    ws.Cells["P9"].Value = "NO FORMAN PARTE";
                    ws.Cells["P10"].Value = "DE LA";
                    ws.Cells["P11"].Value = " BASE IMPONIBLE";

                    ws.Cells["Q7"].Value = "IMPORTE";
                    ws.Cells["Q8"].Value = "TOTAL";
                    ws.Cells["Q9"].Value = "DEL";
                    ws.Cells["Q10"].Value = "COMPROBANTE";
                    ws.Cells["Q11"].Value = "DE PAGO";

                    ws.Cells["R7"].Value = "";
                    ws.Cells["R8"].Value = "TIPO";
                    ws.Cells["R9"].Value = "DE";
                    ws.Cells["R10"].Value = "CAMBIO";
                    ws.Cells["R11"].Value = "";

                    ws.Cells["S7"].Value = "REFERENCIA DEL COMPROBANTE DE PAGO";
                    ws.Cells["S8"].Value = "O DOCUMENTO ORIGINAL QUE SE MODIFICA";
                    ws.Cells["S9"].Value = "";
                    ws.Cells["S10"].Value = "FECHA";
                    ws.Cells["S11"].Value = "";

                    ws.Cells["T9"].Value = "";
                    ws.Cells["T10"].Value = "TIPO";
                    ws.Cells["T11"].Value = "TABLA (10)";

                    ws.Cells["U9"].Value = "";
                    ws.Cells["U10"].Value = "SERIE";
                    ws.Cells["U11"].Value = "";

                    ws.Cells["V9"].Value = "N° DEL";
                    ws.Cells["V10"].Value = "COMPROBANTE";
                    ws.Cells["V11"].Value = "DE PAGO O DOCUMENTO";

                }
                else
                {
                    ws.Cells["K7"].Value = "";
                    ws.Cells["K8"].Value = "";
                    ws.Cells["K9"].Value = "CTA";
                    ws.Cells["K10"].Value = "";
                    ws.Cells["K11"].Value = "";

                    ws.Cells["L7"].Value = "BASE";
                    ws.Cells["L8"].Value = "IMPONIBLE";
                    ws.Cells["L9"].Value = "DE LA";
                    ws.Cells["L10"].Value = "OPERACIÓN";
                    ws.Cells["L11"].Value = "GRAVADA";

                    ws.Cells["M7"].Value = "IMPORTE TOTAL DE LA OPERACIÓN";
                    ws.Cells["M8"].Value = "EXONERADA O INAFECTA";
                    ws.Cells["M9"].Value = "";
                    ws.Cells["M10"].Value = "EXONERADA";
                    ws.Cells["M11"].Value = "";

                    ws.Cells["N9"].Value = "";
                    ws.Cells["N10"].Value = "INAFECTA";
                    ws.Cells["N11"].Value = "";

                    ws.Cells["O9"].Value = "ISC";
                    ws.Cells["P9"].Value = "IGV Y/O IPM";

                    ws.Cells["Q7"].Value = "OTROS TRIBUTOS";
                    ws.Cells["Q8"].Value = "Y CARGOS QUE";
                    ws.Cells["Q9"].Value = "NO FORMAN PARTE";
                    ws.Cells["Q10"].Value = "DE LA";
                    ws.Cells["Q11"].Value = " BASE IMPONIBLE";

                    ws.Cells["R7"].Value = "IMPORTE";
                    ws.Cells["R8"].Value = "TOTAL";
                    ws.Cells["R9"].Value = "DEL";
                    ws.Cells["R10"].Value = "COMPROBANTE";
                    ws.Cells["R11"].Value = "DE PAGO";

                    ws.Cells["S7"].Value = "";
                    ws.Cells["S8"].Value = "TIPO";
                    ws.Cells["S9"].Value = "DE";
                    ws.Cells["S10"].Value = "CAMBIO";
                    ws.Cells["S11"].Value = "";

                    ws.Cells["T7"].Value = "REFERENCIA DEL COMPROBANTE DE PAGO";
                    ws.Cells["T8"].Value = "O DOCUMENTO ORIGINAL QUE SE MODIFICA";
                    ws.Cells["T9"].Value = "";
                    ws.Cells["T10"].Value = "FECHA";
                    ws.Cells["T11"].Value = "";

                    ws.Cells["U9"].Value = "";
                    ws.Cells["U10"].Value = "TIPO";
                    ws.Cells["U11"].Value = "TABLA (10)";

                    ws.Cells["V9"].Value = "";
                    ws.Cells["V10"].Value = "SERIE";
                    ws.Cells["V11"].Value = "";

                    ws.Cells["W9"].Value = "N° DEL";
                    ws.Cells["W10"].Value = "COMPROBANTE";
                    ws.Cells["W11"].Value = "DE PAGO O DOCUMENTO";
                }


                using (ExcelRange rng = ws.Cells["D7:F7"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.Merge = true;
                }

                using (ExcelRange rng = ws.Cells["D8:F8"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.Merge = true;
                }

                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    using (ExcelRange rng = ws.Cells["A7:V7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A8:V8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A9:V9"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A10:V10"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A11:V11"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                }
                else
                {
                    using (ExcelRange rng = ws.Cells["A7:S7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A8:S8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A9:S9"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A10:S10"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A11:S11"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                }



                using (ExcelRange rng = ws.Cells["G7:I7"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.Font.SetFromFont(new Font("Arial", 10));
                    rng.Merge = true;
                }

                using (ExcelRange rng = ws.Cells["G9:H9"])
                {
                    rng.Merge = true;
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.Font.SetFromFont(new Font("Arial", 10));
                    rng.AutoFitColumns();
                }
                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    using (ExcelRange rng = ws.Cells["L7:M7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["L8:M8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["S7:V7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["S8:V8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                }
                else
                {
                    using (ExcelRange rng = ws.Cells["M7:N7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["M8:N8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["S7:V7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));

                    }

                    using (ExcelRange rng = ws.Cells["S8:V8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));

                    }
                }

                ws.Column(7).Width = 180;
                ws.Column(8).Width = 180;
                for (int i = 1; i <= ws.Dimension.End.Column; i++)
                { ws.Column(i).AutoFit(); }

                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
                DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

                objEntidad.CodEmpresa = 3;
                objEntidad.Periodo = Convert.ToInt32(Request["Periodo"]);
                DataTable dtTabla = null;

                dtTabla = objOperacion.F_DocumentoVentaCab_VentaIngresos(objEntidad);

                ws.Cells["B3"].Value = dtTabla.Rows[0]["Periodo"].ToString();
                ws.Cells["B4"].Value = dtTabla.Rows[0]["Nroruc"].ToString();
                ws.Cells["F5"].Value = dtTabla.Rows[0]["RazonSocial"].ToString();

                using (ExcelRange rng = ws.Cells["B3:B4"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));

                }

                using (ExcelRange rng = ws.Cells["F5:M5"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.Merge = true;
                }

                ws.Cells["A12"].LoadFromDataTable(dtTabla, true);
                ws.DeleteRow(12);
                object BaseImponibleSuma;
                object IGVSuma;
                object TotalSuma;
                object OtrosTributos;
                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    ws.DeleteColumn(11);
                    ws.DeleteColumn(20);
                    ws.DeleteColumn(23);
                    ws.DeleteColumn(24);
                    ws.DeleteColumn(25);



                    BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
                    IGVSuma = dtTabla.Compute("Sum(IGV)", "");
                    TotalSuma = dtTabla.Compute("Sum(Total)", "");
                    OtrosTributos = dtTabla.Compute("Sum(OtrosTributos)", "");

                    ws.Cells["I" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = "TOTALES";
                    ws.Cells["K" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = BaseImponibleSuma.ToString();
                    ws.Cells["O" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = IGVSuma.ToString();
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = OtrosTributos.ToString();
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = TotalSuma.ToString();
                    ws.Cells["K" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["O" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells["k:k"].Style.Numberformat.Format = null;
                    ws.Cells["k:k"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["o:o"].Style.Numberformat.Format = null;
                    ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["p:p"].Style.Numberformat.Format = null;
                    ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["q:q"].Style.Numberformat.Format = null;
                    ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["r:r"].Style.Numberformat.Format = null;
                    ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
                }
                else
                {

                    ws.DeleteColumn(20);
                    ws.DeleteColumn(21);
                    ws.DeleteColumn(22);
                    ws.DeleteColumn(23);
                    ws.DeleteColumn(24);
                    ws.DeleteColumn(25);
                    ws.DeleteColumn(26);


                    BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
                    IGVSuma = dtTabla.Compute("Sum(IGV)", "");
                    TotalSuma = dtTabla.Compute("Sum(Total)", "");
                    OtrosTributos = dtTabla.Compute("Sum(OtrosTributos)", "");

                    ws.Cells["J" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = "TOTALES";
                    ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = BaseImponibleSuma.ToString();
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = IGVSuma.ToString();
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = OtrosTributos.ToString();
                    ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = TotalSuma.ToString();
                    ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells["l:l"].Style.Numberformat.Format = null;
                    ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["p:p"].Style.Numberformat.Format = null;
                    ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["q:q"].Style.Numberformat.Format = null;
                    ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["r:r"].Style.Numberformat.Format = null;
                    ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["s:s"].Style.Numberformat.Format = null;
                    ws.Cells["s:s"].Style.Numberformat.Format = "#,##0.000";

                    String Cadena = "";
                    Cadena = "A" + Convert.ToString(dtTabla.Rows.Count + 12) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 12);
                    using (ExcelRange rng = ws.Cells[Cadena])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }

                }

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=RegistroVentas.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
        }

        public void P_Contabilidad_RegistroVentas_Roman()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        //public void P_Contabilidad_RegistroCompras()
        //{
        //    FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

        //    ExcelPackage pck = new ExcelPackage(newFile);

        //    var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

        //    for (int i = 1; i < 500000; i++)
        //        ws.DeleteRow(1);

        //    NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
        //    NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

        //    objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
        //    objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
        //    objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

        //    DataTable dtTabla = null;

        //    dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(objEntidad);

        //    ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

        //    ws.Cells["h:h"].Style.Numberformat.Format = null;
        //    ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
        //    ws.Cells["i:i"].Style.Numberformat.Format = null;
        //    ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
        //    ws.Cells["j:j"].Style.Numberformat.Format = null;
        //    ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
        //    pck.Save();

        //    MemoryStream msMemoria = null;

        //    Response.ContentType = "application/octet-stream";
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
        //    Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
        //    Response.End();
        //}

        public void P_Contabilidad_RegistroCompras()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Detallado = Convert.ToInt32(Request["Detallado"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.Column(1).Width = 10.71;
            ws.Column(2).Width = 10.71;
            ws.Column(3).Width = 10.71;
            ws.Column(4).Width = 10.71;
            ws.Column(5).Width = 87.71;
            ws.Column(6).Width = 10.71;
            ws.Column(7).Width = 10.71;
            ws.Column(8).Width = 10.71;
            ws.Column(9).Width = 10.71;
            ws.Column(10).Width = 10.71;
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Contabilidad_RegistroCompras_detallado()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Detallado = Convert.ToInt32(Request["Detallado"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Column(1).Width = 10.71;
            ws.Column(2).Width = 87.71;
            ws.Column(3).Width = 9.71;
            ws.Column(4).Width = 13.71;
            ws.Column(5).Width = 13.71;
            ws.Column(6).Width = 59.71;
            ws.Column(7).Width = 15.71;
            ws.Column(8).Width = 9.71;
            ws.Column(9).Width = 7.71;
            ws.Column(10).Width = 21.71;
            ws.Column(11).Width = 8.71;
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }


        public void P_Contabilidad_RegistroVentas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Detallado = Convert.ToInt32(Request["Detallado"]);
            objEntidad.CodCtaCte = Convert.ToInt32(Request["CodCtaCte"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROVENTA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.Column(1).Width = 10.71;
            ws.Column(2).Width = 10.71;
            ws.Column(3).Width = 10.71;
            ws.Column(4).Width = 10.71;
            ws.Column(5).Width = 87.71;
            ws.Column(6).Width = 10.71;
            ws.Column(7).Width = 10.71;
            ws.Column(8).Width = 10.71;
            ws.Column(9).Width = 10.71;
            ws.Column(10).Width = 10.71;
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Contabilidad_RegistroVentas_detallado()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Detallado = Convert.ToInt32(Request["Detallado"]);
            objEntidad.CodCtaCte = Convert.ToInt32(Request["CodCtaCte"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROVENTA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Column(1).Width = 10.71;
            ws.Column(2).Width = 87.71;
            ws.Column(3).Width = 9.71;
            ws.Column(4).Width = 13.71;
            ws.Column(5).Width = 13.71;
            ws.Column(6).Width = 59.71;
            ws.Column(7).Width = 15.71;
            ws.Column(8).Width = 9.71;
            ws.Column(9).Width = 7.71;
            ws.Column(10).Width = 21.71;
            ws.Column(11).Width = 8.71;
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Caja_Chica()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
            objLGProductosCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodSede"]);
            objLGProductosCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
            objLGProductosCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objLGProductosCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);
            objLGProductosCE.CodDoc = Convert.ToInt32(Request.QueryString["CodDoc"]);



            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_CajaChica_Detalle(objLGProductosCE);

            if (dtTabla.Rows.Count != 0)
            {
                string MedioPago = dtTabla.Rows[0]["MedioPago"].ToString();
                string Operacion = dtTabla.Rows[0]["Operacion"].ToString();
                int C = 12;
                int LIO = 12;
                string LMINICIAL = "8";
                String LMI = LMINICIAL;
                string SE = "";
                string SS = "";
                int INDICE = 1;

                ws.Cells["F1"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                ws.Cells["F2"].Value = DateTime.Now.ToString("hh:mm:ss");

                ws.Cells["A1"].Value = dtTabla.Rows[0]["Empresa"].ToString();
                ws.Cells["A2"].Value = "SUCURSAL " + dtTabla.Rows[0]["Sede"].ToString();
                ws.Cells["B3"].Value = Request["Titulo"].ToString();
                ws.Cells["B4"].Value = dtTabla.Rows[0]["Fecha"].ToString();
                ws.Cells["A5"].Value = "Caja ";
                ws.Cells["B5"].Value = dtTabla.Rows[0]["Caja"].ToString();
                ws.Cells["A6"].Value = "Usuario Generación :";
                ws.Cells["B6"].Value = dtTabla.Rows[0]["UsuarioGeneracion"].ToString();
                ws.Cells["A7"].Value = "Usuario Cierre ";
                ws.Cells["B7"].Value = dtTabla.Rows[0]["UsuarioLiquidacion"].ToString();
                ws.Cells["A8"].Value = "Fecha Cierre ";
                ws.Cells["B8"].Value = dtTabla.Rows[0]["FechaLiquidacion"].ToString();
                ws.Cells["A9"].Value = "Emision";
                ws.Cells["B9"].Value = "Razon Social";
                ws.Cells["C9"].Value = "T/D";
                ws.Cells["D9"].Value = "S/.";
                ws.Cells["E9"].Value = "US$";
                ws.Cells["F9"].Value = "F/P";
                ws.Cells["G9"].Value = "OBSERVACION";
                ws.Cells["A10"].Value = MedioPago;
                ws.Cells["A10"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["A10"].Style.Font.Bold = true;
                ws.Cells["B11"].Value = Operacion;
                ws.Cells["B11"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["B11"].Style.Font.Bold = true;
                ws.Column(1).Width = 18.77;
                ws.Column(2).Width = 91.77;
                ws.Column(3).Width = 23.30;
                ws.Column(4).Width = 10.02;
                ws.Column(5).Width = 10.02;
                ws.Column(6).Width = 18.87;
                ws.Column(7).Width = 62.20;
                ws.Row(1).Height = 15;
                ws.Row(2).Height = 15;
                ws.Row(3).Height = 15;
                ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A1"].Style.Font.Size = 16;
                ws.Cells["A2"].Style.Font.Size = 16;
                ws.Cells["B3"].Style.Font.Size = 16;
                ws.Cells["B4"].Style.Font.Size = 12;
                ws.Cells["A5:B5"].Style.Font.Size = 10;
                ws.Cells["A6:B6"].Style.Font.Size = 10;
                ws.Cells["A7:B7"].Style.Font.Size = 10;
                ws.Cells["A8:B8"].Style.Font.Size = 10;
                ws.Cells["A9:G9"].Style.Font.Size = 12;
                ws.Cells["A9:G9"].Style.Font.Bold = true;
                ws.Row(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["A5:A8"].Style.Font.Bold = true;
                ws.Cells["A1:G1000"].Style.Font.Name = "Arial";
                ws.Cells["B3"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A2"].Style.Font.Bold = true;
                ws.Cells["A12:A1000"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["D12:D1000"].Style.Numberformat.Format = "#,##0.00";
                ws.Cells["E12:E1000"].Style.Numberformat.Format = "#,##0.00";
                ///////////////////////////////////////////////////
                for (int I = 0; I < dtTabla.Rows.Count; I++)
                {
                    ///////////////////////////////////////////////
                    if (dtTabla.Rows[I]["MedioPago"].ToString() == MedioPago)
                    {
                        if (dtTabla.Rows[I]["Operacion"].ToString() == Operacion)
                        {
                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;

                                    if (I == 0)
                                        INDICE = 0;

                                    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - INDICE]["Operacion"].ToString() + " " + dtTabla.Rows[I - INDICE]["MedioPago"].ToString();
                                    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                    INDICE = 1;

                                    if (I == 0)
                                    {
                                        LMI = (C).ToString();
                                    }
                                    else
                                    {
                                        LMI = (I + C).ToString();
                                    }

                                }
                                //EN CASO QUE SOLO SEA 1 VALOR DE ENTRADA
                                //else
                                //{
                                //    C++;
                                //    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + "1 " + dtTabla.Rows[I]["MedioPago"].ToString();
                                //    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                //    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                //    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                //    //aca guarda los valores de la entrada
                                //    //SE = (CS-2).ToString();
                                //    //SS = (CS-2).ToString();
                                //    LMI = (I + C).ToString();
                                //}

                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                //aca muestras el total final
                                C++;

                                SE = (LIO - 2).ToString();
                                SS = (LIO - 2).ToString();

                                //    LMI = (LIO - 2).ToString();

                                //if (dtTabla.Rows[I]["Operacion"].ToString() != "SALIDA")
                                //{
                                //    SE=  (8).ToString();
                                //    SS = (8).ToString();
                                //}
                                ws.Cells["C" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C).ToString();
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C).ToString();
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;


                            }
                        }
                        else
                        {
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Color.SetColor(Color.Black);
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;
                            Operacion = dtTabla.Rows[I]["Operacion"].ToString();

                            C++;
                            LIO = I + C;

                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;
                                    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;

                                }
                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;


                                C++;
                                ws.Cells["C" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C).ToString();
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C).ToString();
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;

                            }
                        }
                    }

     ///////////////////////////////////////////////////////////////////////////////////////////////////
                    else
                    {
                        //aca muestras los valores de la salida
                        ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                        ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                        ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;

                        //LMI = (I + C).ToString();

                        if (dtTabla.Rows[I - 1]["Operacion"].ToString() != "SALIDA")
                        {
                            SE = (8).ToString();
                            SS = (8).ToString();
                        }

                        //aca muestras los valores del total x medio de pago
                        C++;
                        ws.Cells["C" + (I + C).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["D" + (I + C).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C - 1).ToString();
                        ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["E" + (I + C).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C - 1).ToString();
                        ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                        C++;
                        ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["MedioPago"].ToString();
                        ws.Cells["A" + (I + C).ToString()].Style.Font.Bold = true;
                        MedioPago = dtTabla.Rows[I]["MedioPago"].ToString();
                        Operacion = dtTabla.Rows[I]["Operacion"].ToString();
                        LMI = LMINICIAL;
                        C++;
                        ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                        ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;


                        ws.Cells["A" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                        ws.Cells["B" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                        ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                        ws.Cells["D" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                        ws.Cells["E" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                        ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                        ws.Cells["G" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();


                        if (dtTabla.Rows.Count > I + 1)
                        {
                            if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                            {
                                C++;
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            }
                        }

                        if (dtTabla.Rows.Count == I + 1)
                        {
                            ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                            ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                            ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                            ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;

                        }
                        C++;
                        LIO = I + C;
                    }
                }

            }
            else
            {
                ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            }



            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Caja_Chica_Grupal()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            String XmlDetalle = "";

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request.QueryString["Codigos_Caja"]);

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " Codigos_Caja = '" + item.Codigos_Caja + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";


            objLGProductosCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodSede"]);
            objLGProductosCE.Codigos = XmlDetalle;
            objLGProductosCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objLGProductosCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);
            objLGProductosCE.coddoc = Convert.ToInt32(Request.QueryString["coddoc"]);



            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_CajaChica_Detalle_Grupal_Excel(objLGProductosCE);

            if (dtTabla.Rows.Count != 0)
            {

                string MedioPago = dtTabla.Rows[0]["MedioPago"].ToString();
                string Operacion = dtTabla.Rows[0]["Operacion"].ToString();
                int C = 12;
                int LIO = 12;
                string LMINICIAL = "8";
                String LMI = LMINICIAL;
                string SE = "";
                string SS = "";
                int INDICE = 1;

                ws.Cells["F1"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                ws.Cells["F2"].Value = DateTime.Now.ToString("hh:mm:ss");

                ws.Cells["A1"].Value = dtTabla.Rows[0]["Empresa"].ToString();
                ws.Cells["A2"].Value = "SUCURSAL " + dtTabla.Rows[0]["Sede"].ToString();
                ws.Cells["B3"].Value = Request["Titulo"].ToString();
                ws.Cells["B4"].Value = dtTabla.Rows[0]["Fecha"].ToString();
                ws.Cells["A5"].Value = "Caja ";
                ws.Cells["B5"].Value = dtTabla.Rows[0]["Caja"].ToString();
                ws.Cells["A6"].Value = "Usuario Generación :";
                ws.Cells["B6"].Value = dtTabla.Rows[0]["UsuarioGeneracion"].ToString();
                ws.Cells["A7"].Value = "Usuario Cierre ";
                ws.Cells["B7"].Value = dtTabla.Rows[0]["UsuarioLiquidacion"].ToString();
                ws.Cells["A8"].Value = "Fecha Cierre ";
                ws.Cells["B8"].Value = dtTabla.Rows[0]["FechaLiquidacion"].ToString();
                ws.Cells["A9"].Value = "Emision";
                ws.Cells["B9"].Value = "Razon Social";
                ws.Cells["C9"].Value = "T/D";
                ws.Cells["D9"].Value = "S/.";
                ws.Cells["E9"].Value = "US$";
                ws.Cells["F9"].Value = "F/P";
                ws.Cells["G9"].Value = "OBSERVACION";
                ws.Cells["A10"].Value = MedioPago;
                ws.Cells["A10"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["A10"].Style.Font.Bold = true;
                ws.Cells["B11"].Value = Operacion;
                ws.Cells["B11"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["B11"].Style.Font.Bold = true;
                ws.Column(1).Width = 18.77;
                ws.Column(2).Width = 91.77;
                ws.Column(3).Width = 23.30;
                ws.Column(4).Width = 10.02;
                ws.Column(5).Width = 10.02;
                ws.Column(6).Width = 18.87;
                ws.Column(7).Width = 62.20;
                ws.Row(1).Height = 15;
                ws.Row(2).Height = 15;
                ws.Row(3).Height = 15;
                ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A1"].Style.Font.Size = 16;
                ws.Cells["A2"].Style.Font.Size = 16;
                ws.Cells["B3"].Style.Font.Size = 16;
                ws.Cells["B4"].Style.Font.Size = 12;
                ws.Cells["A5:B5"].Style.Font.Size = 10;
                ws.Cells["A6:B6"].Style.Font.Size = 10;
                ws.Cells["A7:B7"].Style.Font.Size = 10;
                ws.Cells["A8:B8"].Style.Font.Size = 10;
                ws.Cells["A9:G9"].Style.Font.Size = 12;
                ws.Cells["A9:G9"].Style.Font.Bold = true;
                ws.Row(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["A5:A8"].Style.Font.Bold = true;
                ws.Cells["A1:G1000"].Style.Font.Name = "Arial";
                ws.Cells["B3"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A2"].Style.Font.Bold = true;
                ws.Cells["A12:A1000"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["D12:D1000"].Style.Numberformat.Format = "#,##0.00";
                ws.Cells["E12:E1000"].Style.Numberformat.Format = "#,##0.00";
                ///////////////////////////////////////////////////
                for (int I = 0; I < dtTabla.Rows.Count; I++)
                {
                    ///////////////////////////////////////////////
                    if (dtTabla.Rows[I]["MedioPago"].ToString() == MedioPago)
                    {
                        if (dtTabla.Rows[I]["Operacion"].ToString() == Operacion)
                        {
                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;

                                    if (I == 0)
                                        INDICE = 0;

                                    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - INDICE]["Operacion"].ToString() + " " + dtTabla.Rows[I - INDICE]["MedioPago"].ToString();
                                    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                    INDICE = 1;

                                    if (I == 0)
                                    {
                                        LMI = (C).ToString();
                                    }
                                    else
                                    {
                                        LMI = (I + C).ToString();
                                    }

                                }
                                //EN CASO QUE SOLO SEA 1 VALOR DE ENTRADA
                                //else
                                //{
                                //    C++;
                                //    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + "1 " + dtTabla.Rows[I]["MedioPago"].ToString();
                                //    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                //    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                //    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                //    //aca guarda los valores de la entrada
                                //    //SE = (CS-2).ToString();
                                //    //SS = (CS-2).ToString();
                                //    LMI = (I + C).ToString();
                                //}

                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                //aca muestras el total final
                                C++;

                                SE = (LIO - 2).ToString();
                                SS = (LIO - 2).ToString();

                                //    LMI = (LIO - 2).ToString();

                                //if (dtTabla.Rows[I]["Operacion"].ToString() != "SALIDA")
                                //{
                                //    SE=  (8).ToString();
                                //    SS = (8).ToString();
                                //}
                                ws.Cells["C" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C).ToString();
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C).ToString();
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;


                            }
                        }
                        else
                        {
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Color.SetColor(Color.Black);
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;
                            Operacion = dtTabla.Rows[I]["Operacion"].ToString();

                            C++;
                            LIO = I + C;

                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;
                                    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;

                                }
                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;


                                C++;
                                ws.Cells["C" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C).ToString();
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C).ToString();
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;

                            }
                        }
                    }

     ///////////////////////////////////////////////////////////////////////////////////////////////////
                    else
                    {
                        //aca muestras los valores de la salida
                        ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                        ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                        ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;

                        //LMI = (I + C).ToString();

                        if (dtTabla.Rows[I - 1]["Operacion"].ToString() != "SALIDA")
                        {
                            SE = (8).ToString();
                            SS = (8).ToString();
                        }

                        //aca muestras los valores del total x medio de pago
                        C++;
                        ws.Cells["C" + (I + C).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["D" + (I + C).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C - 1).ToString();
                        ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["E" + (I + C).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C - 1).ToString();
                        ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                        C++;
                        ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["MedioPago"].ToString();
                        ws.Cells["A" + (I + C).ToString()].Style.Font.Bold = true;
                        MedioPago = dtTabla.Rows[I]["MedioPago"].ToString();
                        Operacion = dtTabla.Rows[I]["Operacion"].ToString();
                        LMI = LMINICIAL;
                        C++;
                        ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                        ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;


                        ws.Cells["A" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                        ws.Cells["B" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                        ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                        ws.Cells["D" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                        ws.Cells["E" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                        ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                        ws.Cells["G" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();


                        if (dtTabla.Rows.Count > I + 1)
                        {
                            if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                            {
                                C++;
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            }
                        }

                        if (dtTabla.Rows.Count == I + 1)
                        {
                            ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                            ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                            ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                            ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;

                        }
                        C++;
                        LIO = I + C;
                    }
                }

            }
            else
            {
                ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            }

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Inventario_StockActual()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.CodFamilia = Convert.ToString(Request.QueryString["IdFamilia"]);
            objLGProductosCE.CodEstado = Convert.ToInt32(Request.QueryString["CodEstadoBusqueda"]);
            objLGProductosCE.Ubicacion = Convert.ToString(Request.QueryString["Ubicacion"]);
            objLGProductosCE.DscProducto = Convert.ToString(Request.QueryString["DscProducto"]);

            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_LGProductos_Inventario_StockActual(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.Cells["A1:k1"].Style.Font.Size = 10;
            ws.Cells["A1:k1"].Style.Font.Name = "arial";
            ws.Cells["A1:k1"].Style.Font.Bold = true;
            ws.Cells["A1:k1"].Style.Font.Color.SetColor(Color.Black);
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                   
            ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells["D:D"].Style.Numberformat.Format = null;
            ws.Cells["D:D"].Style.Numberformat.Format = "##0.00";
            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["H:H"].Style.Numberformat.Format = null;
            ws.Cells["H:H"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["I:I"].Style.Numberformat.Format = null;
            ws.Cells["I:I"].Style.Numberformat.Format = "#,##0.00";

            ws.DeleteColumn(11); ws.DeleteColumn(12); ws.DeleteColumn(13);

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Inventario_Stock_Minimo()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.CodFamilia = Convert.ToString(Request.QueryString["IdFamilia"]);

            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_LGProductos_Inventario_StockMinimo(objLGProductosCE);
                        
            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.Cells["A1:k1"].Style.Font.Size = 10;
            ws.Cells["A1:k1"].Style.Font.Name = "arial";
            ws.Cells["A1:k1"].Style.Font.Bold = true;
            ws.Cells["A1:k1"].Style.Font.Color.SetColor(Color.Black);
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "##0.00";
            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "##0.00";         
            ws.Cells["I:I"].Style.Numberformat.Format = null;
            ws.Cells["I:I"].Style.Numberformat.Format = "#,##0.00";
       
            ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Inventario_KardexSunat()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.Periodo = Convert.ToInt32(Request.QueryString["Periodo"]);
     
            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_LGProductos_KardexSunat(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.Cells["A1:L1"].Style.Font.Size = 10;
            ws.Cells["A1:L1"].Style.Font.Name = "arial";
            ws.Cells["A1:L1"].Style.Font.Bold = true;
            ws.Cells["A1:L1"].Style.Font.Color.SetColor(Color.Black);
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Column(8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Column(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Column(12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "##0.00";
            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "##0.00";
            ws.Cells["H:H"].Style.Numberformat.Format = null;
            ws.Cells["H:H"].Style.Numberformat.Format = "##0.00";

            ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;            

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Inventario_Pediodo()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.Periodo = Convert.ToInt32(Request.QueryString["Periodo"]);

            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_LGProductos_InventarioPeriodo(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.Cells["A1:k1"].Style.Font.Size = 10;
            ws.Cells["A1:k1"].Style.Font.Name = "arial";
            ws.Cells["A1:k1"].Style.Font.Bold = true;
            ws.Cells["A1:k1"].Style.Font.Color.SetColor(Color.Black);
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Column(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells["D:D"].Style.Numberformat.Format = null;
            ws.Cells["D:D"].Style.Numberformat.Format = "##0.00";
            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";

            ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_ReporteVentasPorPeriodoPorFamilia()
        {


            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);
            if (Convert.ToString(Request["CodAlmacen"]) == "T")
                objEntidad.CodAlmacen = 0;
            else
                objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.TipoReporte = Convert.ToInt32(Request["TipoReporte"]);


            //filtros de combos multiples
            //FAMILIAS-----------------------------------------
            objEntidad.xmlFamilias = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Familias"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + "<D ";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " IdFamilia = '" + item.IdFamilia + "'";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " />";
            }
            objEntidad.xmlFamilias = "<R><XmlLC> " + objEntidad.xmlFamilias + "</XmlLC></R>";

            //filtros de combos multiples
            //LINEAS-----------------------------------------
            objEntidad.xmlLineas = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Lineas"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlLineas = objEntidad.xmlLineas + "<D ";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " IdLinea = '" + item.IdLinea + "'";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " />";
            }
            objEntidad.xmlLineas = "<R><XmlLC> " + objEntidad.xmlLineas + "</XmlLC></R>";

            //MARCAS-----------------------------------------
            objEntidad.xmlMarcas = "";
            dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Marcas"]);
            foreach (dynamic item in jArr3)
            {
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + "<D ";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " Marca = '" + item.Marca + "'";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " />";
            }
            objEntidad.xmlMarcas = "<R><XmlLC> " + objEntidad.xmlMarcas + "</XmlLC></R>";

            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasArticulos_Periodo(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                P_CambioNombreColumnasPeriodos(ref dtTabla);

                FileInfo newFile = new FileInfo(Server.MapPath("Xls_Excel.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["Hoja1"];

                for (int i = 1; i < 100000; i++)
                    ws.DeleteRow(1);

                for (int i = 1; i < 50; i++)
                    ws.DeleteColumn(1);

                //Cabecera
                DateTime fi = Convert.ToDateTime(Request["Desde"].ToString()); DateTime ff = Convert.ToDateTime(Request["Hasta"].ToString());
                string PeriodoDesde = fi.ToString("dd/MM/yyyy");
                string PeriodoHasta = ff.ToString("dd/MM/yyyy");
                string Familias = dtTabla.Rows[0]["Familias"].ToString(); if (Familias == "") Familias = "TODAS";
                string Marcas = dtTabla.Rows[0]["Marcas"].ToString(); if (Marcas == "") Marcas = "TODAS";
                string Almacen = "TODOS";
                if (objEntidad.CodAlmacen > 0)
                    Almacen = ((new TCAlmacenCN()).F_TCAlmacen_Actual(new TCAlmacenCE() { CodEmpresa = 3, CodAlmacen = Convert.ToInt32(objEntidad.CodAlmacen) })).Rows[0]["DscAlmacen"].ToString();

                ws.Cells["A1"].Value = "REPORTE DE UNIDADES VENDIDAS POR PERIODO"; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
                ws.Cells["A2"].Value = "PERIODO: DEL " + PeriodoDesde + " AL " + PeriodoHasta; ws.Row(2).Style.Font.Bold = true;
                ws.Cells["A3"].Value = "FAMILIAS: " + Familias; ws.Row(3).Style.Font.Bold = true;
                ws.Cells["A4"].Value = "MARCAS: " + Marcas; ws.Row(4).Style.Font.Bold = true;
                ws.Cells["A5"].Value = "ALMACEN: " + Almacen; ws.Row(5).Style.Font.Bold = true;

                dtTabla.Columns.RemoveAt(0);
                dtTabla.Columns.RemoveAt(0);

                string FamBuff = ""; int co = 7;
                foreach (DataRow r in dtTabla.Rows)
                {
                    if (r["Familia"].ToString() != FamBuff)
                    {
                        FamBuff = r["Familia"].ToString();

                        //copia de rows necesarias
                        DataTable dt = dtTabla.Clone();
                        dtTabla.Select("Familia = '" + FamBuff + "'").CopyToDataTable(dt, LoadOption.OverwriteChanges);

                        //estilo de cabecera familia
                        ws.Cells["A" + co].Value = "FAMILIA: " + FamBuff;
                        ws.Row(co).Style.Font.Bold = true; ws.Row(co).Style.Font.Size = 16;
                        //estilo de cabecera titulos
                        co++; ws.Row(co).Style.Font.Bold = true;
                        ws.Row(co).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //carga de productos
                        dt.Columns.RemoveAt(0); ws.Cells["A" + co].LoadFromDataTable(dt, true);
                        co = co + dt.Rows.Count + 1;
                    }
                }

                ws.Column(1).Width = 15;
                ws.Column(2).Width = 40;
                ws.Column(3).Width = 15;


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Excel.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public void P_ReporteVentasPorPeriodoCompleto()
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);
            objEntidad.Descripcion = Convert.ToString(Request["Descripcion"]);
            if (Convert.ToString(Request["CodAlmacen"]) == "T")
                objEntidad.CodAlmacen = 0;
            else
                objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.TipoReporte = Convert.ToInt32(Request["TipoReporte"]);

            //filtros de combos multiples
            objEntidad.xmlFamilias = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Familias"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + "<D ";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " IdFamilia = '" + item.IdFamilia + "'";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " />";
            }
            objEntidad.xmlFamilias = "<R><XmlLC> " + objEntidad.xmlFamilias + "</XmlLC></R>";


            //filtros de combos multiples
            //LINEAS-----------------------------------------
            objEntidad.xmlLineas = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Lineas"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlLineas = objEntidad.xmlLineas + "<D ";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " IdLinea = '" + item.IdLinea + "'";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " />";
            }
            objEntidad.xmlLineas = "<R><XmlLC> " + objEntidad.xmlLineas + "</XmlLC></R>";


            objEntidad.xmlMarcas = "";
            dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Marcas"]);
            foreach (dynamic item in jArr3)
            {
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + "<D ";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " Marca = '" + item.Marca + "'";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " />";
            }
            objEntidad.xmlMarcas = "<R><XmlLC> " + objEntidad.xmlMarcas + "</XmlLC></R>";

            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasArticulos_Periodo(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                P_CambioNombreColumnasPeriodos(ref dtTabla);

                FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"].ToString()));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["Hoja1"];

                for (int i = 1; i < 100000; i++)
                    ws.DeleteRow(1);

                for (int i = 1; i < 50; i++)
                    ws.DeleteColumn(1);

                //Cabecera
                DateTime fi = Convert.ToDateTime(Request["Desde"].ToString()); DateTime ff = Convert.ToDateTime(Request["Hasta"].ToString());
                string PeriodoDesde = fi.ToString("dd/MM/yyyy");
                string PeriodoHasta = ff.ToString("dd/MM/yyyy");
                string Familias = dtTabla.Rows[0]["Familias"].ToString(); if (objEntidad.xmlFamilias == "<R><XmlLC> </XmlLC></R>") Familias = "TODAS";
                string Marcas = dtTabla.Rows[0]["Marcas"].ToString(); if (Marcas == "") Marcas = "TODAS";
                string Almacen = "TODOS";
                if (objEntidad.CodAlmacen > 0)
                    Almacen = ((new TCAlmacenCN()).F_TCAlmacen_Actual(new TCAlmacenCE() { CodEmpresa = 3, CodAlmacen = Convert.ToInt32(objEntidad.CodAlmacen) })).Rows[0]["DscAlmacen"].ToString();

                ws.Cells["A1"].Value = "REPORTE DE UNIDADES VENDIDAS POR PERIODO"; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
                ws.Cells["A2"].Value = "PERIODO: DEL " + PeriodoDesde + " AL " + PeriodoHasta; ws.Row(2).Style.Font.Bold = true;
                ws.Cells["A3"].Value = "FAMILIAS: " + Familias; ws.Row(3).Style.Font.Bold = true;
                ws.Cells["A4"].Value = "MARCAS: " + Marcas; ws.Row(4).Style.Font.Bold = true;
                ws.Cells["A5"].Value = "ALMACEN: " + Almacen; ws.Row(5).Style.Font.Bold = true;
               
                //estilo de cabecera titulos
                ws.Row(7).Style.Font.Bold = true;
                ws.Row(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells["A" + 8].LoadFromDataTable(dtTabla, true);
                             

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
                               
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        private void P_CambioNombreColumnasPeriodos(ref DataTable dtTabla)
        {
            //renombro las tablas
            foreach (DataColumn c in dtTabla.Columns)
            {
                try
                {
                    if (Convert.ToInt32(c.ColumnName.Substring(0, 4).ToString()) > 1900)
                    {
                        string año = c.ColumnName.Substring(2, 2).ToString();
                        string mes = c.ColumnName.Substring(4, 2).ToString();

                        switch (mes)
                        {
                            case "01": mes = "Ene"; break;
                            case "02": mes = "Feb"; break;
                            case "03": mes = "Mar"; break;
                            case "04": mes = "Abr"; break;
                            case "05": mes = "May"; break;
                            case "06": mes = "Jun"; break;
                            case "07": mes = "Jul"; break;
                            case "08": mes = "Ago"; break;
                            case "09": mes = "sep"; break;
                            case "10": mes = "Oct"; break;
                            case "11": mes = "Nov"; break;
                            case "12": mes = "Dic"; break;
                        }

                        string añomes = mes + "-" + año;
                        c.ColumnName = añomes;
                    }
                }
                catch (Exception ex)
                { }
            }

        }


        public void P_Reporte_Cobranzas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 500000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();

            objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
            objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

            objDocumentoVentaCabCE.XmlDetalle = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
            foreach (dynamic item in jArr2)
            {
                objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
            }
            objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

            DataTable dtTabla = null;

            dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte(objDocumentoVentaCabCE);

            dtTabla.Columns.RemoveAt(22);
            dtTabla.Columns.RemoveAt(21); dtTabla.Columns.RemoveAt(20); dtTabla.Columns.RemoveAt(19);
            dtTabla.Columns.RemoveAt(18); dtTabla.Columns.RemoveAt(17); dtTabla.Columns.RemoveAt(16);
            dtTabla.Columns.RemoveAt(15); dtTabla.Columns.RemoveAt(14); dtTabla.Columns.RemoveAt(13);
            dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteColumn(1);
            ws.DeleteRow(2);
            decimal SaldoDolares = 0;
            if (dtTabla.Rows.Count > 0)
            {
                SaldoDolares = (decimal)dtTabla.Compute("SUM([SaldoDolares])", null);
            }
            ws.Cells["G" + (dtTabla.Rows.Count + 2).ToString()].Value = "TOTAL";
            ws.Cells["H" + (dtTabla.Rows.Count + 2).ToString()].Value = SaldoDolares;

            ws.Cells["f:f"].Style.Numberformat.Format = null;
            ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["g:g"].Style.Numberformat.Format = null;
            ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Cobranzas_Credito()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 500000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();

            objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
            objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

            objDocumentoVentaCabCE.XmlDetalle = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
            foreach (dynamic item in jArr2)
            {
                objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
            }
            objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

            DataTable dtTabla = null;

            dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_Credito(objDocumentoVentaCabCE);

            dtTabla.Columns.RemoveAt(22);
            dtTabla.Columns.RemoveAt(21); dtTabla.Columns.RemoveAt(20); dtTabla.Columns.RemoveAt(19);
            dtTabla.Columns.RemoveAt(18); dtTabla.Columns.RemoveAt(17); dtTabla.Columns.RemoveAt(16);
            dtTabla.Columns.RemoveAt(15); dtTabla.Columns.RemoveAt(14); dtTabla.Columns.RemoveAt(13);
            dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteColumn(1);
            ws.DeleteRow(2);
            decimal SaldoDolares = 0;
            if (dtTabla.Rows.Count > 0)
            {
                SaldoDolares = (decimal)dtTabla.Compute("SUM([SaldoDolares])", null);
            }
            ws.Cells["G" + (dtTabla.Rows.Count + 2).ToString()].Value = "TOTAL";
            ws.Cells["H" + (dtTabla.Rows.Count + 2).ToString()].Value = SaldoDolares;

            ws.Cells["f:f"].Style.Numberformat.Format = null;
            ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["g:g"].Style.Numberformat.Format = null;
            ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }


        public void P__ObligacionesTributariasCab_REPORTE()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 500000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();

            objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
          
            DataTable dtTabla = null;

            dtTabla = objDocumentoVentaCabCN.F_ObligacionesTributariasCab_REPORTE(objDocumentoVentaCabCE);

            //dtTabla.Columns.RemoveAt(23); dtTabla.Columns.RemoveAt(22);
            //dtTabla.Columns.RemoveAt(21); dtTabla.Columns.RemoveAt(20); dtTabla.Columns.RemoveAt(19);
            //dtTabla.Columns.RemoveAt(18); dtTabla.Columns.RemoveAt(17); dtTabla.Columns.RemoveAt(16);
            //dtTabla.Columns.RemoveAt(15); dtTabla.Columns.RemoveAt(14); dtTabla.Columns.RemoveAt(13);
            //dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);

            //ws.Cells["A2"].LoadFromDataTable(dtTabla, true);
            ////ws.DeleteColumn(1);
            //ws.DeleteRow(2);
            //decimal SaldoDolares = 0;
            //if (dtTabla.Rows.Count > 0)
            //{
            //    SaldoDolares = (decimal)dtTabla.Compute("SUM([SaldoDolares])", null);
            //}
            //ws.Cells["G" + (dtTabla.Rows.Count + 2).ToString()].Value = "TOTAL";
            //ws.Cells["H" + (dtTabla.Rows.Count + 2).ToString()].Value = SaldoDolares;

            //ws.Cells["f:f"].Style.Numberformat.Format = null;
            //ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["g:g"].Style.Numberformat.Format = null;
            //ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["h:h"].Style.Numberformat.Format = null;
            //ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Pagos()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 500000; i++)
                ws.DeleteRow(2);


            NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objNotaIngresoSalidaCabCN = new NotaIngresoSalidaCabCN();

            objNotaIngresoSalidaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objNotaIngresoSalidaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objNotaIngresoSalidaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objNotaIngresoSalidaCabCE.CodCtaCte = Convert.ToInt32(Request.QueryString["CodCtaCte"]);

            DataTable dtTabla = null;

            dtTabla = objNotaIngresoSalidaCabCN.F_FacturasXPagar_Reporte(objNotaIngresoSalidaCabCE);

            //dtTabla.Columns.RemoveAt(23); dtTabla.Columns.RemoveAt(22);
            //dtTabla.Columns.RemoveAt(21); dtTabla.Columns.RemoveAt(20); dtTabla.Columns.RemoveAt(19);
            //dtTabla.Columns.RemoveAt(18); dtTabla.Columns.RemoveAt(17); dtTabla.Columns.RemoveAt(16);
            //dtTabla.Columns.RemoveAt(15); dtTabla.Columns.RemoveAt(14); dtTabla.Columns.RemoveAt(13);
            //dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);

            //ws.Cells["A2"].LoadFromDataTable(dtTabla, true);
            ////ws.DeleteColumn(1);
            //ws.DeleteRow(2);
            //decimal SaldoDolares = 0;
            //if (dtTabla.Rows.Count > 0)
            //{
            //    SaldoDolares = (decimal)dtTabla.Compute("SUM([SaldoDolares])", null);
            //}
            //ws.Cells["G" + (dtTabla.Rows.Count + 2).ToString()].Value = "TOTAL";
            //ws.Cells["H" + (dtTabla.Rows.Count + 2).ToString()].Value = SaldoDolares;

            //ws.Cells["f:f"].Style.Numberformat.Format = null;
            //ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["g:g"].Style.Numberformat.Format = null;
            //ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["h:h"].Style.Numberformat.Format = null;
            //ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Vendedor_Ventas_Mes()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objLGProductosCE.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.Ruta = Convert.ToInt32(Request.QueryString["Ruta"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);
            objLGProductosCE.codMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkCliente = Convert.ToInt32(Request.QueryString["chkCliente"]);
            objLGProductosCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objLGProductosCE.CodVendedor = Convert.ToInt32(Request.QueryString["Vendedor"]);
            objLGProductosCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);



            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR(objLGProductosCE);
            P_CambioNombreColumnasPeriodos(ref dtTabla);
            ws.Cells["A3"].LoadFromDataTable(dtTabla, true);
          
            ws.Cells["A1"].Value = Request["Titulo"].ToString();
            ws.Cells["A2"].Value = "MONEDA " + Request["MONEDA"].ToString();

            ws.Cells["A1"].Style.Font.Size = 16;
            ws.Cells["A2"].Style.Font.Size = 16;
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A2"].Style.Font.Bold = true;
            ws.Cells["b:b"].Style.Numberformat.Format = null;
            ws.Cells["b:b"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["c:c"].Style.Numberformat.Format = null;
            ws.Cells["c:c"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["d:d"].Style.Numberformat.Format = null;
            ws.Cells["d:d"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["e:e"].Style.Numberformat.Format = null;
            ws.Cells["e:e"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["f:f"].Style.Numberformat.Format = null;
            ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["g:g"].Style.Numberformat.Format = null;
            ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["k:k"].Style.Numberformat.Format = null;
            ws.Cells["k:k"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["l:l"].Style.Numberformat.Format = null;
            ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["m:m"].Style.Numberformat.Format = null;
            ws.Cells["m:m"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["n:n"].Style.Numberformat.Format = null;
            ws.Cells["n:n"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["o:o"].Style.Numberformat.Format = null;
            ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["p:p"].Style.Numberformat.Format = null;
            ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["q:q"].Style.Numberformat.Format = null;
            ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";

            ws.Column(1).Width = 18;
            ws.Column(2).Width = 12;
            ws.Column(3).Width = 12;
            ws.Column(4).Width = 12;
            ws.Column(5).Width = 12;
            ws.Column(6).Width = 12; 
            ws.Column(7).Width = 12;
            ws.Column(8).Width = 12;
            ws.Column(9).Width = 12;
            ws.Column(10).Width = 12;
            ws.Column(11).Width = 12;
            ws.Column(12).Width = 12;
            ws.Column(13).Width = 12;
            ws.Column(14).Width = 12;
            ws.Column(15).Width = 12;
            ws.Column(16).Width = 12;
            ws.Column(17).Width = 12;

            for (int i = 4; i <= (dtTabla.Rows.Count+3); i++)
            {
                for (int j = 1; j <= (dtTabla.Columns.Count); j++)
                {
                    if( Convert.ToString(ws.Cells[i, j].Value) == "")
                    {
                        ws.Cells[i, j].Value = 0;
                    }
                }
            }

            //ws.Cells[ dtTabla.Rows.Count + 4,1].Value = "TOTAL X MES";
            //var col = 2;
            //for (int K = 1; K < (dtTabla.Columns.Count); K++)
            //{
                
            //        ws.Cells[dtTabla.Rows.Count + 4, K + 1].Value = (decimal)dtTabla.Compute("SUM([" + ws.Cells[3, col].Value + "])", null);
            //    col=col+1;
            //    }

            ws.Cells[dtTabla.Rows.Count + 4, 1].Value = "TOTAL X MES";
            var col = 2;
            for (int K = 1; K < (dtTabla.Columns.Count); K++)
            {

                //ws.Cells[tabla1 + 4, K + 1].Value = (decimal)dtTabla.Compute("SUM([" + ws.Cells[3, col].Value + "])", null);

                ws.Cells[dtTabla.Rows.Count + 4, K + 1].Formula = "SUM(" + ws.Cells[4, K + 1].ToString() + ":" + ws.Cells[3 + dtTabla.Rows.Count, K + 1].ToString() + ")";
                if (col < dtTabla.Columns.Count - 1)
                {
                    col = col + 1;
                }
            }
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Ventas_Mes()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            for (int i = 1; i < 50; i++)
                ws.DeleteColumn(1);


            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objLGProductosCE.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.Ruta = Convert.ToInt32(Request.QueryString["Ruta"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);
            objLGProductosCE.codMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkCliente = Convert.ToInt32(Request.QueryString["chkCliente"]);
            objLGProductosCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objLGProductosCE.CodVendedor = Convert.ToInt32(Request.QueryString["Vendedor"]);
            objLGProductosCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);



            DataTable dtTabla = null;
            DataTable dtTabla2 = null;
            dtTabla = objLGProductosCN.F_DOCUMENTOVENTACAB_VENTAS_MENSUALES(objLGProductosCE);
            dtTabla2 = objLGProductosCN.F_DOCUMENTOVENTACAB_VENTAS_MENSUALES_LUBRICENTRO(objLGProductosCE);

            P_CambioNombreColumnasPeriodos(ref dtTabla);
            P_CambioNombreColumnasPeriodos(ref dtTabla2);
            ws.Cells["A3"].LoadFromDataTable(dtTabla, true);
            //ws.Column(1).Hidden = true;
            //ws.Column(2).Width = 18.71;
            //ws.Column(3).Width = 15.71;
            //ws.Column(4).Width = 15.71;
            //ws.Column(5).Width = 15.71;
            //ws.Column(6).Width = 15.71;
            //ws.Column(7).Width = 15.71;
            //ws.Column(8).Width = 15.71;
            //ws.Column(9).Width = 15.71;
            //ws.Column(10).Width = 15.71;
            //ws.Column(11).Width = 15.71;
            //ws.Column(12).Width = 15.71;
            //ws.Column(13).Width = 15.71;
            //ws.Column(14).Width = 15.71;
            //ws.Column(15).Width = 15.71;
            //ws.Column(16).Width = 15.71;
            //ws.Column(17).Width = 15.71;
            //ws.Column(18).Width = 15.71;

            //ws.DeleteColumn(1);
            string EMPRESA = dtTabla.Rows[0]["EMPRESA"].ToString();
            string EMPRESA2 = dtTabla2.Rows[0]["EMPRESA"].ToString();
            
            ws.Cells["A1"].Value = EMPRESA; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
            ws.Cells["A2"].Value = "MONEDA " + Request["MONEDA"].ToString();
            ws.Row(2).Style.Font.Size = 18; ws.Row(2).Style.Font.Bold = true;

            ws.Cells["A" + Convert.ToString(dtTabla.Rows.Count + 6)].Value = EMPRESA2; ws.Row(dtTabla.Rows.Count + 6).Style.Font.Size = 18; ws.Row(dtTabla.Rows.Count + 6).Style.Font.Bold = true;
            ws.Cells["A" + Convert.ToString(dtTabla.Rows.Count + 7)].Value = "MONEDA " + Request["MONEDA"].ToString();
            ws.Cells["A" + Convert.ToString(dtTabla.Rows.Count + 8)].LoadFromDataTable(dtTabla2, true);
            ws.Row(dtTabla.Rows.Count + 7).Style.Font.Size = 18; ws.Row(dtTabla.Rows.Count + 7).Style.Font.Bold = true;

           
            //ws.DeleteColumn(1);


            //ws.Cells["c:c"].Style.Numberformat.Format = null;
            //ws.Cells["c:c"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["d:d"].Style.Numberformat.Format = null;
            //ws.Cells["d:d"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["e:e"].Style.Numberformat.Format = null;
            //ws.Cells["e:e"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["f:f"].Style.Numberformat.Format = null;
            //ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["g:g"].Style.Numberformat.Format = null;
            //ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["h:h"].Style.Numberformat.Format = null;
            //ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["i:i"].Style.Numberformat.Format = null;
            //ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["j:j"].Style.Numberformat.Format = null;
            //ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["k:k"].Style.Numberformat.Format = null;
            //ws.Cells["k:k"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["l:l"].Style.Numberformat.Format = null;
            //ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["m:m"].Style.Numberformat.Format = null;
            //ws.Cells["m:m"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["n:n"].Style.Numberformat.Format = null;
            //ws.Cells["n:n"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["o:o"].Style.Numberformat.Format = null;
            //ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["p:p"].Style.Numberformat.Format = null;
            //ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["q:q"].Style.Numberformat.Format = null;
            //ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["r:r"].Style.Numberformat.Format = null;
            //ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
        
            var tabla1 = dtTabla.Rows.Count;
            var tabla2=dtTabla2.Rows.Count;
            ws.DeleteColumn(dtTabla.Columns.Count);

            for (int i = 3; i <= (tabla1 + 3); i++)
            {
                for (int j = 3; j <= (dtTabla.Columns.Count - 1); j++)
                {
                    if (Convert.ToString(ws.Cells[i, j].Value) == "")
                    {
                        ws.Cells[i, j].Value = 0;
                    }
                }
            }

            for (int i = (tabla1 + 5 + tabla2); i <= (tabla1 + 5 + tabla2 + 3); i++)
            {
                for (int j = 3; j <= (dtTabla2.Columns.Count-1); j++)
                {
                    if (Convert.ToString(ws.Cells[i, j].Value) == "")
                    {
                        ws.Cells[i, j].Value = 0;
                    }
                }
            }

            ws.Cells[tabla1 + 4, 1].Value = "TOTAL X MES";
            var col = 2;
            for (int K = 1; K < (dtTabla.Columns.Count); K++)
            {
              
                    //ws.Cells[tabla1 + 4, K + 1].Value = (decimal)dtTabla.Compute("SUM([" + ws.Cells[3, col].Value + "])", null);

                ws.Cells[tabla1 + 4, K + 1].Formula = "SUM(" + ws.Cells[4 , K + 1].ToString() + ":" + ws.Cells[3 + tabla1, K + 1].ToString() + ")"; 
                if (col < dtTabla.Columns.Count-1)
                {
                    col = col + 1;
                }
            }

            ws.Cells[tabla1 + 9 + tabla2, 1].Value = "TOTAL X MES";
            var col2 = 2;

            for (int L = 1; L < (dtTabla2.Columns.Count); L++)
            {


                ws.Cells[tabla1 + 9 + tabla2, L + 1].Formula = "SUM(" + ws.Cells[tabla2 + 9, L + 1].ToString() + ":" + ws.Cells[tabla1+tabla2 + 8, L + 1].ToString() + ")"; 
               
                if (col2 < dtTabla2.Columns.Count - 1)
                {
                    col2 = col2 + 1;
                }
           }
       

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_MedioPago_Mes()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            for (int i = 1; i < 50; i++)
                ws.DeleteColumn(1);


            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objLGProductosCE.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.Ruta = Convert.ToInt32(Request.QueryString["Ruta"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);
            objLGProductosCE.codMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkCliente = Convert.ToInt32(Request.QueryString["chkCliente"]);
            objLGProductosCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objLGProductosCE.CodVendedor = Convert.ToInt32(Request.QueryString["Vendedor"]);
            objLGProductosCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);



            DataTable dtTabla = null;
            DataTable dtTabla2 = null;
            dtTabla = objLGProductosCN.F_DOCUMENTOVENTACAB_MEDIOPAGO_MENSUALES(objLGProductosCE);
            dtTabla2 = objLGProductosCN.F_DOCUMENTOVENTACAB_INGRESO_MENSUALES(objLGProductosCE);

            P_CambioNombreColumnasPeriodos(ref dtTabla);
            P_CambioNombreColumnasPeriodos(ref dtTabla2);
            ws.Cells["A3"].LoadFromDataTable(dtTabla, true);
            //ws.Column(1).Hidden = true;
            //ws.Column(2).Width = 18.71;
            //ws.Column(3).Width = 15.71;
            //ws.Column(4).Width = 15.71;
            //ws.Column(5).Width = 15.71;
            //ws.Column(6).Width = 15.71;
            //ws.Column(7).Width = 15.71;
            //ws.Column(8).Width = 15.71;
            //ws.Column(9).Width = 15.71;
            //ws.Column(10).Width = 15.71;
            //ws.Column(11).Width = 15.71;
            //ws.Column(12).Width = 15.71;
            //ws.Column(13).Width = 15.71;
            //ws.Column(14).Width = 15.71;
            //ws.Column(15).Width = 15.71;
            //ws.Column(16).Width = 15.71;
            //ws.Column(17).Width = 15.71;
            //ws.Column(18).Width = 15.71;

            //ws.DeleteColumn(1);
            string EMPRESA = Request["Titulo"].ToString();
            string EMPRESA2 = Request["Titulo2"].ToString();

            ws.Cells["A1"].Value = EMPRESA; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
            ws.Cells["A2"].Value = "MONEDA " + Request["MONEDA"].ToString();
            ws.Row(2).Style.Font.Size = 18; ws.Row(2).Style.Font.Bold = true;

            ws.Cells["A" + Convert.ToString(dtTabla.Rows.Count + 6)].Value = EMPRESA2; ws.Row(dtTabla.Rows.Count + 6).Style.Font.Size = 18; ws.Row(dtTabla.Rows.Count + 6).Style.Font.Bold = true;
            ws.Cells["A" + Convert.ToString(dtTabla.Rows.Count + 7)].Value = "MONEDA " + Request["MONEDA"].ToString();
            ws.Cells["A" + Convert.ToString(dtTabla.Rows.Count + 8)].LoadFromDataTable(dtTabla2, true);
            ws.Row(dtTabla.Rows.Count + 7).Style.Font.Size = 18; ws.Row(dtTabla.Rows.Count + 7).Style.Font.Bold = true;


            //ws.DeleteColumn(1);


            //ws.Cells["c:c"].Style.Numberformat.Format = null;
            //ws.Cells["c:c"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["d:d"].Style.Numberformat.Format = null;
            //ws.Cells["d:d"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["e:e"].Style.Numberformat.Format = null;
            //ws.Cells["e:e"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["f:f"].Style.Numberformat.Format = null;
            //ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["g:g"].Style.Numberformat.Format = null;
            //ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["h:h"].Style.Numberformat.Format = null;
            //ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["i:i"].Style.Numberformat.Format = null;
            //ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["j:j"].Style.Numberformat.Format = null;
            //ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["k:k"].Style.Numberformat.Format = null;
            //ws.Cells["k:k"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["l:l"].Style.Numberformat.Format = null;
            //ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["m:m"].Style.Numberformat.Format = null;
            //ws.Cells["m:m"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["n:n"].Style.Numberformat.Format = null;
            //ws.Cells["n:n"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["o:o"].Style.Numberformat.Format = null;
            //ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["p:p"].Style.Numberformat.Format = null;
            //ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["q:q"].Style.Numberformat.Format = null;
            //ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["r:r"].Style.Numberformat.Format = null;
            //ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";

            var tabla1 = dtTabla.Rows.Count;
            var tabla2 = dtTabla2.Rows.Count;

            for (int i = 3; i <= (tabla1 + 3); i++)
            {
                for (int j = 3; j <= (dtTabla.Columns.Count - 1); j++)
                {
                    if (Convert.ToString(ws.Cells[i, j].Value) == "")
                    {
                        ws.Cells[i, j].Value = 0;
                    }
                }
            }

            for (int i = (tabla1 + 5 + tabla2); i <= (tabla1 + 5 + tabla2 + 3); i++)
            {
                for (int j = 3; j <= (dtTabla2.Columns.Count - 1); j++)
                {
                    if (Convert.ToString(ws.Cells[i, j].Value) == "")
                    {
                        ws.Cells[i, j].Value = 0;
                    }
                }
            }

            ws.Cells[tabla1 + 4, 1].Value = "TOTAL X MES";
            var col = 2;
            for (int K = 1; K < (dtTabla.Columns.Count); K++)
            {

                //ws.Cells[tabla1 + 4, K + 1].Value = (decimal)dtTabla.Compute("SUM([" + ws.Cells[3, col].Value + "])", null);

                ws.Cells[tabla1 + 4, K + 1].Formula = "SUM(" + ws.Cells[4, K + 1].ToString() + ":" + ws.Cells[3 + tabla1, K + 1].ToString() + ")";


                if (col < dtTabla.Columns.Count - 1)
                {
                    col = col + 1;                  
                }
            }

            ws.Cells[tabla1 + 9 + tabla2, 1].Value = "TOTAL X MES";
            var col2 = 2;

            for (int L = 1; L < (dtTabla2.Columns.Count); L++)
            {


                ws.Cells[tabla1 + 9 + tabla2, L + 1].Formula = "SUM(" + ws.Cells[tabla2 + 9, L + 1].ToString() + ":" + ws.Cells[tabla1 + tabla2 + 8, L + 1].ToString() + ")";

                if (col2 < dtTabla2.Columns.Count - 1)
                {
                    col2 = col2 + 1;
                }
            }

            


            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }


        public void P_Reporte_Ventas_Mes_Unitario()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            for (int i = 1; i < 50; i++)
                ws.DeleteColumn(1);


            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objLGProductosCE.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.Ruta = Convert.ToInt32(Request.QueryString["Ruta"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);
            objLGProductosCE.codMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkCliente = Convert.ToInt32(Request.QueryString["chkCliente"]);
            objLGProductosCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objLGProductosCE.CodVendedor = Convert.ToInt32(Request.QueryString["Vendedor"]);
            objLGProductosCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
            
            DataTable dtTabla = null;
            
            dtTabla = objLGProductosCN.F_DOCUMENTOVENTACAB_VENTAS_MENSUALES(objLGProductosCE);
           

            P_CambioNombreColumnasPeriodos(ref dtTabla);
           
            ws.Cells["A3"].LoadFromDataTable(dtTabla, true);
         
            //ws.DeleteColumn(1);
            string EMPRESA = dtTabla.Rows[0]["EMPRESA"].ToString();
           

            ws.Cells["A1"].Value = EMPRESA; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
            ws.Cells["A2"].Value = "MONEDA " + Request["MONEDA"].ToString();
            ws.Row(2).Style.Font.Size = 18; ws.Row(2).Style.Font.Bold = true;

            ws.Column(1).Width = 35;
           
          
            var tabla1 = dtTabla.Rows.Count;
            //ws.DeleteColumn(dtTabla.Columns.Count);

            for (int i = 3; i <= (tabla1 + 3); i++)
            {
                for (int j = 3; j <= (dtTabla.Columns.Count - 1); j++)
                {
                    if (Convert.ToString(ws.Cells[i, j].Value) == "")
                    {
                        ws.Cells[i, j].Value = 0;
                    }
                }
            }

            ws.Cells[tabla1 + 4, 1].Value = "TOTAL X MES";
            var col = 2;
            for (int K = 2; K < (dtTabla.Columns.Count); K++)
            {              
                ws.Cells[tabla1 + 4, K + 1].Formula = "SUM(" + ws.Cells[4, K + 1].ToString() + ":" + ws.Cells[3 + tabla1, K + 1].ToString() + ")";

                ws.Column(K + 1).Width = 17;
                ws.Column(K + 1).Style.Numberformat.Format = null;
                ws.Column(K + 1).Style.Numberformat.Format = "#,##0.00";

                if (col < dtTabla.Columns.Count - 1)
                {
                    col = col + 1;
                }
            }

            ws.Column(2).Width = 20;

          

            //ws.Cells["C:C"].Style.Numberformat.Format = null;
            //ws.Cells["C:C"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["D:D"].Style.Numberformat.Format = null;
            //ws.Cells["D:D"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["E:E"].Style.Numberformat.Format = null;
            //ws.Cells["E:E"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["F:F"].Style.Numberformat.Format = null;
            //ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["G:G"].Style.Numberformat.Format = null;
            //ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["H:h"].Style.Numberformat.Format = null;
            //ws.Cells["H:h"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["I:I"].Style.Numberformat.Format = null;
            //ws.Cells["I:I"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["J:J"].Style.Numberformat.Format = null;
            //ws.Cells["J:J"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["k:k"].Style.Numberformat.Format = null;
            //ws.Cells["k:k"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["L:L"].Style.Numberformat.Format = null;
            //ws.Cells["L:L"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["M:M"].Style.Numberformat.Format = null;
            //ws.Cells["M:M"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["N:N"].Style.Numberformat.Format = null;
            //ws.Cells["N:N"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["O:O"].Style.Numberformat.Format = null;
            //ws.Cells["O:O"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["P:P"].Style.Numberformat.Format = null;
            //ws.Cells["P:P"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["Q:Q"].Style.Numberformat.Format = null;
            //ws.Cells["Q:Q"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["R:R"].Style.Numberformat.Format = null;
            //ws.Cells["R:R"].Style.Numberformat.Format = "#,##0.00";

            

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }
    }

}