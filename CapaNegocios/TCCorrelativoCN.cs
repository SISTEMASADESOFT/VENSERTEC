using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
  public class TCCorrelativoCN
    {
        TCCorrelativoCD obj = new TCCorrelativoCD();

        public DataTable F_TCCorrelativo_Serie_Select(TCCorrelativoCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCorrelativo_Serie_Select(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCorrelativo_Numero_Select(TCCorrelativoCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCorrelativo_Numero_Select(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCorrelativo_NroItems(TCCorrelativoCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCorrelativo_NroItems(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public TCCorrelativoCE F_TCCorrelativo_Edicion(TCCorrelativoCE objEntidad)
        {

            try
            {

                return obj.F_TCCorrelativo_Edicion(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Vendedor_listado(TCCorrelativoCE objEntidad)
        {
            try
            {
                return obj.F_Vendedor_listado(objEntidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TipoTransportista_listado(TCCorrelativoCE objEntidad)
        {
            try
            {
                return obj.F_TipoTransportista_listado(objEntidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
