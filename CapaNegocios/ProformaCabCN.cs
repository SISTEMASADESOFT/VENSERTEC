using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
    public class ProformaCabCN
    {
        ProformaCabCD obj = new ProformaCabCD();

        public ProformaCabCE F_Proformas_Insert(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Proformas_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProformaCabCE F_Proformas_Insert_William(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Proformas_Insert_William(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProformaCabCE F_Proformas_Insert_Edicion_William(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Proformas_Insert_Edicion_William(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProformaCabCE F_Proformas_Insert_Mercedes(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Proformas_Insert_Mercedes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProformaCabCE F_Proformas_Anulacion(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Proformas_Anulacion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProformaCabCE F_Proformas_Anulacion_Mercedes(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Proformas_Anulacion_Mercedes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_ProformaCab_VistaPreliminar(ProformaCabCE objEntidadBE)
        {

            try
            {

                return obj.F_ProformaCab_VistaPreliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_ProformaCab_Select(ProformaCabCE objEntidadBE)
        {

            try
            {

                return obj.F_ProformaCab_Select(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_ProformaCab_Select_Detalle(ProformaCabCE objEntidadBE)
        {

            try
            {

                return obj.F_ProformaCab_Select_Detalle(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_ProformaCab_ListarXCodigo(ProformaCabCE objEntidadBE)
        {

            try
            {

                return obj.F_ProformaCab_ListarXCodigo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProformaCabCE F_ProformaDet_InsertTemporal(ProformaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_ProformaDet_InsertTemporal(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ProformaCabCE> F_ProformaCab_ListarXEstado(ProformaCabCE objEntidadBE)
        {

            List<ProformaCabCE> lProformaCab = new List<ProformaCabCE>();

            try
            {
                DataTable dtDatos = obj.F_ProformaCab_ListarXEstado(objEntidadBE);
                foreach (DataRow i in dtDatos.Rows)
                {
                    ProformaCabCE newpr = new ProformaCabCE()
                    {
                        CodProforma = int.Parse(i["CodProforma"].ToString()),
                        Serie = i["SerieDoc"].ToString(),
                        Numero = i["NumeroDoc"].ToString(),
                        NroRuc = i["NroRuc"].ToString(),
                        Cliente = i["Cliente"].ToString(),
                        Vendedor = i["Vendedor"].ToString(),
                        Observacion = i["Observacion"].ToString(),
                        FechaEmision = DateTime.Parse(i["Emision"].ToString()),
                        EmisionStr = i["Emision"].ToString(),
                        Vencimiento = DateTime.Parse(i["Vencimiento"].ToString()),
                        VencimientoStr = i["Vencimiento"].ToString(),
                        CodCtaCte = int.Parse(i["CodCtaCte"].ToString()),
                        CodFormaPago = int.Parse(i["CodFormaPago"].ToString()),
                        CodMoneda = int.Parse(i["CodMoneda"].ToString()),
                        TipoCambio = decimal.Parse(i["TC"].ToString()),
                        SubTotal = decimal.Parse(i["SubTotal"].ToString()),
                        Igv = decimal.Parse(i["Igv"].ToString()),
                        Total = decimal.Parse(i["Total"].ToString()),
                        COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString()),
                        FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString()),
                        CodDepartamento = int.Parse(i["CodDepartamento"].ToString()),
                        CodProvincia = int.Parse(i["CodProvincia"].ToString()),
                        CodDistrito = int.Parse(i["CodDistrito"].ToString()),
                        Distrito = i["Distrito"].ToString(),
                        Direccion = i["Direccion"].ToString(),
                        FlagIgv = int.Parse(i["FlagCSIgv"].ToString()),
                        NroOperacion = i["NroOperacion"].ToString(),
                        CodEmpleado = int.Parse(i["CodEmpleado"].ToString()),
                        Placa = i["Placa"].ToString(),
                        KM = i["KM"].ToString(),
                    };
                    lProformaCab.Add(newpr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lProformaCab;
        }

        public ProformaCabCE F_ProformaCab_ObtenerXNumero(ProformaCabCE objEntidadBE)
        {

            try
            {
                DataTable dtDatos = obj.F_ProformaCab_ObtenerXNumero(objEntidadBE);
                try
                {
                    foreach (DataRow i in dtDatos.Rows)
                    {
                        objEntidadBE.CodProforma = int.Parse(i["CodProforma"].ToString());
                        objEntidadBE.Serie = i["SerieDoc"].ToString();
                        objEntidadBE.Numero = i["NumeroDoc"].ToString();
                        objEntidadBE.NroRuc = i["NroRuc"].ToString();
                        objEntidadBE.Cliente = i["Cliente"].ToString();
                        objEntidadBE.Vendedor = i["Vendedor"].ToString();
                        objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                        objEntidadBE.EmisionStr = objEntidadBE.FechaEmision.ToString();
                        objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                        objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString();
                        objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                        objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                        objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                        objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                        objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                        objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                        objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                        objEntidadBE.COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString());
                        objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                        objEntidadBE.NroRuc = i["NroRuc"].ToString();
                        objEntidadBE.Cliente = i["Cliente"].ToString();
                        objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                        objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                        objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                        objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                        objEntidadBE.Distrito = i["Distrito"].ToString();
                        objEntidadBE.Direccion = i["Direccion"].ToString();
                        objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());
                        objEntidadBE.NroOperacion = i["NroOperacion"].ToString();
                        objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());
                        objEntidadBE.Placa = i["Placa"].ToString();
                        objEntidadBE.Placa2 = i["Placa2"].ToString();
                        objEntidadBE.Placa3 = i["Placa3"].ToString();
                        objEntidadBE.Placa4 = i["Placa4"].ToString();
                        objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                        objEntidadBE.Requerimiento = i["Requerimiento"].ToString();
                        objEntidadBE.KM = i["KM"].ToString();

                        objEntidadBE.FlagComisionable = int.Parse(i["FlagComisionable"].ToString());
                        objEntidadBE.Observacion = i["Observacion"].ToString();
                        objEntidadBE.Atencion = i["Atencion"].ToString();
                        objEntidadBE.NroOC = i["NroOC"].ToString();


                        objEntidadBE.lProformaDet = new List<Proformadet>();
                        dtDatos = (new ProformaCabCN()).F_ProformaDet_ListarXCodigo(objEntidadBE);
                        foreach (DataRow r in dtDatos.Rows)
                        {
                            objEntidadBE.lProformaDet.Add(new Proformadet()
                            {
                                CodDetalleProforma = int.Parse(r["CodDetalleProforma"].ToString()),
                                CodProforma = int.Parse(r["CodProforma"].ToString()),
                                CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                                Cantidad = decimal.Parse(r["Cantidad"].ToString()),
                                CantidadEntregada = decimal.Parse(r["CantidadEntregada"].ToString()),
                                Precio = decimal.Parse(r["Precio"].ToString()),
                                ValorVenta = decimal.Parse(r["ValorVenta"].ToString()),
                                Descripcion = r["Descripcion"].ToString(),
                                CodUnidadMedida = int.Parse(r["CodUnidadVenta"].ToString()),
                                Descuento = decimal.Parse(r["Descuento"].ToString()),
                                Comentario = r["Comentario"].ToString(),
                                CodTiempoProducto = int.Parse(r["CodTiempoProducto"].ToString()),
                                TiempoProducto = r["TiempoProducto"].ToString(),
                                CodProductoPresentacion = int.Parse(r["CodProductoPresentacion"].ToString()),
                                CodGratuito = int.Parse(r["CodGratuito"].ToString()),
                                Precio2 = decimal.Parse(r["Precio2"].ToString())
                            });
                        }
                    }
                }
                catch (Exception ex)
                { }
                finally
                { }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private DataTable F_ProformaDet_ListarXCodigo(ProformaCabCE objEntidadBE)
        {

            try
            {

                return obj.F_ProformaDet_ListarXCodigo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
