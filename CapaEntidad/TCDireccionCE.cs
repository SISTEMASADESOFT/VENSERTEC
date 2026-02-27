using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TCDireccionCE
{
    public int CodDireccion { get; set; }
    public int CodSede { get; set; }
    public int CodCtaCte { get; set; }
    public int CodDepartamento { get; set; }
    public int CodProvincia { get; set; }
    public int CodDistrito { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Email2 { get; set; }
    public string Email3 { get; set; }
    public string Email4 { get; set; }
    public string Email5 { get; set; }
    public string Email6 { get; set; }
    public string Celular { get; set; }

    public int Temporal { get; set; }
}


public class TCDireccionesEmail
{
    public int CodCtaCte { get; set; }
    public int CodDireccion { get; set; }
    public int Nro { get; set; }
    public string Email { get; set; }
}

public class CorreosDocumentosEnvios
{
    public int id { get; set; }
    public string idTransaccion { get; set; }
    public int CodUsuario { get; set; }
    public string Usuario { get; set; }
    public DateTime Fecha { get; set; }
    public string FechaStr { get; set; }
    public int CodDocumentoVenta { get; set; }
    public int CodProforma { get; set; }
    public string Email { get; set; }
    public int Enviado { get; set; }
    public DateTime FechaEnvio { get; set; }
    public string FechaEnvioStr { get; set; }

    public string Cliente { get; set; }
    public string NroRuc { get; set; }
    public string Factura { get; set; }
    public string Total { get; set; }
    public string FechaEmision { get; set; }
    public string TipoDoc { get; set; }
    public string Empresa { get; set; }
}

public class EmisorE
{
    public int ID_Emisor { get; set; }
    public int ID_Area_Empresa { get; set; }
    public string T_Correo { get; set; }
    public string T_SmtpHost { get; set; }
    public int N_Puerto { get; set; }
    public string T_Clave { get; set; }
    public string T_Descripcion_Area { get; set; }
}