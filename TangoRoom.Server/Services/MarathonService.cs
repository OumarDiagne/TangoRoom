using Microsoft.EntityFrameworkCore;
using TangoRoom.Server.Interfaces;
using TangoRoom.Server.Models;
using TangoRoom.Server.Models.Data;

namespace TangoRoom.Server.Services
{
    public class MarathonService(ContextTangoRoom contextTango) : IMarathonService
    {
        private readonly ContextTangoRoom _context = contextTango;

        public async Task<Marathon?> GetMarathon(int id)
        {
            var marathon = await _context.Marathons.FindAsync(id);

            return marathon;
        }

        public async Task<List<Marathon>> GetMarathons()
        {
            return await _context.Marathons.ToListAsync();
        }
    }
}
