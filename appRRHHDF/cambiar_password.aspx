<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambiar_password.aspx.cs" Inherits="appRRHHDF.cambiar_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cambio de contraseña</title>
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
					<small><asp:Label ID="lblAviso" runat="server" Text="Label"></asp:Label> </small>
                    <asp:Label ID="lblUsuario" runat="server" Visible="false" ></asp:Label>
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
                        <span>Usuario </span>
                        <asp:TextBox ID="txtUsuario" runat="server" ReadOnly="true" class="form-control form-control-lg inverse-mode" placeholder="Ingrese su password actual" ForeColor="white" ></asp:TextBox>
                    </div>
                    <div class="form-group m-b-20">
                        <span>Contraseña anterior </span>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtPassAnt" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassAnt" runat="server" class="form-control form-control-lg inverse-mode" placeholder="Ingrese su password actual" ForeColor="white" TextMode="Password" ></asp:TextBox>
                    </div>
                    <div class="form-group m-b-20">
                        
                        <span>Nueva contraseña</span>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtPassword" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg inverse-mode" ForeColor="white" placeholder="Ingrese su nuevo password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group m-b-20">
                        
                        <span>Repetir contraseña</span>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtPasswordRep" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPasswordRep" runat="server" class="form-control form-control-lg inverse-mode" ForeColor="white" placeholder="Confirme su nuevo password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="login-buttons">
                        <asp:Button ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" class="btn btn-success btn-block btn-lg" Text="Ingresar" />
                    </div>
					 <div class="login-buttons">
                        <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" CausesValidation="false" class="btn btn-grey btn-block btn-lg" Text="Volver" Visible="false"/>
                    </div>
                    <%--</form>--%>
              <%--  <small>Todavía no se ha registrado? <a href="">Registrese aquí.</a></small>--%>
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