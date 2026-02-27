using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class DocumentoVentaDetCE
{
    
    public int CodDetDocumentoVenta { get; set; } 
	public int CodDocumentoVenta { get; set; } 
	public int CodCobranzaCab { get; set; } 
	public int CodOrdenRepuestoServicios { get; set; } 
	public int CodArticulo { get; set; } 
	public decimal  Cantidad { get; set; } 
	public int CodUndMedida { get; set; } 
	public decimal Precio { get; set; }
    public decimal Costo { get; set; }
    public string XmlDetalle { get; set; }
    public string MsgError { get; set; }
    public int CodTipoOperacion { get; set; }
    public int CodPagoCab { get; set; }
    public decimal TipoCambio { get; set; }
    public int FlagIgv { get; set; }
    public int CodTipoDoc { get; set; }
    public int CodAlmacen { get; set; }
    public int CodMoneda { get; set; }


    public int CodFacturaDet { get; set; }
    public decimal Soles { get; set; }
    public decimal Dolares { get; set; }
    public int CodComprobanteCaja { get; set; }

    public long IdTransaccion { get; set; }

    public int codigo { get; set; }

    public decimal PrecioOriginal { get; set; }

    public string Descripcion { get; set; }

    public int Flag { get; set; }
}
