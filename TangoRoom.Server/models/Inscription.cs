namespace TangoRoom.Server.Models
{


    public class Inscription
    {
        public int IdLeader { get; set; }
        public int IdFollower { get; set; }
        public int IdMarathon { get; set; }
        public DateTime DateMatchUp { get; set; }
    }
}
