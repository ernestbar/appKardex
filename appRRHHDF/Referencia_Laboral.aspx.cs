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
    public partial class Referencia_Laboral : System.Web.UI.Page
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
        public void limpiar_datos()
        {
            lblIdReferencia.Text = "";
            lblAviso.Text = "";
            txtCargo.Text = "";
            txtCelular.Text = "";
            txtCorreoElectronico.Text="";
            txtEmpresa.Text = "";
            txtRelacionLaboral.Text = "";
            txtTelefono.Text = "";
        }
        protected void btnAdicionarReferenciaLaboral_Click(object sender, EventArgs e)
        {
            limpiar_datos();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 0;
                if (lblIdReferencia.Text == "")
                {
                    clases.Referencias_laborales obj_er = new clases.Referencias_laborales("I", 0, Int64.Parse(lblIdPersonal.Text), txtEmpresa.Text,
                        txtRelacionLaboral.Text, txtCargo.Text, txtTelefono.Text, txtCelular.Text, txtCorreoElectronico.Text,
                       lblUsuario.Text);
                    lblAviso.Text = obj_er.ABM();
                }
                else
                {
                    clases.Referencias_laborales obj_er = new clases.Referencias_laborales("U", Int64.Parse(lblIdReferencia.Text), Int64.Parse(lblIdPersonal.Text), txtEmpresa.Text,
                        txtRelacionLaboral.Text, txtCargo.Text, txtTelefono.Text, txtCelular.Text, txtCorreoElectronico.Text,
                       lblUsuario.Text);
                    lblAviso.Text = obj_er.ABM();
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
                limpiar_datos();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_ref_lab_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            limpiar_datos();
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            clases.Referencias_laborales obj_est = new clases.Referencias_laborales(Int64.Parse(id));
            lblIdReferencia.Text = obj_est.PB_ID_REFERENCIA.ToString();
            lblIdPersonal.Text = obj_est.PB_ID_PERSONAL.ToString();
            txtCargo.Text = obj_est.PV_CARGO.ToString();
            txtCelular.Text = obj_est.PV_CELULAR.ToString();
            txtCorreoElectronico.Text = obj_est.PV_EMAIL.ToString();
            txtEmpresa.Text = obj_est.PV_EMPRESA.ToString();
            txtRelacionLaboral.Text = obj_est.PV_RELACION_LABORAL.ToString();
            txtTelefono.Text= obj_est.PV_TELEFONO.ToString();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                clases.Referencias_laborales obj_er = new clases.Referencias_laborales("D", Int64.Parse(id), Int64.Parse(lblIdPersonal.Text), "",
                        "", "", "", "", "",
                       lblUsuario.Text);
                lblAviso.Text = obj_er.ABM();
                limpiar_datos();
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_ref_lab_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }
            

        }
    }
}