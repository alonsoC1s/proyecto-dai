using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PgPrincipal : System.Web.UI.Page 
{

    public string hola = "nombre";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Recuperamos el nombre del usuario de session.
        this.hola = (string) Session["Username"]; 
    }
}