<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Otros_Datos.aspx.cs" Inherits="appRRHHDF.Otros_Datos" %>
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
	<asp:ObjectDataSource ID="odsOtroDocumento" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="OTRO DOCUMENTO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDocumentos" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Otros_documentos">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
			</SelectParameters>
		 </asp:ObjectDataSource>
     <!-- begin #content -->
		<div id="content" class="content">

            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Perfil</a></li>
				<li class="breadcrumb-item active">Otros Datos</li>
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
							<asp:LinkButton ID="lbtnRefLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnOtrosDatos" ForeColor="White" CausesValidation="false" class="nav-link active" OnClick="lbtnOtrosDatos_Click" runat="server">Otros Datos</asp:LinkButton>
							
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
						<asp:Label ID="lblIdOtrosDatos" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12"  style="float:left;background:#fff">
                             <p>
								Favor registre información complementaria que considere importante para completar su perfil, en caso de cometer algún error en el registro puede eliminar el mismo e iniciar nuevamente.
							   </p>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnOtrosDatos" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Otros Datos" Width="220px" OnClick="btnOtrosDatos_Click"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">Tipo Documento</th>
								                <th class="text-nowrap">Descripción</th>
												<th class="text-nowrap">Archivo</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater1" DataSourceID="odsDocumentos" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("DESC_TIPO_OTRO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("PTR_DESCRIPCION") %>'></asp:Label></td>
																 <td><asp:Label ID="lblUrl" runat="server" Text='<%# Eval("PTR_URL") %>'></asp:Label></td>
																<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PRE_ID_OTRO_DOCUMENTO") %>' OnClick="btnEditar_Click" runat="server" Text="Descargar" ToolTip="Descargar archivo" />
																		<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PRE_ID_OTRO_DOCUMENTO") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />
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
                                        <span>Seleccion de Documento*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="fuDocumento" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:FileUpload ID="fuDocumento" class="form-control form-control-lg inverse-mode" ForeColor="Black" runat="server" />
                                    </div>                                                               
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Tipo de Documento*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="dllTipoDocumento" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="dllTipoDocumento"  DataSourceID="odsOtroDocumento" DataTextField="dom_descripcion" OnDataBound="dllTipoDocumento_DataBound" DataValueField="dom_codigo" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server"></asp:DropDownList>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Descripción*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDescripcion" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtDescripcion" ForeColor="Black" class="form-control form-control-lg inverse-mode" runat="server" TextMode="MultiLine"  placeholder="DESCRIPCÌON"></asp:TextBox> 
                                       <span>Máximo hasta 200 carácteres</span>
                                    </div> 
					                      
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
                            </div>	
                            <div class="row"></div>
							    <div class="text-right m-b-0" style="float:right">
								    <div class="login-buttons col-lg-6" style="float:right;display:block">
                                            <asp:Button ID="btnCancelar" runat="server" CausesValidation="false" class="btn btn-success btn-block btn-lg" Text="Cancelar" Width="120px" OnClick="btnCancelar_Click" BackColor="transparent" FontColor="black" ForeColor="Black"/>
                                           </div>
										<div class="login-buttons col-lg-6" style="float:right;display:block">
										<asp:Button ID="btnGuardar" runat="server" class="btn btn-success btn-block btn-lg" Text="Guardar" Width="120px" OnClick="btnGuardar_Click"/>
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
