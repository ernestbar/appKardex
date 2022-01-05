<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Referencia_Laboral.aspx.cs" Inherits="appRRHHDF.Referencia_Laboral" %>
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
	<asp:ObjectDataSource ID="odsReferenciasLaborales" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Referencias_laborales">
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
				<li class="breadcrumb-item active">Referencias Laborales</li>
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
							<asp:LinkButton ID="lbtnCursosTalleres" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnNivelIdioma" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">Idiomas</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnExpLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnExpLaboral_Click" runat="server">Experiencia Laboral</asp:LinkButton>
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnRefLaboral" ForeColor="blue" CausesValidation="false" class="nav-link active" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton>
							
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
						<asp:Label ID="lblAviso" ForeColor="Blue" Font-Size="Large" runat="server" Text=""></asp:Label>
						<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdReferencia" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
                              <%-- <p></p>--%>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarReferenciaLaboral" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Referencia Laboral" Width="260px" OnClick="btnAdicionarReferenciaLaboral_Click"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Nro.</th>
								                <th class="text-nowrap">Empresa</th>
								                <th class="text-nowrap">Cargo</th>
								                <th class="text-nowrap">Relación Laboral</th>
								                <th class="text-nowrap">Contactos</th>
								                <th class="text-nowrap">Correo Electrónico</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							                <asp:Repeater ID="Repeater1" DataSourceID="odsReferenciasLaborales" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblNro" runat="server" Text='<%# Eval("NRO") %>'></asp:Label></td>
																 <td><asp:Label ID="lblEmpresa" runat="server" Text='<%# Eval("PRE_EMPRESA") %>'></asp:Label></td>
																<td><asp:Label ID="lblCargo" runat="server" Text='<%# Eval("PRE_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblRelLab" runat="server" Text='<%# Eval("PRE_RELACION_LABORAL") %>'></asp:Label></td>
																<td><asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("PRE_TELEFONO") %>'></asp:Label> - <asp:Label ID="Label1" runat="server" Text='<%# Eval("PRE_TELEFONO") %>'></asp:Label></td>
																 <td><asp:Label ID="lblCorreo" runat="server" Text='<%# Eval("PRE_EMAIL") %>'></asp:Label></td>
																<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PRE_ID_REFRENCIA") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar registro" />
																		<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PRE_ID_REFRENCIA") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />
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
                                        <span>Empresa*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmpresa" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtEmpresa" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="EMPRESA"></asp:TextBox>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Cargo*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCargo" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCargo" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="CARGO"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Relación Laboral*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRelacionLaboral" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtRelacionLaboral" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="RELACIÒN LABORAL"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Teléfono*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelefono" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtTelefono" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NÙMERO DE TELEFONO"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Celular*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCelular" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NÙMERO DE CELULAR"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Correo Electrónico*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCorreoElectronico" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCorreoElectronico" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="CORREO ELECTRÒNICO"></asp:TextBox>
                                    </div>
                                 					                      
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
                            </div>	
                            <div class="row"></div>
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
