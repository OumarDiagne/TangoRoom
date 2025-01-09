using Microsoft.AspNetCore.Mvc;
using TangoRoom.Server.Interfaces;
using TangoRoom.Server.Models;

namespace TangoRoom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarathonController(IMarathonService IMarathonService) : ControllerBase
    {
        private readonly IMarathonService _marathonService = IMarathonService;

        // GET: api/Marathon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marathon>>> GetMarathons()
        {
            return await _marathonService.GetMarathons();
        }

        // GET: api/Marathon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marathon>> GetMarathon(int id)
        {
            var marathon = await _marathonService.GetMarathon(id);

            if (marathon == null)
            {
                return NotFound();
            }

            return marathon;
        }

        //    // PUT: api/Marathon/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutMarathon(int id, Marathon marathon)
        //    {
        //        if (id != marathon.IdMarathon)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(marathon).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MarathonExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Marathon
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Marathon>> PostMarathon(Marathon marathon)
        //    {
        //        _context.Marathons.Add(marathon);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetMarathon", new { id = marathon.IdMarathon }, marathon);
        //    }

        //    // DELETE: api/Marathon/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteMarathon(int id)
        //    {
        //        var marathon = await _context.Marathons.FindAsync(id);
        //        if (marathon == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Marathons.Remove(marathon);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool MarathonExists(int id)
        //    {
        //        return _context.Marathons.Any(e => e.IdMarathon == id);
        //    }
        //
    }
}
