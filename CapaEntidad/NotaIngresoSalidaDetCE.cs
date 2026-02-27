using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class NotaIngresoSalidaDetCE
{
	public int CodDetalle {get ;set ; }
	public int CodMovimiento {get ;set ; }
	public int CodArticulo {get ;set ; }
	public int Cantidad {get ;set ; }
	public int CodUndMedida {get ;set ; }
	public decimal CostoProducto {get ;set ; }
	public decimal PRECIO {get ;set ; }
	public decimal CostoDescontado {get ;set ; }

}
