using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        this.usuarioActual = (Usuario)Session["UsuarioActual"];
        this.hola = this.usuarioActual.nombre;
        this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];

        // Consultamos BD para obtener las canciones en el carrito 
        string rangeStr = "("; 
        for (int i=0; i<carritoDeCompras.Count; i++)
        {
            if (i < carritoDeCompras.Count - 1)
            {
                rangeStr += String.Format("{0},",carritoDeCompras.ElementAt(i));
            }else
            {
                rangeStr += String.Format("{0}", carritoDeCompras.ElementAt(i)); 
            }
        }
        rangeStr += ")";

        string qryStr = String.Format("Select * from Cancion where cid in {0}", rangeStr);

        this.gestorLocal.consBD(qryStr, DsGeneral, "Cancion");

        // Generamos el html con resultados de consulta 
        StringBuilder sb = new StringBuilder();
        string htmlScaffold = @"
        <div class='row justify-content-center pt-5'>
                <div class='card bg-primary border-dark' style='width: 50%;' > 
                <div class='card text-white bg-primary p-3'>
                    <h5 class='card-title'> {0} </h5>
                    <p class='card-text'> {1} </p>
                    <p class='card-text'> {2} </p>
                    <a class='btn btn-dark' href='PgEliminarCompra.aspx?cid={3}' target='_self' > Eliminar del carrito </a>
                  </div>
            </div> 
        </div>
        ";

        int resCount = DsGeneral.Tables["Cancion"].Rows.Count;
        for (int i = 0; i < resCount; i++)
        {
            //Obteniendo atributos para serializar 
            string nombre = this.DsGeneral.Tables["Cancion"].Rows[i]["nombre"].ToString();
            string artista = this.DsGeneral.Tables["Cancion"].Rows[i]["artista"].ToString();
            string album = this.DsGeneral.Tables["Cancion"].Rows[i]["album"].ToString();
            int ano = (int)this.DsGeneral.Tables["Cancion"].Rows[i]["año"];
            decimal precio = Convert.ToDecimal(this.DsGeneral.Tables["Cancion"].Rows[i]["precio"]);
            string pic = this.DsGeneral.Tables["Cancion"].Rows[i]["picURL"].ToString();
            int cid = (int)this.DsGeneral.Tables["Cancion"].Rows[i]["cid"];

            Cancion canc = new Cancion(nombre, artista, album, ano, precio, pic, cid);

            sb.AppendFormat(htmlScaffold, nombre, album, canc.getDescription(), cid);

        }

        if (resCount > 0)
        {
            sb.AppendFormat("<div class='row justify-content-center pt-5'> <a class='btn btn-primary' href='pgALTACOMPRA.aspx'> Confirmar compra </a> </div>");
        }

        this.placeHolderHtml = sb.ToString(); 


    }
}