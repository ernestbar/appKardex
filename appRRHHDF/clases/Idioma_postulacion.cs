using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class Idioma_postulacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_IDIOMA = 0;
        private Int64 _PB_PER_ID_PERSONAL = 0;
        private string _PV_CNV_CONVOCATORIA = "";
        private string _PV_NIVEL_DOMINIO_LECTURA = "";
        private string _PV_NIVEL_DOMINIO_ESCRITURA = "";
        private string _PV_NIVEL_DOMINIO_CONVERSACION = "";
        private string _PV_CON_TITULO = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_IDIOMA { get { return _PB_ID_IDIOMA; } set { _PB_ID_IDIOMA = value; } }
        public Int64 PB_PER_ID_PERSONAL { get { return _PB_PER_ID_PERSONAL; } set { _PB_PER_ID_PERSONAL = value; } }
        public string PV_CNV_CONVOCATORIA { get { return _PV_CNV_CONVOCATORIA; } set { _PV_CNV_CONVOCATORIA = value; } }
        public string PV_NIVEL_DOMINIO_ESCRITURA { get { return _PV_NIVEL_DOMINIO_ESCRITURA; } set { _PV_NIVEL_DOMINIO_ESCRITURA = value; } }
        public string PV_NIVEL_DOMINIO_CONVERSACION { get { return _PV_NIVEL_DOMINIO_CONVERSACION; } set { _PV_NIVEL_DOMINIO_CONVERSACION = value; } }
        public string PV_CON_TITULO { get { return _PV_CON_TITULO; } set { _PV_CON_TITULO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        //public Experiencias_postulacion(Int64 PB_ID_IDIOMA)
        //{
        //    _PB_ID_IDIOMA = PB_ID_IDIOMA;
        //    RecuperarDatos();
        //}
        public Idioma_postulacion(string pV_TIPO_OPERACION,string pV_CNV_CONVOCATORIA, string pV_NIVEL_DOMINIO_ESCRITURA, Int64 pB_ID_IDIOMA, Int64 pB_PER_ID_PERSONAL, string pV_NIVEL_DOMINIO_LECTURA, string pV_NIVEL_DOMINIO_CONVERSACION,
            string pV_CON_TITULO, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_CNV_CONVOCATORIA = pV_CNV_CONVOCATORIA;
            _PV_NIVEL_DOMINIO_ESCRITURA = pV_NIVEL_DOMINIO_ESCRITURA;
            _PB_ID_IDIOMA = pB_ID_IDIOMA;
            _PB_PER_ID_PERSONAL = pB_PER_ID_PERSONAL;
            _PV_NIVEL_DOMINIO_LECTURA = pV_NIVEL_DOMINIO_LECTURA;
            _PV_NIVEL_DOMINIO_CONVERSACION = pV_NIVEL_DOMINIO_CONVERSACION;
            _PV_CON_TITULO = pV_CON_TITULO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        public static DataTable PR_VCO_GET_IDIOMA(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_IDIOMA");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_VCO_GET_IDIOMA2(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_IDIOMA2");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }


        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_CONV_IDIOMA");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, _PV_CNV_CONVOCATORIA);
                db1.AddInParameter(cmd, "PB_ID_IDIOMA", DbType.Int64, _PB_ID_IDIOMA);
                db1.AddInParameter(cmd, "PB_PER_ID_PERSONAL", DbType.Int64, _PB_PER_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_NIVEL_DOMINIO_ESCRITURA", DbType.String, _PV_NIVEL_DOMINIO_ESCRITURA);
                db1.AddInParameter(cmd, "PV_NIVEL_DOMINIO_LECTURA", DbType.String, _PV_NIVEL_DOMINIO_LECTURA);
                db1.AddInParameter(cmd, "PV_NIVEL_DOMINIO_CONVERSACION", DbType.String, _PV_NIVEL_DOMINIO_CONVERSACION);
                db1.AddInParameter(cmd, "PV_CON_TITULO", DbType.String, _PV_CON_TITULO);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PI_PER_ID_PERSONALOUT").ToString()))
                //    PB_ID_REFERENCIA = 0;
                //else
                //    PB_ID_REFERENCIA = Int64.Parse(db1.GetParameterValue(cmd, "PI_PER_ID_PERSONALOUT").ToString());
                PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCION = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCION;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "||" + "Se produjo un error al registrar: " + ex.ToString();
                return resultado;
            }
        }
    }
}