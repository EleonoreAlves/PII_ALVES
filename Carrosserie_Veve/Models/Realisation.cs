using System.ComponentModel.DataAnnotations;
namespace MvcVeve.Models;

public class Realisation{
     public int Id {get;set;}
    public string NomRealisation {get;set;}=null!;
    public string? ImageAvt{get;set;} // possibilité d'en mettre plusieurs ?? 
    public string? ImageAp{get;set;}
    public string? Description {get;set;} // pas obligatoire


    public Realisation(Realisation realisation)
    {
        Id=realisation.Id;
        NomRealisation=realisation.NomRealisation;
       ImageAvt=realisation.ImageAvt;
        ImageAp=realisation.ImageAp;
        Description=realisation.Description;
    }

public Realisation(){}
}