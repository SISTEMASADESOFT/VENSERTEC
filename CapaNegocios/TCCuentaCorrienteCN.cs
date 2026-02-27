using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
     
    public class TCCuentaCorrienteCN
    {
        TCCuentaCorrienteCD obj = new TCCuentaCorrienteCD();

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_ListarClientes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_ListarResponsable_AutoComplete(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_ListarResponsable_AutoComplete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_PadronSunat(ref TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_PadronSunat(ref objEntidadBE);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable pa_TCCuentaCorriente_BuscarClienteXRucDni(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.pa_TCCuentaCorriente_BuscarClienteXRucDni(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public TCCuentaCorrienteCE F_TCCuentaCorriente_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_Listar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCResponsables_Listar(ResponsablesCE objEntidadBE)
        {

            try
            {

                return obj.F_TCResponsables_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ResponsablesCE F_Responsables_Insert(ResponsablesCE objEntidadBE)
        {

            try
            {

                return obj.F_Responsables_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ResponsablesCE F_Responsables_Update(ResponsablesCE objEntidadBE)
        {

            try
            {

                return obj.F_Responsables_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public DataTable F_TCContactos_Listar(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_TCContactos_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Insert(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Update(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }





        public TCCuentaCorrienteCE F_LGFamilias_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

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

        public TCCuentaCorrienteCE F_LGFamilias_Delete(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Delete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<TCDireccionesEmail> F_Correos_Por_Cliente_Listar_NET(int CodCtaCte, int CodDireccion)
        {

            try
            {
                DataTable dLista = obj.F_Correos_Por_Cliente_Listar(CodCtaCte, CodDireccion);
                List<TCDireccionesEmail> lCorreos = new List<TCDireccionesEmail>();

                foreach (DataRow r in dLista.Rows)
                {
                    lCorreos.Add(new TCDireccionesEmail()
                    {
                        CodCtaCte = CodCtaCte,
                        CodDireccion = CodDireccion,
                        Nro = Convert.ToInt32(r["Nro"].ToString()),
                        Email = r["Email"].ToString()
                    });
                };
                return lCorreos;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<TCDireccionesEmail> F_Correos_Por_Responsable_Listar_NET(int CodResponsable)
        {

            try
            {
                DataTable dLista = obj.F_Correos_Por_Responsable_Listar(CodResponsable);
                List<TCDireccionesEmail> lCorreos = new List<TCDireccionesEmail>();

                foreach (DataRow r in dLista.Rows)
                {
                    lCorreos.Add(new TCDireccionesEmail()
                    {
                        CodCtaCte = CodResponsable,
                        CodDireccion = 0,
                        Nro = Convert.ToInt32(r["Nro"].ToString()),
                        Email = r["Email"].ToString()
                    });
                };
                return lCorreos;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public string F_Correos_Por_Cliente_Actualizar_NET(int CodDireccion, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6, int CodUsuario, int CodDocumentoVenta, int CodTipoDoc)
        {

            try
            {
                return obj.F_Correos_Por_Cliente_Actualizar(CodDireccion, Email1, Email2, Email3, Email4, Email5, Email6, CodUsuario, CodDocumentoVenta, CodTipoDoc).MsgError;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string F_Correos_Por_Responsable_Actualizar_NET(int CodDireccion, string Email1, string Email2, string Email3, string Email4, string Email5, string Email6, int CodUsuario, int CodDocumentoVenta, int CodTipoDoc)
        {

            try
            {
                return obj.F_Correos_Por_Responsable_Actualizar(CodDireccion, Email1, Email2, Email3, Email4, Email5, Email6, CodUsuario, CodDocumentoVenta, CodTipoDoc).MsgError;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public TCCuentaCorrienteCE F_Linea_Insertar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Insertar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Actualizar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listar()
        {
            try
            {
                return obj.F_Linea_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LINEA_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LINEA_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Insertar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Insertar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Actualizar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listar()
        {
            try
            {
                return obj.F_Modelo_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_MODELOVEHICULO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_MODELOVEHICULO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_MARCAPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_MARCAPRODUCTO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable F_Familia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_Familia_AUTOCOMPLETE(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable F_producto_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_producto_AUTOCOMPLETE(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_BuscarDatosPorRucDni(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_BuscarDatosPorRucDni(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_Usuario_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_Usuario_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_TCCUENTACORRIENTE_ENTER_ONBLUR(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCUENTACORRIENTE_ENTER_ONBLUR(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
