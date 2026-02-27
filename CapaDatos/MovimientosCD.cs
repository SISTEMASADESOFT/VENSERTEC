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
  public class MovimientosCD
    {
      public DataTable F_Movimientos_Kardex(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex";

                      sql_comando.Parameters.Add("@CodAlterno", SqlDbType.VarChar,15).Value = objEntidadBE.CodAlterno;
                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      if (objEntidadBE.CodCtaCte == 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = DBNull.Value;
                      else
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

      public DataTable F_Movimientos_KardexDetalleCosto(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_KardexDetalleCosto";

                      sql_comando.Parameters.Add("@NroMesAnio", SqlDbType.Int).Value = objEntidadBE.NroMesAnio;
                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                  
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

      public DataTable F_Movimientos_Kardex_FechaInicial()
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex_FechaInicial";

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

      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex_SaldoInicial_Modificar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CantidadIng", SqlDbType.Decimal).Value = objEntidadBE.CantidadIng;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

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

      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar_William(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex_SaldoInicial_Modificar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CantidadIng", SqlDbType.Decimal).Value = objEntidadBE.CantidadIng;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaRegistro; 

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


      public DataTable F_Kardex_Observacion(MovimientosCE objEntidadBE)
      {
          DataTable dta_auditoria = null;
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
                      sql_comando.CommandText = "PA_Kardex_Observacion";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoDocNota", SqlDbType.Int).Value = objEntidadBE.CodTipoDocNota;

                      dta_auditoria = new DataTable();

                      dta_auditoria.Load(sql_comando.ExecuteReader());

                      return dta_auditoria;

                  }
              }

          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_auditoria.Dispose(); }
      }
    }
}
