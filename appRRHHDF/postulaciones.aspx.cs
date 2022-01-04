using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class postulaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session["usuario"] = "ernesto.barron@gmail.com";
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    lblAviso.Text = "";
                    lblPostular.Text = Session["POSTULAR"].ToString();
                    lblUsuario.Text = Session["usuario"].ToString();
                    lblIdPersonal.Text = Session["ID_PERSONAL"].ToString();
                    lblCodConvocatoria.Text = Session["COD_CONVOCATORIA"].ToString();
                    DataTable dt= clases.Convocatorias2.PR_SEG_GET_CONVOCATORIAS_IND(lblCodConvocatoria.Text);
                    foreach (DataRow dr in dt.Rows)
                    {
                        //lblPuesto.Text = dr["CNV_NOMBRE_CARGO"].ToString().ToUpper();
                        //lblTipoConvocatoria.Text = dr["DESC_TIPO_CONVOCATORIA"].ToString().ToUpper();
                        //lblLugar.Text = dr["DESC_TIPO_CONVOCATORIA"].ToString().ToUpper();
                        //lblObjetivo.Text = dr["CNV_OBJETIVO"].ToString().ToUpper();
                        lblEstudios.Text = dr["DESC_NIVEL_ACADEMICO"].ToString().ToUpper();
                        lblEstudiosDesc.Text = dr["CNV_NIVEL_ACADEMICO_DESC"].ToString().ToUpper();
                        lblExpGen.Text = "Experiencia profesional general Mínimo de " + dr["CNV_EXPERIENCIA_GENERAL"].ToString().ToUpper() + " años.";
                        lblExpGenDesc.Text =dr["CNV_EXPERIENCIA_GENERAL_DESC"].ToString();
                        lblEspEsp.Text = "Experiencia profesional específica mínimo de " + dr["CNV_EXPERIENCIA_REQUERIDA"].ToString().ToUpper() + " años.";
                        lblExpEspDesc.Text = dr["CNV_EXPERIENCIA_REQUERIDA_DESC"].ToString();
                    }

                    DataTable dt1 = clases.Convocatorias2.PR_SEG_GET_RAMASAFINES_CONV(lblCodConvocatoria.Text);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            lblEstudiosDesc.Text = lblEstudiosDesc.Text + " / " + dr1["desc_rama_afin"].ToString();
                        }
                    }
                    

                    string nombre_datos = "";
                    DataTable per = clases.Personal.Lista(lblUsuario.Text);
                    foreach (DataRow dr in per.Rows)
                    {
                        nombre_datos = dr["NOMBRE_COMPLETO"].ToString()+" con C.I:" + dr["PER_NUMERO_DOCUMENTO"].ToString();
                    }
                    lblDDJJTexto.Text = "Yo, "+ nombre_datos +" declaro que la información registrada en mi perfil así como en mi postulación es verdadera. Asimismo, autorizo a la empresa realizar la verificación de antecedentes personales y/o profesionales que se requieran realizan en el marco de la confidencialidad y ética requerida.";
                    


                }

            }
        }

        protected void lblFormacion_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lbtnFormacion.Attributes.Add("class", "nav-link active");
            lbtnExperienciaGeneral.Attributes.Add("class", "nav-link");
            lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link");
            lbtnCursosTalleres.Attributes.Add("class", "nav-link");
            lbtnNivelIdioma.Attributes.Add("class", "nav-link");
            lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
            lbtnPDF.Attributes.Add("class", "nav-link");
            MultiView1.ActiveViewIndex =0;
            pasos = 1;
        }

        protected void lbtnExperienciaGeneral_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lbtnFormacion.Attributes.Add("class", "nav-link active");
            lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
            lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link");
            lbtnCursosTalleres.Attributes.Add("class", "nav-link");
            lbtnNivelIdioma.Attributes.Add("class", "nav-link");
            lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
            lbtnPDF.Attributes.Add("class", "nav-link");
            MultiView1.ActiveViewIndex = 1;
            pasos = 2;
        }

        protected void lbtnExperienciaEspecifica_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lbtnFormacion.Attributes.Add("class", "nav-link active");
            lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
            lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link active");
            lbtnCursosTalleres.Attributes.Add("class", "nav-link");
            lbtnNivelIdioma.Attributes.Add("class", "nav-link");
            lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
            lbtnPDF.Attributes.Add("class", "nav-link");
            MultiView1.ActiveViewIndex = 2;
            pasos = 3;
        }

        protected void lbtnCursosTalleres_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lbtnFormacion.Attributes.Add("class", "nav-link active");
            lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
            lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link active");
            lbtnCursosTalleres.Attributes.Add("class", "nav-link active");
            lbtnNivelIdioma.Attributes.Add("class", "nav-link");
            lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
            lbtnPDF.Attributes.Add("class", "nav-link");
            MultiView1.ActiveViewIndex = 3;
            pasos = 4;
        }

        protected void lbtnNivelIdioma_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lbtnFormacion.Attributes.Add("class", "nav-link active");
            lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
            lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link active");
            lbtnCursosTalleres.Attributes.Add("class", "nav-link active");
            lbtnNivelIdioma.Attributes.Add("class", "nav-link active");
            lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
            lbtnPDF.Attributes.Add("class", "nav-link");
            MultiView1.ActiveViewIndex = 4;
            pasos = 5;
        }
        protected void lbtnDeclaracionJurada_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            lbtnFormacion.Attributes.Add("class", "nav-link active");
            lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
            lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link active");
            lbtnCursosTalleres.Attributes.Add("class", "nav-link active");
            lbtnNivelIdioma.Attributes.Add("class", "nav-link active");
            lbtnDeclaracionJurada.Attributes.Add("class", "nav-link active");
            lbtnPDF.Attributes.Add("class", "nav-link");
            MultiView1.ActiveViewIndex = 5;
            pasos = 6;
        }

        protected void lbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                lbtnFormacion.Attributes.Add("class", "nav-link active");
                lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
                lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link active");
                lbtnCursosTalleres.Attributes.Add("class", "nav-link active");
                lbtnNivelIdioma.Attributes.Add("class", "nav-link active");
                lbtnDeclaracionJurada.Attributes.Add("class", "nav-link active");
                lbtnPDF.Attributes.Add("class", "nav-link active");
                MultiView1.ActiveViewIndex = 6;
                pasos = 7;
                DataTable dt_formacion = new DataTable();
                DataTable dt_general = new DataTable();
                DataTable dt_especifica = new DataTable();
                DataTable dt_cursos = new DataTable();
                DataTable dt_idiomas = new DataTable();
                DataTable dt_ddjj = new DataTable();
                DataTable dt_convocatoria = new DataTable();
                DataTable dt_personal = new DataTable();

                dt_formacion = clases.Formacion_postulacion.PR_VCO_GET_FORMACION2(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_general = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_GENERAL2(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_especifica = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_REQUERIDA2(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_cursos = clases.Curso_postulacion.PR_VCO_GET_CURSO2(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_idiomas = clases.Idioma_postulacion.PR_VCO_GET_IDIOMA2(lblIdPersonal.Text, lblCodConvocatoria.Text);
                dt_ddjj = clases.DDJJ_postulacion.PR_VCO_GET_DDJJrep(lblIdPersonal.Text, lblCodConvocatoria.Text, lblUsuario.Text);
                dt_convocatoria = clases.Convocatorias2.PR_SEG_GET_CONVOCATORIAS_IND(lblCodConvocatoria.Text);
                dt_personal = clases.Personal.Lista(lblUsuario.Text);
                //if (dt_formacion.Select("[EXISTE]='SI'").Count() > 0)
                //{ dt_formacion = dt_formacion.Select("[EXISTE]='SI'").CopyToDataTable(); }

                //dt_general = dt_general.Select("[EXISTE]='SI'").CopyToDataTable();
                //dt_especifica = dt_especifica.Select("[EXISTE]='SI'").CopyToDataTable();
                //dt_cursos = dt_cursos.Select("[EXISTE]='SI'").CopyToDataTable();
                //dt_idiomas = dt_idiomas.Select("[EXISTE]='SI'").CopyToDataTable();
                //dt_ddjj = dt_ddjj.Select("[CDD_VALOR]=''").CopyToDataTable();
                //dt_formacion = dt_formacion.Select("EXISTE=SI").CopyToDataTable();
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSFormacion", dt_formacion));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSGeneral", dt_general));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSEspecifica", dt_especifica));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSCursos", dt_cursos));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSIdiomas", dt_idiomas));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSDDJJ", dt_ddjj));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSConvocatoria", dt_convocatoria));
                rv.LocalReport.DataSources.Add(new ReportDataSource("DSPersonal", dt_personal));

                rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/test1.rdlc");
                rv.LocalReport.EnableHyperlinks = true;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_pdf_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }


        }
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                DateTime fecha_titulo = DateTime.Parse("01/01/3000");
                if (datos[4] != "")
                    fecha_ini = DateTime.Parse(datos[4]);
                if (datos[5] != "")
                    fecha_fin = DateTime.Parse(datos[5]);
                if (datos[8] != "")
                    fecha_titulo = DateTime.Parse(datos[8]);
                clases.Formacion_postulacion obj2 = new clases.Formacion_postulacion("I", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[2],
                    datos[3], fecha_ini, fecha_fin, datos[6], datos[7], fecha_titulo, datos[9], lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0","").Replace("|","");
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_formacion_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        

        protected void btnDesseleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                DateTime fecha_titulo = DateTime.Parse("01/01/3000");
                if (datos[4] != "")
                    fecha_ini = DateTime.Parse(datos[4]);
                if (datos[5] != "")
                    fecha_fin = DateTime.Parse(datos[5]);
                if (datos[8] != "")
                    fecha_titulo = DateTime.Parse(datos[8]);
                clases.Formacion_postulacion obj2 = new clases.Formacion_postulacion("I", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[2],
                    datos[3], fecha_ini, fecha_fin, datos[6], datos[7], fecha_titulo, datos[9], lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_formacion_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            

        }

        //protected void btnAnterior_Click(object sender, EventArgs e)
        //{
            
        //    if (pasos < 0)
        //        pasos = 0;
        //    if (pasos > 6)
        //        pasos = 6;

        //    if (pasos == 0)
        //    {
        //        lbtnFormacion.Attributes.Add("class", "nav-link active");
        //        lbtnExperienciaGeneral.Attributes.Add("class", "nav-link");
        //        MultiView1.ActiveViewIndex = pasos -1;
        //        btnNext.Enabled = true;
        //        btnAnterior.Enabled = false;
        //    }
        //    if (pasos == 1)
        //    {
        //        lbtnExperienciaGeneral.Attributes.Add("class", "nav-link");
        //        lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link");
        //        MultiView1.ActiveViewIndex = pasos -1;
        //        btnNext.Enabled = true;
        //    }
        //    if (pasos == 2)
        //    {
        //        lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link");
        //        lbtnCursosTalleres.Attributes.Add("class", "nav-link");
        //        MultiView1.ActiveViewIndex = pasos-1;
        //        btnNext.Enabled = true;
        //    }
        //    if (pasos == 3)
        //    {
        //        lbtnCursosTalleres.Attributes.Add("class", "nav-link");
        //        lbtnNivelIdioma.Attributes.Add("class", "nav-link");
        //        MultiView1.ActiveViewIndex = pasos -1;
        //        btnNext.Enabled = true;
        //    }
        //    if (pasos == 4)
        //    {
        //        lbtnNivelIdioma.Attributes.Add("class", "nav-link");
        //        lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
        //        MultiView1.ActiveViewIndex = pasos - 1;
        //        btnNext.Enabled = true;
        //    }
        //    if (pasos == 5)
        //    {
        //        lbtnDeclaracionJurada.Attributes.Add("class", "nav-link");
        //        lbtnPDF.Attributes.Add("class", "nav-link");
        //        MultiView1.ActiveViewIndex = pasos - 1;
        //        btnNext.Enabled = true;
        //    }
        //    if (pasos == 6)
        //    {
        //        lbtnPDF.Attributes.Add("class", "nav-link");

        //        MultiView1.ActiveViewIndex = pasos-1;
        //        btnNext.Enabled = false;
        //        DataTable dt_formacion = new DataTable();
        //        DataTable dt_general = new DataTable();
        //        DataTable dt_especifica = new DataTable();
        //        DataTable dt_cursos = new DataTable();
        //        DataTable dt_idiomas = new DataTable();
        //        DataTable dt_ddjj = new DataTable();
        //        DataTable dt_convocatoria = new DataTable();

        //        dt_formacion = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_general = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_GENERAL(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_especifica = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_REQUERIDA(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_cursos = clases.Curso_postulacion.PR_VCO_GET_CURSO(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_idiomas = clases.Idioma_postulacion.PR_VCO_GET_IDIOMA(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_ddjj = clases.DDJJ_postulacion.PR_VCO_GET_DDJJ(lblIdPersonal.Text, lblCodConvocatoria.Text, lblUsuario.Text);
        //        dt_convocatoria = clases.Convocatorias2.PR_SEG_GET_CONVOCATORIAS_IND(lblCodConvocatoria.Text);

        //        //dt_formacion = dt_formacion.Select("EXISTE=SI").CopyToDataTable();
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSFormacion", dt_formacion));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSGeneral", dt_general));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSEspecifica", dt_especifica));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCursos", dt_cursos));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSIdiomas", dt_idiomas));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSDDJJ", dt_ddjj));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSConvocatoria", dt_convocatoria));

        //        rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/test1.rdlc");
        //        rv.LocalReport.EnableHyperlinks = true;
        //    }
        //    pasos--;
        //    lblAviso.Text = "";
        //}
        static int pasos = 0;
        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    lblAviso.Text = "";
        //    pasos++;

        //    if (pasos < 0)
        //        pasos = 0;
        //    if (pasos > 6)
        //        pasos = 6;
        //    if (pasos == 0)
        //    {
        //        lbtnFormacion.Attributes.Add("class", "nav-link active");

        //        MultiView1.ActiveViewIndex = pasos ;
        //        btnAnterior.Enabled = true;
        //    }
        //    if (pasos == 1)
        //    {
        //        lbtnExperienciaGeneral.Attributes.Add("class", "nav-link active");
                
        //        MultiView1.ActiveViewIndex = pasos;
        //        btnAnterior.Enabled = true;
        //    }
        //    if (pasos == 2)
        //    {
        //        lbtnExperienciaEspecifica.Attributes.Add("class", "nav-link active");

        //        MultiView1.ActiveViewIndex = pasos;
        //        btnAnterior.Enabled = true;
        //    }
        //    if (pasos == 3)
        //    {
        //        lbtnCursosTalleres.Attributes.Add("class", "nav-link active");

        //        MultiView1.ActiveViewIndex = pasos;
        //        btnAnterior.Enabled = true;
        //    }
        //    if (pasos == 4)
        //    {
        //        lbtnNivelIdioma.Attributes.Add("class", "nav-link active");

        //        MultiView1.ActiveViewIndex = pasos;
        //        btnAnterior.Enabled = true;
        //    }
        //    if (pasos == 5)
        //    {
        //        lbtnDeclaracionJurada.Attributes.Add("class", "nav-link active");

        //        MultiView1.ActiveViewIndex = pasos;
        //        btnAnterior.Enabled = true;
        //    }
        //    if (pasos == 6)
        //    {
        //        lbtnPDF.Attributes.Add("class", "nav-link active");

        //        MultiView1.ActiveViewIndex = pasos;
        //        btnNext.Enabled = false;
        //        btnAnterior.Enabled = true;
        //        DataTable dt_formacion = new DataTable();
        //        DataTable dt_general = new DataTable();
        //        DataTable dt_especifica = new DataTable();
        //        DataTable dt_cursos = new DataTable();
        //        DataTable dt_idiomas = new DataTable();
        //        DataTable dt_ddjj = new DataTable();
        //        DataTable dt_convocatoria = new DataTable();

        //        dt_formacion = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_general = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_GENERAL(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_especifica = clases.Experiencias_postulacion.PR_VCO_GET_EXPERIENCIA_REQUERIDA(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_cursos = clases.Curso_postulacion.PR_VCO_GET_CURSO(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_idiomas = clases.Idioma_postulacion.PR_VCO_GET_IDIOMA(lblIdPersonal.Text, lblCodConvocatoria.Text);
        //        dt_ddjj = clases.DDJJ_postulacion.PR_VCO_GET_DDJJ(lblIdPersonal.Text, lblCodConvocatoria.Text, lblUsuario.Text);
        //        dt_convocatoria = clases.Convocatorias2.PR_SEG_GET_CONVOCATORIAS_IND(lblCodConvocatoria.Text);

        //        dt_formacion = dt_formacion.Select("[EXISTE]='SI'").CopyToDataTable();
        //        dt_general = dt_general.Select("[EXISTE]='SI'").CopyToDataTable();
        //        dt_especifica = dt_especifica.Select("[EXISTE]='SI'").CopyToDataTable();
        //        dt_cursos = dt_cursos.Select("[EXISTE]='SI'").CopyToDataTable();
        //        dt_idiomas = dt_idiomas.Select("[EXISTE]='SI'").CopyToDataTable();
        //        dt_ddjj = dt_ddjj.Select("[CDD_VALOR] is not null").CopyToDataTable();

        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSFormacion", dt_formacion));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSGeneral", dt_general));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSEspecifica", dt_especifica));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSCursos", dt_cursos));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSIdiomas", dt_idiomas));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSDDJJ", dt_ddjj));
        //        rv.LocalReport.DataSources.Add(new ReportDataSource("DSConvocatoria", dt_convocatoria));

        //        rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/test1.rdlc");
        //        rv.LocalReport.EnableHyperlinks = true;
        //    }
        //}

      

       
        protected void btnSeleccionar2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                if (datos[3] != "")
                    fecha_ini = DateTime.Parse(datos[3]);
                if (datos[4] != "")
                    fecha_fin = DateTime.Parse(datos[4]);
                clases.Experiencias_postulacion obj2 = new clases.Experiencias_postulacion("G", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], "", Int64.Parse(datos[2]), fecha_ini, fecha_fin, "", lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_ex_general_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        protected void btnDesseleccionar2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                if (datos[3] != "")
                    fecha_ini = DateTime.Parse(datos[3]);
                if (datos[4] != "")
                    fecha_fin = DateTime.Parse(datos[4]);
                clases.Experiencias_postulacion obj2 = new clases.Experiencias_postulacion("G", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], "", Int64.Parse(datos[2]), fecha_ini, fecha_fin, "", lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                Repeater2.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_ex_general_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            

        }

        protected void btnSeleccionar3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                if (datos[4] != "")
                    fecha_ini = DateTime.Parse(datos[4]);
                if (datos[5] != "")
                    fecha_fin = DateTime.Parse(datos[5]);
                clases.Experiencias_postulacion obj2 = new clases.Experiencias_postulacion("E", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[2], Int64.Parse(datos[3]), fecha_ini, fecha_fin, datos[6], lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                odsExpEspecifica.DataBind();
                Repeater3.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_ex_especifica_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        protected void btnDesseleccionar3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                if (datos[4] != "")
                    fecha_ini = DateTime.Parse(datos[4]);
                if (datos[5] != "")
                    fecha_fin = DateTime.Parse(datos[5]);
                clases.Experiencias_postulacion obj2 = new clases.Experiencias_postulacion("E", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[2], Int64.Parse(datos[3]), fecha_ini, fecha_fin, datos[6], lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                odsExpEspecifica.DataBind();
                Repeater3.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_ex_especifica_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        protected void btnDesseleccionar4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                DateTime fecha_titulo = DateTime.Parse("01/01/3000");
                if (datos[4] != "")
                    fecha_ini = DateTime.Parse(datos[4]);
                if (datos[5] != "")
                    fecha_fin = DateTime.Parse(datos[5]);
                if (datos[5] != "")
                    fecha_titulo = DateTime.Parse(datos[7]);
                clases.Curso_postulacion obj2 = new clases.Curso_postulacion("I", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[2], datos[3], fecha_ini, fecha_fin, int.Parse(datos[6]), datos[8], fecha_titulo, lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                odsCursos.DataBind();
                Repeater4.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cursos_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        protected void btnSeleccionar4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                DateTime fecha_titulo = DateTime.Parse("01/01/3000");
                if (datos[4] != "")
                    fecha_ini = DateTime.Parse(datos[4]);
                if (datos[5] != "")
                    fecha_fin = DateTime.Parse(datos[5]);
                if (datos[5] != "")
                    fecha_titulo = DateTime.Parse(datos[7]);
                clases.Curso_postulacion obj2 = new clases.Curso_postulacion("I", lblCodConvocatoria.Text, Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[2], datos[3], fecha_ini, fecha_fin, int.Parse(datos[6]), datos[8], fecha_titulo, lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                odsCursos.DataBind();
                Repeater4.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cursos_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        protected void btnSeleccionar5_Click(object sender, EventArgs e)
        {
            try 
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');

                clases.Idioma_postulacion obj2 = new clases.Idioma_postulacion("I", lblCodConvocatoria.Text, datos[2], Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[3], datos[4], lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                Repeater5.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_idiomas_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
        }

        protected void btnDesseleccionar5_Click(object sender, EventArgs e)
        {
            try 
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');

                clases.Idioma_postulacion obj2 = new clases.Idioma_postulacion("I", lblCodConvocatoria.Text, datos[2], Int64.Parse(datos[0]), Int64.Parse(lblIdPersonal.Text), datos[1], datos[3], datos[4], lblUsuario.Text);
                lblAviso.Text = obj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                Repeater5.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_idiomas_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            

        }

        protected void btnGuardarDDJJ_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in Repeater6.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var drop = (DropDownList)item.FindControl("DropDownList1");
                        string[] datos = drop.ToolTip.Split('|');

                        clases.DDJJ_postulacion ddjj = new clases.DDJJ_postulacion("U", datos[0], lblCodConvocatoria.Text, datos[1], Int64.Parse(datos[2]), Int64.Parse(lblIdPersonal.Text), datos[3], drop.SelectedItem.Text, datos[4], datos[5], lblUsuario.Text);
                        lblAviso.Text = ddjj.ABM().Replace("0", "").Replace("|", "").Replace("1", "");

                        var texto = (TextBox)item.FindControl("TextBox1");
                        if (texto.Text != "")
                        {
                            clases.DDJJ_postulacion ddjj2 = new clases.DDJJ_postulacion("U", datos[0], lblCodConvocatoria.Text, datos[1], Int64.Parse(datos[2]), Int64.Parse(lblIdPersonal.Text), datos[3], texto.Text, datos[4], datos[5], lblUsuario.Text);
                            lblAviso.Text = ddjj2.ABM().Replace("0", "").Replace("|", "").Replace("1", "");
                        }

                    }
                }
                string resultado = "";
                DataTable dt = clases.Convocatorias2.PR_VCO_GET_VALIDA_CONVOCATORIA(Int64.Parse(lblIdPersonal.Text), lblCodConvocatoria.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    resultado = dr[0].ToString(); ;
                }
                lblPostular.Text = resultado;
                Repeater1.DataBind();
                Repeater2.DataBind();
                Repeater3.DataBind();
                Repeater4.DataBind();
                Repeater5.DataBind();
                Repeater6.DataBind();

            }
            catch(Exception ex)
            {
                string nombre_archivo = "error_DDJJ_post_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";

            }
            
            
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lblPostular.Text == "NOK")
                { 
                    var btn1a = (Button)e.Item.FindControl("btnSeleccionar");
                    var btn1b = (Button)e.Item.FindControl("btnDesseleccionar");

                    btn1a.Enabled = false;
                    btn1b.Enabled = false;
                }
            }
            
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lblPostular.Text == "NOK")
                {
                    var btn1a = (Button)e.Item.FindControl("btnSeleccionar2");
                    var btn1b = (Button)e.Item.FindControl("btnDesseleccionar2");

                    btn1a.Enabled = false;
                    btn1b.Enabled = false;
                }
            }
        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lblPostular.Text == "NOK")
                {
                    var btn1a = (Button)e.Item.FindControl("btnSeleccionar3");
                    var btn1b = (Button)e.Item.FindControl("btnDesseleccionar3");

                    btn1a.Enabled = false;
                    btn1b.Enabled = false;
                }
            }
        }

        protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lblPostular.Text == "NOK")
                {
                    var btn1a = (Button)e.Item.FindControl("btnSeleccionar4");
                    var btn1b = (Button)e.Item.FindControl("btnDesseleccionar4");

                    btn1a.Enabled = false;
                    btn1b.Enabled = false;
                }
            }
        }

        protected void Repeater5_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lblPostular.Text == "NOK")
                {
                    var btn1a = (Button)e.Item.FindControl("btnSeleccionar5");
                    var btn1b = (Button)e.Item.FindControl("btnDesseleccionar5");

                    btn1a.Enabled = false;
                    btn1b.Enabled = false;
                }
            }
        }

        protected void Repeater6_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lblPostular.Text == "NOK")
                {
                    var btn1a = (DropDownList)e.Item.FindControl("DropDownList1");

                    btn1a.Enabled = false;

                    var btn1b = (TextBox)e.Item.FindControl("TextBox1");

                    btn1b.Enabled = false;
                }
            }

            Label label1 = e.Item.FindControl("lblTitulo") as Label;
            RegularExpressionValidator validar = e.Item.FindControl("RegularExpressionValidator1") as RegularExpressionValidator;
            if (label1.Text.Contains("Preten"))
            {
                //boton1.Text = "Finalizar";
                validar.Enabled = true;
            }
            else
            {
                validar.Enabled = false;
            }

        }

        protected void btnCV_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulario.aspx");
        }
    }
}