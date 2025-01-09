using Microsoft.AspNetCore.Mvc;
using TangoRoom.Server.Interfaces;
using TangoRoom.Server.Models;

namespace TangoRoom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController(IUtilisateurService IUserService) : ControllerBase
    {
        private readonly IUtilisateurService _userService = IUserService;

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            var users = await _userService.GetUtilisateurs();
            return Ok(users);
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _userService.GetUtilisateur(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return Ok(utilisateur);
        }

        // POST: api/Utilisateurs/inscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("inscription")]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur([FromBody] Utilisateur utilisateur)
        {
            Utilisateur? newUser = await _userService.CreationUtilisateur(utilisateur);


            return CreatedAtAction("GetUtilisateur", new { id = newUser!.IdUtilisateur }, newUser);
        }

        // DELETE: api/inscription
        [HttpDelete("inscription")]
        public async Task<IActionResult> DeleteInscription([FromQuery] int idLeader, [FromQuery] int idFollower, [FromQuery] int idMarathon)
        {
            var inscription = await _userService.Deleteinscription(idLeader, idFollower, idMarathon);
            if (inscription == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        //// PUT: api/Utilisateurs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        //{
        //    if (id != utilisateur.IdUtilisateur)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(utilisateur).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UtilisateurExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //private bool UtilisateurExists(int id)
        //{
        //    return _context.Utilisateurs.Any(e => e.IdUtilisateur == id);
        //}
    }
}
