using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carrosserie_Veve.Areas.Identity.Data;
using MvcVeve.Models;

namespace MvcVeve.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HoraireApiController : ControllerBase
{
    private readonly Carrosserie_VeveIdentityDbContext _context;

    public HoraireApiController(Carrosserie_VeveIdentityDbContext context)
    {
        _context = context;
    }

    //GET : api/HoraireApi 
    public async Task<ActionResult<IEnumerable<Horaire>>> GetHoraire()
    {
        return await _context.Horaires.ToListAsync();
    }

    // GET :
    [HttpGet("{id}")]
    public async Task<ActionResult<Horaire>> GetHoraire(int id)
    {
        var horaire = await _context.Horaires.FindAsync(id);
        if (horaire == null)
            return NotFound();
        return horaire;
    }
        // POST :
    [HttpPost]
    public async Task<ActionResult<Horaire>> PostHoraire(Horaire horaire)
    {
        Horaire horaire1 = new Horaire{HeureDebut=horaire.HeureDebut,HeureFin=horaire.HeureFin,JourOff=horaire.JourOff,Vacances=horaire.Vacances};
        _context.Horaires.Add(horaire1);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetHoraire), new { id = horaire1.Id }, horaire1);
    }
    
    //PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHoraire(int id, Horaire horaire)
    {
        if (id != horaire.Id)
            return BadRequest();
        _context.Entry(horaire).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HoraireExists(id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }
    private bool HoraireExists(int id)
    {
        return _context.Horaires.Any(m => m.Id == id);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHoraire(int id)
    {
        var h = await _context.Horaires.FindAsync(id);
        if (h == null)
            return NotFound();

        _context.Horaires.Remove(h);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}