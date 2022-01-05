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
    public partial class nivel_idioma : System.Web.UI.Page
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
                    lblUsuario.Text = Session["usuario"].ToString();
                    lblIdPersonal.Text = Session["id_personal"].ToString();
                   
                }

            }
        }
        public void limpiarDatos()
        {
            ddlNivelConversacion.DataBind();
            ddlNivelEscritura.DataBind();
            ddlNivelLectura.DataBind();
            dllIdiomas.DataBind();
            lblAviso.Text = "";
            lblIdIdioma.Text = "";
            ckbCertificado.Checked = false;
        }
        protected void btnAdicionarNivelIdioma_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                string con_titulo = "NO";
                if (ckbCertificado.Checked == true)
                    con_titulo = "SI";

                MultiView1.ActiveViewIndex = 0;
                if (lblIdIdioma.Text == "")
                {
                    clases.Idiomas obj_er = new clases.Idiomas("I", 0, Int64.Parse(lblIdPersonal.Text), dllIdiomas.SelectedValue,
                        ddlNivelLectura.SelectedValue, ddlNivelEscritura.SelectedValue, ddlNivelConversacion.SelectedValue, con_titulo,
                       lblUsuario.Text);
                    lblAviso.Text = obj_er.ABM();
                }
                else
                {
                    clases.Idiomas obj_er = new clases.Idiomas("U", Int64.Parse(lblIdIdioma.Text), Int64.Parse(lblIdPersonal.Text), dllIdiomas.SelectedValue,
                        ddlNivelLectura.SelectedValue, ddlNivelEscritura.SelectedValue, ddlNivelConversacion.SelectedValue, con_titulo,
                       lblUsuario.Text);
                    lblAviso.Text = obj_er.ABM();
                }


                Repeater1.DataBind();
                limpiarDatos();
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_nivel_idioma_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void lbtnDatosFam_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("Datos_fam.aspx");
        }

        protected void lbtnEstudiosRealizados_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("Estudios_realizados.aspx");
        }

        protected void lbtnCursosTalleres_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("Cursos_Talleres.aspx");
        }

        protected void lbtnNivelIdioma_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("nivel_idioma.aspx");
        }

        protected void lbtnExpLaboral_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("Experiencia_Laboral.aspx");
        }

        protected void lbtnRefLaboral_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("Referencia_Laboral.aspx");
        }

        protected void lbtnOtrosDatos_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("Otros_Datos.aspx");
        }

        protected void lbtnResumen_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("resumen.aspx");
        }

        protected void lbtnDatosPersonales_Click(object sender, EventArgs e)
        {
            Session["id_personal"] = lblIdPersonal.Text;
            Response.Redirect("formulario.aspx");
        }

        protected void ddlNivelConversacion_DataBound(object sender, EventArgs e)
        {
            ddlNivelConversacion.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void ddlNivelEscritura_DataBound(object sender, EventArgs e)
        {
            ddlNivelEscritura.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void ddlNivelLectura_DataBound(object sender, EventArgs e)
        {
            ddlNivelLectura.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void dllIdiomas_DataBound(object sender, EventArgs e)
        {
            dllIdiomas.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            limpiarDatos();
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            clases.Idiomas obj_est = new clases.Idiomas(Int64.Parse(id));
            lblIdIdioma.Text = obj_est.PB_ID_IDIOMA.ToString();
            dllIdiomas.SelectedValue = obj_est.PV_IDIOMA.ToString();
            ddlNivelConversacion.SelectedValue = obj_est.PV_NIVEL_DOMINIO_CONVERSACION.ToString();
            ddlNivelEscritura.SelectedValue = obj_est.PV_NIVEL_DOMINIO_ESCRITURA.ToString();
            ddlNivelLectura.SelectedValue = obj_est.PV_NIVEL_DOMINIO_LECTURA.ToString();
            if (obj_est.PV_CON_TITULO == "SI")
                ckbCertificado.Checked = true;
            else
                ckbCertificado.Checked = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarDatos();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                clases.Idiomas obj_est = new clases.Idiomas(Int64.Parse(id));
                lblIdIdioma.Text = obj_est.PB_ID_IDIOMA.ToString();
                dllIdiomas.SelectedValue = obj_est.PV_IDIOMA.ToString();
                ddlNivelConversacion.SelectedValue = obj_est.PV_NIVEL_DOMINIO_CONVERSACION.ToString();
                ddlNivelEscritura.SelectedValue = obj_est.PV_NIVEL_DOMINIO_ESCRITURA.ToString();
                ddlNivelLectura.SelectedValue = obj_est.PV_NIVEL_DOMINIO_LECTURA.ToString();
                if (obj_est.PV_CON_TITULO == "SI")
                    ckbCertificado.Checked = true;
                else
                    ckbCertificado.Checked = false;
                string con_titulo = "NO";
                if (ckbCertificado.Checked == true)
                    con_titulo = "SI";
                clases.Idiomas obj_er = new clases.Idiomas("D", Int64.Parse(lblIdIdioma.Text), Int64.Parse(lblIdIdioma.Text), dllIdiomas.SelectedValue,
                        ddlNivelLectura.SelectedValue, ddlNivelEscritura.SelectedValue, ddlNivelConversacion.SelectedValue, con_titulo,
                       lblUsuario.Text);
                lblAviso.Text = obj_er.ABM();
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_nivel_idioma_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }
            

        }
    }
}