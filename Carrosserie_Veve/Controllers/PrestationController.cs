using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carrosserie_Veve.Data;
using MvcVeve.Models;

namespace MvcVeve.Controllers;

public class PrestationController : Controller
{
    private readonly ApplicationDbContext _context;

    public PrestationController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var prestation = await _context.Prestations
            .ToListAsync();

        return View(prestation);
    }
    //GET details
     public async Task<IActionResult> Details(int? id)
    {
        
        if (id == null)
        {
            return NotFound();
        }

        var prestation = await _context.Prestations
        //.Include(p=>p.NomPrestation)
            .FirstOrDefaultAsync(p => p.Id == id);
            
        if (prestation == null)
        {
            return NotFound();
        }

        return View(prestation);
    }
    public IActionResult Create()
    {
        return View();
    }
    //POST : Prestation/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NomPrestation,URLImage,Description_courte,Description")] Prestation prestation, IFormFile URLImage )
    {

        if (URLImage != null && URLImage.Length > 0 )
        {
            var fileName = Path.GetFileName(URLImage.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await URLImage.CopyToAsync(stream);
            }

            prestation.URLImage = fileName;

            _context.Add(prestation);
             await _context.SaveChangesAsync();
         }
        return RedirectToAction(nameof(Index));
    }
        // PUT : 
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prestation = await _context.Prestations.FindAsync(id);
        if (prestation == null)
        {
            return NotFound();
        }
        return View(prestation);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NomPrestation,URLImage,Description_courte,Description")] Prestation prestation,IFormFile URLImage)
    {
        if (id != prestation.Id)
        {
            return NotFound();
        }
        
            try
            {
                if(URLImage != null && URLImage.Length > 0)
                {
                    var fileimgName = Path.GetFileName(URLImage.FileName);
                    var fileimgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileimgName);
                
 //problème : FileMode.Edit ne fonctionne pas obliger d'avoir FileMode.Create => obligation de retélécharger l'image à chaque fois qu'on veut modif       
                using (var stream = new FileStream(fileimgPath, FileMode.Create))
                {
                    await URLImage.CopyToAsync(stream);
                }
                    prestation.URLImage=fileimgName;  

                    _context.Update(prestation);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestationExists(prestation.Id))
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

    private bool PrestationExists(int id)
    {
        return _context.Prestations.Any(e => e.Id == id);
    }

        // GET: Prestations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var prestation = await _context.Prestations
            .FirstOrDefaultAsync(p => p.Id == id);
        if (prestation == null)
        {
            return NotFound();
        }

        return View(prestation);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var prestation = await _context.Prestations.FindAsync(id);
        _context.Prestations.Remove(prestation!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

