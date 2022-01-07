<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="resumen.aspx.cs" Inherits="appRRHHDF.resumen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	      <style type="text/css">
                        .bloque_perfil  {
                            margin: 5px 25px;
                            float:left;
                            width:100%;
                            height:auto;
                            color:#000;
                        }
                        .titulo {
                            color:aqua;
                            border-bottom:3px solid aqua;
                            font-size:28pt;
                            margin:20px 5px;
                        }
                        .imagen_perfil {
                            float:left;
                            margin:0px;
                            width:100%;
                            height:100%;
                            display:block;
                        }  
                        .perfil_personal {
                            float:left;
                            margin:0px;
                            width:100%;
                            height:100%;                        
                            display:block;}  
                        
                        .perfil_personal p  {
                            font-size:14pt;}  
                         .perfil_cargo p {
                            font-size:14pt;}  
                        .perfil_cargo {
                            float:right;
                            margin:0px;
                            width:100%;
                            height:100%;
                            display:block;}
                        .imagen_perfil ul li {
                            list-style:square;
                            font-size:14pt;}
                        .perfil_personal ul li {
                            list-style:square;
                            font-size:14pt;}
                        .perfil_cargo ul li {
                            list-style:square;
                            font-size:14pt;}
                    </style>
    <asp:ObjectDataSource ID="odsEstudios" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Estudios_realizados">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
			</SelectParameters>
	</asp:ObjectDataSource>    
    <asp:ObjectDataSource ID="odsExperienciaLaboral" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Experiencia_Laboral">
        <SelectParameters>
             <asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
       </SelectParameters>
    </asp:ObjectDataSource>    
    <asp:ObjectDataSource ID="odsCursosTalleres" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Cursos_talleres" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" Type="String" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsIdiomas" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Idiomas" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter  ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" Type="String" />
        </SelectParameters>
      </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsReferencias" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Referencias_laborales" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter  ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" Type="String" />
        </SelectParameters>
      </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsDatosFam" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.Datos_familiares">
			<SelectParameters>
				<asp:ControlParameter ControlID="lblIdPersonal" Name="PB_ID_PERSONAL" DefaultValue="" />
				<%--<asp:Parameter DefaultValue="TIPO PARENTESCO" Name="PV_DOMINIO" Type="String" />--%>
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
				<li class="breadcrumb-item active">Resumen</li>
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
						<li class="nav-items"><asp:LinkButton ID="lbtnDatosFam" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnDatosFam_Click" runat="server">Datos familiares</asp:LinkButton></li>
						<li class="nav-items"><asp:LinkButton ID="lbtnEstudiosRealizados" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnEstudiosRealizados_Click" runat="server">Estudios Realizados</asp:LinkButton></li>
                        <li class="nav-items"><asp:LinkButton ID="lbtnCursosTalleres" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton></li>
						<li class="nav-items"><asp:LinkButton ID="lbtnNivelIdioma" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">Idiomas</asp:LinkButton></li>
						<li class="nav-items"><asp:LinkButton ID="lbtnExpLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnExpLaboral_Click" runat="server">Experiencia Laboral</asp:LinkButton></li>
                        <li class="nav-items"><asp:LinkButton ID="lbtnRefLaboral" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton></li>
						<li class="nav-items"><asp:LinkButton ID="lbtnOtrosDatos" ForeColor="White" CausesValidation="false" class="nav-link" OnClick="lbtnOtrosDatos_Click" runat="server">Otros Datos</asp:LinkButton></li>
						<li class="nav-items"><asp:LinkButton ID="lbtnResumen" ForeColor="blue" CausesValidation="false" class="nav-link active" OnClick="lbtnResumen_Click" runat="server">Resumen</asp:LinkButton></li>
					</ul>
                  
					<!-- end nav-tabs -->
					<!-- begin tab-content -->
					<asp:Label ID="lblAviso" ForeColor="Blue" Font-Size="Large" runat="server" Text=""></asp:Label>
						<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdCurso" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
					<div class="tab-content">					
                    
                             <div class="m-b-20 col-lg-12"  style="float:left;background:#fff">
                              <%-- <p> </p>--%>
								    
                                <div class="panel-body">
					               <div class="bloque_perfil col-lg-11">
                                       <div class="imagen_perfil col-lg-3">
                                           <div style="float:left; border:1px solid aqua; padding:5px"><asp:Image ID="imgPerfil" runat="server" Width="190" Height="250"></asp:image></div>
                                       </div>
                                       <div class="perfil_personal col-lg-5"  style="padding:22px 0px;" >
                                           <h1> <asp:Label ID="lblNombreApellido" runat="server" Text="Nombres APELLIDO"> </asp:Label> </h1>
                                           <p><b>Direccion: </b><asp:Label ID="lblDireccion" runat="server" Text="Ciudad Pais"></asp:Label></p>
                                           <%--<p><b>Apellido Casada: </b><asp:Label ID="lblApellidoCasada" runat="server" Text=" "></asp:Label> </p>--%>
                                           <p><b>Telefono/Celular: </b><asp:Label ID="lblTelefonoCelular" runat="server" Text="Xxxxxx - Xxxxxxxx"></asp:Label> </p>
                                           <p><b>E-mail: </b><asp:Label ID="lblEmail" runat="server" Text="xxxxxx@email.com"></asp:Label> </p>                                          
                                       </div>
                                       <div class="perfil_cargo col-lg-4" style="padding:75px 0px;text-align:center;">
                                          <%-- <h2> <asp:Label ID="Label1" runat="server" Text="Asistente Contable"> </asp:Label> </h2>
                                          <p>Disponible a partid de: <asp:Label ID="lblDisponibilidad" runat="server" Text="Junio 2020"></asp:Label> </p>--%>
                                       </div>
					               </div>
                                    <%--<div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> HABILIDADES </h2>
                                       <div class="imagen_perfil col-lg-4">
                                           <ul>
                                               <li><asp:Label ID="lblHabilidades1" runat="server" Text="Analisis de Cartera"></asp:Label></li>
                                               <li><asp:Label ID="lblHabilidades2" runat="server" Text="Cuentas de cobro"></asp:Label></li>
                                               <li><asp:Label ID="lblHabilidades3" runat="server" Text="Relacion con proveedores"></asp:Label></li>
                                               <li><asp:Label ID="lblHabilidades4" runat="server" Text="Bilingue"></asp:Label></li>
                                               <li><asp:Label ID="lblHabilidades5" runat="server" Text="Trabajo bajo presion"></asp:Label></li>
                                               <li><asp:Label ID="lblHabilidades6" runat="server" Text="Responsable y organizado"></asp:Label></li>
                                           </ul>
                                       </div>
                                       <div class="perfil_personal col-lg-4">                                           
                                           <ul>
                                               <li><asp:Label ID="lblIdioma1" runat="server" Text="Español"></asp:Label>:<asp:Label ID="lblIdioma4" runat="server" Text="Natal"></asp:Label></li>
                                               <li><asp:Label ID="lblIdioma2" runat="server" Text="Ingles"></asp:Label>:<asp:Label ID="lblIdioma5" runat="server" Text="Avanzado"></asp:Label></li>
                                               <li><asp:Label ID="lblIdioma3" runat="server" Text="Xxxxxx"></asp:Label>:<asp:Label ID="lblIdioma6" runat="server" Text="Xxxxxxx"></asp:Label></li>
                                           </ul>
                                       </div>
                                       <div class="perfil_cargo col-lg-4">                                     
                                           <ul>
                                               <li><b>Programas Manejados: </b> <asp:Label ID="lblAptitudes1" runat="server" Text="Excel, Power Point, Word, Elisa."></asp:Label></li>
                                               <li><b>Nociones en: </b> <asp:Label ID="lblAptitudes2" runat="server" Text="Paquetes contables."></asp:Label></li>
                                           </ul>
                                       </div>
					               </div>--%>
                                    <div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> ESTUDIOS REALIZADOS </h2>
                                        <asp:Repeater ID="Repeater1"  DataSourceID="odsEstudios" runat="server">
                                            <ItemTemplate>
                                                 <div class="perfil_personal col-lg-3">                                           
                                                       <p><b>Año: <asp:Label ID="lblEstudios1" runat="server" Text='<%# Eval("PES_FECHA_FIN") %>'></asp:Label></b></p>                                           
                                                       <p><b>Ciudad: <asp:Label ID="lblEstudios2" runat="server" Text='<%# Eval("PES_CIUDAD") %>'></asp:Label></b></p>
                                                   </div>
                                                   <div class="perfil_cargo col-lg-9"> 
                                                           <p><b>Titulo en: <asp:Label ID="lblEstudios3" runat="server" Text='<%# Eval("PES_TITULO_OBTENIDO") %>'></asp:Label></b></p>
                                                           <p><b>Universidad o Institución: <asp:Label ID="lblEstudios4" runat="server" Text='<%# Eval("PES_INSTITUCION") %>'></asp:Label></b></p>
                                                   </div>
                                            </ItemTemplate>
                                        </asp:Repeater>                                      
					               </div>
                                     <div class="bloque_perfil col-lg-11 embed-responsive" style="float:left;">
                                         <h2 class="titulo col-lg-12"> EXPERIENCIA LABORAL </h2>
                                         <asp:Repeater ID="Repeater2" DataSourceID="odsExperienciaLaboral" runat="server">
                                             <ItemTemplate>
                                                 
                                             <%--    <div class="col-12">--%>
                                                   
                                                 <div class="perfil_cargo col-lg-12 embed-responsive"> 
                                                     <div class="perfil_personal col-lg-4 embed-responsive">                                           
                                                       <p></p>                                           
                                                       <p><b>Experiencia total: <asp:Label ID="lblExperiencia2" runat="server" Text='<%# Eval("PEX_TOTAL_EXPERIENCIA_TOTAL") %>'></asp:Label> años</b></p>
                                                   </div>
                                                     <div class="col-8  embed-responsive"  style="display:inline-block;width:100%;">
                                                            <h3><b><asp:Label ID="lblExperiencia4" runat="server" Text='<%# Eval("PEX_EMPRESA") %>'></asp:Label></b>
                                                            <span><i> Sector: <asp:Label ID="lblExperiencia5" runat="server" Text='<%# Eval("PEX_DEPARTAMENTO_CARGO") %>'></asp:Label></i></span>
                                                            </h3>
                                                       <br />                                                       
                                                           <div class="col-12 embed-responsive" style="display:inline-block;width:100%" >
                                                            <h4 style="text-decoration: underline #000;"> <b><%#(String.IsNullOrEmpty(Eval("PEX_FECHA_INICIO_CARGO").ToString()) ? "" : Eval("PEX_FECHA_INICIO_CARGO").ToString().Remove(0,(Eval("PEX_FECHA_INICIO_CARGO").ToString().Length-4))) %>  a  <%#(String.IsNullOrEmpty(Eval("PEX_FECHA_FIN_CARGO").ToString()) ? "" : Eval("PEX_FECHA_FIN_CARGO").ToString().Remove(0,(Eval("PEX_FECHA_FIN_CARGO").ToString().Length-4))) %> <%#(String.IsNullOrEmpty(Eval("PEX_TOTAL_EXPERIENCIA").ToString()) ? "" : Eval("PEX_TOTAL_EXPERIENCIA")) %>  años como:  </b> <asp:Label ID="lblCargoOcupado1" runat="server" Text='<%# Eval("PEX_CARGO") %>'></asp:Label></h4>
                                                               <br />
                                                               <div class="col-lg-4" style="float:left;display:block;margin:0px;">
                                                                   <h4>Tareas realizadas: </h4>
                                                               </div>
                                                               <div class="col-lg-8" style="float:left;display:block;margin:0px;">
                                                                   <ul>
                                                                       <li> <asp:Label ID="lblTareas1" runat="server" Text='<%# Eval("PEX_FUNCIONES_CARGO") %>'></asp:Label></li>
                                                                   </ul>
                                                               </div>
                                                           </div> 
                                                        </div>
                                                     </div>  
                                                     
                                                    <div class="perfil_cargo col-lg-12 embed-responsive"> 
                                                     <div class="perfil_personal col-lg-4 embed-responsive">                                           
                                                       <p></p>                                           
                                                       <p><b><asp:Label ID="Label10" runat="server" Text=""></asp:Label></b></p>
                                                   </div>
                                                     <div class="col-8  embed-responsive"  style="display:inline-block;width:100%;">
                                                          <asp:Panel ID="planel_cargo1" class="col-8  embed-responsive" style="display:inline-block;width:100%;" Visible='<%# Eval("PEX_CARGO1_VISIBLE") %>' runat="server">
                                                              <br />
                                                              <div class="col-12 embed-responsive" style="display:inline-block;width:100%" >
                                                            <h4 style="text-decoration: underline #000;"><%#(String.IsNullOrEmpty(Eval("PEX_FECHA_INICIO_OTRO1").ToString()) ? "" : Eval("PEX_FECHA_INICIO_OTRO1").ToString().Remove(0,(Eval("PEX_FECHA_INICIO_OTRO1").ToString().Length-4))) %> a <%#(String.IsNullOrEmpty(Eval("PEX_FECHA_FIN_OTRO1").ToString()) ? "" : Eval("PEX_FECHA_FIN_OTRO1").ToString().Remove(0,(Eval("PEX_FECHA_FIN_OTRO1").ToString().Length-4))) %> <%#(String.IsNullOrEmpty(Eval("PEX_TOTAL_EXPERIENCIA_OTRO1").ToString()) ? "" : Eval("PEX_TOTAL_EXPERIENCIA_OTRO1")) %> años como:  <asp:Label ID="Label2" runat="server" Text='<%# Eval("PEX_OTRO_CARGO1") %>'></asp:Label></h4>
                                                               <br />
                                                               <div class="col-lg-4" style="float:left;display:block;margin:0px;">
                                                                   <h4>Tareas realizadas: </h4>
                                                               </div>
                                                               <div class="col-lg-8" style="float:left;display:block;margin:0px;">
                                                                   <ul>
                                                                       <li> <asp:Label ID="Label3" runat="server" Text='<%# Eval("PEX_FUNCIONES_OTRO1") %>'></asp:Label></li>
                                                                   </ul>
                                                               </div>
                                                                 </div>  
                                                              </asp:Panel>
                                                           </div> 
                                                        </div>

                                                          <div class="perfil_cargo col-lg-12 embed-responsive"> 
                                                           <div class="col-12 embed-responsive"  style="display:inline-block;width:100%">
                                                                <div class="perfil_personal col-lg-4 embed-responsive">                                           
                                                       <p></p>                                           
                                                       <p><b><asp:Label ID="Label11" runat="server" Text=""></asp:Label></b></p>
                                                   </div>
                                                               <asp:Panel ID="planel_cargo2" class="col-8  embed-responsive" style="display:inline-block;width:100%;" Visible='<%# Eval("PEX_CARGO2_VISIBLE") %>' runat="server">
                                                                   <br />
                                                              <div class="col-12 embed-responsive" style="display:inline-block;width:100%" >
                                                            <h4 style="text-decoration: underline #000;"><%#(String.IsNullOrEmpty(Eval("PEX_FECHA_INICIO_OTRO2").ToString()) ? "" : Eval("PEX_FECHA_INICIO_OTRO2").ToString().Remove(0,(Eval("PEX_FECHA_INICIO_OTRO2").ToString().Length-4))) %> a <%#(String.IsNullOrEmpty(Eval("PEX_FECHA_FIN_OTRO2").ToString()) ? "" : Eval("PEX_FECHA_FIN_OTRO2").ToString().Remove(0,(Eval("PEX_FECHA_FIN_OTRO2").ToString().Length-4))) %> <%#(String.IsNullOrEmpty(Eval("PEX_TOTAL_EXPERIENCIA_OTRO2").ToString()) ? "" : Eval("PEX_TOTAL_EXPERIENCIA_OTRO2")) %> años como:  <asp:Label ID="Label4" runat="server" Text='<%# Eval("PEX_OTRO_CARGO2") %>'></asp:Label></h4>
                                                               <div class="row"></div>
                                                               <div class="col-lg-4" style="float:left;display:block;margin:0px;">
                                                                   <h4>Tareas realizadas: </h4>
                                                               </div>
                                                               <div class="col-lg-8" style="float:left;display:block;margin:0px;">
                                                                   <ul>
                                                                       <li> <asp:Label ID="Label5" runat="server" Text='<%# Eval("PEX_FUNCIONES_OTRO2") %>'></asp:Label></li>
                                                                   </ul>
                                                               </div>
                                                                   </div>
                                                                   </asp:Panel>
                                                           </div> 
                                                              </div>

                                                         <div class="perfil_cargo col-lg-12 embed-responsive"> 
                                                           <div class="col-12 embed-responsive"  style="display:inline-block;width:100%">
                                                                <div class="perfil_personal col-lg-4 embed-responsive">                                           
                                                               <p></p>                                           
                                                               <p><b><asp:Label ID="Label12" runat="server" Text=""></asp:Label></b></p>
                                                           </div>
                                                       <asp:Panel ID="planel_cargo3" class="col-8  embed-responsive" style="display:inline-block;width:100%;" Visible='<%# Eval("PEX_CARGO3_VISIBLE") %>' runat="server">
                                                           <br />
                                                              <div class="col-12 embed-responsive" style="display:inline-block;width:100%" >
                                                          <%-- <div class="col-8  embed-responsive"  style="display:inline-block;width:100%">--%>
                                                            <h4 style="text-decoration: underline #000;"><%#(String.IsNullOrEmpty(Eval("PEX_FECHA_INICIO_OTRO3").ToString()) ? "" : Eval("PEX_FECHA_INICIO_OTRO3").ToString().Remove(0,(Eval("PEX_FECHA_INICIO_OTRO3").ToString().Length-4))) %> a <%#(String.IsNullOrEmpty(Eval("PEX_FECHA_FIN_OTRO3").ToString()) ? "" : Eval("PEX_FECHA_FIN_OTRO3").ToString().Remove(0,(Eval("PEX_FECHA_FIN_OTRO3").ToString().Length-4))) %> <%#(String.IsNullOrEmpty(Eval("PEX_TOTAL_EXPERIENCIA_OTRO3").ToString()) ? "" : Eval("PEX_TOTAL_EXPERIENCIA_OTRO3")) %> años como:  <asp:Label ID="Label6" runat="server" Text='<%# Eval("PEX_OTRO_CARGO3") %>'></asp:Label></h4>
                                                               <div class="row"></div>
                                                               <div class="col-lg-4" style="float:left;display:block;margin:0px;">
                                                                   <h4>Tareas realizadas: </h4>
                                                               </div>
                                                               <div class="col-lg-8" style="float:left;display:block;margin:0px;">
                                                                   <ul>
                                                                       <li> <asp:Label ID="Label7" runat="server" Text='<%# Eval("PEX_FUNCIONES_OTRO3") %>'></asp:Label></li>
                                                                   </ul>
                                                               </div>
                                                           </div> 
                                                             <%--  </div>--%>
                                                        </asp:Panel>
                                                             </div>
                                                     </div>                                              
                                            <br />
                                             </ItemTemplate>
                                         </asp:Repeater>
                                                
                                      
					               </div>
                                     <div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> CURSOS / TALLERES </h2>
                                        <asp:Repeater ID="Repeater3"  DataSourceID="odsCursosTalleres" runat="server">
                                            <ItemTemplate>
                                                <div class="perfil_personal col-lg-12">
                                                <div class="perfil_personal col-lg-4">                                           
                                                       <p><b>Fecha:</b> <asp:Label ID="Cursos3" runat="server" Text='<%# Eval("PCR_FECHA_INICIO") %>'></asp:Label> a <asp:Label ID="Label1" runat="server" Text='<%# Eval("PCR_FECHA_FIN") %>'> </asp:Label></p>                                           
                                                       <p><b>Tipo:</b> <asp:Label ID="lblCursos2" runat="server" Text='<%# Eval("DESC_TIPO_CAPACITACION") %>'></asp:Label></p>
                                                   </div>
                                                   <div class="perfil_cargo col-lg-8"> 
                                                           <p><b>Duración en Horas:</b> <asp:Label ID="Label9" runat="server" Text='<%# Eval("PCR_TOTAL_HORAS") %>'></asp:Label></p>
                                                           <p><b>Institución:</b> <asp:Label ID="Label8" runat="server" Text='<%# Eval("PCR_INSTITUCION") %>'></asp:Label></p>
                                                   </div>
                                                <%-- <div class="perfil_personal col-lg-12">                                           
                                                                              
                                                        <p><b><asp:Label ID="Cursos3" runat="server" Text='<%# Eval("PCR_FECHA_INICIO") %>'></asp:Label> a <asp:Label ID="Label1" runat="server" Text='<%# Eval("PCR_FECHA_FIN") %>'> </asp:Label> Tipo Curso: <asp:Label ID="lblCursos2" runat="server" Text='<%# Eval("DESC_TIPO_CAPACITACION") %>'></asp:Label> Institucion: <asp:Label ID="Label8" runat="server" Text='<%# Eval("PCR_INSTITUCION") %>'></asp:Label> Total curso (horas): <asp:Label ID="Label9" runat="server" Text='<%# Eval("PCR_TOTAL_HORAS") %>'></asp:Label></b></p> 
                                                   </div>--%>
                                               </div>   
                                            </ItemTemplate>
                                        </asp:Repeater>                                      
					               </div>                                    
                                     <div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> IDIOMAS </h2>
                                        <asp:Repeater ID="Repeater4"  DataSourceID="odsIdiomas" runat="server">
                                            <ItemTemplate>
                                                 <div class="perfil_personal col-lg-4">                                                                               
                                                       <p><b>Idioma: </b><asp:Label ID="lblIdioma2" runat="server" Text='<%# Eval("DESC_IDIOMA") %>'></asp:Label></p>
                                                     
                                                     <br /> <br />
                                                   </div>
                                                   <div class="perfil_cargo col-lg-4"> 
                                                        <p><b>Cuenta con Certificado: </b><asp:Label ID="lblIdioma6" runat="server" Text='<%# Eval("PID_CON_TITULO") %>'></asp:Label></p>      
                                                   </div>
                                                    <div class="perfil_cargo col-lg-4"> 
                                                           <p><b>Escritura: </b><asp:Label ID="lblIdioma3" runat="server" Text='<%# Eval("DESC_ESCRITURA") %>'></asp:Label></p>
                                                           <p><b>Lectura: </b><asp:Label ID="lblIdioma4" runat="server" Text='<%# Eval("DESC_LECTURA") %>'></asp:Label></p>
                                                           <p><b>Conversación: </b><asp:Label ID="lblIdioma5" runat="server" Text='<%# Eval("DESC_CONVERSACION") %>'></asp:Label></p>
                                                           
                                                   </div>
                                                <div class="row col-lg-12"></div><br />
                                            </ItemTemplate>
                                        </asp:Repeater>                                      
					               </div>
                                     <div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> REFERENCIAS LABORALES </h2>
                                        <asp:Repeater ID="Repeater5"  DataSourceID="odsReferencias" runat="server">
                                            <ItemTemplate>
                                                 <div class="perfil_personal col-lg-6">                                                                               
                                                       <p><b>Empresa: </b><asp:Label ID="lblReferencia1" runat="server" Text='<%# Eval("PRE_EMPRESA") %>'></asp:Label></p>
                                                       <p><b>Cargo: </b><asp:Label ID="lblReferencia2" runat="server" Text='<%# Eval("PRE_CARGO") %>'></asp:Label></p>
                                                   </div>
                                                    <div class="perfil_cargo col-lg-6"> 
                                                           <p><b>Referencia: </b><asp:Label ID="lblReferencia3" runat="server" Text='<%# Eval("PRE_RELACION_LABORAL") %>'></asp:Label></p>
                                                           <p><b>Contactos: </b><asp:Label ID="lblReferencia4" runat="server" Text='<%# Eval("PRE_TELEFONO") %>'></asp:Label></p>
                                                           <p><b>Email: </b><asp:Label ID="lblReferencia5" runat="server" Text='<%# Eval("PRE_EMAIL") %>'></asp:Label></p>
                                                   </div>
                                                <div class="row col-lg-12"></div><br />
                                            </ItemTemplate>
                                        </asp:Repeater>                                      
					               </div>

                                    <div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> OTROS DATOS </h2>
                                        <asp:Repeater ID="Repeater7"  DataSourceID="odsDocumentos" runat="server">
                                            <ItemTemplate>
                                                 <div class="perfil_personal col-lg-6">                                                                               
                                                       <p><b>Documento: </b><asp:Label ID="lblReferencia1" runat="server" Text='<%# Eval("DESC_TIPO_OTRO_DOCUMENTO") %>'></asp:Label></p>
                                                      <%-- <p><b>Nro.Documento: </b><asp:Label ID="lblReferencia2" runat="server" Text='<%# Eval("POF_NUMERO_DOCUMENTO") %>'></asp:Label></p>--%>
                                                   </div>
                                                    <div class="perfil_cargo col-lg-6"> 
                                                           <p><b>Descripción: </b><asp:Label ID="lblReferencia3" runat="server" Text='<%# Eval("PTR_DESCRIPCION") %>'></asp:Label></p>
                                                          <%-- <p><b>Paterno: </b><asp:Label ID="lblReferencia4" runat="server" Text='<%# Eval("POF_APELLIDO_PATERNO") %>'></asp:Label></p>
                                                           <p><b>Materno: </b><asp:Label ID="lblReferencia5" runat="server" Text='<%# Eval("POF_APELLIDO_MATERNO") %>'></asp:Label></p>--%>
                                                   </div>
                                                <div class="row col-lg-12"></div><br />
                                            </ItemTemplate>
                                        </asp:Repeater>                                      
					               </div>

                                    <div class="bloque_perfil col-lg-11">
                                         <h2 class="titulo col-lg-12"> DATOS FAMILIARES </h2>
                                        <asp:Repeater ID="Repeater6"  DataSourceID="odsDatosFam" runat="server">
                                            <ItemTemplate>
                                                 <div class="perfil_personal col-lg-6">                                                                               
                                                       <p><b>Parentesco: </b><asp:Label ID="lblReferencia1" runat="server" Text='<%# Eval("DESC_TIPO_PARENTESCO") %>'></asp:Label></p>
                                                       <p><b>Nro.Documento: </b><asp:Label ID="lblReferencia2" runat="server" Text='<%# Eval("POF_NUMERO_DOCUMENTO") %>'></asp:Label></p>
                                                   </div>
                                                    <div class="perfil_cargo col-lg-6"> 
                                                           <p><b>Nombre: </b><asp:Label ID="lblReferencia3" runat="server" Text='<%# Eval("POF_NOMBRES") %>'></asp:Label></p>
                                                           <p><b>Paterno: </b><asp:Label ID="lblReferencia4" runat="server" Text='<%# Eval("POF_APELLIDO_PATERNO") %>'></asp:Label></p>
                                                           <p><b>Materno: </b><asp:Label ID="lblReferencia5" runat="server" Text='<%# Eval("POF_APELLIDO_MATERNO") %>'></asp:Label></p>
                                                   </div>
                                                <div class="row col-lg-12"></div><br />
                                            </ItemTemplate>
                                        </asp:Repeater>                                      
					               </div>
				                </div>
                            </div> 
                        
                        </div>
					<!-- end tab-content -->
				</div>
				<!-- end col-6 -->				
			</div>
			<!-- end row -->
		</div>
		<!-- end #content -->
