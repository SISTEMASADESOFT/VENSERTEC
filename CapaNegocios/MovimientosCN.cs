using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
  public  class MovimientosCN
    {
      MovimientosCD obj = new MovimientosCD();

      public DataTable F_Movimientos_Kardex(MovimientosCE objEntidadBE)
        {

            try
            {

                return obj.F_Movimientos_Kardex(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      public DataTable F_Movimientos_KardexDetalleCosto(MovimientosCE objEntidadBE)
      {

          try
          {

              return obj.F_Movimientos_KardexDetalleCosto(objEntidadBE);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_Movimientos_Kardex_FechaInicial()
      {

          try
          {

              return obj.F_Movimientos_Kardex_FechaInicial();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_SaldoInicial_Modificar(objEntidadBE);
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
              return obj.F_Movimientos_Kardex_SaldoInicial_Modificar_William(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }


      public DataTable F_Kardex_Observacion(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Kardex_Observacion(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }
    }
}
