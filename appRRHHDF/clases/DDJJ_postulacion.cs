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
    public class DDJJ_postulacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_CDD_CONVOCATORIA_DDJJ = "";
        private string _PV_CNV_CONVOCATORIA = "";
        private string _PV_CONVOCATORIA_DJ = "";
        private Int64 _PB_CDD_NRO = 0;
        private Int64 _PB_PER_ID_PERSONAL = 0;
        private string _PV_PREGUNTA = "";
        private string _PV_VALOR = "";
        private string _PV_TIPO = "";
        private string _PV_LISTA = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_CDD_CONVOCATORIA_DDJJ { get { return _PV_CDD_CONVOCATORIA_DDJJ; } set { _PV_CDD_CONVOCATORIA_DDJJ = value; } }
        public string PV_CNV_CONVOCATORIA { get { return _PV_CNV_CONVOCATORIA; } set { _PV_CNV_CONVOCATORIA= value; } }
        public string PV_CONVOCATORIA_DJ { get { return _PV_CONVOCATORIA_DJ; } set { _PV_CONVOCATORIA_DJ = value; } }
        public Int64 PB_CDD_NRO { get { return _PB_CDD_NRO; } set { _PB_CDD_NRO = value; } }
        public Int64 PB_PER_ID_PERSONAL { get { return _PB_PER_ID_PERSONAL; } set { _PB_PER_ID_PERSONAL = value; } }
        public string PV_PREGUNTA { get { return _PV_PREGUNTA; } set { _PV_PREGUNTA = value; } }
        public string PV_VALOR { get { return _PV_VALOR; } set { _PV_VALOR = value; } }
        public string PV_TIPO { get { return _PV_TIPO; } set { _PV_TIPO = value; } }
        public string PV_LISTA { get { return _PV_LISTA; } set { _PV_LISTA = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        //public Experiencias_postulacion(Int64 PB_CDD_NRO)
        //{
        //    _PB_CDD_NRO = PB_CDD_NRO;
        //    RecuperarDatos();
        //}
        public DDJJ_postulacion(string pV_TIPO_OPERACION, string pV_CDD_CONVOCATORIA_DDJJ, string pV_CNV_CONVOCATORIA, string pV_CONVOCATORIA_DJ, Int64 pB_CDD_NRO, Int64 pB_PER_ID_PERSONAL, string pV_PREGUNTA,
            string pV_VALOR,string pV_TIPO,string pV_LISTA, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_CDD_CONVOCATORIA_DDJJ = pV_CDD_CONVOCATORIA_DDJJ;
            _PV_CONVOCATORIA_DJ = pV_CONVOCATORIA_DJ;
            _PB_CDD_NRO = pB_CDD_NRO;
            _PB_PER_ID_PERSONAL = pB_PER_ID_PERSONAL;
            _PV_CNV_CONVOCATORIA = pV_CNV_CONVOCATORIA;
            _PV_PREGUNTA = pV_PREGUNTA;
            _PV_VALOR = pV_VALOR;
            _PV_LISTA = pV_LISTA;
            _PV_TIPO = pV_TIPO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        public static DataTable PR_VCO_GET_DDJJ(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA, string PV_USUARIO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_DDJJ");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
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

        public static DataTable PR_VCO_GET_DDJJrep(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA, string PV_USUARIO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_DDJJrep");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_PREGUNTAS_DDJJ");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_CDD_CONVOCATORIA_DDJJ", DbType.String, _PV_CDD_CONVOCATORIA_DDJJ);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, _PV_CNV_CONVOCATORIA);
                db1.AddInParameter(cmd, "PV_CONVOCATORIA_DJ", DbType.String, _PV_CONVOCATORIA_DJ);
                db1.AddInParameter(cmd, "PB_CDD_NRO", DbType.Int64, _PB_CDD_NRO);
                db1.AddInParameter(cmd, "PB_PER_ID_PERSONAL", DbType.Int64, _PB_PER_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_PREGUNTA", DbType.String, _PV_PREGUNTA);
                db1.AddInParameter(cmd, "PV_VALOR", DbType.String, _PV_VALOR);
                db1.AddInParameter(cmd, "PV_TIPO", DbType.String, _PV_TIPO);
                db1.AddInParameter(cmd, "PV_LISTA", DbType.String, _PV_LISTA);
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