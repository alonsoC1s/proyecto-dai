<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PgPrincipal.aspx.cs" Inherits="PgPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>


    <!-- Estilos. Primero Bootstrap, después propios-->

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"
          integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="styles.css">

    <title>Pagina de Inicio</title>
</head>
<body>

    <!-- Navbar con opciones -->

    <div class="container-fluid">
      <div class="row">
        <nav class="col-md-2 d-none d-md-block bg-light sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
              <li class="nav-item">
                <a class="nav-link active bg-light" href="#">
                  <span data-feather="Inicio"></span>
                  Inicio <span class="sr-only">(current)</span>
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link bg-light" href="#">
                  <span data-feather="file"></span>
                  Mi Cuenta
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link bg-light" href="#">
                  <span data-feather="shopping-cart"></span>
                  Busqueda
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link bg-light" href="#">
                  <span data-feather="users"></span>
                  Mi Carrito
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link bg-light" href="#">
                  <span data-feather="bar-chart-2"></span>
                  Historial de compras
                </a>
              </li>
              <li class="nav-item">
                  <a class="nav-link bg-light" href="Default.aspx">
                      Salir
                  </a>
              </li>
            </ul>


          </div>
        </nav>

        <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
          <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <div class="jumbotron-fluid">
                <h4 class="display-4"> Bienvenido <% Response.Write(hola);  %></h4>
            </div>
          </div>

              <div class="container-fluid">
                  <h5> Top 6 canciones más vendidas</h5>
              </div>


              <!-- Album con todas las canciones -->
              <!-- Falta agregar un Form para activar los botones -->
              <div class="album py-5 bg-light">
        <div class="container">

        <form runat="server">
          <div class="row">
            <!-- Elementos de C# para ejecutar -->

            <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="<% Response.Write(populares[0].picURL); %>">
                <div class="card-body">
                  <h5 class="card-text"> <% Response.Write(populares[0].nombre); %> </h5>
                  <h6 class="card-text"> <% Response.Write(populares[0].artista);  %> </h6>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="card-text"> <% Response.Write(populares[0].getDescription());  %> </p>
                  </div>
                  <div class="d-flex justify-content-center pt-3">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" text="Comprame" CommandName="ThisBtnClick" OnClick="Unnamed_Click" /> 
                  </div>
                </div>
              </div>
            </div>

            <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="<% Response.Write(populares[1].picURL); %>">
                <div class="card-body">
                  <h5 class="card-text"> <% Response.Write(populares[1].nombre); %> </h5>
                  <h6 class="card-text"> <% Response.Write(populares[1].artista);  %> </h6>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="card-text"> <% Response.Write(populares[1].getDescription());  %> </p>
                  </div>
                  <div class="d-flex justify-content-center pt-3">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" text="Comprame"  /> 
                  </div>
                </div>
              </div>
            </div>

            <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="<% Response.Write(populares[2].picURL); %>">
                <div class="card-body">
                  <h5 class="card-text"> <% Response.Write(populares[2].nombre); %> </h5>
                  <h6 class="card-text"> <% Response.Write(populares[2].artista);  %> </h6>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="card-text"> <% Response.Write(populares[2].getDescription());  %> </p>
                  </div>
                  <div class="d-flex justify-content-center pt-3">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" text="Comprame" /> 
                  </div>
                </div>
              </div>
            </div>

            <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="<% Response.Write(populares[3].picURL); %>">
                <div class="card-body">
                  <h5 class="card-text"> <% Response.Write(populares[3].nombre); %> </h5>
                  <h6 class="card-text"> <% Response.Write(populares[3].artista);  %> </h6>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="card-text"> <% Response.Write(populares[3].getDescription());  %> </p>
                  </div>
                  <div class="d-flex justify-content-center pt-3">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" text="Comprame" /> 
                  </div>
                </div>
              </div>
            </div>

            <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="<% Response.Write(populares[4].picURL); %>">
                <div class="card-body">
                  <h5 class="card-text"> <% Response.Write(populares[4].nombre); %> </h5>
                  <h6 class="card-text"> <% Response.Write(populares[4].artista);  %> </h6>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="card-text"> <% Response.Write(populares[4].getDescription());  %> </p>
                  </div>
                  <div class="d-flex justify-content-center pt-3">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" text="Comprame" /> 
                  </div>
                </div>
              </div>
            </div>

            <div class="col-md-4">
              <div class="card mb-4 box-shadow">
                <img class="card-img-top" src="<% Response.Write(populares[5].picURL); %>">
                <div class="card-body">
                  <h5 class="card-text"> <% Response.Write(populares[5].nombre); %> </h5>
                  <h6 class="card-text"> <% Response.Write(populares[5].artista);  %> </h6>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="card-text"> <% Response.Write(populares[5].getDescription());  %> </p>
                  </div>
                  <div class="d-flex justify-content-center pt-3">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" text="Comprame" /> 
                  </div>
                </div>
              </div>
            </div>

            
            <!-- Termina row de tarjetas --> 

          </div>
        </form>
        </div>
      </div>
          </div>



        </main>
      </div>
    </div>

</body>
</html>
