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
    public class Experiencia_Laboral
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private Int64 _PB_ID_EXPERIENCIA = 0;
        private Int64 _PB_ID_PERSONAL = 0;
        private string _PV_EMPRESA = "";
        private string _PV_CARGO = "";
        private Int64 _PI_NRO_DEPENDIENTES = 0;
        private string _PV_FUNCIONES = "";
        private DateTime _PD_FECHA_INICIO = DateTime.Parse("01/01/3000");
        private DateTime _PD_FECHA_FIN = DateTime.Parse("01/01/3000");
        private string _PV_DEPARTAMENTO = "";
        //--cargo 1
        private string _PV_OTRO_CARGO1 = "";
        private Int64 _PI_NRO_DEPENDIENTES_OTRO1 = 0;
        private string _PV_FUNCIONES_OTRO1 = "";
        private DateTime _PD_FECHA_INICIO_OTRO1 = DateTime.Parse("01/01/3000");
        private DateTime _PD_FECHA_FIN_OTRO1 = DateTime.Parse("01/01/3000");
        private string _PV_DEPARTAMENTO_OTRO1= "";
        //--cargo 2
        private string _PV_OTRO_CARGO2 = "";
        private Int64 _PI_NRO_DEPENDIENTES_OTRO2 = 0;
        private string _PV_FUNCIONES_OTRO2 = "";
        private DateTime _PD_FECHA_INICIO_OTRO2 = DateTime.Parse("01/01/3000");
        private DateTime _PD_FECHA_FIN_OTRO2 = DateTime.Parse("01/01/3000");
        private string _PV_DEPARTAMENTO_OTRO2= "";
        //--cargo 3
        private string _PV_OTRO_CARGO3 = "";
        private Int64 _PI_NRO_DEPENDIENTES_OTRO3 = 0;
        private string _PV_FUNCIONES_OTRO3 = "";
        private DateTime _PD_FECHA_INICIO_OTRO3 = DateTime.Parse("01/01/3000");
        private DateTime _PD_FECHA_FIN_OTRO3 = DateTime.Parse("01/01/3000");
        private string _PV_DEPARTAMENTO_OTRO3 = "";
        // OTRO
        private string _PV_DESVINCULACION_OTRO = "";
        // LO DEMÀS
        private string _PV_ACTUAL_CARGO = "";
        private string _PV_MOTIVO_DESVINCULACION = "";
        private Int64 _PI_TOTAL_EXPERIENCIA = 0;
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCION = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public Int64 PB_ID_EXPERIENCIA { get { return _PB_ID_EXPERIENCIA; } set { _PB_ID_EXPERIENCIA = value; } }
        public Int64 PB_ID_PERSONAL { get { return _PB_ID_PERSONAL; } set { _PB_ID_PERSONAL = value; } }
        public string PV_EMPRESA { get { return _PV_EMPRESA; } set { _PV_EMPRESA = value; } }
        public string PV_CARGO { get { return _PV_CARGO; } set { _PV_CARGO = value; } }
        public Int64 PI_NRO_DEPENDIENTES { get { return _PI_NRO_DEPENDIENTES; } set { _PI_NRO_DEPENDIENTES = value; } }
        public string PV_FUNCIONES { get { return _PV_FUNCIONES; } set { _PV_FUNCIONES = value; } }
        public DateTime PD_FECHA_INICIO { get { return _PD_FECHA_INICIO; } set { _PD_FECHA_INICIO = value; } }
        public DateTime PD_FECHA_FIN { get { return _PD_FECHA_FIN; } set { _PD_FECHA_FIN = value; } }
        public string PV_DEPARTAMENTO { get { return _PV_DEPARTAMENTO; } set { _PV_DEPARTAMENTO = value; } }
        public string PV_OTRO_CARGO1 { get { return _PV_OTRO_CARGO1; } set { _PV_OTRO_CARGO1 = value; } }
        public Int64 PI_NRO_DEPENDIENTES_OTRO1 { get { return _PI_NRO_DEPENDIENTES_OTRO1; } set { _PI_NRO_DEPENDIENTES_OTRO1 = value; } }
        public string PV_FUNCIONES_OTRO1 { get { return _PV_FUNCIONES_OTRO1; } set { _PV_FUNCIONES_OTRO1 = value; } }
        public DateTime PD_FECHA_INICIO_OTRO1 { get { return _PD_FECHA_INICIO_OTRO1; } set { _PD_FECHA_INICIO_OTRO1 = value; } }
        public DateTime PD_FECHA_FIN_OTRO1 { get { return _PD_FECHA_FIN_OTRO1; } set { _PD_FECHA_FIN_OTRO1 = value; } }
        public string PV_DEPARTAMENTO_OTRO1 { get { return _PV_DEPARTAMENTO_OTRO1; } set { _PV_DEPARTAMENTO_OTRO1 = value; } }
        public string PV_OTRO_CARGO2 { get { return _PV_OTRO_CARGO2; } set { _PV_OTRO_CARGO2 = value; } }
        public string PV_OTRO_CARGO12 { get { return _PV_OTRO_CARGO2; } set { _PV_OTRO_CARGO2 = value; } }
        public Int64 PI_NRO_DEPENDIENTES_OTRO2 { get { return _PI_NRO_DEPENDIENTES_OTRO2; } set { _PI_NRO_DEPENDIENTES_OTRO2= value; } }
        public string PV_FUNCIONES_OTRO2 { get { return _PV_FUNCIONES_OTRO2; } set { _PV_FUNCIONES_OTRO2 = value; } }
        public DateTime PD_FECHA_INICIO_OTRO2 { get { return _PD_FECHA_INICIO_OTRO2; } set { _PD_FECHA_INICIO_OTRO2 = value; } }
        public DateTime PD_FECHA_FIN_OTRO2 { get { return _PD_FECHA_FIN_OTRO2; } set { _PD_FECHA_FIN_OTRO2 = value; } }
        public string PV_DEPARTAMENTO_OTRO2 { get { return _PV_DEPARTAMENTO_OTRO2; } set { _PV_DEPARTAMENTO_OTRO2 = value; } }
        public string PV_OTRO_CARGO3 { get { return _PV_OTRO_CARGO3; } set { _PV_OTRO_CARGO3 = value; } }
        public Int64 PI_NRO_DEPENDIENTES_OTRO3 { get { return _PI_NRO_DEPENDIENTES_OTRO3; } set { _PI_NRO_DEPENDIENTES_OTRO3 = value; } }
        public string PV_FUNCIONES_OTRO3 { get { return _PV_FUNCIONES_OTRO3; } set { _PV_FUNCIONES_OTRO3 = value; } }
        public DateTime PD_FECHA_INICIO_OTRO3 { get { return _PD_FECHA_INICIO_OTRO3; } set { _PD_FECHA_INICIO_OTRO3 = value; } }
        public DateTime PD_FECHA_FIN_OTRO3 { get { return _PD_FECHA_FIN_OTRO3; } set { _PD_FECHA_FIN_OTRO3 = value; } }
        public string PV_DEPARTAMENTO_OTRO3 { get { return _PV_DEPARTAMENTO_OTRO3; } set { _PV_DEPARTAMENTO_OTRO3 = value; } }
        public string PV_DESVINCULACION_OTRO { get { return _PV_DESVINCULACION_OTRO; } set { _PV_DESVINCULACION_OTRO = value; } }
        public string PV_ACTUAL_CARGO { get { return _PV_ACTUAL_CARGO; } set { _PV_ACTUAL_CARGO = value; } }
        public string PV_MOTIVO_DEVINCULACION { get { return _PV_MOTIVO_DESVINCULACION; } set { _PV_MOTIVO_DESVINCULACION = value; } }
        public Int64 PI_TOTAL_EXPERIENCIA { get { return _PI_TOTAL_EXPERIENCIA; } set { _PI_TOTAL_EXPERIENCIA = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion
                       
        #region Constructores
        public Experiencia_Laboral(Int64 pB_ID_EXPERIENCIA)
        {
            _PB_ID_EXPERIENCIA = pB_ID_EXPERIENCIA;
            RecuperarDatos();
        }
        public Experiencia_Laboral(string pV_TIPO_OPERACION, Int64 pB_ID_EXPERIENCIA, Int64 pB_ID_PERSONAL, string pV_EMPRESA, string pV_CARGO, 
            Int64 pI_NRO_DEPENDIENTES, string pV_FUNCIONES,DateTime pD_FECHA_INICIO, DateTime pD_FECHA_FIN, string pV_DEPARTAMENTO,
            string pV_OTRO_CARGO1, Int64 pI_NRO_DEPENDIENTES_OTRO1, string pV_FUNCIONES_OTRO1, DateTime pD_FECHA_INICIO_OTRO1, DateTime pD_FECHA_FIN_OTRO1, 
            string pV_DEPARTAMENTO_OTRO1, string pV_OTRO_CARGO2, Int64 pI_NRO_DEPENDIENTES_OTRO2, string pV_FUNCIONES_OTRO2, DateTime pD_FECHA_INICIO_OTRO2, 
            DateTime pD_FECHA_FIN_OTRO2, string pV_DEPARTAMENTO_OTRO2, string pV_OTRO_CARGO3, Int64 pI_NRO_DEPENDIENTES_OTRO3, string pV_FUNCIONES_OTRO3, 
            DateTime pD_FECHA_INICIO_OTRO3, DateTime pD_FECHA_FIN_OTRO3, string pV_DEPARTAMENTO_OTRO3, string pV_DESVINCULACION_OTRO,
            string pV_ACTUAL_CARGO, string pV_MOTIVO_DESVINCULACION, Int64 pI_TOTAL_EXPERIENCIA, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PB_ID_EXPERIENCIA = pB_ID_EXPERIENCIA;
            _PB_ID_PERSONAL = pB_ID_PERSONAL;
            _PV_EMPRESA = pV_EMPRESA;
            _PV_CARGO = pV_CARGO;
            _PI_NRO_DEPENDIENTES = pI_NRO_DEPENDIENTES;
            _PV_FUNCIONES = pV_FUNCIONES;
            _PD_FECHA_INICIO = pD_FECHA_INICIO;
            _PD_FECHA_FIN = pD_FECHA_FIN;
            _PV_DEPARTAMENTO = pV_DEPARTAMENTO;
            _PV_OTRO_CARGO1 = pV_OTRO_CARGO1;
            _PI_NRO_DEPENDIENTES_OTRO1 = pI_NRO_DEPENDIENTES_OTRO1;
            _PV_FUNCIONES_OTRO1 = pV_FUNCIONES_OTRO1;
            _PD_FECHA_INICIO_OTRO1 = pD_FECHA_INICIO_OTRO1;
            _PD_FECHA_FIN_OTRO1 = pD_FECHA_FIN_OTRO1;
            _PV_DEPARTAMENTO_OTRO1 = pV_DEPARTAMENTO_OTRO1;
            _PV_OTRO_CARGO2 = pV_OTRO_CARGO2;
            _PI_NRO_DEPENDIENTES_OTRO2 = pI_NRO_DEPENDIENTES_OTRO2;
            _PV_FUNCIONES_OTRO2 = pV_FUNCIONES_OTRO2;
            _PD_FECHA_INICIO_OTRO2 = pD_FECHA_INICIO_OTRO2;
            _PD_FECHA_FIN_OTRO2 = pD_FECHA_FIN_OTRO2;
            _PV_DEPARTAMENTO_OTRO2 = pV_DEPARTAMENTO_OTRO2;
            _PV_OTRO_CARGO3 = pV_OTRO_CARGO3;
            _PI_NRO_DEPENDIENTES_OTRO3 = pI_NRO_DEPENDIENTES_OTRO3;
            _PV_FUNCIONES_OTRO3 = pV_FUNCIONES_OTRO3;
            _PD_FECHA_INICIO_OTRO3 = pD_FECHA_INICIO_OTRO3;
            _PD_FECHA_FIN_OTRO3 = pD_FECHA_FIN_OTRO3;
            _PV_DEPARTAMENTO_OTRO3 = pV_DEPARTAMENTO_OTRO3;
            _PV_DESVINCULACION_OTRO = pV_DESVINCULACION_OTRO;
            _PV_ACTUAL_CARGO = pV_ACTUAL_CARGO;
            _PV_MOTIVO_DESVINCULACION = pV_MOTIVO_DESVINCULACION;
            _PI_TOTAL_EXPERIENCIA = pI_TOTAL_EXPERIENCIA;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static DataTable Lista(string PB_ID_PERSONAL)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_EXPERIENCIA");
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_GET_EXPERIENCIA_IND");
                db1.AddInParameter(cmd, "PB_ID_EXPERIENCIA", DbType.Int32, _PB_ID_EXPERIENCIA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    _PV_EMPRESA = dr["PEX_EMPRESA"].ToString();
                    _PV_CARGO = dr["PEX_CARGO"].ToString();
                    _PI_NRO_DEPENDIENTES = Int64.Parse(dr["PEX_NRO_DEPENDIENTES_CARGO"].ToString());
                    _PV_FUNCIONES = dr["PEX_FUNCIONES_CARGO"].ToString();
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_INICIO_CARGO"].ToString())) { _PD_FECHA_INICIO = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_INICIO = DateTime.Parse(dr["PEX_FECHA_INICIO_CARGO"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_FIN_CARGO"].ToString())) { _PD_FECHA_FIN = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_FIN = DateTime.Parse(dr["PEX_FECHA_FIN_CARGO"].ToString()); }
                    _PV_DEPARTAMENTO = dr["PEX_DEPARTAMENTO_CARGO"].ToString();
                    
                    if (string.IsNullOrEmpty(dr["PEX_OTRO_CARGO1"].ToString())) { _PV_OTRO_CARGO1 = ""; } else { _PV_OTRO_CARGO1 = dr["PEX_OTRO_CARGO1"].ToString(); }
                    if (string.IsNullOrEmpty(dr["PEX_NRO_DEPENDIENTES_OTRO1"].ToString())) { _PI_NRO_DEPENDIENTES_OTRO1 = 0; } else { _PI_NRO_DEPENDIENTES_OTRO1 = Int64.Parse(dr["PEX_NRO_DEPENDIENTES_OTRO1"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FUNCIONES_OTRO1"].ToString())) { _PV_FUNCIONES_OTRO1 = ""; } else { _PV_FUNCIONES_OTRO1 = dr["PEX_FUNCIONES_OTRO1"].ToString(); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_INICIO_OTRO1"].ToString())) { _PD_FECHA_INICIO_OTRO1 = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_INICIO_OTRO1 = DateTime.Parse(dr["PEX_FECHA_INICIO_OTRO1"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_FIN_OTRO1"].ToString())) { _PD_FECHA_FIN_OTRO1 = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_FIN_OTRO1 = DateTime.Parse(dr["PEX_FECHA_FIN_OTRO1"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_DEPARTAMENTO_OTRO1"].ToString())) { _PV_DEPARTAMENTO_OTRO1 = ""; } else { _PV_DEPARTAMENTO_OTRO1 = dr["PEX_DEPARTAMENTO_OTRO1"].ToString(); }
                    
                    if (string.IsNullOrEmpty(dr["PEX_OTRO_CARGO2"].ToString())) { _PV_OTRO_CARGO2 = ""; } else { _PV_OTRO_CARGO2 = dr["PEX_OTRO_CARGO2"].ToString(); }
                    if (string.IsNullOrEmpty(dr["PEX_NRO_DEPENDIENTES_OTRO2"].ToString())) { _PI_NRO_DEPENDIENTES_OTRO2 = 0; } else { _PI_NRO_DEPENDIENTES_OTRO2 = Int64.Parse(dr["PEX_NRO_DEPENDIENTES_OTRO2"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FUNCIONES_OTRO2"].ToString())) { _PV_FUNCIONES_OTRO2 = ""; } else { _PV_FUNCIONES_OTRO2 = dr["PEX_FUNCIONES_OTRO2"].ToString(); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_INICIO_OTRO2"].ToString())) { _PD_FECHA_INICIO_OTRO2 = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_INICIO_OTRO2 = DateTime.Parse(dr["PEX_FECHA_INICIO_OTRO2"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_FIN_OTRO2"].ToString())) { _PD_FECHA_FIN_OTRO2 = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_FIN_OTRO2 = DateTime.Parse(dr["PEX_FECHA_FIN_OTRO2"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_DEPARTAMENTO_OTRO2"].ToString())) { _PV_DEPARTAMENTO_OTRO2 = ""; } else { _PV_DEPARTAMENTO_OTRO2 = dr["PEX_DEPARTAMENTO_OTRO2"].ToString(); }

                    if (string.IsNullOrEmpty(dr["PEX_OTRO_CARGO3"].ToString())) { _PV_OTRO_CARGO3 = ""; } else { _PV_OTRO_CARGO3 = dr["PEX_OTRO_CARGO3"].ToString(); }
                    if (string.IsNullOrEmpty(dr["PEX_NRO_DEPENDIENTES_OTRO3"].ToString())) { _PI_NRO_DEPENDIENTES_OTRO3 = 0; } else { _PI_NRO_DEPENDIENTES_OTRO3 = Int64.Parse(dr["PEX_NRO_DEPENDIENTES_OTRO3"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FUNCIONES_OTRO3"].ToString())) { _PV_FUNCIONES_OTRO3 = ""; } else { _PV_FUNCIONES_OTRO3 = dr["PEX_FUNCIONES_OTRO3"].ToString(); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_INICIO_OTRO3"].ToString())) { _PD_FECHA_INICIO_OTRO3 = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_INICIO_OTRO3 = DateTime.Parse(dr["PEX_FECHA_INICIO_OTRO3"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_FECHA_FIN_OTRO3"].ToString())) { _PD_FECHA_FIN_OTRO3 = DateTime.Parse("01/01/3000"); } else { _PD_FECHA_FIN_OTRO3 = DateTime.Parse(dr["PEX_FECHA_FIN_OTRO3"].ToString()); }
                    if (string.IsNullOrEmpty(dr["PEX_DEPARTAMENTO_OTRO3"].ToString())) { _PV_DEPARTAMENTO_OTRO3 = ""; } else { _PV_DEPARTAMENTO_OTRO3 = dr["PEX_DEPARTAMENTO_OTRO3"].ToString(); }


                    _PV_DESVINCULACION_OTRO = dr["PEX_DESVINCULACION_OTRO"].ToString();
                    _PV_ACTUAL_CARGO = dr["PEX_ACTUAL_CARGO"].ToString();
                    _PV_MOTIVO_DESVINCULACION = dr["PEX_MOTIVO_DESVINCULACION"].ToString();
                    _PI_TOTAL_EXPERIENCIA = Int64.Parse(dr["PEX_TOTAL_EXPERIENCIA"].ToString());                    
                    _PB_ID_EXPERIENCIA = Int64.Parse(dr["PEX_ID_EXPERIENCIA"].ToString());
                    _PB_ID_PERSONAL = Int64.Parse(dr["PER_ID_PERSONAL"].ToString());
                }
            }
            catch(Exception ex) { string ex1 = ""; }
        }




        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_POF_ABM_EXPERIENCIA");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_EXPERIENCIA", DbType.Int64, _PB_ID_EXPERIENCIA);
                db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, _PB_ID_PERSONAL);
                db1.AddInParameter(cmd, "PV_EMPRESA", DbType.String, _PV_EMPRESA);
                db1.AddInParameter(cmd, "PV_CARGO", DbType.String, _PV_CARGO);
                db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES", DbType.Int64, _PI_NRO_DEPENDIENTES);
                db1.AddInParameter(cmd, "PV_FUNCIONES", DbType.String, _PV_FUNCIONES);
                
                if (_PD_FECHA_INICIO == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_FECHA_INICIO", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_FECHA_INICIO", DbType.DateTime, _PD_FECHA_INICIO); }
                
                if (_PD_FECHA_FIN == DateTime.Parse("01/01/3000"))
                { db1.AddInParameter(cmd, "PD_FECHA_FIN", DbType.DateTime, null); }
                else { db1.AddInParameter(cmd, "PD_FECHA_FIN", DbType.DateTime, _PD_FECHA_FIN); }

                db1.AddInParameter(cmd, "PV_DEPARTAMENTO", DbType.String, _PV_DEPARTAMENTO);

                if (_PD_FECHA_INICIO_OTRO1 == DateTime.Parse("01/01/3000"))
                {
                    db1.AddInParameter(cmd, "PD_FECHA_INICIO_OTRO1", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "PV_OTRO_CARGO1", DbType.String, null);
                    db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES_OTRO1", DbType.Int64, null);
                    db1.AddInParameter(cmd, "PV_FUNCIONES_OTRO1", DbType.String, null);
                    db1.AddInParameter(cmd, "PD_FECHA_FIN_OTRO1", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "PV_DEPARTAMENTO_OTRO1", DbType.String, null);
                }
                else
                {
                    db1.AddInParameter(cmd, "PD_FECHA_INICIO_OTRO1", DbType.DateTime, _PD_FECHA_INICIO_OTRO1);
                    db1.AddInParameter(cmd, "PV_OTRO_CARGO1", DbType.String, _PV_OTRO_CARGO1);
                    db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES_OTRO1", DbType.Int64, _PI_NRO_DEPENDIENTES_OTRO1);
                    db1.AddInParameter(cmd, "PV_FUNCIONES_OTRO1", DbType.String, _PV_FUNCIONES_OTRO1);
                    db1.AddInParameter(cmd, "PD_FECHA_FIN_OTRO1", DbType.DateTime, _PD_FECHA_FIN_OTRO1);
                    db1.AddInParameter(cmd, "PV_DEPARTAMENTO_OTRO1", DbType.String, _PV_DEPARTAMENTO_OTRO1);
                }

                if (_PD_FECHA_INICIO_OTRO2 == DateTime.Parse("01/01/3000"))
                {
                    db1.AddInParameter(cmd, "PV_OTRO_CARGO2", DbType.String, null);
                    db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES_OTRO2", DbType.Int64, null);
                    db1.AddInParameter(cmd, "PV_FUNCIONES_OTRO2", DbType.String, null);
                    db1.AddInParameter(cmd, "PD_FECHA_INICIO_OTRO2", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "PD_FECHA_FIN_OTRO2", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "PV_DEPARTAMENTO_OTRO2", DbType.String, null);
                }
                else
                {
                    db1.AddInParameter(cmd, "PV_OTRO_CARGO2", DbType.String, _PV_OTRO_CARGO2);
                    db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES_OTRO2", DbType.Int64, _PI_NRO_DEPENDIENTES_OTRO2);
                    db1.AddInParameter(cmd, "PV_FUNCIONES_OTRO2", DbType.String, _PV_FUNCIONES_OTRO2);
                    db1.AddInParameter(cmd, "PD_FECHA_INICIO_OTRO2", DbType.DateTime, _PD_FECHA_INICIO_OTRO2);
                    db1.AddInParameter(cmd, "PD_FECHA_FIN_OTRO2", DbType.DateTime, _PD_FECHA_FIN_OTRO2);
                    db1.AddInParameter(cmd, "PV_DEPARTAMENTO_OTRO2", DbType.String, _PV_DEPARTAMENTO_OTRO2);
                }

                if (_PD_FECHA_INICIO_OTRO3 == DateTime.Parse("01/01/3000"))
                {
                    db1.AddInParameter(cmd, "PV_OTRO_CARGO3", DbType.String, null);
                    db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES_OTRO3", DbType.Int64, null);
                    db1.AddInParameter(cmd, "PV_FUNCIONES_OTRO3", DbType.String, null);
                    db1.AddInParameter(cmd, "PD_FECHA_INICIO_OTRO3", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "PD_FECHA_FIN_OTRO3", DbType.DateTime, null);
                    db1.AddInParameter(cmd, "PV_DEPARTAMENTO_OTRO3", DbType.String, null);
                }
                else
                {
                    db1.AddInParameter(cmd, "PV_OTRO_CARGO3", DbType.String, _PV_OTRO_CARGO3);
                    db1.AddInParameter(cmd, "PI_NRO_DEPENDIENTES_OTRO3", DbType.Int64, _PI_NRO_DEPENDIENTES_OTRO3);
                    db1.AddInParameter(cmd, "PV_FUNCIONES_OTRO3", DbType.String, _PV_FUNCIONES_OTRO3);
                    db1.AddInParameter(cmd, "PD_FECHA_INICIO_OTRO3", DbType.DateTime, _PD_FECHA_INICIO_OTRO3);
                    db1.AddInParameter(cmd, "PD_FECHA_FIN_OTRO3", DbType.DateTime, _PD_FECHA_FIN_OTRO3);
                    db1.AddInParameter(cmd, "PV_DEPARTAMENTO_OTRO3", DbType.String, _PV_DEPARTAMENTO_OTRO3);
                }

                db1.AddInParameter(cmd, "PV_DESVINCULACION_OTRO", DbType.String, _PV_DESVINCULACION_OTRO);
                db1.AddInParameter(cmd, "PV_ACTUAL_CARGO", DbType.String, _PV_ACTUAL_CARGO);
                
                if(_PV_MOTIVO_DESVINCULACION=="SELECCIONAR UNA OPCION")
                    db1.AddInParameter(cmd, "PV_MOTIVO_DESVINCULACION", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_MOTIVO_DESVINCULACION", DbType.String, _PV_MOTIVO_DESVINCULACION);
                
                db1.AddInParameter(cmd, "PI_TOTAL_EXPERIENCIA", DbType.Int64, _PI_TOTAL_EXPERIENCIA);
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
                resultado = PB_ID_EXPERIENCIA + "|" + PV_ERROR + "|" + PV_ESTADOPR + "|" + PV_DESCRIPCION;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "Se produjo un error al registrar: " + ex.ToString();
                return resultado;
            }
        }

        #endregion
    }
}