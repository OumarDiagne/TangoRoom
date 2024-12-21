namespace TangoRoom.Server.Models
{
    public enum StatutPersonnel { pas_interessé, disponible, inscrit }

    public abstract class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Planning Planning { get; set; } = new Planning();
        public Role Role { get; set; } = new Role();
        public StatutPersonnel StatutPersonnel { get; set; }

    }

    public class Leader : Utilisateur
    {


    }

    public class Follower : Utilisateur
    {


    }

}
