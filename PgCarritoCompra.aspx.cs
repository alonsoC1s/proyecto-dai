using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgCarritoCompra : System.Web.UI.Page
{

    public string hola = "nombre";
    const string SERVERNAME = "SQLNCLI11";
    public Usuario usuarioActual;
    private GestorBD.GestorBD gestorLocal;
    DataSet DsGeneral = new DataSet();
    string top5Songs;
    public Cancion[] populares = new Cancion[6];
    public List<int> carritoDeCompras = new List<int>();


    protected void Page_Load(object sender, EventArgs e)
    {
        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack)
        {
            //Inicializamos el gestor y lo guardamos en session.
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;
            this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];
        }


        // Recuperamos el nombre del usuario de session, y el gestor iniciado.
        this.gestorLocal = (GestorBD.GestorBD)Session["Gestor"];
        this.usuarioActual = (Usuario)Session["UsuarioActual"];
        this.hola = this.usuarioActual.nombre;
        this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];
    }
}