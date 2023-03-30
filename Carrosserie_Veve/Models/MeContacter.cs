using System.ComponentModel.DataAnnotations;
namespace MvcVeve.Models;

public class MeContacter{
    public string Mail {get;set;}=null!;
    public string? Sujet {get;set;}

    public string Contenu {get;set;}=null!;

}