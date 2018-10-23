using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PgPrincipal : System.Web.UI.Page 
{

    public string hola = "nombre";
    const string SERVERNAME = "SQLNCLI11";
    private GestorBD.GestorBD gestorLocal;
    DataSet DsGeneral = new DataSet();
    string top5Songs;
    public Cancion[] populares = new Cancion[6];

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
        this.hola = (string) Session["Username"];

        // Recuperamos las canciones más compradas, y serializamos en objetos nativos 
        // Query a la bd
        string sqlQuery = "select cid, count(cid) as contado from compra group by cid order by contado desc";
        this.gestorLocal.consBD(sqlQuery, this.DsGeneral, "compra");

        // Asumimos que la base es no vacia. Obtenemos las claves.
        
        for (int i=0; i<6; i++)
        {
            // this.DsGeneral.Tables["compra"].Rows[i]["cid"];
            top5Songs += this.DsGeneral.Tables["compra"].Rows[i]["cid"].ToString(); 
            if (i < 5)
            {
                top5Songs += ","; 
            }
        }

        //Obteniendo solamente las canciones que necesitamos. Tomamos 6 por razones esteticas
        sqlQuery = "select * from cancion where cid in (" + this.top5Songs + "); ";
        this.gestorLocal.consBD(sqlQuery, DsGeneral, "cancion");

        for (int i = 0; i < 6; i++){
            //Obteniendo atributos para serializar 
            string nombre = this.DsGeneral.Tables["cancion"].Rows[i]["nombre"].ToString();
            string artista = this.DsGeneral.Tables["cancion"].Rows[i]["artista"].ToString();
            string album = this.DsGeneral.Tables["cancion"].Rows[i]["album"].ToString();
            int ano = (int) this.DsGeneral.Tables["cancion"].Rows[i]["año"];
            decimal precio = Convert.ToDecimal(this.DsGeneral.Tables["cancion"].Rows[i]["precio"]);
            string pic = this.DsGeneral.Tables["cancion"].Rows[i]["picURL"].ToString();
            int cid = (int)this.DsGeneral.Tables["cancion"].Rows[i]["cid"];

            populares[i] = new Cancion(nombre, artista, album, ano, precio, pic, cid); 
        }




    }

    protected void Unnamed_Click(object sender, EventArgs e) {
        Button btn = (Button)sender;
        int selectedItemIdx = 0;
        int selectedCancionCid; 
        
        switch (btn.CommandName) {
            case "btnItem0":
                selectedItemIdx = 0;
                break;

            case "btnItem1":
                selectedItemIdx = 1;
                break;

            case "btnItem2":
                selectedItemIdx = 2;
                break;

            case "btnItem3":
                selectedItemIdx = 3;
                break;

            case "btnItem4":
                selectedItemIdx = 4;
                break;

            case "btnItem5":
                selectedItemIdx = 5;
                break;

        }

        selectedCancionCid = populares[selectedItemIdx].cid;
        Session["CompraCancionId"] = selectedCancionCid; 

        Server.Transfer("PgComfCompra.aspx"); 

    }

}