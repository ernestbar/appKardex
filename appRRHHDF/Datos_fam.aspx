<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Datos_fam.aspx.cs" Inherits="appRRHHDF.Datos_fam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FFFFFF;
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
		<asp:ObjectDataSource ID="odsTipoDocumento" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="TIPO DOCUMENTO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsExpedido" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="EXPEDIDO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoParentesco" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDatosFam" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Datos_familiares">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
		 </asp:ObjectDataSource>
    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
	<asp:Label ID="lblIdPersonal" runat="server" Visible="false" Text=""></asp:Label>
	<asp:Label ID="lblIdDatosFam" runat="server" Visible="false" Text=""></asp:Label>
        <!-- begin #content -->
		<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Perfil</a></li>
				<li class="breadcrumb-item active">Datos Familiares</li>
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
							<asp:LinkButton ID="lbtnDatosPersonales" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnDatosPersonales_Click" runat="server">Datos personales</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosFam" CausesValidation="false" ForeColor="blue" class="nav-link active" OnClick="lbtnDatosFam_Click" runat="server">Datos familiares</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnEstudiosRealizados" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnEstudiosRealizados_Click" runat="server">Estudios Realizados</asp:LinkButton>
						
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnCursosTalleres" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnNivelIdioma" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">Idiomas</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnExpLaboral" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnExpLaboral_Click" runat="server">Experiencia Laboral</asp:LinkButton>
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnRefLaboral" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnOtrosDatos" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnOtrosDatos_Click" runat="server">Otros Datos</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnResumen" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnResumen_Click" runat="server">Resumen</asp:LinkButton>
							
						</li>
					</ul>
					<!-- end nav-tabs -->
					<!-- begin tab-content -->
					<div class="tab-content" style="padding:40px 0">
                        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>

                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
                               <p>
								Con el fin de analizar un posible vínculo consanguíneo o de afinidad (que por normativa podrían limitar tu contratación en la empresa) te pedimos puedas llenar el siguiente formulario en el que requerimos registres los datos de tu entorno anteriormente mencionados de hasta el 2do grado.
							   </p>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarFam" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Familiar" Width="220px" OnClick="btnAdicionarFam_Click"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Tipo de parentesco</th>
								                <th class="text-nowrap">Número de documento</th>
								                <th class="text-nowrap">Apellido Paterno</th>
								                <th class="text-nowrap">Apellido Materno</th>
								                <th class="text-nowrap">Nombres</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
											 <asp:Repeater ID="Repeater1" DataSourceID="odsDatosFam" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("DESC_TIPO_PARENTESCO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("POF_NUMERO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("POF_APELLIDO_PATERNO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("POF_APELLIDO_MATERNO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("POF_NOMBRES") %>'></asp:Label></td>
																<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("POF_ID_DATO_FAMILIAR") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar registro" />
																		<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("POF_ID_DATO_FAMILIAR") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />
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
							    <h3 class="m-t-10">Datos Generales</h3>
							</div>
                            <div class="conten_form">       
                                                                                               
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Tipo Parentesco*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dllTipoParectesco" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="dllTipoParectesco" DataSourceID="odsTipoParentesco" DataTextField="dom_descripcion" OnDataBound="dllTipoParectesco_DataBound" DataValueField="dom_codigo"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Apellido Paterno*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellidoPaterno" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtApellidoPaterno" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="APELLIDO PATERNO"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Apellido Materno*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtApellidoMaterno" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtApellidoMaterno" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="APELLIDO MATERNO"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Nombres*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombres" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtNombres" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NOMBRES"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Tipo Documento*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlTipoDocumento" DataSourceID="odsTipoDocumento" DataTextField="dom_descripcion" OnDataBound="ddlTipoDocumento_DataBound" DataValueField="dom_codigo" ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>      
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Número de Documento*</span>
						               <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNumeroDocumento" Font-Bold="True"></asp:RequiredFieldValidator>
						               <asp:TextBox ID="txtNumeroDocumento" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NUMERO DE DOCUMENTO"></asp:TextBox>
                                    </div>                                           
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Complemento</span>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtComplemento" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						                <asp:TextBox ID="txtComplemento" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="COMPLEMENTO"></asp:TextBox>
                                    </div>     
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Expedido en*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlExpedido" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlExpedido" DataSourceID="odsExpedido" DataTextField="dom_descripcion" OnDataBound="ddlExpedido_DataBound" DataValueField="dom_codigo"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>         
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
                            </div>	
                            <div class="row"></div>
							    <div class="text-right m-b-0" style="float:right">
								    <div class="login-buttons col-lg-6" style="float:right;display:block">
                                            <asp:Button ID="btnCancelar" runat="server" class="btn btn-success btn-block btn-lg" CausesValidation="false" Text="Cancelar" Width="120px" OnClick="btnCancelar_Click1" BackColor="transparent" FontColor="black" ForeColor="Black"/>
                                    </div>
										<div class="login-buttons col-lg-6" style="float:right;display:block">
										<asp:Button ID="btnGuardar" runat="server" class="btn btn-success btn-block btn-lg" Text="Guardar" Width="120px" OnClick="btnGuardar_Click1"/>
							        </div>
                                </div>
							<br /><br />
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
