using TangoRoom.Server.Models;

namespace TangoRoom.Server.Interfaces
{
    public interface IUtilisateurService
    {
        Task<List<Utilisateur>> GetUtilisateurs();
        Task<Utilisateur?> GetUtilisateur(int id);
        Task<Utilisateur?> CreationUtilisateur(Utilisateur utilisateur);
        Task<Inscription?> Deleteinscription(int idLeader, int idFollower, int idMarathon);

    }
}
