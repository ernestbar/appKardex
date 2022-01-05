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
    public partial class Experiencia_Laboral : System.Web.UI.Page
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
                    lblIdPersonal.Text = Session["id_personal"].ToString();
                    Repeater1.DataBind();
                }

            }
        }
        public void limpiar_datos()
        {
            lblAviso.Text = "";
            lblIdExperiencia.Text = "";
            txtEmpresa.Text = "";
            txtCargoInicio.Text = "";
            txtNroDependientes.Text = "";
            txtFunciones.Text = "";
            txtDepartamento.Text = "";
            txtOtroCargo1.Text = "";
            txtNroDependientesOtro1.Text = "";
            txtFuncionesOtro1.Text = "";
            txtDepartamentoOtro1.Text = "";
            txtOtroCargo2.Text = "";
            txtNroDependientesOtro2.Text = "";
            txtFuncionesOtro2.Text = "";
            txtDepartamentoOtro2.Text = "";
            txtOtroCargo3.Text = "";
            txtNroDependientesOtro3.Text = "";
            txtFuncionesOtro3.Text = "";
            txtDepartamentoOtro3.Text = "";
            txtDesvinculacionOtro.Text = "";
            ckbCargoActual.Checked = false;
            ddlMotivoDesvinculacion.DataBind();
            //txtTotalExperiencia.Text = "";
            cargar_calendarios();
        }
        protected void btnAdicionarExperienciaLaboral_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
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
        protected void ddlMotivoDesvinculacion_DataBound(object sender, EventArgs e)
        {
            ddlMotivoDesvinculacion.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }
        public void cargar_calendarios()
        {
            ddlIniDia.Items.Clear();
            ddlIniMes.Items.Clear();
            ddlIniAño.Items.Clear();
            ddlFinDia.Items.Clear();
            ddlFinMes.Items.Clear();
            ddlFinAño.Items.Clear();

            ddlIniDia1.Items.Clear();
            ddlIniMes1.Items.Clear();
            ddlIniAño1.Items.Clear();
            ddlFinDia1.Items.Clear();
            ddlFinMes1.Items.Clear();
            ddlFinAño1.Items.Clear();

            ddlIniDia2.Items.Clear();
            ddlIniMes2.Items.Clear();
            ddlIniAño2.Items.Clear();
            ddlFinDia2.Items.Clear();
            ddlFinMes2.Items.Clear();
            ddlFinAño2.Items.Clear();

            ddlIniDia3.Items.Clear();
            ddlIniMes3.Items.Clear();
            ddlIniAño3.Items.Clear();
            ddlFinDia3.Items.Clear();
            ddlFinMes3.Items.Clear();
            ddlFinAño3.Items.Clear();
            int d = 1;
            for (d = 1; d <= 31; d++)
            {
                ListItem dia = new ListItem(); //fecha inicio cargo
                dia.Text = d.ToString();
                dia.Value = d.ToString();
                ListItem dia2 = new ListItem(); //fecha fin cargo
                dia2.Text = d.ToString();
                dia2.Value = d.ToString();
                ListItem dia3 = new ListItem(); //fecha inicio cargo otro1
                dia3.Text = d.ToString();
                dia3.Value = d.ToString();
                ListItem dia4 = new ListItem(); //fecha fin cargo otro1
                dia4.Text = d.ToString();
                dia4.Value = d.ToString();
                ListItem dia5 = new ListItem(); //fecha inicio cargo otro2
                dia5.Text = d.ToString();
                dia5.Value = d.ToString();
                ListItem dia6 = new ListItem(); //fecha fin cargo otro2
                dia6.Text = d.ToString();
                dia6.Value = d.ToString();
                ListItem dia7 = new ListItem(); //fecha inicio cargo otro3
                dia7.Text = d.ToString();
                dia7.Value = d.ToString();
                ListItem dia8 = new ListItem(); //fecha fin cargo otro3
                dia8.Text = d.ToString();
                dia8.Value = d.ToString();

                ddlIniDia.Items.Add(dia);
                ddlFinDia.Items.Add(dia2);
                ddlIniDia1.Items.Add(dia3);
                ddlFinDia1.Items.Add(dia4);
                ddlIniDia2.Items.Add(dia5);
                ddlFinDia2.Items.Add(dia6);
                ddlIniDia3.Items.Add(dia7);
                ddlFinDia3.Items.Add(dia8);
            }
            int m = 1;
            for (m = 1; m <= 12; m++)
            {
                ListItem mes = new ListItem();
                ListItem mes2 = new ListItem();
                ListItem mes3 = new ListItem();
                ListItem mes4 = new ListItem();
                ListItem mes5 = new ListItem();
                ListItem mes6 = new ListItem();
                ListItem mes7 = new ListItem();
                ListItem mes8 = new ListItem();
                if (m == 1)
                {
                    mes.Text = "ENERO";
                    mes.Value = m.ToString();
                    mes2.Text = "ENERO";
                    mes2.Value = m.ToString();
                    mes3.Text = "ENERO";
                    mes3.Value = m.ToString();
                    mes4.Text = "ENERO";
                    mes4.Value = m.ToString();
                    mes5.Text = "ENERO";
                    mes5.Value = m.ToString();
                    mes6.Text = "ENERO";
                    mes6.Value = m.ToString();
                    mes7.Text = "ENERO";
                    mes7.Value = m.ToString();
                    mes8.Text = "ENERO";
                    mes8.Value = m.ToString();
                }
                if (m == 2)
                {
                    mes.Text = "FEBRERO";
                    mes.Value = m.ToString();
                    mes2.Text = "FEBRERO";
                    mes2.Value = m.ToString();
                    mes3.Text = "FEBRERO";
                    mes3.Value = m.ToString();
                    mes4.Text = "FEBRERO";
                    mes4.Value = m.ToString();
                    mes5.Text = "FEBRERO";
                    mes5.Value = m.ToString();
                    mes6.Text = "FEBRERO";
                    mes6.Value = m.ToString();
                    mes7.Text = "FEBRERO";
                    mes7.Value = m.ToString();
                    mes8.Text = "FEBRERO";
                    mes8.Value = m.ToString();
                }
                if (m == 3)
                {
                    mes.Text = "MARZO";
                    mes.Value = m.ToString();
                    mes2.Text = "MARZO";
                    mes2.Value = m.ToString();
                    mes3.Text = "MARZO";
                    mes3.Value = m.ToString();
                    mes4.Text = "MARZO";
                    mes4.Value = m.ToString();
                    mes5.Text = "MARZO";
                    mes5.Value = m.ToString();
                    mes6.Text = "MARZO";
                    mes6.Value = m.ToString();
                    mes7.Text = "MARZO";
                    mes7.Value = m.ToString();
                    mes8.Text = "MARZO";
                    mes8.Value = m.ToString();
                }
                if (m == 4)
                {
                    mes.Text = "ABRIL";
                    mes.Value = m.ToString();
                    mes2.Text = "ABRIL";
                    mes2.Value = m.ToString();
                    mes3.Text = "ABRIL";
                    mes3.Value = m.ToString();
                    mes4.Text = "ABRIL";
                    mes4.Value = m.ToString();
                    mes5.Text = "ABRIL";
                    mes5.Value = m.ToString();
                    mes6.Text = "ABRIL";
                    mes6.Value = m.ToString();
                    mes7.Text = "ABRIL";
                    mes7.Value = m.ToString();
                    mes8.Text = "ABRIL";
                    mes8.Value = m.ToString();
                }
                if (m == 5)
                {
                    mes.Text = "MAYO";
                    mes.Value = m.ToString();
                    mes2.Text = "MAYO";
                    mes2.Value = m.ToString();
                    mes3.Text = "MAYO";
                    mes3.Value = m.ToString();
                    mes4.Text = "MAYO";
                    mes4.Value = m.ToString();
                    mes5.Text = "MAYO";
                    mes5.Value = m.ToString();
                    mes6.Text = "MAYO";
                    mes6.Value = m.ToString();
                    mes7.Text = "MAYO";
                    mes7.Value = m.ToString();
                    mes8.Text = "MAYO";
                    mes8.Value = m.ToString();
                }
                if (m == 6)
                {
                    mes.Text = "JUNIO";
                    mes.Value = m.ToString();
                    mes2.Text = "JUNIO";
                    mes2.Value = m.ToString();
                    mes3.Text = "JUNIO";
                    mes3.Value = m.ToString();
                    mes4.Text = "JUNIO";
                    mes4.Value = m.ToString();
                    mes5.Text = "JUNIO";
                    mes5.Value = m.ToString();
                    mes6.Text = "JUNIO";
                    mes6.Value = m.ToString();
                    mes7.Text = "JUNIO";
                    mes7.Value = m.ToString();
                    mes8.Text = "JUNIO";
                    mes8.Value = m.ToString();
                }
                if (m == 7)
                {
                    mes.Text = "JULIO";
                    mes.Value = m.ToString();
                    mes2.Text = "JULIO";
                    mes2.Value = m.ToString();
                    mes3.Text = "JULIO";
                    mes3.Value = m.ToString();
                    mes4.Text = "JULIO";
                    mes4.Value = m.ToString();
                    mes5.Text = "JULIO";
                    mes5.Value = m.ToString();
                    mes6.Text = "JULIO";
                    mes6.Value = m.ToString();
                    mes7.Text = "JULIO";
                    mes7.Value = m.ToString();
                    mes8.Text = "JULIO";
                    mes8.Value = m.ToString();
                }
                if (m == 8)
                {
                    mes.Text = "AGOSTO";
                    mes.Value = m.ToString();
                    mes2.Text = "AGOSTO";
                    mes2.Value = m.ToString();
                    mes3.Text = "AGOSTO";
                    mes3.Value = m.ToString();
                    mes4.Text = "AGOSTO";
                    mes4.Value = m.ToString();
                    mes5.Text = "AGOSTO";
                    mes5.Value = m.ToString();
                    mes6.Text = "AGOSTO";
                    mes6.Value = m.ToString();
                    mes7.Text = "AGOSTO";
                    mes7.Value = m.ToString();
                    mes8.Text = "AGOSTO";
                    mes8.Value = m.ToString();
                }
                if (m == 9)
                {
                    mes.Text = "SEPTIEMBRE";
                    mes.Value = m.ToString();
                    mes2.Text = "SEPTIEMBRE";
                    mes2.Value = m.ToString();
                    mes3.Text = "SEPTIEMBRE";
                    mes3.Value = m.ToString();
                    mes4.Text = "SEPTIEMBRE";
                    mes4.Value = m.ToString();
                    mes5.Text = "SEPTIEMBRE";
                    mes5.Value = m.ToString();
                    mes6.Text = "SEPTIEMBRE";
                    mes6.Value = m.ToString();
                    mes7.Text = "SEPTIEMBRE";
                    mes7.Value = m.ToString();
                    mes8.Text = "SEPTIEMBRE";
                    mes8.Value = m.ToString();
                }
                if (m == 10)
                {
                    mes.Text = "OCTUBRE";
                    mes.Value = m.ToString();
                    mes2.Text = "OCTUBRE";
                    mes2.Value = m.ToString();
                    mes3.Text = "OCTUBRE";
                    mes3.Value = m.ToString();
                    mes4.Text = "OCTUBRE";
                    mes4.Value = m.ToString();
                    mes5.Text = "OCTUBRE";
                    mes5.Value = m.ToString();
                    mes6.Text = "OCTUBRE";
                    mes6.Value = m.ToString();
                    mes7.Text = "OCTUBRE";
                    mes7.Value = m.ToString();
                    mes8.Text = "OCTUBRE";
                    mes8.Value = m.ToString();
                }
                if (m == 11)
                {
                    mes.Text = "NOVIEMBRE";
                    mes.Value = m.ToString();
                    mes2.Text = "NOVIEMBRE";
                    mes2.Value = m.ToString();
                    mes3.Text = "NOVIEMBRE";
                    mes3.Value = m.ToString();
                    mes4.Text = "NOVIEMBRE";
                    mes4.Value = m.ToString();
                    mes5.Text = "NOVIEMBRE";
                    mes5.Value = m.ToString();
                    mes6.Text = "NOVIEMBRE";
                    mes6.Value = m.ToString();
                    mes7.Text = "NOVIEMBRE";
                    mes7.Value = m.ToString();
                    mes8.Text = "NOVIEMBRE";
                    mes8.Value = m.ToString();
                }
                if (m == 12)
                {
                    mes.Text = "DICIEMBRE";
                    mes.Value = m.ToString();
                    mes2.Text = "DICIEMBRE";
                    mes2.Value = m.ToString();
                    mes3.Text = "DICIEMBRE";
                    mes3.Value = m.ToString();
                    mes4.Text = "DICIEMBRE";
                    mes4.Value = m.ToString();
                    mes5.Text = "DICIEMBRE";
                    mes5.Value = m.ToString();
                    mes6.Text = "DICIEMBRE";
                    mes6.Value = m.ToString();
                    mes7.Text = "DICIEMBRE";
                    mes7.Value = m.ToString();
                    mes8.Text = "DICIEMBRE";
                    mes8.Value = m.ToString();
                }
                           
                ddlIniMes.Items.Add(mes);
                ddlFinMes.Items.Add(mes2);
                ddlIniMes1.Items.Add(mes3);
                ddlFinMes1.Items.Add(mes4);
                ddlIniMes2.Items.Add(mes5);
                ddlFinMes2.Items.Add(mes6);
                ddlIniMes3.Items.Add(mes7);
                ddlFinMes3.Items.Add(mes8);
            }
            int a = DateTime.Now.Year;
            for (a = DateTime.Now.Year; a >= 1900 ; a--)
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
                ListItem anio4 = new ListItem();
                anio4.Text = a.ToString();
                anio4.Value = a.ToString();
                ListItem anio5 = new ListItem();
                anio5.Text = a.ToString();
                anio5.Value = a.ToString();
                ListItem anio6 = new ListItem();
                anio6.Text = a.ToString();
                anio6.Value = a.ToString();
                ListItem anio7 = new ListItem();
                anio7.Text = a.ToString();
                anio7.Value = a.ToString();
                ListItem anio8 = new ListItem();
                anio8.Text = a.ToString();
                anio8.Value = a.ToString();
                ddlIniAño.Items.Add(anio);
                ddlFinAño.Items.Add(anio2);
                ddlIniAño1.Items.Add(anio3);
                ddlFinAño1.Items.Add(anio4);
                ddlIniAño2.Items.Add(anio5);
                ddlFinAño2.Items.Add(anio6);
                ddlIniAño3.Items.Add(anio7);
                ddlFinAño3.Items.Add(anio8);
            }
            ddlIniDia.Items.Insert(0, "DIA");
            ddlIniMes.Items.Insert(0, "MES");
            ddlIniAño.Items.Insert(0, "AÑO");
            ddlFinDia.Items.Insert(0, "DIA");
            ddlFinMes.Items.Insert(0, "MES");
            ddlFinAño.Items.Insert(0, "AÑO");

            ddlIniDia1.Items.Insert(0, "DIA");
            ddlIniMes1.Items.Insert(0, "MES");
            ddlIniAño1.Items.Insert(0, "AÑO");
            ddlFinDia1.Items.Insert(0, "DIA");
            ddlFinMes1.Items.Insert(0, "MES");
            ddlFinAño1.Items.Insert(0, "AÑO");

            ddlIniDia2.Items.Insert(0, "DIA");
            ddlIniMes2.Items.Insert(0, "MES");
            ddlIniAño2.Items.Insert(0, "AÑO");
            ddlFinDia2.Items.Insert(0, "DIA");
            ddlFinMes2.Items.Insert(0, "MES");
            ddlFinAño2.Items.Insert(0, "AÑO");

            ddlIniDia3.Items.Insert(0, "DIA");
            ddlIniMes3.Items.Insert(0, "MES");
            ddlIniAño3.Items.Insert(0, "AÑO");
            ddlFinDia3.Items.Insert(0, "DIA");
            ddlFinMes3.Items.Insert(0, "MES");
            ddlFinAño3.Items.Insert(0, "AÑO");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cargo = "NO";
                if (ckbCargoActual.Checked == true)
                    cargo = "SI";
                DateTime fecha_ini = DateTime.Parse("01/01/3000");
                DateTime fecha_fin = DateTime.Parse("01/01/3000");
                DateTime fecha_ini1 = DateTime.Parse("01/01/3000");
                DateTime fecha_fin1 = DateTime.Parse("01/01/3000");
                DateTime fecha_ini2 = DateTime.Parse("01/01/3000");
                DateTime fecha_fin2 = DateTime.Parse("01/01/3000");
                DateTime fecha_ini3 = DateTime.Parse("01/01/3000");
                DateTime fecha_fin3 = DateTime.Parse("01/01/3000");
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
                }
                if (s.ToUpper() == "MM/DD/YYYY")
                {
                    if (IsDate(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                    {
                        fecha_ini = DateTime.Parse(ddlIniMes.SelectedValue + "/" + ddlIniDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
                        lblFecha1.Text = "";
                    }
                    else
                        lblFecha1.Text = "La fecha es incorrecta";
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
                }
                if (ckbCargoActual.Checked)
                { }
                else
                {
                    if (s.ToUpper() == "DD/MM/YYYY")
                    {
                        if (IsDate(ddlFinDia.SelectedValue + "/" + ddlFinMes.SelectedValue + "/" + ddlFinAño.SelectedValue) == true)
                        {
                            fecha_fin = DateTime.Parse(ddlFinDia.SelectedValue + "/" + ddlFinMes.SelectedValue + "/" + ddlFinAño.SelectedValue);
                            lblFecha2.Text = "";
                        }
                        else
                            lblFecha2.Text = "La fecha es incorrecta";

                    }
                    if (s.ToUpper() == "D/M/YYYY")
                    {
                        if (IsDate(ddlFinDia.SelectedValue + "/" + ddlFinMes.SelectedValue + "/" + ddlFinAño.SelectedValue) == true)
                        {
                            fecha_fin = DateTime.Parse(ddlFinDia.SelectedValue + "/" + ddlFinMes.SelectedValue + "/" + ddlFinAño.SelectedValue);
                            lblFecha2.Text = "";
                        }
                        else
                            lblFecha2.Text = "La fecha es incorrecta";
                    }
                    if (s.ToUpper() == "MM/DD/YYYY")
                    {
                        if (IsDate(ddlFinMes.SelectedValue + "/" + ddlFinDia.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                        {
                            fecha_fin = DateTime.Parse(ddlFinMes.SelectedValue + "/" + ddlFinDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
                            lblFecha2.Text = "";
                        }
                        else
                            lblFecha2.Text = "La fecha es incorrecta";
                    }
                    if (s.ToUpper() == "M/D/YYYY")
                    {
                        if (IsDate(ddlFinMes.SelectedValue + "/" + ddlFinDia.SelectedValue + "/" + ddlIniAño.SelectedValue) == true)
                        {
                            fecha_fin = DateTime.Parse(ddlFinMes.SelectedValue + "/" + ddlFinDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
                            lblFecha2.Text = "";
                        }
                        else
                            lblFecha2.Text = "La fecha es incorrecta";
                    }
                   
                   
                }


                //fecha para cargo 1
                if (ddlFinDia1.SelectedItem.Text != "DIA")
                {
                    if (ddlFinMes1.SelectedItem.Text != "MES")
                    {
                        if (ddlFinAño1.SelectedItem.Text != "AÑO")
                        {
                            if (s.ToUpper() == "DD/MM/YYYY")
                            {
                                if (IsDate(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue) == true)
                                {
                                    fecha_ini1 = DateTime.Parse(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
                                    lblFecha3.Text = "";
                                }
                                else
                                    lblFecha3.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue) == true)
                                {
                                    fecha_fin1 = DateTime.Parse(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue);
                                    lblFecha4.Text = "";
                                }
                                else
                                    lblFecha4.Text = "La fecha es incorrecta";

                                
                            }
                            if (s.ToUpper() == "D/M/YYYY")
                            {
                                if (IsDate(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue) == true)
                                {
                                    fecha_ini1 = DateTime.Parse(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
                                    lblFecha3.Text = "";
                                }
                                else
                                    lblFecha3.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue) == true)
                                {
                                    fecha_fin1 = DateTime.Parse(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue);
                                    lblFecha4.Text = "";
                                }
                                else
                                    lblFecha4.Text = "La fecha es incorrecta";
                               
                            }
                            if (s.ToUpper() == "MM/DD/YYYY")
                            {
                                if (IsDate(ddlIniMes1.SelectedValue + "/" + ddlIniDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue) == true)
                                {
                                    fecha_ini1 = DateTime.Parse(ddlIniMes1.SelectedValue + "/" + ddlIniDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
                                    lblFecha3.Text = "";
                                }
                                else
                                    lblFecha3.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue) == true)
                                {
                                    fecha_fin1 = DateTime.Parse(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
                                    lblFecha4.Text = "";
                                }
                                else
                                    lblFecha4.Text = "La fecha es incorrecta";
                            }
                            if (s.ToUpper() == "M/D/YYYY")
                            {
                                if (IsDate(ddlIniMes1.SelectedValue + "/" + ddlIniDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue) == true)
                                {
                                    fecha_ini1 = DateTime.Parse(ddlIniMes1.SelectedValue + "/" + ddlIniDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
                                    lblFecha3.Text = "";
                                }
                                else
                                    lblFecha3.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue) == true)
                                {
                                    fecha_fin1 = DateTime.Parse(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
                                    lblFecha4.Text = "";
                                }
                                else
                                    lblFecha4.Text = "La fecha es incorrecta";
                            }
                        }
                    }

                }
                //fecha para cargo 2
                if (ddlFinDia2.SelectedItem.Text != "DIA")
                {
                    if (ddlFinMes2.SelectedItem.Text != "MES")
                    {
                        if (ddlFinAño2.SelectedItem.Text != "AÑO")
                        {
                            if (s.ToUpper() == "DD/MM/YYYY")
                            {
                                if (IsDate(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue) == true)
                                {
                                    fecha_ini2 = DateTime.Parse(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
                                    lblFecha5.Text = "";
                                }
                                else
                                    lblFecha5.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinDia2.SelectedValue + "/" + ddlFinMes2.SelectedValue + "/" + ddlFinAño2.SelectedValue) == true)
                                {
                                    fecha_fin2 = DateTime.Parse(ddlFinDia2.SelectedValue + "/" + ddlFinMes2.SelectedValue + "/" + ddlFinAño2.SelectedValue);
                                    lblFecha6.Text = "";
                                }
                                else
                                    lblFecha6.Text = "La fecha es incorrecta";
                                
                                
                            }
                            if (s.ToUpper() == "D/M/YYYY")
                            {
                                if (IsDate(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue) == true)
                                {
                                    fecha_ini2 = DateTime.Parse(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
                                    lblFecha5.Text = "";
                                }
                                else
                                    lblFecha5.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinDia2.SelectedValue + "/" + ddlFinMes2.SelectedValue + "/" + ddlFinAño2.SelectedValue) == true)
                                {
                                    fecha_fin2 = DateTime.Parse(ddlFinDia2.SelectedValue + "/" + ddlFinMes2.SelectedValue + "/" + ddlFinAño2.SelectedValue);
                                    lblFecha6.Text = "";
                                }
                                else
                                    lblFecha6.Text = "La fecha es incorrecta";
                            }
                            if (s.ToUpper() == "MM/DD/YYYY")
                            {
                                if (IsDate(ddlIniMes2.SelectedValue + "/" + ddlIniDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue) == true)
                                {
                                    fecha_ini2 = DateTime.Parse(ddlIniMes2.SelectedValue + "/" + ddlIniDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
                                    lblFecha5.Text = "";
                                }
                                else
                                    lblFecha5.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinMes2.SelectedValue + "/" + ddlFinDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue) == true)
                                {
                                    fecha_fin2 = DateTime.Parse(ddlFinMes2.SelectedValue + "/" + ddlFinDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
                                    lblFecha6.Text = "";
                                }
                                else
                                    lblFecha6.Text = "La fecha es incorrecta";
                                
                                
                            }
                            if (s.ToUpper() == "M/D/YYYY")
                            {
                                if (IsDate(ddlIniMes2.SelectedValue + "/" + ddlIniDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue) == true)
                                {
                                    fecha_ini2 = DateTime.Parse(ddlIniMes2.SelectedValue + "/" + ddlIniDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
                                    lblFecha5.Text = "";
                                }
                                else
                                    lblFecha5.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinMes2.SelectedValue + "/" + ddlFinDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue) == true)
                                {
                                    fecha_fin2 = DateTime.Parse(ddlFinMes2.SelectedValue + "/" + ddlFinDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
                                    lblFecha6.Text = "";
                                }
                                else
                                    lblFecha6.Text = "La fecha es incorrecta";
                            }
                        }
                    }
                }


                //fecha para cargo 3
                if (ddlFinDia3.SelectedItem.Text != "DIA")
                {
                    if (ddlFinMes3.SelectedItem.Text != "MES")
                    {
                        if (ddlFinAño3.SelectedItem.Text != "AÑO")
                        {
                            if (s.ToUpper() == "DD/MM/YYYY")
                            {
                                if (IsDate(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue) == true)
                                {
                                    fecha_ini3 = DateTime.Parse(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
                                    lblFecha7.Text = "";
                                }
                                else
                                    lblFecha7.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinDia3.SelectedValue + "/" + ddlFinMes3.SelectedValue + "/" + ddlFinAño3.SelectedValue) == true)
                                {
                                    fecha_fin3 = DateTime.Parse(ddlFinDia3.SelectedValue + "/" + ddlFinMes3.SelectedValue + "/" + ddlFinAño3.SelectedValue);
                                    lblFecha8.Text = "";
                                }
                                else
                                    lblFecha8.Text = "La fecha es incorrecta";
                                
                               
                            }
                            if (s.ToUpper() == "D/M/YYYY")
                            {
                                if (IsDate(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue) == true)
                                {
                                    fecha_ini3 = DateTime.Parse(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
                                    lblFecha7.Text = "";
                                }
                                else
                                    lblFecha7.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinDia3.SelectedValue + "/" + ddlFinMes3.SelectedValue + "/" + ddlFinAño3.SelectedValue) == true)
                                {
                                    fecha_fin3 = DateTime.Parse(ddlFinDia3.SelectedValue + "/" + ddlFinMes3.SelectedValue + "/" + ddlFinAño3.SelectedValue);
                                    lblFecha8.Text = "";
                                }
                                else
                                    lblFecha8.Text = "La fecha es incorrecta";
                            }
                            if (s.ToUpper() == "MM/DD/YYYY")
                            {
                                if (IsDate(ddlIniMes3.SelectedValue + "/" + ddlIniDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue) == true)
                                {
                                    fecha_ini3 = DateTime.Parse(ddlIniMes3.SelectedValue + "/" + ddlIniDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
                                    lblFecha7.Text = "";
                                }
                                else
                                    lblFecha7.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinMes3.SelectedValue + "/" + ddlFinDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue) == true)
                                {
                                    fecha_fin3 = DateTime.Parse(ddlFinMes3.SelectedValue + "/" + ddlFinDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
                                    lblFecha8.Text = "";
                                }
                                else
                                    lblFecha8.Text = "La fecha es incorrecta";
                                
                                
                            }
                            if (s.ToUpper() == "M/D/YYYY")
                            {
                                if (IsDate(ddlIniMes3.SelectedValue + "/" + ddlIniDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue) == true)
                                {
                                    fecha_ini3 = DateTime.Parse(ddlIniMes3.SelectedValue + "/" + ddlIniDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
                                    lblFecha7.Text = "";
                                }
                                else
                                    lblFecha7.Text = "La fecha es incorrecta";

                                if (IsDate(ddlFinMes3.SelectedValue + "/" + ddlFinDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue) == true)
                                {
                                    fecha_fin3 = DateTime.Parse(ddlFinMes3.SelectedValue + "/" + ddlFinDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
                                    lblFecha8.Text = "";
                                }
                                else
                                    lblFecha8.Text = "La fecha es incorrecta";
                            }
                        }
                    }
                }
                if (lblFecha1.Text == "" & lblFecha2.Text == "" & lblFecha3.Text == "" & lblFecha4.Text == "" & lblFecha5.Text == "" & lblFecha6.Text == "" & lblFecha7.Text == "" & lblFecha8.Text == "")
                {
                    if (txtNroDependientesOtro1.Text == "")
                        txtNroDependientesOtro1.Text = "0";
                    if (txtNroDependientesOtro2.Text == "")
                        txtNroDependientesOtro2.Text = "0";
                    if (txtNroDependientesOtro3.Text == "")
                        txtNroDependientesOtro3.Text = "0";
                    if (ckbCargoActual.Checked)
                        fecha_fin = DateTime.Parse("01/01/3000");
                    //var timeSpan = (fecha_fin - fecha_ini) + (fecha_fin1 - fecha_ini1) + (fecha_fin2 - fecha_ini2) + (fecha_fin3 - fecha_ini3);
                    //txtTotalExperiencia.Text = timeSpan.TotalDays.ToString();

                    if (lblIdExperiencia.Text == "")
                    {
                        clases.Experiencia_Laboral obj_exp = new clases.Experiencia_Laboral("I", 0, Int64.Parse(lblIdPersonal.Text), txtEmpresa.Text, txtCargoInicio.Text,
                        Int64.Parse(txtNroDependientes.Text), txtFunciones.Text, fecha_ini, fecha_fin, txtDepartamento.Text,
                        txtOtroCargo1.Text, Int64.Parse(txtNroDependientesOtro1.Text), txtFuncionesOtro1.Text, fecha_ini1, fecha_fin1, txtDepartamentoOtro1.Text,
                        txtOtroCargo2.Text, Int64.Parse(txtNroDependientesOtro2.Text), txtFuncionesOtro2.Text, fecha_ini2, fecha_fin2, txtDepartamentoOtro2.Text,
                        txtOtroCargo3.Text, Int64.Parse(txtNroDependientesOtro3.Text), txtFuncionesOtro3.Text, fecha_ini3, fecha_fin3, txtDepartamentoOtro3.Text, txtDesvinculacionOtro.Text,
                             cargo, ddlMotivoDesvinculacion.SelectedValue, 0,
                           lblUsuario.Text);
                        lblAviso.Text = obj_exp.ABM();
                    }
                    else
                    {
                        clases.Experiencia_Laboral obj_exp = new clases.Experiencia_Laboral("U", Int64.Parse(lblIdExperiencia.Text), Int64.Parse(lblIdPersonal.Text), txtEmpresa.Text, txtCargoInicio.Text,
                        Int64.Parse(txtNroDependientes.Text), txtFunciones.Text, fecha_ini, fecha_fin, txtDepartamento.Text,
                        txtOtroCargo1.Text, Int64.Parse(txtNroDependientesOtro1.Text), txtFuncionesOtro1.Text, fecha_ini1, fecha_fin1, txtDepartamentoOtro1.Text,
                        txtOtroCargo2.Text, Int64.Parse(txtNroDependientesOtro2.Text), txtFuncionesOtro2.Text, fecha_ini2, fecha_fin2, txtDepartamentoOtro2.Text,
                        txtOtroCargo3.Text, Int64.Parse(txtNroDependientesOtro3.Text), txtFuncionesOtro3.Text, fecha_ini3, fecha_fin3, txtDepartamentoOtro3.Text, txtDesvinculacionOtro.Text,
                             cargo, ddlMotivoDesvinculacion.SelectedValue, 0,
                           lblUsuario.Text);
                        lblAviso.Text = obj_exp.ABM();
                    }
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                    limpiar_datos();
                }

                
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_exp_lab_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
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
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            limpiar_datos();
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            clases.Experiencia_Laboral obj_est = new clases.Experiencia_Laboral(Int64.Parse(id));
            lblIdExperiencia.Text = obj_est.PB_ID_EXPERIENCIA.ToString();
            txtEmpresa.Text = obj_est.PV_EMPRESA.ToString();
            txtCargoInicio.Text = obj_est.PV_CARGO.ToString();
            txtNroDependientes.Text = obj_est.PI_NRO_DEPENDIENTES.ToString();
            txtFunciones.Text = obj_est.PV_FUNCIONES.ToString();
            txtDepartamento.Text = obj_est.PV_DEPARTAMENTO.ToString();
            txtOtroCargo1.Text = obj_est.PV_OTRO_CARGO1.ToString();
            txtNroDependientesOtro1.Text = obj_est.PI_NRO_DEPENDIENTES_OTRO1.ToString();
            txtFuncionesOtro1.Text = obj_est.PV_FUNCIONES_OTRO1.ToString();
            txtDepartamentoOtro1.Text = obj_est.PV_DEPARTAMENTO_OTRO1.ToString();
            txtOtroCargo2.Text = obj_est.PV_OTRO_CARGO2.ToString();
            txtNroDependientesOtro2.Text = obj_est.PI_NRO_DEPENDIENTES_OTRO2.ToString();
            txtFuncionesOtro2.Text = obj_est.PV_FUNCIONES_OTRO2.ToString();
            txtDepartamentoOtro2.Text = obj_est.PV_DEPARTAMENTO_OTRO2.ToString();
            txtOtroCargo3.Text = obj_est.PV_OTRO_CARGO3.ToString();
            txtNroDependientesOtro3.Text = obj_est.PI_NRO_DEPENDIENTES_OTRO3.ToString();
            txtFuncionesOtro3.Text = obj_est.PV_FUNCIONES_OTRO3.ToString();
            txtDepartamentoOtro3.Text = obj_est.PV_DEPARTAMENTO_OTRO3.ToString();
            txtDesvinculacionOtro.Text = obj_est.PV_DESVINCULACION_OTRO.ToString();
            ddlMotivoDesvinculacion.DataBind();
            ddlMotivoDesvinculacion.Text = obj_est.PV_MOTIVO_DEVINCULACION.ToString();
            //txtTotalExperiencia.Text = obj_est.PI_TOTAL_EXPERIENCIA.ToString();
            string aux_c = obj_est.PV_ACTUAL_CARGO.ToString();
            if (aux_c == "SI")
                ckbCargoActual.Checked = true;
            else
                ckbCargoActual.Checked = false;
            cargar_calendarios();
            DateTime fecha_ini = obj_est.PD_FECHA_INICIO;
            DateTime fecha_fin = obj_est.PD_FECHA_FIN;

            DateTime fecha_ini1 = obj_est.PD_FECHA_INICIO_OTRO1;
            DateTime fecha_fin1 = obj_est.PD_FECHA_FIN_OTRO1;
            DateTime fecha_ini2 = obj_est.PD_FECHA_INICIO_OTRO2;
            DateTime fecha_fin2 = obj_est.PD_FECHA_FIN_OTRO2;
            DateTime fecha_ini3 = obj_est.PD_FECHA_INICIO_OTRO3;
            DateTime fecha_fin3 = obj_est.PD_FECHA_FIN_OTRO3;

            ddlIniDia.SelectedValue = fecha_ini.Day.ToString();
            ddlIniMes.SelectedValue = fecha_ini.Month.ToString();
            ddlIniAño.SelectedValue = fecha_ini.Year.ToString();
            ddlFinDia.SelectedValue = fecha_fin.Day.ToString();
            ddlFinMes.SelectedValue = fecha_fin.Month.ToString();
            ddlFinAño.SelectedValue = fecha_fin.Year.ToString();
            if (fecha_ini == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlIniDia.SelectedValue = fecha_ini.Day.ToString();
                ddlIniMes.SelectedValue = fecha_ini.Month.ToString();
                ddlIniAño.SelectedValue = fecha_ini.Year.ToString();
            }
            if (fecha_fin == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlFinDia.SelectedValue = fecha_fin.Day.ToString();
                ddlFinMes.SelectedValue = fecha_fin.Month.ToString();
                ddlFinAño.SelectedValue = fecha_fin.Year.ToString();
            }

            if (fecha_ini1 == DateTime.Parse("01/01/3000"))
            { }
            else 
            {
                ddlIniDia1.SelectedValue = fecha_ini1.Day.ToString();
                ddlIniMes1.SelectedValue = fecha_ini1.Month.ToString();
                ddlIniAño1.SelectedValue = fecha_ini1.Year.ToString();
            }
            if (fecha_fin1 == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlFinDia1.SelectedValue = fecha_fin1.Day.ToString();
                ddlFinMes1.SelectedValue = fecha_fin1.Month.ToString();
                ddlFinAño1.SelectedValue = fecha_fin1.Year.ToString();
            }
                

            if (fecha_ini2 == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlIniDia2.SelectedValue = fecha_ini2.Day.ToString();
                ddlIniMes2.SelectedValue = fecha_ini2.Month.ToString();
                ddlIniAño2.SelectedValue = fecha_ini2.Year.ToString();
            }
            if (fecha_fin2 == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlFinDia2.SelectedValue = fecha_fin2.Day.ToString();
                ddlFinMes2.SelectedValue = fecha_fin2.Month.ToString();
                ddlFinAño2.SelectedValue = fecha_fin2.Year.ToString();
            }


            if (fecha_ini3 == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlIniDia3.SelectedValue = fecha_ini3.Day.ToString();
                ddlIniMes3.SelectedValue = fecha_ini3.Month.ToString();
                ddlIniAño3.SelectedValue = fecha_ini3.Year.ToString();
            }
            if (fecha_fin3 == DateTime.Parse("01/01/3000"))
            { }
            else
            {
                ddlFinDia3.SelectedValue = fecha_fin3.Day.ToString();
                ddlFinMes3.SelectedValue = fecha_fin3.Month.ToString();
                ddlFinAño3.SelectedValue = fecha_fin3.Year.ToString();
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar_datos();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                clases.Experiencia_Laboral obj_exp = new clases.Experiencia_Laboral("D", Int64.Parse(id), Int64.Parse(lblIdPersonal.Text),
                    "", "", 0, "", DateTime.Now, DateTime.Now, "",
                    "", 0, "", DateTime.Now, DateTime.Now, "",
                     "", 0, "", DateTime.Now, DateTime.Now, "",
                      "", 0, "", DateTime.Now, DateTime.Now, "", "",
                      "", "", 0, lblUsuario.Text);
                lblAviso.Text = obj_exp.ABM();
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_exp_lab_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos un problema por favor revise los datos.";
            }

        }

        //protected void btnCalcular_Click(object sender, EventArgs e)
        //{
        //    DateTime fecha_ini = DateTime.Parse("01/01/3000");
        //    DateTime fecha_fin = DateTime.Parse("01/01/3000");
        //    DateTime fecha_ini1 = DateTime.Parse("01/01/3000");
        //    DateTime fecha_fin1 = DateTime.Parse("01/01/3000");
        //    DateTime fecha_ini2 = DateTime.Parse("01/01/3000");
        //    DateTime fecha_fin2 = DateTime.Parse("01/01/3000");
        //    DateTime fecha_ini3 = DateTime.Parse("01/01/3000");
        //    DateTime fecha_fin3 = DateTime.Parse("01/01/3000");
        //    string s;

        //    s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        //    if (s.ToUpper() == "DD/MM/YYYY")
        //    {
        //        fecha_ini = DateTime.Parse(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue);
        //        fecha_fin = DateTime.Parse(ddlFinDia.SelectedValue + "/" + ddlFinMes.SelectedValue + "/" + ddlFinAño.SelectedValue);
        //    }
        //    if (s.ToUpper() == "D/M/YYYY")
        //    {
        //        fecha_ini = DateTime.Parse(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue);
        //        fecha_fin = DateTime.Parse(ddlFinDia.SelectedValue + "/" + ddlFinMes.SelectedValue + "/" + ddlFinAño.SelectedValue);
        //    }
        //    if (s.ToUpper() == "MM/DD/YYYY")
        //    {
        //        fecha_ini = DateTime.Parse(ddlIniDia.SelectedValue + "/" + ddlIniMes.SelectedValue + "/" + ddlIniAño.SelectedValue);
        //        fecha_fin = DateTime.Parse(ddlFinMes.SelectedValue + "/" + ddlFinDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
        //    }
        //    if (s.ToUpper() == "M/D/YYYY")
        //    {
        //        fecha_ini = DateTime.Parse(ddlIniMes.SelectedValue + "/" + ddlIniDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
        //        fecha_fin = DateTime.Parse(ddlFinMes.SelectedValue + "/" + ddlFinDia.SelectedValue + "/" + ddlIniAño.SelectedValue);
        //    }

        //    //fecha para cargo 1
        //    if (ddlFinDia1.SelectedItem.Text != "DIA")
        //    {
        //        if (ddlFinMes1.SelectedItem.Text != "MES")
        //        {
        //            if (ddlFinAño1.SelectedItem.Text != "AÑO")
        //            {
        //                if (s.ToUpper() == "DD/MM/YYYY")
        //                {
        //                    fecha_ini1 = DateTime.Parse(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
        //                    fecha_fin1 = DateTime.Parse(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue);
        //                }
        //                if (s.ToUpper() == "D/M/YYYY")
        //                {
        //                    fecha_ini1 = DateTime.Parse(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
        //                    fecha_fin1 = DateTime.Parse(ddlFinDia1.SelectedValue + "/" + ddlFinMes1.SelectedValue + "/" + ddlFinAño1.SelectedValue);
        //                }
        //                if (s.ToUpper() == "MM/DD/YYYY")
        //                {
        //                    fecha_ini1 = DateTime.Parse(ddlIniDia1.SelectedValue + "/" + ddlIniMes1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
        //                    fecha_fin1 = DateTime.Parse(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
        //                }
        //                if (s.ToUpper() == "M/D/YYYY")
        //                {
        //                    fecha_ini1 = DateTime.Parse(ddlIniMes1.SelectedValue + "/" + ddlIniDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
        //                    fecha_fin1 = DateTime.Parse(ddlFinMes1.SelectedValue + "/" + ddlFinDia1.SelectedValue + "/" + ddlIniAño1.SelectedValue);
        //                }
        //            }
        //        }

        //    }
        //    //fecha para cargo 2
        //    if (ddlFinDia2.SelectedItem.Text != "DIA")
        //    {
        //        if (ddlFinMes2.SelectedItem.Text != "MES")
        //        {
        //            if (ddlFinAño2.SelectedItem.Text != "AÑO")
        //            {
        //                if (s.ToUpper() == "DD/MM/YYYY")
        //                {
        //                    fecha_ini2 = DateTime.Parse(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
        //                    fecha_fin2 = DateTime.Parse(ddlFinDia2.SelectedValue + "/" + ddlFinMes2.SelectedValue + "/" + ddlFinAño2.SelectedValue);
        //                }
        //                if (s.ToUpper() == "D/M/YYYY")
        //                {
        //                    fecha_ini2 = DateTime.Parse(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
        //                    fecha_fin2 = DateTime.Parse(ddlFinDia2.SelectedValue + "/" + ddlFinMes2.SelectedValue + "/" + ddlFinAño2.SelectedValue);
        //                }
        //                if (s.ToUpper() == "MM/DD/YYYY")
        //                {
        //                    fecha_ini2 = DateTime.Parse(ddlIniDia2.SelectedValue + "/" + ddlIniMes2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
        //                    fecha_fin2 = DateTime.Parse(ddlFinMes2.SelectedValue + "/" + ddlFinDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
        //                }
        //                if (s.ToUpper() == "M/D/YYYY")
        //                {
        //                    fecha_ini2 = DateTime.Parse(ddlIniMes2.SelectedValue + "/" + ddlIniDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
        //                    fecha_fin2 = DateTime.Parse(ddlFinMes2.SelectedValue + "/" + ddlFinDia2.SelectedValue + "/" + ddlIniAño2.SelectedValue);
        //                }
        //            }
        //        }
        //    }


        //    //fecha para cargo 3
        //    if (ddlFinDia3.SelectedItem.Text != "DIA")
        //    {
        //        if (ddlFinMes3.SelectedItem.Text != "MES")
        //        {
        //            if (ddlFinAño3.SelectedItem.Text != "AÑO")
        //            {
        //                if (s.ToUpper() == "DD/MM/YYYY")
        //                {
        //                    fecha_ini3 = DateTime.Parse(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
        //                    fecha_fin3 = DateTime.Parse(ddlFinDia3.SelectedValue + "/" + ddlFinMes3.SelectedValue + "/" + ddlFinAño3.SelectedValue);
        //                }
        //                if (s.ToUpper() == "D/M/YYYY")
        //                {
        //                    fecha_ini3 = DateTime.Parse(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
        //                    fecha_fin3 = DateTime.Parse(ddlFinDia3.SelectedValue + "/" + ddlFinMes3.SelectedValue + "/" + ddlFinAño3.SelectedValue);
        //                }
        //                if (s.ToUpper() == "MM/DD/YYYY")
        //                {
        //                    fecha_ini3 = DateTime.Parse(ddlIniDia3.SelectedValue + "/" + ddlIniMes3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
        //                    fecha_fin3 = DateTime.Parse(ddlFinMes3.SelectedValue + "/" + ddlFinDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
        //                }
        //                if (s.ToUpper() == "M/D/YYYY")
        //                {
        //                    fecha_ini3 = DateTime.Parse(ddlIniMes3.SelectedValue + "/" + ddlIniDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
        //                    fecha_fin3 = DateTime.Parse(ddlFinMes3.SelectedValue + "/" + ddlFinDia3.SelectedValue + "/" + ddlIniAño3.SelectedValue);
        //                }
        //            }
        //        }
        //    }
        //    if (ckbCargoActual.Checked)
        //        fecha_fin = DateTime.Now;
        //   // var timeSpan = (fecha_fin - fecha_ini) + (fecha_fin1 - fecha_ini1) + (fecha_fin2 - fecha_ini2) + (fecha_fin3 - fecha_ini3);
        //   // txtTotalExperiencia.Text = timeSpan.TotalDays.ToString();
        //}

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar_datos();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ddlMotivoDesvinculacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMotivoDesvinculacion.SelectedItem.Text == "OTRO")
            {
                txtDesvinculacionOtro.Enabled = true;
            }
            else
            {
                txtDesvinculacionOtro.Enabled = false;
            }
        }

        protected void ddlMotivoDesvinculacion_DataBound1(object sender, EventArgs e)
        {
            ddlMotivoDesvinculacion.Items.Insert(0, "SELECCIONAR UNA OPCION");
        }

        protected void ckbCargoActual_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCargoActual.Checked)
            { RequiredFieldValidator8.Enabled = false; RequiredFieldValidator9.Enabled = false; RequiredFieldValidator10.Enabled = false; RequiredFieldValidator21.Enabled = false; }
            else
            { RequiredFieldValidator8.Enabled = true; RequiredFieldValidator9.Enabled = true; RequiredFieldValidator10.Enabled = true; RequiredFieldValidator21.Enabled = true; }
            
        }
    }
}