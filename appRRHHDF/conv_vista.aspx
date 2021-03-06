<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="conv_vista.aspx.cs" Inherits="appRRHHDF.conv_vista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="odsCompetencias" runat="server" SelectMethod="PR_SEG_GET_COMPETENCIA_CONV" TypeName="appRRHHDF.clases.Convocatorias2">
		<SelectParameters>
            <asp:ControlParameter ControlID="lblCodConvocatoria" Name="PD_CNV_CONVOCATORIA" Type="String"  DefaultValue="0" />
        </SelectParameters>
		 </asp:ObjectDataSource>
   
    <div class="container" id="myModal" tabindex="-1" role="dialog">
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblIdPersonal" runat="server" Visible="false" Text=""></asp:Label>
            <div class="modal-dialog" style="max-width:600px">
                <div class="modal-content">
                  
                    <div class="modal-body">
                         <asp:Image ID="iLogoEmpresa" Width="170px" runat="server" /><br />
                           <div class="bloque_perfil col-lg-12" style="color:#000000;text-align:justify">
                                 <%--<div class="modal-header">--%>
                                       
                                        <h4 class="modal-title" id="myModal-label"><asp:Label ID="lblEmpresa" runat="server" Text=""></asp:Label>  </h4>
                                        <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>--%>
                                   <%-- </div>--%>
                                 <div class="perfil_cargo col-lg-12"> 
                                        <p><b>Nuestro cliente nos encomendó la búsqueda de una persona para desarrollarse profesionalmente como: 
                                            <asp:Label ID="lblCargo"  runat="server" Text=" ANALISTA DE RISGOS"></asp:Label>
                                            <asp:Label ID="lblArea" Visible="false" ForeColor="Orange" runat="server" Text=""></asp:Label> de la sucursal de 
                                            <asp:Label ID="lblLugar"  runat="server" Text=""></asp:Label>
                                            ,para que sea parte de un equipo colaborativo, abierto al cambio así como a implementar ideas innovadoras.
                                           </b></p>
                                        <p><b><asp:Label ID="lblTipoConvocatoria" ForeColor="Orange" Visible="false" runat="server" Text=" Consultor en línes"></asp:Label></b></p>
                                        <p><b><asp:Label ID="lblCodConvocatoria" ForeColor="Cyan"  runat="server" Visible="false" Text=""></asp:Label></b></p>
                                        <p><b> Objetivo del cargo: </b></p>
                                        <p><b><asp:Label ID="lblObjetivo"  runat="server" Text=""></asp:Label></b></p>
                                        <p><b>Requisitos generales</b></p>
                                        <p><b><asp:Label ID="lblFomracion" Visible="false" ForeColor="Orange" runat="server" Text=""></asp:Label></b></p>
                                        <p><b><asp:Label ID="lblDescFormacion" Visible="true" runat="server" Text=""></asp:Label></b></p>
                                        <p><b>Ten en cuenta que valoraremos experiencia de al menos <asp:Label ID="lblGeneral" runat="server" Text=""></asp:Label> años en cargos de similar complejidad en el sistema financiero, 
                                            liderando equipos de trabajo en el que hayas dejado huella positiva.</b></p>
                                        <p><b></b></p>
                                        <p><b><asp:Label ID="lblDescGeneral" Visible="false" ForeColor="Orange" runat="server" Text=""></asp:Label></b></p>
                                        <p><b><asp:Label ID="lblEspecifica" Visible="false" ForeColor="Orange" runat="server" Text=""></asp:Label></b></p>
                                        <p><b><asp:Label ID="lblDescEspecifica" Visible="false" ForeColor="Orange" runat="server" Text=""></asp:Label></b></p>
                                       <%-- <p><b>Conocimientos </b><br /></p>
                                            <ul>
                                                <li><asp:Label ID="lblVista9" runat="server" Text="Conocimeinto de la Ley 1883 y Codigo de comercio"></asp:Label></li>
                                                <li><asp:Label ID="lblVista10" runat="server" Text="Dominio de ingles (Intermedio)"></asp:Label></li>
                                                <li><asp:Label ID="lblVista11" runat="server" Text="Dominio de Oficce (Avanzado)"></asp:Label></li>
                                            </ul>--%>
                                        <p><b>Competencias requeridas</b></p>
                                           <ul>
                                                <asp:Repeater ID="Repeater1" DataSourceID="odsCompetencias"  runat="server">
										            <ItemTemplate>
                                                        
                                                        <li><asp:Label ID="lblcompetencias" Font-Bold="true" runat="server" Text='<%# Eval("DESC_COMPETENCIA") %>'></asp:Label></li>
                                                        <%--<p><b>* </b></p>--%>
										            </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                       <p><b>Las personas interesadas deberán realizar los siguientes pasos:</b></p>
                                            <ul>
                                                <li><p><b>1. Registrar sus datos personales, laborales y académicos en la sección Perfil.</b></p></li>
                                                <li><p><b>2. Seleccionar la convocatoria a la cual quiere postularse y elegir solamente la información que esté relacionada al cargo al que postula, seleccionando las opciones que correspondan en cuanto a experiencia, formación, estudios adicionales.</b></p></li>
                                                <li><p><b>3. Llenar la información requerida en la Declaración Jurada.</b></p></li>
                                                
                                            </ul>
                                             <p><b>Nota.  Una vez presione el botón declarar, no podrá modificar su postulación, por lo que se recomienda revisar todos los pasos mencionados anteriormente antes de finalizar su postulación.</b></p>
                                        
                                        <p><b>Puedes postularte hasta el <asp:Label ID="lblFechaLimite" runat="server" Text=""></asp:Label></b></p>
                               
                       <%-- <p><b>Importante</b></p>
                         <p>Solo se tomarán en cuenta las postulaciones que cumplan con los requisitos publicados en la presente convocatoria.</p>--%>
                                       </div>  
					       </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnPostular" OnClick="btnPostular_Click" class="btn btn-primary" runat="server" Text="Postular" />
                        <asp:Button ID="btnCerrar" OnClick="btnCerrar_Click" class="btn btn-default" runat="server" Text="Cerrar" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
