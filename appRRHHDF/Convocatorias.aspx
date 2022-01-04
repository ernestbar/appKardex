<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Convocatorias.aspx.cs" Inherits="appRRHHDF.Convocatorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	 <asp:ObjectDataSource ID="odsConvocatorias" runat="server" SelectMethod="PR_SEG_GET_CONVOCATORIAS_PUBLICADOS" TypeName="appRRHHDF.clases.Convocatorias2" >
		</asp:ObjectDataSource>
    <!-- begin #content -->
		<div id="content" class="content" style="background-color:#FFF;border:1PX solid #FBA100">
			<!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Inicio</a></li>
				<li class="breadcrumb-item active">Convocatorias</li>
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">Convocatorias Vigentes</h1>
            <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
			<asp:Label ID="lblIdPersonal" runat="server" Visible="false" Text=""></asp:Label>
			<!-- end page-header -->
			<!-- begin row -->
			<div class="row">				
				<!-- begin col-10 -->
				<div class="col-lg-11">
					<!-- begin panel -->
					<div class="panel panel-inverse">
					<%--	<!-- begin panel-heading -->
						<div class="panel-heading">
							<div class="panel-heading-btn">
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
								<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
							</div>
							<h4 class="panel-title">DataTable - Fixed Columns</h4>
						</div>
						<!-- end panel-heading -->--%>
						
						<!-- begin panel-body -->
						<div class="panel-body">
							<%--<table id="data-table-fixed-columns" class="table table-striped table-bordered">--%>
                              
					       <table id="data-table-default" class="table table-striped table-bordered">
								<thead STYLE="background-color:#e2e7eb;">
									<tr>
										<th class="text-nowrap">Código</th>
										<th class="text-nowrap">Nombre</th>
										<th class="text-nowrap">Estado</th>
										<th class="text-nowrap">Fecha Término</th>
										<th class="text-nowrap">Acciones</th>
									</tr>
								</thead>
								<tbody>
									 <asp:Repeater ID="Repeater1" DataSourceID="odsConvocatorias"  runat="server">
										 <ItemTemplate>
											 <tr class="gradeX">
												<td><asp:Label ID="lblCargo1" runat="server" Text='<%# Eval("CNV_CONVOCATORIA") %>' /></td>
												<td><asp:Label ID="lblCargo4" runat="server" Text='<%# Eval("CNV_NOMBRE_CARGO") %>'></asp:Label></td>
												<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("VIGENTE") %>'></asp:Label></td>
												<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("CNV_FECHA_FIN") %>'></asp:Label></td>
												<td> <asp:LinkButton ID="lbtnVer" CommandArgument='<%# Eval("CNV_CONVOCATORIA") %>' OnClick="lbtnVer_Click" runat="server"><i class="fa fa-eye" style="font-size:14pt;color:#808080;margin:0 5px"></i></asp:LinkButton>
													<%--<a href="javascript:;" data-click="sidebar-minify"><i class="fa fa-street-view" style="font-size:14pt;color:#000;margin:0 5px"></i></a>--%>
												</td>
											</tr>
										 </ItemTemplate>
									 </asp:Repeater>
									
								</tbody>
							</table>
						
						<!-- end panel-body -->
					</div>
					<!-- end panel -->
				</div>
				<!-- end col-10 -->
			</div>
			<!-- end row -->
		</div>
		<!-- end #content -->
        
</asp:Content>
