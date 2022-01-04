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
    public partial class formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargar_calendarios();
               
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");

                }
                else
                {
                    lblAviso.Text = "";
                    lblUsuario.Text = Session["usuario"].ToString();
                    DataTable dt= clases.Personal.Lista(lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (String.IsNullOrEmpty(dr["PER_ID_PERSONAL"].ToString())) { lblIdPersonal.Text = ""; } else { lblIdPersonal.Text = dr["PER_ID_PERSONAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr["CORREO_ELECTRONICO"].ToString())) { txtEmail.Text = ""; } else { txtEmail.Text = dr["CORREO_ELECTRONICO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_NOMBRE"].ToString())) { txtNombres.Text = ""; } else { txtNombres.Text = dr["PER_NOMBRE"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_APELLIDO_PATERNO"].ToString())) { txtPrimerApellido.Text = ""; } else { txtPrimerApellido.Text = dr["PER_APELLIDO_PATERNO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_APELLIDO_MATERNO"].ToString())) { txtSegundoApellido.Text = ""; } else { txtSegundoApellido.Text = dr["PER_APELLIDO_MATERNO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_APELLIDO_MARITAL"].ToString())) { txtApellidoCasada.Text = ""; } else { txtApellidoCasada.Text = dr["PER_APELLIDO_MARITAL"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_NUMERO_DOCUMENTO"].ToString())) { txtNumeroDocumento.Text = ""; } else { txtNumeroDocumento.Text = dr["PER_NUMERO_DOCUMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_TIPO_DOCUMENTO"].ToString())) { ddlTipoDocumento.DataBind(); } else { ddlTipoDocumento.SelectedValue = dr["PER_TIPO_DOCUMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_COMPLEMENTO"].ToString())) { txtComplemento.Text = ""; } else { txtComplemento.Text = dr["PER_COMPLEMENTO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_EXPEDIDO"].ToString())) { ddlExpedido.DataBind(); } else { ddlExpedido.SelectedValue = dr["PER_EXPEDIDO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_ESTADO_CIVIL"].ToString())) { ddlEsdatoCivil.DataBind(); } else { ddlEsdatoCivil.SelectedValue = dr["PER_ESTADO_CIVIL"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_GENERO"].ToString())) { ddlGenero.DataBind(); } else { ddlGenero.SelectedValue = dr["PER_GENERO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_FECHA_NACIMIENTO"].ToString())) { cargar_calendarios(); }
                            else
                            {
                                DateTime fecha_aux=DateTime.Parse(dr["PER_FECHA_NACIMIENTO"].ToString());
                                ddlNacDia.SelectedValue = fecha_aux.Day.ToString();
                                ddlNacMes.SelectedValue = fecha_aux.Month.ToString();
                                ddlNacAño.SelectedValue = fecha_aux.Year.ToString();

                            }
                            if (String.IsNullOrEmpty(dr["TELEFONO_FIJO"].ToString())) { txtTelefono.Text = ""; } else { txtTelefono.Text = dr["TELEFONO_FIJO"].ToString(); }
                            if (String.IsNullOrEmpty(dr["TELEFONO_CELULAR"].ToString())) { txtCelular.Text = ""; } else { txtCelular.Text = dr["TELEFONO_CELULAR"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PAI_ID_PAIS"].ToString())) 
                            { ddlPaisRes.DataBind(); } 
                            else 
                            {
                                ddlPaisRes.DataBind();
                                ListItem valor = new ListItem();
                                valor.Text= dr["DESC_PAIS"].ToString();
                                valor.Value = dr["PAI_ID_PAIS"].ToString();
                                int indice= ddlPaisRes.Items.IndexOf(valor);
                                ddlPaisRes.SelectedIndex = indice;
                                ddlDepartaentoRes.DataBind();
                            }
                            if (String.IsNullOrEmpty(dr["CIU_ID_CIUDAD"].ToString())) { ddlDepartaentoRes.DataBind(); } 
                            else 
                            {
                                ddlDepartaentoRes.SelectedValue = dr["CIU_ID_CIUDAD"].ToString();
                            }
                            if (String.IsNullOrEmpty(dr["DIR_CIUDAD_RESIDENCIA"].ToString())) { txtCiudadRes.Text = ""; } else { txtCiudadRes.Text = dr["DIR_CIUDAD_RESIDENCIA"].ToString(); }
                            if (String.IsNullOrEmpty(dr["DIR_DIRECCION"].ToString())) { txtDireccion.Text = ""; } else { txtDireccion.Text = dr["DIR_DIRECCION"].ToString(); }
                            if (String.IsNullOrEmpty(dr["PER_FOTO"].ToString())) { imgFoto.ImageUrl = "~/Fotos/sin_imagen.png"; }
                            else
                            {   
                                byte[] foto_aux= (byte[])dr["PER_FOTO"];

                                string imageBase64 = Convert.ToBase64String(foto_aux);
                                string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                                imgFoto.ImageUrl = imageSrc;
                            }
                        }
                    }
                }
            }
           
        }
        public void cargar_calendarios()
        {
            ddlNacDia.Items.Clear();
            ddlNacMes.Items.Clear();
            ddlNacAño.Items.Clear();


            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlNacDia.Items.Add(dia);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                if (m == 1)
                {
                    mes.Text = "ENERO";
                    mes.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes.Text = "FEBRERO";
                    mes.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes.Text = "MARZO";
                    mes.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes.Text = "ABRIL";
                    mes.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes.Text = "MAYO";
                    mes.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes.Text = "JUNIO";
                    mes.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes.Text = "JULIO";
                    mes.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes.Text = "AGOSTO";
                    mes.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes.Text = "SEPTIEMBRE";
                    mes.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes.Text = "OCTUBRE";
                    mes.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes.Text = "NOVIEMBRE";
                    mes.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes.Text = "DICIEMBRE";
                    mes.Value = m.ToString();
                }

                //ddlGarMes.Items.Add(mes);
                ddlNacMes.Items.Add(mes);
            }
            int a = 1900;
            for (a = 1900; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlNacAño.Items.Add(anio);
            }
            ddlNacDia.Items.Insert(0, "DIA");
            ddlNacMes.Items.Insert(0, "MES");
            ddlNacAño.Items.Insert(0, "AÑO");


        }
        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {

            ddlTipoDocumento.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlExpedido_DataBound(object sender, EventArgs e)
        {
            ddlExpedido.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlEsdatoCivil_DataBound(object sender, EventArgs e)
        {
            ddlEsdatoCivil.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlGenero_DataBound(object sender, EventArgs e)
        {
            ddlGenero.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlPaisRes_DataBound(object sender, EventArgs e)
        {
            ddlPaisRes.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlDepartaentoRes_DataBound(object sender, EventArgs e)
        {
            ddlDepartaentoRes.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlPaisRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDepartaentoRes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string s;
                string fecha = "";
                byte[] data = null;

                if (fuFoto.HasFile)
                {
                    string Ruta = Server.MapPath("~/Fotos/" + lblIdPersonal.Text + "/");
                    if (!Directory.Exists(Ruta))
                    {
                        Directory.CreateDirectory(Ruta);
                    }
                    string archivo = lblIdPersonal.Text + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fuFoto.FileName;
                    fuFoto.PostedFile.SaveAs(Ruta + archivo);
                    WebClient webClient = new WebClient();
                    string dominio_app = System.Configuration.ConfigurationManager.AppSettings["dominio"].ToString() + "/Fotos/" + lblIdPersonal.Text + "/";
                    data = webClient.DownloadData(dominio_app + archivo);
                }
                s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (s.ToUpper() == "DD/MM/YYYY")
                { fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                if (s.ToUpper() == "MM/DD/YYYY")
                { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }
                if (s.ToUpper() == "M/D/YYYY")
                { fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue; }

                s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (s.ToUpper() == "DD/MM/YYYY")
                {
                    if (IsDate(ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue) == true)
                    {
                        fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue;
                        lblFecha.Text = "";
                    }
                    else
                        lblFecha.Text = "La fecha es incorrecta";
                }
                if (s.ToUpper() == "D/M/YYYY")
                {
                    if (IsDate(ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue) == true)
                    {
                        fecha = ddlNacDia.SelectedValue + "/" + ddlNacMes.SelectedValue + "/" + ddlNacAño.SelectedValue;
                        lblFecha.Text = "";
                    }
                    else
                        lblFecha.Text = "La fecha es incorrecta";
                }
                if (s.ToUpper() == "MM/DD/YYYY")
                {
                    if (IsDate(ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue) == true)
                    {
                        fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue;
                        lblFecha.Text = "";
                    }
                    else
                        lblFecha.Text = "La fecha es incorrecta";

                    
                }
                if (s.ToUpper() == "M/D/YYYY")
                {
                    if (IsDate(ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue) == true)
                    {
                        fecha = ddlNacMes.SelectedValue + "/" + ddlNacDia.SelectedValue + "/" + ddlNacAño.SelectedValue;
                        lblFecha.Text = "";
                    }
                    else
                        lblFecha.Text = "La fecha es incorrecta";
                }
                if (lblFecha.Text == "")
                {
                    clases.Personal obj = new clases.Personal("I", Int64.Parse(lblIdPersonal.Text), txtNombres.Text, txtPrimerApellido.Text,
                       txtSegundoApellido.Text, txtApellidoCasada.Text, ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text,
                       txtComplemento.Text, ddlExpedido.SelectedValue, ddlGenero.SelectedValue, ddlEsdatoCivil.SelectedValue,
                       DateTime.Parse(fecha), Int64.Parse(ddlPaisRes.SelectedValue), Int64.Parse(ddlDepartaentoRes.SelectedValue), txtCiudadRes.Text, txtDireccion.Text,
                       txtEmail.Text, txtTelefono.Text, txtCelular.Text, lblUsuario.Text, data);
                    string[] resultado = obj.ABM().Split('|');
                    lblAviso.Text = resultado[3];
                }
                /////////////CARGA LOS DATOS DEL PERFIL NUEVAMENTE////////////
                lblUsuario.Text = Session["usuario"].ToString();
                DataTable dt = clases.Personal.Lista(lblUsuario.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (String.IsNullOrEmpty(dr["PER_ID_PERSONAL"].ToString())) { lblIdPersonal.Text = ""; } else { lblIdPersonal.Text = dr["PER_ID_PERSONAL"].ToString(); }
                        if (String.IsNullOrEmpty(dr["CORREO_ELECTRONICO"].ToString())) { txtEmail.Text = ""; } else { txtEmail.Text = dr["CORREO_ELECTRONICO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_NOMBRE"].ToString())) { txtNombres.Text = ""; } else { txtNombres.Text = dr["PER_NOMBRE"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_APELLIDO_PATERNO"].ToString())) { txtPrimerApellido.Text = ""; } else { txtPrimerApellido.Text = dr["PER_APELLIDO_PATERNO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_APELLIDO_MATERNO"].ToString())) { txtSegundoApellido.Text = ""; } else { txtSegundoApellido.Text = dr["PER_APELLIDO_MATERNO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_APELLIDO_MARITAL"].ToString())) { txtApellidoCasada.Text = ""; } else { txtApellidoCasada.Text = dr["PER_APELLIDO_MARITAL"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_NUMERO_DOCUMENTO"].ToString())) { txtNumeroDocumento.Text = ""; } else { txtNumeroDocumento.Text = dr["PER_NUMERO_DOCUMENTO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_TIPO_DOCUMENTO"].ToString())) { ddlTipoDocumento.DataBind(); } else { ddlTipoDocumento.SelectedValue = dr["PER_TIPO_DOCUMENTO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_COMPLEMENTO"].ToString())) { txtComplemento.Text = ""; } else { txtComplemento.Text = dr["PER_COMPLEMENTO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_EXPEDIDO"].ToString())) { ddlExpedido.DataBind(); } else { ddlExpedido.SelectedValue = dr["PER_EXPEDIDO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_ESTADO_CIVIL"].ToString())) { ddlEsdatoCivil.DataBind(); } else { ddlEsdatoCivil.SelectedValue = dr["PER_ESTADO_CIVIL"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_GENERO"].ToString())) { ddlGenero.DataBind(); } else { ddlGenero.SelectedValue = dr["PER_GENERO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_FECHA_NACIMIENTO"].ToString())) { cargar_calendarios(); }
                        else
                        {
                            DateTime fecha_aux = DateTime.Parse(dr["PER_FECHA_NACIMIENTO"].ToString());
                            ddlNacDia.SelectedValue = fecha_aux.Day.ToString();
                            ddlNacMes.SelectedValue = fecha_aux.Month.ToString();
                            ddlNacAño.SelectedValue = fecha_aux.Year.ToString();

                        }
                        if (String.IsNullOrEmpty(dr["TELEFONO_FIJO"].ToString())) { txtTelefono.Text = ""; } else { txtTelefono.Text = dr["TELEFONO_FIJO"].ToString(); }
                        if (String.IsNullOrEmpty(dr["TELEFONO_CELULAR"].ToString())) { txtCelular.Text = ""; } else { txtCelular.Text = dr["TELEFONO_CELULAR"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PAI_ID_PAIS"].ToString()))
                        { ddlPaisRes.DataBind(); }
                        else
                        {
                            ddlPaisRes.DataBind();
                            ListItem valor = new ListItem();
                            valor.Text = dr["DESC_PAIS"].ToString();
                            valor.Value = dr["PAI_ID_PAIS"].ToString();
                            int indice = ddlPaisRes.Items.IndexOf(valor);
                            ddlPaisRes.SelectedIndex = indice;
                            ddlDepartaentoRes.DataBind();
                        }
                        if (String.IsNullOrEmpty(dr["CIU_ID_CIUDAD"].ToString())) { ddlDepartaentoRes.DataBind(); }
                        else
                        {
                            ddlDepartaentoRes.SelectedValue = dr["CIU_ID_CIUDAD"].ToString();
                        }
                        if (String.IsNullOrEmpty(dr["DIR_CIUDAD_RESIDENCIA"].ToString())) { txtCiudadRes.Text = ""; } else { txtCiudadRes.Text = dr["DIR_CIUDAD_RESIDENCIA"].ToString(); }
                        if (String.IsNullOrEmpty(dr["DIR_DIRECCION"].ToString())) { txtDireccion.Text = ""; } else { txtDireccion.Text = dr["DIR_DIRECCION"].ToString(); }
                        if (String.IsNullOrEmpty(dr["PER_FOTO"].ToString())) { imgFoto.ImageUrl = "~/Fotos/sin_imagen.png"; }
                        else
                        {
                            byte[] foto_aux = (byte[])dr["PER_FOTO"];

                            string imageBase64 = Convert.ToBase64String(foto_aux);
                            string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                            imgFoto.ImageUrl = imageSrc;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_formulario_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
            


        }
        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }

            return bValid;
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
    }
}