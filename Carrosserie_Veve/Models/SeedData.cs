using Carrosserie_Veve.Data;
using Microsoft.EntityFrameworkCore;
namespace MvcVeve.Models;
using Carrosserie_Veve.Areas.Identity.Data;

public class SeedData{
    

    public static void Init(){
        var optionsBuilder=new DbContextOptionsBuilder<Carrosserie_VeveIdentityDbContext>();
        optionsBuilder.UseSqlite("Data source=app.db");
        using (var context=new Carrosserie_VeveIdentityDbContext(optionsBuilder.Options)){

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