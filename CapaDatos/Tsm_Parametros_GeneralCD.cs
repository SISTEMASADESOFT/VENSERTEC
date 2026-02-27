using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class Tsm_Parametros_GeneralCD
    {

        public Tsm_Parametros_General_RSL F_Select_One_ParametrosGenerales(Tsm_Parametros_General_FLT oFilter)
        {
            Tsm_Parametros_General_RSL lstResultset;
            SqlDataReader Dr;
            lstResultset = new Tsm_Parametros_General_RSL();
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                        sql_conexion.Open();
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "Tsm_Parametros_GeneralSS_UnReg";
                        sql_comando.Parameters.Add("@T_Codigo_Parametro", SqlDbType.VarChar, 3).Value = oFilter.T_Codigo_Parametro;
                        Dr = sql_comando.ExecuteReader();
                        while (Dr.Read())
                        {
                            lstResultset = new Tsm_Parametros_General_RSL();
                            lstResultset.ID_ParametroGeneral = Dr["ID_ParametroGeneral"].getNullOrValue<int, object>();
                            lstResultset.T_Codigo_Parametro = Dr["T_Codigo_Parametro"].getNullOrValue<string, object>();
                            lstResultset.T_Descripcion_Parametro = Dr["T_Descripcion_Parametro"].getNullOrValue<string, object>();
                            lstResultset.T_Valor_Parametro = Dr["T_Valor_Parametro"].getNullOrValue<string, object>();
                            lstResultset.N_Valor_Parametro = Dr["N_Valor_Parametro"].getNullOrValue<decimal, object>();
                            lstResultset.ID_Estado_Parametro_Sistema = Dr["ID_Estado_Parametro_Sistema"].getNullOrValue<int, object>();
                            lstResultset.ID_Moneda_Empresa = Dr["ID_Moneda_Empresa"].getNullOrValue<int, object>();
                        }
                        sql_conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstResultset;
        }

        public DataTable Tsm_Parametros_General_TodosJSON()
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
                        sql_comando.CommandText = "TSM_PARAMETROS_GENERALSS_ALL";
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
        }
    }
}
