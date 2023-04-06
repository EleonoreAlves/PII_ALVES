using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcVeve.Models;
using Carrosserie_Veve.Data;


namespace MvcVeve.Controllers;

public class HoraireController : Controller{
    private readonly ApplicationDbContext _context;

    public HoraireController(ApplicationDbContext context)
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
}