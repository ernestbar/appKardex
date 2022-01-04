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
    public partial class descargas : System.Web.UI.Page
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
                    lblUsuario.Text = Session["usuario"].ToString();
                    DataTable dt = clases.dominios.Lista("TUTORIAL");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["dom_codigo"].ToString() == "PDF")
                            {

                                if (dr["dom_descripcion"].ToString() == "")
                                    lbtnPDF.Visible = false;
                                else
                                {
                                    lbtnPDF.Visible = true;
                                    lbtnPDF.CommandArgument = dr["dom_descripcion"].ToString();
                                }
                            }

                            if (dr["dom_codigo"].ToString() == "MP4")
                            {

                                if (dr["dom_descripcion"].ToString() == "")
                                    lbtnVideo.Visible = false;
                                else
                                {
                                    lbtnVideo.Visible = true;
                                    lbtnVideo.CommandArgument = dr["dom_descripcion"].ToString();
                                }
                                   
                            }
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
                            //if (String.IsNullOrEmpty(dr["CIU_ID_CIUDAD"].ToString())) 
                            //{ ddlDepartaentoRes.DataBind(); }
                            //else
                            //{
                            //    ddlDepartaentoRes.SelectedValue = dr["CIU_ID_CIUDAD"].ToString();
                            //}
                            //if (String.IsNullOrEmpty(dr["DIR_CIUDAD_RESIDENCIA"].ToString())) { txtCiudadRes.Text = ""; } else { txtCiudadRes.Text = dr["DIR_CIUDAD_RESIDENCIA"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["DIR_DIRECCION"].ToString())) { txtDireccion.Text = ""; } else { txtDireccion.Text = dr["DIR_DIRECCION"].ToString(); }
                            //if (String.IsNullOrEmpty(dr["PER_FOTO"].ToString())) { imgFoto.ImageUrl = "~/Fotos/sin_imagen.png"; }
                            //else
                            //{
                            //    byte[] foto_aux = (byte[])dr["PER_FOTO"];

                            //    string imageBase64 = Convert.ToBase64String(foto_aux);
                            //    string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                            //    imgFoto.ImageUrl = imageSrc;
                            //}
                        }
                    }
                }
            }
        }

        protected void lbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
               
                string id = "";
                LinkButton obj = (LinkButton)sender;
                id = obj.CommandArgument.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", id));
                //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl(id)));

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_descargas_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
               // lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void lbtnVideo_Click(object sender, EventArgs e)
        {
            try
            {

                string id = "";
                LinkButton obj = (LinkButton)sender;
                id = obj.CommandArgument.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", id));
                //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl(id)));

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_descargas_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                // lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }
    }
}