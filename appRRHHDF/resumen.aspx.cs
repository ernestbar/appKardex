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
    public partial class resumen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");

                }
                else
                {
                    lblAviso.Text = "";
                    lblUsuario.Text = Session["usuario"].ToString();
                    DataTable dt = clases.Personal.Lista(lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (String.IsNullOrEmpty(dr["PER_ID_PERSONAL"].ToString())) { lblIdPersonal.Text = ""; } else { lblIdPersonal.Text = dr["PER_ID_PERSONAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr["CORREO_ELECTRONICO"].ToString())) { lblEmail.Text = "S/D"; } else { lblEmail.Text = dr["CORREO_ELECTRONICO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_NOMBRE"].ToString())) { lblNombreApellido.Text = ""; } else { lblNombreApellido.Text = dr["PER_NOMBRE"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_APELLIDO_PATERNO"].ToString())) { lblNombreApellido.Text = lblNombreApellido.Text + ""; } else { lblNombreApellido.Text = lblNombreApellido.Text + " " + dr["PER_APELLIDO_PATERNO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_APELLIDO_MATERNO"].ToString())) { lblNombreApellido.Text = lblNombreApellido.Text + ""; } else { lblNombreApellido.Text = lblNombreApellido.Text + " " + dr["PER_APELLIDO_MATERNO"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_APELLIDO_MARITAL"].ToString())) { lblApellidoCasada.Text = ""; } else { lblApellidoCasada.Text = dr["PER_APELLIDO_MARITAL"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_NUMERO_DOCUMENTO"].ToString())) { lbl.Text = ""; } else { txtNumeroDocumento.Text = dr["PER_NUMERO_DOCUMENTO"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_TIPO_DOCUMENTO"].ToString())) { ddlTipoDocumento.DataBind(); } else { ddlTipoDocumento.SelectedValue = dr["PER_TIPO_DOCUMENTO"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_COMPLEMENTO"].ToString())) { txtComplemento.Text = ""; } else { txtComplemento.Text = dr["PER_COMPLEMENTO"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_EXPEDIDO"].ToString())) { ddlExpedido.DataBind(); } else { ddlExpedido.SelectedValue = dr["PER_EXPEDIDO"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_ESTADO_CIVIL"].ToString())) { ddlEsdatoCivil.DataBind(); } else { ddlEsdatoCivil.SelectedValue = dr["PER_ESTADO_CIVIL"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_GENERO"].ToString())) { ddlGenero.DataBind(); } else { ddlGenero.SelectedValue = dr["PER_GENERO"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_FECHA_NACIMIENTO"].ToString())) { cargar_calendarios(); }
                            //else
                            //{
                            //    DateTime fecha_aux = DateTime.Parse(dr["PER_FECHA_NACIMIENTO"].ToString());
                            //    ddlNacDia.SelectedValue = fecha_aux.Day.ToString();
                            //    ddlNacMes.SelectedValue = fecha_aux.Month.ToString();
                            //    ddlNacAño.SelectedValue = fecha_aux.Year.ToString();

                            //}
                            if (String.IsNullOrEmpty(dr["TELEFONO_FIJO"].ToString())) { lblTelefonoCelular.Text = ""; } else { lblTelefonoCelular.Text = dr["TELEFONO_FIJO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["TELEFONO_CELULAR"].ToString())) { lblTelefonoCelular.Text = lblTelefonoCelular.Text + ""; } else { lblTelefonoCelular.Text = lblTelefonoCelular.Text + " - " + dr["TELEFONO_CELULAR"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PAI_ID_PAIS"].ToString()))
                            //{ ddlPaisRes.DataBind(); }
                            //else
                            //{
                            //    ddlPaisRes.DataBind();
                            //    ListItem valor = new ListItem();
                            //    valor.Text = dr["DESC_PAIS"].ToString();
                            //    valor.Value = dr["PAI_ID_PAIS"].ToString();
                            //    int indice = ddlPaisRes.Items.IndexOf(valor);
                            //    ddlPaisRes.SelectedIndex = indice;
                            //    ddlDepartaentoRes.DataBind();
                            //}
                            //if (String.IsNullOrEmpty(dr["CIU_ID_CIUDAD"].ToString())) { ddlDepartaentoRes.DataBind(); }
                            //else
                            //{
                            //    ddlDepartaentoRes.SelectedValue = dr["CIU_ID_CIUDAD"].ToString();
                            //}
                            //if (String.IsNullOrEmpty(dr["DIR_CIUDAD_RESIDENCIA"].ToString())) { txtCiudadRes.Text = ""; } else { txtCiudadRes.Text = dr["DIR_CIUDAD_RESIDENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr["DIR_DIRECCION"].ToString())) { lblDireccion.Text = ""; } else { lblDireccion.Text = dr["DIR_DIRECCION"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_FOTO"].ToString())) { imgPerfil.ImageUrl = "~/Fotos/sin_imagen.png"; }
                            else
                            {
                                byte[] foto_aux = (byte[])dr["PER_FOTO"];

                                string imageBase64 = Convert.ToBase64String(foto_aux);
                                string imageSrc = string.Format("data:image/jpg;base64,{0}", imageBase64);
                                imgPerfil.ImageUrl = imageSrc;
                                //imgPerfil.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void lbtnDatosPersonales_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("formulario.aspx");
        }
        protected void lbtnDatosFam_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("Datos_fam.aspx");
        }

        protected void lbtnEstudiosRealizados_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("Estudios_realizados.aspx");
        }

        protected void lbtnCursosTalleres_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("Cursos_Talleres.aspx");
        }

        protected void lbtnNivelIdioma_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("nivel_idioma.aspx");
        }

        protected void lbtnExpLaboral_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("Experiencia_Laboral.aspx");
        }

        protected void lbtnRefLaboral_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("Referencia_Laboral.aspx");
        }

        protected void lbtnOtrosDatos_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("Otros_Datos.aspx");
        }

        protected void lbtnResumen_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("resumen.aspx");
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!Page.IsPostBack)
        //    {
        //        if (Session["usuario"] == null)
        //        {
        //            Response.Redirect("login.aspx");
        //        }
        //        else
        //        {
        //            lblAviso.Text = "";
        //            lblUsuario.Text = Session["usuario"].ToString();
        //            DataTable dt = clases.Personal.Lista(lblUsuario.Text);
        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    lblIdPersonal.Text = dr["PER_ID_PERSONAL"].ToString();

        //                }
        //            }
        //            DataTable dt_personal = new DataTable();
        //            DataTable dt_estudios = new DataTable();
        //            DataTable dt_idiomas = new DataTable();
        //            DataTable dt_referencias = new DataTable();
        //            DataTable dt_familiares = new DataTable();
        //            DataTable dt_otrosdocs = new DataTable();
        //            DataTable dt_cursos = new DataTable();
        //            DataTable dt_experiencias= new DataTable();

        //            dt_personal = clases.Personal.Lista(lblUsuario.Text);
        //            dt_estudios = clases.Estudios_realizados.Lista(lblIdPersonal.Text);
        //            dt_idiomas = clases.Idiomas.Lista(lblIdPersonal.Text);
        //            dt_referencias = clases.Referencias_laborales.Lista(lblIdPersonal.Text);
        //            dt_familiares = clases.Datos_familiares.Lista(lblIdPersonal.Text);
        //            dt_otrosdocs = clases.Otros_documentos.Lista(lblIdPersonal.Text);
        //            dt_cursos = clases.Cursos_talleres.Lista(lblIdPersonal.Text);
        //            dt_experiencias = clases.Experiencia_Laboral.Lista(lblIdPersonal.Text);

        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSPesonal", dt_personal));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSEstudios", dt_estudios));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSIdiomas", dt_idiomas));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSReferencias", dt_referencias));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSFamiliares", dt_familiares));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSPOtrosDocs", dt_otrosdocs));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSCursos", dt_cursos));
        //            rv.LocalReport.DataSources.Add(new ReportDataSource("DSExperiencias", dt_experiencias));
        //            rv.LocalReport.ReportPath = Server.MapPath("~/Reportes/resumenRpt.rdlc");
        //            rv.LocalReport.EnableHyperlinks = true;

        //        }


        //    }
        //}

        //protected void lbtnDatosFam_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("Datos_fam.aspx");
        //}

        //protected void lbtnEstudiosRealizados_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("Estudios_realizados.aspx");
        //}

        //protected void lbtnCursosTalleres_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("Cursos_Talleres.aspx");
        //}

        //protected void lbtnNivelIdioma_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("nivel_idioma.aspx");
        //}

        //protected void lbtnExpLaboral_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("Experiencia_Laboral.aspx");
        //}

        //protected void lbtnRefLaboral_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("Referencia_Laboral.aspx");
        //}

        //protected void lbtnOtrosDatos_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("Otros_Datos.aspx");
        //}

        //protected void lbtnResumen_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("resumen.aspx");
        //}

        //protected void lbtnDatosPersonales_Click(object sender, EventArgs e)
        //{
        //    Session["usuario"] = lblUsuario.Text;
        //    Response.Redirect("formulario.aspx");
        //}
    }
}