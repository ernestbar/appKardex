using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appRRHHDF
{
    public partial class conv_vista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblCodConvocatoria.Text = Session["COD_CONVOCATORIA"].ToString();
                lblIdPersonal.Text = Session["ID_PERSONAL"].ToString();
                DataTable dt = clases.Convocatorias2.PR_SEG_GET_CONVOCATORIAS_IND(lblCodConvocatoria.Text);
                string logo = "";
                string id_cliente = "";
                foreach (DataRow dr in dt.Rows)
                {
                    lblEmpresa.Text = dr["CLI_RAZON_SOCIAL"].ToString().ToUpper();
                    lblArea.Text= dr["DESC_AREA_TRABAJO"].ToString().ToUpper();
                    lblCargo.Text = dr["CNV_NOMBRE_CARGO"].ToString().ToUpper();
                    lblTipoConvocatoria.Text = dr["DESC_TIPO_CONVOCATORIA"].ToString();
                    lblLugar.Text = dr["CIU_CIUDAD"].ToString();
                    lblObjetivo.Text= dr["CNV_OBJETIVO"].ToString();
                    lblFomracion.Text = dr["DESC_NIVEL_ACADEMICO"].ToString();
                    if (dr["CNV_REQUISITOS_GENERALES"].ToString()=="")
                        lblDescFormacion.Text = dr["CNV_NIVEL_ACADEMICO_DESC"].ToString();
                    else
                        lblDescFormacion.Text = dr["CNV_REQUISITOS_GENERALES"].ToString();
                    // lblGeneral.Text = "Experiencia profesional general Mínimo de " + dr["CNV_EXPERIENCIA_GENERAL"].ToString() + " años.";
                    lblGeneral.Text = dr["CNV_EXPERIENCIA_GENERAL"].ToString();
                    lblDescGeneral.Text = dr["CNV_EXPERIENCIA_GENERAL_DESC"].ToString();
                    //lblEspecifica.Text = "Experiencia profesional específica mínimo de " + dr["CNV_EXPERIENCIA_REQUERIDA"].ToString() + " años.";
                    lblEspecifica.Text = dr["CNV_EXPERIENCIA_REQUERIDA"].ToString();
                    lblDescEspecifica.Text = dr["CNV_EXPERIENCIA_REQUERIDA_DESC"].ToString();
                    DateTime FECHA_FIN=DateTime.Parse(dr["CNV_FECHA_FIN"].ToString());
                    lblFechaLimite.Text = FECHA_FIN.Day.ToString() + " de " + Nombre_mes(FECHA_FIN.Month) + " del " + FECHA_FIN.Year.ToString();
                    if (String.IsNullOrEmpty(dr["CLI_LOGO"].ToString()))
                        logo = "";
                    else
                        logo =dr["CLI_LOGO"].ToString();
                    id_cliente = dr["CLI_ID_CLIENTE"].ToString();
                }
                if (logo != "")
                {
                    string pageurl = System.Configuration.ConfigurationManager.AppSettings["dominio_admin"].ToString() + "/Logos/" + id_cliente + "/" + logo;
                    iLogoEmpresa.ImageUrl = pageurl;
                }
                else
                {
                    //string pageurl = System.Configuration.ConfigurationManager.AppSettings["dominio"].ToString() + "/sin_logo.png";
                    string pageurl = "~/sin_logo.png";
                    iLogoEmpresa.ImageUrl = pageurl;
                }
                iLogoEmpresa.DataBind();
                Repeater1.DataBind();
            }
        }

        protected void btnPostular_Click(object sender, EventArgs e)
        {
            string resultado = "";
            DataTable dt = clases.Convocatorias2.PR_VCO_GET_VALIDA_CONVOCATORIA(Int64.Parse(lblIdPersonal.Text),lblCodConvocatoria.Text);
            foreach (DataRow dr in dt.Rows)
            {
                resultado = dr[0].ToString(); ;
            }
            Session["POSTULAR"] = resultado.ToUpper();
            Session["COD_CONVOCATORIA"] = lblCodConvocatoria.Text;
            Session["ID_PERSONAL"] = lblIdPersonal.Text;
            Response.Redirect("postulaciones.aspx");
        }
        public string Nombre_mes(int mes)
        {
            string nomb_mes = "";
            if (mes == 1)
                nomb_mes = "Enero";
            if (mes == 2)
                nomb_mes = "Febrero";
            if (mes == 3)
                nomb_mes = "Marzo";
            if (mes == 4)
                nomb_mes = "Abril";
            if (mes == 5)
                nomb_mes = "Mayo";
            if (mes == 6)
                nomb_mes = "Junio";
            if (mes == 7)
                nomb_mes = "Julio";
            if (mes == 8)
                nomb_mes = "Agosto";
            if (mes == 9)
                nomb_mes = "Septiembre";
            if (mes == 10)
                nomb_mes = "Octubre";
            if (mes == 11)
                nomb_mes = "Noviembre";
            if (mes == 12)
                nomb_mes = "Diciembre";

            return nomb_mes;

        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Convocatorias.aspx");
        }
    }
}