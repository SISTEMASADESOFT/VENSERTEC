using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LGProductosCE
{
	public int CodProducto {get ;set ; }
	public string CodAlterno {get ;set ; }
	public int CodEmpresa {get ;set ; }
	public int CodAlmacen {get ;set ; }
	public string CodFamilia {get ;set ; }
	public string CodLinea {get ;set ; }
	public string CodSubLinea {get ;set ; }
	public int CodTipoProducto {get ;set ; }
	public string ServAlterno {get ;set ; }
	public int CodClasificacion {get ;set ; }
	public string Ambos_Preventivo_Correctivo {get ;set ; }
	public int CodSistema {get ;set ; }
	public int CodCapacidad {get ;set ; }
	public string DscProducto {get ;set ; }
    public string DscProductoIngles { get; set; }
	public int CodMarca {get ;set ; }
	public int CodUnidadCompra {get ;set ; }
	public int CodUnidadVenta {get ;set ; }
	public string Medida {get ;set ; }
	public string CodColor {get ;set ; }
	public string Peso {get ;set ; }
	public int CodPais {get ;set ; }
	public string ActivoFijo {get ;set ; }
	public decimal  CostoProducto {get ;set ; }
	public decimal CostoUniProducto {get ;set ; }
	public int CodIndicador {get ;set ; }
	public string Observacion {get ;set ; }
	public string FlagEquivalencia {get ;set ; }
	public string Estado {get ;set ; }
	public int CodUsuario {get ;set ; }
	public DateTime FechaRegistro {get ;set ; }
	public int CodUsuarioMod {get ;set ; }
	public DateTime FechaModificacion {get ;set ; }
	public int CodUsuarioAnul {get ;set ; }
	public DateTime FechaAnulacion {get ;set ; }
	public string Capacidad {get ;set ; }
	public string Anaquel {get ;set ; }
	public string Fila {get ;set ; }
	public decimal CostoMercado {get ;set ; }
	public string CodigoProducto {get ;set ; }
	public decimal Precio {get ;set ; }
	public string CodigoAlternativo {get ;set ; }
	public decimal Precio2 {get ;set ; }
	public decimal Precio3 {get ;set ; }
	public int CodMoneda {get ;set ; }
	public string Aro {get ;set ; }
	public string Suplemento {get ;set ; }
	public string DescripcionCorta {get ;set ; }
	public string Medida2 {get ;set ; }
	public string Aro2 {get ;set ; }
	public decimal CostoOriginal {get ;set ; }
	public decimal CostoUniOriginal {get ;set ; }
	public string Medida3 {get ;set ; }
	public decimal Aro3 {get ;set ; }
	public decimal Seccion {get ;set ; }
	public decimal CostoMarginable {get ;set ; }
    public int Factor { get; set; }
    public string MsgError { get; set; }
    public int Flag { get; set; }
    public string XmlDetalle { get; set; }
    public int Periodo { get; set; }
    public int CodTipoOperacion { get; set; }
    public int CodCtaCte { get; set; }
    public decimal Descuento { get; set; }
    public decimal Margen { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Pais { get; set; }
    public string Posicion { get; set; }
    public string Año { get; set; }
    public string DescripcionAuxiliar { get; set; }
    public string DscProducto2 { get; set; }
    public string Ubicacion { get; set; }
    public string Motor { get; set; }
    public int CodTipoDoc { get; set; }
    public int CodCliente { get; set; }
    public int CodEstado { get; set; }
    public decimal StockMinimo { get; set; }
    public string Comentario { get; set; }
    public int ID_TemporalImagen { get; set; }
    public byte[] B_ImagenTem { get; set; }
    public String T_NombreArchivo { get; set; }
    public String T_Preview { get; set; }
    public string T_Ruta { get; set; }
    public long T_Tamaño { get; set; }

    public int CodModeloVehiculo { get; set; }
    public string Anio { get; set; }
    public string Transmision { get; set; }
    public string CajaCambio { get; set; }
    public string Filtro { get; set; }
    public string IPRegistro { get; set; }
    public int CodProductoModelo { get; set; }
    public string IPModificacion { get; set; }


    public int codmovimiento { get; set; }

    public int FlagProductosConStock { get; set; }

    public DateTime Hasta { get; set; }

    public DateTime Desde { get; set; }

    public int CodEmpleado { get; set; }

    public int CodDetraccion { get; set; }
}
