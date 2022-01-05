using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblAviso.Text = "Bienvenido por favor introduza sus credenciales.";
                if (Request.QueryString["tipo"] == "T")
                    lblAviso.Text = "Su password se cambio correctamente, puede ingresar con su nuevo password.";
                if (Request.QueryString["tipo"] == "R")
                    lblAviso.Text = "Su usuario se registro correctamente, revise su correo para ingresar su usario y password temporal.";
                    
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            clases.registro reg = new clases.registro("I", "", "", "", "", "", "", "", txtEmail.Text, txtPassword.Text, "");
            string resultado = reg.ABM();
            string[] datos = resultado.Split('|');
            Session["usuario"] = txtEmail.Text;
            if (datos[2] == "2")
                Response.Redirect("cambiar_password.aspx?tipo=T");
            if (datos[2] == "0")
            {
                Session["usuario"] = txtEmail.Text;
                Response.Redirect("kardex.aspx");
            }
               
            lblAviso.Text = datos[3];
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string link = "http://ihuman.data-fidelis.com:5553/login.aspx";
            clases.registro reg = new clases.registro("S", "", "", "", "",
               "", "", "", txtEmail.Text, "", "");
            string resultado = reg.ABM();
            string[] datos = resultado.Split('|');
            if (datos[1] != "")
            {
                clases.enviar_correo objC = new clases.enviar_correo();
                string resultado2 = objC.enviar(txtEmail.Text, "Registro de usuario", "Estimado usuario " + datos[0] + "<br/><br/> Su password temporal es el siguiente: <br/><br/>" + datos[1] + " <br/><br/> Ahora debe ingresar al sistema del siguiente link: <br/><br/>" +  link + "<br/><br/>Saludos coordiales.", "");
                lblAviso.Text = datos[3] + ". Te enviamos un correo con tu password temporal para ingresar, muchas gracias!!!!";
                //Response.Redirect("login.aspx?tipo=R");
            }
            else
                lblAviso.Text = datos[3];
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrate.aspx");
        }
    }
}