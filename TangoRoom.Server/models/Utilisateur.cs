namespace TangoRoom.Server.models
{
    public enum Role { Leader = 1, Follower }
    public enum StatutPersonnel { pas_interessé, disponible, inscrit }

    public class Utilisateur : InscritPotentiel
    {
        public int IdUtilisateur { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public Planning? Planning { get; set; }

    }

    public class Leader : Utilisateur
    {
        public int Role { get; set; } = 1;
    }

    public class Follower : Utilisateur
    {
        public int Role { get; set; } = 2;

    }

    public class InscritPotentiel
    {
        public StatutPersonnel StatutPersonnel { get; set; }

    }

}
