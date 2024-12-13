namespace TangoRoom.Server.models
{

    public enum StatutMarathon { disponible, clos }
    public class Marathon
    {
        public int IdMarathon { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime DateDebut { get; set; }
        public required DateTime DateFin { get; set; }
        public required DateTime DateFinInscription { get; set; }
        public List<Utilisateur> ListeInscritsPotentiels { get; set; } = [];
        public required StatutMarathon StatutMarathon { get; set; }

    }
}
