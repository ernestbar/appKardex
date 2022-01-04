<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cursos_Talleres.aspx.cs" Inherits="appRRHHDF.Cursos_Talleres" %>
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
	<asp:ObjectDataSource ID="odsTipoCapacitacion" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="TIPO CAPACITACION" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCursos" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Cursos_talleres">
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
				<li class="breadcrumb-item active">Cursos Talleres</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">TRABAJA CON NOSOTROS   <small></small></h1>
			<!-- end page-header -->
			
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
							<asp:LinkButton ID="lbtnEstudiosRealizados" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnEstudiosRealizados_Click" runat="server">Estudios Realizados</asp:LinkButton>
						
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnCursosTalleres" ForeColor="White" CausesValidation="false" class="nav-link active" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton>
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
					<asp:Label ID="lblAviso" ForeColor="Blue" Font-Size="Large" runat="server" Text=""></asp:Label>
						<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdCurso" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
					<div class="tab-content" style="padding:40px 0">
						
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12"  style="float:left;background:#fff">
                              <%-- <p> </p>--%>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarCursoTaller" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Curso/Taller" Width="220px" OnClick="btnAdicionarCursoTaller_Click"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Tipo Capacitación</th>
								                <th class="text-nowrap">Institución</th>
								                <th class="text-nowrap">Lugar</th>
								                <th class="text-nowrap">Duración</th>
								                <th class="text-nowrap">Fecha Inicio</th>
								                <th class="text-nowrap">Fecha Final</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							                <asp:Repeater ID="Repeater1" DataSourceID="odsCursos" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoCap" runat="server" Text='<%# Eval("DESC_TIPO_CAPACITACION") %>'></asp:Label></td>
																<td><asp:Label ID="lblInstitucion" runat="server" Text='<%# Eval("PCR_INSTITUCION") %>'></asp:Label></td>
																 <td><asp:Label ID="lblLugar" runat="server" Text='<%# Eval("PCR_CIUDAD") %>'></asp:Label></td>
																<td><asp:Label ID="lblDuracion" runat="server" Text='<%# Eval("PCR_TOTAL_HORAS") %>'></asp:Label></td>
																<td><asp:Label ID="lblFechaIni" runat="server" Text='<%# Eval("PCR_FECHA_INICIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblFechaFin" runat="server" Text='<%# Eval("PCR_FECHA_FIN") %>'></asp:Label></td>
																<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PCR_ID_CURSO") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar registro" />
																		<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PCR_ID_CURSO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />
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
                                        <span>Tipo Capacitación*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dllTipoCapacitacion" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="dllTipoCapacitacion" DataSourceID="odsTipoCapacitacion" DataTextField="dom_descripcion" OnDataBound="dllTipoCapacitacion_DataBound" DataValueField="dom_codigo" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server"></asp:DropDownList>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Nombre de la Institución*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombreInstitucion" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtNombreInstitucion" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server"  placeholder="CENTRO EDUCATIVO / INSTITUCION EDUCATIVA"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Ciudad*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCiudad" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCiudad" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server"  placeholder="CIUDAD"></asp:TextBox>
                                    </div>
                                
                                    <div class="form-group m-b-20  col-lg-3" style="float:left">     
                                        <span>Fecha Inicio*</span>
										<asp:Label ID="lblFecha1" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlIniDia" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniMes" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniMes" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniAño" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniAño" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida" runat="server" />                                     
                                    </div>
                                    <div class="form-group m-b-20  col-lg-3" style="float:left">     
                                        <span>Fecha Final*</span>
										 <asp:Label ID="lblFecha2" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlFinDia1" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinDia1" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinMes1" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinMes1" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinAño1" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinAño1" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida1" runat="server" />                                     
                                    </div>
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Total Horas*</span>
						               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTotalHoras" Font-Bold="True"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTotalHoras" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" Font-Size="Smaller" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						               <asp:TextBox ID="txtTotalHoras" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server"  placeholder="0"></asp:TextBox>
                                    </div>    
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Título obtenido (como se ha registrado en el diploma)*</span>
						               <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTituloObtenido" Font-Bold="True"></asp:RequiredFieldValidator>
						               <asp:TextBox ID="txtTituloObtenido" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server"  placeholder=" "></asp:TextBox>
                                    </div>    
                                    <div class="form-group m-b-20  col-lg-6" style="float:left">     
                                        <span>Fecha Emisión*</span>
										 <asp:Label ID="lblFecha3" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlTitDia2" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTitDia2" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlTitMes2" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTitMes2" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlTitAño2" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTitAño2" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida2" runat="server" />                                     
                                    </div>				                      
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
								
                            </div>	
							<diV class="row"></diV>
								 <div class="text-right m-b-0" style="float:right">
								    <div class="login-buttons col-lg-6" style="float:right;display:block">
                                            <asp:Button ID="btnCancelar" runat="server" class="btn btn-success btn-block btn-lg" Text="Cancelar" Width="120px" OnClick="btnCancelar_Click" CausesValidation="false" BackColor="transparent" FontColor="black" ForeColor="Black"/>
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
