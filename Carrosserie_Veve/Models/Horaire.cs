using System.ComponentModel.DataAnnotations;
namespace MvcVeve.Models;
// voué à être modifié : jour off pas nécessaire
public class Horaire{
    public int Id {get;set;}
    public string HeureDebut {get;set;}=null!;
    public string HeureFin {get;set;}=null!;

    public string JourOff {get;set;}=null!;

    public string Vacances{ get;set;}=null!;


    // en string pour faciliter la saisie des gérants

}