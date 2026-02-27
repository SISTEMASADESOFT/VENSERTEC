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
   public class LGFamiliasCD
    {
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

       public DataTable F_Servicios_Listar()
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
                       sql_comando.CommandText = "pa_ServiciosDetraccion_Listar";

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

       public DataTable F_Marcas_Por_Familias_Listar(string xml)
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
                       sql_comando.CommandText = "pa_Marcas_Por_Familias_Listar";
                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.VarChar, 10000).Value = xml;

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

       public DataTable F_FlagDetraccion_Select(TCTipoCambioCE objEntidad)
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
                       sql_comando.CommandText = "pa_FlagDetraccion";
                       sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;

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
    }
}
