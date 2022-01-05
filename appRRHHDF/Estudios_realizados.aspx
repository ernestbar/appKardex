<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Estudios_realizados.aspx.cs" Inherits="appRRHHDF.WebForm1" %>
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
                            control.className = "form-control form-control-lg ";
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
	<asp:Label ID="lblIdEstudios" runat="server" Visible="false" Text=""></asp:Label>
	<asp:ObjectDataSource ID="odsNivelEducacion" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="NIVEL ESTUDIO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsEstudios" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Estudios_realizados">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
    <!-- begin #content -->
		<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Perfil</a></li>
				<li class="breadcrumb-item active">Estudios Realizados</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">TRABAJA CON NOSOTROS   <small></small></h1>
			<!-- end page-header -->
			 <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
			<!-- begin row -->
			<div class="row">

				<!-- begin col-12 -->
				<div class="col-lg-12">
                    <!-- begin nav-tabs -->
					<ul class="nav nav-tabs" style="background-color:#6d6d6f;">
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosPersonales" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnDatosPersonales_Click" runat="server">Datos personales</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosFam" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnDatosFam_Click" runat="server">Datos familiares</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnEstudiosRealizados" ForeColor="blue" CausesValidation="false" class="nav-link active" OnClick="lbtnEstudiosRealizados_Click" runat="server">Estudios Realizados</asp:LinkButton>
						
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnCursosTalleres" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnNivelIdioma" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">Idiomas</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnExpLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnExpLaboral_Click" runat="server">Experiencia Laboral</asp:LinkButton>
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnRefLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnOtrosDatos" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnOtrosDatos_Click" runat="server">Otros Datos</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnResumen" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnResumen_Click" runat="server">Resumen</asp:LinkButton>
							
						</li>
					</ul>
					<!-- end nav-tabs -->
					<!-- begin tab-content -->
					<div class="tab-content" style="padding:40px 0">
						
						
                    <asp:MultiView ID="MultiView1" runat="server">
						
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
                             <%--  <p> </p>--%>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarEstudio" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Estudios" Width="220px" OnClick="btnAdicionarFam_Click"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Nivel de Estudio</th>
								                <th class="text-nowrap">Area de Estudio</th>
								                <th class="text-nowrap">Institución</th>
								                <th class="text-nowrap">Lugar</th>
								                <th class="text-nowrap">Fecha Inicio</th>
								                <th class="text-nowrap">Fecha Final</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater1" DataSourceID="odsEstudios" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("DESC_NIVEL_ESTUDIO") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("PES_AREA_ESTUDIO") %>'></asp:Label></td>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("PES_INSTITUCION") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("PES_CIUDAD") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("PES_FECHA_INICIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("PES_FECHA_FIN") %>'></asp:Label></td>
																<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar registro" />
																		<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PED_ID_ESTUDIO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />
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
                             <div  style="border-bottom:1px solid #6c757d;margin:13px;padding:8px">
							    <h3 class="m-t-10"></h3>
							</div>
                            <div class="conten_form">       
                                                                                               
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Nivel de Estudio*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dllNivelEstudio" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="dllNivelEstudio" DataSourceID="odsNivelEducacion" DataTextField="dom_descripcion" OnDataBound="dllNivelEstudio_DataBound" DataValueField="dom_codigo" ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Nombre de la Institución*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombreInstitucion" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtNombreInstitucion" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="CENTRO EDUCATIVO / INSTITUCION EDUCATIVA"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Ciudad*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCiudad" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCiudad" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="CIUDAD"></asp:TextBox>
                                    </div>
								 <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Area de estudio*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAreaEstudio" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtAreaEstudio" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="AREA DE ESTUDIO"></asp:TextBox>
                                    </div>
                                <div class="form-group m-b-20  col-lg-6" style="float:left">     
                                        <span>Fecha Inicio</span>
                                    <asp:Label ID="lblFecha1" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlIniDia" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniMes" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniMes" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniAño" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniAño" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida" runat="server" />                                     
                                    </div>
                                    <div class="form-group m-b-20  col-lg-6" style="float:left">     
                                        <span>Fecha Final</span>
										 <asp:Label ID="lblFecha2" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlFinDia1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinDia1" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinMes1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinMes1" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinAño1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinAño1" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida1" runat="server" />                                     
                                    </div>
					               
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Título obtenido (como se ha registrado en el diploma)*</span>
						               <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTituloOb" Font-Bold="True"></asp:RequiredFieldValidator>
						               <asp:TextBox ID="txtTituloOb" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder=" "></asp:TextBox>
                                    </div>    
                                     <div class="form-group m-b-20  col-lg-6" style="float:left">     
                                        <span>Fecha Emisión de Título</span>
										 <asp:Label ID="lblFecha3" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlTitDia2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTitDia2" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlTitMes2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTitMes2" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlTitAño2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTitAño2" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida2" runat="server" />                                     
                                    </div>		
					                       <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <br />  
										<%--<input type="checkbox" data-render="switchery" data-theme="default" checked />--%>
                                     <%--   <asp:CheckBox ID="ckbConcluido" data-render="switchery" data-theme="default" runat="server" />
                                        <span>Se ha concluido el estudio Formal</span>--%>
                                             <br />        <br />    <br />       <br />                      
                                    </div>
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
                            </div>	
                            <div class="row"></div>
							    <div class="text-right m-b-0" style="float:right">
								    <div class="login-buttons col-lg-6" style="float:right;display:block">
                                            <asp:Button ID="btnCancelar" runat="server" class="btn btn-success btn-block btn-lg" Text="Cancelar" CausesValidation="false" Width="120px" OnClick="btnCancelar_Click" BackColor="transparent" FontColor="black" ForeColor="Black"/>
                                    </div>
										<div class="login-buttons col-lg-6" style="float:right;display:block">
										<asp:Button ID="btnGuardar" runat="server" class="btn btn-success btn-block btn-lg" Text="Guardar" Width="120px" OnClick="btnGuardar_Click"/>
							        </div>
                                </div>
							<br /><br /><br /><br /><br /><br /><br /><br />
                        </asp:View>
					</asp:MultiView>
                        </div>
					<!-- end tab-content -->

				</div>
				<!-- end col-6 -->
				
			</div>
			<!-- end row -->
		</div>
		<!-- end #content -->
</asp:Content>
