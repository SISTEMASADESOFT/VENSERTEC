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
using System.Web.Services;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Net;

namespace SistemaInventario.Ventas
{
    public partial class RegistroNotaCredito : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_FacturacionNotaCredito_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_EditarTemporal_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_ImprimirFacturaTicket_NET);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia_Consulta();
            P_Inicializar_GrillaVacia_Detalle();
            P_Inicializar_GrillaVacia_Serie();
            Session["datos"] = true;
        }


        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();
                GridView grvDetalle = null;
                HiddenField lblCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (HiddenField)(e.Row.FindControl("lblcodigo"));
                if (lblCodigo.Value.ToString() != "")
                {
                    objEntidad.CodDocumentoVenta = Convert.ToInt32(lblCodigo.Value.ToString());
                    grvDetalle.DataSource = objOperacion.F_DocumentoVentaDet_Listar(objEntidad);
                    grvDetalle.DataBind();
                }
            }
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_moneda_html = "";
            String str_ddl_serie_html = "";
            String str_ddl_tipooperaciones_html = "";
            String str_ddl_serieconsulta_html = "";
            String str_ddl_igv_html = "";
            String str_ddlTipoDocumento_html = "";
            String str_ddlFormaPago_html = "";
            String str_numerofactura = "";
            Decimal TC = 0;

            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlMoneda, ref ddlSerie, ref ddlSerieConsulta, ref ddlTipoOperaciones, ref ddlIgv,
                    ref ddlFormaPago, ref ddlTipoDocumento);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);

                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_tipooperaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoOperaciones);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);
                str_ddlFormaPago_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPago);
                str_ddlTipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento);

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
                str_ddl_moneda_html
                + "~" +
                str_ddl_serie_html
                + "~" +
                str_ddl_tipooperaciones_html
                + "~" +
                str_ddl_serieconsulta_html
                + "~" +
                str_numerofactura
                 + "~" +
                TC.ToString()
                + "~" +
                str_ddl_igv_html
                 + "~" +
                str_ddlFormaPago_html
                + "~" +
                str_ddlTipoDocumento_html;


            return str_resultado;

        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleFactura_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                //P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                //if (grvFactura.Rows.Count == 0)
                //    P_Inicializar_GrillaVacia_Factura();

                //str_grvDetalleFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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
                str_grvDetalleFactura_html
                 + "~" +
                Math.Round(Total, 2).ToString();

            return str_resultado;

        }

        public String F_EliminarTemporal_Factura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal_Factura(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                //P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                //if (grvFactura.Rows.Count == 0)
                //    P_Inicializar_GrillaVacia_Factura();
                //str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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
                str_grvFactura_html
                 + "~" +
               Math.Round(Total, 2).ToString();

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;
            int Codigo = 0;
            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion, out Codigo);
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
                Codigo.ToString();

            return str_resultado;
        }

        public String F_FacturacionNotaCredito_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            String Cliente = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            int CodCtaCte = 0;
            int CodMoneda = 0;
            int CodDocumentoVenta = 0;
            decimal SubTotal = 0;
            decimal Igv = 0;
            decimal Total = 0;
            decimal Acuenta = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionCotizacion(obj_parametros, ref str_mensaje_operacion, ref Codigo, ref CodCtaCte, ref CodMoneda,
                   ref SubTotal, ref Igv, ref Total, ref Cliente, ref CodDocumentoVenta);

                if (str_mensaje_operacion == "")
                    P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta);

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
                    Codigo.ToString()
                     + "~" +
                    CodCtaCte.ToString()
                     + "~" +
                    CodMoneda.ToString()
                      + "~" +
                   SubTotal.ToString()
                     + "~" +
                    Igv.ToString()
                     + "~" +
                    Total.ToString()
                     + "~" +
                      Cliente
                      + "~" +
                    str_grvDetalleArticulo_html
                      + "~" +
                    CodDocumentoVenta.ToString()
                    + "~" +
                    Acuenta.ToString();

            return str_resultado;
        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia_Detalle();
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
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
                str_numerofactura
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
                    P_Inicializar_GrillaVacia_Consulta();
                    str_mensaje_operacion = "No se encontraron registros.";
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

        public String F_AgregarLetraTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvLetra_html = "";
            Decimal Total = 0;
            int int_resultado_operacion = 0;
            int Codigo = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarLetraTemporal(obj_parametros, ref MsgError, ref Codigo);



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
                str_grvLetra_html
                + "~" +
                Total.ToString();


            return str_resultado;

        }

        public String F_ListarNroCuenta_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddl_nrocuenta_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //P_ListarNroCuenta(obj_parametros, ref ddlSerie);
                //str_ddl_nrocuenta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
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
                str_ddl_nrocuenta_html;

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
            Decimal Acuenta = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta);
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
                Math.Round(Acuenta, 2).ToString();

            return str_resultado;

        }

        public String F_EditarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta);
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
               Total.ToString()
                + "~" +
                Igv.ToString()
                 + "~" +
                SubTotal.ToString()
                + "~" +
                Acuenta.ToString();

            return str_resultado;

        }

        public String F_BuscarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            String str_grvSerieDetalle_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                P_Inicializar_GrillaVacia_Serie();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                str_grvSerieDetalle_html = Mod_Utilitario.F_GetHtmlForControl(grvSerieDetalle);
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
                str_grvSerieDetalle_html
                 + "~" +
                Math.Round(Acuenta, 2).ToString();

            return str_resultado;
        }

        public String F_Mostrar_Correlativo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numero = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numero);

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
                str_numero;

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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combomoneda,
            ref DropDownList ddl_comboserie, ref DropDownList ddl_comboserieconsulta,
            ref DropDownList ddl_combotipooperaciones, ref DropDownList ddl_comboigv,
            ref DropDownList ddl_comboformapago, ref DropDownList ddl_combodocumento
                                            )
        {
            DataTable dta_consulta = null;

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodDoc = 3;
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.Estado = "A";

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserie.Items.Clear();

            ddl_comboserie.DataSource = dta_consulta;
            ddl_comboserie.DataTextField = "SerieDoc";
            ddl_comboserie.DataValueField = "CodSerie";
            ddl_comboserie.DataBind();

            ddl_comboserieconsulta.Items.Clear();

            objEntidad.Estado = "";

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserieconsulta.DataSource = dta_consulta;
            ddl_comboserieconsulta.DataTextField = "SerieDoc";
            ddl_comboserieconsulta.DataValueField = "CodSerie";
            ddl_comboserieconsulta.DataBind();

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

            dta_consulta = null;

            DocumentoVentaCabCN objOperacionNC = new DocumentoVentaCabCN();

            dta_consulta = objOperacionNC.F_OperacionNC_Listar();

            ddl_combotipooperaciones.Items.Clear();

            ddl_combotipooperaciones.DataSource = dta_consulta;
            ddl_combotipooperaciones.DataTextField = "DscOperacion";
            ddl_combotipooperaciones.DataValueField = "CodTipoOperacion";
            ddl_combotipooperaciones.DataBind();

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
            dta_consulta = objOperacionDocumento.F_TCDocumentos_ListarVentas_FacturaBoleta();

            ddl_combodocumento.Items.Clear();

            ddl_combodocumento.DataSource = dta_consulta;
            ddl_combodocumento.DataTextField = "Descripcion";
            ddl_combodocumento.DataValueField = "CodDoc";
            ddl_combodocumento.DataBind();
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
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("Guia", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("CodTraslado", typeof(string));
            dta_consulta.Columns.Add("Documento", typeof(string));
            dta_consulta.Columns.Add("Proforma", typeof(string));
            dta_consulta.Columns.Add("Factura", typeof(string));
            dta_consulta.Columns.Add("EstatusSunat", typeof(string));
            dta_consulta.Columns.Add("CorreoSunat", typeof(string));
            dta_consulta.Columns.Add("CodTipoDoc", typeof(string));

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
      
            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_Inicializar_GrillaVacia_Detalle()
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
            dta_consultadetalle.Columns.Add("Acuenta", typeof(string));
            dta_consultadetalle.Columns.Add("Marca", typeof(string));

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

        public void P_Inicializar_GrillaVacia_Serie()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("ID", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodDetDocumentoVenta", typeof(string));
            dta_consultadetalleoc.Columns.Add("Serie", typeof(string));

            dtr_filadetalle = dta_consultadetalleoc.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvSerieDetalle.DataSource = dta_consultadetalleoc;
            grvSerieDetalle.DataBind();
        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);

            objOperacion = new DocumentoVentaCabCN();

            grvConsulta.DataSource = objOperacion.F_DocumentoVentaCab_ConsultaCobranzas(objEntidad);
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaCabCE();


            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodigoFactura = '" + item.CodigoFactura + "'";
                XmlDetalle = XmlDetalle + " Factura = '" + item.Factura + "'";
                XmlDetalle = XmlDetalle + " Emision = '" + item.Emision + "'";
                XmlDetalle = XmlDetalle + " Total = '" + item.Total + "'";
                XmlDetalle = XmlDetalle + " Moneda = '" + item.Moneda + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new DocumentoVentaCabCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalCodigoFacturaCab_Insert(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalCodigoFacturaDet_Insert(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }
            MsgError = objEntidad.MsgError;
        }

        public void P_EliminarTemporal_Factura(Hashtable objTablaFiltro, ref String MsgError)
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

            objOperacion.F_TemporalCodigoFacturaDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_CargarGrillaTemporal_Factura(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
           ref Decimal TotalFactura)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                objEntidad.CodDocumentoVenta = Codigo;
                dta_consulta = objOperacion.F_TemporalCodigoFacturaDet_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Total"]);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, out int Codigo)
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
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodFactura_Asociada = Convert.ToInt32(objTablaFiltro["Filtro_CodFactura_Asociada"]);
            objEntidad.CodTipoOperacionNC = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacionNC"]);
            objEntidad.Cliente = Convert.ToString(objTablaFiltro["Filtro_Cliente"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.CodDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodDetalle"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.Acuenta = Convert.ToDecimal(objTablaFiltro["Filtro_Acuenta"]);
            objEntidad.IP = GetIP();
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_NotaCredito_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
            Codigo = objEntidad.CodDocumentoVenta;
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

            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_DocumentoVentaCab_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_Anulacion_NotaCredito(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_AgregarLetraTemporal(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();

            String XmlDetalle = "";

            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.Numero = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);
            objEntidad.Moneda = Convert.ToString(objTablaFiltro["Filtro_Moneda"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodFactura = '" + item.CodFactura + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LetrasCabCN();

            objOperacion.F_TemporalLetraCab_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Cargar_Grilla_Letras(Hashtable objTablaFiltro, ref GridView grvConsulta, ref Decimal Totalletra)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            String XmlDetalle = "";
            objEntidad = new LetrasCabCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlConsulta"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodFactura = '" + item.CodFactura + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LetrasCabCN();

            grvConsulta.DataSource = objOperacion.F_TemporalLetraCab_Listar(objEntidad);
            grvConsulta.DataBind();

            if (grvConsulta.Rows.Count > 0)
            {
                for (int j = 0; j < grvConsulta.Rows.Count; j++)
                    Totalletra += Convert.ToDecimal(grvConsulta.Rows[j].Cells[5].Text);
            }
        }

        public void P_ListarNroCuenta(Hashtable objTablaFiltro, ref DropDownList ddl_combonrocuenta)
        {
            BancosCE objEntidad = null;
            BancosCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new BancosCE();

            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);

            objOperacion = new BancosCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_NroCuenta(objEntidad);

            ddl_combonrocuenta.Items.Clear();

            ddl_combonrocuenta.DataSource = dta_consulta;
            ddl_combonrocuenta.DataTextField = "NumeroCuenta";
            ddl_combonrocuenta.DataValueField = "CodCuenta";
            ddl_combonrocuenta.DataBind();
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

        public void P_FacturacionCotizacion(Hashtable objTablaFiltro, ref String Mensaje, ref Int32 Codigo, ref Int32 CodCtaCte,
           ref Int32 CodMoneda, ref Decimal SubTotal, ref Decimal Igv, ref Decimal Total, ref String Cliente, ref Int32 CodDocumentoVenta)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodTipoOperacionNC = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacionNC"]);
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_ListarXCodigo_NotaCredito(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                CodDocumentoVenta = Convert.ToInt32(dta_consulta.Rows[0][0]);
                CodCtaCte = Convert.ToInt32(dta_consulta.Rows[0][1]);
                CodMoneda = Convert.ToInt32(dta_consulta.Rows[0][2]);
                Cliente = Convert.ToString(dta_consulta.Rows[0][11]);
                objEntidad.CodDocumentoVenta = CodDocumentoVenta;

                objOperacion.F_DocumentoVentaDet_InsertTemporal(objEntidad);

                Codigo = objEntidad.Codigo;
            }
            else
                Mensaje = "No se encontraron registros";
        }

        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
        ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal Acuenta)
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
                        Acuenta += Convert.ToDecimal(dta_consulta.Rows[j]["Acuenta"]);
                    }
                }
                SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
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

        public void P_EditarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Precio = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.Cantidad = Convert.ToDecimal(objTablaFiltro["Filtro_Cantidad"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Editar(objEntidad);
        }

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero)
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
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumDoc"]);
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_Eliminacion_NotaCredito(objEntidad);

            Mensaje = objEntidad.MsgError;
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

        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }
    
    }
}