using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appRRHHDF.clases
{
    public class Personal
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_PERSONAL = 0;
        private string _PV_NOMBRE ="";
        private string _PV_APELLIDO_PATERNO ="";
        private string _PV_APELLIDO_MATERNO ="";
        private string _PV_APELLIDO_MARITAL ="";
        private string _PV_TIPO_DOCUMENTO = "";
        private string _PV_NUMERO_DOCUMENTO = "";
        private string _PV_COMPLEMENTO = "";
        private string _PV_EXPEDIDO = "";
        private string _PV_GENERO = "";
        private string _PV_ESTADO_CIVIL = "";
        private DateTime _PD_FECHA_NACIMIENTO = DateTime.Parse("01/01/3000");
        private Int64 _PB_PAI_ID_PAIS = 0;
        private Int64 _PB_CIU_ID_CIUDAD = 0;
        private string _PV_CIUDAD_RESIDENCIA = "";
        private string _PV_DIRECCION = "";
        private string _PV_CORREO_ELECTRONICO = "";
        private string _PV_TELEFONO_FIJO = "";
        private string _PV_TELEFONO_CELULAR = "";
        private string _PV_USUARIO = "";
        private string _PV_CARGO = "";
        private byte[] _PV_FOTO;
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_PERSONAL { get { return _PB_ID_PERSONAL; } set { _PB_ID_PERSONAL = value; } }
        public Int64 PB_PAI_ID_PAIS { get { return _PB_PAI_ID_PAIS; } set { _PB_PAI_ID_PAIS = value; } }
        public Int64 PB_CIU_ID_CIUDAD { get { return _PB_CIU_ID_CIUDAD; } set { _PB_CIU_ID_CIUDAD = value; } }
        public string PV_NOMBRE { get { return _PV_NOMBRE; } set { _PV_NOMBRE = value; } }
        public string PV_APELLIDO_PATERNO { get { return _PV_APELLIDO_PATERNO; } set { _PV_APELLIDO_PATERNO = value; } }
        public string PV_APELLIDO_MATERNO { get { return _PV_APELLIDO_MATERNO; } set { _PV_APELLIDO_MATERNO = value; } }
        public string PV_APELLIDO_MARITAL { get { return _PV_APELLIDO_MARITAL; } set { _PV_APELLIDO_MARITAL = value; } }
        public string PV_TIPO_DOCUMENTO { get { return _PV_TIPO_DOCUMENTO; } set { _PV_TIPO_DOCUMENTO = value; } }
        public string PV_NUMERO_DOCUMENTO { get { return _PV_NUMERO_DOCUMENTO; } set { _PV_NUMERO_DOCUMENTO = value; } }
        public string PV_COMPLEMENTO { get { return _PV_COMPLEMENTO; } set { _PV_COMPLEMENTO = value; } }
        public string PV_EXPEDIDO { get { return _PV_EXPEDIDO; } set { _PV_EXPEDIDO = value; } }
        public string PV_GENERO { get { return _PV_GENERO; } set { _PV_GENERO = value; } }
        public string PV_ESTADO_CIVIL { get { return _PV_ESTADO_CIVIL; } set { _PV_ESTADO_CIVIL = value; } }
        public string PV_CIUDAD_RESIDENCIA { get { return _PV_CIUDAD_RESIDENCIA; } set { _PV_CIUDAD_RESIDENCIA = value; } }
        public string PV_DIRECCION { get { return _PV_DIRECCION; } set { _PV_DIRECCION = value; } }
        public string PV_CORREO_ELECTRONICO { get { return _PV_CORREO_ELECTRONICO; } set { _PV_CORREO_ELECTRONICO = value; } }
        public string PV_TELEFONO_FIJO { get { return _PV_TELEFONO_FIJO; } set { _PV_TELEFONO_FIJO = value; } }
        public string PV_TELEFONO_CELULAR { get { return _PV_TELEFONO_CELULAR; } set { _PV_TELEFONO_CELULAR = value; } }
        public DateTime PD_FECHA_NACIMIENTO { get { return _PD_FECHA_NACIMIENTO; } set { _PD_FECHA_NACIMIENTO = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_CARGO { get { return _PV_CARGO; } set { _PV_CARGO = value; } }
        public byte[] PV_FOTO { get { return _PV_FOTO; } set { _PV_FOTO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        //public Simulador(string Cod_sumulador)
        //{

        //    RecuperarDatos();
        //}
        public Personal(string pV_TIPO_OPERACION,Int64 pB_ID_PERSONAL, string pV_NOMBRE,
					string pV_APELLIDO_PATERNO,
					string pV_APELLIDO_MATERNO ,
				string pV_APELLIDO_MARITAL,
				string pV_TIPO_DOCUMENTO ,
				string pV_NUMERO_DOCUMENTO,
				string pV_COMPLEMENTO,
				string pV_EXPEDIDO ,
				string pV_GENERO ,
				string pV_ESTADO_CIVIL ,
				DateTime		pD_FECHA_NACIMIENTO ,
                Int64 pB_PAI_ID_PAIS ,
				Int64 pB_CIU_ID_CIUDAD ,
                    string pV_CIUDAD_RESIDENCIA ,
				string pV_DIRECCION, string pV_CORREO_ELECTRONICO,

                    string pV_TELEFONO_FIJO,
					string pV_TELEFONO_CELULAR, string pV_USUARIO, byte[] pV_FOTO,string pV_CARGO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_PERSONAL = pB_ID_PERSONAL;
            _PV_NOMBRE = pV_NOMBRE;
            _PV_APELLIDO_PATERNO = pV_APELLIDO_PATERNO;
            _PV_APELLIDO_MATERNO = pV_APELLIDO_MATERNO;
            _PV_APELLIDO_MARITAL = pV_APELLIDO_MARITAL;
            _PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
            _PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            _PV_COMPLEMENTO = pV_COMPLEMENTO;
            _PV_EXPEDIDO = pV_EXPEDIDO;
            _PV_GENERO = pV_GENERO;
            _PV_ESTADO_CIVIL = pV_ESTADO_CIVIL;
            _PD_FECHA_NACIMIENTO = pD_FECHA_NACIMIENTO;
            _PB_PAI_ID_PAIS = pB_PAI_ID_PAIS;
            _PB_CIU_ID_CIUDAD = pB_CIU_ID_CIUDAD;
            _PV_CIUDAD_RESIDENCIA = pV_CIUDAD_RESIDENCIA;
            _PV_DIRECCION = pV_DIRECCION;
            _PV_CORREO_ELECTRONICO = pV_CORREO_ELECTRONICO;
            _PV_TELEFONO_FIJO = pV_TELEFONO_FIJO;
            _PV_TELEFONO_CELULAR = pV_TELEFONO_CELULAR;
            _PV_USUARIO = pV_USUARIO;
            _PV_FOTO = pV_FOTO;
            _PV_CARGO = pV_CARGO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PV_USUARIO)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_PERSONAL");
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
        public static DataTable PR_SEG_GET_PERSONAL_ID(Int64 PB_ID_CLIENTE)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_PERSONAL_ID");
                db1.AddInParameter(cmd, "PB_ID_CLIENTE", DbType.Int64, PB_ID_CLIENTE);
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
        public static DataTable PR_SEG_GET_PERSONAL_ALL()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_PERSONAL_ALL");
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_PERSONAL");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, _PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PB_PAI_ID_PAIS", DbType.Int64, _PB_PAI_ID_PAIS);
                db1.AddInParameter(cmd, "PB_CIU_ID_CIUDAD", DbType.Int64, _PB_CIU_ID_CIUDAD);
                db1.AddInParameter(cmd, "PV_NOMBRE", DbType.String, _PV_NOMBRE);
                db1.AddInParameter(cmd, "PV_APELLIDO_PATERNO", DbType.String, _PV_APELLIDO_PATERNO);
                db1.AddInParameter(cmd, "PV_APELLIDO_MATERNO", DbType.String, _PV_APELLIDO_MATERNO);
                db1.AddInParameter(cmd, "PV_APELLIDO_MARITAL", DbType.String, _PV_APELLIDO_MARITAL);
                db1.AddInParameter(cmd, "PV_TIPO_DOCUMENTO", DbType.String, _PV_TIPO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_NUMERO_DOCUMENTO", DbType.String, _PV_NUMERO_DOCUMENTO);
                db1.AddInParameter(cmd, "PV_COMPLEMENTO", DbType.String, _PV_COMPLEMENTO);
                db1.AddInParameter(cmd, "PV_EXPEDIDO", DbType.String, _PV_EXPEDIDO);
                db1.AddInParameter(cmd, "PV_GENERO", DbType.String, _PV_GENERO);
                db1.AddInParameter(cmd, "PV_ESTADO_CIVIL", DbType.String, _PV_ESTADO_CIVIL);
                db1.AddInParameter(cmd, "PD_FECHA_NACIMIENTO", DbType.DateTime, _PD_FECHA_NACIMIENTO);
                db1.AddInParameter(cmd, "PV_CIUDAD_RESIDENCIA", DbType.String, _PV_CIUDAD_RESIDENCIA);
                db1.AddInParameter(cmd, "PV_DIRECCION", DbType.String, _PV_DIRECCION);
                db1.AddInParameter(cmd, "PV_CORREO_ELECTRONICO", DbType.String, _PV_CORREO_ELECTRONICO);
                db1.AddInParameter(cmd, "PV_TELEFONO_FIJO", DbType.String, _PV_TELEFONO_FIJO);
                db1.AddInParameter(cmd, "PV_TELEFONO_CELULAR", DbType.String, _PV_TELEFONO_CELULAR);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddInParameter(cmd, "PV_CARGO", DbType.String, _PV_CARGO);
                db1.AddInParameter(cmd, "PV_FOTO", DbType.Binary, _PV_FOTO);

                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PI_PER_ID_PERSONALOUT", DbType.Int64, 64);
                db1.ExecuteNonQuery(cmd);
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PI_PER_ID_PERSONALOUT").ToString()))
                    PB_ID_PERSONAL = 0;
                else
                    PB_ID_PERSONAL = Int64.Parse(db1.GetParameterValue(cmd, "PI_PER_ID_PERSONALOUT").ToString());
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
                resultado = "0|||Se produjo un error al registrar";
                return resultado;
            }
        }

        #endregion
    }
}