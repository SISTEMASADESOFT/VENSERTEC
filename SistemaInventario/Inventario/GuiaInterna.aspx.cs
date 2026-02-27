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
    public partial class GuiaInterna : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_Controles_Inicializar_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TrasladosDetCN objOperacion = new TrasladosDetCN();
                TrasladosDetCE objEntidad = new TrasladosDetCE();
                GridView grvDetalle = null;
                Label lblCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (Label)(e.Row.FindControl("lblcodigo"));
                if (lblCodigo.Text != "")
                {
                    objEntidad.CodTraslado = Convert.ToInt32(lblCodigo.Text);
                    grvDetalle.DataSource = objOperacion.F_TrasladosDet_Listar(objEntidad);
                    grvDetalle.DataBind();
                }

                //Convert.ToInt32(e.Row.Cells[1].Text);
            }
        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);

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
                MsgError;

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

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serieconsulta_html = "";

            Int32 Usuario = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSerieConsulta);

                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);

                Usuario = Convert.ToInt32(Session["CodUsuario"]);

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
                str_ddl_serieconsulta_html;

            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboguia)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodDoc = 4;
            objEntidad.CodSede = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboguia.Items.Clear();

            ddl_comboguia.DataSource = dta_consulta;
            ddl_comboguia.DataTextField = "SerieDoc";
            ddl_comboguia.DataValueField = "CodSerie";
            ddl_comboguia.DataBind();

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
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Destino", typeof(string));
            dta_consulta.Columns.Add("Operacion", typeof(string));

            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {

            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodAlmacenPartida = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new TrasladosCabCN();

            objOperacion.F_TrasladosCab_GuiaInterna_Insert(objEntidad);
            MsgError = objEntidad.MsgError;
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodAlmacenPartida = Convert.ToInt32(Session["CodSede"]);
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

            objOperacion = new TrasladosCabCN();

            dta_consulta = objOperacion.F_TrasladosCab_Listar_GuiaInterna(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

    }
}