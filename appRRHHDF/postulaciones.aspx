<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="postulaciones.aspx.cs" Inherits="appRRHHDF.postulaciones" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control form-control-lg inverse-mode ErrorControl";
                        } else {
                            control.className = "form-control form-control-lg inverse-mode";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
	<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
	<asp:Label ID="lblIdPersonal" runat="server" Visible="false" Text=""></asp:Label>
	<asp:Label ID="lblPostular" runat="server" Visible="false" Text=""></asp:Label>
	
	<asp:ObjectDataSource ID="odsNivelEducacion" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="NIVEL ESTUDIO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsFormacion" runat="server" SelectMethod="PR_VCO_GET_FORMACION" TypeName="appRRHHDF.clases.Formacion_postulacion">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<asp:ControlParameter ControlID="lblCodConvocatoria" Name="PV_CNV_CONVOCATORIA" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsExpGeneral" runat="server" SelectMethod="PR_VCO_GET_EXPERIENCIA_GENERAL" TypeName="appRRHHDF.clases.Experiencias_postulacion">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<asp:ControlParameter ControlID="lblCodConvocatoria" Name="PV_CNV_CONVOCATORIA" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsExpEspecifica" runat="server" SelectMethod="PR_VCO_GET_EXPERIENCIA_REQUERIDA" TypeName="appRRHHDF.clases.Experiencias_postulacion">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<asp:ControlParameter ControlID="lblCodConvocatoria" Name="PV_CNV_CONVOCATORIA" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCursos" runat="server" SelectMethod="PR_VCO_GET_CURSO" TypeName="appRRHHDF.clases.Curso_postulacion">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<asp:ControlParameter ControlID="lblCodConvocatoria" Name="PV_CNV_CONVOCATORIA" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsIdiomas" runat="server" SelectMethod="PR_VCO_GET_IDIOMA" TypeName="appRRHHDF.clases.Idioma_postulacion">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<asp:ControlParameter ControlID="lblCodConvocatoria" Name="PV_CNV_CONVOCATORIA" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDDJJ" runat="server" SelectMethod="PR_VCO_GET_DDJJ" TypeName="appRRHHDF.clases.DDJJ_postulacion">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<asp:ControlParameter ControlID="lblCodConvocatoria" Name="PV_CNV_CONVOCATORIA" DefaultValue="" />
				<asp:ControlParameter ControlID="lblUsuario" Name="PV_USUARIO" DefaultValue="" />
			</SelectParameters>
		 </asp:ObjectDataSource>
    <!-- begin #content -->
		<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Convocatorias</a></li>
				<li class="breadcrumb-item active">Postulaciones</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header"><asp:Label ID="lblCodConvocatoria" runat="server" Visible="true" Text=""></asp:Label><small></small></h1>
			<h5><asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Text=""></asp:Label></h5>
			<!-- end page-header -->
			
			<!-- begin row -->
			<div class="row">

				<!-- begin col-12 -->
				<div class="col-lg-12">
                    <!-- begin nav-tabs -->
					<ul class="nav nav-tabs">
						<li class="nav-items">
							<asp:LinkButton ID="lbtnFormacion" CausesValidation="false" class="nav-link active" OnClick="lblFormacion_Click" runat="server">1. Formacion</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnExperienciaGeneral" CausesValidation="false" class="nav-link" OnClick="lbtnExperienciaGeneral_Click" runat="server">2. Experiencia General</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnExperienciaEspecifica" CausesValidation="false" class="nav-link" OnClick="lbtnExperienciaEspecifica_Click" runat="server">3. Experiencia Especifica</asp:LinkButton>
						
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnCursosTalleres" CausesValidation="false" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">4. Cursos y Talleres</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnNivelIdioma" CausesValidation="false" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">5. Conocimientos e Idiomas</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDeclaracionJurada" CausesValidation="false" class="nav-link" OnClick="lbtnDeclaracionJurada_Click" runat="server">6. Declaracion Jurada</asp:LinkButton>
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnPDF" CausesValidation="false" class="nav-link" OnClick="lbtnPDF_Click" runat="server">7. Descargar Formulario en PDF</asp:LinkButton>
							
						</li>
					</ul>
					<!-- end nav-tabs -->
					<!-- begin tab-content -->
					<div class="tab-content" style="padding:40px 0">
						<asp:Button ID="btnCV" runat="server" CssClass="btn btn-success col-12 btn-md" OnClick="btnCV_Click" Text="Si deseas registrar tu CV o actualizar tus datos presiona AQUI!!!" />
                        
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
								<h3><asp:Label ID="lblEstudiosTitulo" runat="server" Text="Estudios"></asp:Label></h3><br /> 
								<h4><asp:Label ID="lblEstudios" runat="server" Text=""></asp:Label></h4>             
								 <asp:Label ID="lblEstudiosDesc" runat="server" Text=""></asp:Label>
                                <div class="panel-body">
					                <table id="data-table" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Institucion</th>
								                <th class="text-nowrap">Ciudad</th>
								                <th class="text-nowrap">Nivel de Estudioo</th>
								                <th class="text-nowrap">Titulo obtenido</th>
												<th class="text-nowrap">Concluido</th>
												<th class="text-nowrap">Fecha Inicio</th>
								                <th class="text-nowrap">Fecha Final</th>
												
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater1" DataSourceID="odsFormacion" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("PES_INSTITUCION") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("PES_CIUDAD") %>'></asp:Label></td>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("DESC_NIVEL_ESTUDIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("PES_TITULO_OBTENIDO") %>'></asp:Label></td>
																 <td><asp:Label ID="Label7" runat="server" Text='<%# Eval("PES_CONCLUIDO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("PES_FECHA_INICIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("PES_FECHA_FIN") %>'></asp:Label></td>
																 <td>
																	<asp:Button ID="btnSeleccionar" Visible='<%# Eval("EXISTE").ToString().Equals("NO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") +"|"+ Eval("PES_NIVEL_ESTUDIO")+"|"+Eval("PES_INSTITUCION")+"|"+Eval("PES_CIUDAD")+"|"+Eval("PES_FECHA_INICIO")+"|"+Eval("PES_FECHA_FIN")+"|"+Eval("PES_CONCLUIDO")+"|"+Eval("PES_TITULO_OBTENIDO")+"|"+Eval("PES_FECHA_TITULO")+"|"+Eval("PES_AREA_ESTUDIO") %>' OnClick="btnSeleccionar_Click" runat="server" Text="Seleccionar" ToolTip="Seleccionar" />
																	 <asp:Button ID="btnDesseleccionar" Visible='<%# Eval("EXISTE").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-danger btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") +"|"+ Eval("PES_NIVEL_ESTUDIO")+"|"+Eval("PES_INSTITUCION")+"|"+Eval("PES_CIUDAD")+"|"+Eval("PES_FECHA_INICIO")+"|"+Eval("PES_FECHA_FIN")+"|"+Eval("PES_CONCLUIDO")+"|"+Eval("PES_TITULO_OBTENIDO")+"|"+Eval("PES_FECHA_TITULO")+"|"+Eval("PES_AREA_ESTUDIO") %>' OnClick="btnDesseleccionar_Click" runat="server" Text="Cancelar Seleccionar" ToolTip="Cancelar Seleccionar" />
																		<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />--%>
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>
                            </div> 
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                                          <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
								<h3><asp:Label ID="lblExpGeneralTitulo" runat="server" Text="Experiencia General"></asp:Label></h3><br /> 
								<h4><asp:Label ID="lblExpGen" runat="server" Text=""></asp:Label></h4>                       
											  <asp:Label ID="lblExpGenDesc" runat="server" Text=""></asp:Label>
                                <div class="panel-body">
					                <table id="data-table" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Empresa</th>
								              <%--  <th class="text-nowrap">Cargo</th>--%>
								                <th class="text-nowrap">Area/Departamento</th>
								                <th class="text-nowrap">Fecha Inicio</th>
								                <th class="text-nowrap">Fecha Final</th>
												<th class="text-nowrap">Total Experiencia</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater2" DataSourceID="odsExpGeneral" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("PEX_EMPRESA") %>'></asp:Label></td>
																<%--<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("PEX_CARGO") %>'></asp:Label></td>--%>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("PEX_FECHA_INICIO_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("PEX_FECHA_FIN_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA") %>'></asp:Label></td>
																 <td>
																	<asp:Button ID="btnSeleccionar2" Visible='<%# Eval("EXISTE").ToString().Equals("NO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PEX_ID_EXPERIENCIA") +"|"+ Eval("PEX_EMPRESA")+"|"+Eval("PEX_TOTAL_EXPERIENCIA")+"|"+Eval("PEX_FECHA_INICIO_CARGO")+"|"+Eval("PEX_FECHA_FIN_CARGO") %>' OnClick="btnSeleccionar2_Click" runat="server" Text="Seleccionar" ToolTip="Seleccionar" />
																	 <asp:Button ID="btnDesseleccionar2" Visible='<%# Eval("EXISTE").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-danger btn-sm" Enabled="true" CommandArgument='<%# Eval("PEX_ID_EXPERIENCIA") +"|"+ Eval("PEX_EMPRESA")+"|"+Eval("PEX_TOTAL_EXPERIENCIA")+"|"+Eval("PEX_FECHA_INICIO_CARGO")+"|"+Eval("PEX_FECHA_FIN_CARGO") %>' OnClick="btnDesseleccionar2_Click" runat="server" Text="Cancelar Seleccionar" ToolTip="Cancelar Seleccionar" />
																		<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />--%>
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>
                            </div>
                        </asp:View>
						 <asp:View ID="View3" runat="server">
                              <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
								<h3><asp:Label ID="lblTituloEspecifica" runat="server" Text="Experiencia Especifica"></asp:Label></h3><br /> 
								<h4><asp:Label ID="lblEspEsp" runat="server" Text=""></asp:Label></h4>      
								  <asp:Label ID="lblExpEspDesc" runat="server" Text=""></asp:Label>
                                <div class="panel-body">
					                <table id="data-table" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Empresa</th>
								                <th class="text-nowrap">Cargo</th>
								                <th class="text-nowrap">Area/Departamento</th>
								                <th class="text-nowrap">Fecha Inicio</th>
								                <th class="text-nowrap">Fecha Final</th>
												<th class="text-nowrap">Total Experiencia</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater3" DataSourceID="odsExpEspecifica" OnItemDataBound="Repeater3_ItemDataBound" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("PEX_EMPRESA") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("PEX_CARGO") %>'></asp:Label></td>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("PEX_FECHA_INICIO_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("PEX_FECHA_FIN_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA") %>'></asp:Label></td>
																 <td>
																	<asp:Button ID="btnSeleccionar3" Visible='<%# Eval("EXISTE").ToString().Equals("NO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PEX_ID_EXPERIENCIA") +"|"+ Eval("PEX_EMPRESA")+"|"+Eval("PEX_CARGO")+"|"+Eval("PEX_TOTAL_EXPERIENCIA")+"|"+Eval("PEX_FECHA_INICIO_CARGO")+"|"+Eval("PEX_FECHA_FIN_CARGO")+"|"+Eval("PEX_DEPARTAMENTO_CARGO") %>' OnClick="btnSeleccionar3_Click" runat="server" Text="Seleccionar" ToolTip="Seleccionar" />
																	 <asp:Button ID="btnDesseleccionar3" Visible='<%# Eval("EXISTE").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-danger btn-sm" Enabled="true" CommandArgument='<%# Eval("PEX_ID_EXPERIENCIA") +"|"+ Eval("PEX_EMPRESA")+"|"+Eval("PEX_CARGO")+"|"+Eval("PEX_TOTAL_EXPERIENCIA")+"|"+Eval("PEX_FECHA_INICIO_CARGO")+"|"+Eval("PEX_FECHA_FIN_CARGO")+"|"+Eval("PEX_DEPARTAMENTO_CARGO") %>' OnClick="btnDesseleccionar3_Click" runat="server" Text="Cancelar Seleccionar" ToolTip="Cancelar Seleccionar" />
																		<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />--%>
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>
                            </div>
                        </asp:View>
						 <asp:View ID="View4" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
								<h3><asp:Label ID="lblCursosTitulo" runat="server" Text="Cursos obtenidos"></asp:Label></h3><br /> 
								<h4><asp:Label ID="lblCursos" runat="server" Text=""></asp:Label></h4>                       
                                <div class="panel-body">
					                <table id="data-table" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Insitutcion</th>
								                <th class="text-nowrap">Tipo capacitacion</th>
								                <th class="text-nowrap">Titulo Obtenido</th>
								                <th class="text-nowrap">Fecha Inicio</th>
								                <th class="text-nowrap">Fecha Final</th>
												<th class="text-nowrap">Total Horas</th>
												<th class="text-nowrap">Fecha Titulo</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater4" DataSourceID="odsCursos" OnItemDataBound="Repeater4_ItemDataBound" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("PCR_INSTITUCION") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_TIPO_CAPACITACION") %>'></asp:Label></td>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("PCR_TITULO_OBTENIDO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("PCR_FECHA_INICIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("PCR_FECHA_FIN") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("PCR_TOTAL_HORAS") %>'></asp:Label></td>
																 <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("PCR_FECHA_TITULO") %>'></asp:Label></td>
																 <td>
																	<asp:Button ID="btnSeleccionar4" Visible='<%# Eval("EXISTE").ToString().Equals("NO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PCR_ID_CURSO") +"|"+ Eval("PCR_TIPO_CAPACITACION")+"|"+Eval("PCR_INSTITUCION")+"|"+Eval("PCR_CIUDAD")+"|"+Eval("PCR_FECHA_INICIO")+"|"+Eval("PCR_FECHA_FIN")+"|"+Eval("PCR_TOTAL_HORAS")+"|"+Eval("PCR_FECHA_TITULO")+"|"+Eval("PCR_TITULO_OBTENIDO") %>' OnClick="btnSeleccionar4_Click" runat="server" Text="Seleccionar" ToolTip="Seleccionar" />
																	 <asp:Button ID="btnDesseleccionar4" Visible='<%# Eval("EXISTE").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-danger btn-sm" Enabled="true" CommandArgument='<%# Eval("PCR_ID_CURSO") +"|"+ Eval("PCR_TIPO_CAPACITACION")+"|"+Eval("PCR_INSTITUCION")+"|"+Eval("PCR_CIUDAD")+"|"+Eval("PCR_FECHA_INICIO")+"|"+Eval("PCR_FECHA_FIN")+"|"+Eval("PCR_TOTAL_HORAS")+"|"+Eval("PCR_FECHA_TITULO")+"|"+Eval("PCR_TITULO_OBTENIDO") %>' OnClick="btnDesseleccionar4_Click" runat="server" Text="Cancelar Seleccionar" ToolTip="Cancelar Seleccionar" />
																		<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />--%>
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>
                            </div>
                        </asp:View>
						 <asp:View ID="View5" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
								<h3><asp:Label ID="Label2" runat="server" Text="Dominio de idiomas"></asp:Label></h3><br /> 
								<h4><asp:Label ID="Label3" runat="server" Text=""></asp:Label></h4>                       
                                <div class="panel-body">
					                <table id="data-table" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Idioma</th>
								                <th class="text-nowrap">Nivel Escritura</th>
								                <th class="text-nowrap">Nivel Lectura</th>
								                <th class="text-nowrap">Nivel Conversacion</th>
								                <th class="text-nowrap">Con titulo</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater5" DataSourceID="odsIdiomas" OnItemDataBound="Repeater5_ItemDataBound" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("DESC_IDIOMA") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_ESCRITURA") %>'></asp:Label></td>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("DESC_LECTURA") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("DESC_CONVERSACION") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("PID_CON_TITULO") %>'></asp:Label></td>
																 <td>
																	<asp:Button ID="btnSeleccionar5" Visible='<%# Eval("EXISTE").ToString().Equals("NO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PID_ID_IDIOMA") +"|"+ Eval("PID_NIVEL_DOMINIO_LECTURA")+"|"+Eval("PID_NIVEL_DOMINIO_ESCRITURA")+"|"+Eval("PID_NIVEL_DOMINIO_CONVERSACION")+"|"+Eval("PID_CON_TITULO") %>' OnClick="btnSeleccionar5_Click" runat="server" Text="Seleccionar" ToolTip="Seleccionar" />
																	 <asp:Button ID="btnDesseleccionar5" Visible='<%# Eval("EXISTE").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' class="btn btn-danger btn-sm" Enabled="true" CommandArgument='<%# Eval("PID_ID_IDIOMA") +"|"+ Eval("PID_NIVEL_DOMINIO_LECTURA")+"|"+Eval("PID_NIVEL_DOMINIO_ESCRITURA")+"|"+Eval("PID_NIVEL_DOMINIO_CONVERSACION")+"|"+Eval("PID_CON_TITULO") %>' OnClick="btnDesseleccionar5_Click" runat="server" Text="Cancelar Seleccionar" ToolTip="Cancelar Seleccionar" />
																		<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />--%>
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>
                            </div>
                        </asp:View>
						 <asp:View ID="View6" runat="server">
							 <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
								<h3><asp:Label ID="Label5" runat="server" Text="Declaracion jurdada"></asp:Label></h3><br /> 
								<h4><asp:Label ID="Label6" runat="server" Text=""></asp:Label></h4>        
								 <div class="conten_form">   
								 <asp:Repeater ID="Repeater6" DataSourceID="odsDDJJ" OnItemDataBound="Repeater6_ItemDataBound" runat="server">
										<ItemTemplate>
											    
                                                                                               
												<div class="form-group m-b-20 col-lg-6" style="float:left">
													<span><asp:Label ID="lblTitulo" class="col-md-6 text-md-right col-form-label" runat="server" Text='<%# Eval("CDD_PREGUNTA") %>'></asp:Label>(<asp:Label ID="Label8" Text='<%# Eval("CDD_VALOR") %>' runat="server" ></asp:Label>)</span>
																<asp:TextBox ID="TextBox1" TextMode="MultiLine" Height="80px" Text='<%# Eval("CDD_VALOR") %>'   CssClass="form-control" ToolTip='<%# Eval("CDD_CONVOCATORIA_DDJJ")+"|"+Eval("CDJ_CONVOCATORIA_DJ")+"|"+Eval("CDD_NRO")+"|"+Eval("CDD_PREGUNTA")+"|"+Eval("CDD_TIPO")+"|"+Eval("CDD_LISTA") %>' Visible='<%# Eval("CDD_TIPO").ToString().Equals("TEXTO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server"></asp:TextBox>
													<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBox1" Enabled="false" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox1" runat="server" InitialValue="" Enabled='<%# Eval("CDD_TIPO").ToString().Equals("TEXTO".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' ErrorMessage="*"></asp:RequiredFieldValidator>--%>
																<asp:DropDownList ID="DropDownList1" ToolTip='<%# Eval("CDD_CONVOCATORIA_DDJJ")+"|"+Eval("CDJ_CONVOCATORIA_DJ")+"|"+Eval("CDD_NRO")+"|"+Eval("CDD_PREGUNTA")+"|"+Eval("CDD_TIPO")+"|"+Eval("CDD_LISTA") %>' CssClass="form-control" Visible='<%# Eval("CDD_TIPO").ToString().Equals("LISTA".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' runat="server">
																	<asp:ListItem>SI</asp:ListItem>
																	<asp:ListItem>NO</asp:ListItem>
																</asp:DropDownList>
												</div>    
												
											</ItemTemplate>
									 </asp:Repeater>
									 <br /><br />
									 <div class="form-group m-b-20 col-lg-6" style="float:left">
									  <p><asp:Label ID="lblDDJJTexto" CssClass="col-md-3" runat="server" Text=""></asp:Label>
                             <asp:Button ID="btnGuardarDDJJ" class="btn btn-success float-right" OnClick="btnGuardarDDJJ_Click" OnClientClick="return confirm('Estimado usuario, una vez aceptada la declaración jurada, su postulación será registrada y no podrá realizar cambios, está seguro que desea guardar su información?')" runat="server" Text="ACEPTAR" /></p>
							 </div>
									 </div>
								
								
                               <%-- <div class="panel-body">
					                <table id="data-table" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Nro</th>
								                <th class="text-nowrap">Pregunta</th>
								                <th class="text-nowrap">Respuesta</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater6" DataSourceID="odsDDJJ" OnItemDataBound="Repeater6_ItemDataBound" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblNro" runat="server" Text='<%# Eval("CDD_NRO") %>'></asp:Label></td>
																<td><asp:Label ID="lblPreguntas" runat="server" Text='<%# Eval("CDD_PREGUNTA") %>'></asp:Label></td>
																 <td>
																	 
                                                                     <asp:CheckBox ID="CheckBox1" Checked='<%# Eval("CDD_VALOR").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' Text="SI/NO" runat="server" ToolTip='<%# Eval("CDD_CONVOCATORIA_DDJJ")+"|"+Eval("CDJ_CONVOCATORIA_DJ")+"|"+Eval("CDD_NRO")+"|"+Eval("CDD_PREGUNTA") %>' />
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>--%>
                            </div>
							  
							
                        </asp:View>
						 <asp:View ID="View7" runat="server">
							  <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
									<div class="row">
										<h1 class="page-header">Imprime tu postulacion <small></small></h1>
										<br />
										 <div style="overflow-y: auto; height:600px;width:90%">
										<rsweb:ReportViewer ID="rv" runat="server" Height="100%" Width="90%" ShowZoomControl="False" ShowRefreshButton="False" ShowPageNavigationControls="True" ShowFindControls="False" ShowBackButton="False" SizeToReportContent="True"></rsweb:ReportViewer>
										</div>
									</div>
								  </div>
                        </asp:View>
					</asp:MultiView>
                        </div>
					<!-- end tab-content -->
                  <%--  <asp:Button ID="btnAnterior" class="btn btn-default" OnClick="btnAnterior_Click" runat="server" Text="Anterior" />
					<asp:Button ID="btnNext" class="btn btn-success" OnClick="btnNext_Click" runat="server" Text="Siguiente" />--%>
					
				</div>
				<!-- end col-6 -->
				
			</div>
			<!-- end row -->
		</div>
		<!-- end #content -->
</asp:Content>
