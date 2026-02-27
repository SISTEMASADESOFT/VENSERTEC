using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class ResponsablesCE
    {
        public int CodResponsable { get; set; }
        public int CodCtaCte { get; set; }
        public string DatosPersonales { get; set; }
        public string Dni { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public string Correo3 { get; set; }
        public string Correo4 { get; set; }
        public string Correo5 { get; set; }
        public string Correo6 { get; set; }
        public int CodEstado { get; set; }
        public int CodUsuario { get; set; }

        public string MsgError { get; set; }
    }
}
