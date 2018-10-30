using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// La clase representa la página de confirmación de compra. Se encarga de añadir una cancion en el caso de que el usuario la seleccione
public partial class PgComfCompra : System.Web.UI.Page {


    //Atributos de clase
    GestorBD.GestorBD gestorLocal;
    public Cancion cancionComprada; 
    const string SERVERNAME = "SQLNCLI11";
    public  List<int> carritoDeCompras = new List<int>();
    private DataSet DsGeneral = new DataSet(); 
    public int CID; 

    // Llamado cuando la pagina termina de cargar. Obtiene referencias a instancias compartidas y checa si el usuario está loggeado
    protected void Page_Load(object sender, EventArgs e) {
        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;
        }

        //Recuperamos datos
        this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];
        this.gestorLocal = (GestorBD.GestorBD)Session["Gestor"];

        // Recuperamos el id pasado por la pagina anterior en forma de un queryString
        try{
            this.CID = int.Parse(Request.QueryString["cid"]);
        }catch (Exception ex){
            Server.Transfer("PgPrincipal.aspx");
        }

        // Recuperamos cancion comprada con el id consultando bd
        string qryStr = String.Format("Select * from Cancion where cid={0}", CID);
        this.gestorLocal.consBD(qryStr, DsGeneral, "cancion");

        string nombre = this.DsGeneral.Tables["cancion"].Rows[0]["nombre"].ToString();
        string artista = this.DsGeneral.Tables["cancion"].Rows[0]["artista"].ToString();
        string album = this.DsGeneral.Tables["cancion"].Rows[0]["album"].ToString();
        int ano = (int)this.DsGeneral.Tables["cancion"].Rows[0]["año"];
        decimal precio = Convert.ToDecimal(this.DsGeneral.Tables["cancion"].Rows[0]["precio"]);
        string pic = this.DsGeneral.Tables["cancion"].Rows[0]["picURL"].ToString();
        int cid = (int)this.DsGeneral.Tables["cancion"].Rows[0]["cid"];

        this.cancionComprada = new Cancion(nombre, artista, album, ano, precio, pic, cid); 
    }

    // Método escucha. Llamado cuando el usuario confirma que quiere añadir la cancion al carrito.
    // Añade el id de canción a una lista de id´s como instancia compartida, y regresa al usuario al terminar.
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
        Server.Transfer("PgBusqueda.aspx"); 

    }
}