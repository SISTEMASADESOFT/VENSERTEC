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
    public partial class Crystal : System.Web.UI.Page
    {
        ReportDocument rpt = new ReportDocument();
        ReportDocument rptR = new ReportDocument();
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
            rptR.Close();
            rptR.Dispose();
        }

        private void Reportes()
        {
            MemoryStream msMemoria = null;
            DataSet ds = new DataSet();
            DataTable dtTabla = null;
            DataTable dtTabla2 = null;
            String NombreTabla = Request.QueryString["NombreTabla"].ToString();
            String NombreArchivo = Request.QueryString["NombreArchivo"].ToString();
            ParameterDiscreteValue Parametro = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro2 = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro3 = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro4 = new ParameterDiscreteValue();
            LetrasCabCE objEntidadLetras = new LetrasCabCE();
            LetrasCabCN objOperacionLetras = new LetrasCabCN();
            DocumentoVentaCabCE objEntidadVenta = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionVenta = new DocumentoVentaCabCN();
            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();
            NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objNotaIngresoSalidaCabCN = new NotaIngresoSalidaCabCN();
            TrasladosCabCE objTrasladosCabCE = new TrasladosCabCE();
            TrasladosCabCN objTrasladosCabCN = new TrasladosCabCN();
            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            switch (Convert.ToInt32(Request["CodMenu"]))
            {
                case 1:

                    Parametro.Value = "Nota de Pedido " + Request["Numero"].ToString();

                    NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
                    NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

                    objEntidad.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacion.F_NotaIngresoSalidaCab_VistaPreliminar(objEntidad);
                    dtTabla.TableName = "NotaIngresoSalida";

                    rpt.Load(Server.MapPath("rptNotaIngresoSalida.rpt"));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro.Value);

                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    break;

                case 2:

                    String Periodo = Request.QueryString["Periodo"].ToString();
                    DateTime Primer = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(Periodo.Length - 2)), 1).AddMonths(1);
                    Int32 Anio = Convert.ToInt32(Periodo.Substring(0, 4));
                    Int32 Mes = Convert.ToInt32(Periodo.Substring(Periodo.Length - 2));
                    Int32 Ultimo = DateTime.DaysInMonth(Anio, Mes);
                    Parametro.Value = "AREQUIPA";
                    Parametro2.Value = "01-" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Mes) + "-" + Anio.ToString() + " HASTA " +
                                       Ultimo.ToString() + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Mes) + "-" + Anio.ToString();

                    LGProductosCE objEntidadProducto = new LGProductosCE();
                    LGProductosCN objOperacionProducto = new LGProductosCN();

                    objEntidadProducto.Periodo = Convert.ToInt32(Request.QueryString["Periodo"]);
                    objEntidadProducto.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

                    dtTabla = objOperacionProducto.F_LGProductos_KardexSunat_pdf(objEntidadProducto);
                    dtTabla.TableName = "InventarioUnidadesFisicas";

                    rpt.Load(Server.MapPath("rptInventarioUnidadesFisicas.rpt"));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["Sede"].CurrentValues.Clear();
                    rpt.ParameterFields["Sede"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Desde"].CurrentValues.Clear();
                    rpt.ParameterFields["Desde"].CurrentValues.AddValue(Parametro2.Value);

                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    break;

                case 3:

                    MovimientosCE objEntidadMov = new MovimientosCE();
                    MovimientosCN objOperacionMov = new MovimientosCN();
                    Parametro.Value = Convert.ToInt32(Request.QueryString["NroMesAnio"]);
                    objEntidadMov.NroMesAnio = Convert.ToInt32(Request.QueryString["NroMesAnio"]);
                    objEntidadMov.CodProducto = Convert.ToInt32(Request.QueryString["CodProducto"]);

                    dtTabla = objOperacionMov.F_Movimientos_KardexDetalleCosto(objEntidadMov);
                    dtTabla.TableName = "KardexDetalleCosto";

                    rpt.Load(Server.MapPath("rptKardexDetalleCosto.rpt"));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["Periodo"].CurrentValues.Clear();
                    rpt.ParameterFields["Periodo"].CurrentValues.AddValue(Parametro.Value);
                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    break;

                case 4:

                    ProformaCabCE objEntidadProforma = new ProformaCabCE();
                    ProformaCabCN objOperacionProforma = new ProformaCabCN();
                    Parametro.Value = Convert.ToInt32(Request.QueryString["NroMesAnio"]);
                    objEntidadProforma.CodProforma = Convert.ToInt32(Request.QueryString["CodDocumentoVenta"]);

                    dtTabla = objOperacionProforma.F_ProformaCab_VistaPreliminar(objEntidadProforma);
                    dtTabla.TableName = "Electronica";

                    int CodSede = Convert.ToInt32(Request.QueryString["CodSede"]);
                    string SerieDoc = "001";
                    int CodTipoDoc = 15;
                    string TipoImpresion = Convert.ToString(Request.QueryString["TipoImpresion"]);
                    int CodDocumentoVenta = Convert.ToInt32(Request.QueryString["CodDocumentoVenta"]);;
                    DocumentoVentaCabCN objOperacionFactura22 = new DocumentoVentaCabCN();
                    DataTable dtPImpresion = objOperacionFactura22.F_DocumentoVentaCab_ImpresionConfiguracion(3, CodSede, SerieDoc, CodTipoDoc, TipoImpresion,CodDocumentoVenta);

                    rpt.Load(Server.MapPath(dtPImpresion.Rows[0]["FormatoRPT"].ToString()));
                    rpt.SetDataSource(dtTabla);

                    int tipoImpresion = Convert.ToInt32(Request.QueryString["CodTipoArchivo"]);
                    switch (TipoImpresion)
                    {
                        case "PDF": //MOSTRAR EN PDF
                            msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                            Response.BinaryWrite(msMemoria.ToArray());
                            break;
                        default: //POR IMPRESORA DIRECTO
                            int NroCopias = 1;
                            if ((Request.QueryString["NroCopias"]) != "")
                                NroCopias = Convert.ToInt32(Request.QueryString["NroCopias"]);
                            if (NroCopias == 0) NroCopias = 1;
                            for (int i = 1; i <= NroCopias; i++)
                            {
                                rpt = new ReportDocument();
                                rpt.Load(Server.MapPath("rptProforma.rpt"));
                                rpt.SetDataSource(dtTabla);
                                rpt.Refresh();

                                string rptxx = dtPImpresion.Rows[0]["Impresora"].ToString();
                                if ((dtPImpresion.Rows[0]["Impresora"].ToString() != ""))
                                    rpt.PrintOptions.PrinterName = (dtPImpresion.Rows[0]["Impresora"].ToString());
                                rpt.PrintToPrinter(1, true, 1, 1);
                            }
                            break;
                    }

                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    break;

                case 5:
                    //Parametros
                     CodDocumentoVenta = Convert.ToInt32(Request.QueryString["CodDocumentoVenta"]);
                    int CodEmpresa = 3; // Convert.ToInt32(Session["CodSede"]);
                    CodSede = Convert.ToInt32(Request.QueryString["CodSede"]);
                    SerieDoc = Convert.ToString(Request.QueryString["SerieDoc"]);
                    CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    TipoImpresion = Convert.ToString(Request.QueryString["TipoImpresion"]);

                    //Datos de la Factura
                    DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
                    objOperacionFactura22 = new DocumentoVentaCabCN();
                    objEntidadFactura.CodDocumentoVenta = CodDocumentoVenta;


                    dtTabla = objOperacionFactura22.F_DocumentoVentaCab_Impresion_NotaPedido(objEntidadFactura);
                    DocumentoVentaCabCN OBJImpresion = new DocumentoVentaCabCN();

                    //Parametros de Impresion
                    dtPImpresion = objOperacionFactura22.F_DocumentoVentaCab_ImpresionConfiguracion(CodEmpresa, CodSede, SerieDoc,
                                                                                                            CodTipoDoc, TipoImpresion, CodDocumentoVenta);

                    string FormatoRPT = dtPImpresion.Rows[0]["FormatoRPT"].ToString();
                    string ImpresoraRPT = dtPImpresion.Rows[0]["Impresora"].ToString();
                    int NroCopiasRPT = Convert.ToInt32(dtPImpresion.Rows[0]["NroCopias"].ToString());
                    string Margen = dtPImpresion.Rows[0]["Margen"].ToString();

                    rpt = new ReportDocument();
                    rpt.Load(Server.MapPath(FormatoRPT));


                    switch (TipoImpresion)
                    {
                        case "PDF": //PDF
                            rpt.SetDataSource(dtTabla);
                            rpt.Refresh();
                            msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                            Response.BinaryWrite(msMemoria.ToArray());
                            break;
                        default:
                            if (NroCopiasRPT == 0) NroCopiasRPT = 1;
                            for (int i = 1; i <= NroCopiasRPT; i++)
                            {
                                rpt.SetDataSource(dtTabla);
                                rpt.Refresh();
                                rpt.PrintOptions.PrinterName = ImpresoraRPT;
                                rpt.PrintToPrinter(1, true, 1, 1);
                            }
                            break;
                    }
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;

                case 16:

                    objEntidadVenta = new DocumentoVentaCabCE();
                    objOperacionVenta = new DocumentoVentaCabCN();

                    objEntidadVenta.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objEntidadVenta.CodSede = Convert.ToInt32(Session["CodSede"]);
                    objEntidadVenta.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

                    dtTabla = objOperacionVenta.F_CajaChica_Detalle(objEntidadVenta);
                    dtTabla.TableName = "CajaChicaDetalle";

                    rpt.Load(Server.MapPath("rptCajaChicaDetalle.rpt"));
                    rpt.SetDataSource(dtTabla);
                    try
                    {
                        rpt.SetParameterValue("pUsuarioGeneracion", dtTabla.Rows[0]["UsuarioGeneracion"]);
                    }
                    catch (Exception exxx)
                    {
                        rpt.SetParameterValue("pUsuarioGeneracion", "");
                    }

                    try
                    {
                        rpt.SetParameterValue("pUsuarioLiquidacion", dtTabla.Rows[0]["UsuarioLiquidacion"]);
                    }
                    catch (Exception exxx)
                    {
                        rpt.SetParameterValue("pUsuarioLiquidacion", "");
                    }

                    try
                    {
                        rpt.SetParameterValue("pFechaLiquidacion", dtTabla.Rows[0]["FechaLiquidacion"]);
                    }
                    catch (Exception exxx)
                    {
                        rpt.SetParameterValue("pFechaLiquidacion", "");
                    }


                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
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

                    BarCode qrcode = new BarCode();
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
                                    foreach (DataRow dr in dtTabla.Rows)
                                    {
                                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                                    }

                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["Archivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;

                case 201:

                    objEntidadFactura = new DocumentoVentaCabCE();
                    DocumentoVentaCabCN objOperacionFactura201 = new DocumentoVentaCabCN();

                    objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacionFactura201.F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidadFactura);
                    dtTabla.Columns.Add("QR", typeof(byte[]));
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
                        //break;
                    }

                    int Cod2 = Convert.ToInt32(Request.QueryString["CodTipoArchivo2"]);
                    int scod = Convert.ToInt32(Request.QueryString["CodTipoArchivo"]);
                    if (scod == 6) scod = 5;
                    switch (scod)
                    {
                        case 4: //IMPRESION DE FRENTE AL GUARDAR DOCUMENTO TIPO PDF.
                            //string nombreReporte = "";
                            //switch (Cod2)
                            //{
                            //    case 1: nombreReporte = "rptElectronica.rpt"; break; //factura
                            //    case 2: nombreReporte = "rptElectronicaBO.rpt"; break; //nota de credito
                            //    case 3: nombreReporte = "rptElectronicaNC.rpt"; break;
                            //}



                            int NroCopias = 1;
                            if ((Request.QueryString["NroCopias"]) != "")
                                NroCopias = Convert.ToInt32(Request.QueryString["NroCopias"]);
                            if (NroCopias == 0) NroCopias = 1;
                            for (int i = 1; i <= NroCopias; i++)
                            {
                                rpt = new ReportDocument();
                                rpt.Load(Server.MapPath(Convert.ToString(Request.QueryString["ArchivoRpt"])));

                                string ppagina = Convert.ToString(Request.QueryString["PrimeraCopia"]); if (i == 2) ppagina = Convert.ToString(Request.QueryString["SegundaCopia"]);

                                if (Cod2 == 1)
                                {
                                    foreach (DataRow dr in dtTabla.Rows)
                                    { dr["PIE_PAGINA"] = ppagina; }
                                }

                                rpt.SetDataSource(dtTabla);
                                rpt.Refresh();

                                //string rtptimpresora = Request.QueryString["Impresora"].ToString();
                                //if (rtptimpresora != "")
                                rpt.PrintOptions.PrinterName = Request.QueryString["Impresora"].ToString();

                                rpt.PrintToPrinter(1, true, 1, 1);
                                // rpt.PrintToPrinter(0, false, 0, 0);
                            }
                            break;

                        case 5: //Impresion normal (PDF DESDE CONSULTA)
                            //switch (Cod2)
                            //{
                            //    case 1: nombreReporte = "rptElectronica.rpt"; break; //factura
                            //    case 2: nombreReporte = "rptElectronicaBO.rpt"; break; //nota de credito
                            //    case 3: nombreReporte = "rptElectronicaNC.rpt"; break; //BOLETA
                            //    default: nombreReporte = "rptElectronica.rpt"; break;
                            //}

                            rpt.Load(Server.MapPath(Convert.ToString(Request.QueryString["ArchivoRpt"])));
                            rpt.SetDataSource(dtTabla);
                            msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                            Response.BinaryWrite(msMemoria.ToArray());
                            break;

                        case 7: //Impresion de Tickets (DESDE GUARDAR Y CONSULTA)
                            dtTabla = new DataTable();
                            objEntidadFactura = new DocumentoVentaCabCE();
                            objOperacionFactura22 = new DocumentoVentaCabCN();

                            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);
                            dtTabla = objOperacionFactura22.F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidadFactura);

                            if (dtTabla.Rows.Count > 0)
                            {
                                dtTabla.Columns.Add("QR", typeof(byte[]));
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
                                    //break;
                                }

                                //tipo de factura segun formato
                                string rptNombre = "";
                                switch ((int)dtTabla.Rows[0]["CodTipoDocumento"])
                                {
                                    case 16: //en caso de ser NV (proforma)
                                        rptNombre = "rptFacturaImpresionTicketNV.rpt";
                                        break;
                                    default:
                                        rptNombre = "rptFacturaImpresionTicket.rpt";
                                        break;
                                }

                                rpt = new ReportDocument();
                                rpt.Load(Server.MapPath(rptNombre));
                                rpt.SetDataSource(dtTabla);
                                rpt.Refresh();

                                if ((Request.QueryString["Impresora"]) != "")
                                    rpt.PrintOptions.PrinterName = (Request.QueryString["Impresora"]);

                                NroCopias = 1;
                                if ((Request.QueryString["NroCopias"]) != "")
                                    NroCopias = Convert.ToInt32(Request.QueryString["NroCopias"]);
                                if (NroCopias == 0) NroCopias = 2;
                                for (int i = 1; i <= NroCopias; i++)
                                {
                                    rpt.PrintToPrinter(1, false, 1, 1);
                                }
                            }
                            break;
                    }
                    break;

                case 202:

                    DocumentoVentaCabCE objEntidadBoleta = new DocumentoVentaCabCE();
                    DocumentoVentaCabCN objOperacionBoleta = new DocumentoVentaCabCN();

                    objEntidadBoleta.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacionBoleta.F_DocumentoVentaCab_Impresion(objEntidadBoleta);
                    dtTabla.TableName = "FacturaImpresion";
                    PageMargins MargenesBoleta = rpt.PrintOptions.PageMargins;
                    MargenesBoleta.bottomMargin = 900;

                    if (dtTabla.Rows[0][0].ToString().Substring(0, 3) == "003")
                    {
                        rpt.Load(Server.MapPath("rptBoletaImpresion.rpt"));
                        rpt.PrintOptions.PrinterName = "EPSON LX-350 ESCP";
                    }
                    else
                    {
                        rpt.Load(Server.MapPath("rptBoletaImpresionPrincipal.rpt"));
                        rpt.PrintOptions.PrinterName = "EPSON LX-350 ESC/P";
                    }

                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.ApplyPageMargins(MargenesBoleta);
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;

                case 203:

                    objEntidadFactura = new DocumentoVentaCabCE();
                    objOperacionFactura22 = new DocumentoVentaCabCN();

                    objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacionFactura22.F_DocumentoVentaCab_Impresion(objEntidadFactura);
                    dtTabla.TableName = "FacturaImpresion";
                    string archivoRPT = Server.MapPath(Request.QueryString["ArchivoRPT"]);
                    rpt.Load(archivoRPT);
                    if (Convert.ToInt32(Request.QueryString["MargenInferior"]) > 0)
                    {
                        PageMargins Margenes = rpt.PrintOptions.PageMargins;
                        Margenes.bottomMargin = Convert.ToInt32(Request.QueryString["MargenInferior"]);
                        rpt.PrintOptions.ApplyPageMargins(Margenes);
                    }

                    //Margenes.bottomMargin = 900;

                    // String Serie = Convert.ToString(dtTabla.Rows[0]["Numero"]);


                    rpt.PrintOptions.PrinterName = (Request.QueryString["Impresora"]);

                    //if (dtTabla.Rows[0][0].ToString().Substring(0, 3) == "003")
                    //{
                    //    rpt.Load(Server.MapPath("rptFacturaImpresion.rpt"));
                    //    rpt.PrintOptions.PrinterName = "EPSON LX-350 ESCP";
                    //}
                    //else
                    //{
                    //    rpt.Load(Server.MapPath("rptFacturaImpresionPrincipal.rpt"));
                    //    rpt.PrintOptions.PrinterName = "EPSON LX-350 ESC/P";

                    //}

                    //rpt.Load(Server.MapPath("FacturaImpresion.rpt"));
                    //rpt.Load(Server.MapPath("rptFacturaImpresion.rpt"));



                    rpt.SetDataSource(dtTabla);



                    //rpt.PrintOptions.PrinterName = "EPSON LX-350 ESCP";
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;

                case 204:
                    objOperacionTraslados = new TrasladosCabCN();
                    objEntidadTraslados = new TrasladosCabCE();

                    objEntidadTraslados.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacionTraslados.F_TrasladosCab_Impresion(objEntidadTraslados);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["Archivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();

                    rpt.PrintToPrinter(1, true, 1, 1);
                    break;

                case 205:

                    objEntidad = new NotaIngresoSalidaCabCE();
                    objOperacion = new NotaIngresoSalidaCabCN();
                    objEntidad.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objOperacion.F_NotaIngresoSalidaCab_Impresion_Factura(objEntidad);
                    dtTabla.TableName = NombreTabla;
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;


                case 206:

                    objEntidad = new NotaIngresoSalidaCabCE();
                    objOperacion = new NotaIngresoSalidaCabCN();
                    objEntidad.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objEntidad.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    dtTabla = objOperacion.F_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir(objEntidad);
                    dtTabla.TableName = "Electronica";
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["FormatoReporte"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;


                case 23:

                    objEntidadVenta = new DocumentoVentaCabCE();
                    objOperacionVenta = new DocumentoVentaCabCN();

                    objEntidadVenta.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objEntidadVenta.CodSede = Convert.ToInt32(Session["CodSede"]);
                    objEntidadVenta.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

                    dtTabla = objOperacionVenta.F_CajaChica_Regenerar_VistaPreliminar(objEntidadVenta);
                    dtTabla.TableName = "CajaChicaDetalle";

                    rpt.Load(Server.MapPath("rptCajaChicaDetalle.rpt"));
                    rpt.SetDataSource(dtTabla);

                    try
                    {
                        rpt.SetParameterValue("pUsuarioGeneracion", dtTabla.Rows[0]["UsuarioGeneracion"]);
                    }
                    catch (Exception exxx)
                    {
                        rpt.SetParameterValue("pUsuarioGeneracion", "");
                    }

                    try
                    {
                        rpt.SetParameterValue("pUsuarioLiquidacion", dtTabla.Rows[0]["UsuarioLiquidacion"]);
                    }
                    catch (Exception exxx)
                    {
                        rpt.SetParameterValue("pUsuarioLiquidacion", "");
                    }

                    try
                    {
                        rpt.SetParameterValue("pFechaLiquidacion", dtTabla.Rows[0]["FechaLiquidacion"]);
                    }
                    catch (Exception exxx)
                    {
                        rpt.SetParameterValue("pFechaLiquidacion", "");
                    }


                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;

                case 24:

                    Parametro.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();
                    Parametro3.Value = Request.QueryString["NombrePlaca"].ToString();

                   
                    objEntidadVenta = new DocumentoVentaCabCE();
                    objOperacionVenta = new DocumentoVentaCabCN();

                    objEntidadVenta.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objEntidadVenta.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objEntidadVenta.Placa = Convert.ToString(Request.QueryString["Placa"]);
                    objEntidadVenta.CodCliente = Convert.ToInt32(Request.QueryString["codcliente"]);
                    objEntidadVenta.CkhCliente = Convert.ToInt32(Request.QueryString["Cliente"]);

                    dtTabla = objOperacionVenta.F_Reporte_Ventas_Placa(objEntidadVenta);
                    dtTabla.TableName = "REPORTEPLACA";

                    Parametro4.Value = dtTabla.Rows[0]["Empresa"].ToString();

                    rpt = new ReportDocument();
                    rpt.Load(Server.MapPath("rptReporteVentasPlaca.rpt"));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);
                    rpt.ParameterFields["NombrePlaca"].CurrentValues.Clear();
                    rpt.ParameterFields["NombrePlaca"].CurrentValues.AddValue(Parametro3.Value);
                    rpt.ParameterFields["Empresa"].CurrentValues.Clear();
                    rpt.ParameterFields["Empresa"].CurrentValues.AddValue(Parametro4.Value);


                     //rpt.SetDataSource(dtTabla);
                     //rpt.Refresh();
                     try
                     {
                         System.IO.Stream tempStream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                         msMemoria = new MemoryStream();
                         tempStream.CopyTo(msMemoria);
                         tempStream = null;
                     }
                     catch (Exception)
                     {
                     }
                     //msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                     Response.Clear();
                     Response.Buffer = true;
                     Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                     Response.BinaryWrite(msMemoria.ToArray());
                            break;

                case 210:

                    objEntidadLetras.CodLetraCab = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacionLetras.F_LetrasCab_Listar_Documentos1(objEntidadLetras);
                    dtTabla.TableName = "AvisoCobranza1";

                    dtTabla2 = objOperacionLetras.F_LetrasCab_Listar_Documentos2(objEntidadLetras);


                    rpt.Load(Server.MapPath("rptLetrasCab_Listar_Documentos1.rpt"));
                    rpt.SetDataSource(dtTabla);

                    rpt.Subreports[0].SetDataSource(dtTabla2);

                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    break;


                case 211:

                    objEntidadVenta = new DocumentoVentaCabCE();
                    objOperacionVenta = new DocumentoVentaCabCN();

                    objEntidadVenta.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objOperacionVenta.F_DocumentoVentaCab_Retencion_Impresion(objEntidadVenta);

                    dtTabla.TableName = "Electronica";

                    rpt = new ReportDocument();
                    rpt.Load(Server.MapPath("rptObligacionesTributarias.rpt"));

                    rpt.SetDataSource(dtTabla);
                    rpt.Refresh();

                    rpt.SetDataSource(dtTabla);

                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    break;


                case 212:
                    //formago guia remision
                    TrasladosCabCE objEntidadTraslado = new TrasladosCabCE();
                    TrasladosCabCN objOperacionTraslado = new TrasladosCabCN();
                    objEntidadTraslado.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objOperacionTraslado.F_TrasladosCab_Impresion_Factura(objEntidadTraslado);
                    dtTabla.TableName = "Electronica";
                    rpt.Load(Server.MapPath("rptFormatoGuia.rpt"));
                    rpt.SetDataSource(dtTabla);

                    objEntidadTraslado = new TrasladosCabCE();
                    objOperacionTraslado = new TrasladosCabCN();

                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;

             

                case 2001: //NUEVA IMPRESION
                    //Parametros
                    CodDocumentoVenta = Convert.ToInt32(Request.QueryString["CodDocumentoVenta"]);
                    int CodTraslado = Convert.ToInt32(Request.QueryString["CodTraslado"]);
                    CodEmpresa = 3; // Convert.ToInt32(Session["CodSede"]);
                    CodSede = Convert.ToInt32(Request.QueryString["CodSede"]);
                    SerieDoc = Convert.ToString(Request.QueryString["SerieDoc"]);
                    CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    TipoImpresion = Convert.ToString(Request.QueryString["TipoImpresion"]);
                    bool EsElectronica = false; if (SerieDoc.Substring(0, 1) == "F" | SerieDoc.Substring(0, 1) == "B" | CodTipoDoc == 16) { EsElectronica = true; } else { SerieDoc = SerieDoc.Substring(0, 3); } SerieDoc = SerieDoc.Replace("-", "");
                    int NroCopiasFijo = 0;
                    try { NroCopiasFijo = Convert.ToInt32(Request.QueryString["NroCopias"]); } catch (Exception) { }

                    string copia1 = ""; string copia2 = "";

                    //Datos de la Factura
                    objEntidadFactura = new DocumentoVentaCabCE();
                    TrasladosCabCE objEntidadtraslado = new TrasladosCabCE();
                    objOperacionFactura22 = new DocumentoVentaCabCN();
                    objEntidadFactura.CodDocumentoVenta = CodDocumentoVenta;
                    objEntidadtraslado.CodTraslado = CodTraslado;
                    objEntidadtraslado.TipoImpresion = TipoImpresion;


                    //Si es un documento fistal
                    if (EsElectronica)
                    { //---------------------------------------------------------------------------------------------------
                        dtTabla = objOperacionFactura22.F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidadFactura);
                        OBJImpresion = new DocumentoVentaCabCN();

                        //Si tiene datos hace el resto del proceso
                        if (dtTabla.Rows.Count > 0)
                        {
                            dtTabla.Columns.Add("QR", typeof(byte[])); dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                            dtTabla.TableName = "Electronica";

                            qrcode = new BarCode();
                            qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode; qrcode.X = 6; qrcode.Y = 6; qrcode.LeftMargin = 6; qrcode.RightMargin = 6;
                            qrcode.TopMargin = 6; qrcode.BottomMargin = 6; qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                            foreach (DataRow dr in dtTabla.Rows)
                            {
                                string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] + "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                            }
                            copia1 = dtTabla.Rows[0]["COPIA1"].ToString(); copia2 = dtTabla.Rows[0]["COPIA2"].ToString();
                        }
                    }
                    else
                    { //-------------------------------------------------------------------------------------------------
                        dtTabla = objOperacionFactura22.F_DocumentoVentaCab_Impresion(objEntidadFactura);
                        dtTabla.TableName = "FacturaImpresion";
                    }


                    //Parametros de Impresion
                    dtPImpresion = objOperacionFactura22.F_DocumentoVentaCab_ImpresionConfiguracion(CodEmpresa, CodSede, SerieDoc,
                                                                                                            CodTipoDoc, TipoImpresion, CodDocumentoVenta);
                    FormatoRPT = dtPImpresion.Rows[0]["FormatoRPT"].ToString();
                    ImpresoraRPT = dtPImpresion.Rows[0]["Impresora"].ToString();
                    NroCopiasRPT = Convert.ToInt32(dtPImpresion.Rows[0]["NroCopias"].ToString());
                    string NombreArchivoDespacho = dtTabla.Rows[0]["NombreArchivoDespacho"].ToString();

                    //if (NombreArchivoDespacho != "")
                    //{
                    //    rpt2.Load(Server.MapPath(NombreArchivoDespacho));
                    //    rpt2.SetDataSource(dtTabla);
                    //    rpt2.PrintOptions.PrinterName = ImpresoraRPT;
                    //    rpt2.PrintToPrinter(1, true, 1, 1);
                    //}

                    //si se manda el parametro NroCopias desde el JS .. se tomara este.. si se envia 0, se toma 
                    //el que viene desde los Parametros de Impresion
                    if (NroCopiasFijo > 0)
                        NroCopiasRPT = NroCopiasFijo;

                    Margen = dtPImpresion.Rows[0]["Margen"].ToString();

                    rpt = new ReportDocument();
                    rpt.Load(Server.MapPath(FormatoRPT));

                    //TipoImpresion = "PDF";

                    switch (TipoImpresion)
                    {
                        case "PDF": //PDF
                            rpt.SetDataSource(dtTabla);
                            rpt.Refresh();
                            msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                            Response.BinaryWrite(msMemoria.ToArray());
                            break;
                        default:
                            if (NroCopiasRPT == 0) NroCopiasRPT = 1;
                            for (int i = 1; i <= NroCopiasRPT; i++)
                            {
                                rpt.SetDataSource(dtTabla);

                                if (EsElectronica)
                                {
                                    string ppagina = copia1; if (i == 2) ppagina = copia2;
                                    foreach (DataRow dr in dtTabla.Rows) { dr["PIE_PAGINA"] = ppagina; }
                                }
                                else
                                {
                                    MargenesBoleta = rpt.PrintOptions.PageMargins;
                                    MargenesBoleta.bottomMargin = 900;
                                }

                                rpt.Refresh();
                                rpt.PrintOptions.PrinterName = ImpresoraRPT;
                                rpt.PrintToPrinter(1, true, 1, 1);
                            }

                            if (dtTabla.Rows[0]["GuiaRemision"].ToString() != "")
                            {
                                if (dtTabla.Rows[0]["GuiaRemision"].ToString().Substring(0, 1) == "T")
                                {
                                   

                                    DataTable dtTablaGE = null;

                                    dtTablaGE = objTrasladosCabCN.F_TrasladosCab_Impresion(objEntidadtraslado);
                                    dtTablaGE.TableName = dtTablaGE.Rows[0]["Datatable"].ToString();
                                    dtTablaGE.Columns.Add("OR", typeof(byte[]));
                                    dtTablaGE.Columns.Add("QR", typeof(byte[]));

                                    qrcode = new BarCode();
                                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                                    qrcode.X = 6; qrcode.Y = 6;
                                    qrcode.LeftMargin = 6; 
                                    qrcode.RightMargin = 6;
                                    qrcode.TopMargin = 6; 
                                    qrcode.BottomMargin = 6; 
                                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                                  
                                    foreach (DataRow dr in dtTablaGE.Rows)
                                    {
                                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["OR"] = imageData;
                                    }
                                    foreach (DataRow dr in dtTablaGE.Rows)
                                    {
                                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                                    }

                                    rpt3.Load(Server.MapPath(dtTablaGE.Rows[0]["Archivo"].ToString()));
                                    rpt3.SetDataSource(dtTablaGE);
                                    rpt3.PrintOptions.PrinterName = dtTablaGE.Rows[0]["Impresora"].ToString();
                                    rpt3.PrintToPrinter(1, true, 1, 1);
                                }
                            }
                            break;
                            // rpt.SetDataSource(dtTabla);
                            //rpt.Refresh();
                            //msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                            //Response.Clear();
                            //Response.Buffer = true;
                            //Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                            //Response.BinaryWrite(msMemoria.ToArray());
                            //break;
                    }
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;

                case 2002: //NUEVA IMPRESION


                    dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request.QueryString["XmlDetalle"]);
                    dtTabla = null;
                    DocumentoVentaCabCN objOpeFactura = new DocumentoVentaCabCN();
                    foreach (dynamic item in jArr3)
                    {
                        CodDocumentoVenta = Convert.ToInt32(item.CodDocumentoVenta);
                        string Flag_Impresion = GetIP();
                        objOpeFactura.F_Factura_FlagImpresionServicio(CodDocumentoVenta, Flag_Impresion);
                    }

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    break;
                case 700:
                    Parametro.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();
                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Regenerar_VistaPreliminar(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 701:
                    Parametro.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Detalle(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 710:
                    Parametro.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Detalle_Efectivo(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 402:
                    Parametro.Value = Request.QueryString["SubTitulo"].ToString();
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
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 403:
                    Parametro.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodtipoCobranza = Convert.ToInt32(Request.QueryString["CodtipoCobranza"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);

                    dtTabla = objDocumentoVentaCabCN.F_Detracciones_REPORTE(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 400:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

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

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 408:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr5 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr5)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_COBRADOS_HASTA(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 401:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr6 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr6)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_Credito(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 410:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr7 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr7)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_Credito(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 703:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objNotaIngresoSalidaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;
                    NombreArchivo = dtTabla.Rows[0]["Formato"].ToString();
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;

                case 711:
                    Parametro.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    //objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    //objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    //objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.Codliquidacion = Convert.ToInt32(Request.QueryString["lblCodigo"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Detalle_liquidacion(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro.Value);
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