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

namespace SistemaInventario.Ventas
{
    public partial class RegistroCobranzas : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {

            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_Factura_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_Factura_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_AgregarLetraTemporal_NET);
            CallbackManager.Register(F_ListarNroCuenta_NET);
            CallbackManager.Register(F_TipoCambio_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

          P_Inicializar_GrillaVacia_Factura();
          P_Inicializar_GrillaVacia_Consulta();
          Session["datos"] = true;
        }


          public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_moneda_html = "";
            String str_ddl_mediopago_html = "";
            String str_ddl_banco_html = "";
            String str_ddl_nrocuenta_html = "";
            String str_ddl_serieconsulta_html = "";

            decimal TC = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlMoneda, ref ddlMedioPago, ref ddlBanco,ref ddlSerieConsulta);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                P_ListarNroCuenta(obj_parametros, ref ddlCuenta);

                str_ddl_mediopago_html = Mod_Utilitario.F_GetHtmlForControl(ddlMedioPago);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_banco_html = Mod_Utilitario.F_GetHtmlForControl(ddlBanco);
                str_ddl_nrocuenta_html = Mod_Utilitario.F_GetHtmlForControl(ddlCuenta);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);

                //str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);

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
                TC.ToString()
                + "~" +
                str_ddl_mediopago_html
                + "~" +
                str_ddl_banco_html
                + "~" +
                str_ddl_nrocuenta_html
                + "~" +
                str_ddl_serieconsulta_html;
                

            return str_resultado;

        }

        public String F_Buscar_Factura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaFactura_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Cargar_Grilla(obj_parametros, ref grvConsultaFactura);
                if (grvConsultaFactura.Rows.Count == 0)
                    P_LlenarGrillaVacia_ConsultaFactura();

                str_grvConsultaFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaFactura);


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
                str_grvConsultaFactura_html;

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
                P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                if (grvFactura.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Factura();

                str_grvDetalleFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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
                P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                if (grvFactura.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Factura();
                str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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
            String str_numerofactura = "";
            String str_grvFactura_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError);
                P_Inicializar_GrillaVacia_Factura();
                str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
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
                str_numerofactura
                + "~" +
                str_grvFactura_html;


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            String str_grvLetra_html = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia_Factura();
                str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
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
                str_grvFactura_html;


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

        public String F_CargarGrillaVaciaConsultaArticulo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsuArticulo_html = "";
            int int_resultado_operacion = 0;

            try
            {

                P_LlenarGrillaVacia_ConsultaFactura();
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaFactura);
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
                P_ListarNroCuenta(obj_parametros, ref ddlCuenta);
                str_ddl_nrocuenta_html = Mod_Utilitario.F_GetHtmlForControl(ddlCuenta);         
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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combomoneda, ref DropDownList ddl_combomediopago,
                                            ref DropDownList ddl_combobanco, ref DropDownList ddl_combofactura)
        {

            DataTable dta_consulta = null;

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            
            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodDoc = 1;
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofactura.Items.Clear();

            ddl_combofactura.DataSource = dta_consulta;
            ddl_combofactura.DataTextField = "SerieDoc";
            ddl_combofactura.DataValueField = "CodSerie";
            ddl_combofactura.DataBind();

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

            objEntidadConceptosDet.CodConcepto = 23;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomediopago.Items.Clear();

            ddl_combomediopago.DataSource = dta_consulta;
            ddl_combomediopago.DataTextField = "DscAbvConcepto";
            ddl_combomediopago.DataValueField = "CodConcepto";
            ddl_combomediopago.DataBind();

            BancosCN objOperacionBancos = new BancosCN();

            dta_consulta = null;

            dta_consulta = objOperacionBancos.F_Listar_Bancos();

            ddl_combobanco.Items.Clear();

            ddl_combobanco.DataSource = dta_consulta;
            ddl_combobanco.DataTextField = "DscBanco";
            ddl_combobanco.DataValueField = "CodBanco";
            ddl_combobanco.DataBind();

        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
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
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);



        }

        public void P_Inicializar_GrillaVacia_Factura()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Detalle", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Factura", typeof(string));
            dta_consultaarticulo.Columns.Add("Emision", typeof(string));
            dta_consultaarticulo.Columns.Add("Total", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvFactura.DataSource = dta_consultaarticulo;
            grvFactura.DataBind();

        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodFactura", typeof(string));
            dta_consultaarticulo.Columns.Add("Factura", typeof(string));
            dta_consultaarticulo.Columns.Add("NroRuc", typeof(string));
            dta_consultaarticulo.Columns.Add("Cliente", typeof(string));
            dta_consultaarticulo.Columns.Add("Emision", typeof(string));
            dta_consultaarticulo.Columns.Add("Total", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));
            dta_consultaarticulo.Columns.Add("Medio", typeof(string));
            dta_consultaarticulo.Columns.Add("Banco", typeof(string));
            dta_consultaarticulo.Columns.Add("Cuenta", typeof(string));
            dta_consultaarticulo.Columns.Add("NroOperacion", typeof(string));
            dta_consultaarticulo.Columns.Add("TC", typeof(string));

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

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();


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

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            


            //switch (Convert.ToInt32(objTablaFiltro["Filtro_CodMedioPago"]))
            //{ 
            //    case 1:
            //        objEntidad.CodBanco = 0;
            //        objEntidad.CodCtaBancaria = 0;
            //        objEntidad.NroOperacion = "";
            //        break;

            //    case 2-3:
            //          objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);
            //          objEntidad.CodCtaBancaria = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaBancaria"]);
            //          objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            //        break;

            //    case 4:
            //        objEntidad.CodBanco = 0;
            //        objEntidad.CodCtaBancaria = 0;
            //        objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            //        break;
            //}
            objEntidad.CodigoTemporal = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodMedioPago = Convert.ToInt32(objTablaFiltro["Filtro_CodMedioPago"]);
            objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.FechaOperacion = Convert.ToDateTime(objTablaFiltro["Filtro_FechaOperacion"]);
            objEntidad.CodEstado = 1;
            objEntidad.Responsable = Convert.ToString(objTablaFiltro["Filtro_Responsable"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);
            objEntidad.CodCtaBancaria = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaBancaria"]);
            objEntidad.Monto = Convert.ToDecimal(objTablaFiltro["Filtro_Monto"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_Cobranzas_RegistroCobranzas(objEntidad);

            MsgError = objEntidad.MsgError;


        }

        public void P_LlenarGrillaVacia_Detalle()
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

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            //grvDetalleArticulo.DataSource = dta_consultadetalle;
            //grvDetalleArticulo.DataBind();

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            //


            objEntidad = new DocumentoVentaCabCE();
            

           
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkSerie"]) == 1)
                objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            else
                objEntidad.SerieDoc = "";

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

            dta_consulta = objOperacion.F_Cobranzas_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodCobranza = Convert.ToInt32(objTablaFiltro["Filtro_CodCobranza"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_Cobranzas_Anulacion(objEntidad);

            Mensaje = objEntidad.MsgError;
            
        }

        public void P_LlenarGrillaVacia_ConsultaFactura()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Factura", typeof(string));
            dta_consultaarticulo.Columns.Add("Emision", typeof(string));
            dta_consultaarticulo.Columns.Add("Total", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaFactura.DataSource = dta_consultaarticulo;
            grvConsultaFactura.DataBind();

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

        public void P_ListarNroCuenta(Hashtable objTablaFiltro,ref DropDownList ddl_combonrocuenta)
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
    }
}