using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class Convocatorias : System.Web.UI.Page
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
                    lblAviso.Text = "";
                    lblUsuario.Text = Session["usuario"].ToString();
                    DataTable dt = clases.Personal.Lista(lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lblIdPersonal.Text = dr["PER_ID_PERSONAL"].ToString();

                        }
                    }
                }

            }
        }

        protected void lbtnVer_Click(object sender, EventArgs e)
        {

            string id = "";
            LinkButton obj = (LinkButton)sender;
            id = obj.CommandArgument.ToString();
            Session["COD_CONVOCATORIA"] = id;
            Session["ID_PERSONAL"] = lblIdPersonal.Text;
            Response.Redirect("conv_vista.aspx");
        }
    }
}