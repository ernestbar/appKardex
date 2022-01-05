<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="kardex.aspx.cs" Inherits="appRRHHDF.kardex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsPersonal" runat="server" SelectMethod="PR_SEG_GET_PERSONAL_ALL" TypeName="appRRHHDF.clases.Personal">
		 </asp:ObjectDataSource>
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
	<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
	<asp:Label ID="lblIdPersonal" runat="server" Visible="false" Text=""></asp:Label>
	<div id="content" class="content">
            <!-- begin breadcrumb -->
			<ol class="breadcrumb pull-right">
				<li class="breadcrumb-item"><a href="javascript:;">Kardex</a></li>
				
			</ol>
			<!-- end breadcrumb -->
			<!-- begin page-header -->
			<h1 class="page-header">ADMINISTRADOR DE PERSONAL  <small></small></h1>
			<!-- end page-header -->
			 <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
     <div class="m-b-20 col-lg-12" style="float:left;background:#fff">
                             <%--  <p> </p>--%>
								    <div class="login-buttons col-lg-12">
                                        <asp:Button ID="btnAdicionarPersonal" runat="server" class="btn btn-success btn-block btn-lg" Text="+ Adicionar Personal" Width="220px" OnClick="btnAdicionarPersonal_Click"/>
                                    </div>
                                <div class="panel-body">
					                <table id="data-table-default" class="table table-striped table-bordered">
						                <thead>
							                <tr>
								                <th class="text-nowrap">ID</th>
								                <th class="text-nowrap">NOMBRE COMPLETO</th>
								                <th class="text-nowrap">DOCUMENTO</th>
								                <th class="text-nowrap">EXPEDIDO</th>
								                <th class="text-nowrap">CELULAR</th>
								                <th class="text-nowrap">CORREO</th>
								                <th class="text-nowrap">Acciones</th>
							                </tr>
						                </thead>
						                <tbody>
							               <asp:Repeater ID="Repeater1" DataSourceID="odsPersonal" runat="server">
														<ItemTemplate>
															 <tr class="odd gradeX">
																<td><asp:Label ID="lblTipoParentesco" runat="server" Text='<%# Eval("PER_ID_PERSONAL") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("NOMBRE_COMPLETO") %>'></asp:Label></td>
																 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# Eval("PER_NUMERO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("DESC_EXPEDIDO") %>'></asp:Label></td>
																<td><asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("TELEFONO_CELULAR") %>'></asp:Label></td>
																<td><asp:Label ID="lblNombres" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'></asp:Label></td>
																<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PER_ID_PERSONAL") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar registro" />
																		<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" Enabled="true" CommandArgument='<%# Eval("PER_ID_PERSONAL") %>' OnClientClick="return confirm('Seguro que desea eliminar el registro???')" OnClick="btnEliminar_Click"  runat="server" Text="Eliminar" ToolTip="Eliminar Registro" />--%>
																</td>
															</tr>
														</ItemTemplate>
												 </asp:Repeater>
						                </tbody>
					                </table>
				                </div>
                            </div>
		</div>
</asp:Content>
