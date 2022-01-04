using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class registro
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_NOMBRE = "";
        private string _PV_APELLIDO_PATERNO = "";
        private string _PV_APELLIDO_MATERNO = "";
        private string _PV_TIPO_DOCUMENTO = "";
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_COMPLEMENTO = "";
        private string _PV_CORREO_ELECTRONICO = "";
        private string _PV_USUARIO = "";
        private string _PV_PASSWORD = "";
        private string _PV_PASSWORD_NUEVO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";
        private string _PV_USER = "";
        private string _PV_PASSWDORD = "";
       
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_NOMBRE { get { return _PV_NOMBRE; } set { _PV_NOMBRE = value; } }
        public string PV_APELLIDO_PATERNO { get { return _PV_APELLIDO_PATERNO; } set { _PV_APELLIDO_PATERNO = value; } }
        public string PV_APELLIDO_MATERNO { get { return _PV_APELLIDO_MATERNO; } set { _PV_APELLIDO_MATERNO = value; } }
        public string PV_TIPO_DOCUMENTO { get { return _PV_TIPO_DOCUMENTO; } set { _PV_TIPO_DOCUMENTO = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }

        public string PV_COMPLEMENTO { get { return _PV_COMPLEMENTO; } set { _PV_COMPLEMENTO = value; } }
        public string PV_CORREO_ELECTRONICO { get { return _PV_CORREO_ELECTRONICO; } set { _PV_CORREO_ELECTRONICO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_PASSWORD { get { return _PV_PASSWORD; } set { _PV_PASSWORD = value; } }
        public string PV_PASSWORD_NUEVO { get { return _PV_PASSWORD_NUEVO; } set { _PV_PASSWORD_NUEVO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public string PV_USER { get { return _PV_USER; } set { _PV_USER = value; } }
        public string PV_PASSWDORD { get { return _PV_PASSWDORD; } set { _PV_PASSWDORD = value; } }
        #endregion

        #region Constructores
        //public Simulador(string Cod_sumulador)
        //{

        //    RecuperarDatos();
        //}
        public registro(string pV_TIPO_OPERACION, string pV_NOMBRE,
         string pV_APELLIDO_PATERNO, string pV_APELLIDO_MATERNO, string pV_TIPO_DOCUMENTO,
         string pV_NUMERO_DOCUMENTO, string pV_COMPLEMENTO,
         string pV_CORREO_ELECTRONICO, string pV_USUARIO, string pV_PASSWORD,
         string pV_PASSWORD_NUEVO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_NOMBRE = pV_NOMBRE;
            _PV_APELLIDO_PATERNO = pV_APELLIDO_PATERNO;
            _PV_APELLIDO_MATERNO = pV_APELLIDO_MATERNO;
            _PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
            _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_COMPLEMENTO = pV_COMPLEMENTO;
            _PV_CORREO_ELECTRONICO = pV_CORREO_ELECTRONICO;
            _PV_USUARIO = pV_USUARIO;
            _PV_PASSWORD = pV_PASSWORD;
            _PV_PASSWORD_NUEVO = pV_PASSWORD_NUEVO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        //public static DataTable Lista_clientes_sim()
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_CLIENTESSIMULADOR");

        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static DataTable Lista_clientes_detalle(string PV_COD_CLIENTE)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_SIMULADORDETALLE");
        //    db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, PV_COD_CLIENTE);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static DataTable Lista_plan_pago(string PV_COD_SIMULADOR)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_PLANPAGO");
        //    db1.AddInParameter(cmd, "PV_COD_SIMULADOR", DbType.String, PV_COD_SIMULADOR);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}
        //public static DataTable Datos_cliente_simuldor(string PV_COD_CLIENTE)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_SIMULADOR");
        //    db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, PV_COD_CLIENTE);
        //    db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, null);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static DataTable Datos_cliente_simuldor_x_DOC(string pV_NUMERO_DOCUMENTO)
        //{
        //    DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DATOS_SIMULADOR");
        //    db1.AddInParameter(cmd, "pv_cod_cliente", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, null);
        //    db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, pV_NUMERO_DOCUMENTO);
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}

        //public static List<Cliente> ListaTodos(int Id_usuario)
        //{
        //    List<Cliente> listaObj = new List<Cliente>();
        //    DataTable dtDatos = Lista(Id_usuario);
        //    foreach (DataRow dr in dtDatos.Rows)
        //    {
        //        Cliente obj = new Cliente();
        //        obj.id_cliente = (int)dr["id_cliente"];
        //        obj.razon_social = (string)dr["razon_social"];
        //        obj.nit = (string)dr["nit"];
        //        obj.paterno = (string)dr["paterno"];
        //        obj.materno = (string)dr["materno"];
        //        obj.nombre = (string)dr["nombre"];
        //        obj.activo = (Boolean)dr["activo"];
        //        obj.id_tipocliente = (int)dr["id_tipocliente"];
        //        obj.id_tiponegocio = (int)dr["id_tiponegocio"];
        //        obj.fecha_ini = (DateTime)dr["fecha_ini"];
        //        obj.abierto = (Boolean)dr["abierto"];
        //        obj.agenda = (Boolean)dr["agenda"];
        //        listaObj.Add(obj);
        //    }
        //    return listaObj;
        //}


        #endregion

        #region Métodos que requieren constructor
        //private void RecuperarDatos()
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_REGISTRO");
        //        db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.Int32, _id_cliente);
        //        db1.AddOutParameter(cmd, "PV_NOMBRE", DbType.String, 500);
        //        db1.AddOutParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, 100);
        //        db1.AddOutParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, 200);
        //        db1.AddOutParameter(cmd, "PV_TIPO_DOCUMENTO", DbType.String, 200);
        //        db1.AddOutParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, 200);
        //        db1.AddOutParameter(cmd, "PV_COMPLEMENTO", DbType.Boolean, 1);
        //        db1.AddOutParameter(cmd, "id_tipocliente", DbType.Int32, 32);
        //        db1.AddOutParameter(cmd, "id_tiponegocio", DbType.Int32, 32);
        //        db1.AddOutParameter(cmd, "fecha_ini", DbType.DateTime, 30);
        //        db1.AddOutParameter(cmd, "abierto", DbType.Boolean, 1);
        //        db1.AddOutParameter(cmd, "agenda", DbType.Boolean, 1);
        //        db1.AddOutParameter(cmd, "ruta_imagen", DbType.String, 500);
        //        db1.ExecuteNonQuery(cmd);

        //        _razon_social = (string)db1.GetParameterValue(cmd, "razon_social");
        //        _nit = (string)db1.GetParameterValue(cmd, "nit");
        //        _paterno = (string)db1.GetParameterValue(cmd, "paterno");
        //        _materno = (string)db1.GetParameterValue(cmd, "materno");
        //        _nombre = (string)db1.GetParameterValue(cmd, "nombre");
        //        _activo = (Boolean)db1.GetParameterValue(cmd, "activo");
        //        _id_tipocliente = (int)db1.GetParameterValue(cmd, "id_tipocliente");
        //        _id_tiponegocio = (int)db1.GetParameterValue(cmd, "id_tiponegocio");
        //        _fecha_ini = (DateTime)db1.GetParameterValue(cmd, "fecha_ini");
        //        _abierto = (Boolean)db1.GetParameterValue(cmd, "abierto");
        //        _agenda = (Boolean)db1.GetParameterValue(cmd, "agenda");
        //        _ruta_imagen = (string)db1.GetParameterValue(cmd, "ruta_imagen");
        //    }
        //    catch { }
        //}
       


        public string ABM()
        {
            string resultado = "";
            try
            {
               // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_REGISTRO");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, _PV_NOMBRE);
                db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, _PV_APELLIDO_PATERNO);
                db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, _PV_APELLIDO_MATERNO);
                db1.AddInParameter(cmd, "PV_TIPO_DOCUMENTO", DbType.String, _PV_TIPO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, _PV_NUMERO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_COMPLEMENTO", DbType.String, _PV_COMPLEMENTO);
                db1.AddInParameter(cmd, "PV_CORREO_ELECTRONICO", DbType.String, _PV_CORREO_ELECTRONICO);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddInParameter(cmd, "PV_PASSWORD", DbType.String, _PV_PASSWORD);
                db1.AddInParameter(cmd, "PV_PASSWORD_NUEVO", DbType.String, _PV_PASSWORD_NUEVO);


                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_USER", DbType.String, 45);
                db1.AddOutParameter(cmd, "PV_PASSWDORD", DbType.String, 45);
                db1.ExecuteNonQuery(cmd);
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_USER").ToString()))
                    PV_USUARIO = "";
                else
                    PV_USUARIO = (string)db1.GetParameterValue(cmd, "PV_USER");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_PASSWDORD").ToString()))
                    PV_PASSWDORD = "";
                else
                    PV_PASSWDORD = (string)db1.GetParameterValue(cmd, "PV_PASSWDORD");
                PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                PV_DESCRIPCION = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                resultado = PV_USUARIO + "|" + PV_PASSWDORD + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCION;
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