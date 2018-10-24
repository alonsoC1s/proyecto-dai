using System;
using System.Collections.Generic;
using System.Data;
using System.Data.DataSet;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgBusqueda : System.Web.UI.Page
{

    // Atributos de clase 
    public List<int> carritoDeCompras = new List<int>();
    const string SERVERNAME = "SQLNCLI11";
    GestorBD.GestorBD gestorLocal;
    DataSet DsGeneral = new DataSet();
    public string placeHolderHtml; 


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
        this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];



    }

    protected void Busqueda_click(object sender, EventArgs e)
    {
        //Obtenemos los términos buscados 
        String qryCancion = txtCancion.Text;
        String qryArtista = txtArtista.Text;

        //Construimos query y consultamos
        String queryStr = String.Format("select * from Cancion where nombre='{0}' and artista='{1}'; ", qryCancion, qryArtista);
        this.gestorLocal.consBD(queryStr, DsGeneral, "Cancion"); 

    }
}