using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Data;
using CapaEntidad;
using CapaNegocios;

namespace SistemaInventario.Reportes
{
    public partial class Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ExportGridToExcel(Request["Titulo"].ToString(), (GridView)Session["Excel"]);

            switch (Convert.ToInt32(Request["CodMenu"]))
            {

                case 712:
                    P_Reporte_Caja_Chica();
                    break;
            }
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
       
        
        private void ExportGridToExcel(String nameReport,GridView wControl)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = nameReport + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            wControl.GridLines = GridLines.Both;
            wControl.HeaderStyle.Font.Bold = true;
            wControl.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }  
    }
}