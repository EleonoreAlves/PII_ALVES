using MvcVeve.Data;
namespace MvcVeve.Models;

public class SeedData{
    public static void Init(){
        using (var context=new MvcVeveContext()){

            // On regarde si la BDD est déjà remplie
            if(context.Prestations.Any())
            {
                return;
            }
            
            
            Prestation Prestation1= new Prestation{
                NomPrestation="Prestation 1",
                Description="Description prestation1",
                
            };
            Prestation Prestation2= new Prestation{
                NomPrestation="Prestation 2",
                Description="Description prestation 2",
                
            };
            context.Prestations.AddRange(Prestation1,Prestation2);
            
            Horaire Horaire1=new Horaire{
                HeureDebut="7h20",
                HeureFin="17h30",
                JourOff="Jours fériés",
                Vacances="du 15 au 30 aôut"
            };
            context.Horaires.AddRange(Horaire1);
            

            context.SaveChanges();
        }
    }
}