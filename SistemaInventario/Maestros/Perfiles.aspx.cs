using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using CapaNegocios;
using CapaEntidad;
using System.IO;


namespace SistemaInventario.Maestros
{
    public partial class Perfiles : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        { }

        private string _menu = "1000"; private string _opcion = "9";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}

            //Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Session["datos"] = true;

            P_GrabarImagen_Nuevo();
        }

        [WebMethod]
        public static csInicializar F_Inicializar_NET(int CodEstado)
        {
            csInicializar Inicializar = new csInicializar();
            //lleno la lista de usuarios
            Inicializar.lUsuario = F_Usuario_Listar_NET(CodEstado);
            //lleno la lista de menues del sistema
            Inicializar.lMenu = F_Menu_Listar_NET(CodEstado);
            //lleno Lista de Cajas
            Inicializar.lCajas = (new CajaFisicaCN()).F_CajaFisica_Listar(1, Convert.ToInt32(HttpContext.Current.Session["CodSede"].ToString()));

            int CodUsuario = 0; 
            if (Inicializar.lUsuario.Count > 0) 
                CodUsuario = Inicializar.lUsuario[0].CodUsuario;                 
            int CodMenu = 0;
            if (Inicializar.lMenu.Count > 0) 
                CodMenu = Inicializar.lMenu[0].CodigoMenu;

            //lleno lista de permisos por usuario
            Inicializar.lPermisos = F_MenuPaginas_Permisos_Usuarios_NET(CodUsuario, CodMenu);

            return Inicializar;
        }
        public class csInicializar
        {
            public List<UsuarioCE> lUsuario;
            public List<MenuCE> lMenu;
            public List<MenuPaginasCE> lPermisos;
            public List<CajaFisicaCE> lCajas;
        }

        [WebMethod]
        public static List<UsuarioCE> F_Usuario_Listar_NET(int CodEstado)
        {
            UsuarioCN objOperacion = new UsuarioCN();
            return objOperacion.F_Usuario_Listar(Convert.ToInt32(HttpContext.Current.Session["CodSede"].ToString()), CodEstado);
        }

        [WebMethod]
        public static List<MenuCE> F_Menu_Listar_NET(int CodEstado)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_Menu_Listar(CodEstado);
        }

        [WebMethod]
        public static List<MenuPaginasCE> F_MenuPaginas_Permisos_Usuarios_NET(int CodUsuario, int CodigoMenu)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_MenuPaginas_Permisos_Usuarios_NET(CodUsuario, CodigoMenu);
        }

        [WebMethod]
        public static List<CargosCE> F_Cargos_Listar_NET(int CodEstado)
        {
            CargosCN objOperacion = new CargosCN();
            return objOperacion.F_Cargos_Listar(CodEstado);
        }

        [WebMethod]
        public static List<TCConceptosDetCE> F_Conceptos_Listar_NET(int CodPrincipal)
        {
            TCConceptosDetCN objOperacion = new TCConceptosDetCN();
            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE() { CodConcepto = CodPrincipal };
            return objOperacion.F_TCConceptos_Listar(objEntidadConceptosDet);
        }

        [WebMethod]
        public static MenuPaginasCE F_Activar_Permisos_Usuarios_NET(int CodUsuario, int CodigoPagina)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_Activar_Permisos_Usuarios_NET(CodUsuario, CodigoPagina);
        }

        [WebMethod]
        public static MenuPaginasCE F_Desactivar_Permisos_Usuarios_NET(int CodUsuario, int CodigoPagina)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_Desactivar_Permisos_Usuarios_NET(CodUsuario, CodigoPagina);
        }

        [WebMethod]
        public static MenuPaginasCE F_ActivarOtrasOpciones_Permisos_Usuarios_NET(int CodUsuario, int CodigoPagina, string Funcion)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_ActivarOtrasOpciones_Permisos_Usuarios_NET(CodUsuario, CodigoPagina, Funcion);
        }

        [WebMethod]
        public static MenuPaginasCE F_DesactivarOtrasOpciones_Permisos_Usuarios_NET(int CodUsuario, int CodigoPagina, string Funcion)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_DesactivarOtrasOpciones_Permisos_Usuarios_NET(CodUsuario, CodigoPagina, Funcion);
        }

        [WebMethod]
        public static UsuarioCE F_Usuario_Obtener_NET(int CodUsuario, int CodEmpleado)
        {
            UsuarioCN objOperacion = new UsuarioCN();
            UsuarioCE Usuario = objOperacion.F_UsuarioEmpleado_Obtener(CodUsuario, CodEmpleado);
            Usuario.ImagenUsuario = null; //debido a que el json no acepta una longitud de cadena demasiado grande
            return Usuario;
        }

        [WebMethod]
        public static UsuarioCE F_Usuario_Grabar_NET(int CodUsuario, int CodEmpleado,
            string NombreUsuario, string Clave, string ClaveOperacionesEspeciales, string Apellidos, string Nombre, 
            string Tipo, int CodEstado, int CodCargo, string NroDni, int CodCajaFisica, int IdImagen,
            int FlagUsuario, int FlagEmpleado, int FlagEliminarEmpleado, string TipoOperacion)
        {
            UsuarioCN objOperacion = new UsuarioCN();
            UsuarioCE objEntidad = new UsuarioCE()
            {
                CodUsuario = CodUsuario,
                CodEmpleado = CodEmpleado,
                NombreUsuario = NombreUsuario,
                Clave = Clave,
                ClaveOperacionesEspeciales = ClaveOperacionesEspeciales,
                Apellidos = Apellidos,
                Nombre = Nombre,
                Tipo = Tipo,
                CodEstado = CodEstado,
                CodAlmacen = Convert.ToInt32(HttpContext.Current.Session["CodSede"].ToString()),
                Perfil = "",
                CodCargo = CodCargo,
                NroDni = NroDni,
                CodCajaFisica = CodCajaFisica,
                FlagUsuario = FlagUsuario,
                FlagEmpleado = FlagEmpleado,
                FlagEliminarEmpleado = FlagEliminarEmpleado,
                IdImagen = IdImagen,
                TipoOperacion = TipoOperacion
            };
            objEntidad.CodAlmacen = Convert.ToInt32(HttpContext.Current.Session["CodSede"].ToString());
            return objOperacion.F_Usuario_Grabar(objEntidad);
        }



        //Funciones de la Imagen
        public void P_GrabarImagen_Nuevo()
        {
            TCEmpresaCE objEntidadCE = new TCEmpresaCE();
            TCEmpresaCN objOperacion = new TCEmpresaCN();


            bool bol_resultado_operacion = false;


            foreach (string s in Request.Files)
            {
                try
                {

                    HttpPostedFile postedFile = Request.Files[s];
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    if (s.Equals("file1"))
                    {
                        objEntidadCE.B_ImagenTem = bytes;
                    }
                    else
                    {
                        objEntidadCE.B_ImagenTem = bytes;
                    }


                    bol_resultado_operacion = objOperacion.F_AgregarImagen(objEntidadCE);


                }
                catch (Exception ex)
                {

                    throw ex;

                }

            }

        }


        [WebMethod]
        public static jqResult F_UltimaImagenTMP_JS()
        {
            jqResult objResult = new jqResult();

            TCEmpresaCN objOperacion = null;

            try
            {

                String str_mensaje_operacion = string.Empty;

                objOperacion = new TCEmpresaCN();

                objResult.ID_Imagen = objOperacion.F_ConsultarUltimaImagenTemp(out str_mensaje_operacion);
                if (str_mensaje_operacion == string.Empty) objResult.msg = str_mensaje_operacion;
                else
                {
                    objResult.msg = "error 1390 productos.aspx";// RecursoMensajesOperaciones.ObtenerMensaje("MSG_ERROR_SISTEMA") + str_mensaje_operacion;
                    objResult.ID_Imagen = "";
                }

            }
            catch (Exception ex)
            {
                objResult.msg = "error 1397 productos.aspx"; //RecursoMensajesOperaciones.ObtenerMensaje("MSG_ERROR_SISTEMA") + ex.Message.ToString();
                objResult.ID_Imagen = "";
            }
            finally
            {
                objOperacion = null;
            }


            return objResult;
        }

        [WebMethod]
        public static jqResult F_Eliminar_Temporal_Imagen(TCEmpresaCE objEntidad)
        {

            jqResult objResult = new jqResult();

            TCEmpresaCN objOperacion = null;


            try
            {
                objOperacion = new TCEmpresaCN();
                var flag = true;
                String str_mensaje_operacion = string.Empty;

                flag = objOperacion.F_EliminarImagen_Temporal(objEntidad.ID_TemporalImagen, out str_mensaje_operacion);

                if (str_mensaje_operacion == string.Empty)
                {
                    objResult.msg = string.Empty;
                }
                else
                {
                    //objResult.msg = RecursoMensajesOperaciones.ObtenerMensaje("MSG_ERROR_SISTEMA") + str_mensaje_operacion;
                }
            }
            catch (Exception ex)
            {
                //objResult.msg = RecursoMensajesOperaciones.ObtenerMensaje("MSG_ERROR_SISTEMA") + ex.Message.ToString();
            }
            finally
            {
                objOperacion = null;
            }


            return objResult;
        }

        [WebMethod]
        public static jqResult F_Eliminar_Imagen(TCEmpresaCE objEntidad)
        {

            jqResult objResult = new jqResult();

            TCEmpresaCN objOperacion = null;
            try
            {
                objOperacion = new TCEmpresaCN();
                var flag = true;
                String str_mensaje_operacion = string.Empty;

                //flag = objOperacion.F_EliminarImagen(objEntidad.IdImagenProducto1, out str_mensaje_operacion);

                if (str_mensaje_operacion == string.Empty)
                {
                    objResult.msg = string.Empty;
                }
                else
                {
                    //objResult.msg = RecursoMensajesOperaciones.ObtenerMensaje("MSG_ERROR_SISTEMA") + str_mensaje_operacion;
                }
            }
            catch (Exception ex)
            {
                //objResult.msg = RecursoMensajesOperaciones.ObtenerMensaje("MSG_ERROR_SISTEMA") + ex.Message.ToString();
            }
            finally
            {
                objOperacion = null;
            }


            return objResult;
        }


        public class jqResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCEmpresaCE> rows { get; set; }
        }















        //accesos a dispositivos externos
        //ya no lo usan pero esta funcional
        //--------------------------------------------------------------
        [WebMethod]
        public static List<UsuariosDispositivosCE> F_UsuariosDispositivos_Listar_NET(int CodUsuario)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_UsuariosDispositivos_Listar_NET(CodUsuario);
        }
        [WebMethod]
        public static MenuPaginasCE F_Activar_AccesosRemotos_NET(int id)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_Activar_AccesosRemotos_NET(id);
        }
        [WebMethod]
        public static MenuPaginasCE F_Desactivar_AccesosRemotos_NET(int id)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_Desactivar_AccesosRemotos_NET(id);
        }
        [WebMethod]
        public static MenuPaginasCE F_Eliminar_AccesosRemotos_NET(int id)
        {
            MenuCN objOperacion = new MenuCN();
            return objOperacion.F_Eliminar_AccesosRemotos_NET(id);
        }
        //--------------------------------------------------------------
    }
}