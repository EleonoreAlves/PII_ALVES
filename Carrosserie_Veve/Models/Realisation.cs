using System.ComponentModel.DataAnnotations;
namespace MvcVeve.Models;

public class Realisation{
     public int Id {get;set;}
     [Display(Name = "Nom Réalisation")]
    public string NomRealisation {get;set;}=null!;
    [Display(Name = "Image Avant 1")]
    public string? ImageAvt{get;set;} 
    [Display(Name = "Image Avant 2")]
    public string? ImageAvt2{get;set;} 
    [Display(Name = "Image Après 1")]
    public string? ImageAp{get;set;}
    [Display(Name = "Image Après 2")]
    public string? ImageAp2{get;set;}
    public string? Description {get;set;} // pas obligatoire


    public Realisation(Realisation realisation)
    {
        Id=realisation.Id;
        NomRealisation=realisation.NomRealisation;
       ImageAvt=realisation.ImageAvt;
       ImageAvt2=realisation.ImageAvt2;
        ImageAp=realisation.ImageAp;
        ImageAp2=realisation.ImageAp2;
        Description=realisation.Description;
    }

public Realisation(){}
}