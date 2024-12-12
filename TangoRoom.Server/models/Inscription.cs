namespace TangoRoom.Server.models
{
    public class Inscription
    {
        public int IdInscription { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = "porec";



    }
}
