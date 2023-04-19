using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcVeve.Models;
using Carrosserie_Veve.Areas.Identity.Data;

// seul get et edit disponible : il n'y aura jamais plusieurs horaires
// l'administrateur modifiera seulement celle existante
namespace MvcVeve.Controllers;

public class HoraireController : Controller{
    private readonly Carrosserie_VeveIdentityDbContext _context;

    public HoraireController(Carrosserie_VeveIdentityDbContext context)
    {
        _context=context;
    }
    public async Task<IActionResult> Index()
    {
        var horaire=await _context.Horaires.ToListAsync();
        return View(horaire);
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var horaire = await _context.Horaires
            .FirstOrDefaultAsync(h => h.Id == id);
            
        if (horaire == null)
        {
            return NotFound();
        }

        return View(horaire);
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var horaire = await _context.Horaires.FindAsync(id);
        if (horaire == null)
        {
            return NotFound();
        }
        return View(horaire);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,HeureDebut,HeureFin,JourOff,Vacances")] Horaire horaire)
    {
        if (id != horaire.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(horaire);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoraireExists(horaire.Id))
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
        return View(horaire);
    }

    private bool HoraireExists(int id)
    {
        return _context.Horaires.Any(e => e.Id == id);
    }


}