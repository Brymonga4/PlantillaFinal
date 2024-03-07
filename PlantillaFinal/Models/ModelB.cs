namespace PlantillaFinal.Models;
public class ModelB
{
    //Cuadro
    public string title { get; set; }
    public int year { get; set; }
    public string file { get; set; }
    public int artist_id { get; set; }
    public int genre_id { get; set; }
    public int id { get; set; }
    public ModelA artist { get; set; }
    public Genre genre { get; set; }
}

public class ModelBResults
{
    public List<ModelB>? Results { get; set; }
}

public class Artist
{
    public string name { get; set; }
}

public class Genre
{
    public string name { get; set; }
}
