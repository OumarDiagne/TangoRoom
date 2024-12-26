namespace TangoRoom.Server.Models
{
    public enum StatutPersonnel { pas_interessé, disponible, inscrit }


    public class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public StatutPersonnel StatutPersonnel { get; set; }
        public int IdRole { get; set; }
        public virtual List<Marathon> Planning { get; set; } = [];
        public string Link { get; set; } = string.Empty;
        public bool ValideInscription { get; set; }


    }

    public class Follower : Utilisateur
    {
        public string TextInvitation { get; set; } = string.Empty;
    }
    public class Leader : Utilisateur
    {

    }


}
