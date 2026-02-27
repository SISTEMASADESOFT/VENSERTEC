using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TCCuentaCorrienteCE
{

    public int CodEmpresa { get; set; }
    public int CodCtaCte { get; set; }
    public int CodTipoCtacte { get; set; }
    public int CodTipoCliente { get; set; }
    public int CodClaseCliente { get; set; }
    public string ApePaterno { get; set; }
    public string ApeMaterno { get; set; }
    public string Nombres { get; set; }
    public string RazonSocial { get; set; }
    public string NroRuc { get; set; }
    public string NroDni { get; set; }
    public int CodDepartamento { get; set; }
    public int CodProvincia { get; set; }
    public int CodDistrito { get; set; }
    public string Direccion { get; set; }
    public string Referencia { get; set; }
    public string NroTelefono { get; set; }
    public string Email { get; set; }
    public string PaginaWeb { get; set; }
    public DateTime FechaUltCompra { get; set; }
    public string Estado { get; set; }
    public string DspPosterior { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioMod { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CodUsuarioAnul { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public string TipoDocumento { get; set; }
    public string NumCuenta { get; set; }
    public string DireccionEnvio { get; set; }
    public string MsgError { get; set; }
    public int FlagCliente { get; set; }
    public int FlagProveedor { get; set; }
    public string DscFamilia { get; set; }
    public int CodEstado { get; set; }
    public int IDFamilia { get; set; }
    public int NroError { get; set; }

    public int CodModeloVehiculo { get; set; }
    public int CodLinea { get; set; }
    public string Descripcion { get; set; }
    public string IPRegistro { get; set; }
    public string IPModificacion { get; set; }

    public int CodTipoCtaCte { get; set; }

    public int FlagRetencion { get; set; }

    public string dscAlmacen { get; set; }

    public int FlagPrincipal { get; set; }

    public string Usuario { get; set; }

    public string Contraseña { get; set; }

    public string ContraseñaNueva { get; set; }

    public string Confirmacion { get; set; }

    public string Distrito { get; set; }

    public int CodDireccion { get; set; }
}
