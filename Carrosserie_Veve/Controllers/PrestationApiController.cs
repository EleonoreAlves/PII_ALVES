using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carrosserie_Veve.Data;
using MvcVeve.Models;

namespace MvcVeve.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrestationApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PrestationApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    //GET : api/ContactApi 
    public async Task<ActionResult<IEnumerable<Prestation>>> GetPrestation()
    {
        return await _context.Prestations.ToListAsync();
    }

    // GET :
    [HttpGet("{id}")]
    public async Task<ActionResult<Prestation>> GetPrestation(int id)
    {
        var p = await _context.Prestations.FindAsync(id);
        if (p == null)
            return NotFound();
        return p;
    }
        // POST :
    [HttpPost]
    public async Task<ActionResult<Prestation>> PostPrestation(Prestation p)
    {
      
        Prestation p1 = new Prestation(p); 
        _context.Prestations.Add(p1);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrestation), new { id = p1.Id }, p1);
    }
    
    //PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPrestation(int id, Prestation p)
    {
        if (id != p.Id)
            return BadRequest();
        _context.Entry(p).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PrestationExists(id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }
    private bool PrestationExists(int id)
    {
        return _context.Prestations.Any(m => m.Id == id);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrestation(int id)
    {
        var p = await _context.Prestations.FindAsync(id);
        if (p == null)
            return NotFound();

        _context.Prestations.Remove(p);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}