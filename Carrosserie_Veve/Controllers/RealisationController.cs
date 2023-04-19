using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Carrosserie_Veve.Areas.Identity.Data;
using MvcVeve.Models;

namespace MvcVeve.Controllers;

public class RealisationController : Controller
{
    private readonly Carrosserie_VeveIdentityDbContext _context;

    public RealisationController(Carrosserie_VeveIdentityDbContext context)
    {
        _context = context;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var realisation = await _context.Realisations
            .ToListAsync();

        return View(realisation);
    }
    //GET details
     public async Task<IActionResult> Details(int? id)
    {
        
        if (id == null)
        {
            return NotFound();
        }

        var realisation = await _context.Realisations
            .FirstOrDefaultAsync(r => r.Id == id);
            
        if (realisation == null)
        {
            return NotFound();
        }

        return View(realisation);
    }
    public IActionResult Create()
    {
        return View();
    }
    // //POST : Realisation/Create
     [HttpPost]
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> Create([Bind("NomRealisation,ImageAvt,ImageAvt2,ImageAp,ImageAp2,Description")] Realisation realisation,IFormFile ImageAvt,IFormFile ImageAp,IFormFile ImageAvt2,IFormFile ImageAp2)
    {
       
          
            if (ImageAvt != null && ImageAvt.Length > 0 && ImageAp != null && ImageAp.Length > 0 && ImageAvt2 != null && ImageAvt2.Length > 0 && ImageAp2 != null && ImageAp2.Length > 0)
                {
                    var fileavtName = Path.GetFileName(ImageAvt.FileName);
                    var fileavtPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileavtName);

                    var fileapName = Path.GetFileName(ImageAp.FileName);
                    var fileapPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileapName);

                    var fileavt2Name = Path.GetFileName(ImageAvt2.FileName);
                    var fileavt2Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileavt2Name);

                    var fileap2Name = Path.GetFileName(ImageAp2.FileName);
                    var fileap2Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileap2Name);

                    using (var stream = new FileStream(fileavtPath, FileMode.Create))
                    {
                        await ImageAvt.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(fileapPath, FileMode.Create))
                    {
                        await ImageAp.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(fileavt2Path, FileMode.Create))
                    {
                        await ImageAvt2.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(fileap2Path, FileMode.Create))
                    {
                        await ImageAp2.CopyToAsync(stream);
                    }

                    realisation.ImageAvt = fileavtName;
                    realisation.ImageAp = fileapName;
                    realisation.ImageAvt2 = fileavt2Name;
                    realisation.ImageAp2 = fileap2Name;

                    _context.Update(realisation);
                    await _context.SaveChangesAsync();
                }// images Avt2 at Ap2 optionnel
                else{
            realisation.ImageAvt=null;
            realisation.ImageAvt2=null;
            realisation.ImageAp=null;
            realisation.ImageAp2=null;
            _context.Add(realisation);
             await _context.SaveChangesAsync();
         }
        return RedirectToAction(nameof(Index));
    }

        // GET: Realisation/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var realisation = await _context.Realisations.FindAsync(id);
        if (realisation == null)
        {
            return NotFound();
        }
        return View(realisation);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NomRealisation,ImageAvt,ImageAvt2,ImageAp,ImageAp2,Description")] Realisation realisation,IFormFile ImageAvt,IFormFile ImageAp,IFormFile ImageAvt2,IFormFile ImageAp2)
    {
        if (id != realisation.Id)
        {
            return NotFound();
        }

        
            try
            {  if (ImageAvt != null && ImageAvt.Length > 0 && ImageAp != null && ImageAp.Length > 0 && ImageAvt2 != null && ImageAvt2.Length > 0 && ImageAp2 != null && ImageAp2.Length > 0)
                {
                    var fileavtName = Path.GetFileName(ImageAvt.FileName);
                    var fileavtPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileavtName);

                    var fileapName = Path.GetFileName(ImageAp.FileName);
                    var fileapPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileapName);

                    var fileavt2Name = Path.GetFileName(ImageAvt2.FileName);
                    var fileavt2Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileavt2Name);

                    var fileap2Name = Path.GetFileName(ImageAp2.FileName);
                    var fileap2Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileap2Name);

                    using (var stream = new FileStream(fileavtPath, FileMode.Create))
                    {
                        await ImageAvt.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(fileapPath, FileMode.Create))
                    {
                        await ImageAp.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(fileavt2Path, FileMode.Create))
                    {
                        await ImageAvt2.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(fileap2Path, FileMode.Create))
                    {
                        await ImageAp2.CopyToAsync(stream);
                    }

                    realisation.ImageAvt = fileavtName;
                    realisation.ImageAp = fileapName;
                    realisation.ImageAvt2 = fileavt2Name;
                    realisation.ImageAp2 = fileap2Name;

                    _context.Update(realisation);
                    await _context.SaveChangesAsync();
                }
                
                // else{
                //    // realisation.ImageAvt2=null;
                //       realisation.ImageAp2=null; 
                // var fileavtName = Path.GetFileName(ImageAvt.FileName);
                //     var fileavtPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileavtName);

                //     var fileapName = Path.GetFileName(ImageAp.FileName);
                //     var fileapPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileapName);
                // using (var stream = new FileStream(fileavtPath, FileMode.Create))
                //     {
                //         await ImageAvt.CopyToAsync(stream);
                //     }
                //     using (var stream = new FileStream(fileapPath, FileMode.Create))
                //     {
                //         await ImageAp.CopyToAsync(stream);
                //     }
                //      realisation.ImageAvt = fileavtName;
                //      realisation.ImageAp = fileapName;
                //     _context.Update(realisation);
                //     await _context.SaveChangesAsync();
                // } => ne fontionne pas dpu à un pbl de Bdd dont je n'ai pas pu m'occuper
            
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealisationExists(realisation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        
    }

    private bool RealisationExists(int id)
    {
        return _context.Realisations.Any(r => r.Id == id);
    }

        // GET: Realisations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var realisation = await _context.Realisations
            .FirstOrDefaultAsync(p => p.Id == id);
        if (realisation == null)
        {
            return NotFound();
        }

        return View(realisation);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var realisation = await _context.Realisations.FindAsync(id);
        _context.Realisations.Remove(realisation!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

