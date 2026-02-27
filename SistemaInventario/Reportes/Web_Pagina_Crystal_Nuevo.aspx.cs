using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CapaEntidad;
using CapaNegocios;
using System.IO;
using System.Data;
using System.Globalization;
using KeepAutomation.Barcode.Crystal;
using System.Web.Services;
using System.Net;

namespace SistemaInventario.Reportes
{
    public partial class Web_Pagina_Crystal_Nuevo : System.Web.UI.Page
    {
        ReportDocument rpt = new ReportDocument();
        ReportDocument rpt2 = new ReportDocument();
        ReportDocument rpt3 = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            Reportes();
        }

        protected void Page_Unload(object sender, System.EventArgs e)
        {
            rpt.Close();
            rpt.Dispose();
            rpt2.Close();
            rpt2.Dispose();
            rpt3.Close();
            rpt3.Dispose();
        }

        private void Reportes()
        {
            MemoryStream msMemoria = null;
            DataSet ds = new DataSet();
            DataTable dtTabla = null;
            BarCode qrcode = new BarCode();
            String NombreTabla = Request.QueryString["NombreTabla"].ToString();
            String NombreArchivo = Request.QueryString["NombreArchivo"].ToString();
            ParameterDiscreteValue Parametro1 = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro2 = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro3 = new ParameterDiscreteValue();
            NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objNotaIngresoSalidaCabCN = new NotaIngresoSalidaCabCN();
            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();
            TrasladosCabCE objTrasladosCabCE = new TrasladosCabCE();
            TrasladosCabCN objTrasladosCabCN = new TrasladosCabCN();
            ProformaCabCE objProformaCabCE = new ProformaCabCE();
            ProformaCabCN objProformaCabCN = new ProformaCabCN();
            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();
         
            switch (Convert.ToInt32(Request["CodMenu"]))
            {
                case 100:
                    objTrasladosCabCE.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objTrasladosCabCE.TipoImpresion = Convert.ToString(Request.QueryString["TipoImp"]);
              
                    dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                    dtTabla.Columns.Add("OR", typeof(byte[]));
                    dtTabla.Columns.Add("PIE_PAGINA", typeof(string));

                    qrcode = new BarCode();
                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                    qrcode.X = 6;
                    qrcode.Y = 6;
                    qrcode.LeftMargin = 6;
                    qrcode.RightMargin = 6;
                    qrcode.TopMargin = 6;
                    qrcode.BottomMargin = 6;
                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                    foreach (DataRow dr in dtTabla.Rows)
                    {
                        string cadenaQR = dr["NroRuc"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Emision"] + "|" +
                                         dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["RucDestinatario"];
                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["OR"] = imageData;
                    }
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString() ?? "";
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 101:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 102:
                    objTrasladosCabCE.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objTrasladosCabCE.TipoImpresion = Convert.ToString(Request.QueryString["TipoImp"]);
                    dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);
                    break;            
                case 104:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);
                    break;


                case 200:

                    TrasladosCabCE objEntidadTraslados = new TrasladosCabCE();
                    TrasladosCabCN objOperacionTraslados = new TrasladosCabCN();

                    objEntidadTraslados.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objEntidadTraslados.TipoImpresion = Convert.ToString(Request.QueryString["TipoImp"]);

                    dtTabla = objOperacionTraslados.F_TrasladosCab_Impresion(objEntidadTraslados);
                    dtTabla.TableName = "Electronica";
                    dtTabla.Columns.Add("OR", typeof(byte[]));
                    dtTabla.Columns.Add("QR", typeof(byte[]));

                    qrcode = new BarCode();
                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                    qrcode.X = 6; qrcode.Y = 6;
                    qrcode.LeftMargin = 6;
                    qrcode.RightMargin = 6;
                    qrcode.TopMargin = 6;
                    qrcode.BottomMargin = 6;
                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;


                    foreach (DataRow dr in dtTabla.Rows)
                    {
                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["OR"] = imageData;
                    }
                    //foreach (DataRow dr in dtTabla.Rows)
                    //{
                    //    string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                    //                    "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                    //                    "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                    //    qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                    //}

                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["Archivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;
                case 201:
                    objDocumentoVentaCabCE = new DocumentoVentaCabCE();
                   
                    objDocumentoVentaCabCE.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objDocumentoVentaCabCE.TipoImpresion = Convert.ToString(Request.QueryString["TipoImp"]);

                    dtTabla = objDocumentoVentaCabCN.F_DocumentoVentaCab_Impresion_Factura_Electronica(objDocumentoVentaCabCE);
                    dtTabla.Columns.Add("QR", typeof(byte[]));
                    dtTabla.Columns.Add("OR", typeof(byte[]));
                    dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                    dtTabla.TableName = "Electronica";

                    qrcode = new BarCode();
                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                    qrcode.X = 6;
                    qrcode.Y = 6;
                    qrcode.LeftMargin = 6;
                    qrcode.RightMargin = 6;
                    qrcode.TopMargin = 6;
                    qrcode.BottomMargin = 6;
                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                    foreach (DataRow dr in dtTabla.Rows)
                    {
                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                        qrcode.CodeToEncode = cadenaQR;
                        byte[] imageData = qrcode.generateBarcodeToByteArray();
                        dr["QR"] = imageData;                      
                    }
                    //foreach (DataRow dr in dtTabla.Rows)
                    //{
                    //    string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                    //                    "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                    //                    "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                    //    qrcode.CodeToEncode = cadenaQR;
                    //    byte[] imageData = qrcode.generateBarcodeToByteArray();
                    //    dr["OR"] = imageData;
                    //}
                
                    for (int i = 1; i <= Convert.ToInt32(dtTabla.Rows[0]["NroCopias"]); i++)
                    {
                        rpt = new ReportDocument();
                        rpt.Load(Server.MapPath(dtTabla.Rows[0]["FormatoRPT"].ToString()));

                        rpt.SetDataSource(dtTabla);
                        rpt.Refresh();
                        rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                        rpt.PrintToPrinter(1, true, 1, 1);                        
                    }

                    if (dtTabla.Rows[0]["GuiaRemision"].ToString() != "")
                    {
                        if (dtTabla.Rows[0]["GuiaRemision"].ToString().Substring(0, 1) == "T")
                        {
                            objTrasladosCabCE.CodTraslado = Convert.ToInt32(dtTabla.Rows[0]["CodTraslado"]);
                            objTrasladosCabCE.TipoImpresion = Convert.ToString(Request.QueryString["TipoImp"]);

                            DataTable dtTablaGE = null;

                            dtTablaGE = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                            dtTablaGE.TableName = dtTablaGE.Rows[0]["Datatable"].ToString();
                            dtTablaGE.Columns.Add("QR", typeof(byte[]));
                            dtTablaGE.Columns.Add("OR", typeof(byte[]));

                            qrcode = new BarCode();
                            qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode; qrcode.X = 6; qrcode.Y = 6; qrcode.LeftMargin = 6; qrcode.RightMargin = 6;
                            qrcode.TopMargin = 6; qrcode.BottomMargin = 6; qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                            //foreach (DataRow dr in dtTablaGE.Rows)
                            //{
                            //    string cadenaQR = dr["NroRuc"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" +
                            //                      dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + "|" + dr["Emision"] + "|" +
                            //                      dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["RucDestinatario"];
                            //    qrcode.CodeToEncode = cadenaQR; byte[] imageData2 = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData2;
                            //}
                            foreach (DataRow dr in dtTablaGE.Rows)
                            {
                                string cadenaQR = dr["NroRuc"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Emision"] + "|" +
                                         dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["RucDestinatario"]; 
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData2 = qrcode.generateBarcodeToByteArray(); dr["OR"] = imageData2;
                            }

                            rpt3 = new ReportDocument();
                            rpt3.Load(Server.MapPath(dtTablaGE.Rows[0]["NombreArchivo"].ToString()));
                            rpt3.SetDataSource(dtTablaGE);
                            rpt3.PrintOptions.PrinterName = dtTablaGE.Rows[0]["Impresora"].ToString();
                            rpt3.PrintToPrinter(1, true, 1, 1);
                        }
                    }
                    break;
                case 202:
                    objProformaCabCE.CodProforma = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objProformaCabCN.F_ProformaCab_VistaPreliminar(objProformaCabCE);
                    dtTabla.TableName = "Electronica";
                
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["FormatoRPT"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.Refresh();
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.PrintToPrinter(1, true, 1, 1);                      
                    break;
                case 203:
                    objDocumentoVentaCabCE = new DocumentoVentaCabCE();

                    objDocumentoVentaCabCE.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objDocumentoVentaCabCE.TipoImpresion = Convert.ToString(Request.QueryString["TipoImp"]);

                    dtTabla = objDocumentoVentaCabCN.F_DocumentoVentaCab_Impresion_Factura_Electronica(objDocumentoVentaCabCE);
                    dtTabla.Columns.Add("QR", typeof(byte[]));          
                    dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                 
                    qrcode = new BarCode();
                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                    qrcode.X = 6;
                    qrcode.Y = 6;
                    qrcode.LeftMargin = 6;
                    qrcode.RightMargin = 6;
                    qrcode.TopMargin = 6;
                    qrcode.BottomMargin = 6;
                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                    foreach (DataRow dr in dtTabla.Rows)
                    {
                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                        qrcode.CodeToEncode = cadenaQR;
                        byte[] imageData = qrcode.generateBarcodeToByteArray();
                        dr["QR"] = imageData;
                    }                

                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["FormatoRPT"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 204:
                    objProformaCabCE.CodProforma = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objProformaCabCN.F_ProformaCab_VistaPreliminar(objProformaCabCE);
                    dtTabla.TableName = "Electronica";

                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["FormatoRPT"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 401:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    if (Request.QueryString["Resumido"].ToString().Equals("0"))
                        dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_REPORTECOBRANZARESUMIDO(objDocumentoVentaCabCE);
                    else
                        dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_Cobrados(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 402:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);

                    dtTabla = objDocumentoVentaCabCN.F_ObligacionesTributariasCab_REPORTE(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 500:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objNotaIngresoSalidaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objNotaIngresoSalidaCabCE.CodCtaCte = Convert.ToInt32(Request.QueryString["CodCtaCte"]);
                    objNotaIngresoSalidaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objNotaIngresoSalidaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);

                    dtTabla = objNotaIngresoSalidaCabCN.F_FacturasXPagar_Reporte(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
            }
        }

        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }

        public void P_PDF(MemoryStream msMemoria)
        {

            System.IO.Stream tempStream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
            msMemoria = new MemoryStream();
            tempStream.CopyTo(msMemoria);
            tempStream = null;

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
            Response.BinaryWrite(msMemoria.ToArray());
            msMemoria = null;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
