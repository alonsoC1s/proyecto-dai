using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// PgBusqueda representa la página de búsqueda. Está encargada de
// mostrar un form para tomar datos de búsqueda, y hace la consulta a la BD, serializa
// los resultados en objetos nativos, y autogenera HTML para mostrar
public partial class PgBusqueda : System.Web.UI.Page
{

    // Atributos de clase
    public List<int> carritoDeCompras = new List<int>();
    const string SERVERNAME = "SQLNCLI11";
    GestorBD.GestorBD gestorLocal;
    DataSet DsGeneral = new DataSet();
    public string placeHolderHtml;
    string queryStr;

    // Método llamado cuando la página se termina de cargar. Encarcargada de obtener las referencias al gestor
    protected void Page_Load(object sender, EventArgs e){

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
        Button btnSender = (Button)sender;
        // Response.Write(String.Format("<script>alert('desde {0}')</script>",btnSender.CommandName));

        if (btnSender.CommandName == "search")
        {
            //Obtenemos los términos buscados
            String qryCancion = txtCancion.Text;
            String qryArtista = txtArtista.Text;

            //Construimos query y consultamos
            if (qryArtista != "" && qryCancion != "")
            {
                this.queryStr = String.Format("select * from Cancion where nombre='{0}' and artista='{1}'; ", qryCancion, qryArtista);

            }
            else if (qryCancion == "")
            {
                this.queryStr = String.Format("select * from Cancion where artista='{0}'; ", qryArtista);
            }
            else if (qryArtista == "")
            {
                this.queryStr = String.Format("select * from Cancion where nombre='{0}'; ", qryCancion);
            }

            this.gestorLocal.consBD(queryStr, DsGeneral, "Cancion");

            if (this.DsGeneral.Tables["cancion"].Rows.Count != 0) { }

            //Creando elementos html de acuerdo a cuantos resultados tuvimos
            StringBuilder sb = new StringBuilder();
            string htmlScaffold = @"
        <div class='row justify-content-center pt-5'>
                <div class='card bg-primary border-dark' style='width: 50%;' >
                <div class='card text-white bg-primary p-3'>
                    <h5 class='card-title'> {0} </h5>
                    <p class='card-text'> {1} </p>
                    <p class='card-text'> {2} </p>

                    <a class='btn btn-dark' href='PgComfCompra-v2.aspx?cid={3}' target='_self'> Añadir al carrito </a>

                    </div>
            </div>
        </div>

            ";
            int resCount = DsGeneral.Tables["Cancion"].Rows.Count;

            if (resCount != 0)
            {
                for (int i = 0; i < resCount; i++)
                {
                    //Obteniendo atributos para serializar
                    string nombre = this.DsGeneral.Tables["cancion"].Rows[i]["nombre"].ToString();
                    string artista = this.DsGeneral.Tables["cancion"].Rows[i]["artista"].ToString();
                    string album = this.DsGeneral.Tables["cancion"].Rows[i]["album"].ToString();
                    int ano = (int)this.DsGeneral.Tables["cancion"].Rows[i]["año"];
                    decimal precio = Convert.ToDecimal(this.DsGeneral.Tables["cancion"].Rows[i]["precio"]);
                    string pic = this.DsGeneral.Tables["cancion"].Rows[i]["picURL"].ToString();
                    int cid = (int)this.DsGeneral.Tables["cancion"].Rows[i]["cid"];

                    Cancion canc = new Cancion(nombre, artista, album, ano, precio, pic, cid);

                    sb.AppendFormat(htmlScaffold, nombre, album, canc.getDescription(), cid);

                }
            }else
            {
                sb.Append("No encontramos canciones con el criterio de busqueda");
            }

            //Actualizamos el html
            this.placeHolderHtml = sb.ToString();
        }else
        {
            // Se cliqueo el añadir a carrito.
            int cid = int.Parse(btnSender.CommandName);


        }

    }

}
