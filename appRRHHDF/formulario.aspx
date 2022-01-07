<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="formulario.aspx.cs" Inherits="appRRHHDF.formulario" %>
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
	<asp:ObjectDataSource ID="odsGenero" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="GENERO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsEstadoCivil" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="ESTADO CIVIL" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Paises">
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Ciudades">
			<SelectParameters>
				<asp:ControlParameter Name="PI_ID_PAIS" ControlID="ddlPaisRes" DefaultValue="0" />
			</SelectParameters>
		 </asp:ObjectDataSource>
    <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
    <!-- begin #content -->
		<div id="content" class="content">
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Perfil</a></li>
				<li class="breadcrumb-item active">Datos Personales</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">TABS DE NAVEGACIÓN   <small></small></h1>
			<!-- end page-header -->
			
			<!-- begin row -->
			<div class="row">
				<asp:Label ID="lblAviso" ForeColor="Blue" Font-Size="Large" runat="server" Text=""></asp:Label>
				<!-- begin col-6 -->
				<div class="col-lg-12">
					<!-- begin nav-tabs -->
					<ul class="nav nav-tabs">
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosPersonales" CausesValidation="false" ForeColor="blue" class="nav-link active" OnClick="lbtnDatosPersonales_Click" runat="server">Datos personales</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosFam" CausesValidation="false" ForeColor="White" class="nav-link" OnClick="lbtnDatosFam_Click" runat="server">Datos familiares</asp:LinkButton>
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
					<div class="tab-content">
						<!-- begin tab-pane -->
						<div class="tab-pane fade active show" id="default-tab-1">
                            <div  class="form-group m-b-20 col-lg-12" style="border-bottom:1px solid #6c757d;margin:13px;padding:8px">
							    <h3 class="m-t-10"> Datos Generales</h3>								
							</div>	
                             <div class="conten_form">
							    <div class="form-group m-b-20 col-lg-9" style="float:left;display:block;margin-left:5px;">
                                            <span>Fotografía </span>
                                         <asp:FileUpload ID="fuFoto" ForeColor="Black" class="form-control form-control-lg " runat="server" />
                                        <br /><br />    
                                </div>
                                <div class="form-group m-b-20 col-lg-2" style="float:left;display:block;margin-left:5px;">
                                              <div>									      
                                            <asp:Image ID="imgFoto" Height="80px" runat="server" />
									            </div>
                                 </div>	
                             </div>	     
                            <div class="conten_form">
								 
                                  <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Primer Apellido* </span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPrimerApellido" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPrimerApellido" runat="server" class="form-control form-control-lg" placeholder="PRIMER APELLIDO" ForeColor="Black" ></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20  col-lg-4" style="float:left"> 
                                        <span>Segundo Apellido* </span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSegundoApellido" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtSegundoApellido" runat="server" class="form-control form-control-lg" placeholder="SEGUNDO APELLIDO" ForeColor="Black" ></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-4" style="float:left">                        
                                        <span>Apellido de Casada</span>
                                        <asp:TextBox ID="txtApellidoCasada" runat="server" class="form-control form-control-lg " ForeColor="Black" placeholder="APELLIDO DE CASADA"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">                        
                                        <span>Nombres*  </span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtnombres" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtNombres" runat="server" class="form-control form-control-lg " ForeColor="Black" placeholder="NOMBRES"></asp:TextBox>
                                    </div>                                    
                                    <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Tipo Documento*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlTipoDocumento" DataSourceID="odsTipoDocumento" DataTextField="dom_descripcion" OnDataBound="ddlTipoDocumento_DataBound" DataValueField="dom_codigo"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>
					                <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Número Documento*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNumeroDocumento" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtNumeroDocumento" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NUMERO DE DOCUMEUNTO"></asp:TextBox>
                                    </div>
					                <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Complemento</span>
						                <asp:TextBox ID="txtComplemento" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="COMPLEMENTO"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Expedido en*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlExpedido" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlExpedido"  ForeColor="Black" DataSourceID="odsExpedido" OnDataBound="ddlExpedido_DataBound" DataTextField="dom_descripcion" DataValueField="dom_codigo" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group m-b-20  col-lg-4" style="float:left">                        
                                        <span>Fecha de Nacimiento*</span>
										 <asp:Label ID="lblFecha" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtfecha" Font-Bold="True"></asp:RequiredFieldValidator>--%>
                                        <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlNacDia" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacMes" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacMes" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlNacAño" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlNacAño" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<%--<asp:TextBox ID="txtfecha" type="date" runat="server" class="form-control form-control-lg " ForeColor="Black" ></asp:TextBox>  --%>
										<%--<input id="fecha_salida" class="form-control" type="date" required>--%>
										<asp:HiddenField ID="hfFechaSalida" runat="server" />
                                    </div>
                                    <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Estado civil*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlEsdatoCivil" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlEsdatoCivil" DataSourceID="odsEstadoCivil" OnDataBound="ddlEsdatoCivil_DataBound" DataTextField="dom_descripcion" DataValueField="dom_codigo"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>
					                <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Género*</span>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlGenero" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlGenero" DataSourceID="odsGenero" OnDataBound="ddlGenero_DataBound" DataTextField="dom_descripcion" DataValueField="dom_codigo"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>
                            </div>
                            <div  style="border-bottom:1px solid #6c757d;margin:13px;padding:8px">
							    <h3 class="m-t-10"> Residencia actual</h3>
							</div>
                            <div class="conten_form">                                                                     
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>País de Residencia*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPaisRes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlPaisRes" OnDataBound="ddlPaisRes_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddlPaisRes_SelectedIndexChanged" DataSourceID="odsPais" DataTextField="PAI_PAIS" DataValueField="PAI_ID_PAIS"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Departamento de Residencia*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDepartaentoRes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlDepartaentoRes" DataSourceID="odsCiudad" OnDataBound="ddlDepartaentoRes_DataBound" DataTextField="CIU_CIUDAD" DataValueField="CIU_ID_CIUDAD"  ForeColor="Black" class="form-control form-control-lg " runat="server"></asp:DropDownList>
                                    </div>
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Ciudad de Residencia*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCiudadRes" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCiudadRes" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="CUIDAD"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Dirección</span>
						                <asp:TextBox ID="txtDireccion" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DIRECCIÓN"></asp:TextBox>
                                    </div>
                            </div>	
                             <div  style="border-bottom:1px solid #6c757d;margin:13px;padding:8px">
							    <h3 class="m-t-10">Datos del contacto</h3>
							</div>
                            <div class="conten_form">                
					                <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Correo Electrónico*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtEmail" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="Correo Electrónico"></asp:TextBox>
                                    </div>
								 <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Cargo*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCargo" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCargo" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="Cargo"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Teléfono de Domicilio</span>
						                <asp:TextBox ID="txtTelefono" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NÚMERO DE TELÉFONO"></asp:TextBox>
                                    </div>                                           
					                <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Celular*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCelular" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NÚMERO DE CELULAR"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
                            </div>	
                            <div class="row"></div>
							<div class="text-right m-b-0" style="float:right">
								<div class="login-buttons col-lg-12">
                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-success btn-block btn-lg"  Text="Guardar" Width="150px"/>
                                </div>
							</div>
						</div>
						<br /><br />
						<!-- end tab-pane -->
						<!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-2">
                            <div class="m-b-20 col-lg-12" style="float:left">
                               <p>
								Con el fin de analizar un posible vínculo consanguíneo o de afinidad (que por normativa podrían limitar tu contratación en la empresa) te pedimos puedas llenar el siguiente formulario en el que requerimos registres los datos de tu entorno anteriormente mencionados de hasta el 2do grado.
							   </p>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarFam" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Familiar" Width="220px"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Tipo de parentesco</th>
								                <th class="text-nowrap">Numero de documentor</th>
								                <th class="text-nowrap">Apellido Paterno</th>
								                <th class="text-nowrap">Apellido Materno</th>
								                <th class="text-nowrap">Nombres</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							                <tr class="odd gradeX">
								                <td>HERMANO</td>
								                <td>66666660</td>
								                <td>Win 95+</td>
								                <td>4</td>
								                <td>X</td>
								                <td></td>
							                </tr>
							                <tr class="even gradeC">
								                <td>PADRE</td>
								                <td>1231234</td>
								                <td>Win 95+</td>
								                <td>5</td>
								                <td>C</td>
								                <td></td>
							                </tr>
							                <tr class="odd gradeA">
								                <td>MADRE</td>
								                <td>3423435</td>
								                <td>Win 95+</td>
								                <td>5.5</td>
								                <td>A</td>
								                <td></td>
							                </tr>
						                </tbody>
					                </table>
				                </div>
                            </div> 
                            <p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
						<!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-3">
							<p>
								<span class="fa-stack fa-4x pull-left m-r-10">
									<i class="fa fa-square-o fa-stack-2x"></i>
									<i class="fab fa-twitter fa-stack-1x"></i>
								</span>
								Praesent tincidunt nulla ut elit vestibulum viverra. Sed placerat magna eget eros accumsan elementum. 
								Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis lobortis neque. 
								Maecenas justo odio, bibendum fringilla quam nec, commodo rutrum quam. 
								Donec cursus erat in lacus congue sodales. Nunc bibendum id augue sit amet placerat. 
								Quisque et quam id felis tempus volutpat at at diam. Vivamus ac diam turpis.Sed at lacinia augue. 
								Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
								Sed at lacinia augue. Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
							</p>
                            <p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
                        <!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-4">
							<h3 class="m-t-10"><i class="fa fa-cog"></i> Lorem ipsum dolor sit amet</h3>
							<p>
								Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
								Integer ac dui eu felis hendrerit lobortis. Phasellus elementum, nibh eget adipiscing porttitor, 
								est diam sagittis orci, a ornare nisi quam elementum tortor. Proin interdum ante porta est convallis 
								dapibus dictum in nibh. Aenean quis massa congue metus mollis fermentum eget et tellus. 
								Aenean tincidunt, mauris ut dignissim lacinia, nisi urna consectetur sapien, nec eleifend orci eros id lectus.
							</p>
							<p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
						<!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-5">
							<blockquote>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
								<small>Someone famous in <cite title="Source Title">Source Title</cite></small>
							</blockquote>
							<h4>Lorem ipsum dolor sit amet</h4>
							<p>
								Nullam ac sapien justo. Nam augue mauris, malesuada non magna sed, feugiat blandit ligula. 
								In tristique tincidunt purus id iaculis. Pellentesque volutpat tortor a mauris convallis, 
								sit amet scelerisque lectus adipiscing.
							</p>
                            <p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
						<!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-6">
							<p>
								<span class="fa-stack fa-4x pull-left m-r-10">
									<i class="fa fa-square-o fa-stack-2x"></i>
									<i class="fab fa-twitter fa-stack-1x"></i>
								</span>
								Praesent tincidunt nulla ut elit vestibulum viverra. Sed placerat magna eget eros accumsan elementum. 
								Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis lobortis neque. 
								Maecenas justo odio, bibendum fringilla quam nec, commodo rutrum quam. 
								Donec cursus erat in lacus congue sodales. Nunc bibendum id augue sit amet placerat. 
								Quisque et quam id felis tempus volutpat at at diam. Vivamus ac diam turpis.Sed at lacinia augue. 
								Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
								Sed at lacinia augue. Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
							</p>
                            <p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
                        <!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-7">
							<h3 class="m-t-10"><i class="fa fa-cog"></i> Lorem ipsum dolor sit amet</h3>
							<p>
								Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
								Integer ac dui eu felis hendrerit lobortis. Phasellus elementum, nibh eget adipiscing porttitor, 
								est diam sagittis orci, a ornare nisi quam elementum tortor. Proin interdum ante porta est convallis 
								dapibus dictum in nibh. Aenean quis massa congue metus mollis fermentum eget et tellus. 
								Aenean tincidunt, mauris ut dignissim lacinia, nisi urna consectetur sapien, nec eleifend orci eros id lectus.
							</p>
							<p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
						<!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-8">
							<blockquote>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
								<small>Someone famous in <cite title="Source Title">Source Title</cite></small>
							</blockquote>
							<h4>Lorem ipsum dolor sit amet</h4>
							<p>
								Nullam ac sapien justo. Nam augue mauris, malesuada non magna sed, feugiat blandit ligula. 
								In tristique tincidunt purus id iaculis. Pellentesque volutpat tortor a mauris convallis, 
								sit amet scelerisque lectus adipiscing.
							</p>
                            <p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
						<!-- begin tab-pane -->
						<div class="tab-pane fade" id="default-tab-9">
							<p>
								<span class="fa-stack fa-4x pull-left m-r-10">
									<i class="fa fa-square-o fa-stack-2x"></i>
									<i class="fab fa-twitter fa-stack-1x"></i>
								</span>
								Praesent tincidunt nulla ut elit vestibulum viverra. Sed placerat magna eget eros accumsan elementum. 
								Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis lobortis neque. 
								Maecenas justo odio, bibendum fringilla quam nec, commodo rutrum quam. 
								Donec cursus erat in lacus congue sodales. Nunc bibendum id augue sit amet placerat. 
								Quisque et quam id felis tempus volutpat at at diam. Vivamus ac diam turpis.Sed at lacinia augue. 
								Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
								Sed at lacinia augue. Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
							</p>
                            <p class="text-right m-b-0">
								<a href="javascript:;" class="btn btn-white m-r-5">Default</a>
								<a href="javascript:;" class="btn btn-primary">Primary</a>
							</p>
						</div>
						<!-- end tab-pane -->
					</div>
					<!-- end tab-content -->
					
				</div>
				<!-- end col-6 -->
				
			</div>
			<!-- end row -->
		</div>
		<!-- end #content -->



    <%--<script type="text/javascript">

        $(function () {

            $("[id$=txtCi]").autocomplete({

                source: function (request, response) {

                    $.ajax({

                        url: '<%=ResolveUrl("~/Service.asmx/GetCustomers") %>',

                        data: "{ 'prefix': '" + request.term + "'}",

                        dataType: "json",

                        type: "POST",

                        contentType: "application/json; charset=utf-8",

                        success: function (data) {

                            response($.map(data.d, function (item) {

                                return {

                                    label: item.split('|')[0],

                                    val: item.split('|')[1]

                                }

                            }))

                        },

                        error: function (response) {

                            alert(response.responseText);

                        },

                        failure: function (response) {

                            alert(response.responseText);

                        }

                    });

                },

                select: function (e, i) {

                    $("[id$=hfCustomerId]").val(i.item.val);

                },

                minLength: 1

            });

		});



        $(function () {

            $("[id$=txtNit]").autocomplete({

                source: function (request, response) {

                    $.ajax({

                        url: '<%=ResolveUrl("~/Service.asmx/GetCustomersJ") %>',

                        data: "{ 'prefix': '" + request.term + "'}",

                        dataType: "json",

                        type: "POST",

                        contentType: "application/json; charset=utf-8",

                        success: function (data) {

                            response($.map(data.d, function (item) {

                                return {

                                    label: item.split('|')[0],

                                    val: item.split('|')[1]

                                }

                            }))

                        },

                        error: function (response) {

                            alert(response.responseText);

                        },

                        failure: function (response) {

                            alert(response.responseText);

                        }

                    });

                },

                select: function (e, i) {

                    $("[id$=hfCustomerId2]").val(i.item.val);

                },

                minLength: 1

            });

		});

        

           

        

    </script>--%>

</asp:Content>
