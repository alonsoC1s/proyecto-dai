using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {

    // Atributos de clase 
    GestorBD.GestorBD gestorLocal;

    protected void Page_Load(object sender, EventArgs e) {
        Console.WriteLine("Hola desde un lugar raro"); 
    }
}