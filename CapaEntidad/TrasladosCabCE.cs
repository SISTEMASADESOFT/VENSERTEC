using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TrasladosCabCE
{

	public int CodTraslado {get ;set ; }
	public int CodEmpresa {get ;set ; }
	public int CodDoc {get ;set ; }
	public string SerieDoc {get ;set ; }
	public string NumeroDoc {get ;set ; }
	public DateTime FechaEmision {get ;set ; }
	public DateTime FechaTraslado {get ;set ; }
	public int CodAlmacenPartida {get ;set ; }
	public int CodAlmacenLlegada {get ;set ; }
	public string Observacion {get ;set ; }
	public int Estado {get ;set ; }
	public int CodUsuario {get ;set ; }
	public DateTime FechaRegistro {get ;set ; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
	public int CodUsuarioAnulacion {get ;set ; }
	public DateTime FechaAnulacion {get ;set ; }
	public int GuiaEnlazada {get ;set ; }
    public int CodTipoOperacion { get; set; }
    public int CodCtaCte { get; set; }
    public string Direccion { get; set; }
    public string MsgError { get; set; }
    public int CodMotivoTraslado { get; set; }
    public int CodMecanico { get; set; }
    public int CodDocumentoVenta { get; set; }


    public int CodAlmacen { get; set; }

    public int CodTipoFormato { get; set; }

    public int CodEstado { get; set; }

    public int CodDireccion { get; set; }

    public string Partida { get; set; }

    public string Destino { get; set; }

    public int CodDetalle { get; set; }

    public int CodDepartamento { get; set; }

    public int CodTipoDoc { get; set; }

    public decimal TipoCambio { get; set; }

    public int CodMoneda { get; set; }

    public int CodTasa { get; set; }

    public int SubTotal { get; set; }

    public int Igv { get; set; }

    public int Total { get; set; }

    public string Cliente { get; set; }

    public int CodTrasladoAnterior { get; set; }

    public string NroReferencia { get; set; }

    public int CodTransportista { get; set; }

    public object CodDireccionTrans { get; set; }

    public object Placa { get; set; }

    public object NroBultos { get; set; }

    public object Licencia { get; set; }

    public object Marca { get; set; }

    public object Peso { get; set; }

    public int CodProforma { get; set; }

    public string TipoImpresion { get; set; }

    public int CodConductor { get; set; }

    public int CodPeso { get; set; }

    public int CodTipoTransportista { get; set; }

    public int CodDocumentoVentaDireccionDestino { get; set; }

    public int CodDocumentoVentaDireccionTransportista { get; set; }

    public string NroRucTransportista { get; set; }

    public string RazonSocialTransportista { get; set; }

    public string ObservacionGuia { get; set; }
}
