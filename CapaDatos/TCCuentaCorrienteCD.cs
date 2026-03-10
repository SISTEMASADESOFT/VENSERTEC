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
    public class TCCuentaCorrienteCD
    {
        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtacte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;

                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;

                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;

                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;

                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@DspPosterior", SqlDbType.VarChar, 1).Value = objEntidadBE.DspPosterior;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;
                        sql_comando.Parameters.Add("@DireccionEnvio", SqlDbType.VarChar, 500).Value = objEntidadBE.DireccionEnvio;

                        sql_comando.Parameters.Add("@FlagCliente", SqlDbType.Int).Value = objEntidadBE.FlagCliente;
                        sql_comando.Parameters.Add("@FlagProveedor", SqlDbType.Int).Value = objEntidadBE.FlagProveedor;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;

                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Update";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtacte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;

                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;

                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;

                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;

                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@DspPosterior", SqlDbType.VarChar, 1).Value = objEntidadBE.DspPosterior;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;
                        sql_comando.Parameters.Add("@DireccionEnvio", SqlDbType.VarChar, 500).Value = objEntidadBE.DireccionEnvio;

                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;

                        if (objEntidadBE.CodEstado > 0)
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_TCCuentaCorriente_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_ListarClientes";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = objEntidadBE.NroRuc;

                        if (!objEntidadBE.RazonSocial.Equals(""))
                            sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 200).Value = objEntidadBE.RazonSocial;

                        if (objEntidadBE.CodTipoCtacte != 0)
                            sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtacte;

                        if (objEntidadBE.CodTipoCliente != 0)
                            sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

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

        public DataTable F_ListarResponsable_AutoComplete(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_ListarResponsable";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = objEntidadBE.NroRuc;

                        if (!objEntidadBE.RazonSocial.Equals(""))
                            sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 200).Value = objEntidadBE.RazonSocial;

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

        public DataTable F_TCCuentaCorriente_PadronSunat(ref TCCuentaCorrienteCE objEntidadBE)
        {
            objEntidadBE.MsgError = "";
            DataTable dta_consulta = null;
            try
            {
                //------------------------------------------------
                //--Primer intento con primer servidor de Padron--
                //------------------------------------------------
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDSERVICIOS"].ConnectionString;
                    sql_conexion.Open();
                    

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCCuentaCorriente_PadronSunat";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@Ruc", SqlDbType.BigInt).Value = objEntidadBE.NroRuc;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        //return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    //-------------------------------------------------
                    //--Segundo intento con primer servidor de Padron--
                    //-------------------------------------------------
                    using (SqlConnection sql_conexion = new SqlConnection())
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDSERVICIOS2"].ConnectionString;
                        sql_conexion.Open();

                        using (SqlCommand sql_comando = new SqlCommand())
                        {
                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_TCCuentaCorriente_PadronSunat";

                            if (!objEntidadBE.NroRuc.Equals(""))
                                sql_comando.Parameters.Add("@Ruc", SqlDbType.BigInt).Value = objEntidadBE.NroRuc;
                            dta_consulta = new DataTable();
                            dta_consulta.Load(sql_comando.ExecuteReader());
                            //return dta_consulta;
                        }
                    }
                }
                catch (Exception ex2)
                {
                    objEntidadBE.MsgError = ex2.Message;
                }
            }
            finally
            {
                try
                { dta_consulta.Dispose(); }
                catch (Exception)
                {
                    dta_consulta = new DataTable();
                    dta_consulta.Columns.Add("CodCtaCte", typeof(string)); dta_consulta.Columns.Add("RazonSocial", typeof(string)); dta_consulta.Columns.Add("Direccion", typeof(string)); dta_consulta.Columns.Add("DireccionEnvio", typeof(string));
                    dta_consulta.Columns.Add("Distrito", typeof(string)); dta_consulta.Columns.Add("CodDepartamento", typeof(string)); dta_consulta.Columns.Add("CodProvincia", typeof(string)); dta_consulta.Columns.Add("CodDistrito", typeof(string));
                    dta_consulta.Columns.Add("NroRuc", typeof(string)); dta_consulta.Columns.Add("ApePaterno", typeof(string)); dta_consulta.Columns.Add("ApeMaterno", typeof(string)); dta_consulta.Columns.Add("Nombres", typeof(string));
                    dta_consulta.Columns.Add("SaldoCreditoFavor", typeof(string)); dta_consulta.Columns.Add("Ruc", typeof(string));
                    DataRow rw = dta_consulta.NewRow();
                    rw["CodCtaCte"] = "-1";
                    rw["RazonSocial"] = objEntidadBE.MsgError;
                    dta_consulta.Rows.Add(rw);
                }
            }
            return dta_consulta;
        }

        public DataTable pa_TCCuentaCorriente_BuscarClienteXRucDni(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_BuscarClienteXRucDni";

                        sql_comando.Parameters.Add("@Ruc", SqlDbType.BigInt).Value = objEntidadBE.NroRuc;

                        if (objEntidadBE.CodTipoCtacte > 0)
                            sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtacte;

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

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Eliminar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Eliminar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_TCCuentaCorriente_Listar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Listar";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 60).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtacte;

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

        public DataTable F_TCResponsables_Listar(ResponsablesCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Responsables_Listar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

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

        public ResponsablesCE F_Responsables_Insert(ResponsablesCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Responsables_Insert";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Dni", SqlDbType.VarChar, 20).Value = objEntidadBE.Dni;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Correo4", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo4;
                        sql_comando.Parameters.Add("@Correo5", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo5;
                        sql_comando.Parameters.Add("@Correo6", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo6;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;


                        SqlParameter CodResponsable = sql_comando.Parameters.Add("@CodResponsable", SqlDbType.Int);
                        CodResponsable.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodResponsable = Convert.ToInt32(CodResponsable.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ResponsablesCE F_Responsables_Update(ResponsablesCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Responsables_Update";

                        sql_comando.Parameters.Add("@CodResponsable", SqlDbType.Int).Value = objEntidadBE.CodResponsable;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Dni", SqlDbType.VarChar, 20).Value = objEntidadBE.Dni;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Correo4", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo4;
                        sql_comando.Parameters.Add("@Correo5", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo5;
                        sql_comando.Parameters.Add("@Correo6", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo6;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;


                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }




        public DataTable F_TCContactos_Listar(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Listar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

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

        public ContactosCE F_Contactos_Insert(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Insert";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;


                        SqlParameter CodContacto = sql_comando.Parameters.Add("@CodContacto", SqlDbType.Int);
                        CodContacto.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodContacto = Convert.ToInt32(CodContacto.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ContactosCE F_Contactos_Update(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Update";

                        sql_comando.Parameters.Add("@CodContacto", SqlDbType.Int).Value = objEntidadBE.CodContacto;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }






        public TCCuentaCorrienteCE F_LGFamilias_Insert(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar).Value = objEntidadBE.DscFamilia;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_LGFamilias_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Update";

                        sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IDFamilia;
                        sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar).Value = objEntidadBE.DscFamilia;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGFamilias_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Listado";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar, 50).Value = objEntidadBE.DscFamilia;

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

        public DataTable F_LGFamilias_Listar()
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
                        sql_comando.CommandText = "pa_LGFamilias_Listar";

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

        public TCCuentaCorrienteCE F_LGFamilias_Delete(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Delete";

                        sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IDFamilia;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable F_Correos_Por_Cliente_Listar(int CodCtaCte, int CodDireccion)
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
                        sql_comando.CommandText = "pa_Correos_Por_Cliente_Listar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = CodCtaCte;

                        if (CodDireccion > 0)
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

        public DataTable F_Correos_Por_Responsable_Listar(int CodResponsable)
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
                        sql_comando.CommandText = "pa_Correos_Por_Responsable_Listar";

                        sql_comando.Parameters.Add("@CodResponsable", SqlDbType.Int).Value = CodResponsable;

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

        public TCCuentaCorrienteCE F_Correos_Por_Cliente_Actualizar(int CodDireccion, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6, int CodUsuario, int CodDocumentoVenta, int CodTipoDoc)
        {
            try
            {
                TCCuentaCorrienteCE objEntidadBE = new TCCuentaCorrienteCE();
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Correos_Por_Cliente_Editar";

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = CodDireccion;
                        sql_comando.Parameters.Add("@Codusuario", SqlDbType.Int).Value = CodUsuario;

                        sql_comando.Parameters.Add("@Mail1", SqlDbType.VarChar, 100).Value = Email1;
                        sql_comando.Parameters.Add("@Mail2", SqlDbType.VarChar, 100).Value = Email2;
                        sql_comando.Parameters.Add("@Mail3", SqlDbType.VarChar, 100).Value = Email3;
                        sql_comando.Parameters.Add("@Mail4", SqlDbType.VarChar, 100).Value = Email4;
                        sql_comando.Parameters.Add("@Mail5", SqlDbType.VarChar, 100).Value = Email5;
                        sql_comando.Parameters.Add("@Mail6", SqlDbType.VarChar, 100).Value = Email6;

                        if (CodDocumentoVenta > 0)
                        {
                            sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = CodDocumentoVenta;
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = CodTipoDoc;
                        }

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Correos_Por_Responsable_Actualizar(int CodDireccion, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6, int CodUsuario, int CodDocumentoVenta, int CodTipoDoc)
        {
            try
            {
                TCCuentaCorrienteCE objEntidadBE = new TCCuentaCorrienteCE();
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Correos_Por_Responsable_Editar";

                        sql_comando.Parameters.Add("@CodResponsable", SqlDbType.Int).Value = CodDireccion;
                        sql_comando.Parameters.Add("@Codusuario", SqlDbType.Int).Value = CodUsuario;

                        sql_comando.Parameters.Add("@Mail1", SqlDbType.VarChar, 100).Value = Email1;
                        sql_comando.Parameters.Add("@Mail2", SqlDbType.VarChar, 100).Value = Email2;
                        sql_comando.Parameters.Add("@Mail3", SqlDbType.VarChar, 100).Value = Email3;
                        sql_comando.Parameters.Add("@Mail4", SqlDbType.VarChar, 100).Value = Email4;
                        sql_comando.Parameters.Add("@Mail5", SqlDbType.VarChar, 100).Value = Email5;
                        sql_comando.Parameters.Add("@Mail6", SqlDbType.VarChar, 100).Value = Email6;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public TCCuentaCorrienteCE F_Linea_Insertar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_INSERTAR";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Actualizar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_Listado";

                        if (objEntidadBE.DscFamilia != "")
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

        public DataTable F_Linea_Listar()
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
                        sql_comando.CommandText = "pa_LINEA_Listar";

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

        public TCCuentaCorrienteCE F_Linea_Eliminar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LINEA_ELIMINAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LINEA_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LINEA_AUTOCOMPLETE";

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

        public TCCuentaCorrienteCE F_Modelo_Insertar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_INSERTAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Actualizar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_LISTADO";

                        if (objEntidadBE.DscFamilia != "")
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

        public DataTable F_Modelo_Listar()
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
                        sql_comando.CommandText = "pa_Modelo_Listar";

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

        public TCCuentaCorrienteCE F_Modelo_Eliminar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_ELIMINAR";

                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_MODELOVEHICULO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_AUTOCOMPLETE";

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

        public DataTable F_MARCAPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MARCAPRODUCTO_AUTOCOMPLETE";

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

        public DataTable F_Familia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Familia_AUTOCOMPLETE";

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




        public DataTable F_producto_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidad)
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
                        sql_comando.CommandText = "Pa_producto_AUTOCOMPLETE";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidad.Descripcion;

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

        public DataTable F_BuscarDatosPorRucDni(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_BuscarClienteXRucDni";

                        sql_comando.Parameters.Add("@Ruc", SqlDbType.VarChar, 20).Value = objEntidadBE.NroRuc;

                        if (objEntidadBE.CodTipoCtaCte > 0)
                            sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;

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

        public TCCuentaCorrienteCE F_Usuario_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Usuario_Update";

                        sql_comando.Parameters.Add("@Confirmacion", SqlDbType.VarChar, 60).Value = objEntidadBE.Confirmacion;
                        sql_comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 60).Value = objEntidadBE.Usuario;
                        sql_comando.Parameters.Add("@nueva", SqlDbType.VarChar, 60).Value = objEntidadBE.ContraseñaNueva;
                        sql_comando.Parameters.Add("@Antigua", SqlDbType.VarChar, 60).Value = objEntidadBE.Contraseña;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_TCCUENTACORRIENTE_ENTER_ONBLUR(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_TCCUENTACORRIENTE_ENTER_ONBLUR_NUEVO";

                        sql_comando.Parameters.Add("@Ruc", SqlDbType.VarChar, 20).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;


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


        public DataTable ObtenerCredencialesWhatsApp(int CodAlmacen)
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
                        sql_comando.CommandText = "PA_ObtenerCredencialesWhatsApp";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodAlmacen;


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

        public void RegistrarMensajeWhatsApp(int codUsuario, int codDocumentoVenta, int codCategoria, string observacion, int codAlmacen)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString))
                {
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand("PA_REGISTRAR_MENSAJES_WHATSAP", sql_conexion))
                    {

                        sql_comando.CommandType = CommandType.StoredProcedure;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = codUsuario;
                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = codDocumentoVenta;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = codCategoria;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 200).Value = observacion;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = codAlmacen;

                        sql_comando.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable ValidarCredencialesWhatsAppBasico(int CodEmpresa, int CodAlmacen)
        {
            DataTable dta_consulta = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("PA_ValidarCredencialesWhatsAppBasico", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = CodEmpresa;
                        cmd.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodAlmacen;

                        dta_consulta.Load(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dta_consulta;
        }
    }
}
