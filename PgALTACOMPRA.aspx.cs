using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgComfCompra : System.Web.UI.Page {


    //Atributos de clase
    GestorBD.GestorBD gestorLocal;
    public Cancion cancionComprada; 
    const string SERVERNAME = "SQLNCLI11";
    public  List<int> carritoDeCompras = new List<int>();
    Usuario usuarioActual; 

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
        

    }

    


}