using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class Principal : System.Web.UI.MasterPage
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
                    if (Session["usuario"].ToString() == "")
                        Response.Redirect("login.aspx");
                    else
                        lblUsuario.Text = Session["usuario"].ToString();
                    DataTable dt = clases.Personal.Lista(lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (String.IsNullOrEmpty(dr["PER_FOTO"].ToString())) { imgUser.ImageUrl = "~/Fotos/sin_imagen.png"; }
                            else
                            {
                                byte[] foto_aux = (byte[])dr["PER_FOTO"];

                                string imageBase64 = Convert.ToBase64String(foto_aux);
                                string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                                imgUser.ImageUrl = imageSrc;
                            }
                        }
                    }
                }
            }
        }
    }
}