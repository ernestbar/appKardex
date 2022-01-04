<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="descargas.aspx.cs" Inherits="appRRHHDF.descargas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- begin #content -->
		<div id="content" class="content">
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
				<li class="breadcrumb-item active">Centro de descargas</li>
			</ol>
              <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
	          <asp:Label ID="lblIdPersonal" runat="server" Text="" Visible="false"></asp:Label>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header" style="color:#fff;font-weight:bold;">TUTORIALES<small></small></h1>
			<!-- end page-header -->
			<div class="perfil_cargo col-lg-12"> 
                <p><b>Bienvenido al centro de tutoriales, en esa seccion podras descargar el contenido actualizado de guias o videos, que iremos posteando para tu comodidad.
                    </b></p>
                                       
                <%-- <p><b>Conocimientos </b><br /></p>
                    <ul>
                        <li><asp:Label ID="lblVista9" runat="server" Text="Conocimeinto de la Ley 1883 y Codigo de comercio"></asp:Label></li>
                        <li><asp:Label ID="lblVista10" runat="server" Text="Dominio de ingles (Intermedio)"></asp:Label></li>
                        <li><asp:Label ID="lblVista11" runat="server" Text="Dominio de Oficce (Avanzado)"></asp:Label></li>
                    </ul>--%>
                <p><b>Tutoriales disponibles:</b></p>
                    <ul>
                        <asp:LinkButton ID="lbtnPDF" OnClick="lbtnPDF_Click" runat="server">Descargar PDF</asp:LinkButton>
                        <asp:LinkButton ID="lbtnVideo" OnClick="lbtnVideo_Click" Visible="false" runat="server">Descargar Video</asp:LinkButton>
                                                
                    </ul>
                </div>  
		</div>
</asp:Content>
