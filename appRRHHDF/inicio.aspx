<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="appRRHHDF.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
    
	<div id="content" class="content">
        <div class="tab-content">
            
            <div class="carouselExampleIndicators col-lg-11" style="width:70%;margin: 5px 80px;text-align:center">
            <h1>BIENVENIDO </h1> <br />
            <p>Bienvenido a nuestro espacio de registro de datos profesionales y de postulaciones a convocatorias. </p>
                <p>Por favor ingresa a MI PERFIL si es la primera vez, ingresaras tus datos o si quieres editar tu información.</p>
                <p>Ingresa a CONVOCATORIAS VIGENTES luego de realizar tu registro y/o actualizar tus datos, y a continuación postula a la convocatoria de tu interés.</p>
		    </div>
            <div id="carouselExampleIndicators" class="carousel slide col-lg-10" data-ride="carousel"  style="width:80%;margin: 5px 80px;text-align:center">
                 
                    <ol class="carousel-indicators">
                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                  </ol>
                  <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img class="d-block w-100" src="slider/img/slides/slide2.jpg" alt="Ingresa a tu perfil"/>    
                            <div data-wow-delay="0.4s" data-wow-duration="4s" class="button" style ="margin-top:-100px; margin-left:20%;margin-bottom:30px" >							       
								        <span><a href="formulario.aspx" class="btn btn-success" style="font-size:12pt;color:#FFF"> Ver Perfil </a></span>							        
						    </div>
                        </div>
                        <div class="carousel-item">
                            <img class="d-block w-100" src="slider/img/slides/slide1.jpg" alt="Ingresa a ver convocatorias"/>    
                            <div data-wow-delay="0.4s" data-wow-duration="4s" class="button" style ="margin-top:-100px; margin-left:20%;margin-bottom:30px" >
								        <span><a href="Convocatorias.aspx" class="btn btn-success" style="font-size:12pt;color:#FFF"> Ver Convocatorias </a></span>							       
						    </div>
                        </div>
                          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                          </a>
                          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                          </a>   
                </div>		
            </div>		
	</div>
      </div>



</asp:Content>
