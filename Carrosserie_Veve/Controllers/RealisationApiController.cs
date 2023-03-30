using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcVeve.Data;
using MvcVeve.Models;

namespace MvcVeve.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RealisationApiController : ControllerBase
{
    private readonly MvcVeveContext _context;

    public RealisationApiController(MvcVeveContext context)
    {
        _context = context;
    }

    //GET : api/RealisationApi/
    public async Task<ActionResult<IEnumerable<Realisation>>> GetRealisation()
    {
        return await _context.Realisations.ToListAsync();
    }

    // GET :
    [HttpGet("{id}")]
    public async Task<ActionResult<Realisation>> GetRealisation(int id)
    {
        var r = await _context.Realisations.FindAsync(id);
        if (r == null)
            return NotFound();
        return r;
    }
        // POST :
    [HttpPost]
    public async Task<ActionResult<Realisation>> PostRealisation(Realisation r)
    {
      
        Realisation r1 = new Realisation(r); 
        _context.Realisations.Add(r1);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRealisation), new { id = r1.Id }, r1);
    }
    
    //PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRealisation(int id, Realisation r)
    {
        if (id != r.Id)
            return BadRequest();
        _context.Entry(r).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RealisationExists(id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }
    private bool RealisationExists(int id)
    {
        return _context.Realisations.Any(r => r.Id == id);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRealisation(int id)
    {
        var r = await _context.Realisations.FindAsync(id);
        if (r == null)
            return NotFound();

        _context.Realisations.Remove(r);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}