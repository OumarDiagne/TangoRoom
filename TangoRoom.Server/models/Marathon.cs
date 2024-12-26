namespace TangoRoom.Server.Models
{

    public enum StatutMarathon { disponible, clos }
    public class Marathon
    {
        public int IdMarathon { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime DateFinInscription { get; set; }
        public virtual List<Utilisateur> ListeInscritsPotentiels { get; set; } = [];

        public StatutMarathon StatutMarathon { get; set; }

    }
}
