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
  public  class LGProductosCD
    {
      public DataTable F_LGProductos_Select_Ventas(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Select_Ventas";

                      sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar,150).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

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

      public DataTable F_LGProductos_Select(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Select";

                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;
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


      public DataTable F_LGProductos_Servicios_Select(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Servicios_Select";

                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

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


      public LGProductosCE F_LGProductos_Insert(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar,3).Value = objEntidadBE.CodFamilia;
                      sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                      sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoProducto;
                      sql_comando.Parameters.Add("@CostoOriginal", SqlDbType.Decimal).Value = objEntidadBE.CostoOriginal;
                      sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                      sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar,50).Value = objEntidadBE.CodigoProducto;
                      sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@Margen", SqlDbType.Decimal).Value = objEntidadBE.Margen;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Aro", SqlDbType.Decimal).Value = objEntidadBE.Aro3;
                      sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar).Value = objEntidadBE.Medida3;
                      sql_comando.Parameters.Add("@Seccion", SqlDbType.Decimal).Value = objEntidadBE.Seccion;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 250).Value = objEntidadBE.Marca;
                      sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 250).Value = objEntidadBE.Modelo;
                      sql_comando.Parameters.Add("@Pais", SqlDbType.VarChar, 250).Value = objEntidadBE.Pais;
                      sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Año;
                      sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 250).Value = objEntidadBE.Posicion;
                      sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                      sql_comando.Parameters.Add("@DescripcionAuxiliar", SqlDbType.VarChar, 250).Value = objEntidadBE.DescripcionAuxiliar;
                      sql_comando.Parameters.Add("@DscProducto2", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto2;
                      sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 20).Value = objEntidadBE.Ubicacion;
                      sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
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

      public LGProductosCE F_LGProductos_Insert_Mercedes(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;
                      sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                      sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoProducto;
                      sql_comando.Parameters.Add("@CostoOriginal", SqlDbType.Decimal).Value = objEntidadBE.CostoOriginal;
                      sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                      sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                      sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@Margen", SqlDbType.Decimal).Value = objEntidadBE.Margen;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Aro", SqlDbType.Decimal).Value = objEntidadBE.Aro3;
                      sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar).Value = objEntidadBE.Medida3;
                      sql_comando.Parameters.Add("@Seccion", SqlDbType.Decimal).Value = objEntidadBE.Seccion;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 250).Value = objEntidadBE.Marca;
                      sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 250).Value = objEntidadBE.Modelo;
                      sql_comando.Parameters.Add("@Pais", SqlDbType.VarChar, 250).Value = objEntidadBE.Pais;
                      sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Año;
                      sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 250).Value = objEntidadBE.Posicion;
                      sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                      sql_comando.Parameters.Add("@DescripcionAuxiliar", SqlDbType.VarChar, 250).Value = objEntidadBE.DescripcionAuxiliar;
                      sql_comando.Parameters.Add("@DscProducto2", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto2;
                      sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 20).Value = objEntidadBE.Ubicacion;
                      sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
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

      public LGProductosCE F_LGProductos_Update(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Update";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;
                      sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                      sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoProducto;
                      sql_comando.Parameters.Add("@CostoOriginal", SqlDbType.Decimal).Value = objEntidadBE.CostoOriginal;
                      sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                      sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@Margen", SqlDbType.Decimal).Value = objEntidadBE.Margen;
                      sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Aro", SqlDbType.Decimal).Value = objEntidadBE.Aro3;
                      sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar,250).Value = objEntidadBE.Medida;
                      sql_comando.Parameters.Add("@Seccion", SqlDbType.Decimal).Value = objEntidadBE.Seccion;
                      sql_comando.Parameters.Add("@CostoMarginable", SqlDbType.Decimal).Value = objEntidadBE.CostoMarginable;
                      sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 250).Value = objEntidadBE.Marca;
                      sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 250).Value = objEntidadBE.Modelo;
                      sql_comando.Parameters.Add("@Pais", SqlDbType.VarChar, 250).Value = objEntidadBE.Pais;
                      sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Año;
                      sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 250).Value = objEntidadBE.Posicion;
                      sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                      sql_comando.Parameters.Add("@DescripcionAuxiliar", SqlDbType.VarChar, 250).Value = objEntidadBE.DescripcionAuxiliar;
                      sql_comando.Parameters.Add("@DscProducto2", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto2;
                      sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 20).Value = objEntidadBE.Ubicacion;
                      sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                      sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 500).Value = objEntidadBE.Comentario;
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

      public LGProductosCE F_LGProductos_Update_Mercedes(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Update";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;
                      sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                      sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoProducto;
                      sql_comando.Parameters.Add("@CostoOriginal", SqlDbType.Decimal).Value = objEntidadBE.CostoOriginal;
                      sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                      sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@Margen", SqlDbType.Decimal).Value = objEntidadBE.Margen;
                      sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Aro", SqlDbType.Decimal).Value = objEntidadBE.Aro3;
                      sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 250).Value = objEntidadBE.Medida;
                      sql_comando.Parameters.Add("@Seccion", SqlDbType.Decimal).Value = objEntidadBE.Seccion;
                      sql_comando.Parameters.Add("@CostoMarginable", SqlDbType.Decimal).Value = objEntidadBE.CostoMarginable;
                      sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;
                      sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 250).Value = objEntidadBE.Marca;
                      sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 250).Value = objEntidadBE.Modelo;
                      sql_comando.Parameters.Add("@Pais", SqlDbType.VarChar, 250).Value = objEntidadBE.Pais;
                      sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Año;
                      sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 250).Value = objEntidadBE.Posicion;
                      sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                      sql_comando.Parameters.Add("@DescripcionAuxiliar", SqlDbType.VarChar, 250).Value = objEntidadBE.DescripcionAuxiliar;
                      sql_comando.Parameters.Add("@DscProducto2", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto2;
                      sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 20).Value = objEntidadBE.Ubicacion;
                      sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
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

      public LGProductosCE F_LGProductos_Eliminar(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Eliminar";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
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

      public DataTable F_LGProductos_Listar(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Listar";

                      if (objEntidadBE.DscProducto.TrimEnd().TrimStart()=="")
                         sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar,150).Value =DBNull.Value ;
                      else
                         sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar,150).Value =objEntidadBE.DscProducto ;

                      if (objEntidadBE.CodFamilia == "0")
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar,3).Value = DBNull.Value;
                      else
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;

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

      public DataTable F_LGProductos_ConsultaMovimiento(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_ListarMovimientos";

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

      public DataTable F_LGProductos_HistorialCostos(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_LogsCostos";

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


      public DataTable F_LGProductos_Select_Ajustes(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Select_Ajustes";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar,150).Value = objEntidadBE.DscProducto;

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

      public LGProductosCE F_LGProductos_Ajuste(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Ajustes";

                      sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

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

      public DataTable F_LGProductos_Inventario_StockActual(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGStockAlmacen_Inventario_StockActual";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

                      if (objEntidadBE.CodFamilia=="0")
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar,3).Value = DBNull.Value;
                      else
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;


                      if (objEntidadBE.CodEstado > 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;


                      if (objEntidadBE.Ubicacion != "")
                          sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 100).Value = objEntidadBE.Ubicacion;
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


      public DataTable F_LGProductos_Inventario_StockMinimo(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGStockAlmacen_Inventario_StockMinimo";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                      if (objEntidadBE.CodFamilia == "0")
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = DBNull.Value;
                      else
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;

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
      public DataTable F_LGProductos_InventarioPeriodo(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_InventarioPeriodo";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;

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

      public DataTable F_LGProductos_KardexSunat(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_InventarioUnidadesFisicas";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;

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

      public DataTable F_LGProductos_KardexSunat_pdf(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_InventarioUnidadesFisicas_pdf";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;

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

      public LGProductosCE F_LGProductosServicios_Update(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductosServicios_Update";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
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

      public DataTable F_LGProductos_UltimoPrecio(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_DocumentoVentaCab_UltimaVentaArticulo";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

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

      public DataTable F_LGProductos_Select_Compras(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Select_Compras";

                      sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

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

      public DataTable F_LGProductos_ListarServicios(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_ListarServicios";

                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;
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

      public LGProductosCE F_LGProductos_Servicios_Insert(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Servicios_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 8000).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetraccion", SqlDbType.Int).Value = objEntidadBE.CodDetraccion;
               
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

      public LGProductosCE F_LGProductos_Servicios_Update(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Servicios_Update";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 8000).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodDetraccion", SqlDbType.Int).Value = objEntidadBE.CodDetraccion;
                    
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

      public LGProductosCE F_LGProductos_Eliminar_Servicios(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_Eliminar_Servicios";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
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

      public DataTable F_LGProductos_VerPrecio_Moneda(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_VerPrecio_Moneda";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaRegistro;

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

      public LGProductosCE F_LGProductos_ActualizarDatos(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_ActualizarDatos";

                      sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

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

      public DataTable F_LGProductos_ListarProductosPrecios(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_ListarProductosPrecios";

                      if (objEntidadBE.CodFamilia !="0")
                      sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      if (objEntidadBE.CodProducto !=0)
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

      public DataTable F_LGProductos_ListarVentas_Descuento(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_ListarVentas_Descuento";

                      sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;
                      sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      if (objEntidadBE.CodTipoDoc != 0)
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      if (objEntidadBE.CodCliente != 0)
                          sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                      if (objEntidadBE.CodFamilia != "0")
                          sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar,3).Value = objEntidadBE.CodFamilia;

                      if (objEntidadBE.CodEstado > 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;


                      if (objEntidadBE.Ubicacion != "")
                          sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 100).Value = objEntidadBE.Ubicacion;

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


      public DataTable F_DescargarImagen_CodProducto(LGProductosCE objEntidad)
      {
          #region VARIABLES
          DataTable dta_consulta = null;

          #endregion

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
                      sql_comando.CommandText = "[usp_search_ImagenProducto]";

                      #region PARAMETROS

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodEmpresa;
                      #endregion

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

          finally
          {
              dta_consulta.Dispose();
          }
      }

      public DataTable F_DescargarDocumento_CP(LGProductosCE objEntidad)
      {
          #region VARIABLES
          DataTable dta_consulta = null;

          #endregion

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
                      sql_comando.CommandText = "[usp_search_ImagenProducto]";

                      #region PARAMETROS

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.VarChar).Value = objEntidad.CodigoProducto;
                      #endregion

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

          finally
          {
              dta_consulta.Dispose();
          }
      }


      public DataTable F_AbrirImagen_CP(LGProductosCE objEntidadCE)
      {
          #region VARIABLES
          DataTable dta_consulta = null;
          #endregion

          try
          {
              //Probar la logica de esta funcion
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDVENSERTEC_PRUEBAS"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "usp_search_ImagenProducto_CP";

                      #region PARAMETROS
                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadCE.CodigoProducto;
                      #endregion

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


      public DataTable F_ProductoModelo_Listado(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_ProductoModelo_LISTADO";

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

      public LGProductosCE F_ProductoModelo_Insertar(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_ProductoModelo_INSERTAR";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Anio;
                      sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
                      sql_comando.Parameters.Add("@CajaCambio", SqlDbType.VarChar, 1000).Value = objEntidadBE.CajaCambio;
                      sql_comando.Parameters.Add("@Transmision", SqlDbType.VarChar, 1000).Value = objEntidadBE.Transmision;
                      sql_comando.Parameters.Add("@Filtro", SqlDbType.VarChar, 1000).Value = objEntidadBE.Filtro;
                      sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                  }

              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return objEntidadBE;
      }

      public LGProductosCE F_ProductoModelo_Actualizar(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_ProductoModelo_ACTUALIZAR";

                      sql_comando.Parameters.Add("@CodProductoModelo", SqlDbType.Int).Value = objEntidadBE.CodProductoModelo;
                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                      sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Anio;
                      sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
                      sql_comando.Parameters.Add("@CajaCambio", SqlDbType.VarChar, 1000).Value = objEntidadBE.CajaCambio;
                      sql_comando.Parameters.Add("@Transmision", SqlDbType.VarChar, 1000).Value = objEntidadBE.Transmision;
                      sql_comando.Parameters.Add("@Filtro", SqlDbType.VarChar, 1000).Value = objEntidadBE.Filtro;
                      sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                  }

              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return objEntidadBE;
      }

      public LGProductosCE F_ProductoModelo_Eliminar(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_ProductoModelo_ELIMINAR";

                      sql_comando.Parameters.Add("@CodProductoModelo", SqlDbType.Int).Value = objEntidadBE.CodProductoModelo;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                  }

              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return objEntidadBE;
      }


      public LGProductosCE F_LGProductos_ActualizarListaPrecio(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_LGProductos_ActualizarListaPrecio";

                      sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 150);
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
      public DataTable F_LGProductos_HistorialMovimiento(LGProductosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimiento_HistorialMovimiento";

                      sql_comando.Parameters.Add("@codmovimiento", SqlDbType.Int).Value = objEntidadBE.codmovimiento;

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

      public DataTable F_Producto_Auditoria(LGProductosCE objEntidad)
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
                      sql_comando.CommandText = "PA_Producto_Auditoria";

                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodProducto;

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
