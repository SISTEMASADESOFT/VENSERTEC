using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class TrasladosCabCN
    {
        TrasladosCabCD obj = new TrasladosCabCD();

        public DataTable F_TrasladosCab_Impresion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Impresion_Factura(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion_Factura(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_GuiaInterna_Insert(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_GuiaInterna_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Listar_GuiaInterna(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Listar_GuiaInterna(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_GUIAREMISION_AUDITORIA(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_GUIAREMISION_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_GUIAREMISION_OBSERVACION(TrasladosCabCE objEntidadBE)
        {

            try
            {
                return obj.F_GUIAREMISION_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Anulacion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Anulacion(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Eliminacion_Inventario(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Eliminacion_Inventario(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Insert(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Listar(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public DataTable F_TrasladosCab_Reemplazar(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Reemplazar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
