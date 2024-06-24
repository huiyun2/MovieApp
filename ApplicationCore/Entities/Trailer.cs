namespace ApplicationCore.Entities;

public class Trailer
{
    public int Id{get; set;}
    public string TrailerUrl {get; set;}
    public string Name {get; set; }

    //reference to movie id fk
    public int MovieId {get; set; }
    // navigation property
    public Movie Movie {get; set; }




}