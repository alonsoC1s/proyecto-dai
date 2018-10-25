using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgHistorialCompras : System.Web.UI.Page
{

    // Atributos de clase
    public Usuario usuarioActual;
    GestorBD.GestorBD gestorLocal;
    const string SERVERNAME = "SQLNCLI11";
    DataSet DsGeneral = new DataSet();
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
        }

        // Recuperamos el nombre del usuario de session, y el gestor iniciado.
        this.gestorLocal = (GestorBD.GestorBD)Session["Gestor"];
        this.carritoDeCompras = (List<int>)Session["carritoDeCompras"];

        //Obtenemos el usuario actual de session
        this.usuarioActual = (Usuario)Session["UsuarioActual"];

        //Consultamos base de datos por compras del usuario
        string queryStr = String.Format("select * from compra as com, cancion as can where com.cid=can.cid and com.uid = {0}", usuarioActual.Uid);
        this.gestorLocal.consBD(queryStr, DsGeneral, "Resultado");

        //Creando elementos html de acuerdo a cuantos resultados tuvimos
        StringBuilder sb = new StringBuilder();
        string htmlScaffold = @"
        <div class='row justify-content-center pt-5'>
                <div class='card bg-primary border-dark' style='width: 50%;' > 
                <div class='card text-white bg-primary p-3'>
                    <h5 class='card-title'> {0} </h5>
                    <p class='card-text'> {1} </p>
                    <p class='card-text'> {2} </p>
                    <input runat='server' type='submit' CommandName='{3}' value='Añadir al carrito' class='btn btn-primary bg-dark' onclick='callHandler();return false;'  />
                  </div>
            </div> 
        </div>

            ";
        int resCount = DsGeneral.Tables["Resultado"].Rows.Count;
        for (int i = 0; i < resCount; i++)
        {
            //Obteniendo atributos para serializar 
            string nombre = this.DsGeneral.Tables["Resultado"].Rows[i]["nombre"].ToString();
            string artista = this.DsGeneral.Tables["Resultado"].Rows[i]["artista"].ToString();
            string album = this.DsGeneral.Tables["Resultado"].Rows[i]["album"].ToString();
            int ano = (int)this.DsGeneral.Tables["Resultado"].Rows[i]["año"];
            decimal precio = Convert.ToDecimal(this.DsGeneral.Tables["Resultado"].Rows[i]["precio"]);
            string pic = this.DsGeneral.Tables["Resultado"].Rows[i]["picURL"].ToString();
            int cid = (int)this.DsGeneral.Tables["Resultado"].Rows[i]["cid"];

            Cancion canc = new Cancion(nombre, artista, album, ano, precio, pic, cid);

            sb.AppendFormat(htmlScaffold, nombre, album, canc.getDescription(), cid);

        }

        this.placeHolderHtml = sb.ToString(); 




    }

    public static void sayHi()
    {
        // asdkfasd
    }
}