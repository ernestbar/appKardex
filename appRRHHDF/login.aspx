<<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="appRRHHDF.login" %>

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
	 <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 2px Red;
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
			<%--<div class="login-header">--%>
				<%--<div class="brand">--%>
					<span><img src="Imagenes/logo.png" width="350" /></span> 
                    <br />  
					<small><asp:Label ID="lblAviso" runat="server" Text="Label"></asp:Label> </small>
                    
				<%--</div>--%>
			<%--	<div class="icon">
					<i class="fa fa-lock"></i>
				</div>--%>
			<%--</div>--%>
			<!-- end brand -->
			<!-- begin login-content -->
			<div class="login-content">
                    <%--<form action="index.html" method="GET" class="margin-bottom-0">--%>
                    <div class="form-group m-b-20">
                        <span>Correo Electrònico</span>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" ></asp:RequiredFieldValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtEmail" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg inverse-mode" ForeColor="white" placeholder="admin@admin.com.bo"></asp:TextBox>
                    </div>
					  <div class="login-buttons col-lg-6" style="float:left; display:block;margin:5px 0">
                        <span>Password</span>
						  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Yellow" ControlToValidate="txtPassword" InitialValue="" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
                     <div class="login-buttons col-lg-6" style="float:left; display:block;margin:5px 0">
                         <asp:LinkButton ID="lbtnReset" CausesValidation="false" OnClick="btnReset_Click" runat="server" Font-Size="small" style="background-color:transparent; border:none;color:white">Olvido su Contraseña?</asp:LinkButton>
						      <%--<asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Olvido su Contraseña?"  Font-Size="small" style="background-color:transparent; border:none;color:#808080" />--%>
                     </div>
                    <div class="form-group m-b-20">
                             
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg inverse-mode" ForeColor="white" placeholder="Ingrese su password" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="login-buttons">
						     <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" class="btn btn-success btn-block btn-lg"  Text="Ingresar"/>
                    </div>					 
                    <div class="login-buttons col-lg-12" style="float:left;margin:5px 0;text-align:center">
                         <span>Todavía no se ha registrado?</span>
                        <asp:LinkButton ID="lbtnResgistro" Font-Size="medium" CausesValidation="false" style="background-color:transparent; border:none;color:#1f6bff" OnClick="btnRegistro_Click" runat="server">Registrate aquí</asp:LinkButton>
                        <%--<asp:Button ID="btnRegistro" runat="server"  Font-Size="medium" style="background-color:transparent; border:none;color:#1f6bff" OnClick="btnRegistro_Click" Text="Registrate aqui"/>--%>
                                            
                    </div>
                    <%--</form>--%>
					
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