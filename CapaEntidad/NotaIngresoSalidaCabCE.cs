using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class NotaIngresoSalidaCabCE
{

	public int CodMovimiento {get ;set ; }
	public int CodTipoOperacion {get ;set ; }
	public string DscOtraOperacion {get ;set ; }
	public int CodOrdenCompra {get ;set ; }
	public int CodTipoDoc {get ;set ; }
	public string SerieDoc {get ;set ; }
	public string NumeroDoc {get ;set ; }
	public int CodAlmacen {get ;set ; }
	public int CodAlmacenOrigen {get ;set ; }
	public int CodOrdenTrabajo {get ;set ; }
	public int CodOrdenRepuestoServicios {get ;set ; }
	public int CodPlaca {get ;set ; }
	public int CodTipoDocSust {get ;set ; }
	public string SerieDocSust {get ;set ; }
	public string NumeroDocSust {get ;set ; }
    public string MsgError { get; set; }
	public int CodTasa {get ;set ; }
    public int Periodo { get; set; }
	public int CodUsuario {get ;set ; }
	public DateTime FechaRegistro {get ;set ; }
    public int CodDetalle { get; set; }
    public DateTime Vencimiento { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaEmision { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
	public int CodEstado {get ;set ; }
	public int CodMecanico {get ;set ; }
	public int CodMoneda {get ;set ; }
	public int CodCtaCte {get ;set ; }
    public int Codigo { get; set; }
	public int CodEmpresa {get ;set ; }
    public int FlagLetra { get; set; }
    public int FlagIgv { get; set; }
	public decimal ImpSubTotal {get ;set ; }
	public decimal ImpIGV {get ;set ; }
	public decimal ImpTotal {get ;set ; }
    public decimal SubTotal { get; set; }
    public decimal Igv { get; set; }
    public decimal Total { get; set; }
	public int CodFormaPago {get ;set ; }
	public decimal Descuento {get ;set ; }
	public decimal TipoCambio {get ;set ; }
    public decimal TasaIgv { get; set; }
    public int CodigoTemporal { get; set; }
    public int CodigoTemporalCobranzas { get; set; }
    public int CodMedioPago { get; set; }
    public string NroOperacion { get; set; }
    public string Observacion { get; set; }
    public string Responsable { get; set; }
    public string XmlDetalle { get; set; }
    public int CodBanco { get; set; }
    public int CodCtaBancaria { get; set; }
    public DateTime FechaOperacion { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoFactura { get; set; }
    public decimal NoAfecto { get; set; }
    public int CodPago { get; set; }
    public int CodClasificacion { get; set; }
    public int CodCategoria { get; set; }
    public int CodFactura_Asociada { get; set; }
    public int CodTipoOperacionNC { get; set; }
    public int CodSerie { get; set; }
    public int FlagPercepcion { get; set; }
    public int CodFacturaAnterior { get; set; }
    public int CodTipoFormato { get; set; }
    public int chkRegistro { get; set; }
    public int CodDireccion { get; set; }
    public int CodDepartamento { get; set; }
    public int CodProvincia { get; set; }
    public int CodDistrito { get; set; }
    public string RazonSocial { get; set; }
    public string NroDni { get; set; }
    public string NroRuc { get; set; }
    public string Direccion { get; set; }

    public string Guia { get; set; }

    public int CodComprobanteCaja { get; set; }
    public int CodDocumentoVenta { get; set; }
    public decimal SaldoComprobante { get; set; }
    public int CodMotivo { get; set; }

    public string Proveedor { get; set; }
    public int CodCajaFisica { get; set; }
    public int CodPagoCab { get; set; }


    public string ObservacionAnulacion { get; set; }

    public int FlagRenovar { get; set; }

    public string Factura { get; set; }

    public int CodRecibido { get; set; }

    public int CodEntregado { get; set; }

    public string FormaPago { get; set; }

    public int Motorizado { get; set; }

    public int Detallado { get; set; }
}
