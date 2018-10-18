<%@ Page Language="C#" Inherits="sitiodai.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
        
    <!-- Estilos. Primero Bootstrap, después propios-->       
        
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" 
          integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="styles.css">
        
        
	<title>Proyecto de DAI</title>
</head>
<body>
	
     <!-- Empezamos Contenido. Primer contenedor--> 
     <div class="container-fluid h-100">
        <div class="row">
            <div class="col-md-2 main-color"></div>
            <div class="col-md-8">
                <div class="jumbotron-fluid p-5">
                        
                    <h4 class="display-4"> Bienvenido </h4>
                    <h5>Inicia Sesión </h5>
                        
                    <form runat="server">
                    <asp:login runat="server" id="MyLoginControl">
                            
                    </asp:login>
                    </form>
                </div>
            </div>
            <div class="col-md-2 main-color"></div>
        </div>
        <div class="row">
            <div class="col">
                <p> Copyright © Alonso Martinez C.
            </div>
        </div>
     </div>
     
</body>
</html>
