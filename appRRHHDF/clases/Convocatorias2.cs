using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace appRRHHDF.clases
{
    public class Convocatorias2
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        public static DataTable PR_SEG_GET_CONVOCATORIAS_PUBLICADOS()
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CONVOCATORIAS_PUBLICADOS");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable PR_SEG_GET_COMPETENCIA_CONV(string PD_CNV_CONVOCATORIA)
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_COMPETENCIA_CONV");
            db1.AddInParameter(cmd, "PD_CNV_CONVOCATORIA", DbType.String, PD_CNV_CONVOCATORIA);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_CNV_GET_PREGUNTAS_FRECUENTES()
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_CNV_GET_PREGUNTAS_FRECUENTES");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static DataTable PR_SEG_GET_CONVOCATORIAS_IND(string PD_CNV_CONVOCATORIA)
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CONVOCATORIAS_IND");
            db1.AddInParameter(cmd, "PD_CNV_CONVOCATORIA", DbType.String, PD_CNV_CONVOCATORIA);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_VCO_GET_VALIDA_CONVOCATORIA(Int64 PB_ID_PERSONAL, string PD_CNV_CONVOCATORIA)
        {


            DbCommand cmd = db1.GetStoredProcCommand("PR_VCO_GET_VALIDA_CONVOCATORIA");
            db1.AddInParameter(cmd, "PB_ID_PERSONAL", DbType.Int64, PB_ID_PERSONAL);
            db1.AddInParameter(cmd, "PV_CNV_CONVOCATORIA", DbType.String, PD_CNV_CONVOCATORIA);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_SEG_GET_RAMASAFINES_CONV(string PD_CNV_CONVOCATORIA)
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_RAMASAFINES_CONV");
            db1.AddInParameter(cmd, "PD_CNV_CONVOCATORIA", DbType.String, PD_CNV_CONVOCATORIA);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
    }
}