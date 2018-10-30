using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Clase que representa la página de confirmación de compra.
// Dicha página solo muestra un mensaje de confirmación, y hace las altas a BD
public partial class PgComfCompra : System.Web.UI.Page {


    //Atributos de clase
    GestorBD.GestorBD gestorLocal;
    public Cancion cancionComprada;
    const string SERVERNAME = "SQLNCLI11";
    public  List<int> carritoDeCompras = new List<int>();
    Usuario usuarioActual;

    // Método llamado cuando la página termina de cargar. Encargada de obtener referencias a las
    // instancias compartidas como usuarioActual, carritoDeCompras, gestorBD, etc...
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
        this.usuarioActual = (Usuario)Session["UsuarioActual"];

        //Hacemos las altas
        StringBuilder sb = new StringBuilder();
        foreach (int cid in this.carritoDeCompras)
        {
            sb.AppendFormat("insert into Compra values({0}, {1}, getDate(), {2}  ); \n ", cid, this.usuarioActual.Uid, 200 );
        }

        string sqlQry = sb.ToString();

        this.gestorLocal.altaBD(sqlQry);

        // Borramos los contenidos del carrito
        this.carritoDeCompras.Clear(); 


    }




}
