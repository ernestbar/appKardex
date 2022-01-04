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
    public class Curso_postulacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_CURSO = 0;
        private Int64 _PB_PER_ID_PERSONAL = 0;
        private string _PV_CNV_CONVOCATORIA = "";
        private string _PV_TIPO_CAPACITACION = "";
        private string _PV_INSTITUCION = "";
        private int _PI_TOTAL_HORAS = 0;
        private DateTime _PD_FECHA_INICIO = DateTime.Parse("01/01/3000");
        private DateTime _PD_FECHA_FIN = DateTime.Parse("01/01/3000");
        private string _PV_CIUDAD = "";
        private string _PV_TITULO_OBTENIDO = "";
        private DateTime _PD_FECHA_TITULO = DateTime.Parse("01/01/3000");
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_CURSO { get { return _PB_ID_CURSO; } set { _PB_ID_CURSO = value; } }
        public Int64 PB_PER_ID_PERSONAL { get { return _PB_PER_ID_PERSONAL; } set { _PB_PER_ID_PERSONAL = value; } }
        public string PV_CNV_CONVOCATORIA { get { return _PV_CNV_CONVOCATORIA; } set { _PV_CNV_CONVOCATORIA = value; } }
        public string PV_TIPO_CAPACITACION { get { return _PV_TIPO_CAPACITACION; } set { _PV_TIPO_CAPACITACION = value; } }
        public string PV_INSTITUCION { get { return _PV_INSTITUCION; } set { _PV_INSTITUCION = value; } }
        public int PI_TOTAL_HORAS { get { return _PI_TOTAL_HORAS; } set { _PI_TOTAL_HORAS = value; } }
        public DateTime PD_FECHA_INICIO { get { return _PD_FECHA_INICIO; } set { _PD_FECHA_INICIO = value; } }
        public DateTime PD_FECHA_FIN { get { return _PD_FECHA_FIN; } set { _PD_FECHA_FIN = value; } }
        public string PV_CIUDAD { get { return _PV_CIUDAD; } set { _PV_CIUDAD = value; } }
        public string PV_TITULO_OBTENIDO { get { return _PV_TITULO_OBTENIDO; } set { _PV_TITULO_OBTENIDO = value; } }
        public DateTime PD_FECHA_TITULO { get { return _PD_FECHA_TITULO; } set { _PD_FECHA_TITULO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        //public Experiencias_postulacion(Int64 PB_ID_CURSO)
        //{
        //    _PB_ID_CURSO = PB_ID_CURSO;
        //    RecuperarDatos();
        //}
        public Curso_postulacion(string pV_TIPO_OPERACION, string pV_CNV_CONVOCATORIA, Int64 pB_ID_CURSO, Int64 pB_PER_ID_PERSONAL, string pV_TIPO_CAPACITACION, string pV_INSTITUCION,
            string pV_CIUDAD, DateTime pD_FECHA_INICIO, DateTime pD_FECHA_FIN, int pI_TOTAL_HORAS,string pV_TITULO_OBTENIDO,DateTime pD_FECHA_TITULO,  
            string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_TIPO_CAPACITACION = pV_TIPO_CAPACITACION;
            _PB_ID_CURSO = pB_ID_CURSO;
            _PB_PER_ID_PERSONAL = pB_PER_ID_PERSONAL;
            _PV_CNV_CONVOCATORIA = pV_CNV_CONVOCATORIA;
            _PV_INSTITUCION = pV_INSTITUCION;
            _PI_TOTAL_HORAS = pI_TOTAL_HORAS;
            _PD_FECHA_INICIO = pD_FECHA_INICIO;
            _PD_FECHA_FIN = pD_FECHA_FIN;
            _PV_CIUDAD = pV_CIUDAD;
            _PV_TITULO_OBTENIDO = pV_TITULO_OBTENIDO;
            _PD_FECHA_TITULO = pD_FECHA_TITULO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        public static DataTable PR_VCO_GET_CURSO(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_CURSO");
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

        public static DataTable PR_VCO_GET_CURSO2(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_CURSO2");
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_CONV_CURSO");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_TIPO_CAPACITACION", DbType.String, _PV_TIPO_CAPACITACION);
                db1.AddInParameter(cmd, "PB_ID_CURSO", DbType.Int64, _PB_ID_CURSO);
                db1.AddInParameter(cmd, "PB_PER_ID_PERSONAL", DbType.Int64, _PB_PER_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, _PV_CNV_CONVOCATORIA);
                db1.AddInParameter(cmd, "PV_INSTITUCION", DbType.String, _PV_INSTITUCION);
                db1.AddInParameter(cmd, "PV_CIUDAD", DbType.String, _PV_CIUDAD);
                
                if (_PD_FECHA_INICIO == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_FECHA_INICIO", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_FECHA_INICIO", DbType.DateTime, _PD_FECHA_INICIO); }
                if (_PD_FECHA_FIN == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_FECHA_FIN", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_FECHA_FIN", DbType.DateTime, _PD_FECHA_FIN); }
                db1.AddInParameter(cmd, "PI_TOTAL_HORAS", DbType.Int32, _PI_TOTAL_HORAS);
                db1.AddInParameter(cmd, "PV_TITULO_OBTENIDO", DbType.String, _PV_TITULO_OBTENIDO);
                if (_PD_FECHA_TITULO == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_FECHA_TITULO", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_FECHA_TITULO", DbType.DateTime, _PD_FECHA_TITULO); }
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