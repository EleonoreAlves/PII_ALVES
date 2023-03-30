using System.ComponentModel.DataAnnotations;
namespace MvcVeve.Models;

public class Prestation{
    public int Id {get;set;}
    public string NomPrestation {get;set;}=null!;
    public string? URLImage{get;set;}
    public string? Description_courte {get;set;}
    public string Description {get;set;}=null!;


public Prestation(Prestation presta)
    {
        Id=presta.Id;
        NomPrestation=presta.NomPrestation;
        URLImage=presta.URLImage;
        Description_courte=presta.Description_courte;
        Description=presta.Description;
    }

public Prestation(){}


}

