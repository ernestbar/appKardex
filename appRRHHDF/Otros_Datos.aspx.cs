using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class Otros_Datos : System.Web.UI.Page
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

        public void limpiarDatos()
        {
            dllTipoDocumento.DataBind();
            txtDescripcion.Text="";
            fuDocumento.Dispose();
            lblAviso.Text = "";
            lblIdOtrosDatos.Text = "";
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                string archivo = lblIdPersonal.Text + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuDocumento.FileName;

                MultiView1.ActiveViewIndex = 0;
                if (lblIdOtrosDatos.Text == "")
                {
                    clases.Otros_documentos obj_er = new clases.Otros_documentos("I", 0, Int64.Parse(lblIdPersonal.Text), dllTipoDocumento.SelectedValue,
                       txtDescripcion.Text, archivo,
                       lblUsuario.Text);
                    lblAviso.Text = obj_er.ABM();
                    string Ruta = Server.MapPath("~/Documentos/" + lblIdPersonal.Text + "/");
                    if (!Directory.Exists(Ruta))
                    {
                        Directory.CreateDirectory(Ruta);
                    }
                    //string archivo =lblIdPersonal.Text+DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuDocumento.FileName;
                    fuDocumento.PostedFile.SaveAs(Ruta + archivo);
                }
                else
                {
                    clases.Otros_documentos obj_er = new clases.Otros_documentos("U", Int64.Parse(lblIdOtrosDatos.Text), Int64.Parse(lblIdPersonal.Text), dllTipoDocumento.SelectedValue,
                       txtDescripcion.Text, archivo,
                       lblUsuario.Text);
                    lblAviso.Text = obj_er.ABM();
                    string Ruta = Server.MapPath("~/Documentos/" + lblIdPersonal.Text + "/");
                    if (!Directory.Exists(Ruta))
                    {
                        Directory.CreateDirectory(Ruta);
                    }
                    //string archivo = lblIdPersonal.Text + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuDocumento.FileName;
                    fuDocumento.PostedFile.SaveAs(Ruta + archivo);
                }


                Repeater1.DataBind();
                limpiarDatos();
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_otros_datos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }

        }

        protected void btnOtrosDatos_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            MultiView1.ActiveViewIndex = 1;
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

        protected void lbtnDatosPersonales_Click(object sender, EventArgs e)
        {
            Session["usuario"] = lblUsuario.Text;
            Response.Redirect("formulario.aspx");
        }

        protected void dllTipoDocumento_DataBound(object sender, EventArgs e)
        {
            dllTipoDocumento.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            clases.Otros_documentos otr = new clases.Otros_documentos(int.Parse(id));
            string pageurl = System.Configuration.ConfigurationManager.AppSettings["dominio"].ToString() + "/Documentos/" + lblIdPersonal.Text + "/" +otr.PV_URL;
            //Response.Redirect(pageurl);
            Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
            string dlDir = "~/Documentos/" + lblIdPersonal.Text + "/";
            string path = Server.MapPath(dlDir + otr.PV_URL);

            //System.IO.FileInfo toDownload =
            //             new System.IO.FileInfo(path);

            //if (toDownload.Exists)
            //{
            //    Response.Clear();
            //    Response.AddHeader("Content - Disposition","attachment; filename =" +toDownload.Name);
            //    Response.AddHeader("Content - Length",toDownload.Length.ToString());
            //    Response.ContentType = "application / octet - stream";
            //    Response.WriteFile(otr.PV_URL);
            //    Response.End();
            //}
            //Response.ContentType = "text/pdf";
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.AppendHeader("NombreCabecera", "MensajeCabecera");
            //Response.TransmitFile(Server.MapPath("~/Documentos/" + lblIdPersonal.Text +"/" + otr.PV_URL));
            //Response.End();

            //string dominio_app = System.Configuration.ConfigurationManager.AppSettings["dominio"].ToString() + "/Documentos/" + lblIdPersonal.Text + "/";
            //string remoteUri = "http://www.contoso.com/library/homepage/images/";
            //string fileName = otr.PV_URL, myStringWebResource = null;

            // Create a new WebClient instance.
            //using (WebClient myWebClient = new WebClient())
            //{
            //    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    string archivo_local= desktopPath+@"\" + fileName;
            //    //myStringWebResource =Server.MapPath( "~/Documentos/"+ lblIdPersonal.Text+"/" + fileName);
            //    myStringWebResource = dominio_app + fileName;
            //    // Download the Web resource and save it into the current filesystem folder.
            //    myWebClient.DownloadFile(myStringWebResource, archivo_local);
            //}
            //string javaScript = "alert('Se decargo su archivo correctamente en su escritorio!');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //String FileName =Server.MapPath("~/Documentos/"+ lblIdPersonal.Text+"/"+ fileName);
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", FileName));
            //Response.ContentType = "application/pdf";
            //StringWriter stringWriter = new StringWriter();
            //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            //Response.Write(stringWriter.ToString());
            //Response.End();

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarDatos();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                clases.Otros_documentos obj_er = new clases.Otros_documentos("D", Int64.Parse(id), Int64.Parse(lblIdPersonal.Text), "",
                       "", "",
                      lblUsuario.Text);
                lblAviso.Text = obj_er.ABM();
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_otros_datos_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }
            
        }
    }
}