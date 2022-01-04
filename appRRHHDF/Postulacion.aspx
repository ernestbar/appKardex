<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Postulacion.aspx.cs" Inherits="appRRHHDF.Postulacion" %>
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
    <!-- begin #content -->
	<div id="content" class="content">
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Inicio</a></li>
				<li class="breadcrumb-item active">Postulaciones</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1><small></small></h1>
			<!-- end page-header -->
			<!-- begin wizard-form -->
			<form action="/" method="POST" class="form-control-with-bg">
				<!-- begin wizard -->
				<div id="wizard">
					<!-- begin wizard-step -->
					<ul class="text-center" style="padding-left:15%">
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-1">
								<span class="number" style ="font-size:17pt;border:1px solid #000">1</span> 
							</a>
								<span class="info text-ellipsis" style="width:100%;float:left;color:#4bb050;">
									Inicio Postulacion
								</span>
						</li>
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-2">
								<span class="number" style ="font-size:17pt;border:1px solid #000">2</span> 
							</a>
								<span class="info text-ellipsis"  style="width:100%;float:left;color:#4bb050;">
									Formación
								</span>
						</li>
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-3">
								<span class="number" style ="font-size:17pt;border:1px solid #000">3</span>
							</a>
								<span class="info text-ellipsi"  style="width:100%;float:left;color:#4bb050;">
									Experiencia <br /> General
								</span>
						</li>
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-4">
								<span class="number" style ="font-size:17pt;border:1px solid #000">4</span> 
							</a>
								<span class="info text-ellipsis"  style="width:100%;float:left;color:#4bb050;">
									Experiencia <br /> Específica
								</span>
						</li>
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-5">
								<span class="number" style ="font-size:17pt;border:1px solid #000">5</span> 
							</a>
								<span class="info text-ellipsis"  style="width:100%;float:left;color:#4bb050;">
									Conocimientos <br /> de Software y <br /> Específicos
								</span>
						</li>
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-6">
								<span class="number" style ="font-size:17pt;border:1px solid #000">6</span>
							</a>
								<span class="info text-ellipsis"  style="width:100%;float:left;color:#4bb050;">
									Conocimeientos <br /> de Idiomas
								</span>
						</li>
						<li class="col-md-1 col-sm-4 col-3">
							<a href="#step-7">
								<span class="number" style ="font-size:17pt;border:1px solid #000">7</span> 
							</a>
								<span class="info text-ellipsis"  style="width:100%;float:left;color:#4bb050;">
									Declaración y <br /> Formulario de <br /> postulación
								</span>
						</li>
					</ul>
					<!-- end wizard-step -->
					<!-- begin wizard-content -->
					<div>
						<!-- begin step-1 -->
						<div id="step-1">
							<div class="jumbotron m-b-0 text-center">
								<h2 class="text-inverse">Inicio de Postulación</h2>
								<p class="m-b-30 f-s-16"> A continuación se incia la postulacion a una convocatoria. </p>								
							</div>
						</div>
						<!-- end step-1 -->
						<!-- begin step-2 -->
						<div id="step-2">
                            <div class="row col-lg-12" style="border:2px solid #4bb050;margin:12px;border-radius:10px;padding:8px">
							    <div class="col-12" style="display:inline-block">
								    <h2 class="text-inverse">Convocatoria 42/2020</h2>
                                    <div class="row col-lg-12" style="margin:10px;border:1px solid #000; border-radius:5px;float:left">
								        <p class="m-b-30 f-s-16"> <b style="color:#000">Estudios</b> <br />
                                        <asp:Label ID="lblPostulacion1" runat="server" Text="Licenciatura en Administradion de empresas e ingenieria Industrial"></asp:Label> </p>
                                    </div>
                                    <span style="color:blue;font-style:italic"> Selecciona Experiencia Laboral que cumpla con los requerimeintos</span>
							    </div>
                                 <div  class="col-12" style="display:inline-block; text-align:center;">
                                     <!-- incio de registro -->
                                    <div class="row col-lg-12" style="margin:0 6px;padding:3px; border:1px solid #000; border-radius:5px;color:#000">
								        <div class="col-lg-12">
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Empresa:</b><br />
                                        <asp:Label ID="lblPostulacion2" runat="server" Text="Empresa 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Cargo:</b><br />
                                        <asp:Label ID="lblPostulacion3" runat="server" Text="Cargo 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Area / Departamento:</b><br />
                                        <asp:Label ID="lblPostulacion4" runat="server" Text="DEPTO. DE INVESTIGACION Y DESARROLLO"></asp:Label> </p>
                                        </div></div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Inicio:</b><br />
                                        <asp:Label ID="lblPostulacion5" runat="server" Text="07/06/2018"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Término:</b><br />
                                        <asp:Label ID="lblPostulacion6" runat="server" Text="07/06/2020"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Total Experiencia:</b><br />
                                        <asp:Label ID="lblPostulacion7" runat="server" Text="2 - 4 Años"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <asp:Button ID="btnSeleccionar" runat="server" class="btn btn-success btn-block btn-lg" Text="Seleccionar" Width="185px" BackColor="Blue" />
                                        </div>
                                        </div>
                                    </div>
                                     <!-- Fin de registro -->
                                     <!-- incio de registro -->
                                    <div class="row col-lg-12" style="margin:0 6px;padding:3px; border:1px solid #000; border-radius:5px;color:#000;background:#deead1;">
								        <div class="col-lg-12">
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Empresa:</b><br />
                                        <asp:Label ID="lblPostulacion8" runat="server" Text="Empresa 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Cargo:</b><br />
                                        <asp:Label ID="lblPostulacion9" runat="server" Text="Cargo 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Area / Departamento:</b><br />
                                        <asp:Label ID="lblPostulacion10" runat="server" Text="DEPTO. DE INVESTIGACION Y DESARROLLO"></asp:Label> </p>
                                        </div></div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Inicio:</b><br />
                                        <asp:Label ID="lblPostulacion11" runat="server" Text="07/06/2018"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Término:</b><br />
                                        <asp:Label ID="lblPostulacion12" runat="server" Text="07/06/2020"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Total Experiencia:</b><br />
                                        <asp:Label ID="lblPostulacion13" runat="server" Text="2 - 4 Años"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <asp:Button ID="btnSeleccionarN" runat="server" class="btn btn-success btn-block btn-lg" Text=" Eliminar Seleccionar" Width="185px" BackColor="Red" />
                                        </div>
                                        </div>
                                    </div>
                                     <!-- Fin de registro -->
							    </div>	
							</div>
						</div>
						<!-- end step-2 -->
						<!-- begin step-3 -->
						<div id="step-3">
							<div class="row col-lg-12" style="border:2px solid #4bb050;margin:12px;border-radius:10px;padding:8px">
							    <div class="col-12" style="display:inline-block">
								    <h2 class="text-inverse">Convocatoria 42/2020</h2>
                                    <div class="row col-lg-12" style="margin:10px;border:1px solid #000; border-radius:5px;float:left">
								        <p class="m-b-30 f-s-16"> <b style="color:#000">Experiencia general</b> <br />
                                        <asp:Label ID="lblExperiencia14" runat="server" Text="En aca va el detalle de experiencia genreal que sean de (3) años Proximadamente y demas"></asp:Label> </p>
                                    </div>
                                    <span style="color:blue;font-style:italic"> Selecciona Experiencia Laboral que cumpla con los requerimeintos</span>
							    </div>
                                 <div  class="col-12" style="display:inline-block; text-align:center;">
                                     <!-- incio de registro -->
                                    <div class="row col-lg-12" style="margin:0 6px;padding:3px; border:1px solid #000; border-radius:5px;color:#000">
								        <div class="col-lg-12">
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Empresa:</b><br />
                                        <asp:Label ID="lblExperiencia15" runat="server" Text="Empresa 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Cargo:</b><br />
                                        <asp:Label ID="lblExperiencia16" runat="server" Text="Cargo 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Area / Departamento:</b><br />
                                        <asp:Label ID="lblExperiencia17" runat="server" Text="DEPTO. DE INVESTIGACION Y DESARROLLO"></asp:Label> </p>
                                        </div></div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Inicio:</b><br />
                                        <asp:Label ID="lblExperiencia18" runat="server" Text="07/06/2018"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Término:</b><br />
                                        <asp:Label ID="lblExperienci9" runat="server" Text="07/06/2020"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Total Experiencia:</b><br />
                                        <asp:Label ID="lblExperiencia20" runat="server" Text="2 - 4 Años"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <asp:Button ID="Button1" runat="server" class="btn btn-success btn-block btn-lg" Text="Seleccionar" Width="185px" BackColor="Blue" />
                                        </div>
                                        </div>
                                    </div>
                                     <!-- Fin de registro -->
                                     <!-- incio de registro -->
                                    <div class="row col-lg-12" style="margin:0 6px;padding:3px; border:1px solid #000; border-radius:5px;color:#000;background:#deead1;">
								        <div class="col-lg-12">
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Empresa:</b><br />
                                        <asp:Label ID="lblExperiencia21" runat="server" Text="Empresa 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Cargo:</b><br />
                                        <asp:Label ID="lblExperiencia22" runat="server" Text="Cargo 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Area / Departamento:</b><br />
                                        <asp:Label ID="lblExperiencia23" runat="server" Text="DEPTO. DE INVESTIGACION Y DESARROLLO"></asp:Label> </p>
                                        </div></div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Inicio:</b><br />
                                        <asp:Label ID="lblExperiencia24" runat="server" Text="07/06/2018"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Término:</b><br />
                                        <asp:Label ID="lblExperiencia25" runat="server" Text="07/06/2020"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Total Experiencia:</b><br />
                                        <asp:Label ID="lblExperiencia26" runat="server" Text="2 - 4 Años"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <asp:Button ID="Button2" runat="server" class="btn btn-success btn-block btn-lg" Text=" Eliminar Seleccionar" Width="185px" BackColor="Red" />
                                        </div>
                                        </div>
                                    </div>
                                     <!-- Fin de registro -->
							    </div>	
							</div>
						</div>
						<!-- end step-3 -->
						<!-- begin step-4 -->
						<div id="step-4">
							<div class="row col-lg-12" style="border:2px solid #4bb050;margin:12px;border-radius:10px;padding:8px">
							    <div class="col-12" style="display:inline-block">
								    <h2 class="text-inverse">Convocatoria 42/2020</h2>
                                    <div class="row col-lg-12" style="margin:10px;border:1px solid #000; border-radius:5px;float:left">
								        <p class="m-b-30 f-s-16"> <b style="color:#000">Experiencia Específica</b> <br />
                                        <asp:Label ID="lblExperiencia27" runat="server" Text="En aca va el detalle de experiencia especificaca minimo de (3) años y máximo (5) años que sean de (3) años Proximadamente y banca de valores."></asp:Label> </p>
                                    </div>
                                    <span style="color:blue;font-style:italic"> Selecciona Experiencia Laboral que cumpla con los requerimeintos</span>
							    </div>
                                 <div  class="col-12" style="display:inline-block; text-align:center;">
                                     <!-- incio de registro -->
                                    <div class="row col-lg-12" style="margin:0 6px;padding:3px; border:1px solid #000; border-radius:5px;color:#000">
								        <div class="col-lg-12">
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Empresa:</b><br />
                                        <asp:Label ID="lblExperiencia28" runat="server" Text="Empresa 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Cargo:</b><br />
                                        <asp:Label ID="lblExperiencia29" runat="server" Text="Cargo 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Area / Departamento:</b><br />
                                        <asp:Label ID="lblExperiencia30" runat="server" Text="DEPTO. DE INVESTIGACION Y DESARROLLO"></asp:Label> </p>
                                        </div></div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Inicio:</b><br />
                                        <asp:Label ID="lblExperiencia31" runat="server" Text="07/06/2018"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Término:</b><br />
                                        <asp:Label ID="lblExperiencia32" runat="server" Text="07/06/2020"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Total Experiencia:</b><br />
                                        <asp:Label ID="lblExperiencia33" runat="server" Text="2 - 4 Años"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <asp:Button ID="Button3" runat="server" class="btn btn-success btn-block btn-lg" Text="Seleccionar" Width="185px" BackColor="Blue" />
                                        </div>
                                        </div>
                                    </div>
                                     <!-- Fin de registro -->
                                     <!-- incio de registro -->
                                    <div class="row col-lg-12" style="margin:0 6px;padding:3px; border:1px solid #000; border-radius:5px;color:#000;background:#deead1;">
								        <div class="col-lg-12">
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Empresa:</b><br />
                                        <asp:Label ID="lblExperiencia34" runat="server" Text="Empresa 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Cargo:</b><br />
                                        <asp:Label ID="lblExperiencia35" runat="server" Text="Cargo 1"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-4" style="float:left;display:block">
                                            <p><b>Area / Departamento:</b><br />
                                        <asp:Label ID="lblExperiencia36" runat="server" Text="DEPTO. DE INVESTIGACION Y DESARROLLO"></asp:Label> </p>
                                        </div></div>
                                        <div class="col-lg-12">
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Inicio:</b><br />
                                        <asp:Label ID="lblExperiencia37" runat="server" Text="07/06/2018"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Fecha Término:</b><br />
                                        <asp:Label ID="lblExperiencia38" runat="server" Text="07/06/2020"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <p><b>Total Experiencia:</b><br />
                                        <asp:Label ID="lblExperiencia39" runat="server" Text="2 - 4 Años"></asp:Label> </p>
                                        </div>
                                        <div class="col-lg-3" style="float:left;display:block">
                                            <asp:Button ID="Button4" runat="server" class="btn btn-success btn-block btn-lg" Text=" Eliminar Seleccionar" Width="185px" BackColor="Red" />
                                        </div>
                                        </div>
                                    </div>
                                     <!-- Fin de registro -->
							    </div>	
							</div>
						</div>
						<!-- end step-4 -->
                        <!-- begin step-5 -->
						<div id="step-5">
							<div class="row col-lg-12" style="border:2px solid #4bb050;margin:12px;border-radius:10px;padding:8px">
							    <div class="col-12" style="display:inline-block">
								    <h2 class="text-inverse">Convocatoria 42/2020</h2>
                                    <div class="row col-lg-12" style="margin:10px;border:1px solid #000; border-radius:5px;float:left">
								        <p class="m-b-30 f-s-16"> <b style="color:#000">Conocimeinetos de Software</b> <br />
                                        <asp:Label ID="lblPostulacion40" runat="server" Text="Dominio de oficce Word, Excel Power Point (Avanzado)"></asp:Label> </p>
                                    </div>
                                    <span style="color:blue;font-style:italic"> Selecciona Experiencia Laboral que cumpla con los requerimeintos</span>
							    </div>
                                 <div  class="col-12" style="display:inline-block; text-align:center;">
                                     <div class="panel-body">                        
					                   <table id="data-table-fixed-columns" class="table table-striped table-bordered">
								            <thead STYLE="background-color:#e2e7eb;">
									            <tr>
										            <th class="text-nowrap">#</th>
										            <th class="text-nowrap">Centro Estudio</th>
										            <th class="text-nowrap">Paquete Software</th>
										            <th class="text-nowrap">Nivel Dominio</th>
										            <th class="text-nowrap">Fecha Emisión Certificado</th>
										            <th class="text-nowrap">Acciones</th>
									            </tr>
								            </thead>
								            <tbody>
									            <tr class="gradeX">
										            <td>1</td>
										            <td>UMSA</td>
										            <td>Office Word</td>
										            <td>AVANZADO</td>
										            <td>12/feb/2019</td>
										            <td><asp:CheckBox ID="cbxSoftwware1" runat="server" /></td>
                                                </tr>
									            <tr class="gradeX">
										            <td>2</td>
										            <td>ICEI</td>
										            <td>.NET C#</td>
										            <td>BASICO</td>
										            <td>12/feb/2019</td>
										            <td><asp:CheckBox ID="cbxSoftwware2" runat="server" /></td>
                                                </tr>
									            <tr class="gradeX">
										            <td>3</td>
										            <td>EDUCSER</td>
										            <td>SPSS</td>
										            <td>AVANZADO</td>
										            <td>12/feb/2019</td>
										            <td><asp:CheckBox ID="cbxSoftwware3" runat="server" /></td>
                                                </tr>
								            </tbody>
							            </table>						
						            <!-- end panel-body -->
					            </div>
							    </div>	
							</div>
						</div>
						<!-- end step-5 -->
                        <!-- begin step-6 -->
						<div id="step-6">
							<div class="row col-lg-12" style="border:2px solid #4bb050;margin:12px;border-radius:10px;padding:8px">
							    <div class="col-12" style="display:inline-block">
								    <h2 class="text-inverse">Convocatoria 42/2020</h2>
                                    <div class="row col-lg-12" style="margin:10px;border:1px solid #000; border-radius:5px;float:left">
								        <p class="m-b-30 f-s-16"> <b style="color:#000">Conocimeinetos de Idioma</b> <br />
                                        <asp:Label ID="lblPostulacion41" runat="server" Text="Dominio de Ingles (Intermedio)"></asp:Label> </p>
                                    </div>
                                    <span style="color:blue;font-style:italic"> Selecciona Experiencia Laboral que cumpla con los requerimeintos</span>
							    </div>
                                 <div  class="col-12" style="display:inline-block; text-align:center;">
                                      <div class="panel-body">                        
					                   <table id="data-table-fixed-columns1" class="table table-striped table-bordered">
								            <thead STYLE="background-color:#e2e7eb;">
									            <tr>
										            <th class="text-nowrap">#</th>
										            <th class="text-nowrap">idioma</th>
										            <th class="text-nowrap">Nivel Lectura</th>
										            <th class="text-nowrap">Nivel Escritura</th>
										            <th class="text-nowrap">Fecha Conversación</th>
										            <th class="text-nowrap">Acciones</th>
									            </tr>
								            </thead>
								            <tbody>
									            <tr class="gradeX">
										            <td>1</td>
										            <td>INGLES</td>
										            <td>BASICO</td>
										            <td>AVANZADO</td>
										            <td>BASICO</td>
										            <td><asp:CheckBox ID="cbxSoftwware4" runat="server" /></td>
                                                </tr>
									            <tr class="gradeX">
										            <td>2</td>
										            <td>AYMARA</td>
										            <td>BASICO</td>
										            <td>AVANZADO</td>
										            <td>BASICO</td>
										            <td><asp:CheckBox ID="cbxSoftwware5" runat="server" /></td>
                                                </tr>
								            </tbody>
							            </table>						
						            <!-- end panel-body -->
					            </div>
							    </div>	
							</div>
						</div>
						<!-- end step-6 -->
                        <!-- begin step-7 -->
						<div id="step-7">
							<div class="row col-lg-12" style="border:2px solid #4bb050;margin:12px;border-radius:10px;padding:8px">							    
                                  <div class="conten_form">                                                                                                   
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <p>¿Fue evaluado(a) anteriormente por la institución?</p>
                                    </div>     
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <asp:RadioButton ID="rbtnPostulacion1" runat="server" /> SI 
                                        <asp:RadioButton ID="rbtnPostulacion2" runat="server" Checked="true"  /> NO <br /><br />
                                    </div>   
                                     <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <p>¿Ha rabajado anteriormente en la institución?</p>
                                    </div>     
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <asp:RadioButton ID="rbtnPostulacion3" runat="server" /> SI  
                                        <asp:RadioButton ID="rbtnPostulacion4" runat="server" Checked="true" /> NO <br /><br />
                                    </div>   
                                       <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <p>¿Fue evaluado(a) anteriormente en alguna institución Bancaria?</p>
                                    </div>     
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <asp:RadioButton ID="rbtnPostulacion5" runat="server" /> SI 
                                        <asp:RadioButton ID="rbtnPostulacion6" runat="server" Checked="true"  /> NO <br /><br />
                                    </div>   
                                     <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <p>¿Actualmente tiene parentexco con algún/a trabajador/a de la Institución?</p>
                                    </div>     
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <asp:RadioButton ID="rbtnPostulacion7" runat="server" /> SI  
                                        <asp:RadioButton ID="rbtnPostulacion8" runat="server" Checked="true" /> NO <br /><br />
                                    </div>  
   
                                                                                               
                                    <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Nombre Persona *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPostulacion1" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPostulacion1" runat="server" class="form-control form-control-lg inverse-mode" placeholder="Nombre completo del Trabajador" ForeColor="Black" ></asp:TextBox>
                                    </div>      
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Parentezco *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPostulacion2" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPostulacion2" runat="server" class="form-control form-control-lg inverse-mode" placeholder="Nombre completo del Trabajador" ForeColor="Black" ></asp:TextBox>
                                        </div>   
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Parentezco Salarial (Bs./Mes) *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPostulacion3" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPostulacion3" runat="server" class="form-control form-control-lg inverse-mode" placeholder="Monto en Bs. ej: 2000" ForeColor="Black" ></asp:TextBox>
                                       </div> 
                                   <div class="form-group m-b-20 col-lg-6" style="float:left">
                                        <span>Disponibilidad de tiempo para inciciar en el trabajo *</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPostulacion3" Font-Bold="True"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtPostulacion4" runat="server" class="form-control form-control-lg inverse-mode" placeholder="Número de días en espera (Inmediatamente = 0)" ForeColor="Black" ></asp:TextBox>
                                   </div>                        				                      
                                    <div class="form-group m-b-20 col-lg-12" style="float:left">
                                        <asp:CheckBox ID="cbxPostulacion1" runat="server" /> YO NOMBRE COMPLETO CON CI 123456789 AL PARTICIPAR DEL PRESENTE PROCESO DE RECLUTAMIENTO Y SELECCION DE PERSONAL, 
                                        MANIFIESTO DE MI LIBRE VOLUNTAD Y DECLARO QUE LA INFORMACION BRINDADA EN EL FORMULARIO DE POSTULACION ES VERDADERA Y MI OBLIGACION EL SUSTENTARLA CON LOS RESPALDOS ORIGINALES 
                                        Y DOY MI AUTORIZACIÓN PARA QUE PUEDAN VERIFICAR LAS REFERENCIAS DEL FORMULARIO POR ULTIMO, CONOZCO Y ACEPTO QUE ES CASUAL DE RECHAZO DE LA POSTULACIÓN AL PROCESO, 
                                        SIN LUGAR AL RECLAMO LA INSTITUCIÓN SE RESERVA EL DERECHO DE ANULAR LA POSTULACION EN CASO DE QUE SE EVIDENCIE ALGUNA IRREGULARIDAD EN CUALQUIER ETAPA DE LA POSTULACIÓN.
                                    </div>
                            </div>	
                            <div class="row"></div>
							    <div class="text-right m-b-0" style="float:right">
								    <div class="login-buttons col-lg-6" style="float:right;display:block">
										<asp:Button ID="btnDescargar" runat="server" class="btn btn-success btn-block btn-lg" Text="Descargar Formulario de Postulación PDF" BackColor="Blue" Width="380px" />
							        </div>
                                </div>	
						</div>
						<!-- end step-7 -->
					</div>
					<!-- end wizard-content -->
				</div>
				<!-- end wizard -->
			</form>
			<!-- end wizard-form -->
		</div>
		<!-- end #content -->


</asp:Content>
