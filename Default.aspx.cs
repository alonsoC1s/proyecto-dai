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
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal; 
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

        if (this.DsGeneral.Tables["Usuario"].Rows.Count != 0) {
            //Guardamos datos del usuario actual, y despues vamos a la pagina de inicio
            Session["Username"] = MyLoginControl.UserName; 
            Response.Write("<script>alert('Te encontramos')</script>");
            Server.Transfer("PgPrincipal.aspx"); 
             
            
        } else {
            Response.Write("<script>alert('NO te encontramos')</script>");
        }
    }
}