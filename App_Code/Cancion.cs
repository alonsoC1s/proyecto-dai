public class Cancion
{
    public string nombre; 
    public string artista; 
    public string album; 
    public int ano; 
    public decimal precio; 
    public string picURL; 
    public int cid; 

    public Cancion(string nom, string art, string alb, int ano, decimal prec, string pic, int cid){
        this.nombre = nom; 
        this.artista = art; 
        this.album = alb; 
        this.ano = ano; 
        this.precio = prec; 
        this.picURL = pic; 
        this.cid = cid; 
}

    public string getDescription() {
        string strBuild = ""; 
        string anoString = this.ano.ToString();
        strBuild += this.album + "," + anoString + ". Comprame a " + this.precio + "$"; 

        return strBuild;

    }
    
    
}