using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class registrate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarRegistro_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            string link = "http://ihuman.data-fidelis.com:5553/login.aspx";
            clases.registro reg = new clases.registro("R",txtNombre.Text,txtPaterno.Text,txtMaterno.Text,ddlTipoDocumento.SelectedValue,
                txtNumeroDocumento.Text,"",txtEmail.Text,"","","");
            string resultado=reg.ABM();
            string[] datos = resultado.Split('|');
            if (datos[1] != "")
            {
                clases.enviar_correo objC = new clases.enviar_correo();
                string resultado2 = objC.enviar(txtEmail.Text, "Registro de usuario", "Estimado su usuario es: " + datos[0] + " y su password es el siguiente: " + datos[1] + " ahora debe ingresar al sistema del siguiente link: " + link, "");
                lblAviso.Text = "Le enviamos un correo con su usuario y password para ingresar, muchas gracias!!!!";
                Response.Redirect("login.aspx?tipo=R");
            }
            else
                lblAviso.Text = datos[3];
        }

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}