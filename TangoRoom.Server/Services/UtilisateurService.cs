using Microsoft.EntityFrameworkCore;
using TangoRoom.Server.Interfaces;
using TangoRoom.Server.Models;
using TangoRoom.Server.Models.Data;

namespace TangoRoom.Server.Services
{
    public class UtilisateurService(ContextTangoRoom contextTango) : IUtilisateurService
    {
        private readonly ContextTangoRoom _context = contextTango;

        public Task<Utilisateur?> CreationUtilisateur(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public async Task<Inscription?> Deleteinscription(int idLeader, int idFollower, int idMarathon)
        {
            var inscription = await _context.Inscriptions.FindAsync(idLeader, idFollower, idMarathon);
            if (inscription == null)
            {
                return null;
            }
            _context.Inscriptions.Remove(inscription);
            await _context.SaveChangesAsync();
            return inscription;
        }

        public async Task<Utilisateur?> GetUtilisateur(int id)
        {
            var user = await _context.Utilisateurs.FindAsync(id);

            return user;
        }

        public async Task<List<Utilisateur>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync();
        }
    }
}
