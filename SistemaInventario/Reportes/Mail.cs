using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using CapaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using KeepAutomation.Barcode.Crystal;
using System.Net.Mail;
using System.Text;

namespace SistemaInventario
{
    public class Mail
    {
        public void prEnvioCorreo(int CodDocumentoVenta, int CodTipoDoc, int CodAlmacen)
        {
            if (CodTipoDoc == 15)
                prEnvioCorreoProforma(CodDocumentoVenta, CodAlmacen);
            else
                prEnvioCorreoDocumentos(CodDocumentoVenta, CodAlmacen, CodTipoDoc);
        }


        private void prEnvioCorreoProforma(int CodProforma, int CodAlmacen)
        {
            List<CorreosDocumentosEnvios> lCorreos = (new DocumentoVentaCabCN()).F_CorreosDocumentosEnvios_Listar(0, CodProforma);

            if (lCorreos.Count > 0)
            {
                if (lCorreos[0].Email.Trim() != "[SIN CORREOS]")
                {
                    ProformaCabCE objEntidadProforma = new ProformaCabCE(); 
                    ProformaCabCN objOperacionProforma = new ProformaCabCN();
                    objEntidadProforma.CodProforma = CodProforma;

                    DataTable dtTabla = objOperacionProforma.F_ProformaCab_VistaPreliminar(objEntidadProforma);
                    dtTabla.TableName = "Electronica";

                    string SerieDoc = "001";
                    int CodTipoDoc = 15;
                    string TipoImpresion = "IMP";
                    DocumentoVentaCabCN objOperacionFactura22 = new DocumentoVentaCabCN();
                    DataTable dtPImpresion = objOperacionFactura22.F_DocumentoVentaCab_ImpresionConfiguracion(3, CodAlmacen, SerieDoc, CodTipoDoc, TipoImpresion, CodProforma);

                    ReportDocument rpt = new ReportDocument();

                    string rptFormato = dtPImpresion.Rows[0]["FormatoRPT"].ToString();
                    string vtas = "\\Ventas\\";
                    string rpts = "\\Reportes\\";
                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath(rptFormato).Replace(vtas, rpts));
                    rpt.SetDataSource(dtTabla);

                    MemoryStream msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                    string Archivo = fCrearArchivo(msMemoria, "CT", CodProforma);
                    bool Envio = EnvioCorreo(Archivo, 0, CodProforma, lCorreos, "COTIZACION");

                    objEntidadProforma = null;
                    objOperacionProforma = null;
                    dtTabla = null;
                    objOperacionFactura22 = null;
                    dtPImpresion = null;
                    rpt.Dispose();
                    rpt = null;
                }
            }
        }

