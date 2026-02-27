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

namespace SistemaInventario.Inventario
{
    public partial class UnionCodigo : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia();
            Session["datos"] = true;
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
                //P_Buscar(obj_parametros, ref grvKardex);

                //if (grvKardex.Rows.Count == 0)
                //{
                //    P_Inicializar_GrillaVacia();
                //    str_mensaje_operacion = "No se encontraron registros.";
                //}
                //else
                //    str_mensaje_operacion = "";


                //str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
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

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia();

               // str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
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
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlTipoOperaciones_html = "";

            Int32 Usuario = 0;
            decimal TC = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

           //     P_Controles_Inicializar(obj_parametros, ref ddlTipoOperaciones);

           //     str_ddlTipoOperaciones_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoOperaciones);

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
                str_ddlTipoOperaciones_html
                + "~" +
                Session["CodSede"].ToString();

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError);
             
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
                str_grvDetalleArticulo_html;


            return str_resultado;

        }

        public void P_Inicializar_GrillaVacia()
        {

            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("ID", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("DscProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Serie", typeof(string));


            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";


            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            //grvDetalleArticulo.DataSource = dta_consultadetalle;
            //grvDetalleArticulo.DataBind();

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            MovimientosCE objEntidad = null;
            MovimientosCN objOperacion = null;

            DataTable dta_consulta = null;


            int iCodEmpresa = 3;

            objEntidad = new MovimientosCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.CodAlterno = Convert.ToString(objTablaFiltro["Filtro_CodAlterno"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);

            objOperacion = new MovimientosCN();

            dta_consulta = objOperacion.F_Movimientos_Kardex(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combooperacion)
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 1;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combooperacion.Items.Clear();

            ddl_combooperacion.DataSource = dta_consulta;
            ddl_combooperacion.DataTextField = "DscAbvConcepto";
            ddl_combooperacion.DataValueField = "CodConcepto";
            ddl_combooperacion.DataBind();
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodProductoCorrecto = Convert.ToInt32(objTablaFiltro["Filtro_CodProductoCorrecto"]);
            objEntidad.CodProductoIncorrecto = Convert.ToInt32(objTablaFiltro["Filtro_CodProductoIncorrecto"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_LGProductos_UnirCodigos(objEntidad);

            MsgError = objEntidad.MsgError;

        }
    }
}