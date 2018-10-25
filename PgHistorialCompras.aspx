<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PgHistorialCompras.aspx.cs" Inherits="PgHistorialCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>


    <!-- Estilos. Primero Bootstrap, después propios-->

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"
          integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="styles.css">

    <title>Pagina de Inicio</title>
    <script>
        function callHandler() {
            PageMethods.sayHi(); 
        }
    </script>
</head>
<body>

    <!-- Navbar con opciones -->

    <div class="container-fluid">
      <div class="row">
        <nav class="col-md-2 d-none d-md-block bg-light sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
              <li class="nav-item">
                <a class="nav-link bg-light" href="PgPrincipal.aspx">
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
                <a class="nav-link bg-light" href="PgBusqueda.aspx">
                  <span data-feather="shopping-cart"></span>
                  Busqueda
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link bg-light" href="#">
                  <span data-feather="users"></span>
                  Mi Carrito <span class="badge badge-pill badge-primary"> <% Response.Write(this.carritoDeCompras.Count); %> </span>
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link active bg-light" href="PgHistorialCompras.aspx">
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
        <div class="container-fluid">
          <form runat="server">
              <asp:ScriptManager runat="server" EnablePageMethods="true" /> 
              <div class="row justify-content-center">
                <h4 class="display-4"> Historial de compras de <% Response.Write(usuarioActual.nombre);  %> </h4>
                
              </div>
              <div class="row justify-content-center">
                

              
              </div>
              
                
                <% Response.Write(placeHolderHtml);  %>
              
          </form>
        </div>


        </main>
      </div>
    </div>

</body>
</html>
