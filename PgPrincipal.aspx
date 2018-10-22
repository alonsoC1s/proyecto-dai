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
        <nav class="col-md-2 d-none d-md-block bg-dark sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
              <li class="nav-item">
                <a class="nav-link active" href="#">
                  <span data-feather="Inicio"></span>
                  Inicio <span class="sr-only">(current)</span>
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="file"></span>
                  Mi Cuenta
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="shopping-cart"></span>
                  Busqueda
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="users"></span>
                  Mi Carrito
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="bar-chart-2"></span>
                  Historial de compras
                </a>
              </li>
              <li class="nav-item">
                  <a class="nav-link" href="Default.aspx">
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
          <div class="row">
              <div class="container-fluid">
                  <h5> Top 5 canciones más vendidas</h5>
              </div>
          </div>

          

        </main>
      </div>
    </div>

</body>
</html>
