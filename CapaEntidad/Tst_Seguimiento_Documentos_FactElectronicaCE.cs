using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Tst_Seguimiento_Documentos_FactElectronicaCE
    {
        public int ID_SegDoc_FacElec { get; set; }
        public int ID_DocumentoVenta { get; set; }
        public string T_Mensaje_Rpta_Sunat { get; set; }
        public int ID_Estado_Proceso_FacElec { get; set; }
        public int ID_Estado_Envio_Correo_Sistema { get; set; }
        public string T_Estado_Proceso_FacElec { get; set; }
        public int ID_Estado_Rpta_Sunat_FacElec { get; set; }
        public string T_Estado_Rpta_Sunat_FacElec { get; set; }

        public string T_NombreArchivo_FacEle { get; set; }
        public string T_ExtensionArchivo_FacEle { get; set; }

        public int PAGE_NUMBER { get; set; }
        public int PAGE_SIZE { get; set; }

        public string T_Nro_Serie { get; set; }
        public string T_Nro_Documento { get; set; }
        public int Fecha_Inicio { get; set; }
        public int Fecha_Fin { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Tipo_Documento { get; set; }
    }