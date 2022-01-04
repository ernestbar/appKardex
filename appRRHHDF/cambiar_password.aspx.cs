using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class cambiar_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (Request.QueryString["tipo"] == "T")
                { 
                    lblAviso.Text = "Su usuario se encuentra con un password temporal, por favor cambielo ahora.";
                    btnRegresar.Visible = false;
                }
                if (Request.QueryString["tipo"] == "C")
                {
                    lblAviso.Text = "Por seguridad haga cambios periodicos de su contraseña.";
                    btnRegresar.Visible = true;
                }
                txtUsuario.Text = Session["usuario"].ToString();
                lblUsuario.Text = Session["usuario"].ToString();
            }
            
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            clases.registro reg = new clases.registro("C", "", "", "", "", "", "", "", txtUsuario.Text, txtPassAnt.Text, txtPassword.Text);
            string resultado = reg.ABM();
            string[] datos = resultado.Split('|');
            if (datos[2] == "0")
                Response.Redirect("login.aspx?tipo=T");
            lblAviso.Text = datos[3];
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("inicio.aspx");
        }
    }
}