        private void prEnvioCorreoDocumentos(int CodDocumentoVenta, int CodAlmacen, int CodTipoDoc)
        {
            List<CorreosDocumentosEnvios> lCorreos = (new DocumentoVentaCabCN()).F_CorreosDocumentosEnvios_Listar(CodDocumentoVenta, 0);

            if (lCorreos.Count > 0)
            {
                if (lCorreos[0].Email.Trim() != "[SIN CORREOS]")
                {
                    DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
                    DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
                    objEntidad.CodDocumentoVenta = CodDocumentoVenta;

                    DataTable dtTabla = objOperacion.F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidad);
                    //dtTabla.TableName = "Electronica";

                    string SerieDoc = "001";
                    string TipoImpresion = "IMP";
                    string TDoc = "";
                    string TipoDoc = "";
                    switch (CodTipoDoc) {
                        case 1:
                            TDoc = "FT";
                            TipoDoc = "FACTURA";
                        break;
                        case 2:
                        TDoc = "BO";
                        TipoDoc = "BOLETA";
                        break;
                        case 16:
                        TDoc = "NP";
                        TipoDoc = "NOTAPEDIDO";
                        break;

                    }
                    DocumentoVentaCabCN objOperacionFactura22 = new DocumentoVentaCabCN();
                    DataTable dtPImpresion = objOperacionFactura22.F_DocumentoVentaCab_ImpresionConfiguracion(3, CodAlmacen, SerieDoc, CodTipoDoc, TipoImpresion, CodDocumentoVenta);

                    ReportDocument rpt = new ReportDocument();

                    string rptFormato = dtPImpresion.Rows[0]["FormatoRPT"].ToString();
                    string vtas = "\\Ventas\\";
                    string rpts = "\\Reportes\\";
                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath(rptFormato).Replace(vtas, rpts));
                    rpt.SetDataSource(dtTabla);

                    MemoryStream msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                    string Archivo = fCrearArchivo(msMemoria, TDoc, CodDocumentoVenta);
                    bool Envio = EnvioCorreo(Archivo, 0, CodDocumentoVenta, lCorreos, TipoDoc);

                    objEntidad = null;
                    objOperacion = null;
                    dtTabla = null;
                    objOperacionFactura22 = null;
                    dtPImpresion = null;
                    rpt.Dispose();
                    rpt = null;
                }
            }
        }

        private string fCrearArchivo(MemoryStream msMemoria, string Tipo, int Codigo)
        {
            string NombrePDF = DateTime.Now.ToString("yyMMddhhmmss") + "_" + Tipo + "_" + Codigo.ToString() + ".pdf";
            string ruta_nombre = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + NombrePDF;
            try
            {
                using (FileStream file = new FileStream(ruta_nombre, FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytes = new byte[msMemoria.Length];
                    msMemoria.Read(bytes, 0, (int)msMemoria.Length);
                    file.Write(bytes, 0, bytes.Length);
                    msMemoria.Close();
                }
            }
            catch (Exception)
            {
                ruta_nombre = "";
            }
            return ruta_nombre;
        }

        private bool EnvioCorreo(string Archivo, int CodDocumentoVenta, int CodProforma, List<CorreosDocumentosEnvios> lCorreos, string TipoDocumento)
        {
            bool resultado = true;
            EmisorE emisor = new EmisorE();
            string idTransaccion = lCorreos[0].idTransaccion;
            FacturaBoletaElectronica objObjeto = new FacturaBoletaElectronica();
            Tsm_Parametros_General_FLT oFilter = new Tsm_Parametros_General_FLT();
            string CodigoArea = "0008";
            string nom_cliente = lCorreos[0].Cliente;
            string nro_identidad = lCorreos[0].NroRuc;
            string mon_total = lCorreos[0].Total;
            string fecha_emision = lCorreos[0].FechaEmision;
            string tipo_doc = lCorreos[0].TipoDoc;
            string nombre_empresa = lCorreos[0].Empresa;
            string nro_factura = lCorreos[0].Factura;

            emisor = new CapaDatos.EmisorCD().ObtenerEmisor(CodigoArea);

            oFilter.T_Codigo_Parametro = "007";
            var correoEmisor = objObjeto.F_Select_One_ParametrosGenerales(oFilter);
            oFilter.T_Codigo_Parametro = "008";
            var contraseñaEmisor = objObjeto.F_Select_One_ParametrosGenerales(oFilter);
            oFilter.T_Codigo_Parametro = "009";
            var Host = objObjeto.F_Select_One_ParametrosGenerales(oFilter);
            oFilter.T_Codigo_Parametro = "010";
            var Port = objObjeto.F_Select_One_ParametrosGenerales(oFilter);


            MailMessage mmsg = new MailMessage();
            foreach (CorreosDocumentosEnvios c in lCorreos) {
                mmsg.To.Add(c.Email);
            }

            //ASUNTO
            mmsg.Subject = "ASUNTO : " + TipoDocumento + " " + nombre_empresa;
            mmsg.SubjectEncoding = Encoding.UTF8;
            //CORREO AL CUAL PODEMOS ENVIARL EL MENSAJE COMO UNA COPIA.
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //OPCIONAL

            //CONTENIDO DEL MENSAJE
            nom_cliente = nom_cliente.Replace("EMPRESA.", "EMPRESA:");
            mmsg.Body = "<p><body style='margin: 0; padding: 0;'> <table align='center' border='0' cellpadding='0' cellspacing='0' width='800' style='border-collapse: collapse; font-family: Arial, sans-serif'> <tr>  <td align='center' style = 'display:none' >  <img src='https://s29.postimg.org/3wy9paj7b/cab.jpg' alt='Portada' width='800' height='160' style='display: block' /> </td>  </tr>  <tr>  <td bgcolor='#F2F2F2' style='padding: 40px 30px 40px 30px;'>  <table border='0' cellpadding='0' cellspacing='0' width='100%'>  <tr>  <td style='color: #153643; font-size: 24px; border-bottom: 1px solid #153643 '>  <b> SE HA EMITIDO UNA " + tipo_doc +  "!</b>  </td>  </tr> <tr style='text-align: justify'>  <td style='padding: 20px 0 10px 0; font-size: 15px'>  Estimado Cliente <br/> <font style='color:#444444; font-weight:bold'>" +
                        nom_cliente + "</font> <br/>  <font style='color:#444444; font-weight:bold'>RUC : " +
                        nro_identidad + "</font>  <br/><br/>  <font style='color:#0174DF; font-weight:bold'>GRACIAS POR SU PREFERENCIA</font> </td>  <td style = 'display:none'  >  <img src='https://s30.postimg.org/ggteixtq9/venta.png' alt='imagen' width='200' height='160' style='display: block'>  </td>  </tr>  </table>  <table style='padding-left:40px' border='0' cellpadding='0' cellspacing='0' width='50%'>  <tr>  <td style='color: #0174DF; font-size: 11px; width:100px;font-weight:bold'>  TIPO :   </td>  <td>  <font style='color:#444444'>" +
                        tipo_doc + "</font>  </td>  </tr>  <tr>  <td style='color: #0174DF ; font-size: 11px; font-weight:bold'>  NUMERO:  </td>  <td>  <font style='color:#444444'>" +
                        nro_factura + "</font>  </td>  </tr>  <tr>  <td style='color: #0174DF ; font-size: 11px; font-weight:bold'>  MONTO:  </td>  <td>  <font style='color:#444444'>" +
                        mon_total + "</font>  </td>  </tr>  <tr>  <td style='color: #0174DF ; font-size: 11px; font-weight:bold'>  FECHA EMISION:  </td>  <td>  <font style='color:#444444'>" +
                        fecha_emision + "</font>  </td>  </tr>  </table>  <table border='0' cellpadding='0' cellspacing='0' width='100%'>  <tr>  <td colspan='3' style='padding-top:15px; font-size: 11px;font-weight:bold'>  </td> <tr><td colspan='3' style='padding-top:15px; font-size: 11px;font-weight:bold'>  </td> </tr>  </tr>  </table>  </td>  </tr>  <tr>  <td bgcolor='#190707' style='padding: 30px 30px 0 30px; padding-top:10px'>  <table border='0'>  <tr>  <td style='color: #BDBDBD; font-size: 9px;'>  Disclaimer: Este e-mail es de inter&eacute;s solo para los individuos mencionados en el mismo.  Por lo anterior, no podr&aacute; distribuirse ni difundirse bajo ninguna circustancia.<br/>  Si Usted no es alguno de los destinatarios y este correo le ha llegado por equivocaci&oacute;n   se le pide borrarlo inmediatamente.  </td>   <tr>  <table>  </td>  </tr>  </table> </body></p>";
            //fecha_emision + "</font>  </td>  </tr>  </table>  <table border='0' cellpadding='0' cellspacing='0' width='100%'>  <tr>  <td colspan='3' style='padding-top:15px; font-size: 11px;font-weight:bold'> * Le adjuntamos la factura correspondiente a nuestro servicios en formato PDF   y tambien con el nuevo formato electr&oacute;nico.  </td>  </tr>  </table>  </td>  </tr>  <tr>  <td bgcolor='#190707' style='padding: 30px 30px 0 30px; padding-top:10px'>  <table border='0'>  <tr>  <td style='color: #BDBDBD; font-size: 9px;'>  Disclaimer: Este e-mail es de inter&eacute;s solo para los individuos mencionados en el mismo.  Por lo anterior, no podr&aacute; distribuirse ni difundirse bajo ninguna circustancia.<br/>  Si Usted no es alguno de los destinatarios y este correo le ha llegado por equivocaci&oacute;n   se le pide borrarlo inmediatamente.  </td>   <tr>  <table>  </td>  </tr>  </table> </body></p>";
            //fecha_emision + "</font>  </td>  </tr>  </table>  <table border='0' cellpadding='0' cellspacing='0' width='100%'>  <tr>  <td colspan='3' style='padding-top:15px; font-size: 11px;font-weight:bold'> * Le adjuntamos la factura correspondiente a nuestro servicios en formato PDF   y tambien con el nuevo formato electr&oacute;nico.  </td>  </tr>  </table>  </td>  </tr>  <tr>  <td bgcolor='#190707' style='padding: 30px 30px 0 30px; padding-top:10px'>  <table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-bottom: 1px solid #ffffff; padding-bottom:10px '>  <tr>  <td style='color: #ffffff; font-size: 14px;'>&reg Copyright SIGA, siglas SIGA 2017<br/>  <a href='#' style='color: #ffffff;'><font color='#ffffff'>Visite</font></a> to this newsletter instantly  </td>  <td align='right'>  <table border='0' cellpadding='0' cellspacing='0'>  <tr>  <td>  <a href='http://www.facebook.com/'>  <img src='http://www.iconsdb.com/icons/preview/gray/facebook-4-xxl.png' alt='Facebook' width='38' height='38' style='display: block;' border='0' />  </a>  </td>  <td style='font-size: 0; line-height: 0;' width='20'>&amp;nbsp;</td>  <td>  <a href='http://www.twitter.com/'>  <img src='http://www.caribbeanelections.com/images/newicons/twitter03.png' alt='Twitter' width='38' height='38' style='display: block;' border='0' />  </a>  </td>  <td style='font-size: 0; line-height: 0;' width='20'>&amp;nbsp;</td>  <td>  <a href='http://www.fconsulting.pe/'>  <img src='https://s23.postimg.org/kutnnvg5n/web.png' alt='Web' width='38' height='38' style='display: block;' border='0' />  </a>  </td>  </tr>  </table>  </td>  </tr>  </table>  <table border='0'>  <tr>  <td style='color: #BDBDBD; font-size: 9px;'>  Disclaimer: Este e-mail es de inter&eacute;s solo para los individuos mencionados en el mismo.  Por lo anterior, no podr&aacute; distribuirse ni difundirse bajo ninguna circustancia.<br/>  Si Usted no es alguno de los destinatarios y este correo le ha llegado por equivocaci&oacute;n   se le pide borrarlo inmediatamente.  </td>  <tr>  <table>  </td>  </tr>  </table> </body></p>";
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = true; //ENVIAR MENSAJE HTML : TRUE
            //CORREO DEL EMISOR
            //mmsg.From = new MailAddress(correoEmisor.T_Valor_Parametro);
            mmsg.From = new MailAddress(emisor.T_Correo);

            mmsg.Attachments.Add(new Attachment(Archivo));


            SmtpClient cliente = new SmtpClient();
            cliente.UseDefaultCredentials = false;
            if (emisor.T_SmtpHost.ToLower() == "smtp.gmail.com" | emisor.T_SmtpHost.ToLower() == "smtp.mail.yahoo.com")
                cliente.UseDefaultCredentials = true;

            string correo = emisor.T_Correo.Substring(emisor.T_Correo.LastIndexOf('@') + 1);

            // set up the Gmail server
            cliente.Host = emisor.T_SmtpHost;
            cliente.EnableSsl = true;

            cliente.Port = emisor.N_Puerto;
            cliente.Credentials = new System.Net.NetworkCredential(emisor.T_Correo.Trim(), emisor.T_Clave.Trim());

            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

            /*---ENVIAR CORREO---*/
            try
            {
                //ENVIAR CORREO y actualizar estado
                cliente.Send(mmsg);
                (new DocumentoVentaCabCN()).F_CorreosDocumentosEnvios_Actualizar(CodDocumentoVenta, CodProforma, idTransaccion, 1, "Enviado Correctamente");
            }
            catch (SmtpException ex)
            {
                (new DocumentoVentaCabCN()).F_CorreosDocumentosEnvios_Actualizar(CodDocumentoVenta, CodProforma, idTransaccion, 0, "Error al enviar: " + ex.Message.ToString());
            }

            return resultado;
        }



    }
}