using System;

namespace sitiodai {

    public partial class Default : System.Web.UI.Page{

        // Variables de clase
        
        GestorBD.GestorBD gestorLocal; 
        
        
        protected void Page_Load(object sender, EventArgs ev){
            // IsPostBack guarda el estado de la página. Cargada por primera vez, o recargada
            Console.WriteLine("Prueba Uno"); 
            if (!IsPostBack){
                gestorLocal = new GestorBD.GestorBD("SQLNCLI11", "localhost", "sa", "sqladmin", "proyecto-musica");
                //Guardamos el gestor en Session para recuperarlo después
                Session["Gestor"] = gestorLocal; 
            }
        }


    }
}
