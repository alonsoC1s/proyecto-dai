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

    protected void Page_Load(object sender, EventArgs e) {
        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;
        }

        this.cancionComprada = (Cancion)Session["CancionComprada"]; 
    }

    protected void compra_Click(object sender, EventArgs e)
    {

        //Obtenemos id de usuario y de cancion para la alta 
        Usuario userActual = (Usuario)Session["UsuarioActual"]; 

        // Dando de alta la compra. Asumimos que el gestor ya fue inicializado. 
        string cadSQL = "insert into Compra values (" + this.cancionComprada.cid + "," + userActual.Uid +
            ", getDate(), " + this.cancionComprada.precio.ToString() + ");" ;

        Response.Write(cadSQL);

    }
}