<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrate.aspx.cs" Inherits="appRRHHDF.registrate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
	<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	
	<!-- ================== BEGIN BASE CSS STYLE ================== -->
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
	<link href="assets/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/font-awesome/5.3/css/all.min.css" rel="stylesheet" />
	<link href="assets/plugins/animate/animate.min.css" rel="stylesheet" />
	<link href="assets/css/default/style.min.css" rel="stylesheet" />
	<link href="assets/css/default/style-responsive.min.css" rel="stylesheet" />
	<link href="assets/css/default/theme/default.css" rel="stylesheet" id="theme" />
	<!-- ================== END BASE CSS STYLE ================== -->
	
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/pace/pace.min.js"></script>
	<!-- ================== END BASE JS ================== -->

</head>
<body class="pace-top">
	<form runat="server">
		<asp:ObjectDataSource ID="odsTipoDocumento" runat="server" SelectMethod="Lista" TypeName="appRRHHDF.clases.dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="TIPO DOCUMENTO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
		<!-- begin #page-loader -->
	<div id="page-loader" class="fade show"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	
	<!-- begin login-cover -->
	<div class="login-cover">
		<%--<div class="login-cover-image" style="background-image: url(assets/img/login-bg/login-bg-17.jpg)" data-id="login-cover-image"></div>--%>
		<div class="login-cover-image" style="background-image: url(Fotos/fondo1.jpg)" data-id="login-cover-image"></div>
		<div class="login-cover-bg"></div>
	</div>
	<!-- end login-cover -->
	
	<!-- begin #page-container -->
	<div id="page-container" class="fade">
		<!-- begin login -->
		<div class="login login-v2" data-pageload-addclass="animated fadeIn">
			<!-- begin brand -->
			<div class="login-header">
				<div class="brand">
					<span><img src="Imagenes/logo.png" width="350" /></span> 
                    <br />  
					<h3 style="width:370px;text-align:center;">Formulario de registro</h3>
                    <small  style="width:370px;text-align:center;"><asp:Label ID="lblAviso" class="col-form-label" ForeColor="Black" runat="server" Text="Proporciona los siguientes datos para crear tu usuario."></asp:Label></small>
                    
				</div>
				<div class="icon">
					<i class="fa fa-lock"></i>
				</div>
			</div>
			<!-- end brand -->
			<!-- begin login-content -->
                <div class="login-content">
                    <%--<form action="index.html" method="GET" class="margin-bottom-0">--%>
                    <div class="form-group m-b-20">
                        <span>Nombre</span>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtNombre" Font-Bold="True"></asp:RequiredFieldValidator>
						<asp:TextBox ID="txtNombre" class="form-control form-control-lg inverse-mode" ForeColor="White" placeholder="Nombre" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group m-b-20">
                        <span>Apellido Paterno</span>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtPaterno" Font-Bold="True"></asp:RequiredFieldValidator>
						<asp:TextBox ID="txtPaterno" class="form-control form-control-lg inverse-mode" ForeColor="White" placeholder="Apellido Paterno" runat="server"></asp:TextBox>
                        
                    </div>
					<div class="form-group m-b-20">
                        <span>Apellido Materno</span>
                        <asp:TextBox ID="txtMaterno" class="form-control form-control-lg inverse-mode" ForeColor="White" placeholder="Apellido Materno" runat="server"></asp:TextBox>

                    </div>
					<div class="form-group m-b-20">
                        <span>Tipo Documento</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="ddlTipoDocumento" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						<asp:DropDownList ID="ddlTipoDocumento" DataSourceID="odsTipoDocumento" ForeColor="White" OnDataBound="ddlTipoDocumento_DataBound" DataTextField="dom_descripcion" DataValueField="dom_codigo" class="form-control form-control-lg inverse-mode" runat="server"></asp:DropDownList>
                    </div>
					<div class="form-group m-b-20">
                        <span>Numero Documento</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtNumeroDocumento" Font-Bold="True"></asp:RequiredFieldValidator>
						<asp:TextBox ID="txtNumeroDocumento" ForeColor="White" class="form-control form-control-lg inverse-mode" placeholder="Numero de documento" runat="server"></asp:TextBox>

                    </div>
					<div class="form-group m-b-20">
                        <span>Correo electrónico</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						<asp:TextBox ID="txtEmail" ForeColor="White" class="form-control form-control-lg inverse-mode" placeholder="Correo electrónico" runat="server"></asp:TextBox>
                    </div>
                    <div class="login-buttons">
						<asp:Button ID="btnIniciarRegistro" class="btn btn-success btn-block btn-lg" OnClick="btnIniciarRegistro_Click"  runat="server" Text="Iniciar registro" />
                    </div>
					<div class="login-buttons">
						<asp:Button ID="btnCancelar" class="btn btn-danger btn-block btn-lg" OnClick="btnCancelar_Click" CausesValidation="false"  runat="server" Text="Cancelar" />
                    </div>
                </div>
                <!-- end login-content -->
		</div>
		<!-- end login -->
		
	</div>
	<!-- end page container -->
    <!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/jquery/jquery-3.3.1.min.js"></script>
	<script src="assets/plugins/jquery-ui/jquery-ui.min.js"></script>
	<script src="assets/plugins/bootstrap/4.1.3/js/bootstrap.bundle.min.js"></script>
	<!--[if lt IE 9]>
		<script src="assets/crossbrowserjs/html5shiv.js"></script>
		<script src="assets/crossbrowserjs/respond.min.js"></script>
		<script src="assets/crossbrowserjs/excanvas.min.js"></script>
	<![endif]-->
	<script src="assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>
	<script src="assets/plugins/js-cookie/js.cookie.js"></script>
	<script src="assets/js/theme/default.min.js"></script>
	<script src="assets/js/apps.min.js"></script>
	<!-- ================== END BASE JS ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL JS ================== -->
	<script src="assets/plugins/highlight/highlight.common.js"></script>
	<script src="assets/js/demo/render.highlight.js"></script>
	<!-- ================== END PAGE LEVEL JS ================== -->
	<script>
        $(document).ready(function () {
            App.init({
                disableDraggablePanel: true
            });
            Highlight.init();
        });
    </script>	
		</form>
</body>
</html>


