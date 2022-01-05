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
    public partial class Datos_fam : System.Web.UI.Page
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
        protected void btnAdicionarFam_Click(object sender, EventArgs e)
        {
            limpiar_datos();
            MultiView1.ActiveViewIndex = 1;
        }

     
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar_datos();
        }

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ddlExpedido.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void dllTipoParectesco_DataBound(object sender, EventArgs e)
        {
            dllTipoParectesco.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            { //lblAviso.Text = "Ejecuta igual";
                limpiar_datos();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                clases.Datos_familiares obj_df = new clases.Datos_familiares(Int64.Parse(id));
                lblIdDatosFam.Text = obj_df.PB_ID_DATO_FAMILIAR.ToString();
                txtApellidoMaterno.Text = obj_df.PV_APELIIDO_PRIMERO.ToString();
                txtApellidoPaterno.Text = obj_df.PV_APELIIDO_SEGUNDO.ToString();
                txtComplemento.Text = obj_df.PV_COMPLEMENTO.ToString();
                txtNombres.Text = obj_df.PV_NOMBRE.ToString();
                txtNumeroDocumento.Text = obj_df.PV_NUMERO_DOCUMENTO.ToString();
                ddlExpedido.SelectedValue = obj_df.PV_EXPEDIDO.ToString();
                ddlTipoDocumento.SelectedValue = obj_df.PV_TIPO_DOCUMENTO.ToString();
                dllTipoParectesco.SelectedValue = obj_df.PV_TIPO_PARENTESCO.ToString();

                clases.Datos_familiares obj_df2 = new clases.Datos_familiares("D", Int64.Parse(lblIdDatosFam.Text), Int64.Parse(lblIdPersonal.Text), dllTipoParectesco.SelectedValue, txtNombres.Text,
                      txtApellidoPaterno.Text, txtApellidoMaterno.Text, ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, txtComplemento.Text, ddlExpedido.SelectedValue,
                      lblUsuario.Text);
                lblAviso.Text = obj_df2.ABM();
                Repeater1.DataBind();
                MultiView1.ActiveViewIndex = 0;
                limpiar_datos();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_datos_fam_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }
            
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar_datos();
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (lblIdDatosFam.Text == "")
                {
                    clases.Datos_familiares obj = new clases.Datos_familiares("I", 0, Int64.Parse(lblIdPersonal.Text), dllTipoParectesco.SelectedValue, txtNombres.Text,
                       txtApellidoPaterno.Text, txtApellidoMaterno.Text, ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, txtComplemento.Text, ddlExpedido.SelectedValue,
                       lblUsuario.Text);
                    lblAviso.Text = obj.ABM();
                }
                else
                {
                    clases.Datos_familiares obj = new clases.Datos_familiares("U", Int64.Parse(lblIdDatosFam.Text), Int64.Parse(lblIdPersonal.Text), dllTipoParectesco.SelectedValue, txtNombres.Text,
                       txtApellidoPaterno.Text, txtApellidoMaterno.Text, ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, txtComplemento.Text, ddlExpedido.SelectedValue,
                       lblUsuario.Text);
                    lblAviso.Text = obj.ABM();
                }

                Repeater1.DataBind();
                MultiView1.ActiveViewIndex = 0;
                limpiar_datos();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_datos_fam_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }
            

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
            clases.Datos_familiares obj_df = new clases.Datos_familiares(Int64.Parse(id));
            lblIdDatosFam.Text = obj_df.PB_ID_DATO_FAMILIAR.ToString();
            txtApellidoMaterno.Text = obj_df.PV_APELIIDO_PRIMERO.ToString();
            txtApellidoPaterno.Text = obj_df.PV_APELIIDO_SEGUNDO.ToString();
            txtComplemento.Text = obj_df.PV_COMPLEMENTO.ToString();
            txtNombres.Text = obj_df.PV_NOMBRE.ToString();
            txtNumeroDocumento.Text = obj_df.PV_NUMERO_DOCUMENTO.ToString();
            ddlExpedido.SelectedValue = obj_df.PV_EXPEDIDO.ToString();
            ddlTipoDocumento.SelectedValue = obj_df.PV_TIPO_DOCUMENTO.ToString();
            dllTipoParectesco.SelectedValue = obj_df.PV_TIPO_PARENTESCO.ToString();
            MultiView1.ActiveViewIndex = 1;
        }

        public void limpiar_datos()
        {
            lblIdDatosFam.Text = "";
            lblAviso.Text = "";
            txtApellidoMaterno.Text = "";
            txtApellidoPaterno.Text = "";
            txtComplemento.Text = "";
            txtNombres.Text = "";
            txtNumeroDocumento.Text = "";
            ddlExpedido.DataBind();
            ddlTipoDocumento.DataBind();
            dllTipoParectesco.DataBind();
        }
    }
}