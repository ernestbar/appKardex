<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reportePostulacion.aspx.cs" Inherits="appRRHHDF.reportePostulacion" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Convocatorias</a></li>
				<li class="breadcrumb-item active">Postulaciones</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header"><asp:Label ID="lblCodConvocatoria" runat="server" Visible="true" Text=""></asp:Label><small></small></h1>
			<h5><asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Text=""></asp:Label></h5>
			<!-- end page-header -->
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
	<asp:Label ID="lblIdPersonal" runat="server" Visible="false" Text=""></asp:Label>
	
			<div class="row">
										<h1 class="page-header">Imprime tu postulacion <small></small></h1>
										<br />
										 <div style="overflow-y: auto; height:600px;width:90%">
										<rsweb:ReportViewer ID="rv" runat="server" Height="100%" Width="90%" ShowZoomControl="False" ShowRefreshButton="False" ShowPageNavigationControls="True" ShowFindControls="False" ShowBackButton="False" SizeToReportContent="True"></rsweb:ReportViewer>
										</div>
									</div>
								  </div>

		
		</div>
	
</asp:Content>
