using System.ComponentModel.DataAnnotations;
namespace MvcVeve.Models;
// classe optionnelle : ajout d'une foncitonnalité me contacter si j'ai le temps
public class MeContacter{
    public string Mail {get;set;}=null!;
    public string? Sujet {get;set;}

    public string Contenu {get;set;}=null!;

}