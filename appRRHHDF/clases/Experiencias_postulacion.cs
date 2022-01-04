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
    public class Experiencias_postulacion
    { //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_EXPERIENCIA = 0;
        private Int64 _PB_PER_ID_PERSONAL = 0;
        private string _PV_PEX_EMPRESA = "";
        private string _PV_CNV_CONVOCATORIA = "";
        private string _PV_CNF_CARGO = "";
        private string _PV_CNF_DEPARTAMENTO_CARGO = "";
        private Int64 _PB_CNF_TOTAL_EXPERIENCIAS = 0;
        private DateTime _PD_FECHA_INICIO = DateTime.Parse("01/01/3000");
        private DateTime _PD_FECHA_FIN  = DateTime.Parse("01/01/3000");
        private string _PV_CON_TITULO = "";
      
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_EXPERIENCIA { get { return _PB_ID_EXPERIENCIA; } set { _PB_ID_EXPERIENCIA = value; } }
        public Int64 PB_PER_ID_PERSONAL { get { return _PB_PER_ID_PERSONAL; } set { _PB_PER_ID_PERSONAL = value; } }
        public string PV_PEX_EMPRESA { get { return _PV_PEX_EMPRESA; } set { _PV_PEX_EMPRESA = value; } }
        public string PV_CNV_CONVOCATORIA { get { return _PV_CNV_CONVOCATORIA; } set { _PV_CNV_CONVOCATORIA = value; } }
        public string PV_CNF_CARGO { get { return _PV_CNF_CARGO; } set { _PV_CNF_CARGO = value; } }
        public string PV_CNF_DEPARTAMENTO_CARGO { get { return _PV_CNF_DEPARTAMENTO_CARGO; } set { _PV_CNF_DEPARTAMENTO_CARGO = value; } }
        public Int64 PB_CNF_TOTAL_EXPERIENCIAS { get { return _PB_CNF_TOTAL_EXPERIENCIAS; } set { _PB_CNF_TOTAL_EXPERIENCIAS = value; } }
        public DateTime PD_FECHA_INICIO { get { return _PD_FECHA_INICIO; } set { _PD_FECHA_INICIO = value; } }
        public DateTime PD_FECHA_FIN  { get { return _PD_FECHA_FIN ; } set { _PD_FECHA_FIN  = value; } }
        public string PV_CON_TITULO { get { return _PV_CON_TITULO; } set { _PV_CON_TITULO = value; } }
    
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion
                       
        #region Constructores
        //public Experiencias_postulacion(Int64 pB_ID_EXPERIENCIA)
        //{
        //    _PB_ID_EXPERIENCIA = pB_ID_EXPERIENCIA;
        //    RecuperarDatos();
        //}
        public Experiencias_postulacion(string pV_TIPO_OPERACION,string PV_CNV_CONVOCATORIA, Int64 pB_ID_EXPERIENCIA, Int64 pB_PER_ID_PERSONAL, string pV_PEX_EMPRESA, string pV_CNF_CARGO, 
            Int64 pB_CNF_TOTAL_EXPERIENCIAS,DateTime PD_FECHA_INICIO, DateTime PD_FECHA_FIN , string pV_CNF_DEPARTAMENTO_CARGO,
            string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_CNF_CARGO = pV_CNF_CARGO;
            _PV_CNV_CONVOCATORIA = PV_CNV_CONVOCATORIA;
            _PB_ID_EXPERIENCIA = pB_ID_EXPERIENCIA;
            _PB_PER_ID_PERSONAL = pB_PER_ID_PERSONAL;
            _PV_PEX_EMPRESA = pV_PEX_EMPRESA;
            _PV_CNF_DEPARTAMENTO_CARGO = pV_CNF_DEPARTAMENTO_CARGO;
            _PB_CNF_TOTAL_EXPERIENCIAS = pB_CNF_TOTAL_EXPERIENCIAS;
            _PD_FECHA_INICIO = PD_FECHA_INICIO;
            _PD_FECHA_FIN  = PD_FECHA_FIN ;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        public static DataTable PR_VCO_GET_EXPERIENCIA(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_EXPERIENCIA");
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
        public static DataTable PR_VCO_GET_EXPERIENCIA_GENERAL(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_EXPERIENCIA_GENERAL");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
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
        public static DataTable PR_VCO_GET_EXPERIENCIA_REQUERIDA(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_EXPERIENCIA_REQUERIDA");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "@PV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
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
        public static DataTable PR_VCO_GET_EXPERIENCIA_GENERAL2(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_EXPERIENCIA_GENERAL2");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
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
        public static DataTable PR_VCO_GET_EXPERIENCIA_REQUERIDA2(string PB_ID_PERSONAL, string PV_CNV_CONVOCATORIA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_EXPERIENCIA_REQUERIDA2");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "@PV_CONVOCATORIA", DbType.String, PV_CNV_CONVOCATORIA);
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_EXPERIENCIAS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, _PV_CNV_CONVOCATORIA);
                db1.AddInParameter(cmd, "PB_PEX_ID_EXPERIENCIA", DbType.Int64, _PB_ID_EXPERIENCIA);
                db1.AddInParameter(cmd, "PB_PER_ID_PERSONAL", DbType.Int64, _PB_PER_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_PEX_EMPRESA", DbType.String, _PV_PEX_EMPRESA);
                db1.AddInParameter(cmd, "PV_CNF_CARGO", DbType.String, _PV_CNF_CARGO);
                db1.AddInParameter(cmd, "PV_CNF_DEPARTAMENTO_CARGO", DbType.String, _PV_CNF_DEPARTAMENTO_CARGO);
                db1.AddInParameter(cmd, "PB_CNF_TOTAL_EXPERIENCIAS", DbType.Int64, _PB_CNF_TOTAL_EXPERIENCIAS);
                if (_PD_FECHA_INICIO == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_CNF_FECHA_INICIO_CARGO", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_CNF_FECHA_INICIO_CARGO", DbType.DateTime, _PD_FECHA_INICIO); }
                if (_PD_FECHA_FIN == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_CNF_FECHA_FIN_CARGO", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_CNF_FECHA_FIN_CARGO", DbType.DateTime, _PD_FECHA_FIN); }

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
                resultado = "||"+"Se produjo un error al registrar: " + ex.ToString();
                return resultado;
            }
        }
    }
}