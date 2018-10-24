using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {

    // Atributos de clase 
    const string SERVERNAME = "SQLNCLI11"; 
    GestorBD.GestorBD gestorLocal;
    DataSet DsGeneral = new DataSet();
    int currentUserId; 

    protected void Page_Load(object sender, EventArgs e) {
        Console.WriteLine("Hola desde un lugar raro"); 

        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.
            /*
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal; 
            */
            gestorLocal.conex = new System.Data.OleDb.OleDbConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=proyecto-musica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
        }
    }


    protected void MyLoginControl_Authenticate(object sender, AuthenticateEventArgs e) {
        // Checamos si el usuario existe. 
        // Recuperamos el gestor de Session 
        this.gestorLocal = (GestorBD.GestorBD)Session["Gestor"];

        string queryStr = "select * from Usuario where nombre ='" + MyLoginControl.UserName + 
            "' and password='" + MyLoginControl.Password + "'";
 
        // Consulta a la base de datos. Verificando si es vacio 
        this.gestorLocal.consBD(queryStr, this.DsGeneral, "Usuario");
        Console.Write(DsGeneral);
        Usuario elusuario; 

        if (this.DsGeneral.Tables["Usuario"].Rows.Count != 0) {
            //Guardamos datos del usuario actual serializado como objeto nativo, y despues vamos a la pagina de inicio
            int cid = (int) this.DsGeneral.Tables["Usuario"].Rows[0]["Uid"];
            string nom = this.DsGeneral.Tables["Usuario"].Rows[0]["nombre"].ToString();
            string pass = this.DsGeneral.Tables["Usuario"].Rows[0]["password"].ToString();

            Usuario usActual = new Usuario(cid, nom, pass);


            Session["UsuarioActual"] = usActual; 
            Response.Write("<script>alert('Te encontramos')</script>");
            Server.Transfer("PgPrincipal.aspx"); 
             
            
        } else {
            Response.Write("<script>alert('NO te encontramos')</script>");
        }
    }
}