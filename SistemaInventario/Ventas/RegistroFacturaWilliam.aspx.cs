using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Configuration;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;
using System.Net;
using System.Drawing;

namespace SistemaInventario.Ventas
{
    public partial class RegistroFacturaWilliam : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_VerUltimoPrecio_NET);
            CallbackManager.Register(F_PrecioMoneda_NET);
            CallbackManager.Register(F_ActualizarPrecio_Net);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_FacturacionOC_NET);
            CallbackManager.Register(F_Devolucion_NET);
            CallbackManager.Register(F_ImprimirFacturaTicket_NET);
            CallbackManager.Register(F_ListarEnviosCorreos_NET);
            CallbackManager.Register(F_ReenvioMail_NET);
            CallbackManager.Register(F_DocumentoVentaCab_ReenvioMail_Documentos_NET);
            CallbackManager.Register(F_ReenvioMailNP_NET);
            CallbackManager.Register(F_ActualizarDetalle_NET);
            CallbackManager.Register(F_FacturacionNV_NET);
            CallbackManager.Register(F_Inicializar_GrillaVacia_DetalleNV_NET);
            CallbackManager.Register(F_FacturacionCT_NET);
            CallbackManager.Register(F_Inicializar_GrillaVacia_DetalleCT_NET);
            CallbackManager.Register(F_Buscar_Responsables_NET);
            CallbackManager.Register(F_DatosFactura_NET);
            CallbackManager.Register(F_EdicionFactura_NET);
            CallbackManager.Register(F_ReenvioMail_Enviar_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_LlenarGridDetalle_Auditoria_NET);
            CallbackManager.Register(F_LlenarGridDetalle_Observacion_NET);
            CallbackManager.Register(F_ActualizarDetalle_CAMBIO_MONEDA_NET);
            CallbackManager.Register(F_ReemplazarFactura_NET);
            CallbackManager.Register(F_AgregarTemporalNP_NET);
            CallbackManager.Register(F_ProductoDetalle_NET);
            CallbackManager.Register(F_FacturarVale_NET);
            CallbackManager.Register(F_DireccionTemporal_NET);
            CallbackManager.Register(F_GrabarDireccionTemporal_NET);
            CallbackManager.Register(F_BuscarDireccionCotizacion_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia_Articulo();
            P_Inicializar_GrillaVacia_Detalle();
            P_Inicializar_GrillaVacia_Consulta();
            P_Inicializar_GrillaVacia_DetalleOC();
            P_Inicializar_GrillaVacia_DetalleGuia();
            P_Inicializar_GrillaVacia_PrecioMoneda();
            P_Inicializar_GrillaVacia_DetalleNV();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)(e.Row.FindControl("lblEstado"));
                if (lblEstado.Text == "PENDIENTE")
                    lblEstado.ForeColor = Color.Red;

                GridView grvDetalle = null;
                GridView grvDetalleAuditoria = null;
                GridView grvDetalleObservacion = null;
                HiddenField lblCodigo = null;
                HiddenField hfCodTipoDoc = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));
                lblCodigo = (HiddenField)(e.Row.FindControl("lblcodigo"));
                hfCodTipoDoc = (HiddenField)(e.Row.FindControl("hfCodTipoDoc"));


                ImageButton Eliminar = (ImageButton)(e.Row.FindControl("imgEliminarDocumento"));
                ImageButton Anular = (ImageButton)(e.Row.FindControl("imgAnularDocumento"));
                ImageButton Ticket = (ImageButton)(e.Row.FindControl("imgTCK"));
                ImageButton Imprimir = (ImageButton)(e.Row.FindControl("imgPdf"));
                ImageButton Pdf = (ImageButton)(e.Row.FindControl("imgPdf2"));
                ImageButton Mail = (ImageButton)(e.Row.FindControl("imgMail"));
                ImageButton Reemplazar = (ImageButton)(e.Row.FindControl("imgReemplazar"));

                try
                {
                    switch (Convert.ToString(hfCodTipoDoc.Value))
                    {
                        case "1":
                            Eliminar.Visible = true;
                            Anular.Visible = true;
                            Ticket.Visible = true;
                            Imprimir.Visible = true;
                            Pdf.Visible = true;
                            Mail.Visible = true;
                            Reemplazar.Visible = false;
                            break;
                        case "2":
                            Eliminar.Visible = true;
                            Anular.Visible = true;
                            Ticket.Visible = true;
                            Imprimir.Visible = true;
                            Pdf.Visible = true;
                            Mail.Visible = true;
                            Reemplazar.Visible = false;
                            break;
                        case "15":
                            Eliminar.Visible = false;
                            //Anular.Visible = false;
                            Ticket.Visible = false;
                            Imprimir.Visible = true;
                            Pdf.Visible = true;
                            Mail.Visible = false;
                            Reemplazar.Visible = true;
                            break;

                    }
                }
                catch (Exception exx) { }

                if (lblCodigo.Value != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                    dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                    dta_consultaarticulo.Columns.Add("Marca", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                    dta_consultaarticulo.Columns.Add("UM", typeof(string));
                    dta_consultaarticulo.Columns.Add("Precio", typeof(string));
                    dta_consultaarticulo.Columns.Add("Importe", typeof(string));
                    dta_consultaarticulo.Columns.Add("OV", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodMoneda", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();
                    dta_consultaarticulo.Columns.Add("Observacion", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                    grvDetalleObservacion.DataSource = dta_consultaarticulo;
                    grvDetalleObservacion.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                    grvDetalleAuditoria.DataSource = dta_consultaarticulo;
                    grvDetalleAuditoria.DataBind();
                }

            }
        }

        protected void grvConsultaNP_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)(e.Row.FindControl("lblEstado"));
                if (lblEstado.Text == "PENDIENTE")
                    lblEstado.ForeColor = Color.Red;

                GridView grvDetalle = null;
                HiddenField lblCodigo = null;
                HiddenField hfCodTipoDoc = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (HiddenField)(e.Row.FindControl("lblcodigo"));


                if (lblCodigo.Value != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();


                    DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                    DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                    objEntidad.CodDocumentoVenta = Convert.ToInt32(lblCodigo.Value);
                    grvDetalle.DataSource = objOperacion.F_DocumentoVentaDet_Listar_NP(objEntidad);
                    grvDetalle.DataBind();
                }

            }
        }

        protected void grvConsultaEnvioCorreos_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grvDetalle = null;
                HiddenField hfIdTransaccion = null;
                HiddenField hfCodTipoDoc = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                hfIdTransaccion = (HiddenField)(e.Row.FindControl("hfIdTransaccion"));


                if (hfIdTransaccion.Value != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();


                    DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                    DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                    objEntidad.IdTransaccion = Convert.ToInt64(hfIdTransaccion.Value);
                    grvDetalle.DataSource = objOperacion.F_CorreosDocumentosEnvios_ListarDet(objEntidad);
                    grvDetalle.DataBind();
                }

            }
        }


        protected void grvDetalleDireccionTemporal_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    try
                    {

                    }
                    catch (Exception exx) { }

                }
            }
            catch (Exception exx) { }
        }


        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_LlenarGridDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                //Consulta
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodDocumentoVenta = Convert.ToInt32(Codigo);
                objEntidad.CodTipoDoc = Convert.ToInt32(CodTipoDoc);
                grvDetalle.DataSource = objOperacion.F_DocumentoVentaDet_Listar(objEntidad);
                grvDetalle.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        public String F_LlenarGridDetalle_Auditoria_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalleAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleAuditoria");

                //Consulta
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodDocumentoVenta = Convert.ToInt32(Codigo);
                objEntidad.CodTipoDoc = Convert.ToInt32(CodTipoDoc);
                grvDetalleAuditoria.DataSource = objOperacion.F_CodDocumentoVenta_Auditoria(objEntidad);
                grvDetalleAuditoria.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleAuditoria);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        public String F_LlenarGridDetalle_Observacion_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalleObservacion = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleObservacion");

                //Consulta
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodDocumentoVenta = Convert.ToInt32(Codigo);
                objEntidad.CodTipoDoc = Convert.ToInt32(CodTipoDoc);
                grvDetalleObservacion.DataSource = objOperacion.F_DocumentoVentaDet_Observacion(objEntidad);
                grvDetalleObservacion.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleObservacion);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddl_serieguia_edicion_html = "";
            String str_ddl_moneda_html = "";
            String str_ddl_formapago_html = "";
            String str_ddl_formapago_edicion_html = "";
            String str_ddl_serieconsulta_html = "";
            String str_ddl_igv_html = "";
            String str_ddl_tipodoc_html = "";
            String str_ddl_tipodoc2_html = "";
            String str_ddlSerieNV_html = "";
            String str_ddlSerieCT_html = "";
            String str_numerofactura = "";
            String str_TipoImpresion = "";
            String str_direccion = "";
            String str_ddlVendedor_html = "";
            String str_ddl_TipoTransportista_html = "";
            String str_ddl_TipoTransportistaedicion_html = "";
            String str_ddl_CodUnidadpeso_html = "";
            String str_ddl_CodUnidadpesoEdicion_html = "";
            String str_ddl_EstadoConsultaNP_html = "";
            Int32 Usuario = 0;
            Int32 CodEmpleado = 0;
            decimal TC = 0;
            decimal TC_Paralelo = 0;
            decimal TC_ParaleloCompra = 0;
            int int_resultado_operacion = 0;

            //Parametros Formularios
            Int32 P_CANTIDADPLACAS = 0;
            Int32 P_MOSTRAR_UM_CONSULTAS = 0;
            Int32 P_REDONDEO_AM = 0;
            Int32 P_VALIDASTOCK = 1;
            Int32 P_FORMAPAGO = 1;
            Int32 P_KM = 0;

            Int32 P_IMPRESION_IMPRESORA = 1;
            Int32 P_IMPRESION_TICKETERA = 0;

            String str_ddlVendedorEdicion_html = "";

            Int32 P_EDITAR_PRECIOS = 0;

            Int32 P_FILTRA_SERVICIOS = 0;
            Int32 P_FILTRA_ACTIVOS = 0;


            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSerie, ref ddlSerieConsulta, ref ddlSerieGuia, ref ddlFormaPago, ref ddlMoneda, ref ddlIgv, ref str_direccion,
                                        ref ddlTipoDoc, ref ddlTipoDoc2, ref P_CANTIDADPLACAS, ref ddlSerieNV, ref ddlSerieCT, ref P_FORMAPAGO, ref ddlFormaPagoEdicion,
                                        ref P_MOSTRAR_UM_CONSULTAS, ref P_REDONDEO_AM, ref P_VALIDASTOCK, ref P_KM, ref P_IMPRESION_IMPRESORA, ref P_IMPRESION_TICKETERA,
                                        ref P_EDITAR_PRECIOS, ref P_FILTRA_SERVICIOS, ref P_FILTRA_ACTIVOS, ref ddlSerieGuiaEdicion, ref ddlVendedor, ref ddlVendedorEdicion, ref ddlTipoTransportista, ref ddlTipoTransportistaEdicion, ref ddlcodunidadpeso, ref ddlcodunidadpesoedicion, ref ddlEstadoConsultaNP);

                P_Obtener_TipoCambio(obj_parametros, ref TC, ref TC_Paralelo, ref TC_ParaleloCompra);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura, ref str_TipoImpresion);

                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_serieguia_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieGuia);
                str_ddl_serieguia_edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieGuiaEdicion);
                str_ddl_formapago_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPago);
                str_ddl_formapago_edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPagoEdicion);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);
                str_ddl_tipodoc_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDoc);
                str_ddl_tipodoc2_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDoc2);
                str_ddlSerieNV_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieNV);
                str_ddlSerieCT_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieCT);
                str_ddlVendedor_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
                str_ddlVendedorEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedorEdicion);
                str_ddl_TipoTransportista_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoTransportista);
                str_ddl_TipoTransportistaedicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoTransportistaEdicion);
                str_ddl_CodUnidadpeso_html = Mod_Utilitario.F_GetHtmlForControl(ddlcodunidadpeso);
                str_ddl_CodUnidadpesoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlcodunidadpesoedicion);
                str_ddl_EstadoConsultaNP_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoConsultaNP);


                Usuario = Convert.ToInt32(Session["CodUsuario"]);
                CodEmpleado = Convert.ToInt32(Session["CodEmpleado"]);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }


            try
            {
                if (P_MOSTRAR_UM_CONSULTAS == 0)
                    grvConsultaArticulo.Columns[9].Visible = false;
            }
            catch (Exception exxx)
            { }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //00
                str_mensaje_operacion + "~" + //01
                str_ddl_serie_html + "~" + //02
                str_ddl_serieguia_html + "~" + //03
                str_ddl_formapago_html + "~" + //04
                str_ddl_moneda_html + "~" + //05
                TC.ToString() + "~" + //06
                str_numerofactura + "~" + //07
                str_ddl_igv_html + "~" + //08
                str_ddl_serieconsulta_html + "~" + //09
                Usuario.ToString() + "~" + //10
                str_direccion + "~" + //11
                Session["CodSede"].ToString() + "~" + //12
                str_ddl_tipodoc_html + "~" + //13
                str_ddl_tipodoc2_html + "~" + //14
                P_CANTIDADPLACAS.ToString() + "~" + //15
                str_ddlSerieNV_html + "~" + //16
                str_ddlSerieCT_html + "~" + //17
                P_FORMAPAGO.ToString() + "~" + //18
                str_ddl_formapago_edicion_html + "~" + //19
                str_TipoImpresion + "~" +  //20
                P_MOSTRAR_UM_CONSULTAS + "~" +  //21
                P_REDONDEO_AM + "~" +  //22
                P_VALIDASTOCK + "~" + //23
                P_KM + "~" + //24
                TC_Paralelo + "~" + //25
                P_IMPRESION_IMPRESORA + "~" + //26
                P_IMPRESION_TICKETERA + "~" + //27
                P_EDITAR_PRECIOS + "~" +  //28
                P_FILTRA_SERVICIOS + "~" +  //29
                P_FILTRA_ACTIVOS + "~" + //30
                str_ddl_serieguia_edicion_html + "~" + //31
                TC_ParaleloCompra + "~" + //32
                str_ddlVendedor_html + "~" + //33
                CodEmpleado.ToString() + "~" + //34
                str_ddlVendedorEdicion_html + "~" + //35
                str_ddl_TipoTransportista_html + "~" +//36
                str_ddl_TipoTransportistaedicion_html + "~" +//37
                str_ddl_CodUnidadpeso_html + "~" +//38
                str_ddl_CodUnidadpesoEdicion_html + "~" +//39
                str_ddl_EstadoConsultaNP_html; //40

            return str_resultado;

        }

        public String F_Mostrar_Correlativo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numero = "";
            int int_resultado_operacion = 0;
            String str_TipoImpresion = "";
            Hashtable obj_parametros = null;
            Int32 NroItems = 0;
            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numero, ref str_TipoImpresion);
                P_Obtener_NroItems(obj_parametros, ref NroItems);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                str_numero + "~" + //2
                str_TipoImpresion + "~" + //3
                NroItems; //4


            return str_resultado;

        }

        public String F_Buscar_Productos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaArticulo_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Cargar_Grilla(obj_parametros, ref grvConsultaArticulo);
                if (grvConsultaArticulo.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Articulo();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";


                str_grvConsultaArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);


                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsultaArticulo_html;

            return str_resultado;

        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            String str_notapedido = "0";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref NotaPedido);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_EliminarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion, ref Codigo);

                int_resultado_operacion = 1;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                Codigo.ToString()
                + "~" +
                str_numerofactura;


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            String str_grvDetalleArticulo_html = "";
            String str_numeroguia = "";
            String str_TipoImpresion = "";

            int int_resultado_operacion = 1;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura, ref str_TipoImpresion);
                //P_Obtener_Correlativo(obj_parametros, ref str_numeroguia);
                P_LlenarGrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleArticulo_html
                + "~" +
                str_numerofactura
                + "~" +
                str_numeroguia
                + "~" +
                str_TipoImpresion;


            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Consulta();
                    str_mensaje_operacion = "No se encontraron registros";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_AnularRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AnularRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_CargarGrillaVaciaConsultaArticulo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsuArticulo_html = "";
            int int_resultado_operacion = 0;

            try
            {
                P_Inicializar_GrillaVacia_Articulo();

                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsuArticulo_html;


            return str_resultado;

        }

        public String F_TipoCambio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal TipoCambio = 0;
            Decimal TipoCambioParalelo = 0;
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio, ref TipoCambioParalelo);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                TipoCambio.ToString()
                + "~" +
                TipoCambioParalelo.ToString();


            return str_resultado;

        }

        public String F_VerUltimoPrecio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal Precio = 0;
            String Moneda = "";
            String Fecha = "";
            Decimal Cantidad = 0;
            String Modelo = "";
            String Motor = "";
            String Posicion = "";
            String Año = "";
            String Medida = "";

            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_VerUltimoPrecio(obj_parametros, ref Precio, ref Moneda, ref Fecha, ref Cantidad,
                    ref Modelo, ref Motor, ref Posicion, ref Año, ref Medida);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                Precio.ToString()
                + "~" +
                Moneda
                + "~" +
                Fecha
                + "~" +
                Cantidad.ToString()
                + "~" +
                Modelo
                + "~" +
                Motor
                + "~" +
                Posicion
                + "~" +
                Año.ToString()
                + "~" +
                Medida;


            return str_resultado;

        }

        public String F_ActualizarPrecio_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarPrecios(obj_parametros, ref str_mensaje_operacion);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_PrecioMoneda_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvPrecioMoneda_html = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_PrecioMoneda(obj_parametros, ref grvPrecioMoneda);
                if (grvPrecioMoneda.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_PrecioMoneda();

                str_grvPrecioMoneda_html = Mod_Utilitario.F_GetHtmlForControl(grvPrecioMoneda);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvPrecioMoneda_html;


            return str_resultado;

        }

        public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_FacturacionOC_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleOC_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionOC(obj_parametros, ref grvDetalleOC);

                if (grvDetalleOC.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleOC();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleOC);

                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleOC_html;

            return str_resultado;

        }

        public String F_Devolucion_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleOC_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Devolucion(obj_parametros, ref str_mensaje_operacion);
                P_FacturacionOC(obj_parametros, ref grvDetalleOC);

                if (grvDetalleOC.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleOC();
                    str_mensaje_operacion = "No se encontraron registros.";
                }



                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleOC);

                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleOC_html;

            return str_resultado;

        }

        public String F_FacturacionNV_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleNV_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Buscar_NP(obj_parametros, ref grvConsultaNP);

                if (grvConsultaNP.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleNV();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleNV_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaNP);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleNV_html;

            return str_resultado;
        }

        public string F_Inicializar_GrillaVacia_DetalleNV_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 1;
            String str_grvDetalleNV_html = "";
            Hashtable obj_parametros = null;

            try
            {
                //obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_FacturacionNV(obj_parametros, ref grvDetalleNV);

                //if (grvDetalleNV.Rows.Count == 0)
                //{
                P_Inicializar_GrillaVacia_DetalleNV();
                //    str_mensaje_operacion = "No se encontraron registros.";
                //}
                //else
                //    str_mensaje_operacion = "";

                str_grvDetalleNV_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaNP);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleNV_html;

            return str_resultado;
        }

        public String F_FacturacionCT_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleCT_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionCT(obj_parametros, ref grvDetalleCT);

                if (grvDetalleCT.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleCT();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleCT_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleCT);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleCT_html;

            return str_resultado;
        }

        public string F_Inicializar_GrillaVacia_DetalleCT_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 1;
            String str_grvDetalleCT_html = "";
            Hashtable obj_parametros = null;

            try
            {
                //obj_parametros = SistemaICTentario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_FacturacionCT(obj_parametros, ref grvDetalleCT);

                //if (grvDetalleCT.Rows.Count == 0)
                //{
                P_Inicializar_GrillaVacia_DetalleCT();
                //    str_mensaje_operacion = "No se encontraron registros.";
                //}
                //else
                //    str_mensaje_operacion = "";

                str_grvDetalleCT_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleCT);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleCT_html;

            return str_resultado;
        }

        public string F_Buscar_Responsables_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 1;
            String str_ddl_Responsables_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //F_Buscar_Responsables(obj_parametros, ref ddlResponsableNP);

                //str_ddl_Responsables_html = Mod_Utilitario.F_GetHtmlForControl(ddlResponsableNP);

                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_ddl_Responsables_html;

            return str_resultado;
        }

        public void F_Buscar_Responsables(Hashtable objTablaFiltro, ref DropDownList dll_Responsables)
        {

            ResponsablesCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new ResponsablesCE();

            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodEstado = 1;

            objOperacion = new TCCuentaCorrienteCN();

            dta_consulta = objOperacion.F_TCResponsables_Listar(objEntidad);

            dll_Responsables.Items.Clear();

            dll_Responsables.DataSource = dta_consulta;
            dll_Responsables.DataTextField = "DatosPersonales";
            dll_Responsables.DataValueField = "CodResponsable";
            dll_Responsables.DataBind();
        }

        public String F_DatosFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String Emision = "";
            String Vencimiento = "";
            Int32 FormaPago = 0;
            String Placa1 = "";
            String Placa2 = "";
            String Placa3 = "";
            String Placa4 = "";
            String Placa5 = "";
            String Placa6 = "";
            String Placa7 = "";
            String Placa8 = "";
            Int32 CodCtaCte = 0;
            String Kilometraje = "";
            Int32 CodTraslado = 0;
            String SerieGuia = "";
            String NumeroGuia = "";
            String Fecha = "";
            String Destino = "";
            String DireccionTrans = "";
            String DireccionFactura = "";
            Int32 CodTransportista = 0;
            Int32 CodDireccionTransportista = 0;
            String Transportista = "";
            String OrdenCompra = "";
            String Recepcion = "";
            String Observacion = "";
            Int32 FlagComisionable = 0;
            Int32 FlagMotorizado = 0;

            String PlacaTraslado = "";
            String MarcaVehiculo = "";
            String Licencia = "";
            String NroBultos = "";
            String Peso = "";
            String NroOperacion = "";
            String NumeroOC = "";
            String Requerimiento = "";
            //miguel-GUIA
            String NroConductor = "";
            String Conductor = "";
            Int32 CodConductor = 0;
            Int32 Serie = 0;
            String NombreAgencia = "";
            String GuiaAgencia = "";
            String ClaveAgencia = "";
            String DistritoTrans = "";
            Int32 CodVendedor = 0;
            String Responsable1 = "";
            String ResponsableDNI1 = "";
            String Responsable2 = "";
            String ResponsableDNI2 = "";
            int int_resultado_operacion = 0;
            String r = "";


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_DatosFactura(obj_parametros, ref Emision, ref Vencimiento, ref FormaPago, ref Placa1, ref Placa2, ref Placa3, ref Placa4,
                    ref CodCtaCte, ref Kilometraje, ref CodTraslado, ref SerieGuia, ref NumeroGuia, ref Fecha, ref Destino, ref DireccionTrans,
                    ref CodTransportista, ref Transportista, ref DireccionFactura, ref CodDireccionTransportista, ref OrdenCompra,
                    ref Recepcion, ref FlagComisionable,
                    ref PlacaTraslado, ref MarcaVehiculo, ref Licencia, ref NroBultos, ref Peso,
                    ref NroOperacion, ref NumeroOC, ref Requerimiento, ref Observacion, ref Placa5, ref Placa6, ref Placa7, ref Placa8,ref NroConductor, ref Conductor,
                    ref CodConductor, ref Serie, ref CodVendedor, ref NombreAgencia, ref GuiaAgencia, ref ClaveAgencia, ref DistritoTrans, ref FlagMotorizado,
                    ref Responsable1, ref ResponsableDNI1, ref Responsable2, ref ResponsableDNI2);


                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                Emision + "~" + //2
                Vencimiento + "~" + //3
                FormaPago.ToString() + "~" + //4
                Placa1 + "~" + //5
                Placa2 + "~" + //6
                Placa3 + "~" + //7
                Placa4 + "~" + //8
                CodCtaCte.ToString() + "~" + //9
                Kilometraje + "~" + //10
                CodTraslado + "~" + //11
                SerieGuia + "~" + //12
                NumeroGuia + "~" + //13
                Fecha + "~" + //14
                Destino + "~" + //15
                DireccionTrans + "~" + //16
                CodTransportista + "~" + //17
                Transportista + "~" + //18
                DireccionFactura + "~" + //19
                CodDireccionTransportista + "~" + //20
                OrdenCompra + "~" + //21
                Recepcion + "~" + //22
                FlagComisionable.ToString() + "~" + //23
                PlacaTraslado + "~" + //24
                MarcaVehiculo + "~" + //25
                Licencia + "~" + //26
                NroBultos + "~" + //27
                Peso + "~" + //28
                NroOperacion + "~" + //29
                NumeroOC + "~" + //30
                Requerimiento + "~" + //31
                Observacion + "~" + //32
                Placa5 + "~" + //33
                Placa6 + "~" + //34
                Placa7 + "~" + //35
               Placa8 + "~" +  //36
               //miguel - guia
                NroConductor.ToString() + "~" +//37
                Conductor.ToString() + "~" +//38
                CodConductor.ToString() + "~" +//39
                Serie + "~" + //40
                CodVendedor + "~" + //41
                NombreAgencia + "~" +//42
                GuiaAgencia + "~" + //43
                ClaveAgencia + "~" + //44
                DistritoTrans + "~" +//45
               FlagMotorizado + "~" +//46
               Responsable1 + "~" +//47
               ResponsableDNI1 + "~" +//48
               Responsable2 + "~" +//49
               ResponsableDNI2;//50

            return str_resultado;

        }

        public String F_EdicionFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            int CodTraslado = 0;
            Hashtable obj_parametros = null;
            String MsgError = "";

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EdicionFactura(obj_parametros, ref MsgError);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion   ;

            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combofactura, ref DropDownList ddl_combofacturaconsulta,
            ref DropDownList ddl_comboguia, ref DropDownList ddl_comboformapago, ref DropDownList ddl_combomoneda, ref DropDownList ddl_comboigv, ref String Direccion,
            ref DropDownList ddl_tipodoc, ref DropDownList ddl_tipodoc2, ref Int32 P_CANTIDADPLACAS,
            ref DropDownList ddl_comboserienv, ref DropDownList ddl_comboseriect, ref Int32 FormaPago, ref DropDownList ddl_formapagoEdicion,
            ref Int32 P_MOSTRAR_UM_CONSULTAS, ref Int32 P_REDONDEO_AM, ref Int32 P_VALIDASTOCK, ref Int32 P_KM, ref Int32 P_IMPRESION_IMPRESORA, ref Int32 P_IMPRESION_TICKETERA,
            ref Int32 P_EDITAR_PRECIOS, ref Int32 P_FILTRA_SERVICIOS, ref Int32 P_FILTRA_ACTIVOS,
            ref DropDownList ddl_comboguia_edicion, ref DropDownList ddl_CodVendedor, ref DropDownList ddl_VendedorEdicion, ref DropDownList ddl_TipoTransportista, ref DropDownList ddl_TipoTransportistaEdicion, ref DropDownList ddl_CodunidadPeso, ref DropDownList ddl_CodunidadPesoedicion, ref DropDownList ddl_EstadoConsultaNP)

        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;


            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.Estado = Convert.ToString(objTablaFiltro["Filtro_CodEstado"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofactura.Items.Clear();

            ddl_combofactura.DataSource = dta_consulta;
            ddl_combofactura.DataTextField = "SerieDoc";
            ddl_combofactura.DataValueField = "CodSerie";
            ddl_combofactura.DataBind();

            objEntidad.Estado = "";

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofacturaconsulta.Items.Clear();

            ddl_combofacturaconsulta.DataSource = dta_consulta;
            ddl_combofacturaconsulta.DataTextField = "SerieDoc";
            ddl_combofacturaconsulta.DataValueField = "CodSerie";
            ddl_combofacturaconsulta.DataBind();

            ddl_combofacturaconsulta.Items.Insert(0, new ListItem("TODOS", "0"));


            dta_consulta = null;
            objEntidad.CodDoc = 10;
            objEntidad.Estado = "A";
            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboguia.Items.Clear();
            ddl_comboguia.DataSource = dta_consulta;
            ddl_comboguia.DataTextField = "SerieDoc";
            ddl_comboguia.DataValueField = "CodSerie";
            ddl_comboguia.DataBind();

            ddl_comboguia_edicion.Items.Clear();
            ddl_comboguia_edicion.DataSource = dta_consulta;
            ddl_comboguia_edicion.DataTextField = "SerieDoc";
            ddl_comboguia_edicion.DataValueField = "CodSerie";
            ddl_comboguia_edicion.DataBind();


            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 4;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomoneda.Items.Clear();

            ddl_combomoneda.DataSource = dta_consulta;
            ddl_combomoneda.DataTextField = "DscAbvConcepto";
            ddl_combomoneda.DataValueField = "CodConcepto";
            ddl_combomoneda.DataBind();


            dta_consulta = null;
            objEntidadConceptosDet.CodConcepto = 5;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboformapago.Items.Clear();

            ddl_comboformapago.DataSource = dta_consulta;
            ddl_comboformapago.DataTextField = "DscAbvConcepto";
            ddl_comboformapago.DataValueField = "CodConcepto";
            ddl_comboformapago.DataBind();

            ddl_formapagoEdicion.Items.Clear();

            ddl_formapagoEdicion.DataSource = dta_consulta;
            ddl_formapagoEdicion.DataTextField = "DscAbvConcepto";
            ddl_formapagoEdicion.DataValueField = "CodConcepto";
            ddl_formapagoEdicion.DataBind();

            dta_consulta = null;
            objEntidadConceptosDet.CodConcepto = 35;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_CodunidadPeso.Items.Clear();

            ddl_CodunidadPeso.DataSource = dta_consulta;
            ddl_CodunidadPeso.DataTextField = "DscAbvConcepto";
            ddl_CodunidadPeso.DataValueField = "CodConcepto";
            ddl_CodunidadPeso.DataBind();

            ddl_CodunidadPesoedicion.Items.Clear();

            ddl_CodunidadPesoedicion.DataSource = dta_consulta;
            ddl_CodunidadPesoedicion.DataTextField = "DscAbvConcepto";
            ddl_CodunidadPesoedicion.DataValueField = "CodConcepto";
            ddl_CodunidadPesoedicion.DataBind();

            dta_consulta = null;
            objEntidadConceptosDet.CodConcepto = 16;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_EstadoConsultaNP.Items.Clear();

            ddl_EstadoConsultaNP.DataSource = dta_consulta;
            ddl_EstadoConsultaNP.DataTextField = "DscAbvConcepto";
            ddl_EstadoConsultaNP.DataValueField = "CodConcepto";
            ddl_EstadoConsultaNP.DataBind();


            ddl_EstadoConsultaNP.Items.Insert(0, new ListItem("TODOS", "0"));

            dta_consulta = null;
            TCTasasCE objEntidadTasa = new TCTasasCE();
            objEntidadTasa.CodTipoTasa = 1;
            objEntidadTasa.Estado = "";
            TCTasasCN objOperacionTasa = new TCTasasCN();
            dta_consulta = objOperacionTasa.F_TCTasas_ListarXTipoTasa(objEntidadTasa);

            ddl_comboigv.Items.Clear();

            ddl_comboigv.DataSource = dta_consulta;
            ddl_comboigv.DataTextField = "Valor";
            ddl_comboigv.DataValueField = "CodTasa";
            ddl_comboigv.DataBind();

            dta_consulta = null;

            TCAlmacenCE objEntidadAlmacen = new TCAlmacenCE();
            TCAlmacenCN objOperacionAlmacen = new TCAlmacenCN();

            objEntidadAlmacen.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            //dta_consulta = objOperacionAlmacen.F_DscDestinos_Listar(objEntidadAlmacen);

            //if (dta_consulta.Rows.Count > 0)
            //    Direccion = dta_consulta.Rows[0][0].ToString();
            //else
            Direccion = "";



            TCDocumentosCN objOperacionTCDocumentos = new TCDocumentosCN();
            TCDocumentosCE objEntidadTCDocumentos = new TCDocumentosCE();
            dta_consulta = objOperacionTCDocumentos.F_TCDocumentos_ListarFacturacion();
            ddlTipoDoc.Items.Clear();
            ddlTipoDoc.DataSource = dta_consulta;
            ddlTipoDoc.DataTextField = "Descripcion";
            ddlTipoDoc.DataValueField = "CodDoc";
            ddlTipoDoc.DataBind();

            ddlTipoDoc2.Items.Clear();
            ddlTipoDoc2.DataSource = dta_consulta;
            ddlTipoDoc2.DataTextField = "Descripcion";
            ddlTipoDoc2.DataValueField = "CodDoc";
            ddlTipoDoc2.DataBind();


            objEntidad.CodDoc = 16;
            objEntidad.Estado = "";
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserienv.Items.Clear();

            ddl_comboserienv.DataSource = dta_consulta;
            ddl_comboserienv.DataTextField = "SerieDoc";
            ddl_comboserienv.DataValueField = "CodSerie";
            ddl_comboserienv.DataBind();
            ddl_comboserienv.Items.Insert(0, new ListItem("TODOS", "0"));

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]); ;
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_Vendedor_listado(objEntidad);

            ddl_CodVendedor.Items.Clear();

            ddl_CodVendedor.DataSource = dta_consulta;
            ddl_CodVendedor.DataTextField = "Vendedor";
            ddl_CodVendedor.DataValueField = "CodVendedor";
            ddl_CodVendedor.DataBind();

            ddl_VendedorEdicion.Items.Clear();

            ddl_VendedorEdicion.DataSource = dta_consulta;
            ddl_VendedorEdicion.DataTextField = "Vendedor";
            ddl_VendedorEdicion.DataValueField = "CodVendedor";
            ddl_VendedorEdicion.DataBind();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]); ;
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TipoTransportista_listado(objEntidad);

            ddl_TipoTransportista.Items.Clear();

            ddl_TipoTransportista.DataSource = dta_consulta;
            ddl_TipoTransportista.DataTextField = "TIPOTRANSPORTISTA";
            ddl_TipoTransportista.DataValueField = "CodConcepto";
            ddl_TipoTransportista.DataBind();

            ddl_TipoTransportistaEdicion.Items.Clear();

            ddl_TipoTransportistaEdicion.DataSource = dta_consulta;
            ddl_TipoTransportistaEdicion.DataTextField = "TIPOTRANSPORTISTA";
            ddl_TipoTransportistaEdicion.DataValueField = "CodConcepto";
            ddl_TipoTransportistaEdicion.DataBind();



            objEntidad.CodDoc = 15;
            objEntidad.Estado = "";
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboseriect.Items.Clear();

            ddl_comboseriect.DataSource = dta_consulta;
            ddl_comboseriect.DataTextField = "SerieDoc";
            ddl_comboseriect.DataValueField = "CodSerie";
            ddl_comboseriect.DataBind();
            ddl_comboseriect.Items.Insert(0, new ListItem("TODOS", "0"));

            dta_consulta = (new TCEmpresaCN()).F_TCEmpresa_Listar(new TCEmpresaCE() { CodEmpresa = iCodEmpresa });
            try { P_CANTIDADPLACAS = (int)dta_consulta.Rows[0]["P_CANTIDADPLACAS"]; }
            catch (Exception exx) { P_CANTIDADPLACAS = 1; }
            try { FormaPago = (int)dta_consulta.Rows[0]["P_FormaPago"]; }
            catch (Exception exx) { FormaPago = 1; }
            try { P_MOSTRAR_UM_CONSULTAS = (int)dta_consulta.Rows[0]["P_MOSTRAR_UM_CONSULTAS"]; }
            catch (Exception exx) { P_MOSTRAR_UM_CONSULTAS = 0; }
            try { P_REDONDEO_AM = (int)dta_consulta.Rows[0]["P_REDONDEO_AM"]; }
            catch (Exception exx) { P_REDONDEO_AM = 1; }
            try { P_VALIDASTOCK = (int)dta_consulta.Rows[0]["P_VALIDASTOCK"]; }
            catch (Exception exx) { P_VALIDASTOCK = 1; }
            try { P_KM = (int)dta_consulta.Rows[0]["P_KM"]; }
            catch (Exception exx) { P_KM = 1; }
            try { P_IMPRESION_IMPRESORA = (int)dta_consulta.Rows[0]["P_IMPRESION_IMPRESORA"]; }
            catch (Exception exx) { P_IMPRESION_IMPRESORA = 1; }
            try { P_IMPRESION_TICKETERA = (int)dta_consulta.Rows[0]["P_IMPRESION_TICKED"]; }
            catch (Exception exx) { P_IMPRESION_TICKETERA = 1; }
            try { P_EDITAR_PRECIOS = (int)dta_consulta.Rows[0]["P_EDITAR_PRECIOS"]; }
            catch (Exception exx) { P_EDITAR_PRECIOS = 0; }
            try { P_FILTRA_SERVICIOS = (int)dta_consulta.Rows[0]["P_FILTRA_SERVICIOS"]; }
            catch (Exception exx) { P_FILTRA_SERVICIOS = 0; }
            try { P_FILTRA_ACTIVOS = (int)dta_consulta.Rows[0]["P_FILTRA_ACTIVOS"]; }
            catch (Exception exx) { P_FILTRA_ACTIVOS = 0; }
        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio, ref Decimal TipoCambioParalelo, ref Decimal TipoCambioParaleloCompra)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;

            //
            //int iCodEmpresa = 3;

            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);
                TipoCambioParalelo = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Paralelo"]);
                TipoCambioParaleloCompra = Convert.ToDecimal(dta_consulta.Rows[0]["TC_ParaleloCompra"]);
            }



        }

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero, ref String TipoImpPorDefecto)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);
            if (dta_consulta.Rows.Count > 0)
            {
                Numero = dta_consulta.Rows[0][0].ToString();
                TipoImpPorDefecto = dta_consulta.Rows[0][1].ToString();
            }
        }

        public void P_Obtener_NroItems(Hashtable objTablaFiltro, ref Int32 NroItems)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_NroItems(objEntidad);
            if (dta_consulta.Rows.Count > 0)
            {
                NroItems = Convert.ToInt32(dta_consulta.Rows[0]["NroItems"].ToString());
            }
        }

        public void P_Inicializar_GrillaVacia_Articulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("Chala1", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Chala2", typeof(string));
            dta_consultaarticulo.Columns.Add("PrecioSoles", typeof(string));
            dta_consultaarticulo.Columns.Add("PrecioDolares", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoCambio", typeof(string));
            dta_consultaarticulo.Columns.Add("Descuento", typeof(string));
            dta_consultaarticulo.Columns.Add("CodFamilia", typeof(string));
            dta_consultaarticulo.Columns.Add("CostoProductoSoles", typeof(string));
            dta_consultaarticulo.Columns.Add("CostoProductoDolares", typeof(string));
            dta_consultaarticulo.Columns.Add("Margen", typeof(string));
            dta_consultaarticulo.Columns.Add("MargenVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("DscProducto2", typeof(string));
            dta_consultaarticulo.Columns.Add("Ubicacion", typeof(string));
            dta_consultaarticulo.Columns.Add("UltimoPrecio", typeof(string));
            dta_consultaarticulo.Columns.Add("Medida", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("Redondeo", typeof(string));
            dta_consultaarticulo.Columns.Add("FactorRedondeo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoProducto", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";
            dtr_consultafila[6] = "";
            dtr_consultafila[7] = "";
            dtr_consultafila[8] = "";
            dtr_consultafila[9] = "";
            dtr_consultafila[10] = "";
            dtr_consultafila[11] = "";
            dtr_consultafila[12] = "";
            dtr_consultafila[13] = "";
            dtr_consultafila[14] = "";
            dtr_consultafila[15] = "";
            dtr_consultafila[16] = "";
            dtr_consultafila[17] = "";
            dtr_consultafila[18] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();


            //columnas invisibles
            try
            {
                //int iCodEmpresa = 3;
                //DataTable dta_consulta = (new TCEmpresaCN()).F_TCEmpresa_Listar(new TCEmpresaCE() { CodEmpresa = iCodEmpresa });
                //DataTable dta_talmacenes = (new TCAlmacenCN()).F_TCAlmacen_Listar_Todos(new TCAlmacenCE() { CodEmpresa = iCodEmpresa });
                //try
                //{
                //    //columna MEDIDA (5)
                //    if (Convert.ToInt32(dta_consulta.Rows[0]["P_MEDIDA"].ToString()) == 0)
                //        grvConsultaArticulo.Columns[6].Visible = false;
                //    //columna UM (8)
                //    if (Convert.ToInt32(dta_consulta.Rows[0]["P_MOSTRAR_UM_CONSULTAS"].ToString()) == 0)
                //        grvConsultaArticulo.Columns[9].Visible = false;

                //    //columnas de ALMACENES (6 y 7)
                //    try
                //    {
                //        try
                //        {
                //            try { grvConsultaArticulo.Columns[7].HeaderText = dta_talmacenes.Rows[1]["P_TITULO_VTAS"].ToString(); }
                //            catch (Exception) { }
                //            if (dta_talmacenes.Rows[1]["P_MOSTRAR_VTAS"].ToString() == "0")
                //            {
                //                grvConsultaArticulo.Columns[8].Visible = false;
                //            }
                //        }
                //        catch (Exception) { grvConsultaArticulo.Columns[8].Visible = false; }

                //        try
                //        {
                //            try { grvConsultaArticulo.Columns[7].HeaderText = dta_talmacenes.Rows[0]["P_TITULO_VTAS"].ToString(); }
                //            catch (Exception) { }
                //            if (dta_talmacenes.Rows[0]["P_MOSTRAR_VTAS"].ToString() == "0")
                //            {
                //                grvConsultaArticulo.Columns[7].Visible = false;
                //            }
                //        }
                //        catch (Exception) { }
                //    }
                //    catch (Exception exxxx) { }

                //}
                //catch (Exception ex)
                //{ }
            }
            catch (Exception exx)
            { }

        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Cliente", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Condicion", typeof(string));
            dta_consulta.Columns.Add("Vencimiento", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("TC", typeof(string));
            dta_consulta.Columns.Add("SubTotal", typeof(string));
            dta_consulta.Columns.Add("Igv", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("Guia", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("CodTraslado", typeof(string));
            dta_consulta.Columns.Add("Documento", typeof(string));
            dta_consulta.Columns.Add("Placa", typeof(string));
            dta_consulta.Columns.Add("EstatusSunat", typeof(string));
            dta_consulta.Columns.Add("CorreoSunat", typeof(string));
            dta_consulta.Columns.Add("CodTipoDoc", typeof(string));
            dta_consulta.Columns.Add("Anexo", typeof(string));
            dta_consulta.Columns.Add("CodGuia", typeof(string));
            dta_consulta.Columns.Add("CodMoneda", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("CodCtaCte", typeof(string));
            dta_consulta.Columns.Add("CODFORMAPAGO", typeof(string));



            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";
            dtr_filaconsulta[9] = "";
            dtr_filaconsulta[10] = "";
            dtr_filaconsulta[11] = "";
            dtr_filaconsulta[12] = "";
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";
            dtr_filaconsulta[15] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();


            //columnas invisibles
            int iCodEmpresa = 3;
            dta_consulta = (new TCEmpresaCN()).F_TCEmpresa_Listar(new TCEmpresaCE() { CodEmpresa = iCodEmpresa });
            try
            {
                //columna MEDIDA (6)
                if (Convert.ToInt32(dta_consulta.Rows[0]["P_IMPRESION_TICKED"].ToString()) == 0)
                    grvConsulta.Columns[5].Visible = false;
            }
            catch (Exception ex)
            { }

        }

        public void P_Inicializar_GrillaVacia_Detalle()
        {

            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("NroRow", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Costo", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalleOC", typeof(string));
            dta_consultadetalle.Columns.Add("Marca", typeof(string));
            dta_consultadetalle.Columns.Add("CostoDolares", typeof(string));
            dta_consultadetalle.Columns.Add("Margen", typeof(string));
            dta_consultadetalle.Columns.Add("Stock", typeof(string));
            dta_consultadetalle.Columns.Add("Redondeo", typeof(string));
            dta_consultadetalle.Columns.Add("FactorRedondeo", typeof(string));
            dta_consultadetalle.Columns.Add("CostoProductoSoles", typeof(string));
            dta_consultadetalle.Columns.Add("CostoProductoDolares", typeof(string));
            dta_consultadetalle.Columns.Add("Descuento", typeof(string));
            dta_consultadetalle.Columns.Add("CodMoneda", typeof(string));
            dta_consultadetalle.Columns.Add("Moneda", typeof(string));

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();

        }

        public void P_Inicializar_GrillaVacia_DetalleOC()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Producto", typeof(string));
            dta_consultadetalleoc.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleoc.Columns.Add("UM", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleoc.Columns.Add("Precio", typeof(string));
            dta_consultadetalleoc.Columns.Add("Numero", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleoc.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleoc.Columns.Add("Marca", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMoneda", typeof(string));
            dta_consultadetalleoc.Columns.Add("Moneda", typeof(string));


            dtr_filadetalle = dta_consultadetalleoc.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvDetalleOC.DataSource = dta_consultadetalleoc;
            grvDetalleOC.DataBind();

        }

        public void P_Inicializar_GrillaVacia_DetalleGuia()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Producto", typeof(string));
            dta_consultadetalleoc.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleoc.Columns.Add("UM", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleoc.Columns.Add("Precio", typeof(string));
            dta_consultadetalleoc.Columns.Add("Numero", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleoc.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleoc.Columns.Add("Almacen", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodDepartamento", typeof(string));
            dta_consultadetalleoc.Columns.Add("FechaEmision", typeof(string));
            dta_consultadetalleoc.Columns.Add("Marca", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMoneda", typeof(string));
            dta_consultadetalleoc.Columns.Add("Moneda", typeof(string));

            dtr_filadetalle = dta_consultadetalleoc.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvFacturacionGuia.DataSource = dta_consultadetalleoc;
            grvFacturacionGuia.DataBind();

        }

        public void P_Inicializar_GrillaVacia_PrecioMoneda()
        {
            DataTable dta_consultapreciomoneda = null;
            DataRow dtr_filadetalle = null;

            dta_consultapreciomoneda = new DataTable();

            dta_consultapreciomoneda.Columns.Add("CodProducto", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio1", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio2", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio3", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Moneda", typeof(string));

            dtr_filadetalle = dta_consultapreciomoneda.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";

            dta_consultapreciomoneda.Rows.Add(dtr_filadetalle);

            grvPrecioMoneda.DataSource = dta_consultapreciomoneda;
            grvPrecioMoneda.DataBind();

        }

        public void P_Inicializar_GrillaVacia_DetalleNV()
        {
            DataTable dta_consultadetallenv = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetallenv = new DataTable();

            dta_consultadetallenv.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetallenv.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetallenv.Columns.Add("Codigo", typeof(string));
            dta_consultadetallenv.Columns.Add("Producto", typeof(string));
            dta_consultadetallenv.Columns.Add("Cantidad", typeof(string));
            dta_consultadetallenv.Columns.Add("UM", typeof(string));
            dta_consultadetallenv.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetallenv.Columns.Add("Precio", typeof(string));
            dta_consultadetallenv.Columns.Add("Numero", typeof(string));
            dta_consultadetallenv.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetallenv.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetallenv.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetallenv.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetallenv.Columns.Add("Fecha", typeof(string));
            dta_consultadetallenv.Columns.Add("Cliente", typeof(string));
            dta_consultadetallenv.Columns.Add("Acuenta", typeof(string));
            dta_consultadetallenv.Columns.Add("Importe", typeof(string));
            dta_consultadetallenv.Columns.Add("FechaAnexo", typeof(string));
            dta_consultadetallenv.Columns.Add("Marca", typeof(string));
            dta_consultadetallenv.Columns.Add("CodCtaCte", typeof(string));
            dta_consultadetallenv.Columns.Add("NroRuc", typeof(string));
            dta_consultadetallenv.Columns.Add("CodMoneda", typeof(string));
            dta_consultadetallenv.Columns.Add("Moneda", typeof(string));

            dta_consultadetallenv.Columns.Add("Emision", typeof(string));
            dta_consultadetallenv.Columns.Add("Condicion", typeof(string));
            dta_consultadetallenv.Columns.Add("TC", typeof(string));
            dta_consultadetallenv.Columns.Add("Total", typeof(string));
            dta_consultadetallenv.Columns.Add("Estado", typeof(string));

            dtr_filadetalle = dta_consultadetallenv.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";
            dtr_filadetalle[16] = "";
            dtr_filadetalle[17] = "";

            dta_consultadetallenv.Rows.Add(dtr_filadetalle);

            grvConsultaNP.DataSource = dta_consultadetallenv;
            grvConsultaNP.DataBind();
        }

        public void P_Inicializar_GrillaVacia_DetalleCT()
        {
            DataTable dta_consultadetalleCT = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleCT = new DataTable();

            dta_consultadetalleCT.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleCT.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleCT.Columns.Add("Producto", typeof(string));
            dta_consultadetalleCT.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleCT.Columns.Add("UM", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleCT.Columns.Add("Precio", typeof(string));
            dta_consultadetalleCT.Columns.Add("Numero", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleCT.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleCT.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleCT.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleCT.Columns.Add("Fecha", typeof(string));
            dta_consultadetalleCT.Columns.Add("Cliente", typeof(string));
            dta_consultadetalleCT.Columns.Add("Acuenta", typeof(string));
            dta_consultadetalleCT.Columns.Add("Importe", typeof(string));
            dta_consultadetalleCT.Columns.Add("FechaAnexo", typeof(string));
            dta_consultadetalleCT.Columns.Add("Marca", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodCtaCte", typeof(string));
            dta_consultadetalleCT.Columns.Add("NroRuc", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodMoneda", typeof(string));
            dta_consultadetalleCT.Columns.Add("Moneda", typeof(string));


            dtr_filadetalle = dta_consultadetalleCT.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";
            dtr_filadetalle[16] = "";
            dtr_filadetalle[17] = "";

            dta_consultadetalleCT.Rows.Add(dtr_filadetalle);

            grvDetalleCT.DataSource = dta_consultadetalleCT;
            grvDetalleCT.DataBind();
        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objOperacion = new LGProductosCN();

            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoProducto"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.CodFamilia = Convert.ToString(objTablaFiltro["Filtro_CodFamilia"]);
            objEntidad.Ubicacion = Convert.ToString(objTablaFiltro["Filtro_Ubicacion"]);
            objEntidad.FlagProductosConStock = Convert.ToInt32(objTablaFiltro["Filtro_FlagProductosConStock"]);

            grvConsulta.DataSource = objOperacion.F_LGProductos_ListarVentas_Descuento(objEntidad);
            grvConsulta.DataBind();


        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";


            int iCodEmpresa = 3;


            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]); ;

            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);

            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);

            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"])) + "'";
                XmlDetalle = XmlDetalle + " PrecioDscto = '" + item.Precio / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"])) + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CodUm = '" + item.CodUm + "'";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " OC = '" + item.OC + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + item.CodTipoDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaCabCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalFacturacionDet_Insert(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalFacturacionDetalle_Insert(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }
            MsgError = objEntidad.MsgError;

        }

        public void P_EliminarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaDetCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
            ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Int32 NotaPedido)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objOperacion = new DocumentoVentaCabCN();


            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
                objEntidad.Tasa = Convert.ToDecimal(objTablaFiltro["Filtro_Tasa"]);
                objEntidad.CodDocumentoVenta = Codigo;

                dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                if (Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 1)
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        if (Convert.ToDecimal(dta_consulta.Rows[j]["CodTipoProducto"]) == 1)
                            TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }

                }
                else
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {

                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }
                }

                SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();

            try { NotaPedido = Convert.ToInt32(dta_consulta.Rows[0]["NotaPedido"]); }
            catch (Exception exxx) { NotaPedido = 0; };
        }

        public void P_ACTUALIZAR_MONTO_MONEDA(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_ACTUALIZAR_MONTO_MONEDA(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            int iCodEmpresa = 3;

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);

            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);

            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
        
            objEntidad.CodTipoCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoCliente"]);
            objEntidad.CodClaseCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodClaseCliente"]);
            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);

            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.ApePaterno = Convert.ToString(objTablaFiltro["Filtro_ApePaterno"]);
            objEntidad.ApeMaterno = Convert.ToString(objTablaFiltro["Filtro_ApeMaterno"]);
            objEntidad.Nombres = Convert.ToString(objTablaFiltro["Filtro_Nombres"]);

            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.NroDni = Convert.ToString(objTablaFiltro["Filtro_NroDni"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.Destino = Convert.ToString(objTablaFiltro["Filtro_Destino"]);

            objEntidad.FlagIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.Placa2 = Convert.ToString(objTablaFiltro["Filtro_Placa2"]);
            objEntidad.Placa3 = Convert.ToString(objTablaFiltro["Filtro_Placa3"]);
            objEntidad.Placa4 = Convert.ToString(objTablaFiltro["Filtro_Placa4"]);
            objEntidad.Placa5 = Convert.ToString(objTablaFiltro["Filtro_Placa5"]);
            objEntidad.Placa6 = Convert.ToString(objTablaFiltro["Filtro_Placa6"]);
            objEntidad.Placa7 = Convert.ToString(objTablaFiltro["Filtro_Placa7"]);
            objEntidad.Placa8 = Convert.ToString(objTablaFiltro["Filtro_Placa8"]);
            objEntidad.Cliente = Convert.ToString(objTablaFiltro["Filtro_Cliente"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);

            objEntidad.CodDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodDetalle"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.Partida = Convert.ToString(objTablaFiltro["Filtro_Partida"]);
            objEntidad.DireccionCompleta = Convert.ToString(objTablaFiltro["Filtro_DireccionCompleta"]);

            objEntidad.FlagRetencion = Convert.ToInt32(objTablaFiltro["Filtro_FlagRetencion"]);
            objEntidad.FlagLetra = Convert.ToInt32(objTablaFiltro["Filtro_FlagLetra"]);
            objEntidad.NotaPedido = Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]);
            objEntidad.TasaIgv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);

            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);

            objEntidad.KM = Convert.ToString(objTablaFiltro["Filtro_KM"]);
            objEntidad.Correo = Convert.ToString(objTablaFiltro["Filtro_Correo"]);

            objEntidad.Email1 = Convert.ToString(objTablaFiltro["Filtro_Email1"]);
            objEntidad.Email2 = Convert.ToString(objTablaFiltro["Filtro_Email2"]);
            objEntidad.Email3 = Convert.ToString(objTablaFiltro["Filtro_Email3"]);
            objEntidad.Email4 = Convert.ToString(objTablaFiltro["Filtro_Email4"]);
            objEntidad.Email5 = Convert.ToString(objTablaFiltro["Filtro_Email5"]);
            objEntidad.Email6 = Convert.ToString(objTablaFiltro["Filtro_Email6"]);

            objEntidad.NroOC = Convert.ToString(objTablaFiltro["Filtro_NumeroOC"]);
            objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodVendedor"]);

            objEntidad.CodFactura_Anterior = Convert.ToInt32(objTablaFiltro["Filtro_CodFacturaAnterior"]);
            objEntidad.Codtipodoctemporal = Convert.ToInt32(objTablaFiltro["Filtro_Codtipodoctemporal"]);

            objEntidad.Requerimiento = Convert.ToString(objTablaFiltro["Filtro_Requerimiento"]);
            objEntidad.Celular = Convert.ToString(objTablaFiltro["Filtro_Celular"]);
            objEntidad.CodDocumentoVentaDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVentaDireccion"]);

            /////transportista
            /////
            //objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);
            //objEntidad.FlagGuia = Convert.ToInt32(objTablaFiltro["Filtro_FlagGuia"]);
            //objEntidad.SerieGuia = Convert.ToString(objTablaFiltro["Filtro_SerieGuia"]);

            //objEntidad.NumeroGuia = Convert.ToString(objTablaFiltro["Filtro_NumeroGuia"]);
            //objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaTraslado"]);
            //objEntidad.Transportista = Convert.ToString(objTablaFiltro["Filtro_Transportista"]);
            objEntidad.Marca = Convert.ToString(objTablaFiltro["Filtro_Marca"]);
            objEntidad.Licencia = Convert.ToString(objTablaFiltro["Filtro_Licencia"]);
            objEntidad.NuBultos = Convert.ToString(objTablaFiltro["Filtro_NuBultos"]);
            //objEntidad.Peso = Convert.ToString(objTablaFiltro["Filtro_Peso"]);
            //objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);
            //objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            //objEntidad.DireccionTrans = Convert.ToString(objTablaFiltro["Filtro_DireccionTrans"]);
            //objEntidad.PlacaTraslado = Convert.ToString(objTablaFiltro["Filtro_PlacaTraslado"]);
            //objEntidad.NroRucTransportista = Convert.ToString(objTablaFiltro["Filtro_NroRucTransportista"]);
            //objEntidad.CodDepartamentoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamentoTransportista"]);
            //objEntidad.CodProvinciaTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodProvinciaTransportista"]);
            //objEntidad.CodDistritoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDistritoTransportista"]);
            //objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            //objEntidad.CodConductor = Convert.ToInt32(objTablaFiltro["Filtro_CodConductor"]);
            //objEntidad.CodtipoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_TipoTransportista"]);
            //objEntidad.CodUnidadPeso = Convert.ToInt32(objTablaFiltro["Filtro_codunidadpeso"]);

            // INICIO DATOS DE LA GUIA
            objEntidad.Transportista = Convert.ToString(objTablaFiltro["Filtro_Transportista"]);
            objEntidad.FlagGuia = Convert.ToInt32(objTablaFiltro["Filtro_FlagGuia"]);
            objEntidad.SerieGuia = Convert.ToString(objTablaFiltro["Filtro_SerieGuia"]);
            objEntidad.NumeroGuia = Convert.ToString(objTablaFiltro["Filtro_NumeroGuia"]);
            objEntidad.CodTipoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoTransportista"]);
            objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaTraslado"]);
            objEntidad.CodDocumentoVentaDireccionDestino = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVentaDireccionDestino"]);
            objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);
            objEntidad.CodDocumentoVentaDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVentaDireccionTransportista"]);
            objEntidad.NroRucTransportista = Convert.ToString(objTablaFiltro["Filtro_RucTransportista"]);
            objEntidad.RazonSocialTransportista = Convert.ToString(objTablaFiltro["Filtro_RazonSocialTransportista"]);
            objEntidad.PlacaTraslado = Convert.ToString(objTablaFiltro["Filtro_PlacaTraslado"]);
            objEntidad.MarcaVehiculo = Convert.ToString(objTablaFiltro["Filtro_MarcaVehiculo"]);
            objEntidad.Licencia = Convert.ToString(objTablaFiltro["Filtro_Licencia"]);
            objEntidad.NroBultos = Convert.ToInt32(objTablaFiltro["Filtro_NroBultos"]);
            objEntidad.Peso = Convert.ToDecimal(objTablaFiltro["Filtro_Peso"]);
            objEntidad.CodUnidadPeso = Convert.ToInt32(objTablaFiltro["Filtro_CodUnidadPeso"]);
            objEntidad.CodConductor = Convert.ToInt32(objTablaFiltro["Filtro_CodConductor"]);
            objEntidad.ObservacionGuia = Convert.ToString(objTablaFiltro["Filtro_ObservacionGuia"]);

            // FIN DATOS DE LA GUIA


            objOperacion = new DocumentoVentaCabCN();

            //Inserts por tipos de documentos
            switch (objEntidad.CodTipoDoc)
            {
                case 15: //Cotizacion
                    ProformaCabCE objEntidadProforma = new ProformaCabCE();
                    ProformaCabCN objOperacionProforma = new ProformaCabCN();
                    objEntidadProforma.CodSede = Convert.ToInt32(Session["CodSede"]);
                    objEntidadProforma.CodEmpresa = iCodEmpresa;
                    objEntidadProforma.CodCtaCte = objEntidad.CodCliente;
                    objEntidadProforma.Serie = objEntidad.SerieDoc;
                    objEntidadProforma.Numero = objEntidad.NumeroDoc;
                    objEntidadProforma.FechaEmision = objEntidad.FechaEmision;
                    objEntidadProforma.CodMoneda = objEntidad.CodMoneda;
                    objEntidadProforma.CodEstado = objEntidad.CodEstado;
                    objEntidadProforma.Vencimiento = objEntidad.FechaVencimiento;
                    objEntidadProforma.Observacion = objEntidad.Observacion;
                    objEntidadProforma.SubTotal = objEntidad.SubTotal;
                    objEntidadProforma.Igv = objEntidad.Igv;
                    objEntidadProforma.Total = objEntidad.Total;
                    objEntidadProforma.TipoCambio = objEntidad.TipoCambio;
                    objEntidadProforma.CodUsuario = objEntidad.CodUsuario;
                    objEntidadProforma.CodDetalle = objEntidad.CodDetalle;
                    objEntidadProforma.CodDoc = 15;
                    objEntidadProforma.Referencia = Convert.ToString(objTablaFiltro["Filtro_Referencia"]);
                    objEntidadProforma.Atencion = Convert.ToString(objTablaFiltro["Filtro_Atencion"]);
                    objEntidadProforma.Observacion = "";
                    objEntidadProforma.CodTasa = objEntidad.CodTasa;
                    objEntidadProforma.Placa = objEntidad.Placa;
                    objEntidadProforma.Placa2 = objEntidad.Placa2;
                    objEntidadProforma.Placa3 = objEntidad.Placa3;
                    objEntidadProforma.Placa4 = objEntidad.Placa4;
                    objEntidadProforma.CodFormaPago = objEntidad.CodFormaPago;
                    objEntidadProforma.Observacion = objEntidad.Observacion;
                    objEntidadProforma.Cliente = objEntidad.Cliente;
                    objEntidadProforma.RazonSocial = objEntidad.RazonSocial;
                    objEntidadProforma.NroRuc = objEntidad.NroRuc;
                    objEntidadProforma.NroDni = objEntidad.NroDni;
                    objEntidadProforma.Correo = objEntidad.Correo;
                    objEntidadProforma.CodDireccion = objEntidad.CodDireccion;
                    objEntidadProforma.Direccion = objEntidad.Direccion;
                    objEntidadProforma.CodDepartamento = objEntidad.CodDepartamento;
                    objEntidadProforma.CodProvincia = objEntidad.CodProvincia;
                    objEntidadProforma.CodDistrito = objEntidad.CodDistrito;
                    objEntidadProforma.CodVendedor = objEntidad.CodVendedor;
                    objEntidadProforma.Email1 = objEntidad.Email1;
                    objEntidadProforma.Email2 = objEntidad.Email2;
                    objEntidadProforma.Email3 = objEntidad.Email3;
                    objEntidadProforma.Email4 = objEntidad.Email4;
                    objEntidadProforma.Email5 = objEntidad.Email5;
                    objEntidadProforma.Email6 = objEntidad.Email6;
                    objEntidadProforma.Requerimiento = objEntidad.Requerimiento;
                    objEntidadProforma.CodDocumentoVentaDireccion = objEntidad.CodDocumentoVentaDireccion;
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);     


                    if (objEntidad.CodFactura_Anterior > 0)
                    {
                        objEntidadProforma.NumeroAnterior = objEntidad.NumeroDoc;
                        objEntidadProforma.CodFactura_Anterior = objEntidad.CodFactura_Anterior;
                        objOperacionProforma.F_Proformas_Insert_Edicion_William(objEntidadProforma);
                    }
                    else
                    {
                        objOperacionProforma.F_Proformas_Insert_William(objEntidadProforma);
                    }              

                    MsgError = objEntidadProforma.MsgError; Codigo = objEntidadProforma.Codigo;

                    if (MsgError == "Se Grabo Correctamente")
                    {
                        if (Convert.ToInt32(objTablaFiltro["Filtro_EnviarEmailsInmediato"]) == 1)
                        {
                            Mail x = new Mail();
                            x.prEnvioCorreo(Codigo, 15, Convert.ToInt32(Session["CodSede"]));
                            x = null;
                        }
                    }

                    break;
                case 16: //Nota de Pedido
                    objEntidad.CodResponsable = Convert.ToInt32(objTablaFiltro["Filtro_CodResponsable"]);
                    objEntidad.Responsable2 = Convert.ToString(objTablaFiltro["Filtro_Responsable2"]);
                    objEntidad.Responsable2DNI = Convert.ToString(objTablaFiltro["Filtro_Responsable2DNI"]);
                    objEntidad.CodResponsable = Convert.ToInt32(objTablaFiltro["Filtro_CodResponsable"]);
                    objEntidad.Responsable = Convert.ToString(objTablaFiltro["Filtro_Responsable1"]);
                    objEntidad.ResponsableDNI = Convert.ToString(objTablaFiltro["Filtro_Responsable1DNI"]);

                    objOperacion.F_DocumentoVentaCab_Insert_NP_OC_William(objEntidad);
                    MsgError = objEntidad.MsgError; Codigo = objEntidad.CodDocumentoVenta;


                    if (MsgError == "Se Grabo Correctamente")
                    {
                        if (Convert.ToInt32(objTablaFiltro["Filtro_EnviarEmailsInmediato"]) == 1)
                        {
                            Mail x = new Mail();
                            x.prEnvioCorreo(Codigo, 16, Convert.ToInt32(Session["CodSede"]));
                            x = null;
                        }
                    }


                    break;
                default: //Facturas y Boletas
                    if (objEntidad.NotaPedido == 0) //Insert Normal
                        
                    if (objEntidad.CodFactura_Anterior > 0)
                    {

                        objOperacion.F_DocumentoVentaCab_Insert_Edicion_William(objEntidad);
                    }
                    else
                    {
                        objOperacion.F_DocumentoVentaCab_Insert_William(objEntidad);
                    }  
                       
                    else //Insert con NOTAPEDIDO NOTA VENTA, COTIZACION
                        objOperacion.F_DocumentoVentaCab_Insert_Factura_NV_William(objEntidad);

                    MsgError = objEntidad.MsgError; Codigo = objEntidad.CodDocumentoVenta;
                    break;
            }

        }

        public void P_LlenarGrillaVacia_Detalle()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("NroRow", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalleOC", typeof(string));
            dta_consultadetalle.Columns.Add("Marca", typeof(string));
            dta_consultadetalle.Columns.Add("Costo", typeof(string));
            dta_consultadetalle.Columns.Add("CostoDolares", typeof(string));
            dta_consultadetalle.Columns.Add("Margen", typeof(string));
            dta_consultadetalle.Columns.Add("CostoProductoSoles", typeof(string));
            dta_consultadetalle.Columns.Add("CostoProductoDolares", typeof(string));
            dta_consultadetalle.Columns.Add("Redondeo", typeof(string));
            dta_consultadetalle.Columns.Add("FactorRedondeo", typeof(string));
            dta_consultadetalle.Columns.Add("Descuento", typeof(string));
            dta_consultadetalle.Columns.Add("CodMoneda", typeof(string));
            dta_consultadetalle.Columns.Add("Moneda", typeof(string));

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.NumeroDoc = "";

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            }
            else
            {
                objEntidad.Desde = Convert.ToDateTime("01/01/1990");
                objEntidad.Hasta = Convert.ToDateTime("01/01/1990");
            }


            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkCliente"]) == 1)
                objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCliente = 0;

            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.Estado = Convert.ToString(objTablaFiltro["Filtro_Estado"]);
            objEntidad.EstadoNP = Convert.ToInt32(objTablaFiltro["Filtro_EstadoNP"]);
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkProducto"]) == 1)
                objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            else
                objEntidad.CodProducto = 0;

            //objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);


            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_DocumentoVentaCab_Listar_William(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_Buscar_NP(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.NumeroDoc = "";

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            }
            else
            {
                objEntidad.Desde = Convert.ToDateTime("01/01/1990");
                objEntidad.Hasta = Convert.ToDateTime("01/01/1990");
            }


            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkCliente"]) == 1)
                objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCliente = 0;

            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);

            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);


            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_DocumentoVentaCab_Listar_NP_William(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            int CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            if (CodTipoDoc != 15)
            {
                DocumentoVentaCabCE objEntidad = null;
                DocumentoVentaCabCN objOperacion = null;

                objEntidad = new DocumentoVentaCabCE();

                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
                objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
                objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
                objEntidad.ObservacionAnulacion = Convert.ToString(objTablaFiltro["Filtro_ObservacionAnulacion"]);

                objOperacion = new DocumentoVentaCabCN();

                objOperacion.F_DocumentoVentaCab_Anulacion(objEntidad);

                Mensaje = objEntidad.MsgError;
            }
            else
            {

                ProformaCabCE objEntidad = null;
                ProformaCabCN objOperacion = null;

                objEntidad = new ProformaCabCE();


                objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);

                objOperacion = new ProformaCabCN();

                objOperacion.F_Proformas_Anulacion(objEntidad);

                Mensaje = objEntidad.MsgError;

            }




        }


        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC, ref Decimal TCParalelo)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
            {
                TC = 0;
                TCParalelo = 0;
            }
            else
            {
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);
                TCParalelo = Convert.ToDecimal(dta_consulta.Rows[0][1]);
            }


        }

        public void P_VerUltimoPrecio(Hashtable objTablaFiltro, ref Decimal UltimoPrecio, ref String UltimaMoneda, ref String UltimaFecha, ref Decimal UltimaCantidad,
            ref String Modelo, ref String Motor, ref String Posicion, ref String Año, ref String Medida)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new LGProductosCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_LGProductos_UltimoPrecio(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                UltimoPrecio = Convert.ToDecimal(dta_consulta.Rows[0]["Precio"]);
                UltimaMoneda = Convert.ToString(dta_consulta.Rows[0]["Moneda"]);
                UltimaFecha = Convert.ToString(dta_consulta.Rows[0]["Fecha"]);
                UltimaCantidad = Convert.ToDecimal(dta_consulta.Rows[0]["Cantidad"]);

                Modelo = Convert.ToString(dta_consulta.Rows[0]["Modelo"]);
                Motor = Convert.ToString(dta_consulta.Rows[0]["Motor"]);
                Posicion = Convert.ToString(dta_consulta.Rows[0]["Posicion"]);
                Año = Convert.ToString(dta_consulta.Rows[0]["Año"]);
                Medida = Convert.ToString(dta_consulta.Rows[0]["Medida"]);
            }



        }

        public void P_DatosFactura(Hashtable objTablaFiltro, ref String Emision, ref String Vencimiento,
                                    ref Int32 FormaPago, ref String Placa1, ref String Placa2, ref String Placa3, ref String Placa4,
                                    ref Int32 CodCtaCte, ref String Kilometraje,
                                    ref Int32 CodTraslado, ref String SerieGuia, ref String NumeroGuia, ref String Fecha,
                                    ref String Destino, ref String DireccionTrans, ref Int32 CodTransportista, ref String Transportista,
                                    ref String DireccionFactura, ref Int32 CodDireccionTransportista,
                                    ref String OrdenCompra, ref String Recepcion, ref Int32 FlagComisionable,
                                    ref String PlacaTraslado, ref String MarcaVehiculo, ref String Licencia, ref String NroBultos, ref String Peso,
                                    ref String NroOperacion, ref String NumeroOC, ref string Requerimiento, ref string Observacion, ref String Placa5,
            ref String Placa6, ref String Placa7, ref String Placa8, ref String NroConductor, ref String Conductor,
                             ref Int32 CodConductor, ref Int32 Serie, ref Int32 CodVendedor, ref String NombreAgencia, ref String GuiaAgencia, ref String ClaveAgencia,
            ref String DistritoTrans, ref Int32 FlagMotorizado, ref String Responsable1, ref String ResponsableDNI1, ref String Responsable2, ref String ResponsableDNI2)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoventa"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);


            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_Datos(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                Emision = Convert.ToString(dta_consulta.Rows[0]["FechaEmision"]);
                Vencimiento = Convert.ToString(dta_consulta.Rows[0]["FechaVencimiento"]);
                FormaPago = Convert.ToInt32(dta_consulta.Rows[0]["CodFormaPago"]);
                Placa1 = Convert.ToString(dta_consulta.Rows[0]["Placa"]);
                Placa2 = Convert.ToString(dta_consulta.Rows[0]["Placa2"]);
                Placa3 = Convert.ToString(dta_consulta.Rows[0]["Placa3"]);
                Placa4 = Convert.ToString(dta_consulta.Rows[0]["Placa4"]);
                Placa5= Convert.ToString(dta_consulta.Rows[0]["Placa5"]);
                Placa6 = Convert.ToString(dta_consulta.Rows[0]["Placa6"]);
                Placa7 = Convert.ToString(dta_consulta.Rows[0]["Placa7"]);
                Placa8 = Convert.ToString(dta_consulta.Rows[0]["Placa8"]);
                CodCtaCte = Convert.ToInt32(dta_consulta.Rows[0]["CodCtaCte"]);
                Kilometraje = Convert.ToString(dta_consulta.Rows[0]["Kilometraje"]);
                //guial - guia
                CodVendedor = Convert.ToInt32(dta_consulta.Rows[0]["CodEmpleado"]);
                NombreAgencia = Convert.ToString(dta_consulta.Rows[0]["NombreAgencia"]);
                GuiaAgencia = Convert.ToString(dta_consulta.Rows[0]["GuiaAgencia"]);
                ClaveAgencia = Convert.ToString(dta_consulta.Rows[0]["ClaveAgencia"]);

                DireccionFactura = Convert.ToString(dta_consulta.Rows[0]["DireccionFactura"]);
                OrdenCompra = Convert.ToString(dta_consulta.Rows[0]["OrdenCompra"]);
                Recepcion = Convert.ToString(dta_consulta.Rows[0]["Recepcion"]);
                FlagComisionable = Convert.ToInt32(dta_consulta.Rows[0]["FlagComisionable"]);
                FlagMotorizado = Convert.ToInt32(dta_consulta.Rows[0]["FlagMotorizado"]);
                Observacion = Convert.ToString(dta_consulta.Rows[0]["Observacion"]);
                Responsable1 = Convert.ToString(dta_consulta.Rows[0]["Responsable1"]);
                ResponsableDNI1 = Convert.ToString(dta_consulta.Rows[0]["ResponsableDNI1"]);
                Responsable2 = Convert.ToString(dta_consulta.Rows[0]["Responsable2"]);
                ResponsableDNI2 = Convert.ToString(dta_consulta.Rows[0]["ResponsableDNI2"]);

                try
                {
                    try { CodTraslado = Convert.ToInt32(dta_consulta.Rows[0]["CodTraslado"]); }
                    catch (Exception) { }

                    SerieGuia = Convert.ToString(dta_consulta.Rows[0]["SerieDoc"]);
                    NumeroGuia = Convert.ToString(dta_consulta.Rows[0]["NumeroDoc"]);
                    Fecha = Convert.ToString(dta_consulta.Rows[0]["Fecha"]);
                    Destino = Convert.ToString(dta_consulta.Rows[0]["Destino"]);
                    try { DireccionTrans = Convert.ToString(dta_consulta.Rows[0]["DireccionTransportista"]); }
                    catch (Exception) { }
                    try { CodTransportista = Convert.ToInt32(dta_consulta.Rows[0]["CodTransportista"]); }
                    catch (Exception) { }
                    try { CodDireccionTransportista = Convert.ToInt32(dta_consulta.Rows[0]["CodDireccionTrans"]); }
                    catch (Exception) { }
                    try { Transportista = Convert.ToString(dta_consulta.Rows[0]["Transportista"]); }
                    catch (Exception) { }
                    
                    try { PlacaTraslado = Convert.ToString(dta_consulta.Rows[0]["PlacaTraslado"]); }
                    catch (Exception) { }
                    try { MarcaVehiculo = Convert.ToString(dta_consulta.Rows[0]["MarcaVehiculo"]); }
                    catch (Exception) { }
                    try { Licencia = Convert.ToString(dta_consulta.Rows[0]["Licencia"]); }
                    catch (Exception) { }
                    try { NroBultos = Convert.ToString(dta_consulta.Rows[0]["NroBultos"]); }
                    catch (Exception) { }
                    try { Peso = Convert.ToString(dta_consulta.Rows[0]["Peso"]); }
                    catch (Exception) { }

                    try { NroOperacion = Convert.ToString(dta_consulta.Rows[0]["NroOperacion"]); }
                    catch (Exception) { }
                    try { NumeroOC = Convert.ToString(dta_consulta.Rows[0]["NumeroOC"]); }
                    catch (Exception) { }
                    try { Requerimiento = Convert.ToString(dta_consulta.Rows[0]["Requerimiento"]); }
                    catch (Exception) { }
                    try { CodConductor = Convert.ToInt32(dta_consulta.Rows[0]["CodConductor"]); }
                    catch (Exception) { }
                    try { Conductor = Convert.ToString(dta_consulta.Rows[0]["Conductor"]); }
                    catch (Exception) { }
                    try { NroConductor = Convert.ToString(dta_consulta.Rows[0]["NroConductor"]); }
                    catch (Exception) { }
                    try { DistritoTrans = Convert.ToString(dta_consulta.Rows[0]["DistritoTrans"]); }
                    catch (Exception) { }
                }
                catch (Exception exxx)
                { }
            }
        }

        public void P_ActualizarPrecios(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Precio = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]); ;
            objEntidad.Cantidad = Convert.ToDecimal(objTablaFiltro["Filtro_Cantidad"]); ;

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_PrecioMoneda(Hashtable objTablaFiltro, ref GridView grillaPrecioMoneda)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new LGProductosCN();

            grillaPrecioMoneda.DataSource = objOperacion.F_LGProductos_VerPrecio_Moneda(objEntidad);
            grillaPrecioMoneda.DataBind();

        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_Eliminacion(objEntidad);

            Mensaje = objEntidad.MsgError;



        }

        public void P_FacturacionOC(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_OCXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }

        public void P_Devolucion(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaCabCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " CodUndMedida = '" + item.CodUndMedida + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CostoUnitario = '" + item.CostoUnitario + "'";
                XmlDetalle = XmlDetalle + " SerieDoc = '" + item.SerieDoc + "'";
                XmlDetalle = XmlDetalle + " NumeroDoc = '" + item.NumeroDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objEntidad.CodEmpresa = 3;
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.TasaIgv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodTipoOperacion = 1;

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_DevolucionOC(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public String F_ImprimirFacturaTicket_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_json_factura = P_ImprimirFacturaTicket(obj_parametros, ref str_mensaje_operacion);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_json_factura;


            return str_resultado;

        }

        public string P_ImprimirFacturaTicket(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidadFactura.IP = GetIP().Trim();
            DataTable dtTabla = objOperacionFactura.F_DocumentoVentaCab_ImpresionFlagTicket_Insert(objEntidadFactura);

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dtTabla);
            return JSONresult;
        }

        public void P_FacturacionNV(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_NVXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }

        public void P_FacturacionCT(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_CTXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }



        public String F_ListarEnviosCorreos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            String str_grvConsulta_html = "";
            String str_ConsultaCorreos_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                F_ListarEnviosCorreos(obj_parametros, ref grvConsultaEnvioCorreos);
                F_ListarCorreos(obj_parametros, ref grvConsultaCorreos);
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaEnvioCorreos);
                str_ConsultaCorreos_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaCorreos);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grvConsulta_html + "~" +
                str_ConsultaCorreos_html;


            return str_resultado;

        }


        public String F_ReenvioMail_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_mensaje_operacion = F_ReenvioMail(obj_parametros, ref str_mensaje_operacion);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion;


            return str_resultado;

        }

        public String F_DocumentoVentaCab_ReenvioMail_Documentos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_mensaje_operacion = F_DocumentoVentaCab_ReenvioMail_Documentos(obj_parametros, ref str_mensaje_operacion);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion;


            return str_resultado;

        }


        public void F_ListarEnviosCorreos(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);


            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_CorreosDocumentosEnvios_ListarCab(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }


        public string F_ReenvioMail(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidadFactura = objOperacionFactura.F_DocumentoVentaCab_ReenvioMail(objEntidadFactura);

            Mensaje = objEntidadFactura.MsgError;

            return Mensaje;
        }

        public string F_DocumentoVentaCab_ReenvioMail_Documentos(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();
            Mail x = new Mail();
            String XmlDetalle = "";


            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidadFactura.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidadFactura.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidadFactura.CodUsuario = Convert.ToInt32(Session["CodUsuario"].ToString());


            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " Orden = '" + item.Orden + "'";
                XmlDetalle = XmlDetalle + " Correo = '" + item.Correo + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidadFactura.XmlDetalle = XmlDetalle;


            objEntidadFactura = objOperacionFactura.F_DocumentoVentaCab_ReenvioMail_Documentos(objEntidadFactura);

            

            //Inserts por tipos de documentos
            switch (objEntidadFactura.CodTipoDoc)
            {
                case 15: //Cotizacion
                    x.prEnvioCorreo(objEntidadFactura.CodProforma, 15, Convert.ToInt32(Session["CodSede"]));
                    objEntidadFactura.MsgError = "SE HIZO EL ENVIO DE LA COTIZACION";
                    break;
                case 16: //Nota de Pedido
                    x.prEnvioCorreo(objEntidadFactura.CodDocumentoVenta, 16, Convert.ToInt32(Session["CodSede"]));
                    objEntidadFactura.MsgError = "SE HIZO EL ENVIO DE LA NOTA DE VENTA";
                    break;
                default: //Facturas y Boletas
                    break;
            }

            x = null;

            Mensaje = objEntidadFactura.MsgError;

            return Mensaje;
        }

        public String F_ReenvioMailNP_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;
            string Responsable = "";
            string Factura = "";
            string Correo1 = "";
            string Correo2 = "";
            string Correo3 = "";
            string Correo4 = "";
            string Correo5 = "";
            string Correo6 = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ReenvioMail(obj_parametros, ref Responsable, ref Factura, ref Correo1, ref Correo2, ref Correo3, ref Correo4, ref Correo5, ref Correo6);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                Responsable
                + "~" +
                Factura
                + "~" +
                Correo1
                + "~" +
                Correo2
                + "~" +
                Correo3
                + "~" +
                Correo4
                + "~" +
                Correo5
                + "~" +
                Correo6;


            return str_resultado;

        }

        public void P_ReenvioMail(Hashtable objTablaFiltro, ref string Responsable, ref string Factura, ref string Correo1, ref string Correo2, ref string Correo3, ref  string Correo4, ref  string Correo5, ref string Correo6)
        {
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();
            DataTable dta_Res = objOperacionFactura.F_CorreosFacturasCotizaciones(Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]));
            Responsable = Convert.ToString(dta_Res.Rows[0]["ResponsableNombre"]);
            Factura = Convert.ToString(dta_Res.Rows[0]["Factura"]);
            Correo1 = Convert.ToString(dta_Res.Rows[0]["Correo1"]);
            Correo2 = Convert.ToString(dta_Res.Rows[0]["Correo2"]);
            Correo3 = Convert.ToString(dta_Res.Rows[0]["Correo3"]);
            Correo4 = Convert.ToString(dta_Res.Rows[0]["Correo4"]);
            Correo5 = Convert.ToString(dta_Res.Rows[0]["Correo5"]);
            Correo6 = Convert.ToString(dta_Res.Rows[0]["Correo6"]);
        }

        public String F_ReenvioMail_Enviar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_mensaje_operacion = F_ReenvioMail_Enviar(obj_parametros, ref str_mensaje_operacion);
                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion;


            return str_resultado;

        }

        public string F_ReenvioMail_Enviar(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);

            if (Convert.ToString(objTablaFiltro["Filtro_Correo1"]).Trim() != "")
                objEntidadFactura.Correos += ";" + Convert.ToString(objTablaFiltro["Filtro_Correo1"]).Trim();
            if (Convert.ToString(objTablaFiltro["Filtro_Correo2"]).Trim() != "")
                objEntidadFactura.Correos += ";" + Convert.ToString(objTablaFiltro["Filtro_Correo2"]).Trim();
            if (Convert.ToString(objTablaFiltro["Filtro_Correo3"]).Trim() != "")
                objEntidadFactura.Correos += ";" + Convert.ToString(objTablaFiltro["Filtro_Correo3"]).Trim();
            if (Convert.ToString(objTablaFiltro["Filtro_Correo4"]).Trim() != "")
                objEntidadFactura.Correos += ";" + Convert.ToString(objTablaFiltro["Filtro_Correo4"]).Trim();
            if (Convert.ToString(objTablaFiltro["Filtro_Correo5"]).Trim() != "")
                objEntidadFactura.Correos += ";" + Convert.ToString(objTablaFiltro["Filtro_Correo5"]).Trim();
            if (Convert.ToString(objTablaFiltro["Filtro_Correo6"]).Trim() != "")
                objEntidadFactura.Correos += ";" + Convert.ToString(objTablaFiltro["Filtro_Correo6"]).Trim();

            objEntidadFactura.CodTipoDoc = 15;
            objEntidadFactura = objOperacionFactura.F_DocumentoVentaCab_ReenvioMail(objEntidadFactura);

            Mensaje = objEntidadFactura.MsgError;

            return Mensaje;
        }

        public String F_ActualizarDetalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                Codigo = Convert.ToInt32(Convert.ToDecimal(obj_parametros["Filtro_CodigoTemporal"]));
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref NotaPedido);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_ActualizarDetalle_CAMBIO_MONEDA_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ACTUALIZAR_MONTO_MONEDA(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(Convert.ToDecimal(obj_parametros["Filtro_CodigoTemporal"]));
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref NotaPedido);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

                int_resultado_operacion = 1;
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_ReemplazarFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;

            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal AcuentaNV = 0;
            Decimal Dscto = 0;

            Decimal Total2 = 0;
            Decimal SubTotal2 = 0;
            Decimal Igv2 = 0;
            Decimal AcuentaNV2 = 0;
            Decimal Dscto2 = 0;

            int NotaPedido = 0;

            Hashtable obj_parametros = null;
            String str_ddl_serie_html = "";
            string JSONDocumentoVentaCab = "";
            DocumentoVentaCabCE objReemplazo = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_ValidarFactura(obj_parametros, ref str_mensaje_operacion);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarFactura(obj_parametros,
                                        ref ddlSerie, ref objReemplazo);

                    decimal stotalo = 0; decimal igvo = 0; decimal totalo = 0; //se le ponen estas para que no sume demas ya que los montos se llenan arriba
                    P_CargarGrillaTemporal(obj_parametros, objReemplazo.Codigo, ref grvDetalleArticulo, ref stotalo, ref igvo, ref totalo, ref NotaPedido);

                    if (Math.Round(Total, 2) == Math.Round(Total2, 2))
                    {
                        objReemplazo.FlagIgv = 1;
                    }

                    str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                    str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);


                    JSONDocumentoVentaCab = JsonConvert.SerializeObject(objReemplazo);

                    int_resultado_operacion = 1;
                }
                else
                    int_resultado_operacion = 0;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                str_grvDetalleArticulo_html + "~" + //2
                str_ddl_serie_html + "~" +  //3
                JSONDocumentoVentaCab; //4

            return str_resultado;
        }

        public String F_AgregarTemporalNP_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";

            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal AcuentaNV = 0;
            Decimal Dscto = 0;

            Decimal Total2 = 0;
            Decimal SubTotal2 = 0;
            Decimal Igv2 = 0;
            Decimal AcuentaNV2 = 0;
            Decimal Dscto2 = 0;

            int NotaPedido = 0;

            Hashtable obj_parametros = null;
            String str_ddl_serie_html = "";
            string JSONDocumentoVentaCab = "";
            DocumentoVentaCabCE objReemplazo = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                if (str_mensaje_operacion == "")
                {
                    F_AgregarTemporalNP(obj_parametros, ref objReemplazo);

                    P_CargarGrillaTemporal(obj_parametros, objReemplazo.Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref NotaPedido);
                    objReemplazo.SubTotal = Math.Round(SubTotal, 2);
                    objReemplazo.Igv = Math.Round(Igv, 2);
                    objReemplazo.Total = Math.Round(Total, 2);
                    objReemplazo.NotaPedido = NotaPedido;


                    if (Math.Round(Total, 2) == Math.Round(Total2, 2))
                    {
                        objReemplazo.FlagIgv = 1;
                    }

                    str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                    str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);


                    JSONDocumentoVentaCab = JsonConvert.SerializeObject(objReemplazo);

                    int_resultado_operacion = 1;
                }
                else
                    int_resultado_operacion = 0;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                str_grvDetalleArticulo_html + "~" + //2
                str_ddl_serie_html + "~" +  //3
                JSONDocumentoVentaCab; //4

            return str_resultado;
        }

        public String F_ProductoDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalle = (GridView)grvConsultaArticulo.Rows[0].FindControl("grvDetalleProducto");

                LGProductosCE objEntidad = null;
                LGProductosCN objOperacion = null;

                objEntidad = new LGProductosCE();

                objEntidad.CodProducto = Codigo;
                objOperacion = new LGProductosCN();
                DataTable dt = objOperacion.F_ProductoModelo_Listado(objEntidad);
                if (dt.Rows.Count > 0)
                {
                    grvDetalle.DataSource = dt;
                    grvDetalle.DataBind();
                }
                else
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Linea", typeof(string));
                    dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Año", typeof(string));
                    dta_consultaarticulo.Columns.Add("Motor", typeof(string));
                    dta_consultaarticulo.Columns.Add("CajaCambio", typeof(string));
                    dta_consultaarticulo.Columns.Add("Filtro", typeof(string));
                    dta_consultaarticulo.Columns.Add("Transmision", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();
                }

                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        protected void grvConsultaArticulo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hfPrecio1 = null;
                    HiddenField hfPrecio2 = null;
                    HiddenField hfPrecio3 = null;
                    DropDownList ddlPrecio = null;

                    GridView grvDetalle = null;
                    Label lblCodigo = null;

                    grvDetalle = (GridView)(e.Row.FindControl("grvDetalleProducto"));
                    lblCodigo = (Label)(e.Row.FindControl("lblcodproducto"));

                    if (lblCodigo.Text != "")
                    {
                        DataTable dta_consultaarticulo = null;
                        DataRow dtr_consultafila = null;
                        dta_consultaarticulo = new DataTable();

                        dta_consultaarticulo.Columns.Add("Linea", typeof(string));
                        dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
                        dta_consultaarticulo.Columns.Add("Año", typeof(string));
                        dta_consultaarticulo.Columns.Add("Motor", typeof(string));
                        dta_consultaarticulo.Columns.Add("CajaCambio", typeof(string));
                        dta_consultaarticulo.Columns.Add("Filtro", typeof(string));
                        dta_consultaarticulo.Columns.Add("Transmision", typeof(string));

                        dtr_consultafila = dta_consultaarticulo.NewRow();

                        dtr_consultafila[0] = "";
                        dta_consultaarticulo.Rows.Add(dtr_consultafila);

                        grvDetalle.DataSource = dta_consultaarticulo;
                        grvDetalle.DataBind();
                    }
                }
            }
            catch (Exception exx) { }
        }


        public void P_EdicionFactura(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;


            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa1"]);
            objEntidad.Placa2 = Convert.ToString(objTablaFiltro["Filtro_Placa2"]);
            objEntidad.Placa3 = Convert.ToString(objTablaFiltro["Filtro_Placa3"]);
            objEntidad.Placa4 = Convert.ToString(objTablaFiltro["Filtro_Placa4"]);
            objEntidad.Placa5 = Convert.ToString(objTablaFiltro["Filtro_Placa5"]);
            objEntidad.Placa6 = Convert.ToString(objTablaFiltro["Filtro_Placa6"]);
            objEntidad.Placa7 = Convert.ToString(objTablaFiltro["Filtro_Placa7"]);
            objEntidad.Placa8 = Convert.ToString(objTablaFiltro["Filtro_Placa8"]);
            objEntidad.KM = Convert.ToString(objTablaFiltro["Filtro_KM"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());

            objEntidad.DireccionCompleta = Convert.ToString(objTablaFiltro["Filtro_DireccionTraslado"]);
           
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.NroOC = Convert.ToString(objTablaFiltro["Filtro_NroOC"]);
            //objEntidad.Recepcion = Convert.ToDateTime(objTablaFiltro["Filtro_Recepcion"]);
            objEntidad.FlagComisionable = Convert.ToInt32(objTablaFiltro["Filtro_FlagComisionable"]);
            objEntidad.FlagMotorizado = Convert.ToInt32(objTablaFiltro["Filtro_FlagMotorizado"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodVendedor"]);
            objEntidad.Requerimiento = Convert.ToString(objTablaFiltro["Filtro_Requerimiento"]);

            //guia miguel
            //objEntidad.NroRucTransportista = Convert.ToString(objTablaFiltro["Filtro_NroRucTransportista"]);
            //objEntidad.Transportista = Convert.ToString(objTablaFiltro["Filtro_Transportista"]);
            //objEntidad.CodDepartamentoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamentoTransportista"]);
            //objEntidad.CodProvinciaTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodProvinciaTransportista"]);
            //objEntidad.CodDistritoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDistritoTransportista"]);

            //objEntidad.GuiaAgencia = Convert.ToString(objTablaFiltro["Filtro_GuiaAgencia"]);
            //objEntidad.NombreAgencia = Convert.ToString(objTablaFiltro["Filtro_NombreAgencia"]);
            //objEntidad.ClaveAgencia = Convert.ToString(objTablaFiltro["Filtro_txtClaveAgencia"]);
            //objEntidad.CodConductor = Convert.ToInt32(objTablaFiltro["Filtro_CodConductor"]);


            //objEntidad.CodtipoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_TipoTransportista"]);
            //objEntidad.CodUnidadPeso = Convert.ToInt32(objTablaFiltro["Filtro_codunidadpeso"]);
            //objEntidad.PlacaTraslado = Convert.ToString(objTablaFiltro["Filtro_PlacaTraslado"]);
            //objEntidad.Marca = Convert.ToString(objTablaFiltro["Filtro_MarcaTraslado"]);
            //objEntidad.Licencia = Convert.ToString(objTablaFiltro["Filtro_LicenciaTraslado"]);
            //objEntidad.NuBultos = Convert.ToString(objTablaFiltro["Filtro_NroBultos"]);
            //objEntidad.Peso = Convert.ToDecimal(objTablaFiltro["Filtro_PesoBultos"]); 
            //objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            //objEntidad.DireccionTrans = Convert.ToString(objTablaFiltro["Filtro_DireccionTransportista"]);
            //objEntidad.FlagGuia = Convert.ToInt32(objTablaFiltro["Filtro_FlagGuia"]);
            //objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);
            //objEntidad.SerieGuia = Convert.ToString(objTablaFiltro["Filtro_SerieGuia"]);
            //objEntidad.NumeroGuia = Convert.ToString(objTablaFiltro["Filtro_NumeroGuia"]);
            //objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaTraslado"]);
            //objEntidad.Destino = Convert.ToString(objTablaFiltro["Filtro_Destino"]);
            //objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);

            // INICIO DATOS DE LA GUIA

            objEntidad.FlagGuia = Convert.ToInt32(objTablaFiltro["Filtro_FlagGuia"]);
            objEntidad.SerieGuia = Convert.ToString(objTablaFiltro["Filtro_SerieGuia"]);
            objEntidad.NumeroGuia = Convert.ToString(objTablaFiltro["Filtro_NumeroGuia"]);
            objEntidad.CodTipoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoTransportista"]);
            objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaTraslado"]);
            objEntidad.CodDocumentoVentaDireccionDestino = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVentaDireccionDestino"]);
            objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);
            objEntidad.CodDocumentoVentaDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVentaDireccionTransportista"]);
            objEntidad.NroRucTransportista = Convert.ToString(objTablaFiltro["Filtro_NroRucTransportista"]);
            objEntidad.RazonSocialTransportista = Convert.ToString(objTablaFiltro["Filtro_RazonSocialTransportista"]);
            objEntidad.PlacaTraslado = Convert.ToString(objTablaFiltro["Filtro_PlacaTraslado"]);
            objEntidad.MarcaVehiculo = Convert.ToString(objTablaFiltro["Filtro_MarcaVehiculo"]);
            objEntidad.Licencia = Convert.ToString(objTablaFiltro["Filtro_Licencia"]);
            objEntidad.NroBultos = Convert.ToInt32(objTablaFiltro["Filtro_NroBultos"]);
            objEntidad.Peso = Convert.ToDecimal(objTablaFiltro["Filtro_Peso"]);
            objEntidad.CodUnidadPeso = Convert.ToInt32(objTablaFiltro["Filtro_CodUnidadPeso"]);
            objEntidad.CodConductor = Convert.ToInt32(objTablaFiltro["Filtro_CodConductor"]);
            objEntidad.ObservacionGuia = Convert.ToString(objTablaFiltro["Filtro_ObservacionGuia"]);
            objEntidad.CodTrasladoEdicion = Convert.ToInt32(objTablaFiltro["Filtro_CodTrasladoEdicion"]);

            // FIN DATOS DE LA GUIA

            objEntidad.Responsable = Convert.ToString(objTablaFiltro["Filtro_Responsable1"]);
            objEntidad.ResponsableDNI = Convert.ToString(objTablaFiltro["Filtro_ResponsableDni1"]);
            objEntidad.Responsable2 = Convert.ToString(objTablaFiltro["Filtro_Responsable2"]);
            objEntidad.Responsable2DNI = Convert.ToString(objTablaFiltro["Filtro_ResponsableDni2"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_EdicionFactura(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public void P_ReemplazarFactura(Hashtable objTablaFiltro,
            ref DropDownList ddlSerie, ref DocumentoVentaCabCE objEntidadReemplazo
)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            if (objEntidad.CodTipoDoc == 16)
            {
                dtTabla = objOperacion.F_DocumentoVentaCab_Reemplazar(objEntidad);
            }
            else
            {
                objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
                dtTabla = objOperacion.F_Proforma_Reemplazar(objEntidad);
            }

            if (dtTabla.Rows.Count > 0)
            {
                objEntidadReemplazo = new DocumentoVentaCabCE();
                objEntidadReemplazo.NroRuc = dtTabla.Rows[0]["NroRuc"].ToString();
                objEntidadReemplazo.Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                objEntidadReemplazo.CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                objEntidadReemplazo.CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                objEntidadReemplazo.Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                objEntidadReemplazo.CodFormaPago = Convert.ToInt32(dtTabla.Rows[0]["CodFormaPago"]);
                objEntidadReemplazo.CodFactura_Anterior = Convert.ToInt32(dtTabla.Rows[0]["CodFacturaAnterior"]);
                objEntidadReemplazo.SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                objEntidadReemplazo.NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                objEntidadReemplazo.FechaEmision = Convert.ToDateTime(dtTabla.Rows[0]["FechaEmision"]);
                objEntidadReemplazo.FechaEmisionStr = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                objEntidadReemplazo.FechaVencimiento = Convert.ToDateTime(dtTabla.Rows[0]["FechaVencimiento"]);
                objEntidadReemplazo.FechaVencimientoStr = Convert.ToString(dtTabla.Rows[0]["FechaVencimiento"]);
                objEntidadReemplazo.CodTasa = Convert.ToInt32(dtTabla.Rows[0]["CodTasa"]);
                objEntidadReemplazo.SubTotal = Convert.ToDecimal(dtTabla.Rows[0]["ImpSubTotal"]);
                objEntidadReemplazo.Igv = Convert.ToDecimal(dtTabla.Rows[0]["ImpIgv"]);
                objEntidadReemplazo.Total = Convert.ToDecimal(dtTabla.Rows[0]["ImpTotal"]);
                objEntidadReemplazo.Descuento = Convert.ToDecimal(dtTabla.Rows[0]["Descuento"]);
                objEntidadReemplazo.CodDireccion = Convert.ToInt32(dtTabla.Rows[0]["CodDireccion"]);
                objEntidadReemplazo.CodDepartamento = Convert.ToInt32(dtTabla.Rows[0]["CodDepartamento"]);
                objEntidadReemplazo.CodProvincia = Convert.ToInt32(dtTabla.Rows[0]["CodProvincia"]);
                objEntidadReemplazo.CodDistrito = Convert.ToInt32(dtTabla.Rows[0]["CodDistrito"]);
                objEntidadReemplazo.Distrito = Convert.ToString(dtTabla.Rows[0]["Distrito"]);

                objEntidadReemplazo.Placa = Convert.ToString(dtTabla.Rows[0]["Placa"]);
                objEntidadReemplazo.Placa2 = Convert.ToString(dtTabla.Rows[0]["Placa2"]);
                objEntidadReemplazo.Placa3 = Convert.ToString(dtTabla.Rows[0]["Placa3"]);
                objEntidadReemplazo.Placa4 = Convert.ToString(dtTabla.Rows[0]["Placa4"]);
                objEntidadReemplazo.Placa5 = Convert.ToString(dtTabla.Rows[0]["Placa5"]);
                objEntidadReemplazo.Placa6 = Convert.ToString(dtTabla.Rows[0]["Placa6"]);
                objEntidadReemplazo.Placa7 = Convert.ToString(dtTabla.Rows[0]["Placa7"]);
                objEntidadReemplazo.Placa8 = Convert.ToString(dtTabla.Rows[0]["Placa8"]);
                objEntidadReemplazo.KM = Convert.ToString(dtTabla.Rows[0]["Kilometraje"]);
                objEntidadReemplazo.CodResponsable = Convert.ToInt32(dtTabla.Rows[0]["CodResponsable"]);
                objEntidadReemplazo.Responsable2 = Convert.ToString(dtTabla.Rows[0]["Responsable2"]);
                objEntidadReemplazo.Responsable2DNI = Convert.ToString(dtTabla.Rows[0]["Responsable2DNI"]);
                objEntidadReemplazo.Responsable = Convert.ToString(dtTabla.Rows[0]["Responsable1"]);
                objEntidadReemplazo.ResponsableDNI = Convert.ToString(dtTabla.Rows[0]["Responsable1DNI"]);
                objEntidadReemplazo.Observacion = Convert.ToString(dtTabla.Rows[0]["Observacion"]);
                objEntidadReemplazo.Requerimiento = Convert.ToString(dtTabla.Rows[0]["Requerimiento"]);
                objEntidadReemplazo.CodVendedor = Convert.ToInt32(dtTabla.Rows[0]["CodVendedor"]);
                objEntidadReemplazo.atencion = Convert.ToString(dtTabla.Rows[0]["Atencion"]);
                objEntidadReemplazo.NroOperacion = Convert.ToString(dtTabla.Rows[0]["NroOperacion"]);
                objEntidadReemplazo.NroOC = Convert.ToString(dtTabla.Rows[0]["NroOC"]);

                //guia

                objEntidadReemplazo.Codtraslado = Convert.ToInt32(dtTabla.Rows[0]["Codtraslado"]);
                objEntidadReemplazo.SerieDocGuia = Convert.ToString(dtTabla.Rows[0]["SerieDocGuia"]);
                objEntidadReemplazo.NumeroDocGuia = Convert.ToString(dtTabla.Rows[0]["NumeroDocGuia"]);
                objEntidadReemplazo.Destino = Convert.ToString(dtTabla.Rows[0]["Destino"]);
                objEntidadReemplazo.Partida = Convert.ToString(dtTabla.Rows[0]["Partida"]);
                objEntidadReemplazo.Transportista = Convert.ToString(dtTabla.Rows[0]["Transportista"]);
                objEntidadReemplazo.CodTransportista = Convert.ToInt32(dtTabla.Rows[0]["CodTransportista"]);
                objEntidadReemplazo.CodDireccionTransportista = Convert.ToInt32(dtTabla.Rows[0]["CodDireccionTransportista"]);
                objEntidadReemplazo.DireccionTrans = Convert.ToString(dtTabla.Rows[0]["DireccionTrans"]);
                objEntidadReemplazo.DistritoTransportista = Convert.ToString(dtTabla.Rows[0]["DistritoTrans"]);
                objEntidadReemplazo.PlacaTraslado = Convert.ToString(dtTabla.Rows[0]["PlacaTraslado"]);
                objEntidadReemplazo.Marca = Convert.ToString(dtTabla.Rows[0]["Marca"]);
                objEntidadReemplazo.Licencia = Convert.ToString(dtTabla.Rows[0]["Licencia"]);
                objEntidadReemplazo.NuBultos = Convert.ToString(dtTabla.Rows[0]["NuBultos"]);
                objEntidadReemplazo.Peso = Convert.ToDecimal(dtTabla.Rows[0]["Peso"]);
                objEntidadReemplazo.NroRuctrans = Convert.ToString(dtTabla.Rows[0]["NroRuctrans"]);
                objEntidadReemplazo.RazonSocialtrans = Convert.ToString(dtTabla.Rows[0]["RazonSocialtrans"]);
                objEntidadReemplazo.CodDepartamentoGuia = Convert.ToInt32(dtTabla.Rows[0]["CodDepartamentoGuia"]);
                objEntidadReemplazo.CodDistritoGuia = Convert.ToInt32(dtTabla.Rows[0]["CodDistritoGuia"]);
                objEntidadReemplazo.CodProvinciaGuia = Convert.ToInt32(dtTabla.Rows[0]["CodProvinciaGuia"]);


                //llenado de combo seriedoc
                //-------------------------
                DataTable dta_consulta = (new TCCorrelativoCN()).F_TCCorrelativo_Serie_Select((new TCCorrelativoCE()
                {
                    CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]),
                    CodSede = Convert.ToInt32(Session["CodSede"]),
                    CodEmpresa = 3
                }));

                ddlSerie.Items.Clear();
                ddlSerie.DataSource = dta_consulta;
                ddlSerie.DataTextField = "SerieDoc";
                ddlSerie.DataValueField = "CodSerie";
                ddlSerie.DataBind();
                //-------------------------
            }
        }

        public void F_AgregarTemporalNP(Hashtable objTablaFiltro, ref DocumentoVentaCabCE objEntidadReemplazo
)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodTemporal"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            String XmlDetalle = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDocumentos"].ToString());
            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDocumentoVenta = '" + item.CodDocumentoVenta + "'";
                XmlDetalle = XmlDetalle + " />";
            }
            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";
            objEntidad.XmlDetalle = XmlDetalle;



            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_AgregarTemporan_NP_Varios(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                objEntidadReemplazo = new DocumentoVentaCabCE();
                objEntidadReemplazo.NroRuc = dtTabla.Rows[0]["NroRuc"].ToString();
                objEntidadReemplazo.Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                objEntidadReemplazo.CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                objEntidadReemplazo.CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                objEntidadReemplazo.Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                objEntidadReemplazo.CodFormaPago = Convert.ToInt32(dtTabla.Rows[0]["CodFormaPago"]);
                //objEntidadReemplazo.CodFactura_Anterior = Convert.ToInt32(dtTabla.Rows[0]["CodFacturaAnterior"]);
                objEntidadReemplazo.SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                objEntidadReemplazo.NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                objEntidadReemplazo.FechaEmision = Convert.ToDateTime(dtTabla.Rows[0]["FechaEmision"]);
                objEntidadReemplazo.FechaEmisionStr = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                objEntidadReemplazo.FechaVencimiento = Convert.ToDateTime(dtTabla.Rows[0]["FechaVencimiento"]);
                objEntidadReemplazo.FechaVencimientoStr = Convert.ToString(dtTabla.Rows[0]["FechaVencimiento"]);
                objEntidadReemplazo.CodTasa = Convert.ToInt32(dtTabla.Rows[0]["CodTasa"]);
                objEntidadReemplazo.SubTotal = Convert.ToDecimal(dtTabla.Rows[0]["ImpSubTotal"]);
                objEntidadReemplazo.Igv = Convert.ToDecimal(dtTabla.Rows[0]["ImpIgv"]);
                objEntidadReemplazo.Total = Convert.ToDecimal(dtTabla.Rows[0]["ImpTotal"]);
                objEntidadReemplazo.Descuento = Convert.ToDecimal(dtTabla.Rows[0]["Descuento"]);
                objEntidadReemplazo.CodDireccion = Convert.ToInt32(dtTabla.Rows[0]["CodDireccion"]);
                objEntidadReemplazo.CodDepartamento = Convert.ToInt32(dtTabla.Rows[0]["CodDepartamento"]);
                objEntidadReemplazo.CodProvincia = Convert.ToInt32(dtTabla.Rows[0]["CodProvincia"]);
                objEntidadReemplazo.CodDistrito = Convert.ToInt32(dtTabla.Rows[0]["CodDistrito"]);
                objEntidadReemplazo.Distrito = Convert.ToString(dtTabla.Rows[0]["Distrito"]);

                objEntidadReemplazo.Placa = Convert.ToString(dtTabla.Rows[0]["Placa"]);
                objEntidadReemplazo.Placa2 = Convert.ToString(dtTabla.Rows[0]["Placa2"]);
                objEntidadReemplazo.Placa3 = Convert.ToString(dtTabla.Rows[0]["Placa3"]);
                objEntidadReemplazo.Placa4 = Convert.ToString(dtTabla.Rows[0]["Placa4"]);
                objEntidadReemplazo.KM = Convert.ToString(dtTabla.Rows[0]["Kilometraje"]);
                objEntidadReemplazo.CodResponsable = Convert.ToInt32(dtTabla.Rows[0]["CodResponsable"]);
                objEntidadReemplazo.Responsable2 = Convert.ToString(dtTabla.Rows[0]["Responsable2"]);
                objEntidadReemplazo.Responsable2DNI = Convert.ToString(dtTabla.Rows[0]["Responsable2DNI"]);
            }
        }

        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }

        [WebMethod(EnableSession = true)]
        public static List<TCDireccionesEmail> F_Correos_Por_Cliente_Listar_NET(int CodCtaCte, int CodDireccion)
        {
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            return objOperacion.F_Correos_Por_Cliente_Listar_NET(CodCtaCte, CodDireccion);
        }

        [WebMethod(EnableSession = true)]
        public static string F_Correos_Por_Cliente_Actualizar_NET(int CodDireccion, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6)
        {
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            return objOperacion.F_Correos_Por_Cliente_Actualizar_NET(CodDireccion, Email1, Email2, Email3, Email4, Email5, Email6, int.Parse(HttpContext.Current.Session["CodUsuario"].ToString()), 0, 0);
        }

        [WebMethod(EnableSession = true)]
        public static string F_Correos_Por_Cliente_Actualizar_CodDocumentoVenta_NET(int CodDocumentoVenta, int CodTipoDoc, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6)
        {
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            return objOperacion.F_Correos_Por_Cliente_Actualizar_NET(0, Email1, Email2, Email3, Email4, Email5, Email6, int.Parse(HttpContext.Current.Session["CodUsuario"].ToString()), CodDocumentoVenta, CodTipoDoc);
        }

        [WebMethod(EnableSession = true)]
        public static List<TCDireccionesEmail> F_Correos_Por_Responsable_Listar_NET(int CodResponsable)
        {
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            return objOperacion.F_Correos_Por_Responsable_Listar_NET(CodResponsable);
        }

        [WebMethod(EnableSession = true)]
        public static string F_Correos_Por_Responsable_Actualizar_NET(int CodDireccion, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6)
        {
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            return objOperacion.F_Correos_Por_Responsable_Actualizar_NET(CodDireccion, Email1, Email2, Email3, Email4, Email5, Email6, int.Parse(HttpContext.Current.Session["CodUsuario"].ToString()), 0, 0);
        }

        [WebMethod]
        public static DocumentoVentaCabCE F_ObtenerArchivoCDR_NET(int CodDocumentoVenta)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE()
            {
                CodDocumentoVenta = CodDocumentoVenta
            };
            return (new DocumentoVentaCabCN()).F_Tst_ArchivoCDR_FactElectronica(objEntidad);
        }

        [WebMethod]
        //busca el stock del almacen especificado
        public static jqProformasResult F_Consulta_Cotizaciones_Pendientes_NET(int CodAlmacen)
        {
            jqProformasResult data = new jqProformasResult();
            ProformaCabCE par = new ProformaCabCE() { CodEmpresa = 3, CodAlmacen = CodAlmacen, CodEstado = 6 };
            data.rows = (new ProformaCabCN()).F_ProformaCab_ListarXEstado(par);
            return data;
        }
        public class jqProformasResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<ProformaCabCE> rows { get; set; }
        }

        [WebMethod]
        public static ProformaCabCE F_ObtenerCotizacion_PorNumero_Net(int NumeroCotizacion)
        {
            ProformaCabCE objEntidad = new ProformaCabCE();
            ProformaCabCN objOperacion = new ProformaCabCN();
            objEntidad.Numero = NumeroCotizacion.ToString();
            return objOperacion.F_ProformaCab_ObtenerXNumero(objEntidad);
        }

        public void F_ListarCorreos(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);


            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_ListarCorreos(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public String F_FacturarVale_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;

            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal AcuentaNV = 0;
            Decimal Dscto = 0;

            Decimal Total2 = 0;
            Decimal SubTotal2 = 0;
            Decimal Igv2 = 0;
            Decimal AcuentaNV2 = 0;
            Decimal Dscto2 = 0;
            Decimal igvo = 0;
            Decimal totalo = 0;
            Decimal stotalo = 0;

            int NotaPedido = 0;

            Hashtable obj_parametros = null;
            String str_ddl_serie_html = "";
            string JSONDocumentoVentaCab = "";
            DocumentoVentaCabCE objReemplazo = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                if (str_mensaje_operacion == "")
                {
                    P_FacturarVale(obj_parametros,
                                        ref ddlSerie, ref objReemplazo, ref str_mensaje_operacion);
                    str_mensaje_operacion = objReemplazo.Mensaje;
                    //se le ponen estas para que no sume demas ya que los montos se llenan arriba
                    P_CargarGrillaTemporalVale(obj_parametros, objReemplazo.Codigo, ref grvDetalleArticulo, ref stotalo, ref igvo, ref totalo, ref NotaPedido);

                    if (Math.Round(Total, 2) == Math.Round(Total2, 2))
                    {
                        objReemplazo.FlagIgv = 1;
                    }

                    str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                    str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);


                    JSONDocumentoVentaCab = JsonConvert.SerializeObject(objReemplazo);

                    int_resultado_operacion = 1;
                }
                else
                    int_resultado_operacion = 0;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                str_grvDetalleArticulo_html + "~" + //2
                str_ddl_serie_html + "~" +  //3
                JSONDocumentoVentaCab + "~" + //4
                Math.Round(totalo, 2).ToString() + "~" + //5
                Math.Round(igvo, 2).ToString() + "~" +//6
                Math.Round(stotalo, 2).ToString(); //7

            return str_resultado;
        }

        public void P_FacturarVale(Hashtable objTablaFiltro,
            ref DropDownList ddlSerie, ref DocumentoVentaCabCE objEntidadReemplazo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

           
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoventa"]);

            String XmlDetalle = "";

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDocumentoventa = '" + item.CodDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_Facturar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                objEntidadReemplazo = new DocumentoVentaCabCE();
                objEntidadReemplazo.NroRuc = dtTabla.Rows[0]["NroRuc"].ToString();
                objEntidadReemplazo.Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                objEntidadReemplazo.CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                objEntidadReemplazo.CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                objEntidadReemplazo.Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                objEntidadReemplazo.CodFormaPago = Convert.ToInt32(dtTabla.Rows[0]["CodFormaPago"]);
                objEntidadReemplazo.Codtipodoctemporal = Convert.ToInt32(dtTabla.Rows[0]["Codtipodoctemporal"]);
                objEntidadReemplazo.SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                objEntidadReemplazo.NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                objEntidadReemplazo.FechaEmision = Convert.ToDateTime(dtTabla.Rows[0]["FechaEmision"]);
                objEntidadReemplazo.FechaEmisionStr = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                objEntidadReemplazo.FechaVencimiento = Convert.ToDateTime(dtTabla.Rows[0]["FechaVencimiento"]);
                objEntidadReemplazo.FechaVencimientoStr = Convert.ToString(dtTabla.Rows[0]["FechaVencimiento"]);
                objEntidadReemplazo.CodTasa = Convert.ToInt32(dtTabla.Rows[0]["CodTasa"]);
                objEntidadReemplazo.SubTotal = Convert.ToDecimal(dtTabla.Rows[0]["ImpSubTotal"]);
                objEntidadReemplazo.Igv = Convert.ToDecimal(dtTabla.Rows[0]["ImpIgv"]);
                objEntidadReemplazo.Total = Convert.ToDecimal(dtTabla.Rows[0]["ImpTotal"]);
                objEntidadReemplazo.Descuento = Convert.ToDecimal(dtTabla.Rows[0]["Descuento"]);
                objEntidadReemplazo.CodDireccion = Convert.ToInt32(dtTabla.Rows[0]["CodDireccion"]);
                objEntidadReemplazo.CodDepartamento = Convert.ToInt32(dtTabla.Rows[0]["CodDepartamento"]);
                objEntidadReemplazo.CodProvincia = Convert.ToInt32(dtTabla.Rows[0]["CodProvincia"]);
                objEntidadReemplazo.CodDistrito = Convert.ToInt32(dtTabla.Rows[0]["CodDistrito"]);
                objEntidadReemplazo.Distrito = Convert.ToString(dtTabla.Rows[0]["Distrito"]);

                objEntidadReemplazo.Placa = Convert.ToString(dtTabla.Rows[0]["Placa"]);
                objEntidadReemplazo.Placa2 = Convert.ToString(dtTabla.Rows[0]["Placa2"]);
                objEntidadReemplazo.Placa3 = Convert.ToString(dtTabla.Rows[0]["Placa3"]);
                objEntidadReemplazo.Placa4 = Convert.ToString(dtTabla.Rows[0]["Placa4"]);
                objEntidadReemplazo.Placa5 = Convert.ToString(dtTabla.Rows[0]["Placa5"]);
                objEntidadReemplazo.Placa6 = Convert.ToString(dtTabla.Rows[0]["Placa6"]);
                objEntidadReemplazo.Placa7 = Convert.ToString(dtTabla.Rows[0]["Placa7"]);
                objEntidadReemplazo.Placa8 = Convert.ToString(dtTabla.Rows[0]["Placa8"]);
                objEntidadReemplazo.KM = Convert.ToString(dtTabla.Rows[0]["Kilometraje"]);
                objEntidadReemplazo.CodResponsable = Convert.ToInt32(dtTabla.Rows[0]["CodResponsable"]);
                objEntidadReemplazo.Responsable2 = Convert.ToString(dtTabla.Rows[0]["Responsable2"]);
                objEntidadReemplazo.Responsable2DNI = Convert.ToString(dtTabla.Rows[0]["Responsable2DNI"]);
                objEntidadReemplazo.Mensaje  = Convert.ToString(dtTabla.Rows[0]["Mensaje"]);
                MsgError = Convert.ToString(dtTabla.Rows[0]["Mensaje"]);
                //llenado de combo seriedoc
                //-------------------------
                DataTable dta_consulta = (new TCCorrelativoCN()).F_TCCorrelativo_Serie_Select((new TCCorrelativoCE()
                {
                    CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]),
                    CodSede = Convert.ToInt32(Session["CodSede"]),
                    CodEmpresa = 3
                }));

                ddlSerie.Items.Clear();
                ddlSerie.DataSource = dta_consulta;
                ddlSerie.DataTextField = "SerieDoc";
                ddlSerie.DataValueField = "CodSerie";
                ddlSerie.DataBind();
                //-------------------------
            }
        }

        public void P_CargarGrillaTemporalVale(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
           ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Int32 NotaPedido)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objOperacion = new DocumentoVentaCabCN();


            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
                objEntidad.Tasa = Convert.ToDecimal(objTablaFiltro["Filtro_Tasa"]);
                objEntidad.CodDocumentoVenta = Codigo;

                dta_consulta = objOperacion.F_TemporalFacturacionDetallado_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                if (Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 1)
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        //if (Convert.ToDecimal(dta_consulta.Rows[j]["CodTipoProducto"]) == 2)
                            TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }

                }
                else
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {

                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }
                }

                SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();

            try { NotaPedido = Convert.ToInt32(dta_consulta.Rows[0]["NotaPedido"]); }
            catch (Exception exxx) { NotaPedido = 0; };
        }

        public void P_ValidarFactura(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);

            objOperacion = new DocumentoVentaCabCN();

            Mensaje = objOperacion.F_Documentoventa_Validar_Factura(objEntidad).MsgError;
        }

        //guia remision

        public void P_Inicializar_GrillaVacia_Consulta_DireccionTemporal()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("CodDocumentoVentaDireccion", typeof(string));
            dta_consulta.Columns.Add("CodDocumentoVenta", typeof(string));
            dta_consulta.Columns.Add("CodDistrito", typeof(string));
            dta_consulta.Columns.Add("CodProvincia", typeof(string));
            dta_consulta.Columns.Add("CodDepartamento", typeof(string));
            dta_consulta.Columns.Add("Correo1", typeof(string));
            dta_consulta.Columns.Add("Correo2", typeof(string));
            dta_consulta.Columns.Add("distrito", typeof(string));
            dta_consulta.Columns.Add("Direccion", typeof(string));

            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvDireccion.DataSource = dta_consulta;
            grvDireccion.DataBind();
        }

        public String F_DireccionTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_BuscarDireccionTemporal(obj_parametros, ref grvDireccion);
                if (grvDireccion.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Consulta_DireccionTemporal();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvDireccion);
                int_resultado_operacion = 1;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public void P_BuscarDireccionTemporal(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            TCDistritoCE objEntidad = null;
            TCDistritoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCDistritoCE();

            objEntidad.Temporal = Convert.ToInt32(objTablaFiltro["Filtro_CodTemporal"]);
            objEntidad.FlagTraslado = Convert.ToInt32(objTablaFiltro["Filtro_FlagTraslado"]);

            objOperacion = new TCDistritoCN();

            dta_consulta = objOperacion.F_TCDireccion_ListarXDireccionTemporal(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public String F_GrabarDireccionTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDireccion_html = "";
            int int_resultado_operacion = 0;
            int CodDocumentoVentaDireccion = 0;
            int FlagTraslado = 0;
            int CodDocumentoVenta = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDireccionTemporal(obj_parametros, ref CodDocumentoVentaDireccion, ref FlagTraslado, ref str_mensaje_operacion, ref CodDocumentoVenta);

                P_BuscarDireccionTemporal(obj_parametros, ref grvDireccion);

                if (grvDireccion.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta_DireccionTemporal();

                str_grvDireccion_html = Mod_Utilitario.F_GetHtmlForControl(grvDireccion);
                int_resultado_operacion = 1;



            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                 + "~" +
                str_grvDireccion_html
                 + "~" +
                 CodDocumentoVentaDireccion.ToString()
                  + "~" +
                 FlagTraslado.ToString()
                  + "~" +
                 CodDocumentoVenta.ToString();


            return str_resultado;

        }

        public void P_GrabarDireccionTemporal(Hashtable objTablaFiltro, ref int CodDocumentoVentaDireccion, ref int FlagTraslado, ref String MsgError, ref int CodDocumentoVenta)
        {

            TCDistritoCE objEntidad = null;
            TCDistritoCN objOperacion = null;

            objEntidad = new TCDistritoCE();

            objEntidad.CodAlmacen = Convert.ToInt32((Session["CodSede"]));
            objEntidad.Temporal = Convert.ToInt32(objTablaFiltro["Filtro_CodTemporal"]);
            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.Email = Convert.ToString(objTablaFiltro["Filtro_correo1"]);
            objEntidad.Email2 = Convert.ToString(objTablaFiltro["Filtro_correo2"]);
            objEntidad.CodCLiente = Convert.ToInt32(objTablaFiltro["Filtro_codCliente"]);
            objEntidad.CodDireccionTemporal = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTemporal"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.FlagTraslado = Convert.ToInt32(objTablaFiltro["Filtro_FlagTraslado"]);

            objOperacion = new TCDistritoCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTemporal"]) == 0)
            {
                objOperacion.F_TCDireccionTemporal_Agregar(objEntidad);
            }
            else
            {
                objOperacion.F_TCDireccionTemporal_Editar(objEntidad);
            }
            MsgError = objEntidad.Mensaje;
            CodDocumentoVentaDireccion = objEntidad.CodDocumentoVentaDireccion;
            FlagTraslado = Convert.ToInt32(objTablaFiltro["Filtro_FlagTraslado"]);
            CodDocumentoVenta = objEntidad.Temporal;
        }

        public String F_EliminarDireccionTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDireccion_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarDireccionTemporal(obj_parametros, ref str_mensaje_operacion);

                P_BuscarDireccionTemporal(obj_parametros, ref grvDireccion);

                if (grvDireccion.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta_DireccionTemporal();

                str_grvDireccion_html = Mod_Utilitario.F_GetHtmlForControl(grvDireccion);
                int_resultado_operacion = 1;



            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                 + "~" +
                str_grvDireccion_html;


            return str_resultado;

        }

        public void P_EliminarDireccionTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            TCDistritoCE objEntidad = null;
            TCDistritoCN objOperacion = null;

            objEntidad = new TCDistritoCE();

            objEntidad.CodDireccionTemporal = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTemporal"]);

            objOperacion = new TCDistritoCN();

            objOperacion.F_TCDireccionTemporal_Eliminar(objEntidad);

            MsgError = objEntidad.Mensaje;

        }

        public String F_BuscarDireccionCotizacion_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDireccion_html = "";
            int int_resultado_operacion = 0;
            int CodDireccionTemporal = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_BuscarDireccionCotizacion(obj_parametros, ref CodDireccionTemporal, ref str_mensaje_operacion);

                int_resultado_operacion = 1;



            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                 + "~" +
                str_grvDireccion_html
                 + "~" +
                 CodDireccionTemporal.ToString();


            return str_resultado;

        }

        public void P_BuscarDireccionCotizacion(Hashtable objTablaFiltro, ref int CodDireccionTemporal, ref String MsgError)
        {

            TCDistritoCE objEntidad = null;
            TCDistritoCN objOperacion = null;

            objEntidad = new TCDistritoCE();


            objEntidad.Temporal = Convert.ToInt32(objTablaFiltro["Filtro_CodTemporal"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);

            objOperacion = new TCDistritoCN();


            objOperacion.F_BuscarDireccionCotizacion(objEntidad);

            MsgError = objEntidad.Mensaje;
            CodDireccionTemporal = objEntidad.CodDireccionTemporal;

        }


    }  

}
