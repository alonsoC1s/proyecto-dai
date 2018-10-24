using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgComfCompra : System.Web.UI.Page {


    //Atributos de clase
    GestorBD.GestorBD gestorLocal;
    public Cancion cancionComprada; 
    const string SERVERNAME = "SQLNCLI11";
    public  List<int> carritoDeCompras = new List<int>(); 

    protected void Page_Load(object sender, EventArgs e) {
        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;
        }

        //Recuperamos datos
        this.cancionComprada = (Cancion)Session["CancionComprada"];
        this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];
    }

    //TODO: Ver que metodo se usa cuando la pagina es limpiada. OnUnload

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