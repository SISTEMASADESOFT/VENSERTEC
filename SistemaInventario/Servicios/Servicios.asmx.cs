using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SistemaInventario.Servicios;
using System.Text.RegularExpressions;
using KeepAutomation.Barcode.Crystal;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaInventario.App_Code
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    public class Servicios : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public UsuarioCE KeepActiveSession()
        {
            bool SesionActiva = true;
            if (HttpContext.Current.Session["datos"] == null | Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) == 0)
                SesionActiva = false;

            UsuarioCE Usuario = new UsuarioCE();

            if (Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) > 0)
            {
                Usuario = (new UsuarioCN()).F_Usuario_Obtener(Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]));

                HttpContext.Current.Session["Usuario"] = Usuario.NombreUsuario;
                HttpContext.Current.Session["Apellidos"] = Usuario.Apellidos;
                HttpContext.Current.Session["Nombre"] = Usuario.Nombre;
                HttpContext.Current.Session["Perfil"] = Usuario.Perfil;
                HttpContext.Current.Session["CodCajaFisica"] = Usuario.CodCajaFisica.ToString();

                DataTable dtEmpresa = (new TCAlmacenCN()).F_TCAlmacen_ObtenerDatos(Convert.ToInt32(HttpContext.Current.Session["CodSede"]));

                HttpContext.Current.Session["CodEmpresa"] = Convert.ToInt32(dtEmpresa.Rows[0]["CodEmpresa"]);
                Usuario.CodEmpresa = Convert.ToInt32(dtEmpresa.Rows[0]["CodEmpresa"]);

                HttpContext.Current.Session["Empresa"] = dtEmpresa.Rows[0]["RazonSocial"];
                Usuario.Empresa = dtEmpresa.Rows[0]["RazonSocial"].ToString();

                HttpContext.Current.Session["Almacen"] = dtEmpresa.Rows[0]["DscAlmacen"];
                Usuario.Almacen = dtEmpresa.Rows[0]["DscAlmacen"].ToString();

                if (Usuario.IdImagen > 0)
                {
                    Session["ImagenUsuario"] = Usuario.ImagenUsuario;
                    Utilitarios.Menu.ImagenUsuario = (byte[])Usuario.ImagenUsuario;
                    Utilitarios.Menu.ImagenUsuarioNombre = Usuario.NombreUsuario + ".jpg";
                    Usuario.ImagenNombre = Usuario.NombreUsuario + ".jpg";
                    Utilitarios.Menu.F_ImagenUsuario();
                }
                else
                {
                    Utilitarios.Menu.ImagenUsuario = null;
                    Utilitarios.Menu.ImagenUsuarioNombre = "../Asset/images/mainuser.png";
                }
            }

            Usuario.ImagenUsuario = null; //debido a que el json no acepta una longitud de cadena demasiado grande
            Usuario.SesionActiva = SesionActiva;
            return Usuario;
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtacte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                    dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                    dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["CodDireccion"]));
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarResponsable_AutoComplete(string NroRuc, string RazonSocial, int Codctacte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            objEntidad.CodCtaCte = Codctacte;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_ListarResponsable_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2}", dtTabla.Rows[i]["ResponsableDNI"], dtTabla.Rows[i]["Responsable"], dtTabla.Rows[i]["cabezera"]));
            return Lista.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarDatosPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.pa_TCCuentaCorriente_BuscarClienteXRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarClientesPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtacte = 1;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.pa_TCCuentaCorriente_BuscarClienteXRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarProveedoresPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.pa_TCCuentaCorriente_BuscarClienteXRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = "";
            objEntidad.CodTipoCtacte = 2;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], R["CodDireccion"],0));


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            //if (dtTabla.Rows.Count == 0)
            //{
            //    dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(ref objEntidad);
                //Error relacionado con la red o específico de la instancia mientras se establecía una conexión con el servidor SQL Server
                //int CodCtaCte = 0; if (objEntidad.MsgError != "")
                    //CodCtaCte = -1;
                //foreach (DataRow R in dtTabla.Rows)
                    //Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", CodCtaCte, R["RazonSocial"], R["Direccion"],
                        //R["Direccion"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                        //R["Ruc"], "", "", "", 0, 0));
            //}
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunatVarios(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtacte = CodTipoCtaCte;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], R["CodDireccion"], 0));


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            if (dtTabla.Rows.Count == 0)
            {
                dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(ref objEntidad);
                //Error relacionado con la red o específico de la instancia mientras se establecía una conexión con el servidor SQL Server
                int CodCtaCte = 0; if (objEntidad.MsgError != "")
                    CodCtaCte = -1;
                foreach (DataRow R in dtTabla.Rows)
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", CodCtaCte, R["RazonSocial"], R["Direccion"],
                        R["Direccion"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                        R["Ruc"], "", "", "", 0, 0));
            }

            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat_Clientes(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtacte = 1;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], R["SaldoCreditoFavor"], R["CodDireccion"]));


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            //if (dtTabla.Rows.Count == 0)
            //{
            //    dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(ref objEntidad);
                //Error relacionado con la red o específico de la instancia mientras se establecía una conexión con el servidor SQL Server
                //int CodCtaCte = 0; if (objEntidad.MsgError != "")
                //    CodCtaCte = -1;
                //foreach (DataRow R in dtTabla.Rows)
                //    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", CodCtaCte, R["RazonSocial"], R["Direccion"],
                //        R["Direccion"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                //        R["Ruc"], "", "", "", 0, 0));
            //}
            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LGProductos_Select(string Descripcion, int CodAlmacen)
        {
            LGProductosCE objEntidad = new LGProductosCE();

            objEntidad.DscProducto = Descripcion;
            objEntidad.CodAlmacen = CodAlmacen;

            DataTable dtTabla = null;
            LGProductosCN objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_LGProductos_Select(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6}", dtTabla.Rows[i]["CodAlterno"], dtTabla.Rows[i]["DscProducto"], dtTabla.Rows[i]["StockActual"], dtTabla.Rows[i]["Costo"], dtTabla.Rows[i]["Moneda"], dtTabla.Rows[i]["CodProducto"], dtTabla.Rows[i]["Marca"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LGProductos_Servicios_Select(string Descripcion, int CodAlmacen)
        {
            LGProductosCE objEntidad = new LGProductosCE();

            objEntidad.DscProducto = Descripcion;
            objEntidad.CodAlmacen = CodAlmacen;

            DataTable dtTabla = null;
            LGProductosCN objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_LGProductos_Servicios_Select(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5}", dtTabla.Rows[i]["CodAlterno"], dtTabla.Rows[i]["DscProducto"], dtTabla.Rows[i]["StockActual"], dtTabla.Rows[i]["Costo"], dtTabla.Rows[i]["Moneda"], dtTabla.Rows[i]["CodProducto"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarDepartamento_AutoComplete(string Descripcion)
        {
            TCDepartamentoCE objEntidad = new TCDepartamentoCE();

            objEntidad.DscDepartamento = Descripcion;

            DataTable dtTabla = null;
            TCDepartamentoCN objOperacion = new TCDepartamentoCN();
            dtTabla = objOperacion.F_Departamento_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarProvincia_AutoComplete(string Descripcion, int Codigo)
        {
            TCProvinciaCE objEntidad = new TCProvinciaCE();

            objEntidad.CodDepartamento = Codigo;
            objEntidad.DscProvincia = Descripcion;
            DataTable dtTabla = null;
            TCProvinciaCN objOperacion = new TCProvinciaCN();
            dtTabla = objOperacion.F_Provincia_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarDistrito_AutoComplete(string Descripcion, int Codigo)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodProvincia = Codigo;
            objEntidad.DscDistrito = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Distrito_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDistrito_Listar(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDistrito_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["DscDistrito"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDistrito_ListarXCodDistrito(int CodDistrito)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodDistrito = CodDistrito;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDistrito_ListarXCodDistrito(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["DscDistrito"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodDistrito(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0}", dtTabla.Rows[i]["Direccion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodDistrito_AutoComplete(string Direccion, int CodDepartamento, int CodProvincia, int CodDistrito, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodDepartamento = CodDepartamento;
            objEntidad.CodProvincia = CodProvincia;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["Direccion"]
                                , dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDepartamento"]
                                , dtTabla.Rows[i]["Email"], dtTabla.Rows[i]["Email2"], dtTabla.Rows[i]["Email3"]
                                , dtTabla.Rows[i]["Email4"], dtTabla.Rows[i]["Email5"], dtTabla.Rows[i]["Email6"]
                                ));

            return Lista.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodTransportista_AutoComplete(string Direccion, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodCtaCte_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["Direccion"].ToString().Trim()));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccion_ListarXCodDistritoCliente_AutoComplete(string Direccion, int CodDepartamento, int CodProvincia, int CodDistrito, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodDepartamento = CodDepartamento;
            objEntidad.CodProvincia = CodProvincia;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }
        public class jqProformasResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCDireccionCE> rows { get; set; }
        }


        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public bool KeepActiveSession()
        //{
        //    if (HttpContext.Current.Session["CodSede"] != null & HttpContext.Current.Session["CodUsuario"] != null)
        //        return true;
        //    else
        //        return false;
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_DocumentoVentaCab_Placas_AutoComplete(int CodCtaCte, string Placa)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodCliente = CodCtaCte;
            objEntidad.Placa = Placa;

            DataTable dtTabla = null;

            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            dtTabla = objOperacion.F_DocumentoVentaCab_Placas_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0}", dtTabla.Rows[i]["PLACA"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarClientesPorRucDniSinSaldo(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 1;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }

            return Lista.ToArray();
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LINEA_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_LINEA_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodLinea"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_MODELOVEHICULO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_MODELOVEHICULO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodModeloVehiculo"], dtTabla.Rows[i]["Modelo"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_MARCAPRODUCTO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_MARCAPRODUCTO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodMarcaProducto"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Familia_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Familia_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["DscFamilia"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Producto_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_producto_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodProducto"], dtTabla.Rows[i]["DscProducto"]));
                }
            }
            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //Joel Buscar el distrito del Api
        public string[] F_Direccion_Buscar(string Ubigeo)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Ubigeo = Ubigeo;

            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Direccion_Buscar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"]
                                , dtTabla.Rows[i]["CodDistrito"]
                                ));

            return Lista.ToArray();

        }


        //Joel Buscar el url y el token
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_API_RUC_Buscar()
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_API_RUC_Buscar(Convert.ToInt32(HttpContext.Current.Session["CodEmpresa"]));
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["urlapisunat"], dtTabla.Rows[i]["tokenapisunat"]
                                ));

            return Lista.ToArray();
        }


        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ParametrosCE> F_ParametrosListar(string Parametro, int CodigoMenu, int CodigoInterno)
        {
            List<ParametrosCE> lParametros = new List<ParametrosCE>();
            DataTable dtPermisos = (new TCEmpresaCN()).F_ParametrosSistemas_Listar(Parametro, CodigoMenu, CodigoInterno);

            foreach (DataRow r in dtPermisos.Rows)
            {
                ParametrosCE p = new ParametrosCE();
                p.Parametro = r["Parametro"].ToString();
                p.Valor = r["Valor"].ToString();
                lParametros.Add(p);
            }
            return lParametros;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ObtenerAlmacen(int CodAlmacen)
        {
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = CodAlmacen;
            DataTable dtTabla = null;

            TCAlmacenCN objOperacion = new TCAlmacenCN();
            dtTabla = objOperacion.F_TCAlmacen_Actual(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodAlmacen"], dtTabla.Rows[i]["Direccion"].ToString().Trim()));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete2(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                        dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"]));
                }
            }
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCUENTACORRIENTE_ENTER_ONBLUR(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCUENTACORRIENTE_ENTER_ONBLUR(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {


                Lista.Add(string.Format("{0},{1}", R["CodCtaCte"], R["RazonSocial"]));

            }

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccion_ListarTemporal(string NroRuc, string CodDocumentoVenta, int CodCtacte, string Razonsocial, int FlagTraslado, string Ubigeo, string Direccion, int Codtipodoc)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.NroRuc = NroRuc;
            objEntidad.Codtemporal = CodDocumentoVenta;
            objEntidad.CodCLiente = CodCtacte;
            objEntidad.Cliente = Razonsocial;
            objEntidad.FlagTraslado = FlagTraslado;
            objEntidad.CodUsuario = 4;
            objEntidad.Ubigeo = Ubigeo;
            objEntidad.Direccion = Direccion;
            objEntidad.Codtipodoc = Codtipodoc;
            //Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]); 
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarTemporal(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Temporal = int.Parse(dtTabla.Rows[i]["CodDocumentoVenta"].ToString())
                    }
                    );

            }

            return data;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccionTemporal_Listar(string CodDocumentoVenta, int FlagTraslado)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.Codtemporal = CodDocumentoVenta;
            objEntidad.FlagTraslado = FlagTraslado;
            //Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]); 
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccionTemporal_Listar(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Temporal = int.Parse(dtTabla.Rows[i]["CodDocumentoVenta"].ToString())
                    }
                    );

            }

            return data;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqDireccionesClientesResult F_TCDireccion_ListarXCliente_AutoComplete(int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodCtaCte = CodCtaCte;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCliente_AutoComplete(objEntidad);

            jqDireccionesClientesResult data = new jqDireccionesClientesResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }
        public class jqDireccionesClientesResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCDireccionCE> rows { get; set; }
        }

        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCCuentaCorrienteCE> F_ListarClientes_AutoComplete_toList(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            List<TCCuentaCorrienteCE> lClientes = new List<TCCuentaCorrienteCE>();
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            foreach (DataRow r in dtTabla.Rows)
            {
                TCCuentaCorrienteCE nCli = new TCCuentaCorrienteCE();
                nCli.CodCtaCte = Convert.ToInt32(r["CodCtaCte"].ToString());
                nCli.RazonSocial = r["RazonSocial"].ToString();
                nCli.Direccion = r["Direccion"].ToString();
                nCli.DireccionEnvio = r["DireccionEnvio"].ToString();
                nCli.Distrito = r["Distrito"].ToString();
                nCli.CodDepartamento = Convert.ToInt32(r["CodDepartamento"].ToString());
                nCli.CodProvincia = Convert.ToInt32(r["CodProvincia"].ToString());
                nCli.CodDistrito = Convert.ToInt32(r["CodDistrito"].ToString());
                nCli.NroRuc = r["NroRuc"].ToString();
                nCli.CodTipoCtaCte = Convert.ToInt32(r["CodTipoCtaCte"].ToString());
                nCli.CodDireccion = Convert.ToInt32(r["CodDireccion"]);
                lClientes.Add(nCli);
            }
            return lClientes;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_Guia_Lote2_PDF(string Codigos, string Guia, string TipoImp)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");
            string outputPdfPath = null;
            string DomainNameOutPut = null;
            List<string> pdfs = F_Facturas_GUIA_PDF(Codigos, nombreBase, Guia,TipoImp);


            outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_FACTURAS.pdf";


            DomainNameOutPut = @"../files/temp/" + nombreBase + "_FACTURAS.pdf";



            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DomainNameOutPut;
        }

        private List<string> F_Facturas_GUIA_PDF(string Codigos, string nombreBase, string Guia, string TipoImp)
        {
            List<string> lista = new List<string>();

            var Facturas = Codigos.Split(',');

            try
            {
                //genero todos los pdf y los guardo

                int CodigoDocumento = Convert.ToInt32(Codigos);
                string TipoImpresion = Convert.ToString(TipoImp);
                if (CodigoDocumento > 0)
                {
                    string nombreRutaDocumentoTemp = nombreBase + "_" + Codigos + "_FT_" + ".pdf";
                    cGeneraPDF pdf = new cGeneraPDF();
                    string pdfNuevo = pdf.GenerarFACTURASNC(CodigoDocumento, nombreRutaDocumentoTemp, TipoImpresion);
                    lista.Add(pdfNuevo);
                    pdf = null;
                }

                int Guias = Convert.ToInt32(Guia);
                if (Guias > 0)
                {
                    string nombreRutaDocumentoTemp = nombreBase + "_" + Guia + "_GR_" + ".pdf";
                    cGeneraPDF pdf = new cGeneraPDF();
                    string pdfNuevoG = pdf.GenerarGUIAS(Guias, nombreRutaDocumentoTemp, TipoImpresion);
                    lista.Add(pdfNuevoG);
                    pdf = null;
                }
            }
            catch (Exception)
            {

            }


            return lista;
        }

        private int get_pageCcount(string file)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }

        private class cGeneraPDF
        {

            public string GenerarFACTURASNC(int CodDocumentoVenta, string nombreRutaDocumentoTemp, string TipoImpresion)
            {
                ReportDocument rpt = new ReportDocument();
                try
                {
                    DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
                    DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();
                    objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(CodDocumentoVenta);
                    objEntidadFactura.TipoImpresion = Convert.ToString(TipoImpresion);
                    DataTable dtTabla = objOperacionFactura.F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidadFactura);
                    int CodTipoDoc = Convert.ToInt32(dtTabla.Rows[0]["CodTipoDocumento"].ToString());

                    dtTabla.Columns.Add("QR", typeof(byte[]));
                    dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                    dtTabla.TableName = "Electronica";

                    BarCode qrcode = new BarCode();
                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                    qrcode.X = 6;
                    qrcode.Y = 6;
                    qrcode.LeftMargin = 6;
                    qrcode.RightMargin = 6;
                    qrcode.TopMargin = 6;
                    qrcode.BottomMargin = 6;
                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                    foreach (DataRow dr in dtTabla.Rows)
                    {
                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                    }

                    string ArchivoRpt = dtTabla.Rows[0]["FormatoRPT"].ToString();


                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);
                    return tempDirectory;
                }
                catch (Exception e)
                {
                    rpt.Dispose();
                    throw e;
                }

            }


            public string GenerarGUIAS(int CodTraslado, string nombreRutaDocumentoTemp, string TipoImp)
            {
                TrasladosCabCE objEntidadTraslados = new TrasladosCabCE();
                TrasladosCabCN objOperacionTraslados = new TrasladosCabCN();
                objEntidadTraslados.CodTraslado = Convert.ToInt32(CodTraslado);
                objEntidadTraslados.TipoImpresion = Convert.ToString(TipoImp);
                DataTable dtTabla = objOperacionTraslados.F_TrasladosCab_Impresion(objEntidadTraslados);

                dtTabla.Columns.Add("OR", typeof(byte[]));
                dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                dtTabla.TableName = "Electronica";

                BarCode qrcode = new BarCode();
                qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                qrcode.X = 6;
                qrcode.Y = 6;
                qrcode.LeftMargin = 6;
                qrcode.RightMargin = 6;
                qrcode.TopMargin = 6;
                qrcode.BottomMargin = 6;
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                foreach (DataRow dr in dtTabla.Rows)
                {
                    string cadenaQR = dr["NroRuc"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Emision"] + "|" +
                                         dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["RucDestinatario"];
                    qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["OR"] = imageData;
                }


                string FORMATO = dtTabla.Rows[0]["NombreArchivo"].ToString();

                dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();

                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + FORMATO));
                rpt.SetDataSource(dtTabla);

                string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp;
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);

                return tempDirectory;
            }

            
        }

    }
    
    
    }
