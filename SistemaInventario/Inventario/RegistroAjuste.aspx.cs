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
//using System.Web.Helpers;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Compras
{
    public partial class RegistroAjuste : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_Nuevo_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia();
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
              
              
                if (grvConsultaArticulo.Rows.Count==0)
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

        public String F_Nuevo_NET(String arg)
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

                P_Inicializar_GrillaVacia();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));//
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));//
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));//
            dta_consultaarticulo.Columns.Add("Chala1", typeof(string));
            dta_consultaarticulo.Columns.Add("Chala2", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));//
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));//
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));//
            dta_consultaarticulo.Columns.Add("CodUnidadCompra", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));//
            dta_consultaarticulo.Columns.Add("Factor", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));//
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));//

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
           
            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();

            //columnas invisibles
            try
            {
                int iCodEmpresa = 3;
                DataTable dta_consulta = (new TCEmpresaCN()).F_TCEmpresa_Listar(new TCEmpresaCE() { CodEmpresa = iCodEmpresa });
                DataTable dta_talmacenes = (new TCAlmacenCN()).F_TCAlmacen_Listar_Todos(new TCAlmacenCE() { CodEmpresa = iCodEmpresa });
                try
                {
                    ////columna MEDIDA (5)
                    //if (Convert.ToInt32(dta_consulta.Rows[0]["P_MEDIDA"].ToString()) == 0)
                    //    grvConsultaArticulo.Columns[5].Visible = false;
                    //columna UM (8)
                    if (Convert.ToInt32(dta_consulta.Rows[0]["P_MOSTRAR_UM_CONSULTAS"].ToString()) == 0)
                        grvConsultaArticulo.Columns[6].Visible = false;

                    //columnas de ALMACENES (6 y 7)
                    try
                    {
                        try
                        {
                            try { grvConsultaArticulo.Columns[5].HeaderText = dta_talmacenes.Rows[1]["P_TITULO_VTAS"].ToString(); }
                            catch (Exception) { }
                            if (dta_talmacenes.Rows[1]["P_MOSTRAR_VTAS"].ToString() == "0")
                            {
                                grvConsultaArticulo.Columns[5].Visible = false;
                            }
                        }
                        catch (Exception) { grvConsultaArticulo.Columns[5].Visible = false; }

                        try
                        {
                            try { grvConsultaArticulo.Columns[4].HeaderText = dta_talmacenes.Rows[0]["P_TITULO_VTAS"].ToString(); }
                            catch (Exception) { }
                            if (dta_talmacenes.Rows[0]["P_MOSTRAR_VTAS"].ToString() == "0")
                            {
                                grvConsultaArticulo.Columns[4].Visible = false;
                            }
                        }
                        catch (Exception) { }
                    }
                    catch (Exception exxxx) { }

                }
                catch (Exception ex)
                { }
            }
            catch (Exception exx)
            { }
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

            grvConsulta.DataSource = objOperacion.F_LGProductos_ListarVentas_Descuento(objEntidad);
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
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Ajuste = '" + item.Ajuste + "'";
                XmlDetalle = XmlDetalle + " CodUnidadCompra = '" + item.CodUnidadCompra + "'";
                XmlDetalle = XmlDetalle + " CodUnidadVenta = '" + item.CodUnidadVenta + "'";
                XmlDetalle = XmlDetalle + " Factor = '" + item.Factor + "'";
                XmlDetalle = XmlDetalle + " Observacion = '" + item.Observacion + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LGProductosCN();

            objOperacion.F_LGProductos_Ajuste(objEntidad);
            
            MsgError = objEntidad.MsgError;

        }
    }
}