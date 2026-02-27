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
//using System.Web.Helpers;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;

namespace SistemaInventario.Inventario
{
    public partial class KardexWilliam : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_EdicionSaldoInicial_NET);
            CallbackManager.Register(F_ConsultaHistorialMovimientos_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grvDetalle = null;
                HiddenField lblCodigo = null;
                HiddenField hfCodTipoOperacion = null;
                ImageButton btnEditarSaldoInicial = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                hfCodTipoOperacion = (HiddenField)(e.Row.FindControl("hfCodTipoOperacion"));
                btnEditarSaldoInicial = (ImageButton)(e.Row.FindControl("imgEditarDocumento"));
  
                if (lblCodigo.Value != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    if (hfCodTipoOperacion.Value != "16")
                        btnEditarSaldoInicial.Visible = false;

                    dta_consultaarticulo.Columns.Add("Observacion", typeof(string));
                
                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();
                }

            }
        }

        public String F_LlenarGridDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;       
            string Observacion = "";
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);            
                Observacion = Convert.ToString(obj_parametros["Filtro_Observacion"]);

                GridView grvDetalle = (GridView)grvKardex.Rows[0].FindControl("grvDetalle");

                DataTable dta_consultadetalle = null;
                DataRow dtr_filadetalle = null;

                dta_consultadetalle = new DataTable();
                dta_consultadetalle.Columns.Add("Observacion", typeof(string));
                dtr_filadetalle = dta_consultadetalle.NewRow();

                dtr_filadetalle[0] = Observacion;
                dta_consultadetalle.Rows.Add(dtr_filadetalle);

                grvDetalle.DataSource = dta_consultadetalle;
                grvDetalle.DataBind();

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
  
        public String F_EdicionSaldoInicial_NET(String arg)
        {
            string str_resultado = "";
            string str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                F_EdicionSaldoInicial(obj_parametros, ref str_mensaje_operacion);

                int_resultado_operacion = 1;
            }
            catch (Exception exxx)
            {
                str_mensaje_operacion = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 0;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion;

            return str_resultado;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_mensaje_operacion = "";
            String str_resultado = "";
            int int_resultado_operacion = 0;
            string FechaInicial = "";
            try
            {
                P_Controles_Inicializar(ref FechaInicial);
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Error Inicializando los parametros.";
                int_resultado_operacion = 1;
            }

            str_resultado =
               Convert.ToString(int_resultado_operacion) + "~" + //00
               str_mensaje_operacion + "~" + //01
               Session["CodSede"].ToString() + "~" +  //02
               FechaInicial;  //03


            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            decimal StockActual = 0;
            decimal CostoUniOriginal = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvKardex, ref StockActual, ref CostoUniOriginal);

                if (grvKardex.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";


                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
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
                str_grvConsulta_html
                   + "~" +
                StockActual.ToString()
                   + "~" +
                CostoUniOriginal.ToString();


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

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
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

        public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            decimal StockActual = 0;
            decimal CostoUniOriginal = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvKardex, ref StockActual, ref CostoUniOriginal);
                if (grvKardex.Rows.Count == 0)
                    P_Inicializar_GrillaVacia();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
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
                str_grvConsulta_html
                + "~" +
                StockActual.ToString()
                 + "~" +
                CostoUniOriginal.ToString();

            return str_resultado;
        }

        public void P_Inicializar_GrillaVacia()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("Codigo", typeof(string));
            dta_consultadetalle.Columns.Add("Operacion", typeof(string));
            dta_consultadetalle.Columns.Add("Registro", typeof(string));
            dta_consultadetalle.Columns.Add("RazonSocial", typeof(string));
            dta_consultadetalle.Columns.Add("Numero", typeof(string));
            dta_consultadetalle.Columns.Add("Costo", typeof(string));
            dta_consultadetalle.Columns.Add("Moneda", typeof(string));
            dta_consultadetalle.Columns.Add("TC", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Inicial", typeof(string));
            dta_consultadetalle.Columns.Add("Ingreso", typeof(string));
            dta_consultadetalle.Columns.Add("Salida", typeof(string));
            dta_consultadetalle.Columns.Add("Final", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Anexo", typeof(string));
            dta_consultadetalle.Columns.Add("FechaAnexo", typeof(string));
            dta_consultadetalle.Columns.Add("CostoSoles", typeof(string));
            dta_consultadetalle.Columns.Add("CostoDolares", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoOperacion", typeof(string));
            dta_consultadetalle.Columns.Add("Observacion", typeof(string));
            dta_consultadetalle.Columns.Add("Usuario", typeof(string));
            dta_consultadetalle.Columns.Add("Codtipodoc", typeof(string));
            dta_consultadetalle.Columns.Add("CodDoc", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoDocNota", typeof(string));

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
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";
            dtr_filadetalle[16] = "";
            dtr_filadetalle[17] = "";
            dtr_filadetalle[18] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvKardex.DataSource = dta_consultadetalle;
            grvKardex.DataBind();


            //try
            //{
            //    int iCodEmpresa = 3;
            //    DataTable dta_consulta = (new TCEmpresaCN()).F_TCEmpresa_Listar(new TCEmpresa() { CodEmpresa = iCodEmpresa });
            //    try
            //    {
            //        //columna UM (8)
            //        if (Convert.ToInt32(dta_consulta.Rows[0]["P_MOSTRAR_UM_CONSULTAS"].ToString()) == 0)
            //            grvKardex.Columns[15].Visible = false;

            //    }
            //    catch (Exception ex)
            //    { }
            //}
            //catch (Exception exx)
            //{ }


        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar, ref Decimal Stock, ref Decimal CostoUniOriginal)
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

            if (dta_consulta.Rows.Count > 0)
            {
                Stock = Convert.ToDecimal(dta_consulta.Rows[0]["StockActual"]);
                CostoUniOriginal = Convert.ToDecimal(dta_consulta.Rows[0]["CostoUniOriginal"]);
            }
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_MOVIMIENTOS_ELIMINARAJUSTES(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void F_EdicionSaldoInicial(Hashtable objTablaFiltro, ref String Mensaje)
        {
            MovimientosCE objEntidad = null;
            MovimientosCN objOperacion = null;

            objEntidad = new MovimientosCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CantidadIng = Convert.ToDecimal(objTablaFiltro["Filtro_CantidadIngreso"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_FechaRegistro"]);

            objOperacion = new MovimientosCN();

            objOperacion.F_Movimientos_Kardex_SaldoInicial_Modificar_William(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_Controles_Inicializar(ref string FechaInicial)
        {
            DataTable dta_Fecha = (new MovimientosCN()).F_Movimientos_Kardex_FechaInicial();
            FechaInicial = dta_Fecha.Rows[0][0].ToString();
        }

        public String F_ConsultaHistorialMovimientos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Int32 int_resultado_operacion = 0;
            String str_grvConsulta_Movimientos_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                F_ConsultaMovimientosAuditoria(obj_parametros, ref grvHistorialMovimientos);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

                str_grvConsulta_Movimientos_html = Mod_Utilitario.F_GetHtmlForControl(grvHistorialMovimientos);
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grvConsulta_Movimientos_html;

            return str_resultado;

        }

        public void F_ConsultaMovimientosAuditoria(Hashtable objTablaFiltro, ref GridView gridMovimiento)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            DataTable dtTabla = null;
            objEntidad = new LGProductosCE();

            objEntidad.codmovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);

            //grid de costos
            objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_LGProductos_HistorialMovimiento(objEntidad);

            gridMovimiento.DataSource = dtTabla;
            gridMovimiento.DataBind();

            //grid de precios
            //objOperacion = new LGProductosCN();
            //dtTabla = objOperacion.F_LGProductos_Auditoria_Listar(objEntidad);

            //gridPrecios.DataSource = dtTabla;
            //gridPrecios.DataBind();

        }
    }
}