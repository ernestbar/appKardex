using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class reportePostulacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = "ernesto.barron@gmail.com";
                lblCodConvocatoria.Text = "CNV/72/2021";
                lblIdPersonal.Text = "4";
                DataTable dt_formacion = new DataTable();
                DataTable dt_general = new DataTable();
                DataTable dt_especifica = new DataTable();
                DataTable dt_cursos = new DataTable();
                DataTable dt_idiomas = new DataTable();
                DataTable dt_ddjj = new DataTable();
                DataTable dt_convocatoria = new DataTable();

                dt_formacion = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_general = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_GENERAL(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_especifica = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_REQUERIDA(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_cursos = clases.Curso_postulacion.PR_VCO_GET_CURSO(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_idiomas = clases.Idioma_postulacion.PR_VCO_GET_IDIOMA(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_ddjj = clases.DDJJ_postulacion.PR_VCO_GET_DDJJ(lblIdPersonal.Text, lblCodConvocatoria.Text, lblUsuario.Text);
                dt_convocatoria = clases.Convocatorias2.PR_SEG_GET_CONVOCATORIAS_IND(lblCodConvocatoria.Text);

                dt_formacion = dt_formacion.Select("[EXISTE]='SI'").CopyToDataTable();
                dt_general = dt_general.Select("[EXISTE]='SI'").CopyToDataTable();
                dt_especifica = dt_especifica.Select("[EXISTE]='SI'").CopyToDataTable();
                dt_cursos = dt_cursos.Select("[EXISTE]='SI'").CopyToDataTable();
                dt_idiomas = dt_idiomas.Select("[EXISTE]='SI'").CopyToDataTable();
                dt_ddjj = dt_ddjj.Select("[CDD_VALOR] is not null").CopyToDataTable();

                rv.LocalReport.DataSources.Add(new ReportDataSource("DSFormacion", dt_formacion));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSGeneral", dt_general));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSEspecifica", dt_especifica));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSCursos", dt_cursos));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSIdiomas", dt_idiomas));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSDDJJ", dt_ddjj));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSConvocatoria", dt_convocatoria));

                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/test1.rdlc");
                rv.LocalReport.EnableHyperlinks = true;
            }
            
        }
    }
}