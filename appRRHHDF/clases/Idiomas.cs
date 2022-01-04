using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class Idiomas
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_IDIOMA = 0;
        private Int64 _PB_ID_PERSONAL = 0;
        private string _PV_IDIOMA = "";
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
        public Int64 PB_ID_PERSONAL { get { return _PB_ID_PERSONAL; } set { _PB_ID_PERSONAL = value; } }
        public Int64 PB_ID_IDIOMA { get { return _PB_ID_IDIOMA; } set { _PB_ID_IDIOMA = value; } }
        public string PV_IDIOMA { get { return _PV_IDIOMA; } set { _PV_IDIOMA = value; } }
        public string PV_NIVEL_DOMINIO_LECTURA { get { return _PV_NIVEL_DOMINIO_LECTURA; } set { _PV_NIVEL_DOMINIO_LECTURA = value; } }
        public string PV_NIVEL_DOMINIO_ESCRITURA { get { return _PV_NIVEL_DOMINIO_ESCRITURA; } set { _PV_NIVEL_DOMINIO_ESCRITURA = value; } }
        public string PV_NIVEL_DOMINIO_CONVERSACION { get { return _PV_NIVEL_DOMINIO_CONVERSACION; } set { _PV_NIVEL_DOMINIO_CONVERSACION = value; } }
        public string PV_CON_TITULO { get { return _PV_CON_TITULO; } set { _PV_CON_TITULO = value; } }
        
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Idiomas(Int64 pB_ID_IDIOMA)
        {
            _PB_ID_IDIOMA = pB_ID_IDIOMA;
            RecuperarDatos();
        }
        public Idiomas(string pV_TIPO_OPERACION, Int64 pB_ID_IDIOMA, Int64 pB_ID_PERSONAL,
            string pV_IDIOMA, string pV_NIVEL_DOMINIO_LECTURA,
             string pV_NIVEL_DOMINIO_ESCRITURA, string pV_NIVEL_DOMINIO_CONVERSACION,
                string pV_CON_TITULO, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_PERSONAL = pB_ID_PERSONAL;
            _PV_NIVEL_DOMINIO_LECTURA = pV_NIVEL_DOMINIO_LECTURA;
            _PV_NIVEL_DOMINIO_ESCRITURA = pV_NIVEL_DOMINIO_ESCRITURA;
            _PV_IDIOMA = pV_IDIOMA;
            _PV_NIVEL_DOMINIO_CONVERSACION = pV_NIVEL_DOMINIO_CONVERSACION;
            _PB_ID_IDIOMA = pB_ID_IDIOMA;
            _PV_USUARIO = pV_USUARIO;
            _PV_CON_TITULO = pV_CON_TITULO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PB_ID_PERSONAL)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_IDIOMA");
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_IDIOMA_IND");
                db1.AddInParameter(cmd, "PB_ID_IDIOMA", DbType.Int32, _PB_ID_IDIOMA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    _PB_ID_IDIOMA = Int64.Parse(dr["PID_ID_IDIOMA"].ToString());
                    _PV_IDIOMA = dr["PID_IDIOMA"].ToString();
                    _PV_NIVEL_DOMINIO_LECTURA = dr["PID_NIVEL_DOMINIO_LECTURA"].ToString();
                    _PV_NIVEL_DOMINIO_ESCRITURA = dr["PID_NIVEL_DOMINIO_ESCRITURA"].ToString();
                    _PV_NIVEL_DOMINIO_CONVERSACION = dr["PID_NIVEL_DOMINIO_CONVERSACION"].ToString();
                    _PV_CON_TITULO = dr["PID_CON_TITULO"].ToString();

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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_ABM_IDIOMA");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, _PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PB_ID_IDIOMA", DbType.Int64, _PB_ID_IDIOMA);
                db1.AddInParameter(cmd, "PV_IDIOMA", DbType.String, _PV_IDIOMA);
                db1.AddInParameter(cmd, "PV_NIVEL_DOMINIO_LECTURA", DbType.String, _PV_NIVEL_DOMINIO_LECTURA);
                db1.AddInParameter(cmd, "PV_NIVEL_DOMINIO_ESCRITURA", DbType.String, _PV_NIVEL_DOMINIO_ESCRITURA);
                db1.AddInParameter(cmd, "PV_NIVEL_DOMINIO_CONVERSACION", DbType.String, _PV_NIVEL_DOMINIO_CONVERSACION);
                db1.AddInParameter(cmd, "PV_CON_TITULO", DbType.String, _PV_CON_TITULO);
                
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PI_PER_ID_PERSONALOUT").ToString()))
                //    PB_ID_PERSONAL = 0;
                //else
                //    PB_ID_PERSONAL = Int64.Parse(db1.GetParameterValue(cmd, "PI_PER_ID_PERSONALOUT").ToString());
                PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCION = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PB_ID_PERSONAL + "|" + PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCION;
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