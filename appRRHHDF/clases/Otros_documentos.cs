using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class Otros_documentos
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_OTRO_DOCUMENTO = 0;
        private Int64 _PB_ID_PERSONAL = 0;
        private string _PV_TIPO_OTRO_DOCUMENTO = "";
        private string _PV_DESCRIPCIONO = "";
        private string _PV_URL = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_OTRO_DOCUMENTO { get { return _PB_ID_OTRO_DOCUMENTO; } set { _PB_ID_OTRO_DOCUMENTO = value; } }
        public Int64 PB_ID_PERSONAL { get { return _PB_ID_PERSONAL; } set { _PB_ID_PERSONAL = value; } }
        public string PV_TIPO_OTRO_DOCUMENTO { get { return _PV_TIPO_OTRO_DOCUMENTO; } set { _PV_TIPO_OTRO_DOCUMENTO = value; } }
        public string PV_DESCRIPCIONO { get { return _PV_DESCRIPCIONO; } set { _PV_DESCRIPCIONO = value; } }
        public string PV_URL { get { return _PV_URL; } set { _PV_URL = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Otros_documentos(Int64 pB_ID_OTRO_DOCUMENTO)
        {
            _PB_ID_OTRO_DOCUMENTO = pB_ID_OTRO_DOCUMENTO;
            RecuperarDatos();
        }
        public Otros_documentos(string pV_TIPO_OPERACION, Int64 pB_ID_OTRO_DOCUMENTO,
         Int64 pB_ID_PERSONAL, string pV_TIPO_OTRO_DOCUMENTO, 
         string pV_DESCRIPCIONO,string pV_URL, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_OTRO_DOCUMENTO = pB_ID_OTRO_DOCUMENTO;
            _PB_ID_PERSONAL = pB_ID_PERSONAL;
            _PV_TIPO_OTRO_DOCUMENTO = pV_TIPO_OTRO_DOCUMENTO;
            _PV_DESCRIPCIONO = pV_DESCRIPCIONO;
            _PV_URL = pV_URL;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PB_ID_PERSONAL)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_OTROS_DOCUMENTOS");
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_OTROS_DOCUMENTOS_IND");
                db1.AddInParameter(cmd, "PB_ID_OTRO_DOCUMENTO", DbType.Int32, _PB_ID_OTRO_DOCUMENTO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    _PB_ID_OTRO_DOCUMENTO = int.Parse( dr["PRE_ID_OTRO_DOCUMENTO"].ToString());
                    _PB_ID_PERSONAL = int.Parse(dr["PER_ID_PERSONAL"].ToString());
                    _PV_TIPO_OTRO_DOCUMENTO = dr["PTR_TIPO_OTRO_DOCUMENTO"].ToString();
                    _PV_DESCRIPCIONO = dr["PTR_DESCRIPCION"].ToString();
                    _PV_URL = dr["PTR_URL"].ToString();
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_ABM_OTROS_DOCUMENTOS");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_OTRO_DOCUMENTO", DbType.Int64, _PB_ID_OTRO_DOCUMENTO);
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, _PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_TIPO_OTRO_DOCUMENTO", DbType.String, _PV_TIPO_OTRO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_DESCRIPCIONO", DbType.String, _PV_DESCRIPCIONO);
                db1.AddInParameter(cmd, "PV_URL", DbType.String, _PV_URL);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);

                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_USER").ToString()))
                //    PV_USUARIO = "";
                //else
                //    PV_USUARIO = (string)db1.GetParameterValue(cmd, "PV_USER");
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
                resultado = "Se produjo un error al registrar";
                return resultado;
            }
        }

        #endregion
    }
}