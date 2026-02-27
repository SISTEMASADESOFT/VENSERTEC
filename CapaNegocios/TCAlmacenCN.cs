using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
   public class TCAlmacenCN
    {
       TCAlmacenCD obj = new TCAlmacenCD();

       public DataTable F_TCAlmacen_Listar(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_TCAlmacen_Listar(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCAlmacen_Listar_Todos(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_TCAlmacen_Listar_Todos(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_DscDestinos_Listar(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_DscDestinos_Listar(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCAlmacen_Actual(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_TCAlmacen_Actual(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCAlmacen_Listar(int codEmp)
       {
           try
           {

               return obj.F_TCAlmacen_Listar(codEmp);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCAlmacen_ObtenerDatos(int CodAlmacen)
       {
           try
           {
               return obj.F_TCAlmacen_ObtenerDatos(CodAlmacen);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable F_TCAlmacen_Listar_Conexiones(TCAlmacenCE objEntidad)
       {
           return obj.F_TCAlmacen_Listar_Conexiones(objEntidad);
       }

       public DataTable F_Consulta_Stock_Almacen_Externo(TCAlmacenCE objEntidad)
       {
           return obj.F_Consulta_Stock_Almacen_Externo(objEntidad);
       }

       public decimal F_Consulta_Stock_Almacen_Remoto(TCAlmacenCE objEntidad)
       {
           return obj.F_Consulta_Stock_Almacen_Remoto(objEntidad);
       }

       public DataTable F_TCAlmacenesExternos_Listar_Parametros_Conexion()
       {
           return obj.F_TCAlmacenesExternos_Listar_Parametros_Conexion();
       }

       public DataTable F_TCAlmacenesExternos_Listar(int SoloExternos)
       {
           return obj.F_TCAlmacenesExternos_Listar(SoloExternos);
       }

       public DataTable F_Consulta_Stock_Azure(int CodProductoAzure, string CodigoInterno)
       {
           return obj.F_Consulta_Stock_Azure(CodProductoAzure, CodigoInterno);
       }

       public DataTable F_LGStockAlmacen_StockArticulo(int CodProductoAzure, int CodProducto, int CodAlmacen)
       {
           return obj.F_LGStockAlmacen_StockArticulo(CodProductoAzure, CodProducto, CodAlmacen);
       }

       public DataTable F_TCALMACEN_LISTAR_TODOS(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_TCALMACEN_LISTAR_TODOS(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       public DataTable F_TCALMACEN_LISTAR_TODOS_william(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_TCALMACEN_LISTAR_TODOS_william(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }


       public List<TCAlmacenCE> F_TCAlmacen_Listar(int codEmp, int pTodos)
       {
           try
           {

               List<TCAlmacenCE> lDatos = new List<TCAlmacenCE>();
               DataTable dtDatos = obj.F_TCAlmacen_Listar(codEmp);


               if (pTodos == 1)
                   lDatos.Add(new TCAlmacenCE()
                   {
                       CodAlmacen = 0,
                       DscAlmacen = "TODOS"
                   });

               foreach (DataRow r in dtDatos.Rows)
               {
                   lDatos.Add(new TCAlmacenCE()
                   {
                       CodAlmacen = Convert.ToInt32(r["CodAlmacen"]),
                       DscAlmacen = r["DscAlmacen"].ToString()
                   });
               };

               return lDatos;

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }


       public DataTable F_TCAlmacen_Listar_Excluyente(TCAlmacenCE objEntidadBE)
       {
           try
           {

               return obj.F_TCAlmacen_Listar_Excluyente(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

    }
}
