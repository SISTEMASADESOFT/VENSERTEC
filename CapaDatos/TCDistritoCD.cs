using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class TCDistritoCD
    {

        public TCDistritoCE F_TCDireccion_Agregar(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_Agregar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodSede;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 300).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@Email2", SqlDbType.VarChar, 300).Value = objEntidadBE.Email2;
                        sql_comando.Parameters.Add("@Email3", SqlDbType.VarChar, 300).Value = objEntidadBE.Email3;
                        sql_comando.Parameters.Add("@Email4", SqlDbType.VarChar, 300).Value = objEntidadBE.Email4;
                        sql_comando.Parameters.Add("@Email5", SqlDbType.VarChar, 300).Value = objEntidadBE.Email5;
                        sql_comando.Parameters.Add("@Email6", SqlDbType.VarChar, 300).Value = objEntidadBE.Email6;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public TCDistritoCE F_TCDireccion_Editar(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_Editar";

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 300).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@Email2", SqlDbType.VarChar, 300).Value = objEntidadBE.Email2;
                        sql_comando.Parameters.Add("@Email3", SqlDbType.VarChar, 300).Value = objEntidadBE.Email3;
                        sql_comando.Parameters.Add("@Email4", SqlDbType.VarChar, 300).Value = objEntidadBE.Email4;
                        sql_comando.Parameters.Add("@Email5", SqlDbType.VarChar, 300).Value = objEntidadBE.Email5;
                        sql_comando.Parameters.Add("@Email6", SqlDbType.VarChar, 300).Value = objEntidadBE.Email6;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public TCDistritoCE F_TCDireccion_Eliminar(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_Eliminar";

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_Distrito_Autocomplete(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Distrito_Autocomplete";
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@DscDistrito", SqlDbType.VarChar, 20).Value = objEntidadBE.DscDistrito;
                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDistrito_Listar(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDistrito_Listar";
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;
                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDistrito_ListarXCodDistrito(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDistrito_ListarXCodDistrito";
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.VarChar, 50).Value = objEntidadBE.CodDistrito;
                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }
        public DataTable F_TCDireccion_Listar(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_Listar";
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.Codigo;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;
                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDireccion_ListarXCodDistrito(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarXCodDistrito";
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;
                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDireccion_ListarXCodCtaCte(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarXCodCtaCte";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDireccion_ListarXCodDistrito_AutoComplete(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarXCodDistrito_AutoComplete";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = objEntidadBE.Direccion;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }



        public DataTable F_TCDireccion_ListarXCodCtaCte_AutoComplete(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TcDireccion_Consultar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDireccion_ListarCorreosXCodDireccion(int CodDireccion)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarCorreosXCodDireccion";

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = CodDireccion;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public bool F_ElegirPrincipalDireccion(int CodDireccion, out string Mensaje)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_ElegirPrincipalDireccion";

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = CodDireccion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        Mensaje = MsgError.Value.ToString();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = "ERROR: " + ex.Message;
                return false;
            }

        }

        public bool F_TCDireccion_ActivarDesactivar(int CodDireccion, int CodEstado, out string Mensaje)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ActivarDesactivar";

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = CodDireccion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = CodEstado;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        Mensaje = MsgError.Value.ToString();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = "ERROR: " + ex.Message;
                return false;
            }

        }
        public DataTable F_API_RUC_Buscar(int CodEmpresa)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_API_RUC_Buscar";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = CodEmpresa;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_Direccion_Buscar(TCDistritoCE objEntidad)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Direccion_Buscar";

                        sql_comando.Parameters.Add("@Ubigeo", SqlDbType.VarChar, 6).Value = objEntidad.Ubigeo;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDireccion_ListarXCliente_AutoComplete(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarXCliente_AutoComplete";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }


        public DataTable F_TCDireccion_ListarTemporal(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {


                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;

                   
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarTemporal";

                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 20).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Codtemporal", SqlDbType.Int).Value = objEntidadBE.Codtemporal;
                        sql_comando.Parameters.Add("@CodCLiente", SqlDbType.Int).Value = objEntidadBE.CodCLiente;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 1000).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FlagTraslado", SqlDbType.Int).Value = objEntidadBE.FlagTraslado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Ubigeo", SqlDbType.VarChar, 10).Value = objEntidadBE.Ubigeo;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Direccion;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_TCDireccionTemporal_Listar(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccionTemporal_Listar";


                        sql_comando.Parameters.Add("@Codtemporal", SqlDbType.Int).Value = objEntidadBE.Codtemporal;
                        sql_comando.Parameters.Add("@FlagTraslado", SqlDbType.Int).Value = objEntidadBE.FlagTraslado;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }


        public DataTable F_TCDireccion_ListarXDireccionTemporal(TCDistritoCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccion_ListarXDireccionTemporal";

                        sql_comando.Parameters.Add("@Temporal", SqlDbType.Int).Value = objEntidadBE.Temporal;
                        sql_comando.Parameters.Add("@FlagTraslado", SqlDbType.Int).Value = objEntidadBE.FlagTraslado;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public TCDistritoCE F_TCDireccionTemporal_Agregar(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccionTemporal_Agregar";

                        sql_comando.Parameters.Add("@Temporal", SqlDbType.Int).Value = objEntidadBE.Temporal;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodSede;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 300).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@Email2", SqlDbType.VarChar, 300).Value = objEntidadBE.Email2;
                        sql_comando.Parameters.Add("@CodCLiente", SqlDbType.Int).Value = objEntidadBE.CodCLiente;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 300).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@FlagTraslado", SqlDbType.Int).Value = objEntidadBE.FlagTraslado;


                        SqlParameter CodDocumentoVentaDireccion = sql_comando.Parameters.Add("@CodDocumentoVentaDireccion", SqlDbType.Int);
                        CodDocumentoVentaDireccion.Direction = ParameterDirection.Output;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodDocumentoVenta = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        CodDocumentoVenta.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVentaDireccion = Convert.ToInt32(CodDocumentoVentaDireccion.Value);
                        objEntidadBE.Temporal = Convert.ToInt32(CodDocumentoVenta.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public TCDistritoCE F_TCDireccionTemporal_Editar(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccionTemporal_Editar";

                        sql_comando.Parameters.Add("@Temporal", SqlDbType.Int).Value = objEntidadBE.Temporal;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 300).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@Email2", SqlDbType.VarChar, 300).Value = objEntidadBE.Email2;
                        sql_comando.Parameters.Add("@CodCLiente", SqlDbType.Int).Value = objEntidadBE.CodCLiente;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDireccionTemporal", SqlDbType.Int).Value = objEntidadBE.CodDireccionTemporal;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;


                        SqlParameter CodDocumentoVentaDireccion = sql_comando.Parameters.Add("@CodDocumentoVentaDireccion", SqlDbType.Int);
                        CodDocumentoVentaDireccion.Direction = ParameterDirection.Output;

                        SqlParameter FlagTraslado = sql_comando.Parameters.Add("@FlagTraslado", SqlDbType.Int);
                        FlagTraslado.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVentaDireccion = Convert.ToInt32(CodDocumentoVentaDireccion.Value);
                        objEntidadBE.FlagTraslado = Convert.ToInt32(FlagTraslado.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public TCDistritoCE F_TCDireccionTemporal_Eliminar(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCDireccionTemporal_Eliminar";

                        sql_comando.Parameters.Add("@CodDireccionTemporal", SqlDbType.Int).Value = objEntidadBE.CodDireccionTemporal;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public TCDistritoCE F_BuscarDireccionCotizacion(TCDistritoCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;

                    
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_BuscarDireccionCotizacion";

                        sql_comando.Parameters.Add("@Temporal", SqlDbType.Int).Value = objEntidadBE.Temporal;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;


                        SqlParameter CodDireccionTemporal = sql_comando.Parameters.Add("@CodDireccionTemporal", SqlDbType.Int);
                        CodDireccionTemporal.Direction = ParameterDirection.Output;



                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.Mensaje = MsgError.Value.ToString();
                        objEntidadBE.CodDireccionTemporal = Convert.ToInt32(CodDireccionTemporal.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
    }
}
