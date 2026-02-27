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
   public class DocumentoVentaDetCD
    {
       public DocumentoVentaDetCE F_TemporalFacturacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalFacturacionDet_Eliminar";

                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                       

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

       public DataTable F_DocumentoVentaDet_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_DocumentoVentaDet_Listar";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

       public DataTable F_ProformaDet_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_ProformaDet_Listar";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

       public DataTable F_Proforma_Auditoria(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_Proforma_AUDITORIA";

                       sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

       public DataTable F_DocumentoVentaDet_Listar_NP(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_DocumentoVentaDet_Listar_NP";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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


       public DataTable F_CorreosDocumentosEnvios_ListarDet(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_CorreosDocumentosEnvios_ListarDet";

                       sql_comando.Parameters.Add("@idTransaccion", SqlDbType.BigInt).Value = objEntidadBE.IdTransaccion;

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


       public DocumentoVentaDetCE F_TemporalCodigoFacturaDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Eliminar";

                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;


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

       public DataTable F_DocumentoVentaCab_RetencionDetalle(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_DocumentoVentaCab_RetencionDetalle";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                       sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
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

       public DocumentoVentaDetCE F_TemporalFacturacionDet_Editar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalFacturacionDet_Editar";

                       sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                       sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                       sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;

                       sql_comando.ExecuteNonQuery();

                       return objEntidadBE;

                   }

               }



           }
           catch (Exception ex)
           {

               throw ex;

           }



       }

       public DocumentoVentaDetCE F_TemporalFacturacionDet_Update(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalFacturacionDet_Update";

                       sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                       sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                       sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                       sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                       SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                       MsgError.Direction = ParameterDirection.Output;

                       sql_comando.ExecuteNonQuery();

                       objEntidadBE.MsgError =MsgError.Value.ToString();


                       return objEntidadBE;

                   }

               }

           }
           catch (Exception ex)
           {
               throw ex;
               //objEntidadBE.MsgError = ex.Message.ToString();

           }



       }

       public DataTable F_CobranzasDet_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_CobranzasDet_Listar";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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

       public DataTable F_PagosDet_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_PagosDet_Listar";

                       sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

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

       public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_NOStock(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalFacturacionDet_Update_NOStock";

                       sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                       sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                       sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;

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
               //objEntidadBE.MsgError = ex.Message.ToString();

           }



       }

       public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalFacturacionDet_Actualizar";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                       sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Decimal).Value = objEntidadBE.FlagIgv;

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
               //objEntidadBE.MsgError = ex.Message.ToString();

           }
       }

       public DocumentoVentaDetCE F_ACTUALIZAR_MONTO_MONEDA(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_TEMPORALFACTURACIONDET_ACTUALIZAR_MONTO_MONEDA";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                       sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                       sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

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
               //objEntidadBE.MsgError = ex.Message.ToString();

           }



       }

       public DataTable F_ComprobanteCajaDet_LISTAR(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_ComprobanteCajaDet_LISTAR";

                       sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;

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


       public DocumentoVentaDetCE F_TemporalCodigoFacturaDet_Update(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Update";

                       sql_comando.Parameters.Add("@CodFacturaDet", SqlDbType.Int).Value = objEntidadBE.CodFacturaDet;
                       sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                       sql_comando.Parameters.Add("@Soles", SqlDbType.Decimal).Value = objEntidadBE.Soles;
                       sql_comando.Parameters.Add("@Dolares", SqlDbType.Decimal).Value = objEntidadBE.Dolares;

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

       public DataTable F_CodDocumentoVenta_Auditoria(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_CodDocumentoVenta_AUDITORIA";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

       public DataTable F_DocumentoVentaDet_Observacion(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_OBSERVACION";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

       public DataTable F_CAJACHICADet_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_CAJACHICADet_Listar";

                       sql_comando.Parameters.Add("@CodLiquidacionCajaCab", SqlDbType.Int).Value = objEntidadBE.codigo;
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

       //auditoria
       public DataTable F_COBRANZASCAB_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_CobranzasCab_AUDITORIA";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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


       public DataTable F_CAJACHICADet_Listar_liquidacion(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_CAJACHICADet_Listar_liquidacion";

                       sql_comando.Parameters.Add("@CodLiquidacionCajaCab", SqlDbType.Int).Value = objEntidadBE.codigo;
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


       public DataTable F_COBRANZASCAB_Eliminadas_OBSERVACIONes(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_COBRANZASCAB_Eliminadas_OBSERVACIONes";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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

       public DataTable F_CobranzasCab_ELIMINADOS_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_CobranzasCab_ELIMINADOS_AUDITORIA";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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

       public DataTable F_COBRANZASCAB_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_COBRANZASCAB_OBSERVACION";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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


       //eliminar 

       public DataTable F_CobranzasDet_Eliminar_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_CobranzasDet_Eliminados_Listar";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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

       //observacion elmiinacion

       public DataTable F_COBRANZASCAB_ELIMINADOS_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_COBRANZASCAB_Eliminadas_OBSERVACION";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

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

       public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO";

                       sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

       public DataTable F_PAGOSCAB_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_PAGOSCab_AUDITORIA";

                       sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

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

       public DataTable F_PAGOSCAB_ELIMINADOS_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_Pagos_Eliminados_Observacion";

                       sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

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

       public DataTable F_PagosDet_Eliminar_Listar(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_PagosDet_Eliminados_Listar";

                       sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

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

       public DataTable F_PAGOSCAB_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_PAGOSCAB_OBSERVACION";

                       sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

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

       public DataTable F_LIQUIDACION_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_LIQUIDACION_OBSERVACION";

                       sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.Codigo;

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

       public object F_PAGOSCAB_ELIMINADOS_AUDITORIA(DocumentoVentaDetCE objEntidad)
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
                       sql_comando.CommandText = "PA_CobranzasCab_ELIMINADOS_AUDITORIA";

                       sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidad.CodCobranzaCab;

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

    
       public DataTable F_CobranzasDet_ComisionTarjeta(Cobranzas objEntidadBE)
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
                       sql_comando.CommandText = "PA_CobranzasDet_ComisionTarjeta";

                       sql_comando.Parameters.Add("@CodCobranza", SqlDbType.Int).Value = objEntidadBE.CodCobranza;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

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
