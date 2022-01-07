<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Experiencia_Laboral.aspx.cs" Inherits="appRRHHDF.Experiencia_Laboral" %>
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
    <asp:ObjectDataSource ID="odsExperienciaLaboral" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Experiencia_Laboral">
        <SelectParameters>
             <asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
       </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMotivoDesvinculacion" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="DESVINCULACION" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
    <!-- begin #content -->
		<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Perfil</a></li>
				<li class="breadcrumb-item active">Experiencia Laboral</li>
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
					<ul class="nav nav-tabs">
						<li class="nav-items"><asp:LinkButton ID="lbtnDatosPersonales" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnDatosPersonales_Click" runat="server">Datos personales</asp:LinkButton></li>
						<li class="nav-items"><asp:LinkButton ID="lbtnDatosFam" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnDatosFam_Click" runat="server">Datos familiares</asp:LinkButton>	</li>
						<li class="nav-items"><asp:LinkButton ID="lbtnEstudiosRealizados" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnEstudiosRealizados_Click" runat="server">Estudios Realizados</asp:LinkButton>	</li>
                        <li class="nav-items"><asp:LinkButton ID="lbtnCursosTalleres" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton>	</li>
						<li class="nav-items"><asp:LinkButton ID="lbtnNivelIdioma" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">Idiomas</asp:LinkButton>	</li>
						<li class="nav-items"><asp:LinkButton ID="lbtnExpLaboral" ForeColor="blue" CausesValidation="false" class="nav-link active" OnClick="lbtnExpLaboral_Click" runat="server">Experiencia Laboral</asp:LinkButton>	</li>
                        <li class="nav-items"><asp:LinkButton ID="lbtnRefLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton>	</li>
						<li class="nav-items"><asp:LinkButton ID="lbtnOtrosDatos" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnOtrosDatos_Click" runat="server">Otros Datos</asp:LinkButton>	</li>
						<li class="nav-items"><asp:LinkButton ID="lbtnResumen" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnResumen_Click" runat="server">Resumen</asp:LinkButton>	</li>
					</ul>
					<!-- end nav-tabs -->
					<!-- begin tab-content -->
					<div class="tab-content" style="padding:40px 0">
                        <asp:Label ID="lblAviso" ForeColor="Blue" Font-Size="Large" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	                    <asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblIdExperiencia" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                             <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
                              <%-- <p></p>--%>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarExperienciaLaboral" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Experiencia Laboral" Width="270px" OnClick="btnAdicionarExperienciaLaboral_Click"/>
                                    </div>
                               <div>
                                  <div class="panel-body">
					                                                          
                                            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="odsExperienciaLaboral">
                                                <ItemTemplate>
							                         <div class="conten_form" style="border:1px solid #d8dfeb; position:relative; padding:10px;float:left;">       
                                                             <div class="conten_form">                        
                                                                <div class="form-group m-b-20 col-lg-8" style="float:left">
                                                                    <span>Empresa</span>
                                                                    <asp:TextBox ID="txtEmpresaV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_EMPRESA") %>'></asp:TextBox>
                                                                </div>                                   
                                                               <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Cargo de inicio</span>
                                                                    <asp:TextBox ID="txtCargoInicioV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_CARGO") %>'></asp:TextBox>
                                                                </div>
                                                              <%--  <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Nro. Dependientes</span>
                                                                    <asp:TextBox ID="txtNroDependientesV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_NRO_DEPENDIENTES_CARGO") %>'></asp:TextBox>
                                                                </div>--%>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Experiencia en Años </span>
                                                                    <asp:TextBox ID="TextBox1" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA") %>'></asp:TextBox>
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Funciones</span>
                                                                    <asp:TextBox ID="txtFuncionesV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FUNCIONES_CARGO") %>'></asp:TextBox>
                                                                </div>
									                            <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Inicio</span>
                                                                    <asp:TextBox ID="txtFechaIniV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_INICIO_CARGO") %>'></asp:TextBox>
                                                                    <%-- <asp:TextBox ID="txtFechaIniV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_INICIO_CARGO") %>'></asp:TextBox>     --%>                               
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Final</span>
                                                                    <asp:TextBox ID="txtFechaFinV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_FIN_CARGO") %>'></asp:TextBox>
                                                                    <%-- <asp:TextBox ID="txtFechaFinV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_FIN_CARGO") %>'></asp:TextBox>    --%>                               
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Departamento</span>
                                                                    <asp:TextBox ID="txtDepartamentoV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_CARGO") %>'></asp:TextBox>
                                                                </div>
                                                                  <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <br />  
                                                                    <%--<asp:CheckBox ID="ckbCargoActualV" runat="server"  Text='<%# Eval("PEX_ACTUAL_CARGO") %>'/>--%>
                                                                    <span>Actualmente </span>   <asp:label  ID="lblCargoActualV" runat="server" Text='<%# Eval("PEX_ACTUAL_CARGO") %>' ></asp:label>   <span> continua en el cargo</span>
                                                                         <br />        <br />    <br />       <br />                      
                                                                </div>
                                                                <div class="form-group m-b-20 col-lg-12" style="float:left">
                                                                    <span>Desvinculación</span>
						                                            <asp:TextBox ID="txtDesvinculacionV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("DES_MOTIVO_DESVINCULACION")%>'></asp:TextBox>
                                                                </div>   
                                                                 <asp:Panel ID="Panel1" Visible='<%# Eval("PEX_CARGO1_VISIBLE") %>' runat="server">
                                                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Otro cargo 1</span>
                                                                    <asp:TextBox ID="txtOtroCargo1V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_OTRO_CARGO1") %>'></asp:TextBox>
                                                                </div>                                                                
                                                               <%-- <div class="form-group m-b-20 col-lg-2" style="float:left">
                                                                    <span>Nro. Dependientes</span>
                                                                    <asp:TextBox ID="txtNroDependientesOtro1V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_NRO_DEPENDIENTES_OTRO1") %>'></asp:TextBox>
                                                                </div>--%>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Experiencia Años</span>
                                                                    <asp:TextBox ID="TextBox2" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA_OTRO1") %>'></asp:TextBox>
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Funciones Otro Cargo 1</span>
                                                                    <asp:TextBox ID="txtFuncionesOtro1V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FUNCIONES_OTRO1") %>'></asp:TextBox>
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Inicio</span>
                                                                     <asp:TextBox ID="txtFechaIniOtro1V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_INICIO_OTRO1") %>'></asp:TextBox>                                    
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Final</span>
                                                                     <asp:TextBox ID="txtFechaFinOtro1V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_FIN_OTRO1") %>'></asp:TextBox>                                   
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Departamento Otro Cargo 1</span>
                                                                    <asp:TextBox ID="txtDepartamentoOtro1V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_OTRO1") %>'></asp:TextBox>
                                                                </div>
                                                                 </asp:Panel>
                                                               
                                                                     <asp:Panel ID="Panel2" Visible='<%# Eval("PEX_CARGO2_VISIBLE") %>' runat="server">
                                                                      <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Otro cargo 2</span>
                                                                   <asp:TextBox ID="txtOtroCargo2V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server"  Text='<%# Eval("PEX_OTRO_CARGO2") %>'></asp:TextBox>
                                                                </div>                                                                
                                                             <%--   <div class="form-group m-b-20 col-lg-2" style="float:left">
                                                                    <span>Nro. Dependientes</span>
                                                                    <asp:TextBox ID="txtNroDependientesOtro2V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_NRO_DEPENDIENTES_OTRO2") %>'></asp:TextBox>
                                                                </div>--%>
                                                                   <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Experiencia Años</span>
                                                                    <asp:TextBox ID="TextBox3" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA_OTRO2") %>'></asp:TextBox>
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Funciones Otro Cargo 1</span>
                                                                    <asp:TextBox ID="txtFuncionesOtro2V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FUNCIONES_OTRO2") %>'></asp:TextBox>
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Inicio</span>
                                                                     <asp:TextBox ID="txtFechaIniOtro2V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_INICIO_OTRO2") %>'></asp:TextBox>                                    
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Final</span>
                                                                     <asp:TextBox ID="txtFechaFinOtro2V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_FIN_OTRO2") %>'></asp:TextBox>                                   
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Departamento  Otro Cargo 2</span>
                                                                    <asp:TextBox ID="txtDepartamentoOtro2V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_OTRO2") %>'></asp:TextBox>
                                                                </div>
                                                                 </asp:Panel>
					                                           
                                                                    <asp:Panel ID="Panel3" Visible='<%# Eval("PEX_CARGO3_VISIBLE") %>' runat="server">
                                                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Otro cargo 3</span>
                                                                    <asp:TextBox ID="txtOtroCargo3V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_OTRO_CARGO3") %>'></asp:TextBox>
                                                                </div>                                                                
                                                                <%--<div class="form-group m-b-20 col-lg-2" style="float:left">
                                                                    <span>Nro. Dependientes</span>
                                                                    <asp:TextBox ID="txtNroDependientesOtro3V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_NRO_DEPENDIENTES_OTRO3") %>'></asp:TextBox>
                                                                </div>--%>
                                                                   <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Experiencia Años</span>
                                                                    <asp:TextBox ID="TextBox4" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA_OTRO3") %>'></asp:TextBox>
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Funciones Otro Cargo 3</span>
                                                                    <asp:TextBox ID="txtFuncionesOtro3V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FUNCIONES_OTRO3") %>'></asp:TextBox>
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Inicio</span>
                                                                     <asp:TextBox ID="txtFechaIniOtro3V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_INICIO_OTRO3") %>'></asp:TextBox>                                    
                                                                </div>
                                                                <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                                                    <span>Fecha Final</span>
                                                                     <asp:TextBox ID="txtFechaFinOtro3V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_FECHA_FIN_OTRO3") %>'></asp:TextBox>                                   
                                                                </div>
                                                                 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Departamento  Otro Cargo 3</span>
                                                                    <asp:TextBox ID="txtDepartamentoOtro3V" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_OTRO3") %>'></asp:TextBox>
                                                                </div>
                                                                 </asp:Panel>
					                                            

                                                              <%--    <div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Desvinculacion</span>
                                                                    <asp:TextBox ID="txtDesvinculacionOtro" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" Text='<%# Eval("PEX_DESVINCULACION_OTRO") %>'></asp:TextBox>
                                                                </div>--%>
					                                            
                                                                <%--<div class="form-group m-b-20 col-lg-4" style="float:left">
                                                                    <span>Total Experiencia Dias</span>
						                                           <asp:TextBox ID="txtTotalExperienciaV" ForeColor="Black" BackColor="#dae0ec" class="form-control form-control-lg " runat="server" ReadOnly="true" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA") %>'></asp:TextBox>
									                             </div>--%>                                         
                                                        </div>	
                                                            <div class="row col-lg-12" style="border:1px solid #dae0ec;margin:10px"></div>
							                                <div class="text-right m-b-0" style="float:right">
								                                <div class="login-buttons col-lg-12" style="float:right;display:block;;margin:0 30px">
                                                                    <div class="form-group m-b-6 col-lg-4" style="float:left;display:block">
                                                                        <asp:Button ID="btnEditar" runat="server" class="btn btn-success btn-block btn-lg" Text="Editar" Width="120px" FontColor="black" CommandArgument='<%# Eval("PEX_ID_EXPERIENCIA") %>' OnClick="btnEditar_Click"  ToolTip="Editar registro" />
                                                                    </div>
                                                                    <div class="form-group m-b-6 col-lg-4" style="float:right;display:block">
											                            <asp:Button ID="btnEliminar" class="btn btn-success btn-block btn-lg" Enabled="true" CommandArgument='<%# Eval("PEX_ID_EXPERIENCIA") %>' OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Eliminar Registro" BackColor="Orange"  OnClientClick="return confirm('Seguro que desea eliminar el registro???')" FontColor="White" Width="120px"/>
										                            </div>
									                            </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                            </asp:Repeater>						                
				                </div>
                               </div>
                            </div> 
                        </asp:View>
                        
                       <asp:View ID="View2" runat="server">
                             <div  style="border-bottom:1px solid #6c757d;margin:13px;padding:8px">
							    <h3 class="m-t-10"></h3>
							</div>
                            <div class="conten_form">       
                                    <div class="conten_form">                        
                                    <div class="form-group m-b-20 col-lg-8" style="float:left">
                                        <span>Empresa *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmpresa" Font-Bold="True"></asp:RequiredFieldValidator>
						                 <asp:TextBox ID="txtEmpresa" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="EMPRESA"></asp:TextBox>
                                    </div>                                   
                                   <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Cargo de inicio *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCargoInicio" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtCargoInicio" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="NOMBRE CARGO"></asp:TextBox>
                                    </div>
                                    <div class="form-group m-b-20 col-lg-3" style="float:left">
                                        <span>Nro. Dependientes *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNroDependientes" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNroDependientes" runat="server" ErrorMessage="*Solo numeros" ForeColor="Red" Font-Size="Smaller" ValidationExpression="\d*\.?\d*"></asp:RegularExpressionValidator>
						                <asp:TextBox ID="txtNroDependientes" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPENDIENTES"></asp:TextBox>
                                        
                                    </div>
                                     <div class="form-group m-b-20 col-lg-9" style="float:left">
                                        <span>Funciones *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFunciones"  Font-Bold="True"></asp:RequiredFieldValidator>
						                 <asp:TextBox ID="txtFunciones" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DESCRIPCION EN DETALLE DEL PUESTO DE TRABAJO"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Inicio *</span>
                                         <asp:Label ID="lblFecha1" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlIniDia" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlIniDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
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
                                    <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Final *</span>
                                        <asp:Label ID="lblFecha2" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlFinDia" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinDia" InitialValue="DIA" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinMes" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinMes" InitialValue="MES" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinAño" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFinAño" InitialValue="AÑO" Font-Bold="True"></asp:RequiredFieldValidator>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalida1" runat="server" />                                     
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Departamento *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDepartamento" Font-Bold="True"></asp:RequiredFieldValidator>
						                 <asp:TextBox ID="txtDepartamento" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPARTAMENTO"></asp:TextBox>
                                        <br />                                      </div>
                                    <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Otro cargo 1</span>
                                        <asp:TextBox ID="txtOtroCargo1" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder=""></asp:TextBox>
                                    </div>
									 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Nros. Dependientes Otro Cargo 1</span>
						                <asp:TextBox ID="txtNroDependientesOtro1" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPENDIENTES"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Funciones Otro Cargo 1</span>
                                         
						                 <asp:TextBox ID="txtFuncionesOtro1" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DESCRIPCION OTRO CARGO"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Inicio</span>
                                         <asp:Label ID="lblFecha3" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlIniDia1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniMes1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniAño1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalidaIniOtro1" runat="server" />                                     
                                    </div>
                                    <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Final</span>
                                        <asp:Label ID="lblFecha4" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlFinDia1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinMes1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinAño1" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalidaFinOtro1" runat="server" />                                     
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Departamento Otro Cargo 1</span>
						                 <asp:TextBox ID="txtDepartamentoOtro1" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPARTAMENTO"></asp:TextBox>
                                             <br /> 
                                     </div>
																	
					                <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Otro cargo 2</span>
                                       <asp:TextBox ID="txtOtroCargo2" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder=""></asp:TextBox>
                                    </div>
									 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Nros. Dependientes Otro Cargo 2</span>
						                <asp:TextBox ID="txtNroDependientesOtro2" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPENDIENTES"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Funciones Otro Cargo 2</span>
						                 <asp:TextBox ID="txtFuncionesOtro2" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DESCRIPCION OTRO CARGO"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Inicio</span>
                                         <asp:Label ID="lblFecha5" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlIniDia2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniMes2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniAño2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalidaIniOtro2" runat="server" />                                     
                                    </div>
                                    <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Final</span>
                                        <asp:Label ID="lblFecha6" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlFinDia2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinMes2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinAño2" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalidaFinOtro2" runat="server" />                                     
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Departamento Otro Cargo 2</span>
						                 <asp:TextBox ID="txtDepartamentoOtro2" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPARTAMENTO"></asp:TextBox>
                                            <br /> 
                                     </div>
									
					                <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Otro cargo 3</span>
                                        <asp:TextBox ID="txtOtroCargo3" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder=""></asp:TextBox>
                                    </div>
									 <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Nros. Dependientes Otro Cargo 3</span>
						                <asp:TextBox ID="txtNroDependientesOtro3" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPENDIENTES"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Funciones Otro Cargo 3</span>
						                 <asp:TextBox ID="txtFuncionesOtro3" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DESCRIPCION OTRO CARGO"></asp:TextBox>
                                    </div>
                                     <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Inicio</span>
                                         <asp:Label ID="lblFecha7" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlIniDia3" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniMes3" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlIniAño3" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalidaIniOtro3" runat="server" />                                     
                                    </div>
                                    <div class="form-group m-b-20  col-lg-4" style="float:left">     
                                        <span>Fecha Final</span>
                                        <asp:Label ID="lblFecha8" runat="server" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                         <div class="row row-space-6">
													<div class="col-4">
                                                        <asp:DropDownList ID="ddlFinDia3" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinMes3" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
													<div class="col-4">
														<asp:DropDownList ID="ddlFinAño3" class="form-control form-control-lg " ForeColor="Black" runat="server"></asp:DropDownList>
													</div>
												</div>
										<asp:HiddenField ID="hfFechaSalidaFinOtro3" runat="server" />                                     
                                    </div>
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Departamento Otro Cargo 3</span>
						                 <asp:TextBox ID="txtDepartamentoOtro3" ForeColor="Black" class="form-control form-control-lg " runat="server"  placeholder="DEPARTAMENTO"></asp:TextBox>
                                    </div>             
                                    <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Motivo de Desvinculación</span>						               
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlMotivoDesvinculacion" InitialValue="SELECCIONAR UNA OPCION" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlMotivoDesvinculacion" DataSourceID="odsMotivoDesvinculacion" AutoPostBack="true" OnSelectedIndexChanged="ddlMotivoDesvinculacion_SelectedIndexChanged" OnDataBound="ddlMotivoDesvinculacion_DataBound1" DataTextField="dom_descripcion" DataValueField="dom_codigo"  ForeColor="Black" class="form-control form-control-lg " runat="server" ></asp:DropDownList>
                                    </div>        
                                     <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Desvinculación Otro</span>
						                 <asp:TextBox ID="txtDesvinculacionOtro" ForeColor="Black" class="form-control form-control-lg " Enabled="false" runat="server"  placeholder="OTRO MOTIVO DE DESVINCULACION"></asp:TextBox>
                                    </div> 
					                <div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <br />  
                                        <asp:CheckBox ID="ckbCargoActual" AutoPostBack="true" OnCheckedChanged="ckbCargoActual_CheckedChanged" runat="server" />
                                        <span>Actualmente continua en el cargo</span>
                                             <br />        <br />    <br />       <br />                      
                                    </div>
                                    
                                    <%--<div class="form-group m-b-20 col-lg-4" style="float:left">
                                        <span>Total Experiencia Dias</span>
						               <asp:TextBox ID="txtTotalExperiencia" ForeColor="Black" class="form-control form-control-lg " runat="server" ReadOnly="true"  placeholder="TOTAL EXPERIENCIA"></asp:TextBox>
										<asp:Button ID="btnCalcular" runat="server" class="btn btn-success btn-sm" OnClick="btnCalcular_Click" Text="Calcular dias" Width="120px"  ForeColor="White"/>
                                    </div>    --%>
                                     
					                      
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <span>Debe llenar los campos marcados con (*)</span><br />
                                    </div>
                            </div>	
                            <div class="row"></div>
							    <div class="text-right m-b-0" style="float:right">
								    <div class="login-buttons col-lg-12" style="float:right;display:block;;margin:0 30px">
                                        <div class="form-group m-b-6 col-lg-4" style="float:left;display:block">
                                            <asp:Button ID="btnGuardar" runat="server" class="btn btn-success btn-block btn-lg" Text="Guardar" Width="120px"  FontColor="black" OnClick="btnGuardar_Click"/>
                                            </div>
                                        <div class="form-group m-b-6 col-lg-4" style="float:right;display:block">
											<asp:Button ID="btnCancelar" runat="server" class="btn btn-success btn-block btn-lg" CausesValidation="false" OnClick="btnCancelar_Click" Text="Cancelar" Width="120px" BackColor="transparent" FontColor="black" ForeColor="Black"/>
										</div>
									</div>
                                </div>
                                </div>
						   <br /><br />
                            <br /><br />
                            <br /><br />
                            <br /><br /> <br /><br />
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
