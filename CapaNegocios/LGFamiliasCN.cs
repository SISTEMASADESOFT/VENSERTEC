using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
    public class LGFamiliasCN
    {
        LGFamiliasCD obj = new LGFamiliasCD();

        public DataTable F_LGFamilias_Listar()
        {
            try
            {
                return obj.F_LGFamilias_Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Servicios_Listar()
        {
            try
            {
                return obj.F_Servicios_Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<LGFamiliasCE> F_Familias_Listar(int pTodos)
        {
            try
            {
                List<LGFamiliasCE> lDatos = new List<LGFamiliasCE>();
                DataTable dtDatos = F_LGFamilias_Listar();

                if (pTodos == 1)
                    lDatos.Add(new LGFamiliasCE()
                    {
                        IdFamilia = 0,
                        DscFamilia = "TODOS"
                    });

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new LGFamiliasCE()
                    {
                        IdFamilia = Convert.ToInt32(r["CodFamilia"]),
                        DscFamilia = r["DscFamilia"].ToString()
                    });
                };

                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<MarcasCE> F_Marcas_Por_Familias_Listar(string xml)
        {
            try
            {

                List<MarcasCE> lDatos = new List<MarcasCE>();
                DataTable dtDatos = obj.F_Marcas_Por_Familias_Listar(xml);

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new MarcasCE()
                    {
                        Marca = r["Marca"].ToString()
                    });
                };

                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_FlagDetraccion_Select(TCTipoCambioCE objEntidad)
        {
            try
            {

                return obj.F_FlagDetraccion_Select(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}