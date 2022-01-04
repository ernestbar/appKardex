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
    public partial class Cursos_Talleres : System.Web.UI.Page
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
                    cargar_calendarios();
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
        protected void btnAdicionarCursoTaller_Click(object sender, EventArgs e)
        {
            limpiar_datos();
            MultiView1.ActiveViewIndex = 1;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                DateTime fecha_titulo = DateTime.Parse("01/01/3000");
                string s;

                s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (s.ToUpper() == "DD/MM/YYYY")
                {
                    if (IsDate(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_ini = DateTime.Parse(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha1.Text = "";
                    }
                    else
                        lblFecha1.Text = "La fecha es incorrecta";

                    if (IsDate(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue) == true)
                    {
                        fecha_fin = DateTime.Parse(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue);
                        lblFecha2.Text = "";
                    }
                    else
                        lblFecha2.Text = "La fecha es incorrecta";

                    if (IsDate(ddlTitDia2.SelectedValue + "/" + ddlTitMes2.SelectedValue + "/" + ddlTitAño2.SelectedValue) == true)
                    {
                        fecha_titulo = DateTime.Parse(ddlTitDia2.SelectedValue + "/" + ddlTitMes2.SelectedValue + "/" + ddlTitAño2.SelectedValue);
                        lblFecha3.Text = "";
                    }
                    else
                        lblFecha3.Text = "La fecha es incorrecta";




                }
                if (s.ToUpper() == "D/M/YYYY")
                {
                    if (IsDate(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_ini = DateTime.Parse(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha1.Text = "";
                    }
                    else
                        lblFecha1.Text = "La fecha es incorrecta";

                    if (IsDate(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue) == true)
                    {
                        fecha_fin = DateTime.Parse(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue);
                        lblFecha2.Text = "";
                    }
                    else
                        lblFecha2.Text = "La fecha es incorrecta";

                    if (IsDate(ddlTitDia2.SelectedValue + "/" + ddlTitMes2.SelectedValue + "/" + ddlTitAño2.SelectedValue) == true)
                    {
                        fecha_titulo = DateTime.Parse(ddlTitDia2.SelectedValue + "/" + ddlTitMes2.SelectedValue + "/" + ddlTitAño2.SelectedValue);
                        lblFecha3.Text = "";
                    }
                    else
                        lblFecha3.Text = "La fecha es incorrecta";

                }
                if (s.ToUpper() == "MM/DD/YYYY")
                {
                    if (IsDate(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_ini = DateTime.Parse(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha1.Text = "";
                    }
                    else
                        lblFecha1.Text = "La fecha es incorrecta";

                    if (IsDate(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_fin = DateTime.Parse(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha2.Text = "";
                    }
                    else
                        lblFecha2.Text = "La fecha es incorrecta";

                    if (IsDate(ddlTitMes2.SelectedValue + "/" + ddlTitDia2.SelectedValue + "/" + ddlTitAño2.SelectedValue) == true)
                    {
                        fecha_titulo = DateTime.Parse(ddlTitMes2.SelectedValue + "/" + ddlTitDia2.SelectedValue + "/" + ddlTitAño2.SelectedValue);
                        lblFecha3.Text = "";
                    }
                    else
                        lblFecha3.Text = "La fecha es incorrecta";



                }
                if (s.ToUpper() == "M/D/YYYY")
                {
                    if (IsDate(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_ini = DateTime.Parse(ddlIniMes.SelectedValue + "/" + ddlIniDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha1.Text = "";
                    }
                    else
                        lblFecha1.Text = "La fecha es incorrecta";

                    if (IsDate(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_fin = DateTime.Parse(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha2.Text = "";
                    }
                    else
                        lblFecha2.Text = "La fecha es incorrecta";

                    if (IsDate(ddlTitMes2.SelectedValue + "/" + ddlTitDia2.SelectedValue + "/" + ddlTitAño2.SelectedValue) == true)
                    {
                        fecha_titulo = DateTime.Parse(ddlTitMes2.SelectedValue + "/" + ddlTitDia2.SelectedValue + "/" + ddlTitAño2.SelectedValue);
                        lblFecha3.Text = "";
                    }
                    else
                        lblFecha3.Text = "La fecha es incorrecta";



                }
                if (lblFecha1.Text == "" & lblFecha2.Text == "" & lblFecha3.Text == "")
                {
                    if (lblIdCurso.Text == "")
                    {
                        clases.Cursos_talleres obj_er = new clases.Cursos_talleres("I", 0, Int64.Parse(lblIdPersonal.Text), dllTipoCapacitacion.SelectedValue,
                            txtNombreInstitucion.Text,
                           txtCiudad.Text, fecha_ini, fecha_fin, int.Parse(txtTotalHoras.Text), txtTituloObtenido.Text, fecha_titulo,
                           lblUsuario.Text);
                        lblAviso.Text = obj_er.ABM();
                    }
                    else
                    {
                        clases.Cursos_talleres obj_er = new clases.Cursos_talleres("U", Int64.Parse(lblIdCurso.Text), Int64.Parse(lblIdPersonal.Text), dllTipoCapacitacion.SelectedValue,
                            txtNombreInstitucion.Text,
                           txtCiudad.Text, fecha_ini, fecha_fin, int.Parse(txtTotalHoras.Text), txtTituloObtenido.Text, fecha_titulo,
                           lblUsuario.Text);
                        lblAviso.Text = obj_er.ABM();
                    }


                    Repeater1.DataBind();
                    limpiar_datos();
                    MultiView1.ActiveViewIndex = 0;

                }
                    
            }
            catch (Exception ex)
            {
                string nombre_archivo ="error_cursos_"+ DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString()+ DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()+ DateTime.Now.Second.ToString()+".txt";
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

        public void limpiar_datos()
        {
            lblIdCurso.Text = "";
            lblAviso.Text = "";
            txtCiudad.Text = "";
            txtNombreInstitucion.Text = "";
            dllTipoCapacitacion.DataBind();
            txtTituloObtenido.Text = "";
            txtTotalHoras.Text = "";
            cargar_calendarios();
        }
        public void cargar_calendarios()
        {
            ddlIniDia.Items.Clear();
            ddlIniMes.Items.Clear();
            ddlIniAño.Items.Clear();

            ddlFinDia1.Items.Clear();
            ddlFinMes1.Items.Clear();
            ddlFinAño1.Items.Clear();

            ddlTitDia2.Items.Clear();
            ddlTitMes2.Items.Clear();
            ddlTitAño2.Items.Clear();

            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem();
                dia.Text = d.ToString();
                dia.Value = d.ToString();
                ListItem dia2 = new ListItem();
                dia2.Text = d.ToString();
                dia2.Value = d.ToString();
                ListItem dia3 = new ListItem();
                dia3.Text = d.ToString();
                dia3.Value = d.ToString();
                // ddlGarDia.Items.Add(dia);
                ddlIniDia.Items.Add(dia);
                ddlFinDia1.Items.Add(dia2);
                ddlTitDia2.Items.Add(dia3);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                ListItem mes2 = new ListItem();
                ListItem mes3 = new ListItem();
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

                if (m == 1)
                {
                    mes2.Text = "ENERO";
                    mes2.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes2.Text = "FEBRERO";
                    mes2.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes2.Text = "MARZO";
                    mes2.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes2.Text = "ABRIL";
                    mes2.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes2.Text = "MAYO";
                    mes2.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes2.Text = "JUNIO";
                    mes2.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes2.Text = "JULIO";
                    mes2.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes2.Text = "AGOSTO";
                    mes2.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes2.Text = "SEPTIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes2.Text = "OCTUBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes2.Text = "NOVIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes2.Text = "DICIEMBRE";
                    mes2.Value = m.ToString();
                }
                if (m == 1)
                {
                    mes3.Text = "ENERO";
                    mes3.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes3.Text = "FEBRERO";
                    mes3.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes3.Text = "MARZO";
                    mes3.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes3.Text = "ABRIL";
                    mes3.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes3.Text = "MAYO";
                    mes3.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes3.Text = "JUNIO";
                    mes3.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes3.Text = "JULIO";
                    mes3.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes3.Text = "AGOSTO";
                    mes3.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes3.Text = "SEPTIEMBRE";
                    mes3.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes3.Text = "OCTUBRE";
                    mes3.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes3.Text = "NOVIEMBRE";
                    mes3.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes3.Text = "DICIEMBRE";
                    mes3.Value = m.ToString();
                }
                ddlIniMes.Items.Add(mes);
                ddlFinMes1.Items.Add(mes2);
                ddlTitMes2.Items.Add(mes3);
            }
            int a = 1900;
            for (a = 1900; a <= DateTime.Now.Year; a++)
            {
                ListItem anio = new ListItem();
                anio.Text = a.ToString();
                anio.Value = a.ToString();
                ListItem anio2 = new ListItem();
                anio2.Text = a.ToString();
                anio2.Value = a.ToString();
                ListItem anio3 = new ListItem();
                anio3.Text = a.ToString();
                anio3.Value = a.ToString();
                // ddlGarAño.Items.Add(anio);
                ddlIniAño.Items.Add(anio);
                ddlFinAño1.Items.Add(anio2);
                ddlTitAño2.Items.Add(anio3);
            }
            ddlIniDia.Items.Insert(0, "DIA");
            ddlIniMes.Items.Insert(0, "MES");
            ddlIniAño.Items.Insert(0, "AÑO");

            ddlFinDia1.Items.Insert(0, "DIA");
            ddlFinMes1.Items.Insert(0, "MES");
            ddlFinAño1.Items.Insert(0, "AÑO");

            ddlTitDia2.Items.Insert(0, "DIA");
            ddlTitMes2.Items.Insert(0, "MES");
            ddlTitAño2.Items.Insert(0, "AÑO");


        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            limpiar_datos();
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            clases.Cursos_talleres obj_est = new clases.Cursos_talleres(Int64.Parse(id));
            lblIdCurso.Text = obj_est.PB_ID_CURSO.ToString();
            txtCiudad.Text = obj_est.PV_CIUDAD.ToString();
            txtNombreInstitucion.Text = obj_est.PV_INSTITUCION.ToString();
            txtTituloObtenido.Text = obj_est.PV_TITULO_OBTENIDO.ToString();

            DateTime fecha_ini = obj_est.PD_FECHA_INICIO;
            DateTime fecha_fin = obj_est.PD_FECHA_FIN;
            DateTime fecha_titulo = obj_est.PV_FECHA_TITULO;
            dllTipoCapacitacion.SelectedValue = obj_est.PV_TIPO_CAPACITACION.ToString();
            txtTotalHoras.Text = obj_est.PI_TOTAL_HORAS.ToString();

            ddlIniDia.SelectedValue = fecha_ini.Day.ToString();
            ddlIniMes.SelectedValue = fecha_ini.Month.ToString();
            ddlIniAño.SelectedValue = fecha_ini.Year.ToString();

            ddlFinDia1.SelectedValue = fecha_fin.Day.ToString();
            ddlFinMes1.SelectedValue = fecha_fin.Month.ToString();
            ddlFinAño1.SelectedValue = fecha_fin.Year.ToString();

            ddlTitDia2.SelectedValue = fecha_titulo.Day.ToString();
            ddlTitMes2.SelectedValue = fecha_titulo.Month.ToString();
            ddlTitAño2.SelectedValue = fecha_titulo.Year.ToString();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            limpiar_datos();
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            clases.Cursos_talleres obj_est = new clases.Cursos_talleres(Int64.Parse(id));
            lblIdCurso.Text = obj_est.PB_ID_CURSO.ToString();
            txtCiudad.Text = obj_est.PV_CIUDAD.ToString();
            txtNombreInstitucion.Text = obj_est.PV_INSTITUCION.ToString();
            txtTituloObtenido.Text = obj_est.PV_TITULO_OBTENIDO.ToString();
            txtTotalHoras.Text = obj_est.PI_TOTAL_HORAS.ToString();
            DateTime fecha_ini = obj_est.PD_FECHA_INICIO;
            DateTime fecha_fin = obj_est.PD_FECHA_FIN;
            DateTime fecha_titulo = obj_est.PV_FECHA_TITULO;
            dllTipoCapacitacion.SelectedValue = obj_est.PV_TIPO_CAPACITACION.ToString();

            ddlIniDia.SelectedValue = fecha_ini.Day.ToString();
            ddlIniMes.SelectedValue = fecha_ini.Month.ToString();
            ddlIniAño.SelectedValue = fecha_ini.Year.ToString();

            ddlFinDia1.SelectedValue = fecha_fin.Day.ToString();
            ddlFinMes1.SelectedValue = fecha_fin.Month.ToString();
            ddlFinAño1.SelectedValue = fecha_fin.Year.ToString();

            ddlTitDia2.SelectedValue = fecha_titulo.Day.ToString();
            ddlTitMes2.SelectedValue = fecha_titulo.Month.ToString();
            ddlTitAño2.SelectedValue = fecha_titulo.Year.ToString();

           

            clases.Cursos_talleres obj_er = new clases.Cursos_talleres("D", Int64.Parse(lblIdCurso.Text), Int64.Parse(lblIdPersonal.Text),
                dllTipoCapacitacion.SelectedValue, txtNombreInstitucion.Text,
                  txtCiudad.Text, fecha_ini, fecha_fin, int.Parse(txtTotalHoras.Text), txtTituloObtenido.Text, fecha_titulo,
                  lblUsuario.Text);
            lblAviso.Text = obj_er.ABM();
            Repeater1.DataBind();
            MultiView1.ActiveViewIndex = 0;
            limpiar_datos();
        }

        protected void dllTipoCapacitacion_DataBound(object sender, EventArgs e)
        {
            dllTipoCapacitacion.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }
    }
}