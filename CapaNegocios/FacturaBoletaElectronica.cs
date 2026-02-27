using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos;
using System.IO;
using CapaEntidad;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace CapaNegocios
{
    public class FacturaBoletaElectronica
    {

        public string[] F_Generar_Trama_Correo_Pendiente()
        {
            List<String> objLista = new List<String>();
            DataTable dt = new DataTable();

            Tst_Seguimiento_Documentos_FactElectronicaCE objEntidadCE = new Tst_Seguimiento_Documentos_FactElectronicaCE();
            var objOperacion = new DocumentoVentaCabCD();

            dt = objOperacion.F_Obtener_Documento_CorreoPendinteEnvio();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objLista.Add(String.Format("{0}:{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}*{10}", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], dt.Rows[i][8], dt.Rows[i][9], dt.Rows[i][10]));
            }

            string[] array_nom = new string[0];
            array_nom = objLista.ToArray();

            return array_nom;
        }

        public Tsm_Parametros_General_RSL F_Select_One_ParametrosGenerales(Tsm_Parametros_General_FLT oFilter)
        {
            var operacion = new Tsm_Parametros_GeneralCD();
            return operacion.F_Select_One_ParametrosGenerales(oFilter);
        }

    }
}
