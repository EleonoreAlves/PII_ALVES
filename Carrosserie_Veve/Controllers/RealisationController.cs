using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Carrosserie_Veve.Data;
using MvcVeve.Models;

namespace MvcVeve.Controllers;

public class RealisationController : Controller
{
    private readonly ApplicationDbContext _context;

    public RealisationController(ApplicationDbContext context)
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
     public async Task<IActionResult> Create([Bind("NomRealisation,ImageAvt,ImageAp,Description")] Realisation realisation,IFormFile ImageAvt,IFormFile ImageAp)
    {
       
          
            if (ImageAvt != null && ImageAvt.Length > 0 && ImageAp != null && ImageAp.Length > 0)
        {
            var fileavtName = Path.GetFileName(ImageAvt.FileName);
            var fileavtPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileavtName);

            var fileapName = Path.GetFileName(ImageAp.FileName);
            var fileapPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileapName);

            using (var stream = new FileStream(fileavtPath, FileMode.Create))
            {
                await ImageAvt.CopyToAsync(stream);
            }
            using (var stream = new FileStream(fileapPath, FileMode.Create))
            {
                await ImageAp.CopyToAsync(stream);
            }

            realisation.ImageAvt = fileavtName;
            realisation.ImageAp = fileapName;

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
    public async Task<IActionResult> Edit(int id, [Bind("Id,NomRealisation,ImageAvt,ImageAp,Description")] Realisation realisation)
    {
        if (id != realisation.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(realisation);
                await _context.SaveChangesAsync();
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
        return View(realisation);
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

