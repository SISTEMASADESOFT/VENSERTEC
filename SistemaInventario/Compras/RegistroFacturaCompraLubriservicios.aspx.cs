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

namespace SistemaInventario.Compras
{
    public partial class RegistroFacturaCompraLubriservicios : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_BuscarTemporal_NET);
            CallbackManager.Register(F_EditarTemporal_NET);
            CallbackManager.Register(F_ActualizarPrecio_Net);
            CallbackManager.Register(F_ActualizarDetalle_NET);
            CallbackManager.Register(F_CargarGrillaTemporal_NET);
            CallbackManager.Register(F_ReemplazarFactura_NET);
            CallbackManager.Register(F_ProductoDetalle_NET);
            CallbackManager.Register(F_VerUltimoPrecio_NET);
            CallbackManager.Register(F_LlenarGridDetalle_Auditoria_NET);
            CallbackManager.Register(F_LlenarGridDetalle_Observacion_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia_ConsultaArticulo();
            P_Inicializar_GrillaVacia_DetalleArticulo();
            P_Inicializar_GrillaVacia_ConsultaFactura();
            P_Inicializar_GrillaVacia_DetalleOC();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
                GridView grvDetalle = null;
                GridView grvDetalleAuditoria = null;
                GridView grvDetalleObservacion = null;
                HiddenField lblCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));
                lblCodigo = (HiddenField)(e.Row.FindControl("lblcodigo"));
                if (lblCodigo.Value.ToString() != "")
                {
                    objEntidad.CodMovimiento = Convert.ToInt32(lblCodigo.Value.ToString());
                    grvDetalle.DataSource = objOperacion.F_NotaIngresoSalidaDet_Select(objEntidad);
                    grvDetalle.DataBind();
                }


                if (lblCodigo.Value != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                    grvDetalleAuditoria.DataSource = dta_consultaarticulo;
                    grvDetalleAuditoria.DataBind();
                }
                //Convert.ToInt32(e.Row.Cells[1].Text);
            }
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddl_moneda_html = "";
            String str_ddl_formapago_html = "";
            String str_ddl_TipoDocumento_html = "";
            String str_ddl_Clasificacion_html = "";
            String str_ddl_igv_html = "";
            String str_numerofactura = "";
            String str_ddlCategoria_html = "";
            String str_ddlClasificacionConsulta_html = "";
            String str_ddlCajaFisica_html = "";
            int CodCajaFisica = 0;

            decimal TC = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlFormaPago, ref ddlMoneda, ref ddlIgv, ref ddlTipoDocumento,
                                            ref ddlClasificacion, ref ddlCategoria, ref ddlClasificacionConsulta, ref ddlCajaFisica);
                P_Obtener_TipoCambio(obj_parametros, ref TC);


                str_ddl_formapago_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPago);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_TipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento);
                str_ddl_Clasificacion_html = Mod_Utilitario.F_GetHtmlForControl(ddlClasificacion);
                str_ddlCategoria_html = Mod_Utilitario.F_GetHtmlForControl(ddlCategoria);
                str_ddlClasificacionConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlClasificacionConsulta);
                str_ddlCajaFisica_html = Mod_Utilitario.F_GetHtmlForControl(ddlCajaFisica);

                str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);

                try { CodCajaFisica = Convert.ToInt32(Session["CodCajaFisica"]); }
                catch (Exception) { }

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
                str_ddl_serie_html + "~" + //2
                str_ddl_serieguia_html + "~" + //3
                str_ddl_formapago_html + "~" + //4
                str_ddl_moneda_html + "~" + //5
                TC.ToString() + "~" + //6
                str_numerofactura + "~" + //7
                str_ddl_igv_html + "~" + //8
                str_ddl_TipoDocumento_html + "~" + //9
                str_ddl_Clasificacion_html + "~" + //10
                str_ddlClasificacionConsulta_html + "~" + //11
                str_ddlCategoria_html + "~" + //12
                str_ddlCajaFisica_html + "~" + //13
                CodCajaFisica; //14

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
                    P_Inicializar_GrillaVacia_ConsultaArticulo();
                    str_mensaje_operacion = "No se encontraron registros";
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
            int FlagCSIgv = -1;
            Decimal Dscto = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref FlagCSIgv);
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
                Math.Round(Dscto, 2).ToString();

            return str_resultado;
        }

        public String F_EliminarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int FlagCSigv = -1;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Dscto = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref FlagCSigv);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();

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
                Math.Round(Dscto, 2).ToString();

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError, ref Codigo);
                P_Inicializar_GrillaVacia_DetalleArticulo();

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
                Codigo.ToString()
                + "~" +
                str_numerofactura;


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia_DetalleArticulo();
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
                str_grvDetalleArticulo_html;



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
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";


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
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_ConsultaFactura();
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

                P_Inicializar_GrillaVacia_ConsultaArticulo();
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
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio);
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
                TipoCambio.ToString();


            return str_resultado;

        }

        public String F_BuscarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();

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
                str_grvDetalleArticulo_html;

            return str_resultado;

        }

        public String F_EditarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarTemporal(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";

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

        public String F_ActualizarPrecio_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            int FlagCSigv = -1;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Dscto = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarPrecios(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref FlagCSigv);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();
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
                Math.Round(SubTotal, 2).ToString();

            return str_resultado;

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
            Decimal Dscto = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;
            int FlagCSigv = -1;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarDetalle(obj_parametros, ref str_mensaje_operacion);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodDocumentoVenta"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref FlagCSigv);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                str_mensaje_operacion = "Se actualizó con éxito";
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
                Math.Round(Dscto, 2).ToString();

            return str_resultado;

        }

        public String F_CargarGrillaTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Dscto = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;
            int FlagCSigv = -1;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodDocumentoVenta"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref FlagCSigv);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();

                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                str_mensaje_operacion = "Se actualizó con éxito";
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
                Math.Round(Dscto, 2).ToString();

            return str_resultado;
        }

        public String F_ReemplazarFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            String NroRuc = "";
            String Proveedor = "";
            String SerieDoc = "";
            String NumeroDoc = "";
            String FechaEmision = "";
            String FechaVencimiento = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            int CodProveedor = 0;
            int CodMoneda = 0;
            int CodFormaPago = 0;
            int CodFacturaAnterior = 0;
            int CodCtaCte = 0;
            int CodCategoria = 0;
            int CodClasificacion = 0;
            int FlagPercepcion = 0;
            int FlagMotorizado = 0;
            int Periodo = 0;
            int CodTasa = 0;
            int FlagIgv = 0;
            int CodDireccion = 0;
            int CodDepartamento = 0;
            int CodProvincia = 0;
            int CodDistrito = 0;
            String Distrito = "";
            String NumeroGuia = "";
            int FlagCSigv = -1;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal AcuentaNV = 0;
            Decimal Dscto = 0;

            int FlagCSIgv = -1;
            Decimal Total2 = 0;
            Decimal SubTotal2 = 0;
            Decimal Igv2 = 0;
            Decimal AcuentaNV2 = 0;
            Decimal Dscto2 = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_ValidarFactura(obj_parametros, ref str_mensaje_operacion);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarFactura(obj_parametros,
                                        ref  NroRuc, ref Codigo, ref CodCtaCte,
                                        ref CodMoneda, ref  Proveedor, ref CodFormaPago, ref CodFacturaAnterior,
                                        ref  NumeroDoc, ref  FechaEmision, ref  FechaVencimiento, ref  SerieDoc,
                                        ref CodCategoria, ref FlagPercepcion, ref Periodo, ref CodClasificacion,
                                        ref CodTasa, ref SubTotal, ref Igv, ref Total, ref Dscto,
                                        ref CodDireccion, ref CodDepartamento, ref CodProvincia, ref CodDistrito, ref Distrito, ref NumeroGuia, ref FlagMotorizado, ref FlagCSIgv);

                    P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal2, ref Igv2, ref Total2, ref Dscto2, ref FlagCSIgv);


                    str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
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
                Codigo.ToString() + "~" + //2
                str_grvDetalleArticulo_html + "~" + //3
                Math.Round(Total, 2).ToString() + "~" + //4
                Math.Round(Igv, 2).ToString() + "~" + //5
                Math.Round(SubTotal, 2).ToString() + "~" + //6
                Math.Round(AcuentaNV, 2).ToString() + "~" + //7
                NroRuc + "~" + //8
                Proveedor + "~" + //9
                CodMoneda.ToString() + "~" + //10
                CodFormaPago.ToString() + "~" + //11
                CodProveedor.ToString() + "~" + //12
                CodFacturaAnterior.ToString() + "~" + //13
                NumeroDoc + "~" + //14
                FechaEmision + "~" + //15
                FechaVencimiento + "~" + //16
                SerieDoc + "~" + //17
                CodCategoria + "~" + //18
                FlagPercepcion + "~" + //19
                Periodo + "~" + //20
                CodClasificacion + "~" + //21
                CodTasa + "~" + //22
                Dscto + "~" + //23
                CodCtaCte + "~" + //24
                FlagIgv + "~" + //25  
                CodDireccion + "~" + //26
                CodDepartamento + "~" +  //27
                CodProvincia + "~" + //28
                CodDistrito + "~" + //29
                Distrito + "~" +//30
                NumeroGuia + "~" + //31
                FlagCSIgv; //32

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



        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboformapago,
             ref DropDownList ddl_combomoneda, ref DropDownList ddl_comboigv, ref DropDownList ddl_combodocumento,
             ref DropDownList ddl_comboclasificacion, ref DropDownList ddl_combocategoria, ref DropDownList ddl_comboclasificacionconsulta,
             ref DropDownList ddl_CajaFisica)
        {

            DataTable dta_consulta = null;


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


            objEntidadConceptosDet.CodConcepto = 26;


            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboclasificacion.Items.Clear();

            ddl_comboclasificacion.DataSource = dta_consulta;
            ddl_comboclasificacion.DataTextField = "DscAbvConcepto";
            ddl_comboclasificacion.DataValueField = "CodConcepto";
            ddl_comboclasificacion.DataBind();

            ddl_comboclasificacionconsulta.Items.Clear();

            ddl_comboclasificacionconsulta.DataSource = dta_consulta;
            ddl_comboclasificacionconsulta.DataTextField = "DscAbvConcepto";
            ddl_comboclasificacionconsulta.DataValueField = "CodConcepto";
            ddl_comboclasificacionconsulta.DataBind();

            objEntidadConceptosDet.CodConcepto = 10;

            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combocategoria.Items.Clear();

            ddl_combocategoria.DataSource = dta_consulta;
            ddl_combocategoria.DataTextField = "DscAbvConcepto";
            ddl_combocategoria.DataValueField = "CodConcepto";
            ddl_combocategoria.DataBind();

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

            TCDocumentosCN objOperacionDocumento = new TCDocumentosCN();
            dta_consulta = objOperacionDocumento.F_TCDocumentos_ListarCompras();

            ddl_combodocumento.Items.Clear();

            ddl_combodocumento.DataSource = dta_consulta;
            ddl_combodocumento.DataTextField = "Descripcion";
            ddl_combodocumento.DataValueField = "CodDoc";
            ddl_combodocumento.DataBind();

            dta_consulta = (new CajaFisicaCN()).F_dtCajaFisica_Listar(1);
            ddl_CajaFisica.Items.Clear();
            ddl_CajaFisica.DataSource = dta_consulta;
            ddl_CajaFisica.DataTextField = "Descripcion";
            ddl_CajaFisica.DataValueField = "CodCajaFisica";
            ddl_CajaFisica.DataBind();
        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {
            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);
        }

        public void P_Inicializar_GrillaVacia_ConsultaArticulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));//
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));//
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));//
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));//
            dta_consultaarticulo.Columns.Add("UM", typeof(string));//
            dta_consultaarticulo.Columns.Add("CostoMercado", typeof(string));//
            dta_consultaarticulo.Columns.Add("CodTipoProducto", typeof(string));//
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));//
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));//
            dta_consultaarticulo.Columns.Add("Medida", typeof(string));//
            dta_consultaarticulo.Columns.Add("Chala1", typeof(string));//
            dta_consultaarticulo.Columns.Add("Chala2", typeof(string));//
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
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("Redondeo", typeof(string));
            dta_consultaarticulo.Columns.Add("FactorRedondeo", typeof(string));

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

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();

            ////columnas invisibles
            //try
            //{
            //    int iCodEmpresa = 3;
            //    DataTable dta_consulta = (new TCEmpresaCN()).F_TCEmpresa_Listar(new TCEmpresaCE() { CodEmpresa = iCodEmpresa });
            //    DataTable dta_talmacenes = (new TCAlmacenCN()).F_TCAlmacen_Listar(new TCAlmacenCE() { CodEmpresa = iCodEmpresa });
            //    try
            //    {
            //        //columna UM (8)
            //        if (Convert.ToInt32(dta_consulta.Rows[0]["P_MOSTRAR_UM_CONSULTAS"].ToString()) == 0)
            //            grvConsultaArticulo.Columns[9].Visible = false;

            //        //columnas de ALMACENES (6 y 7)
            //        try
            //        {
            //            try
            //            {
            //                try { grvConsultaArticulo.Columns[8].HeaderText = dta_talmacenes.Rows[1]["P_TITULO_VTAS"].ToString(); }
            //                catch (Exception) { }
            //                if (dta_talmacenes.Rows[1]["P_MOSTRAR_VTAS"].ToString() == "0")
            //                {
            //                    grvConsultaArticulo.Columns[8].Visible = false;
            //                }
            //            }
            //            catch (Exception) { grvConsultaArticulo.Columns[8].Visible = false; }

            //            try
            //            {
            //                try { grvConsultaArticulo.Columns[7].HeaderText = dta_talmacenes.Rows[0]["P_TITULO_VTAS"].ToString(); }
            //                catch (Exception) { }
            //                if (dta_talmacenes.Rows[0]["P_MOSTRAR_VTAS"].ToString() == "0")
            //                {
            //                    grvConsultaArticulo.Columns[7].Visible = false;
            //                }
            //            }
            //            catch (Exception) { }
            //        }
            //        catch (Exception exxxx) { }

            //        //columna MEDIDA (5)
            //        if (Convert.ToInt32(dta_consulta.Rows[0]["P_MEDIDA"].ToString()) == 0)
            //            grvConsultaArticulo.Columns[6].Visible = false;
            //    }
            //    catch (Exception ex)
            //    { }
            //}
            //catch (Exception exx)
            //{ }
        }

        public void P_Inicializar_GrillaVacia_DetalleArticulo()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalleOC", typeof(string));
            dta_consultadetalle.Columns.Add("Serie", typeof(string));
            dta_consultadetalle.Columns.Add("Marca", typeof(string));
            dta_consultadetalle.Columns.Add("Costo", typeof(string));
            dta_consultadetalle.Columns.Add("NroRow", typeof(string));

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
            dtr_filadetalle[9] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();

        }

        public void P_Inicializar_GrillaVacia_ConsultaFactura()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();


            dta_consulta.Columns.Add("ID", typeof(string));
            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Documento", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Ingreso", typeof(string));
            dta_consulta.Columns.Add("Vcto", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("Dscto", typeof(string));
            dta_consulta.Columns.Add("SubTotal", typeof(string));
            dta_consulta.Columns.Add("Igv", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("TipoCambio", typeof(string));
            dta_consulta.Columns.Add("Anexo", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Condicion", typeof(string));
            dta_consulta.Columns.Add("Periodo", typeof(string));
            dta_consulta.Columns.Add("FechaCancelacion", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("CodTipoDoc", typeof(string));
            dta_consulta.Columns.Add("CodMoneda", typeof(string));
            dta_consulta.Columns.Add("Motorizado", typeof(string));

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
            dtr_filaconsulta[16] = "";
            dtr_filaconsulta[17] = "";
            dtr_filaconsulta[18] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
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
            dta_consultadetalleoc.Columns.Add("SerieDocSust", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDocSust", typeof(string));
            dta_consultadetalleoc.Columns.Add("Fecha", typeof(string));
            dta_consultadetalleoc.Columns.Add("StockActual", typeof(string));
            dta_consultadetalleoc.Columns.Add("Costo", typeof(string));


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

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvDetalleOC.DataSource = dta_consultadetalleoc;
            grvDetalleOC.DataBind();
        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoProducto"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.CodFamilia = Convert.ToString(objTablaFiltro["Filtro_CodFamilia"]);

            objOperacion = new LGProductosCN();

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

            objEntidad.CodGuia = Convert.ToInt32(objTablaFiltro["Filtro_CodGuia"]);
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"])) + "'";
                XmlDetalle = XmlDetalle + " PrecioDscto = '" + item.Precio / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"])) + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CodUm = '" + item.CodUm + "'";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " OC = '" + item.OC + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + item.CodTipoDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }


            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";
            XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

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
            ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal TotalDscto, ref Int32 FlagCSIgv)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;
            objEntidad = new DocumentoVentaCabCE();
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                if (FlagCSIgv == 0)
                    objEntidad.Igv = 1;
                else
                    objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"]);

                objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
                objEntidad.Tasa = Convert.ToDecimal(objTablaFiltro["Filtro_Tasa"]);
                objEntidad.CodDocumentoVenta = Codigo;

                dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                for (int j = 0; j < dta_consulta.Rows.Count; j++)
                {
                    TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    TotalDscto += Convert.ToDecimal(dta_consulta.Rows[j]["Dscto"]);
                }
                TotalFactura -= TotalDscto;
                if (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"]) == 1)
                    TotalFactura = TotalFactura * Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);

                SubTotalFactura = (TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]));
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();
            int iCodEmpresa = 3;

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDocSust = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDocSust = Convert.ToString(objTablaFiltro["Filtro_SerieDocSust"]);
            objEntidad.NumeroDocSust = Convert.ToString(objTablaFiltro["Filtro_NumeroDocSust"]);

            objEntidad.FechaIngreso = Convert.ToDateTime(objTablaFiltro["Filtro_FechaIngreso"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_FechaRegistro"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);

            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.ImpSubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_ImpSubTotal"]);
            objEntidad.ImpIGV = Convert.ToDecimal(objTablaFiltro["Filtro_ImpIGV"]);

            objEntidad.ImpTotal = Convert.ToDecimal(objTablaFiltro["Filtro_ImpTotal"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.Descuento = Convert.ToDecimal(objTablaFiltro["Filtro_Descuento"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);

            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.Periodo = Convert.ToInt32(objTablaFiltro["Filtro_Periodo"]);
            objEntidad.Vencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodDetalle"]);
            objEntidad.TasaIgv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.CodClasificacion = Convert.ToInt32(objTablaFiltro["Filtro_CodClasificacion"]);
            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.FlagIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]);

            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]) - (Convert.ToDecimal(objTablaFiltro["Filtro_Total"]) / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"])));
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]) / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);
            objEntidad.FlagPercepcion = Convert.ToInt32(objTablaFiltro["Filtro_FlagPercepcion"]);

            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);
            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.NroDni = Convert.ToString(objTablaFiltro["Filtro_NroDni"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);

            objEntidad.Guia = Convert.ToString(objTablaFiltro["Filtro_Guia"]);

            objEntidad.CodCajaFisica = Convert.ToInt32(objTablaFiltro["Filtro_CodCajaFisica"]);
            objEntidad.Motorizado = Convert.ToInt32(objTablaFiltro["Filtro_Motorizado"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]) == 12)
                objEntidad.FlagLetra = 1;
            else
                objEntidad.FlagLetra = 0;

            objEntidad.CodFacturaAnterior = Convert.ToInt32(objTablaFiltro["Filtro_CodFacturaAnterior"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_NotaIngresoSalidaCab_Insert(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodTipoOperacion = 2;
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = 7;
            objEntidad.CodTipoDocSust = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDocSust"]);
            objEntidad.CodClasificacion = Convert.ToInt32(objTablaFiltro["Filtro_CodClasificacion"]);
            objEntidad.FormaPago = Convert.ToString(objTablaFiltro["Filtro_FormaPago"]);
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
                objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCtaCte = 0;

            objOperacion = new NotaIngresoSalidaCabCN();

            dta_consulta = objOperacion.F_NotaIngresoSalidaCab_Select_Compras(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();


            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));


            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_Anulacion_NotaIngreso(objEntidad);

            Mensaje = objEntidad.MsgError;



        }

        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
                TC = 0;
            else
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);


        }

        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodDocumentoVenta = Codigo;

            dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);

            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }

        public void P_EditarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.Periodo = Convert.ToInt32(objTablaFiltro["Filtro_Periodo"]);
            objEntidad.Motorizado = Convert.ToInt32(objTablaFiltro["Filtro_FlagMotorizado"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_NotaIngresoSalidaCab_Update(objEntidad);


        }

        public void P_ActualizarPrecios(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Precio = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.Cantidad = Convert.ToDecimal(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_ActualizarDetalle(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.FlagIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Actualizar(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_ValidarFactura(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            Mensaje = objOperacion.F_NotaIngresoSalidaCab_Validar_Factura(objEntidad).MsgError;
        }

        public void P_ReemplazarFactura(Hashtable objTablaFiltro,
            ref String NroRuc, ref Int32 Codigo, ref Int32 CodCtaCte,
            ref Int32 CodMoneda, ref String Proveedor, ref Int32 CodFormaPago, ref Int32 CodFacturaAnterior,
            ref String NumeroDoc, ref String FechaEmision, ref String FechaVencimiento, ref String SerieDoc,
            ref Int32 CodCategoria, ref Int32 FlagPercepcion, ref Int32 Periodo, ref Int32 CodClasificacion,
            ref Int32 CodTasa, ref decimal Sutotal, ref decimal Igv, ref decimal Total, ref decimal Descuento,
            ref Int32 CodDireccion, ref Int32 CodDepartamento, ref Int32 CodProvincia, ref Int32 CodDistrito,
            ref String Distrito, ref String NumeroGuia, ref Int32 FlagMotorizado, ref Int32 FlagCSIgv
        )
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new NotaIngresoSalidaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NotaIngresoSalidaCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                NroRuc = dtTabla.Rows[0]["NroRuc"].ToString();
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodCtaCte = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                Proveedor = Convert.ToString(dtTabla.Rows[0]["Proveedor"]);
                CodFormaPago = Convert.ToInt32(dtTabla.Rows[0]["CodFormaPago"]);
                CodFacturaAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodFacturaAnterior"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                FechaEmision = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                FechaVencimiento = Convert.ToString(dtTabla.Rows[0]["FechaVencimiento"]);
                CodCategoria = Convert.ToInt32(dtTabla.Rows[0]["CodCategoria"]);
                FlagPercepcion = Convert.ToInt32(dtTabla.Rows[0]["FlagPercepcion"]);
                Periodo = Convert.ToInt32(dtTabla.Rows[0]["Periodo"]);
                CodClasificacion = Convert.ToInt32(dtTabla.Rows[0]["CodClasificacion"]);
                CodTasa = Convert.ToInt32(dtTabla.Rows[0]["CodTasa"]);
                Sutotal = Convert.ToDecimal(dtTabla.Rows[0]["ImpSubTotal"]);
                Igv = Convert.ToDecimal(dtTabla.Rows[0]["ImpIgv"]);
                Total = Convert.ToDecimal(dtTabla.Rows[0]["ImpTotal"]);
                Descuento = Convert.ToDecimal(dtTabla.Rows[0]["Descuento"]);
                CodDireccion = Convert.ToInt32(dtTabla.Rows[0]["CodDireccion"]);
                Distrito = Convert.ToString(dtTabla.Rows[0]["Distrito"]);
                NumeroGuia = Convert.ToString(dtTabla.Rows[0]["NumeroGuia"]);
                FlagMotorizado = Convert.ToInt32(dtTabla.Rows[0]["FlagMotorizado"]);
                FlagCSIgv = Convert.ToInt32(dtTabla.Rows[0]["FlagCSIgv"]);
            }
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
                NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();
                NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();

                //consulta a la base de datos y se llena grid
                objEntidad.Codigo = Convert.ToInt32(Codigo);
                objEntidad.CodTipoDoc = Convert.ToInt32(CodTipoDoc);
                grvDetalleAuditoria.DataSource = objOperacion.F_AUDITORIA_NOTAINGRESO(objEntidad);
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
                NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();
                NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodDocumentoVenta = Convert.ToInt32(Codigo);
                objEntidad.CodTipoDoc = Convert.ToInt32(CodTipoDoc);
                grvDetalleObservacion.DataSource = objOperacion.F_NOTADEINGRESO_OBSERVACION(objEntidad);
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




    }
}