</asp:Content>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

    <!-- begin #content -->
		<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Perfil</a></li>
				<li class="breadcrumb-item active">Cursos Talleres</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header"> MI <small>PERFIL</small></h1>
			<!-- end page-header -->
			
			<!-- begin row -->
			<div class="row">

				<!-- begin col-12 -->
				<div class="col-lg-12">
                    <!-- begin nav-tabs -->
					<ul class="nav nav-tabs">
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosPersonales" CausesValidation="false" class="nav-link" OnClick="lbtnDatosPersonales_Click" runat="server">Datos personales</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnDatosFam" CausesValidation="false" class="nav-link" OnClick="lbtnDatosFam_Click" runat="server">Datos familiares</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnEstudiosRealizados" CausesValidation="false" class="nav-link" OnClick="lbtnEstudiosRealizados_Click" runat="server">Estudios Realizados</asp:LinkButton>
						
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnCursosTalleres" CausesValidation="false" class="nav-link" OnClick="lbtnCursosTalleres_Click" runat="server">Cursos/Talleres</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnNivelIdioma" CausesValidation="false" class="nav-link" OnClick="lbtnNivelIdioma_Click" runat="server">Idiomas</asp:LinkButton>
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnExpLaboral" CausesValidation="false" class="nav-link" OnClick="lbtnExpLaboral_Click" runat="server">Experiencia Laboral</asp:LinkButton>
						</li>
                        <li class="nav-items">
							<asp:LinkButton ID="lbtnRefLaboral" CausesValidation="false" class="nav-link" OnClick="lbtnRefLaboral_Click" runat="server">Referencia Laboral</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnOtrosDatos" CausesValidation="false" class="nav-link" OnClick="lbtnOtrosDatos_Click" runat="server">Otros Datos</asp:LinkButton>
							
						</li>
						<li class="nav-items">
							<asp:LinkButton ID="lbtnResumen" CausesValidation="false" class="nav-link active" OnClick="lbtnResumen_Click" runat="server">Resumen</asp:LinkButton>
							
						</li>
					</ul>
					<!-- end nav-tabs -->
					<!-- begin tab-content -->
					<asp:Label ID="lblAviso" ForeColor="Blue" Font-Size="Large" runat="server" Text=""></asp:Label>
						<asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdCurso" runat="server" Text="" Visible="false"></asp:Label>
						<asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
					<div class="tab-content" style="padding:40px 0">
                        <rsweb:ReportViewer ID="rv" Width="70%" Height="350px" runat="server" ></rsweb:ReportViewer>
						</div>
					</div>
				</div>
			</div>--%>

