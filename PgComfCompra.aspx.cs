using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Clase que representa la página de confirmación de compra. Le deja al usuario ver la info. de canción y añadir al carrito
public partial class PgComfCompra : System.Web.UI.Page {


    //Atributos de clase
    GestorBD.GestorBD gestorLocal;
    public Cancion cancionComprada; 
    const string SERVERNAME = "SQLNCLI11";
    public  List<int> carritoDeCompras = new List<int>(); 

    // Método llamado al terminar de cargar. Obtiene referencias a instancias compartidas
    protected void Page_Load(object sender, EventArgs e) {
        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;
        }

        //Recuperamos datos
        // Recuperamos el nombre del usuario de session, y el gestor iniciado. Si alguno es null, redirect a login
        try
        {
            this.cancionComprada = (Cancion)Session["CancionComprada"];
            this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];
        }
        catch (Exception exx)
        {
            Server.Transfer("Default.aspx");
        }
    }


     // Método escucha llamado cuando el usuario da click en confirmar compra. Se encarga de añadir la cancion al carrito de compra
     // y se asegura de actualizar la instancia compartida de lista. 
    protected void compra_Click(object sender, EventArgs e)
    {

        //Obtenemos id de usuario y de cancion para la alta 
        Usuario userActual = (Usuario)Session["UsuarioActual"];

        // Actualizamos la lista de carrito de compras. Guardamos carrito en session 
        this.carritoDeCompras.Add(this.cancionComprada.cid);

        //Actualizamos instancias compartidas.
        Session["carritoDeCompras"] = carritoDeCompras;


        //Confirmamos y regresamos a pg principal
        Response.Write("<script>alert('Cancion añadida al carrito')</script>");
        Server.Transfer("PgPrincipal.aspx"); 

    }
}