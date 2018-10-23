<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PgComfCompra.aspx.cs" Inherits="PgComfCompra" %>

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
                <a class="nav-link bg-light" href="#">
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
                <a class="nav-link active bg-light" href="#">
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
        <div class="container-fluid">
          <div class="row justify-content-center">
              <img class="rounded-circle" src="<% Response.Write(cancionComprada.picURL); %>"  style="width: 25%; height: 12.5%; "/>
          </div>
          <div class="row justify-content-center pt-4">
             <h3 class="display-4"> <% Response.Write(cancionComprada.nombre);  %></h3>
          </div>
          <div class="row justify-content-center ">
            <p> <% Response.Write(cancionComprada.getDescription());  %></p>
          </div>
            <form runat="server">
                <div class="row justify-content-center ">
                    <asp:Button runat="server" CssClass="btn btn-primary bg-dark" Text="Confirmar compra" OnClick="compra_Click" />
                </div>
            </form>
        </div>


        </main>
      </div>
    </div>

</body>
</html>
