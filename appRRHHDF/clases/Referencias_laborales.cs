using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class Referencias_laborales
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_PERSONAL = 0;
        private Int64 _PB_ID_REFERENCIA = 0;
        private string _PV_EMPRESA = "";
        private string _PV_CARGO = "";
        private string _PV_RELACION_LABORAL = "";
        private string _PV_TELEFONO = "";
        private string _PV_CELULAR = "";
        private string _PV_EMAIL = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_REFERENCIA { get { return _PB_ID_REFERENCIA; } set { _PB_ID_REFERENCIA = value; } }
        public Int64 PB_ID_PERSONAL { get { return _PB_ID_PERSONAL; } set { _PB_ID_PERSONAL = value; } }
        public string PV_EMPRESA { get { return _PV_EMPRESA; } set { _PV_EMPRESA = value; } }
        public string PV_CARGO { get { return _PV_CARGO; } set { _PV_CARGO = value; } }
        public string PV_RELACION_LABORAL { get { return _PV_RELACION_LABORAL; } set { _PV_RELACION_LABORAL = value; } }
        public string PV_TELEFONO { get { return _PV_TELEFONO; } set { _PV_TELEFONO = value; } }
        public string PV_CELULAR { get { return _PV_CELULAR; } set { _PV_CELULAR = value; } }
        public string PV_EMAIL { get { return _PV_EMAIL; } set { _PV_EMAIL = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Referencias_laborales(Int64 pB_ID_REFERENCIA)
        {
            _PB_ID_REFERENCIA = pB_ID_REFERENCIA;
            RecuperarDatos();
        }
        public Referencias_laborales(string pV_TIPO_OPERACION,  Int64 pB_ID_REFERENCIA, Int64 pB_ID_PERSONAL,
            string pV_EMPRESA, string pV_RELACION_LABORAL,
                   string pV_CARGO, string pV_TELEFONO,
                    string pV_CELULAR,
                string pV_EMAIL,
                string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_PERSONAL = pB_ID_PERSONAL;
            _PB_ID_REFERENCIA = pB_ID_REFERENCIA;
            _PV_RELACION_LABORAL = pV_RELACION_LABORAL;
            _PV_TELEFONO = pV_TELEFONO;
            _PV_CELULAR = pV_CELULAR;
            _PV_EMAIL = pV_EMAIL;
            _PV_EMPRESA = pV_EMPRESA;
            _PV_CARGO = pV_CARGO;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PB_ID_PERSONAL)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_REFERENCIA");
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.String, PB_ID_PERSONAL);
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




        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_REFERENCIA_IND");
                db1.AddInParameter(cmd, "PB_ID_REFERENCIA", DbType.Int32, _PB_ID_REFERENCIA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    _PV_EMPRESA = dr["PRE_EMPRESA"].ToString();
                    _PV_CARGO = dr["PRE_CARGO"].ToString();
                    _PV_RELACION_LABORAL = dr["PRE_RELACION_LABORAL"].ToString();
                    _PV_TELEFONO = dr["PRE_TELEFONO"].ToString();
                    _PV_CELULAR = dr["PRE_CELULAR"].ToString();
                    _PV_EMAIL = dr["PRE_EMAIL"].ToString();
                    _PB_ID_REFERENCIA = Int64.Parse(dr["PRE_ID_REFRENCIA"].ToString());
                    _PB_ID_PERSONAL = Int64.Parse(dr["PER_ID_PERSONAL"].ToString());
                }
            }
            catch { }
        }




        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_ABM_REFERENCIA");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_REFERENCIA", DbType.Int64, _PB_ID_REFERENCIA);
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, _PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_RELACION_LABORAL", DbType.String, _PV_RELACION_LABORAL);
                db1.AddInParameter(cmd, "PV_TELEFONO", DbType.String, _PV_TELEFONO);
                db1.AddInParameter(cmd, "PV_CELULAR", DbType.String, _PV_CELULAR);
                db1.AddInParameter(cmd, "PV_EMAIL", DbType.String, _PV_EMAIL);
                db1.AddInParameter(cmd, "PV_EMPRESA", DbType.String, _PV_EMPRESA);
                db1.AddInParameter(cmd, "PV_CARGO", DbType.String, _PV_CARGO);
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
                resultado = PB_ID_REFERENCIA + "|" + PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCION;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar";
                return resultado;
            }
        }

        #endregion
    }
}