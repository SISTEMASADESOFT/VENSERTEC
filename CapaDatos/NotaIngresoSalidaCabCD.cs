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
  public  class NotaIngresoSalidaCabCD
    {
      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert(NotaIngresoSalidaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                        sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar,4).Value = objEntidadBE.SerieDocSust;
                        sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar,8).Value = objEntidadBE.NumeroDocSust;

                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                               
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                        sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                        sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;

                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@FlagPercepcion", SqlDbType.Int).Value = objEntidadBE.FlagPercepcion;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Motorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;

                        sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                
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

      public DataTable F_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Mercedes(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;

                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@FlagPercepcion", SqlDbType.Int).Value = objEntidadBE.FlagPercepcion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;

                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;

                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;

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

      public DataTable F_NotaIngresoSalidaCab_Select_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_Compras";

                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") !="19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }
                      
                      if (objEntidadBE.NumeroDoc !="")
                      sql_comando.Parameters.Add("@NumeroDoc",SqlDbType.VarChar,10).Value = objEntidadBE.NumeroDoc;


                      if (objEntidadBE.FormaPago != "Todos")
                          sql_comando.Parameters.Add("@FormaPago", SqlDbType.VarChar, 8).Value = objEntidadBE.FormaPago;
                       
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

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_Mercedes(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_Compras";

                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroDoc;

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

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Anulacion_NotaIngreso";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_NotaIngresoSalidaCab_Letras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Letras";

                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

      public DataTable F_NotaIngresoSalidaCab_ConsultaPagos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ConsultaPagos";

                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
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

      public NotaIngresoSalidaCabCE F_Pagos_RegistroPagos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_RegistroPagos";

                      sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                      sql_comando.Parameters.Add("@CodigoTemporalCobranzas", SqlDbType.Int).Value = objEntidadBE.CodigoTemporalCobranzas;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 250).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaOperacion;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 250).Value = objEntidadBE.Responsable;
                      sql_comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                      sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;
                      sql_comando.Parameters.Add("@MontoOperacion", SqlDbType.Decimal).Value = objEntidadBE.Monto;
                      sql_comando.Parameters.Add("@MontoFactura", SqlDbType.Decimal).Value = objEntidadBE.MontoFactura;
                      sql_comando.Parameters.Add("@TotalPago", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;


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

      public DataTable F_Pagos_Listar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_Listar";

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.CodMedioPago != 0)
                          sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodCajaFisica != 0)
                          sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;

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

      public NotaIngresoSalidaCabCE F_Pagos_Anulacion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_Anulacion";

                      sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 400);
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_InsertGastos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_InsertGastos";

                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 6).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 14).Value = objEntidadBE.NumeroDocSust;
                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Proveedor", SqlDbType.VarChar, 500).Value = objEntidadBE.Proveedor;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;
                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;

                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;


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

      public DataTable F_NotaIngresoSalidaCab_VistaPreliminar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalida_VistaPreliminar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_NotaIngesoSalidaCab_FacturaPercepcion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngesoSalidaCab_FacturaPercepcion";

                      if (objEntidadBE.CodMoneda==0)
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = DBNull.Value;
                      else
                          sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = objEntidadBE.Monto;
                      //sql_comando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

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

      public DataTable F_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaDet_InsertTemporal(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaDet_InsertTemporal";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

                      SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                      Codigo.Direction = ParameterDirection.Output;


                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);


                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_NotaCredito_Insert(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_NotaCredito_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;

                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodFactura_Asociada", SqlDbType.Int).Value = objEntidadBE.CodFactura_Asociada;
                      sql_comando.Parameters.Add("@CodTipoOperacionNC", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacionNC;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar,2000).Value = objEntidadBE.Observacion;


                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                      Codigo.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodMovimiento = Convert.ToInt32(Codigo.Value);

                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public DataTable F_NotaIngresoSalidaCab_ConsultaPago(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ConsultaPago";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

      public DataTable F_NotaIngresoSalidaCab_RegistroCompras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_RegistroCompras";

                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                  
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Update(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Update";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@FlagMotorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = "";

                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public NotaIngresoSalidaCabCE F_Movimientos_CierreMensual(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_CierreMensual";

                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@NroMesAnio", SqlDbType.Int).Value = objEntidadBE.Periodo;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Factura(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Validar_Factura";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_NotaIngresoSalidaCab_Reemplazar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Reemplazar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Anulacion_NotaCredito(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Anulacion_NotaCredito";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_ELIMINARAJUSTES(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_MOVIMIENTOS_ELIMINARAJUSTES";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_NotaIngresoSalidaCab_Impresion_Factura(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Impresion_Factura";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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



      public NotaIngresoSalidaCabCE F_ComprobanteCaja_ActualizarSaldo_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_ActualizarSaldo_Compras";

                      sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@SaldoComprobante", SqlDbType.Decimal).Value = objEntidadBE.SaldoComprobante;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;

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



      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Anulacion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Anulacion";

                      sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
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


      public DataTable F_ComprobanteCaja_BuscarFactura_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_BuscarFactura_Compras";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

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

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Insert(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = objEntidadBE.Monto;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 300).Value = objEntidadBE.Proveedor;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 300).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 500).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                      sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                      sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;

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

      public DataTable F_ComprobanteCaja_Listar_Egresos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Listar_Egresos";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

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


      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Eliminacion_NotaIngreso";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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


      public DataTable F_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
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

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NotaIngresoSalidaCab_REPORTE_CONTABILIDAD_REGISTROCOMPRA";

                      if (objEntidadBE.CodAlmacen > 0)
                          sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.Detallado > 0)
                          sql_comando.Parameters.Add("@Detallado", SqlDbType.Int).Value = objEntidadBE.Detallado;

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

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROVENTA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NotaIngresoSalidaCab_REPORTE_CONTABILIDAD_REGISTROVENTA";

                      if (objEntidadBE.CodAlmacen > 0)
                          sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.Detallado > 0)
                          sql_comando.Parameters.Add("@Detallado", SqlDbType.Int).Value = objEntidadBE.Detallado;
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

      public object F_AUDITORIA_EGRESO(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_EGRESO";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;

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

      public object F_AUDITORIA_INGRESO(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_Ingreso";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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


      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Actualizar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Actualizar";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.Codigo;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

      public object F_COMPROBANTEDEEGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_COMPROBANTEDEEGRESO_OBSERVACION";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

      public object F_COMPROBANTEDEINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_COMPROBANTEDEINGRESO_OBSERVACION";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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


      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Gastos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Eliminacion_NotaIngreso_Gastos";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

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

      public NotaIngresoSalidaCabCE F_Confirmacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Confirmar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_NotaIngresoSalida_Documentos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "NotaIngresoSalida_Documentos";

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

      public DataTable F_FacturasXPagar_Reporte(NotaIngresoSalidaCabCE objEntidadBE)
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
                      //sql_comando.CommandText = "pa_FacturasXPagar_Reporte";
                      sql_comando.CommandText = "pa_Pagos_Reporte";

                      if (objEntidadBE.CodEmpresa != 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.CodTipoDoc != 0)
                          sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

      public object F_AUDITORIA_NOTAINGRESO(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_NOTADEINGRESO";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

      public object F_NOTADEINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_NOTADEINGRESO_OBSERVACION";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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
