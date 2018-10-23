using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgComfCompra : System.Web.UI.Page {


    //Atributos de clase
    GestorBD.GestorBD gestorLocal;
    const string SERVERNAME = "SQLNCLI11";

    protected void Page_Load(object sender, EventArgs e) {
        // Checamos si es la primera vez que se carga la página
        if (!IsPostBack) {
            //Inicializamos el gestor y lo guardamos en session.
            this.gestorLocal = new GestorBD.GestorBD(SERVERNAME, "localhost",
                "sa", "sqladmin", "proyecto-musica");

            Session["Gestor"] = this.gestorLocal;
        }

        Response.Write("<script> alert(hola) </script> "); 
    }
}