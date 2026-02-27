using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Empleados
{

	public int CodEmpleado {get ;set;}
	public int CodCargo {get ;set;}
	public int CodSede {get ;set;}
	public string Nombres {get ;set;}
	public string ApePaterno {get ;set;}
	public string ApeMaterno {get ;set;}
	public string DocIdentidad {get ;set;}
    public string Usuario { get; set; }
	public int CodUsuario {get ;set;}

}
