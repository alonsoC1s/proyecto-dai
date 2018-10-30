using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// La clase _Default representa a la página default del sistema
// En la página default se checa el nombre de usuario y contraseña para hacer login
public partial class _Default : System.Web.UI.Page {

    // Atributos de clase
    const string SERVERNAME = "SQLNCLI11";
    GestorBD.GestorBD gestorLocal;
    DataSet DsGeneral = new DataSet();
    int currentUserId;

    // Método llamado cuando la página termina de cargar y está lista para desplegar información
    // El método está encargado de conseguir la referencia al gestorBD para poder hacer la consulta de login
    protected void Page_Load(object sender, EventArgs e) {
        Console.WriteLine("Hola desde un lugar raro");

        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.

            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;

        }
    }


    // MyLoginControl_Authenticate es llamado cuando el asp:logincontrol recibe datos de inicio de session
    // Toma los datos provistos, y hace una consulta a la base de datos, dando acceso al usuario de encontrar credenciales
    protected void MyLoginControl_Authenticate(object sender, AuthenticateEventArgs e) {
        // Checamos si el usuario existe.
        // Recuperamos el gestor de Session
        this.gestorLocal = (GestorBD.GestorBD)Session["Gestor"];

        string queryStr = "select * from Usuario where nombre ='" + MyLoginControl.UserName +
            "' and password='" + MyLoginControl.Password + "'";

        // Consulta a la base de datos.
        this.gestorLocal.consBD(queryStr, this.DsGeneral, "Usuario");
        Console.Write(DsGeneral);
        Usuario elusuario;

        // Checando si existe coincidencia en la BD. Guardando datos del usuaro actual de encontrarse 
        if (this.DsGeneral.Tables["Usuario"].Rows.Count != 0) {
            //Guardamos datos del usuario actual serializado como objeto nativo, y despues vamos a la pagina de inicio
            int cid = (int) this.DsGeneral.Tables["Usuario"].Rows[0]["Uid"];
            string nom = this.DsGeneral.Tables["Usuario"].Rows[0]["nombre"].ToString();
            string pass = this.DsGeneral.Tables["Usuario"].Rows[0]["password"].ToString();

            Usuario usActual = new Usuario(cid, nom, pass);


            Session["UsuarioActual"] = usActual;
            Session["carritoDeCompras"] = new List<int>();
            Response.Write("<script>alert('Te encontramos')</script>");
            Server.Transfer("PgPrincipal.aspx");


        } else {
            Response.Write("<script>alert('NO te encontramos')</script>");
        }
    }
}
