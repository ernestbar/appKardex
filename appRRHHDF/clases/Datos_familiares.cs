using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class Datos_familiares
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_DATO_FAMILIAR = 0;
        private Int64 _PB_ID_PERSONAL = 0;
        private string _PV_TIPO_PARENTESCO = "";
        private string _PV_NOMBRE ="";
        private string _PV_APELIIDO_PRIMERO ="";
        private string _PV_APELIIDO_SEGUNDO ="";
        private string _PV_TIPO_DOCUMENTO = "";
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_COMPLEMENTO = "";
        private string _PV_EXPEDIDO = "";
        
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_PERSONAL { get { return _PB_ID_PERSONAL; } set { _PB_ID_PERSONAL = value; } }
        public Int64 PB_ID_DATO_FAMILIAR { get { return _PB_ID_DATO_FAMILIAR; } set { _PB_ID_DATO_FAMILIAR = value; } }
        public string PV_TIPO_PARENTESCO { get { return _PV_TIPO_PARENTESCO; } set { _PV_TIPO_PARENTESCO = value; } }
        public string PV_NOMBRE { get { return _PV_NOMBRE; } set { _PV_NOMBRE = value; } }
        public string PV_APELIIDO_PRIMERO { get { return _PV_APELIIDO_PRIMERO; } set { _PV_APELIIDO_PRIMERO = value; } }
        public string PV_APELIIDO_SEGUNDO { get { return _PV_APELIIDO_SEGUNDO; } set { _PV_APELIIDO_SEGUNDO = value; } }
        public string PV_TIPO_DOCUMENTO { get { return _PV_TIPO_DOCUMENTO; } set { _PV_TIPO_DOCUMENTO = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }
        public string PV_COMPLEMENTO { get { return _PV_COMPLEMENTO; } set { _PV_COMPLEMENTO = value; } }
        public string PV_EXPEDIDO { get { return _PV_EXPEDIDO; } set { _PV_EXPEDIDO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Datos_familiares(Int64 pB_ID_DATO_FAMILIAR)
        {
            _PB_ID_DATO_FAMILIAR = pB_ID_DATO_FAMILIAR;
            RecuperarDatos();
        }
        public Datos_familiares(string pV_TIPO_OPERACION, Int64 pB_ID_DATO_FAMILIAR, Int64 pB_ID_PERSONAL,
            string pV_TIPO_PARENTESCO, string pV_NOMBRE,
					string pV_APELIIDO_PRIMERO,
					string pV_APELIIDO_SEGUNDO ,
				string pV_TIPO_DOCUMENTO ,
				string pV_NUMERO_DOCUMENTO,
				string pV_COMPLEMENTO,
				string pV_EXPEDIDO ,
				string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_PERSONAL = pB_ID_PERSONAL;
            _PV_NOMBRE = pV_NOMBRE;
            _PV_APELIIDO_PRIMERO = pV_APELIIDO_PRIMERO;
            _PV_APELIIDO_SEGUNDO = pV_APELIIDO_SEGUNDO;
            _PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
            _PV_TIPO_PARENTESCO = pV_TIPO_PARENTESCO;
            _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_COMPLEMENTO = pV_COMPLEMENTO;
            _PV_EXPEDIDO = pV_EXPEDIDO;
            _PB_ID_DATO_FAMILIAR = pB_ID_DATO_FAMILIAR;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PB_ID_PERSONAL)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_FAMILIAR");
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_FAMILIAR_IND");
                db1.AddInParameter(cmd, "PB_ID_DATO_FAMILIAR", DbType.Int32, _PB_ID_DATO_FAMILIAR);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    _PV_NOMBRE = dr["POF_NOMBRES"].ToString();
                    _PV_APELIIDO_PRIMERO = dr["POF_APELLIDO_PATERNO"].ToString();
                    _PV_APELIIDO_SEGUNDO = dr["POF_APELLIDO_MATERNO"].ToString();
                    _PV_TIPO_DOCUMENTO = dr["POF_TIPO_DOCUMENTO"].ToString();
                    _PV_TIPO_PARENTESCO = dr["POF_TIPO_PARENTESCO"].ToString();
                    _PV_NUMERO_DOCUMENTO = dr["POF_NUMERO_DOCUMENTO"].ToString();
                    _PV_COMPLEMENTO = dr["POF_COMPLEMENTO"].ToString();
                    _PV_EXPEDIDO = dr["POF_EXPEDIDO"].ToString();
                    _PB_ID_DATO_FAMILIAR = Int64.Parse( dr["POF_ID_DATO_FAMILIAR"].ToString());
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_ABM_FAMILIAR");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, _PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PB_ID_DATO_FAMILIAR", DbType.Int64, _PB_ID_DATO_FAMILIAR);
                db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, _PV_NOMBRE);
                db1.AddInParameter(cmd, "PV_APELLIDO_PRIMERO", DbType.String, _PV_APELIIDO_PRIMERO);
                db1.AddInParameter(cmd, "PV_APELLIDO_SEGUNDO", DbType.String, _PV_APELIIDO_SEGUNDO);
                db1.AddInParameter(cmd, "PV_TIPO_DOCUMENTO", DbType.String, _PV_TIPO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, _PV_NUMERO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_COMPLEMENTO", DbType.String, _PV_COMPLEMENTO);
                db1.AddInParameter(cmd, "PV_EXPEDIDO", DbType.String, _PV_EXPEDIDO);
                db1.AddInParameter(cmd, "PV_TIPO_PARENTESCO", DbType.String, _PV_TIPO_PARENTESCO);
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