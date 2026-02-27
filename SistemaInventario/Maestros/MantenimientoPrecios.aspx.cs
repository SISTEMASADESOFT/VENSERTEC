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
using System.Web.Services;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Maestros
{
    public partial class MantenimientoPrecios : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia();
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_familia_html = "";
            String str_grvConsultaArticulo_html = "";

            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlFamilia);
                P_Cargar_Grilla(obj_parametros, ref grvConsultaArticulo);
                if (grvConsultaArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia();

                str_ddl_familia_html = Mod_Utilitario.F_GetHtmlForControl(ddlFamilia);
                str_grvConsultaArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);

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
                str_ddl_familia_html
                + "~" +
                str_grvConsultaArticulo_html
                + "~" +
                Session["CodUsuario"].ToString()
                + "~" +
                Session["CodSede"].ToString();

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
                    P_Inicializar_GrillaVacia();
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

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaArticulo_html = "";
            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia();
                str_grvConsultaArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsultaArticulo_html;


            return str_resultado;

        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaArticulo_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                
                    P_AgregarTemporal(obj_parametros, ref str_mensaje_operacion);
                    P_Cargar_Grilla(obj_parametros, ref grvConsultaArticulo);
               

                if (grvConsultaArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia();

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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combofamilia)
        {
            DataTable dta_consulta = null;

            LGFamiliasCN objOperacion = null;

            objOperacion = new LGFamiliasCN();

            dta_consulta = objOperacion.F_LGFamilias_Listar();

            ddl_combofamilia.Items.Clear();

            ddl_combofamilia.DataSource = dta_consulta;
            ddl_combofamilia.DataTextField = "DscFamilia";
            ddl_combofamilia.DataValueField = "CodFamilia";
            ddl_combofamilia.DataBind();

            ddl_combofamilia.Items.Insert(0, new ListItem("--Todos--", "0"));
        }

        public void P_Inicializar_GrillaVacia()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodAlterno", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));
            dta_consultaarticulo.Columns.Add("Margen", typeof(string));
            dta_consultaarticulo.Columns.Add("Descuento", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio", typeof(string));
            dta_consultaarticulo.Columns.Add("CostoOriginal", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));

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

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();


        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodFamilia = Convert.ToString(objTablaFiltro["Filtro_CodFamilia"]);
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new LGProductosCN();

            grvConsulta.DataSource = objOperacion.F_LGProductos_ListarProductosPrecios(objEntidad);
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            String XmlDetalle = "";


            int iCodEmpresa = 3;


            objEntidad = new LGProductosCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodProducto = '" + item.CodProducto + "'";
                XmlDetalle = XmlDetalle + " CodAlterno = '" + item.CodAlterno + "'";
                XmlDetalle = XmlDetalle + " CostoMarginable = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " Margen = '" + item.Margen + "'";
                XmlDetalle = XmlDetalle + " Descuento = '" + item.Descuento + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductos_ActualizarDatos(objEntidad);

            MsgError = objEntidad.MsgError;

        }

    }
}